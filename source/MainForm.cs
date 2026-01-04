using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using BackupRestoreTool.Services;

namespace BackupRestoreTool
{
    public partial class MainForm : Form
    {
        private bool _isBusy = false;

        public MainForm()
        {
            InitializeComponent();

            // Load embedded branding resources safely after InitializeComponent
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("BackupRestoreTool.icon.ico"))
            {
                if (stream != null) this.Icon = new Icon(stream);
            }

            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("BackupRestoreTool.icon.png"))
            {
                if (stream != null) picLogo.Image = Image.FromStream(stream);
            }

            // Set lblPercent parent to progressBar for true transparency
            lblPercent.Parent = progressBar;
            lblPercent.BackColor = Color.Transparent;
            lblPercent.Location = new Point(0, 0); // Temporary, UpdateProgress will handle centering

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            string folderName = "DefaultBackup";

            try
            {
                GlobalConfig.Initialize(folderName);
                this.Text = "PC 백업 & 복원 도구 v2.0 (Build 26.01.04 19:15)";
                Logger.Log($"세션 초기화됨: {folderName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"초기 설정 중 오류 발생: {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            // Update Session UI
            txtSession.Text = new DirectoryInfo(GlobalConfig.BackupWritePath).Name;

            // Wire Events
            WireBackupEvents();
            WireRestoreEvents();
            WireCheckEvents();

            Logger.OnLogReceived += UpdateLog;
            ProgressService.OnProgressChanged += UpdateProgress;

            // Initial Data Load
            RefreshBackupLists();
            RefreshRestoreLists();
            RefreshCheckLists();
        }

        private void WireBackupEvents()
        {
            // Session
            btnSessionChange.Click += (s, e) =>
            {
                string newFolder = InputBox.Show("세션 변경", "새로운 백업 세션(폴더) 이름을 입력하세요", "NewBackup");
                if (!string.IsNullOrWhiteSpace(newFolder))
                {
                    GlobalConfig.SetWritePath(newFolder);
                    txtSession.Text = newFolder;
                    this.Text = $"Backup & Restore Tool - 백업(쓰기): {newFolder}";
                    Logger.Log($"쓰기 세션 변경됨: {newFolder}");
                    RefreshBackupLists(); // Refresh lists as path changed
                }
            };
            btnSessionDelete.Click += (s, e) =>
            {
                if (MessageBox.Show($"현재 백업 세션 폴더 '{GlobalConfig.BackupWritePath}'를 완전히 삭제하시겠습니까?\n이 작업은 되돌릴 수 없습니다.", "세션 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    RunTask(() =>
                    {
                        BackupService.DeleteDirectory(GlobalConfig.BackupWritePath);
                        Logger.Log("세션 삭제됨.");
                    });
                }
            };

            // Browsers
            btnPwdChrome.Click += (s, e) => RunTask(() => BrowserService.OpenPasswordManager("Chrome"));
            btnPwdEdge.Click += (s, e) => RunTask(() => BrowserService.OpenPasswordManager("Edge"));
            btnBackupBrowsers.Click += (s, e) =>
            {
                if (_isBusy) return;
                if (!chkChrome.Checked && !chkEdge.Checked) { MessageBox.Show("최소 하나의 브라우저를 선택해주세요."); return; }
                RunTask(() =>
                {
                    if (chkChrome.Checked) BrowserService.BackupChrome();
                    if (chkEdge.Checked) BrowserService.BackupEdge();
                });
            };

            // Certs
            btnBackupCerts.Click += (s, e) => RunTask(() => { CertService.BackupNPKI(); CertService.BackupGPKI(); });

            // Network
            btnRefreshNet.Click += (s, e) => RefreshBackupLists();
            btnBackupNet.Click += (s, e) => RunTask(() =>
            {
                var selectedConfigs = lstNetSource.CheckedItems.Cast<NetworkAdapterConfig>().ToList();
                if (selectedConfigs.Count == 0) { MessageBox.Show("백업할 네트워크 어댑터를 선택해주세요.", "알림"); return; }
                NetworkService.BackupNetworkConfig(selectedConfigs);
                this.Invoke(new Action(RefreshBackupLists));
            });

            // Printers
            btnPrinterTxt.Click += (s, e) => RunTask(() => PrinterService.BackupPrinterInfoText());
            btnPrinterFull.Click += (s, e) => RunTask(() => PrinterService.BackupFullSystem());

            // Apps
            btnBackupApp1.Click += (s, e) => RunTask(() => AppService.BackupDesktopCal()); // DesktopCal
            btnBackupApp2.Click += (s, e) => RunTask(() => AppService.BackupSMemo()); // SMemo
            btnBackupApp3.Click += (s, e) => RunTask(() => AppService.BackupStickyNotes()); // StickyNotes

            // Backup All
            btnBackupAll.Click += (s, e) =>
            {
                string msg = "다음 모든 항목에 대한 백업을 시작하시겠습니까?\n\n" +
                             "1. 웹 브라우저 (Chrome, Edge 사용자 데이터)\n" +
                             "2. 공인인증서 (NPKI, GPKI)\n" +
                             "3. 네트워크 설정 (IP 주소 정보)\n" +
                             "4. 프린터 목록 (텍스트 리스트)\n" +
                             "5. 앱 데이터 (DesktopCal, SMemo, StickyNotes)";

                if (MessageBox.Show(msg, "전체 백업 시작", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RunTask(() =>
                    {
                        BrowserService.BackupChrome();
                        BrowserService.BackupEdge();
                        CertService.BackupNPKI();
                        CertService.BackupGPKI();
                        NetworkService.BackupNetworkConfig();
                        PrinterService.BackupPrinterInfoText(); // User specifically asked for txt list only
                        AppService.BackupDesktopCal();
                        AppService.BackupSMemo();
                        AppService.BackupStickyNotes();
                        this.Invoke(new Action(RefreshBackupLists));
                    });
                }
            };
        }

        private void WireRestoreEvents()
        {
            // Session List
            btnRestRefresh.Click += (s, e) => RefreshRestoreLists();
            cmbRestSessions.SelectedIndexChanged += (s, e) =>
            {
                if (cmbRestSessions.SelectedItem != null)
                {
                    string folderName = cmbRestSessions.SelectedItem.ToString() ?? "";
                    string fullPath = Path.Combine(AppContext.BaseDirectory, "Backup", folderName);
                    GlobalConfig.SetReadPath(fullPath);
                    lblRestSelected.Text = "선택됨: " + folderName;
                    Logger.Log($"복원 원본 설정됨: {folderName}");
                    RefreshRestoreNetworkListOnly(); // Refresh Inner lists based on selection
                }
            };

            // Browsers
            btnInstChrome.Click += (s, e) => BrowserService.RunInstaller("Chrome");
            btnInstEdge.Click += (s, e) => BrowserService.RunInstaller("Edge");
            btnRestoreBrowsers.Click += (s, e) =>
            {
                if (!chkChromeRest.Checked && !chkEdgeRest.Checked) { MessageBox.Show("최소 하나의 브라우저를 선택해주세요."); return; }
                RunTask(() =>
                {
                    if (chkChromeRest.Checked) BrowserService.RestoreChrome();
                    if (chkEdgeRest.Checked) BrowserService.RestoreEdge();
                }, confirm: true);
            };

            // Certs
            btnRestoreCerts.Click += (s, e) => RunTask(() => { CertService.RestoreNPKI(); CertService.RestoreGPKI(); }, confirm: true);

            // Network
            btnRefreshRestNet.Click += (s, e) => RefreshRestoreNetworkListOnly();
            btnRestoreNet.Click += (s, e) =>
            {
                if (lstNetRestSource.SelectedIndex < 0 || lstNetRestTarget.SelectedIndex < 0) { MessageBox.Show("백업 및 타겟 어댑터를 모두 선택해주세요."); return; }
                var backups = NetworkService.LoadBackupConfig();
                if (backups.Count <= lstNetRestSource.SelectedIndex) return;
                var config = backups[lstNetRestSource.SelectedIndex];

                var targetWrapper = lstNetRestTarget.SelectedItem as AdapterDetailItem;
                string targetName = targetWrapper?.Config.Name ?? "";

                RunTask(() => NetworkService.RestoreAdapter(config, targetName));
            };

            // Printers
            btnRestorePrinters.Click += (s, e) => RunTask(() => PrinterService.RestoreFullSystem(), confirm: true);

            // Apps
            btnRestApp1.Click += (s, e) => RunTask(() => AppService.RestoreDesktopCal(), confirm: true);
            btnInstApp1.Click += (s, e) => AppService.RunInstaller("DesktopCal");

            btnRestApp2.Click += (s, e) => RunTask(() => AppService.RestoreSMemo(), confirm: true);
            btnInstApp2.Click += (s, e) => AppService.RunInstaller("SMemo");

            btnRestApp3.Click += (s, e) => RunTask(() => AppService.RestoreStickyNotes(), confirm: true);
            btnInstApp3.Click += (s, e) => AppService.RunInstaller("StickyNotes");

            // Restore All
            btnRestoreAll.Click += (s, e) =>
            {
                string msg = "다음 모든 항목에 대한 복원을 시작하시겠습니까?\n" +
                             "(기존 데이터가 백업본으로 교체됩니다)\n\n" +
                             "1. 웹 브라우저 (Chrome, Edge 사용자 데이터)\n" +
                             "2. 공인인증서 (NPKI, GPKI)\n" +
                             "3. 앱 데이터 (DesktopCal, SMemo, StickyNotes)\n\n" +
                             "※ 네트워크 및 프린터는 안전을 위해 수동 복원을 권장합니다.";

                if (MessageBox.Show(msg, "전체 복원 시작 (주의)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    RunTask(() =>
                    {
                        BrowserService.RestoreChrome();
                        BrowserService.RestoreEdge();
                        CertService.RestoreNPKI();
                        CertService.RestoreGPKI();
                        AppService.RestoreDesktopCal();
                        AppService.RestoreSMemo();
                        AppService.RestoreStickyNotes();
                    });
                }
            };
        }


        private void RefreshBackupLists()
        {
            lstNetSource.Items.Clear();
            lstNetBackup.Items.Clear();
            foreach (var a in NetworkService.GetCurrentAdapters(true))
            {
                if (!a.DHCP) lstNetSource.Items.Add(a, true);
            }
            foreach (var b in NetworkService.LoadBackupConfig()) lstNetBackup.Items.Add(b.Name + " (" + b.IP + ")");
        }

        private void RefreshRestoreLists()
        {
            // Session List
            cmbRestSessions.Items.Clear();
            string baseDir = Path.Combine(AppContext.BaseDirectory, "Backup");
            if (Directory.Exists(baseDir))
            {
                foreach (var d in Directory.GetDirectories(baseDir))
                {
                    cmbRestSessions.Items.Add(new DirectoryInfo(d).Name);
                }
            }
            if (cmbRestSessions.Items.Count > 0)
            {
                cmbRestSessions.SelectedIndex = 0; // Triggers SelectedIndexChanged -> RefreshRestoreNetworkListOnly
            }
        }

        private void RefreshRestoreNetworkListOnly()
        {
            lstNetRestSource.Items.Clear();
            lstNetRestTarget.Items.Clear();
            foreach (var b in NetworkService.LoadBackupConfig()) lstNetRestSource.Items.Add(b.Name + " (" + b.IP + ")");
            foreach (var a in NetworkService.GetCurrentAdapters(true)) lstNetRestTarget.Items.Add(new AdapterDetailItem(a));
        }

        private void WireCheckEvents()
        {
            btnCheckRefresh.Click += (s, e) => RefreshCheckLists();
            cmbCheckSessions.SelectedIndexChanged += (s, e) =>
            {
                if (cmbCheckSessions.SelectedItem != null)
                {
                    string folderName = cmbCheckSessions.SelectedItem.ToString() ?? "";
                    lblCheckSelected.Text = "선택됨: " + folderName;
                    UpdateCheckSummary(folderName);
                }
            };
        }

        private void RefreshCheckLists()
        {
            cmbCheckSessions.Items.Clear();
            string baseDir = Path.Combine(AppContext.BaseDirectory, "Backup");
            if (Directory.Exists(baseDir))
            {
                foreach (var d in Directory.GetDirectories(baseDir))
                {
                    cmbCheckSessions.Items.Add(new DirectoryInfo(d).Name);
                }
            }
            if (cmbCheckSessions.Items.Count > 0)
            {
                cmbCheckSessions.SelectedIndex = 0;
            }
        }

        private void UpdateCheckSummaryByPath(string fullPath)
        {
            var summary = CheckService.GetSummary(fullPath);

            rtbSummary.Clear();
            AppendBoldText("■ 백업 세션 정보\n");
            rtbSummary.AppendText($"  세션 이름: {summary.SessionName}\n");
            rtbSummary.AppendText($"  백업 일시: {summary.BackupDate}\n");
            rtbSummary.AppendText($"  전체 용량: {FormatSize(summary.TotalSize)}\n\n");

            AppendBoldText("■ 네트워크 설정 (JSON)\n");
            if (summary.NetworkAdapters.Count > 0)
                summary.NetworkAdapters.ForEach(a => AppendStatusLine($"  [V] {a}", true));
            else
                AppendStatusLine("  [X] 네트워크 백업 정보 없음", false);
            rtbSummary.AppendText("\n");

            AppendBoldText("■ 프린터 정보\n");
            AppendStatusLine($"  리스트(Txt):   {(summary.HasPrinterTxt ? "[V] 존재" : "[X] 없음")}", summary.HasPrinterTxt);
            AppendStatusLine($"  전체백업(Full): {(summary.HasPrinterFull ? "[V] 존재" : "[X] 없음")}", summary.HasPrinterFull);
            if (summary.Printers.Count > 0)
            {
                rtbSummary.AppendText("  검색된 프린터 목록:\n");
                summary.Printers.ForEach(p => rtbSummary.AppendText($"    - {p}\n"));
            }
            rtbSummary.AppendText("\n");

            AppendBoldText("■ 웹 브라우저 사용자 데이터\n");
            AppendStatusLine($"  Chrome: {(summary.HasChrome ? "[V] 존재" : "[X] 없음")}", summary.HasChrome);
            AppendStatusLine($"  Edge:   {(summary.HasEdge ? "[V] 존재" : "[X] 없음")}", summary.HasEdge);
            rtbSummary.AppendText("\n");

            AppendBoldText("■ 인증서 (NPKI/GPKI)\n");
            AppendStatusLine($"  NPKI: {(summary.HasNPKI ? "[V] 존재" : "[X] 없음")}", summary.HasNPKI);
            AppendStatusLine($"  GPKI: {(summary.HasGPKI ? "[V] 존재" : "[X] 없음")}", summary.HasGPKI);
            rtbSummary.AppendText("\n");

            AppendBoldText("■ 응용 프로그램 데이터\n");
            AppendStatusLine($"  DesktopCal:  {(summary.HasDesktopCal ? "[V] 존재" : "[X] 없음")}", summary.HasDesktopCal);
            AppendStatusLine($"  SMemo:       {(summary.HasSMemo ? "[V] 존재" : "[X] 없음")}", summary.HasSMemo);
            AppendStatusLine($"  StickyNotes: {(summary.HasStickyNotes ? "[V] 존재" : "[X] 없음")}", summary.HasStickyNotes);
        }

        private void AppendStatusLine(string text, bool success)
        {
            rtbSummary.SelectionStart = rtbSummary.TextLength;
            rtbSummary.SelectionLength = 0;
            rtbSummary.SelectionColor = success ? Color.SeaGreen : Color.Gray;
            if (success) rtbSummary.SelectionFont = new Font(rtbSummary.Font, FontStyle.Bold);
            
            rtbSummary.AppendText(text + "\n");
            
            rtbSummary.SelectionColor = rtbSummary.ForeColor;
            rtbSummary.SelectionFont = new Font(rtbSummary.Font, FontStyle.Regular);
        }

        private void UpdateCheckSummary(string folderName)
        {
            string fullPath = Path.Combine(AppContext.BaseDirectory, "Backup", folderName);
            UpdateCheckSummaryByPath(fullPath);
        }

        private void AppendBoldText(string text)
        {
            rtbSummary.SelectionStart = rtbSummary.TextLength;
            rtbSummary.SelectionLength = 0;
            rtbSummary.SelectionFont = new Font(rtbSummary.Font, FontStyle.Bold);
            rtbSummary.AppendText(text);
            rtbSummary.SelectionFont = new Font(rtbSummary.Font, FontStyle.Regular);
        }

        private void RunTask(Action action, bool confirm = false)
        {
            if (_isBusy) return;

            if (confirm)
            {
                if (MessageBox.Show("복원/삭제를 진행하시겠습니까?\n기존 데이터가 덮어씌워지거나 삭제됩니다.", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
            }

            SetUIBusy(true);

            if (progressBar != null && !progressBar.IsDisposed)
            {
                progressBar.Value = 0;
                lblPercent.Text = "0%";
            }

            Task.Run(() =>
            {
                try { action(); }
                catch (Exception ex) { Logger.Error(ex.Message); }
                finally
                {
                    this.Invoke(() =>
                    {
                        SetUIBusy(false);

                        if (progressBar != null && !progressBar.IsDisposed)
                        {
                            if (progressBar.Value >= 100)
                            {
                                // 100% 도달시 잠시 대기 후 리셋 (숨기지 않음)
                                Task.Delay(1000).ContinueWith(_ => this.Invoke(() => { 
                                    if (!progressBar.IsDisposed) {
                                        progressBar.Value = 0;
                                        lblPercent.Text = "0%";
                                    }
                                }));
                            }
                        }
                    });
                }
            });
        }

        private void SetUIBusy(bool busy)
        {
            _isBusy = busy;

            // FOOLPROOF LOCK: Disable the entire panel containing all buttons/tabs
            pnlMiddle.Enabled = !busy;

            // Explicitly disable and change color for extreme visibility
            btnPwdChrome.Enabled = !busy;
            btnPwdEdge.Enabled = !busy;
            btnBackupBrowsers.Enabled = !busy;
            btnBackupAll.Enabled = !busy;

            btnPwdChrome.BackColor = busy ? Color.DarkGray : Color.WhiteSmoke;
            btnPwdEdge.BackColor = busy ? Color.DarkGray : Color.WhiteSmoke;
            btnBackupBrowsers.BackColor = busy ? Color.Orange : Color.AliceBlue;

            // Visual feedback
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
            
            if (busy) Logger.Log("UI 잠금 활성화 (작업 완료까지 버튼 사용 불가)");
            else Logger.Log("UI 잠금 해제 (이제 다른 작업을 수행할 수 있습니다)");
            
            Application.DoEvents(); // Force UI to update immediate changes
        }

        private void UpdateProgress(int val)
        {
            if (progressBar.IsDisposed) return;
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<int>(UpdateProgress), val);
                return;
            }

            progressBar.Value = val;
            lblPercent.Text = $"{val}%";

            // Ensure they are visible when progress happens
            progressBar.Visible = true;
            lblPercent.Visible = true;

            // Re-center label on bar (Relative to parent progressBar)
            int x = (progressBar.Width - lblPercent.Width) / 2;
            int y = (progressBar.Height - lblPercent.Height) / 2;
            lblPercent.Location = new Point(x, y);
            lblPercent.BringToFront();
        }

        private void UpdateLog(string msg)
        {
            if (txtLog.IsDisposed) return;
            if (txtLog.InvokeRequired) { txtLog.Invoke(new Action<string>(UpdateLog), msg); }
            else { txtLog.AppendText(msg + Environment.NewLine); }
        }

        private class AdapterDetailItem
        {
            public NetworkAdapterConfig Config { get; }
            public AdapterDetailItem(NetworkAdapterConfig config) { Config = config; }
            public override string ToString()
            {
                return $"[{Config.InterfaceType}] {Config.Description} - {Config.Name} ({Config.IP})";
            }
        }

        private void grpCertsBackup_Enter(object sender, EventArgs e)
        {

        }

        private void lblNetTarget_Click(object sender, EventArgs e)
        {

        }

        private void btnBackupAll_Click(object sender, EventArgs e)
        {

        }

        private void gridBackup_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblPercent_Click(object sender, EventArgs e)
        {

        }

        private void grpLog_Enter(object sender, EventArgs e)
        {

        }

        private void tabRestore_Click(object sender, EventArgs e)
        {

        }

        private void lblRestList_Click(object sender, EventArgs e)
        {

        }

        private void btnPrinterTxt_Click(object sender, EventArgs e)
        {

        }

        private void btnRestorePrinters_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private string FormatSize(long bytes)
        {
            if (bytes == 0) return "0 B";
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i = 0;
            double dblSByte = bytes;
            while (dblSByte >= 1024 && i < Suffix.Length - 1)
            {
                dblSByte /= 1024;
                i++;
            }
            return $"{dblSByte:0.##} {Suffix[i]}";
        }

    }
}
