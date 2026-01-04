using System;
using System.Collections.Generic;

namespace BackupRestoreTool.Services
{
    public static class Logger
    {
        public static event Action<string> OnLogReceived;

        public static void Log(string message)
        {
            string timeStampedMessage = $"[{DateTime.Now:HH:mm:ss}] {message}";
            OnLogReceived?.Invoke(timeStampedMessage);
        }

        public static void Error(string message)
        {
            Log($"[ERROR] {message}");
        }
    }
}
