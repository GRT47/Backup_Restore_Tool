using System;
using System.Diagnostics;
using System.IO;

namespace BackupRestoreTool.Services
{
    public static class BackupService
    {
        public static void CopyDirectory(string sourceDir, string destinationDir)
        {
            try
            {
                int totalFiles = GetFileCount(sourceDir);
                int copiedFiles = 0;
                CopyDirectoryInternal(sourceDir, destinationDir, totalFiles, ref copiedFiles);
                ProgressService.Report(100);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static int GetFileCount(string dirPath)
        {
            if (!Directory.Exists(dirPath)) return 0;
            try
            {
                string[] files = Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);
                return files.Length > 0 ? files.Length : 1;
            }
            catch { return 1; }
        }

        private static void CopyDirectoryInternal(string sourceDir, string destinationDir, int totalFiles, ref int copiedFiles)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(destinationDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath, true);
                
                copiedFiles++;
                int percent = (int)((double)copiedFiles / totalFiles * 100);
                ProgressService.Report(percent);
            }

            foreach (DirectoryInfo subDir in dirs)
            {
                string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectoryInternal(subDir.FullName, newDestinationDir, totalFiles, ref copiedFiles);
            }
        }

        public static void KillProcess(string processName)
        {
            try
            {
                Logger.Log($"프로세스 종료 중: {processName}...");
                foreach (var process in Process.GetProcessesByName(processName))
                {
                    process.Kill();
                    process.WaitForExit(3000); // Wait up to 3 seconds
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"프로세스 {processName} 종료 오류: {ex.Message}");
            }
        }

        public static bool IsDataExists(string path)
        {
            return Directory.Exists(path) || File.Exists(path);
        }

        public static void DeleteDirectory(string targetDir)
        {
            if (!Directory.Exists(targetDir)) return;

            Directory.Delete(targetDir, true); // Recursive delete
            Logger.Log($"삭제됨: {targetDir}");
        }
    }
}
