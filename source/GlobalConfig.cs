using System;
using System.IO;

namespace BackupRestoreTool
{
    public static class GlobalConfig
    {
        public static string BackupWritePath { get; private set; } = string.Empty;
        public static string RestoreReadPath { get; private set; } = string.Empty;

        public static void SetWritePath(string folderName)
        {
            if (string.IsNullOrWhiteSpace(folderName)) throw new ArgumentException("Folder name cannot be empty.");
            BackupWritePath = Path.Combine(AppContext.BaseDirectory, "Backup", folderName);
            if (!Directory.Exists(BackupWritePath)) Directory.CreateDirectory(BackupWritePath);
        }

        public static void SetReadPath(string fullPath)
        {
            RestoreReadPath = fullPath;
        }

        public static void Initialize(string folderName) {
             SetWritePath(folderName);
             SetReadPath(BackupWritePath);
        }

        public static bool IsBackupPathSet => !string.IsNullOrEmpty(BackupWritePath);
    }
}
