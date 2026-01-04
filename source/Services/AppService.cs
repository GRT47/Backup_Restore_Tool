using System;
using System.Diagnostics;
using System.IO;

namespace BackupRestoreTool.Services
{
    public static class AppService
    {
        // DesktopCal: %AppData%\DesktopCal
        // SMemo: C:\SMYSoft or %AppData%\SMemo. Requirement says check both or defined path. 
        // Doc says "C:\SMYSoft (or %AppData%)". I will check C:\SMYSoft first, then AppData.
        // StickyNotes: %LocalAppData%\Packages\Microsoft.MicrosoftStickyNotes_8wekyb3d8bbwe\LocalState
        
        private static readonly string DesktopCalSource = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DesktopCal");
        private static readonly string StickyNotesSource = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages\Microsoft.MicrosoftStickyNotes_8wekyb3d8bbwe\LocalState");
        
        private static string GetSMemoPath()
        {
             if (Directory.Exists(@"C:\SMYSoft")) return @"C:\SMYSoft";
             string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SMemo");
             if (Directory.Exists(appDataPath)) return appDataPath;
             return @"C:\SMYSoft"; // Default fallback
        }

        public static void BackupDesktopCal() => BackupApp("DesktopCal", "DesktopCal", DesktopCalSource);
        public static void RestoreDesktopCal() => RestoreApp("DesktopCal", "DesktopCal", DesktopCalSource);

        public static void BackupSMemo() => BackupApp("SMemo", "SMemo", GetSMemoPath());
        public static void RestoreSMemo() => RestoreApp("SMemo", "SMemo", GetSMemoPath());

        public static void BackupStickyNotes() => BackupApp("StickyNotes", "Microsoft.Notes", StickyNotesSource);
        public static void RestoreStickyNotes() => RestoreApp("StickyNotes", "Microsoft.Notes", StickyNotesSource);

        private static void BackupApp(string name, string processName, string sourcePath)
        {
            if (!GlobalConfig.IsBackupPathSet) { Logger.Error("백업 경로가 설정되지 않았습니다."); return; }
            string destPath = Path.Combine(GlobalConfig.BackupWritePath, name);
            
            Logger.Log($"{name} 백업 시작...");
            try
            {
                BackupService.KillProcess(processName);
                if (!Directory.Exists(sourcePath)) { Logger.Error($"{sourcePath}에서 {name}을(를) 찾을 수 없습니다."); return; }
                BackupService.CopyDirectory(sourcePath, destPath);
                Logger.Log($"{name} 백업 완료.");
            }
            catch (Exception ex) { Logger.Error($"{name} 백업 실패: {ex.Message}"); }
        }

        private static void RestoreApp(string name, string processName, string targetPath)
        {
            // Note: IsBackupPathSet checks WritePath, but here we care about ReadPath? 
            // Actually GlobalConfig initializes ReadPath too.
            string backupPath = Path.Combine(GlobalConfig.RestoreReadPath, name);

            Logger.Log($"{name} 복원 시작...");
            try
            {
                if (!Directory.Exists(backupPath)) { Logger.Error($"{name} 백업을 찾을 수 없습니다."); return; }
                BackupService.KillProcess(processName);
                BackupService.CopyDirectory(backupPath, targetPath);
                Logger.Log($"{name} 복원 완료.");
            }
            catch (Exception ex) { Logger.Error($"{name} 복원 실패: {ex.Message}"); }
        }
        
        public static void RunInstaller(string appName)
        {
             string pattern = appName switch 
             {
                 "DesktopCal" => "DesktopCal*.exe",
                 "SMemo" => "SMemo*.exe",
                 "StickyNotes" => "StickyNotes.bat",
                 _ => ""
             };
             if (string.IsNullOrEmpty(pattern)) return;

             string installDir = Path.Combine(AppContext.BaseDirectory, "install");
             if (!Directory.Exists(installDir)) return;
             
             var files = Directory.GetFiles(installDir, pattern);
             if (files.Length > 0) Process.Start(files[0]);
             else Logger.Error($"{appName} 설치 프로그램을 찾을 수 없습니다.");
        }
    }
}
