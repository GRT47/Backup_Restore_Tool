using System;
using System.IO;

namespace BackupRestoreTool.Services
{
    public static class CertService
    {
        private static readonly string NPKISource = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"..\LocalLow\NPKI");
        private static readonly string GPKISource = @"C:\GPKI";

        public static void BackupNPKI() => BackupCert("NPKI", NPKISource);
        public static void RestoreNPKI() => RestoreCert("NPKI", NPKISource);

        public static void BackupGPKI() => BackupCert("GPKI", GPKISource);
        public static void RestoreGPKI() => RestoreCert("GPKI", GPKISource);

        private static void BackupCert(string name, string sourcePath)
        {
            if (!GlobalConfig.IsBackupPathSet) { Logger.Error("백업 경로가 설정되지 않았습니다."); return; }
            string destPath = Path.Combine(GlobalConfig.BackupWritePath, "Certificates", name);
            
            Logger.Log($"{name} 백업 시작...");
            try
            {
                if (!Directory.Exists(sourcePath)) { Logger.Error($"{sourcePath}에서 {name}을(를) 찾을 수 없습니다."); return; }
                BackupService.CopyDirectory(sourcePath, destPath);
                Logger.Log($"{name} 백업 완료.");
            }
            catch (Exception ex) { Logger.Error($"{name} 백업 실패: {ex.Message}"); }
        }

        private static void RestoreCert(string name, string targetPath)
        {
            if (!GlobalConfig.IsBackupPathSet) return;
            string backupPath = Path.Combine(GlobalConfig.RestoreReadPath, "Certificates", name);

            Logger.Log($"{name} 복원 시작...");
            try
            {
                if (!Directory.Exists(backupPath)) { Logger.Error($"{name} 백업을 찾을 수 없습니다."); return; }
                BackupService.CopyDirectory(backupPath, targetPath);
                Logger.Log($"{name} 복원 완료.");
            }
            catch (Exception ex) { Logger.Error($"{name} 복원 실패: {ex.Message}"); }
        }
    }
}
