using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.Json;
using Microsoft.Win32;

namespace BackupRestoreTool.Services
{
    public class NetworkAdapterConfig
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string IP { get; set; } = "";
        public string Subnet { get; set; } = "";
        public string Gateway { get; set; } = "";
        public string CommonDNS { get; set; } = ""; // Preferred
        public string AlternateDNS { get; set; } = "";
        public bool DHCP { get; set; }
        public string InterfaceType { get; set; } = "Unknown";

        public override string ToString()
        {
            return $"{Name} ({IP})";
        }
    }

    public static class NetworkService
    {
        public static List<NetworkAdapterConfig> GetCurrentAdapters(bool includeInactive = false)
        {
            var list = new List<NetworkAdapterConfig>();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet || ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    // If includeInactive is true, skip Status check. Else, check for Up.
                    if (includeInactive || ni.OperationalStatus == OperationalStatus.Up)
                    {
                        var props = ni.GetIPProperties();
                        
                        // Handle unassigned IP case
                        var ipv4 = props?.UnicastAddresses?.FirstOrDefault(a => a.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                        
                        // If we found an IP, OR if unassigned are allowed
                        if (ipv4 != null || includeInactive)
                        {
                            var config = new NetworkAdapterConfig
                            {
                                Name = ni.Name,
                                Description = ni.Description,
                                // If ipv4 is null, use placeholder or empty
                                IP = ipv4?.Address.ToString() ?? "Disconnected",
                                Subnet = ipv4?.IPv4Mask.ToString() ?? "",
                                DHCP = props?.GetIPv4Properties()?.IsDhcpEnabled ?? false,
                                InterfaceType = (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) ? "Wireless" : "Wired"
                            };

                            if (props != null) {
                                var gateways = props.GatewayAddresses;
                                if (gateways != null && gateways.Count > 0) config.Gateway = gateways[0].Address.ToString();

                                var dns = props.DnsAddresses;
                                if (dns != null && dns.Count > 0) config.CommonDNS = dns[0].ToString();
                                if (dns != null && dns.Count > 1) config.AlternateDNS = dns[1].ToString();
                            }

                            // Fallback to Registry if disconnected, showing APIPA (169.254.x.x), or empty
                            if (includeInactive && (ni.OperationalStatus != OperationalStatus.Up || config.IP.StartsWith("169.254") || string.IsNullOrEmpty(config.IP) || config.IP == "Disconnected"))
                            {
                                FillStaticConfigFromRegistry(ni.Id, config);
                            }

                            list.Add(config);
                        }
                    }
                }
            }
            return list;
        }

        public static void BackupNetworkConfig(List<NetworkAdapterConfig>? targets = null)
        {
            if (!GlobalConfig.IsBackupPathSet) return;
            try
            {
                // If targets is null, get all. If provided, use them.
                var adapters = targets ?? GetCurrentAdapters(true);
                
                if (adapters.Count == 0) 
                {
                    Logger.Log("백업할 어댑터가 선택되지 않았습니다.");
                    return;
                }

                string jsonPath = Path.Combine(GlobalConfig.BackupWritePath, "NetworkConfig.json");
                string txtPath = Path.Combine(GlobalConfig.BackupWritePath, "NetworkConfig.txt");

                // Save JSON
                string json = JsonSerializer.Serialize(adapters, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonPath, json);

                // Save TXT
                using (StreamWriter sw = new StreamWriter(txtPath))
                {
                    foreach (var a in adapters)
                    {
                        sw.WriteLine($"Name: {a.Name}");
                        sw.WriteLine($"DHCP: {a.DHCP}");
                        sw.WriteLine($"IP: {a.IP}");
                        sw.WriteLine($"Subnet: {a.Subnet}");
                        sw.WriteLine($"Gateway: {a.Gateway}");
                        sw.WriteLine($"DNS1: {a.CommonDNS}");
                        sw.WriteLine($"DNS2: {a.AlternateDNS}");
                        sw.WriteLine("------------------------------");
                    }
                }
                Logger.Log($"네트워크 설정 백업 완료: {adapters.Count}개 어댑터.");
                ProgressService.Report(100);
            }
            catch (Exception ex)
            {
                Logger.Error($"네트워크 백업 실패: {ex.Message}");
            }
        }

        public static List<NetworkAdapterConfig> LoadBackupConfig()
        {
            if (!GlobalConfig.IsBackupPathSet) return new List<NetworkAdapterConfig>();
            string jsonPath = Path.Combine(GlobalConfig.RestoreReadPath, "NetworkConfig.json");
            if (!File.Exists(jsonPath)) return new List<NetworkAdapterConfig>();

            try
            {
                string json = File.ReadAllText(jsonPath);
                return JsonSerializer.Deserialize<List<NetworkAdapterConfig>>(json) ?? new List<NetworkAdapterConfig>();
            }
            catch
            {
                return new List<NetworkAdapterConfig>();
            }
        }

        public static void RestoreAdapter(NetworkAdapterConfig config, string targetAdapterName)
        {
            Logger.Log($"인터페이스 '{targetAdapterName}'에 IP 복원 중...");
            try
            {
                if (config.DHCP)
                {
                    RunNetsh($"interface ip set address \"{targetAdapterName}\" dhcp");
                    RunNetsh($"interface ip set dns \"{targetAdapterName}\" dhcp");
                }
                else
                {
                    // Static IP
                    // netsh interface ip set address "Name" static IP Mask Gateway 1
                    string cmd = $"interface ip set address \"{targetAdapterName}\" static {config.IP} {config.Subnet}";
                    if (!string.IsNullOrEmpty(config.Gateway)) cmd += $" {config.Gateway}";
                    RunNetsh(cmd);
                    ProgressService.Report(50);

                    // DNS
                    if (!string.IsNullOrEmpty(config.CommonDNS))
                    {
                        RunNetsh($"interface ip set dns \"{targetAdapterName}\" static {config.CommonDNS}");
                        if (!string.IsNullOrEmpty(config.AlternateDNS))
                        {
                            RunNetsh($"interface ip add dns \"{targetAdapterName}\" {config.AlternateDNS} index=2");
                        }
                    }
                }
                Logger.Log("네트워크 복원 명령이 실행되었습니다.");
                ProgressService.Report(100);
            }
            catch (Exception ex)
            {
                Logger.Error($"네트워크 복원 실패: {ex.Message}");
            }
        }

        private static void RunNetsh(string args)
        {
             ProcessStartInfo psi = new ProcessStartInfo("netsh", args);
             psi.UseShellExecute = true;
             psi.Verb = "runas";
             psi.WindowStyle = ProcessWindowStyle.Hidden;
             Process.Start(psi)?.WaitForExit();
        }

        private static void FillStaticConfigFromRegistry(string interfaceId, NetworkAdapterConfig config)
        {
            try
            {
                string keyPath = $@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces\{interfaceId}";
                using (RegistryKey? key = Registry.LocalMachine.OpenSubKey(keyPath))
                {
                    if (key == null) return;

                    // 1. DHCP Status
                    object? dhcpEnabled = key.GetValue("EnableDHCP");
                    config.DHCP = (dhcpEnabled is int val && val == 1);

                    if (!config.DHCP)
                    {
                        // 2. IP Address (REG_MULTI_SZ)
                        if (key.GetValue("IPAddress") is string[] ips && ips.Length > 0) config.IP = ips[0];
                        
                        // 3. Subnet Mask (REG_MULTI_SZ)
                        if (key.GetValue("SubnetMask") is string[] masks && masks.Length > 0) config.Subnet = masks[0];

                        // 4. Default Gateway (REG_MULTI_SZ)
                        if (key.GetValue("DefaultGateway") is string[] gateways && gateways.Length > 0) config.Gateway = gateways[0];

                        // 5. DNS (String, space/comma separated)
                        string dns = key.GetValue("NameServer") as string ?? "";
                        if (!string.IsNullOrEmpty(dns))
                        {
                            var dnsPart = dns.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (dnsPart.Length > 0) config.CommonDNS = dnsPart[0];
                            if (dnsPart.Length > 1) config.AlternateDNS = dnsPart[1];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"레지스트리 설정 읽기 실패 ({interfaceId}): {ex.Message}");
            }
        }
    }
}
