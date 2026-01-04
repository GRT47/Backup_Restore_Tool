using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace BackupRestoreTool.Services
{
    public class BackupSummary
    {
        public string SessionName { get; set; } = "";
        public string BackupDate { get; set; } = "";
        public List<string> NetworkAdapters { get; set; } = new List<string>();
        public List<string> Printers { get; set; } = new List<string>();
        public bool HasPrinterTxt { get; set; }
        public bool HasPrinterFull { get; set; }
        public bool HasChrome { get; set; }
        public bool HasEdge { get; set; }
        public bool HasNPKI { get; set; }
        public bool HasGPKI { get; set; }
        public bool HasDesktopCal { get; set; }
        public bool HasSMemo { get; set; }
        public bool HasStickyNotes { get; set; }
        public long TotalSize { get; set; }
    }

    public static class CheckService
    {
        public static BackupSummary GetSummary(string folderPath)
        {
            var summary = new BackupSummary();
            if (!Directory.Exists(folderPath)) return summary;

            var dirInfo = new DirectoryInfo(folderPath);
            summary.SessionName = dirInfo.Name;
            summary.BackupDate = dirInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");

            // 1. Network
            string netFile = Path.Combine(folderPath, "NetworkConfig.json");
            if (File.Exists(netFile))
            {
                try
                {
                    string json = File.ReadAllText(netFile);
                    var configs = JsonSerializer.Deserialize<List<NetworkAdapterConfig>>(json);
                    if (configs != null)
                    {
                        summary.NetworkAdapters = configs.Select(c => $"{c.Name} ({c.IP})").ToList();
                    }
                }
                catch { }
            }

            // 2. Printers
            string printerFile = Path.Combine(folderPath, "프린터정보.txt");
            if (File.Exists(printerFile))
            {
                summary.HasPrinterTxt = true;
                try
                {
                    var lines = File.ReadAllLines(printerFile);
                    foreach (var line in lines)
                    {
                        if (line.Contains("Name            :"))
                        {
                            summary.Printers.Add(line.Split(':')[1].Trim());
                        }
                    }
                }
                catch { }
            }
            
            summary.HasPrinterFull = File.Exists(Path.Combine(folderPath, "PrinterFullBackup.printerExport"));

            // Get All Subdirectories for robust matching
            var allSubDirs = Directory.GetDirectories(folderPath, "*", SearchOption.TopDirectoryOnly).Select(Path.GetFileName).ToList();
            var certDir = allSubDirs.FirstOrDefault(d => d.Equals("Certificates", StringComparison.OrdinalIgnoreCase));
            List<string> certSubs = new List<string>();
            if (certDir != null)
            {
                certSubs = Directory.GetDirectories(Path.Combine(folderPath, certDir)).Select(Path.GetFileName).ToList();
            }

            // 3. Browsers
            summary.HasChrome = allSubDirs.Any(d => d.Equals("Chrome", StringComparison.OrdinalIgnoreCase));
            summary.HasEdge = allSubDirs.Any(d => d.Equals("Edge", StringComparison.OrdinalIgnoreCase));

            // 4. Certs (Check root OR Certificates subfolder)
            summary.HasNPKI = allSubDirs.Any(d => d.Equals("NPKI", StringComparison.OrdinalIgnoreCase)) ||
                             certSubs.Any(d => d.Equals("NPKI", StringComparison.OrdinalIgnoreCase));
            summary.HasGPKI = allSubDirs.Any(d => d.Equals("GPKI", StringComparison.OrdinalIgnoreCase)) ||
                             certSubs.Any(d => d.Equals("GPKI", StringComparison.OrdinalIgnoreCase));

            // 5. Apps
            summary.HasDesktopCal = allSubDirs.Any(d => d.Equals("DesktopCal", StringComparison.OrdinalIgnoreCase));
            summary.HasSMemo = allSubDirs.Any(d => d.Equals("SMemo", StringComparison.OrdinalIgnoreCase));
            summary.HasStickyNotes = allSubDirs.Any(d => d.Equals("StickyNotes", StringComparison.OrdinalIgnoreCase));

            // Total Size
            summary.TotalSize = GetDirectorySize(folderPath);

            return summary;
        }


        private static long GetDirectorySize(string path)
        {
            long size = 0;
            try
            {
                var dir = new DirectoryInfo(path);
                foreach (var fi in dir.GetFiles("*", SearchOption.AllDirectories))
                {
                    size += fi.Length;
                }
            }
            catch { }
            return size;
        }
    }
}
