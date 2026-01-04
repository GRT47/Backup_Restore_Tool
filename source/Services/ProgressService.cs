using System;

namespace BackupRestoreTool.Services
{
    public static class ProgressService
    {
        public static event Action<int> OnProgressChanged;

        public static void Report(int percentage)
        {
            if (percentage < 0) percentage = 0;
            if (percentage > 100) percentage = 100;
            OnProgressChanged?.Invoke(percentage);
        }

        public static void Reset()
        {
            OnProgressChanged?.Invoke(0);
        }
    }
}
