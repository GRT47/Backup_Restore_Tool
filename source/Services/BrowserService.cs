using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace BackupRestoreTool.Services
{
    public static class BrowserService
    {
        private static readonly string ChromeSource = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Google\Chrome\User Data");
        private static readonly string EdgeSource = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Microsoft\Edge\User Data");

        public static void BackupChrome() => BackupBrowser("Chrome", "chrome", ChromeSource);
        public static void RestoreChrome() => RestoreBrowser("Chrome", "chrome", ChromeSource);
        
        public static void BackupEdge() => BackupBrowser("Edge", "msedge", EdgeSource);
        public static void RestoreEdge() => RestoreBrowser("Edge", "msedge", EdgeSource);

        private static void BackupBrowser(string name, string processName, string sourcePath)
        {
            if (!GlobalConfig.IsBackupPathSet)
            {
                Logger.Error("백업 경로가 설정되지 않았습니다.");
                return;
            }

            string destPath = Path.Combine(GlobalConfig.BackupWritePath, name);
            Logger.Log($"{name} 백업 시작...");

            try
            {
                BackupService.KillProcess(processName);
                
                if (!Directory.Exists(sourcePath))
                {
                    Logger.Error($"{name} 소스 디렉토리를 찾을 수 없습니다: {sourcePath}");
                    return;
                }

                BackupService.CopyDirectory(sourcePath, destPath);
                Logger.Log($"{name} 백업 완료.");
            }
            catch (Exception ex)
            {
                Logger.Error($"{name} 백업 실패: {ex.Message}");
            }
        }

        private static void RestoreBrowser(string name, string processName, string targetPath)
        {
            if (!GlobalConfig.IsBackupPathSet) return; // Check if config initialized

            string backupPath = Path.Combine(GlobalConfig.RestoreReadPath, name);
            Logger.Log($"{name} 복원 시작...");

            if (!Directory.Exists(backupPath))
            {
                Logger.Error($"{backupPath}에서 {name} 백업을 찾을 수 없습니다.");
                return;
            }

            try
            {
                BackupService.KillProcess(processName);
                if (Directory.Exists(targetPath))
                {
                    // Optional: Clean target before restore? Specification says "Overwrite", CopyDirectory creates/overwrites.
                    // Usually safer to clear old data or just overwrite. XCopy behavior is overwrite.
                }

                BackupService.CopyDirectory(backupPath, targetPath);
                Logger.Log($"{name} 복원 완료.");
            }
            catch (Exception ex)
            {
                Logger.Error($"{name} 복원 실패: {ex.Message}");
            }
        }
        
        public static void RunInstaller(string browserName)
        {
             string installDir = Path.Combine(AppContext.BaseDirectory, "install");
             if (!Directory.Exists(installDir)) { Logger.Error("'install' 폴더를 찾을 수 없습니다."); return; }
             
             string[] files;
             if (browserName == "Edge")
             {
                 // Check both .exe and .msi for Edge
                 files = Directory.GetFiles(installDir, "Edge*.exe")
                          .Concat(Directory.GetFiles(installDir, "Edge*.msi")).ToArray();
             }
             else
             {
                 files = Directory.GetFiles(installDir, $"{browserName}*.exe");
             }

             if (files.Length > 0) 
             { 
                 Logger.Log($"{browserName} 설치 프로그램 실행 중: {Path.GetFileName(files[0])}"); 
                 ProcessStartInfo psi = new ProcessStartInfo {
                     FileName = files[0],
                     UseShellExecute = true
                 };
                 System.Diagnostics.Process.Start(psi); 
             }
             else 
             { 
                 Logger.Error($"{browserName} 설치 프로그램을 찾을 수 없습니다."); 
             }
        }

        public static bool HasBackup(string browserName)
        {
             if (!GlobalConfig.IsBackupPathSet) return false;
             return Directory.Exists(Path.Combine(GlobalConfig.RestoreReadPath, browserName));
        }

        public static void DeleteBackup(string browserName)
        {
            if (!GlobalConfig.IsBackupPathSet) return;
            string path = Path.Combine(GlobalConfig.BackupWritePath, browserName);
            try {
                BackupService.DeleteDirectory(path);
            } catch (Exception ex) { Logger.Error($"삭제 실패: {ex.Message}"); }
        }
        
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void OpenPasswordManager(string browserName)
        {
            // We run this synchronously on the calling thread (usually a Task.Run from RunTask)
            // But we need an STA thread for Clipboard/SendKeys, so we create one and WAIT for it.
            Exception? threadEx = null;
            Thread automationThread = new Thread(() =>
            {
                try
                {
                    string url = browserName == "Chrome" 
                        ? "chrome://password-manager/settings" 
                        : "edge://settings/autofill/passwords";
                    
                    string processName = browserName == "Chrome" ? "chrome" : "msedge";
                    
                    // 1. Copy URL to clipboard
                    Clipboard.SetText(url);

                    // 2. Start Browser
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = processName,
                        UseShellExecute = true
                    };
                    Process.Start(psi);

                    // 3. Wait for Window and Send keys
                    bool success = false;
                    for (int i = 0; i < 50; i++) // Max 10 seconds (200ms * 50)
                    {
                        var processes = Process.GetProcessesByName(processName);
                        foreach (var p in processes)
                        {
                            if (p.MainWindowHandle != IntPtr.Zero)
                            {
                                SetForegroundWindow(p.MainWindowHandle);
                                Thread.Sleep(1000); // Wait for focus stabilization
                                
                                SendKeys.SendWait("%d"); // Alt+D
                                Thread.Sleep(200);
                                SendKeys.SendWait("^v"); // Ctrl+V
                                Thread.Sleep(200);
                                SendKeys.SendWait("{ENTER}");
                                
                                success = true;
                                break;
                            }
                        }
                        if (success) break;
                        Thread.Sleep(200);
                    }

                    if (success)
                    {
                        Logger.Log($"{browserName} 비밀번호 관리자로 이동 완료.");
                    }
                    else
                    {
                        Logger.Error($"{browserName} 창을 찾을 수 없습니다.");
                    }
                }
                catch (Exception ex)
                {
                    threadEx = ex;
                }
            });

            automationThread.SetApartmentState(ApartmentState.STA);
            automationThread.Start();
            automationThread.Join(); // WAIT until automation is finished (important for RunTask block)

            if (threadEx != null) throw threadEx;
        }
    }
}
