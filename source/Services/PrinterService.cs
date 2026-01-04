using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

// Wait, .NET 6 System.Management needs nuget package 'System.Management'.
// I should add package System.Management or use PowerShell/CLI commands if I want to avoid Nuget.
// The instructions said "dll dependency issue free single file".
// System.Management is a standard Windows capability but in .NET Core/.NET 5+ it is a nuget package.
// To avoid Nuget, I can use 'wmic' or PowerShell via Process.

namespace BackupRestoreTool.Services
{
    public static class PrinterService
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, uint cchBuffer);

        private static string ToShortPath(string longPath)
        {
            StringBuilder sb = new StringBuilder(260);
            uint result = GetShortPathName(longPath, sb, (uint)sb.Capacity);
            if (result == 0) return longPath;
            return sb.ToString();
        }

        public static void BackupPrinterInfoText()
        {
            if (!GlobalConfig.IsBackupPathSet) return;
            string filePath = Path.Combine(GlobalConfig.BackupWritePath, "프린터정보.txt");
            Logger.Log("프린터 목록 내보내는 중...");

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "powershell";
                string script = "$ports = Get-WmiObject Win32_TCPIPPrinterPort; " +
                                "Get-WmiObject Win32_Printer | ForEach-Object { " +
                                "$p = $_; " +
                                "$port = $ports | Where-Object { $_.Name -eq $p.PortName }; " +
                                "[PSCustomObject]@{ " +
                                "Default = $p.Default; " +
                                "Name = $p.Name; " +
                                "DriverName = $p.DriverName; " +
                                "PortName = $p.PortName; " +
                                "HostAddress = if ($port) { $port.HostAddress } else { '' } " +
                                "} } | Format-List | Out-String";

                psi.Arguments = $"-Command \"{script}\"";
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                using (Process p = Process.Start(psi))
                {
                    ProgressService.Report(80);
                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                    File.WriteAllText(filePath, output);
                }
                Logger.Log("프린터 정보 저장 완료.");
                ProgressService.Report(100);
            }
            catch (Exception ex)
            {
                Logger.Error($"프린터 정보 내보내기 실패: {ex.Message}");
            }
        }

        public static void BackupFullSystem()
        {
            if (!GlobalConfig.IsBackupPathSet) return;

            // Always include text-based info export in full backup
            BackupPrinterInfoText();
            
            string targetDir = GlobalConfig.BackupWritePath;
            if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);

            string fileName = "PrinterFullBackup.printerExport";
            string filePath = Path.Combine(targetDir, fileName);
            
            Logger.Log("전체 프린터 백업 시작 (Short Path Fix)...");
            
            try
            {
                if (File.Exists(filePath)) File.Delete(filePath);

                // Convert to Short Path (8.3) to avoid spaces and quotes which confuse PrintBrm
                string shortPath = ToShortPath(filePath);
                
                // NO QUOTES around shortPath
                string args = $"-B -f {shortPath}";
                RunPrintBrm(args);
                
                if (File.Exists(filePath))
                {
                    Logger.Log("프린터 백업 완료.");
                    ProgressService.Report(100);
                }
                else
                {
                    Logger.Error("프린터 백업 파일이 생성되지 않았습니다.");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"프린터 백업 실패: {ex.Message}");
            }
        }

        public static void RestoreFullSystem()
        {
            if (!GlobalConfig.IsBackupPathSet) return;
            string targetDir = GlobalConfig.RestoreReadPath;
            string fileName = "PrinterFullBackup.printerExport";
            string filePath = Path.Combine(targetDir, fileName);
            
            if (!File.Exists(filePath))
            {
                Logger.Error("프린터 백업 파일을 찾을 수 없습니다.");
                return;
            }

            Logger.Log("전체 프린터 복원 시작 (Short Path Fix)...");
            
            try
            {
                string shortPath = ToShortPath(filePath);
                string args = $"-R -f {shortPath}";
                RunPrintBrm(args);
                ProgressService.Report(100);
            }
            catch (Exception ex)
            {
                Logger.Error($"프린터 복원 실패: {ex.Message}");
            }
        }

        private static void RunPrintBrm(string args)
        {
            try
            {
                string sys = Environment.GetFolderPath(Environment.SpecialFolder.System);
                string exe = Path.Combine(sys, @"spool\tools\PrintBrm.exe");
                if (!File.Exists(exe)) exe = Path.Combine(sys, "PrintBrm.exe");

                if (!File.Exists(exe))
                {
                    Logger.Error("PrintBrm.exe를 찾을 수 없습니다.");
                    return;
                }

                Logger.Log($"실행: {exe} {args}");

                // Use Regex to parse percentage from output: ************ 10% ************
                var progressRegex = new Regex(@"(\d+)%");

                ProcessStartInfo psi = new ProcessStartInfo(exe, args)
                {
                    UseShellExecute = false, // Redirect requires false
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (Process? p = Process.Start(psi))
                {
                    if (p != null)
                    {
                        // Real-time output parsing
                        while (!p.StandardOutput.EndOfStream)
                        {
                            string? line = p.StandardOutput.ReadLine();
                            if (string.IsNullOrEmpty(line)) continue;

                            var match = progressRegex.Match(line);
                            if (match.Success)
                            {
                                if (int.TryParse(match.Groups[1].Value, out int percent))
                                {
                                    ProgressService.Report(percent);
                                }
                            }
                        }
                        p.WaitForExit();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"PrintBrm 실행 실패: {ex.Message}");
            }
        }
    }
}
