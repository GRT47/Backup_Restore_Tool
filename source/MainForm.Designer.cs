namespace BackupRestoreTool
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlMiddle = new Panel();
            tabControl = new TabControl();
            tabBackup = new TabPage();
            gridBackup = new TableLayoutPanel();
            grpSession = new GroupBox();
            picLogo = new PictureBox();
            lblSessionName = new Label();
            txtSession = new TextBox();
            btnSessionChange = new Button();
            btnSessionDelete = new Button();
            btnBackupAll = new Button();
            grpAppsBackup = new GroupBox();
            lblApp1 = new Label();
            btnBackupApp1 = new Button();
            lblApp2 = new Label();
            btnBackupApp2 = new Button();
            lblApp3 = new Label();
            btnBackupApp3 = new Button();
            grpNetworkBackup = new GroupBox();
            label1 = new Label();
            lstNetSource = new CheckedListBox();
            lblNetSource = new Label();
            lblNetTarget = new Label();
            lstNetBackup = new ListBox();
            btnBackupNet = new Button();
            btnRefreshNet = new Button();
            grpCertsBackup = new GroupBox();
            btnBackupCerts = new Button();
            grpPrintersBackup = new GroupBox();
            btnPrinterTxt = new Button();
            btnPrinterFull = new Button();
            lblPrinterNote = new Label();
            grpBrowsersBackup = new GroupBox();
            chkChrome = new CheckBox();
            btnPwdChrome = new Button();
            chkEdge = new CheckBox();
            btnPwdEdge = new Button();
            btnBackupBrowsers = new Button();
            lblBrowserWarn = new Label();
            tabRestore = new TabPage();
            gridRestore = new TableLayoutPanel();
            grpSourceRestore = new GroupBox();
            lblRestList = new Label();
            cmbRestSessions = new ComboBox();
            lblRestSelected = new Label();
            btnRestRefresh = new Button();
            btnRestoreAll = new Button();
            grpNetworkRestore = new GroupBox();
            lblNetRest1 = new Label();
            lblNetRest2 = new Label();
            lstNetRestSource = new CheckedListBox();
            lstNetRestTarget = new ListBox();
            btnRestoreNet = new Button();
            btnRefreshRestNet = new Button();
            lblNetRestWarn = new Label();
            grpAppsRestore = new GroupBox();
            lblRestApp1 = new Label();
            btnRestApp1 = new Button();
            btnInstApp1 = new Button();
            lblRestApp2 = new Label();
            btnRestApp2 = new Button();
            btnInstApp2 = new Button();
            lblRestApp3 = new Label();
            btnRestApp3 = new Button();
            btnInstApp3 = new Button();
            grpCertsRestore = new GroupBox();
            btnRestoreCerts = new Button();
            grpPrintersRestore = new GroupBox();
            btnRestorePrinters = new Button();
            grpBrowsersRestore = new GroupBox();
            chkChromeRest = new CheckBox();
            btnInstChrome = new Button();
            chkEdgeRest = new CheckBox();
            btnInstEdge = new Button();
            btnRestoreBrowsers = new Button();
            lblRestoreNote = new Label();
            grpLog = new GroupBox();
            lblPercent = new Label();
            txtLog = new TextBox();
            progressBar = new ProgressBar();
            lblBrowserRestWarn = new Label();
            tabCheck = new TabPage();
            grpCheckSelection = new GroupBox();
            lblCheckList = new Label();
            cmbCheckSessions = new ComboBox();
            lblCheckSelected = new Label();
            btnCheckRefresh = new Button();
            grpCheckSummary = new GroupBox();
            rtbSummary = new RichTextBox();
            pnlMiddle.SuspendLayout();
            tabControl.SuspendLayout();
            tabBackup.SuspendLayout();
            gridBackup.SuspendLayout();
            grpSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            grpAppsBackup.SuspendLayout();
            grpNetworkBackup.SuspendLayout();
            grpCertsBackup.SuspendLayout();
            grpPrintersBackup.SuspendLayout();
            grpBrowsersBackup.SuspendLayout();
            tabRestore.SuspendLayout();
            gridRestore.SuspendLayout();
            grpSourceRestore.SuspendLayout();
            grpNetworkRestore.SuspendLayout();
            grpAppsRestore.SuspendLayout();
            grpCertsRestore.SuspendLayout();
            grpPrintersRestore.SuspendLayout();
            grpBrowsersRestore.SuspendLayout();
            grpLog.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMiddle
            // 
            pnlMiddle.Controls.Add(tabControl);
            pnlMiddle.Dock = DockStyle.Fill;
            pnlMiddle.Location = new Point(0, 0);
            pnlMiddle.Name = "pnlMiddle";
            pnlMiddle.Padding = new Padding(5);
            pnlMiddle.Size = new Size(900, 531);
            pnlMiddle.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.AccessibleDescription = "";
            tabControl.AccessibleName = "";
            tabControl.Controls.Add(tabBackup);
            tabControl.Controls.Add(tabRestore);
            tabControl.Controls.Add(tabCheck);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(5, 5);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(890, 521);
            tabControl.TabIndex = 0;
            tabControl.Tag = "";
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // tabBackup
            // 
            tabBackup.BackColor = Color.White;
            tabBackup.Controls.Add(gridBackup);
            tabBackup.Location = new Point(4, 24);
            tabBackup.Name = "tabBackup";
            tabBackup.Size = new Size(882, 493);
            tabBackup.TabIndex = 0;
            tabBackup.Text = "백업";
            // 
            // gridBackup
            // 
            gridBackup.ColumnCount = 2;
            gridBackup.ColumnStyles.Add(new ColumnStyle());
            gridBackup.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            gridBackup.Controls.Add(grpSession, 0, 0);
            gridBackup.Controls.Add(grpAppsBackup, 1, 1);
            gridBackup.Controls.Add(grpNetworkBackup, 0, 1);
            gridBackup.Controls.Add(grpCertsBackup, 0, 2);
            gridBackup.Controls.Add(grpPrintersBackup, 1, 2);
            gridBackup.Controls.Add(grpBrowsersBackup, 0, 3);
            gridBackup.Dock = DockStyle.Fill;
            gridBackup.Location = new Point(0, 0);
            gridBackup.Name = "gridBackup";
            gridBackup.Padding = new Padding(10, 5, 10, 5);
            gridBackup.RowCount = 4;
            gridBackup.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
            gridBackup.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            gridBackup.RowStyles.Add(new RowStyle(SizeType.Absolute, 87F));
            gridBackup.RowStyles.Add(new RowStyle(SizeType.Absolute, 182F));
            gridBackup.Size = new Size(882, 493);
            gridBackup.TabIndex = 0;
            gridBackup.Paint += gridBackup_Paint;
            // 
            // grpSession
            // 
            gridBackup.SetColumnSpan(grpSession, 2);
            grpSession.Controls.Add(picLogo);
            grpSession.Controls.Add(lblSessionName);
            grpSession.Controls.Add(txtSession);
            grpSession.Controls.Add(btnSessionChange);
            grpSession.Controls.Add(btnSessionDelete);
            grpSession.Controls.Add(btnBackupAll);
            grpSession.Dock = DockStyle.Fill;
            grpSession.Location = new Point(13, 17);
            grpSession.Margin = new Padding(3, 12, 3, 3);
            grpSession.Name = "grpSession";
            grpSession.Size = new Size(856, 70);
            grpSession.TabIndex = 0;
            grpSession.TabStop = false;
            grpSession.Text = "0. 백업 이름 설정";
            // 
            // picLogo
            // 
            picLogo.Location = new Point(10, 15);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(48, 48);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 5;
            picLogo.TabStop = false;
            // 
            // lblSessionName
            // 
            lblSessionName.AutoSize = true;
            lblSessionName.Location = new Point(68, 32);
            lblSessionName.Name = "lblSessionName";
            lblSessionName.Size = new Size(57, 15);
            lblSessionName.TabIndex = 0;
            lblSessionName.Text = "백업 이름:";
            // 
            // txtSession
            // 
            txtSession.Location = new Point(131, 28);
            txtSession.Name = "txtSession";
            txtSession.ReadOnly = true;
            txtSession.Size = new Size(247, 23);
            txtSession.TabIndex = 1;
            // 
            // btnSessionChange
            // 
            btnSessionChange.BackColor = Color.WhiteSmoke;
            btnSessionChange.FlatStyle = FlatStyle.Flat;
            btnSessionChange.Location = new Point(384, 26);
            btnSessionChange.Name = "btnSessionChange";
            btnSessionChange.Size = new Size(100, 28);
            btnSessionChange.TabIndex = 2;
            btnSessionChange.Text = "이름 변경";
            btnSessionChange.UseVisualStyleBackColor = false;
            // 
            // btnSessionDelete
            // 
            btnSessionDelete.BackColor = Color.MistyRose;
            btnSessionDelete.FlatStyle = FlatStyle.Flat;
            btnSessionDelete.Location = new Point(490, 26);
            btnSessionDelete.Name = "btnSessionDelete";
            btnSessionDelete.Size = new Size(100, 28);
            btnSessionDelete.TabIndex = 3;
            btnSessionDelete.Text = "백업데이터 삭제";
            btnSessionDelete.UseVisualStyleBackColor = false;
            // 
            // btnBackupAll
            // 
            btnBackupAll.BackColor = Color.LightSkyBlue;
            btnBackupAll.FlatStyle = FlatStyle.Flat;
            btnBackupAll.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackupAll.Location = new Point(657, 14);
            btnBackupAll.Name = "btnBackupAll";
            btnBackupAll.Size = new Size(195, 50);
            btnBackupAll.TabIndex = 4;
            btnBackupAll.Text = "전체 백업 시작 (All-in-One)";
            btnBackupAll.UseVisualStyleBackColor = false;
            btnBackupAll.Click += btnBackupAll_Click;
            // 
            // grpAppsBackup
            // 
            grpAppsBackup.Controls.Add(lblApp1);
            grpAppsBackup.Controls.Add(btnBackupApp1);
            grpAppsBackup.Controls.Add(lblApp2);
            grpAppsBackup.Controls.Add(btnBackupApp2);
            grpAppsBackup.Controls.Add(lblApp3);
            grpAppsBackup.Controls.Add(btnBackupApp3);
            grpAppsBackup.Dock = DockStyle.Fill;
            grpAppsBackup.Location = new Point(543, 102);
            grpAppsBackup.Margin = new Padding(3, 12, 3, 3);
            grpAppsBackup.Name = "grpAppsBackup";
            grpAppsBackup.Size = new Size(326, 185);
            grpAppsBackup.TabIndex = 2;
            grpAppsBackup.TabStop = false;
            grpAppsBackup.Text = "5. 응용프로그램 데이터";
            // 
            // lblApp1
            // 
            lblApp1.Location = new Point(15, 30);
            lblApp1.Name = "lblApp1";
            lblApp1.Size = new Size(85, 23);
            lblApp1.TabIndex = 0;
            lblApp1.Text = "DesktopCal";
            // 
            // btnBackupApp1
            // 
            btnBackupApp1.BackColor = Color.AliceBlue;
            btnBackupApp1.FlatStyle = FlatStyle.Flat;
            btnBackupApp1.Location = new Point(105, 26);
            btnBackupApp1.Name = "btnBackupApp1";
            btnBackupApp1.Size = new Size(65, 28);
            btnBackupApp1.TabIndex = 1;
            btnBackupApp1.Text = "백업";
            btnBackupApp1.UseVisualStyleBackColor = false;
            // 
            // lblApp2
            // 
            lblApp2.Location = new Point(15, 62);
            lblApp2.Name = "lblApp2";
            lblApp2.Size = new Size(85, 23);
            lblApp2.TabIndex = 2;
            lblApp2.Text = "SMemo";
            // 
            // btnBackupApp2
            // 
            btnBackupApp2.BackColor = Color.AliceBlue;
            btnBackupApp2.FlatStyle = FlatStyle.Flat;
            btnBackupApp2.Location = new Point(105, 58);
            btnBackupApp2.Name = "btnBackupApp2";
            btnBackupApp2.Size = new Size(65, 28);
            btnBackupApp2.TabIndex = 3;
            btnBackupApp2.Text = "백업";
            btnBackupApp2.UseVisualStyleBackColor = false;
            // 
            // lblApp3
            // 
            lblApp3.Location = new Point(15, 94);
            lblApp3.Name = "lblApp3";
            lblApp3.Size = new Size(85, 23);
            lblApp3.TabIndex = 4;
            lblApp3.Text = "StickyNotes";
            // 
            // btnBackupApp3
            // 
            btnBackupApp3.BackColor = Color.AliceBlue;
            btnBackupApp3.FlatStyle = FlatStyle.Flat;
            btnBackupApp3.Location = new Point(105, 90);
            btnBackupApp3.Name = "btnBackupApp3";
            btnBackupApp3.Size = new Size(65, 28);
            btnBackupApp3.TabIndex = 5;
            btnBackupApp3.Text = "백업";
            btnBackupApp3.UseVisualStyleBackColor = false;
            // 
            // grpNetworkBackup
            // 
            grpNetworkBackup.Controls.Add(label1);
            grpNetworkBackup.Controls.Add(lstNetSource);
            grpNetworkBackup.Controls.Add(lblNetSource);
            grpNetworkBackup.Controls.Add(lblNetTarget);
            grpNetworkBackup.Controls.Add(lstNetBackup);
            grpNetworkBackup.Controls.Add(btnBackupNet);
            grpNetworkBackup.Controls.Add(btnRefreshNet);
            grpNetworkBackup.Dock = DockStyle.Fill;
            grpNetworkBackup.Location = new Point(13, 102);
            grpNetworkBackup.Margin = new Padding(3, 12, 3, 3);
            grpNetworkBackup.Name = "grpNetworkBackup";
            grpNetworkBackup.Size = new Size(524, 185);
            grpNetworkBackup.TabIndex = 1;
            grpNetworkBackup.TabStop = false;
            grpNetworkBackup.Text = "3. 네트워크 설정 (IP)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(15, 19);
            label1.Name = "label1";
            label1.Size = new Size(113, 14);
            label1.TabIndex = 7;
            label1.Text = "※ 고정IP만 목록에 출력";
            // 
            // lstNetSource
            // 
            lstNetSource.CheckOnClick = true;
            lstNetSource.Location = new Point(15, 53);
            lstNetSource.Name = "lstNetSource";
            lstNetSource.Size = new Size(250, 76);
            lstNetSource.TabIndex = 6;
            // 
            // lblNetSource
            // 
            lblNetSource.AutoSize = true;
            lblNetSource.Location = new Point(15, 33);
            lblNetSource.Name = "lblNetSource";
            lblNetSource.Size = new Size(73, 15);
            lblNetSource.TabIndex = 0;
            lblNetSource.Text = "어댑터 (소스)";
            // 
            // lblNetTarget
            // 
            lblNetTarget.AutoSize = true;
            lblNetTarget.Location = new Point(271, 33);
            lblNetTarget.Name = "lblNetTarget";
            lblNetTarget.Size = new Size(73, 15);
            lblNetTarget.TabIndex = 2;
            lblNetTarget.Text = "백업됨 (현재)";
            lblNetTarget.Click += lblNetTarget_Click;
            // 
            // lstNetBackup
            // 
            lstNetBackup.ItemHeight = 15;
            lstNetBackup.Location = new Point(271, 53);
            lstNetBackup.Name = "lstNetBackup";
            lstNetBackup.Size = new Size(250, 79);
            lstNetBackup.TabIndex = 3;
            // 
            // btnBackupNet
            // 
            btnBackupNet.BackColor = Color.AliceBlue;
            btnBackupNet.FlatStyle = FlatStyle.Flat;
            btnBackupNet.Location = new Point(15, 138);
            btnBackupNet.Name = "btnBackupNet";
            btnBackupNet.Size = new Size(250, 36);
            btnBackupNet.TabIndex = 4;
            btnBackupNet.Text = "선택한 어댑터 백업";
            btnBackupNet.UseVisualStyleBackColor = false;
            // 
            // btnRefreshNet
            // 
            btnRefreshNet.BackColor = Color.WhiteSmoke;
            btnRefreshNet.FlatStyle = FlatStyle.Flat;
            btnRefreshNet.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefreshNet.Location = new Point(271, 138);
            btnRefreshNet.Name = "btnRefreshNet";
            btnRefreshNet.Size = new Size(95, 36);
            btnRefreshNet.TabIndex = 5;
            btnRefreshNet.Text = "새로고침";
            btnRefreshNet.UseVisualStyleBackColor = false;
            // 
            // grpCertsBackup
            // 
            grpCertsBackup.Controls.Add(btnBackupCerts);
            grpCertsBackup.Dock = DockStyle.Fill;
            grpCertsBackup.Location = new Point(13, 302);
            grpCertsBackup.Margin = new Padding(3, 12, 3, 3);
            grpCertsBackup.Name = "grpCertsBackup";
            grpCertsBackup.Size = new Size(524, 72);
            grpCertsBackup.TabIndex = 3;
            grpCertsBackup.TabStop = false;
            grpCertsBackup.Text = "2. 인증서 (NPKI/GPKI)";
            grpCertsBackup.Enter += grpCertsBackup_Enter;
            // 
            // btnBackupCerts
            // 
            btnBackupCerts.BackColor = Color.AliceBlue;
            btnBackupCerts.FlatStyle = FlatStyle.Flat;
            btnBackupCerts.Location = new Point(15, 22);
            btnBackupCerts.Name = "btnBackupCerts";
            btnBackupCerts.Size = new Size(300, 36);
            btnBackupCerts.TabIndex = 0;
            btnBackupCerts.Text = "통합 인증서 백업 (NPKI & GPKI)";
            btnBackupCerts.UseVisualStyleBackColor = false;
            // 
            // grpPrintersBackup
            // 
            grpPrintersBackup.Controls.Add(btnPrinterTxt);
            grpPrintersBackup.Controls.Add(btnPrinterFull);
            grpPrintersBackup.Controls.Add(lblPrinterNote);
            grpPrintersBackup.Dock = DockStyle.Fill;
            grpPrintersBackup.Location = new Point(543, 302);
            grpPrintersBackup.Margin = new Padding(3, 12, 3, 3);
            grpPrintersBackup.Name = "grpPrintersBackup";
            grpPrintersBackup.Size = new Size(326, 72);
            grpPrintersBackup.TabIndex = 4;
            grpPrintersBackup.TabStop = false;
            grpPrintersBackup.Text = "4. 프린터 (Printers)";
            // 
            // btnPrinterTxt
            // 
            btnPrinterTxt.BackColor = Color.AliceBlue;
            btnPrinterTxt.FlatStyle = FlatStyle.Flat;
            btnPrinterTxt.Location = new Point(15, 30);
            btnPrinterTxt.Name = "btnPrinterTxt";
            btnPrinterTxt.Size = new Size(140, 34);
            btnPrinterTxt.TabIndex = 0;
            btnPrinterTxt.Text = "목록백업(Txt)";
            btnPrinterTxt.UseVisualStyleBackColor = false;
            btnPrinterTxt.Click += btnPrinterTxt_Click;
            // 
            // btnPrinterFull
            // 
            btnPrinterFull.BackColor = Color.AliceBlue;
            btnPrinterFull.FlatStyle = FlatStyle.Flat;
            btnPrinterFull.Location = new Point(165, 30);
            btnPrinterFull.Name = "btnPrinterFull";
            btnPrinterFull.Size = new Size(140, 34);
            btnPrinterFull.TabIndex = 1;
            btnPrinterFull.Text = "전체백업(Full)";
            btnPrinterFull.UseVisualStyleBackColor = false;
            // 
            // lblPrinterNote
            // 
            lblPrinterNote.AutoSize = true;
            lblPrinterNote.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrinterNote.ForeColor = Color.Blue;
            lblPrinterNote.Location = new Point(15, 17);
            lblPrinterNote.Name = "lblPrinterNote";
            lblPrinterNote.Size = new Size(309, 13);
            lblPrinterNote.TabIndex = 2;
            lblPrinterNote.Text = "※ Txt는 단순 정보 확인용이며, Full 백업만 실제 복원이 가능합니다.";
            // 
            // grpBrowsersBackup
            // 
            gridBackup.SetColumnSpan(grpBrowsersBackup, 2);
            grpBrowsersBackup.Controls.Add(chkChrome);
            grpBrowsersBackup.Controls.Add(btnPwdChrome);
            grpBrowsersBackup.Controls.Add(chkEdge);
            grpBrowsersBackup.Controls.Add(btnPwdEdge);
            grpBrowsersBackup.Controls.Add(btnBackupBrowsers);
            grpBrowsersBackup.Controls.Add(lblBrowserWarn);
            grpBrowsersBackup.Location = new Point(13, 389);
            grpBrowsersBackup.Margin = new Padding(3, 12, 3, 3);
            grpBrowsersBackup.Name = "grpBrowsersBackup";
            grpBrowsersBackup.Size = new Size(856, 98);
            grpBrowsersBackup.TabIndex = 5;
            grpBrowsersBackup.TabStop = false;
            grpBrowsersBackup.Text = "1. 웹 브라우저";
            // 
            // chkChrome
            // 
            chkChrome.Checked = true;
            chkChrome.CheckState = CheckState.Checked;
            chkChrome.Location = new Point(15, 32);
            chkChrome.Name = "chkChrome";
            chkChrome.Size = new Size(85, 24);
            chkChrome.TabIndex = 0;
            chkChrome.Text = "Chrome";
            // 
            // btnPwdChrome
            // 
            btnPwdChrome.BackColor = Color.WhiteSmoke;
            btnPwdChrome.FlatStyle = FlatStyle.Flat;
            btnPwdChrome.Location = new Point(340, 32);
            btnPwdChrome.Name = "btnPwdChrome";
            btnPwdChrome.Size = new Size(99, 26);
            btnPwdChrome.TabIndex = 1;
            btnPwdChrome.Text = "비밀번호 백업";
            btnPwdChrome.UseVisualStyleBackColor = false;
            // 
            // chkEdge
            // 
            chkEdge.Checked = true;
            chkEdge.CheckState = CheckState.Checked;
            chkEdge.Location = new Point(15, 62);
            chkEdge.Name = "chkEdge";
            chkEdge.Size = new Size(85, 24);
            chkEdge.TabIndex = 2;
            chkEdge.Text = "Edge";
            // 
            // btnPwdEdge
            // 
            btnPwdEdge.BackColor = Color.WhiteSmoke;
            btnPwdEdge.FlatStyle = FlatStyle.Flat;
            btnPwdEdge.Location = new Point(340, 60);
            btnPwdEdge.Name = "btnPwdEdge";
            btnPwdEdge.Size = new Size(99, 26);
            btnPwdEdge.TabIndex = 3;
            btnPwdEdge.Text = "비밀번호 백업";
            btnPwdEdge.UseVisualStyleBackColor = false;
            // 
            // btnBackupBrowsers
            // 
            btnBackupBrowsers.BackColor = Color.AliceBlue;
            btnBackupBrowsers.FlatStyle = FlatStyle.Flat;
            btnBackupBrowsers.Location = new Point(106, 32);
            btnBackupBrowsers.Name = "btnBackupBrowsers";
            btnBackupBrowsers.Size = new Size(228, 54);
            btnBackupBrowsers.TabIndex = 4;
            btnBackupBrowsers.Text = "선택한 브라우저 백업";
            btnBackupBrowsers.UseVisualStyleBackColor = false;
            // 
            // lblBrowserWarn
            // 
            lblBrowserWarn.AutoSize = true;
            lblBrowserWarn.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblBrowserWarn.ForeColor = Color.Crimson;
            lblBrowserWarn.Location = new Point(445, 32);
            lblBrowserWarn.Name = "lblBrowserWarn";
            lblBrowserWarn.Size = new Size(210, 14);
            lblBrowserWarn.TabIndex = 5;
            lblBrowserWarn.Text = "※ 백업 진행시 브라우저가 강제 종료됩니다．";
            // 
            // tabRestore
            // 
            tabRestore.BackColor = Color.White;
            tabRestore.Controls.Add(gridRestore);
            tabRestore.Location = new Point(4, 24);
            tabRestore.Name = "tabRestore";
            tabRestore.Size = new Size(882, 493);
            tabRestore.TabIndex = 1;
            tabRestore.Text = "복원";
            tabRestore.Click += tabRestore_Click;
            // 
            // gridRestore
            // 
            gridRestore.ColumnCount = 2;
            gridRestore.ColumnStyles.Add(new ColumnStyle());
            gridRestore.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            gridRestore.Controls.Add(grpSourceRestore, 0, 0);
            gridRestore.Controls.Add(grpNetworkRestore, 0, 1);
            gridRestore.Controls.Add(grpAppsRestore, 1, 1);
            gridRestore.Controls.Add(grpCertsRestore, 0, 2);
            gridRestore.Controls.Add(grpPrintersRestore, 1, 2);
            gridRestore.Controls.Add(grpBrowsersRestore, 0, 3);
            gridRestore.Location = new Point(0, 0);
            gridRestore.Name = "gridRestore";
            gridRestore.Padding = new Padding(10, 5, 10, 5);
            gridRestore.RowCount = 4;
            gridRestore.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
            gridRestore.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            gridRestore.RowStyles.Add(new RowStyle(SizeType.Absolute, 87F));
            gridRestore.RowStyles.Add(new RowStyle(SizeType.Absolute, 182F));
            gridRestore.Size = new Size(879, 527);
            gridRestore.TabIndex = 0;
            // 
            // grpSourceRestore
            // 
            gridRestore.SetColumnSpan(grpSourceRestore, 2);
            grpSourceRestore.Controls.Add(lblRestList);
            grpSourceRestore.Controls.Add(cmbRestSessions);
            grpSourceRestore.Controls.Add(lblRestSelected);
            grpSourceRestore.Controls.Add(btnRestRefresh);
            grpSourceRestore.Controls.Add(btnRestoreAll);
            grpSourceRestore.Dock = DockStyle.Fill;
            grpSourceRestore.Location = new Point(10, 5);
            grpSourceRestore.Margin = new Padding(0, 0, 0, 8);
            grpSourceRestore.Name = "grpSourceRestore";
            grpSourceRestore.Size = new Size(859, 77);
            grpSourceRestore.TabIndex = 0;
            grpSourceRestore.TabStop = false;
            grpSourceRestore.Text = "0. 복원 원본 선택";
            // 
            // lblRestList
            // 
            lblRestList.AutoSize = true;
            lblRestList.Location = new Point(18, 19);
            lblRestList.Name = "lblRestList";
            lblRestList.Size = new Size(57, 15);
            lblRestList.TabIndex = 0;
            lblRestList.Text = "백업 선택:";
            lblRestList.Click += lblRestList_Click;
            // 
            // cmbRestSessions
            // 
            cmbRestSessions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRestSessions.FormattingEnabled = true;
            cmbRestSessions.Location = new Point(18, 41);
            cmbRestSessions.Name = "cmbRestSessions";
            cmbRestSessions.Size = new Size(300, 23);
            cmbRestSessions.TabIndex = 1;
            // 
            // lblRestSelected
            // 
            lblRestSelected.AutoSize = true;
            lblRestSelected.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblRestSelected.Location = new Point(323, 19);
            lblRestSelected.Name = "lblRestSelected";
            lblRestSelected.Size = new Size(68, 15);
            lblRestSelected.TabIndex = 2;
            lblRestSelected.Text = "선택됨: 없음";
            // 
            // btnRestRefresh
            // 
            btnRestRefresh.BackColor = Color.WhiteSmoke;
            btnRestRefresh.FlatStyle = FlatStyle.Flat;
            btnRestRefresh.Location = new Point(324, 37);
            btnRestRefresh.Name = "btnRestRefresh";
            btnRestRefresh.Size = new Size(120, 34);
            btnRestRefresh.TabIndex = 3;
            btnRestRefresh.Text = "목록 새로고침";
            btnRestRefresh.UseVisualStyleBackColor = false;
            // 
            // btnRestoreAll
            // 
            btnRestoreAll.BackColor = Color.LightGreen;
            btnRestoreAll.FlatStyle = FlatStyle.Flat;
            btnRestoreAll.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnRestoreAll.Location = new Point(658, 19);
            btnRestoreAll.Name = "btnRestoreAll";
            btnRestoreAll.Size = new Size(195, 50);
            btnRestoreAll.TabIndex = 4;
            btnRestoreAll.Text = "전체 복원 시작 (All-in-One)";
            btnRestoreAll.UseVisualStyleBackColor = false;
            // 
            // grpNetworkRestore
            // 
            grpNetworkRestore.Controls.Add(lblNetRest1);
            grpNetworkRestore.Controls.Add(lblNetRest2);
            grpNetworkRestore.Controls.Add(lstNetRestSource);
            grpNetworkRestore.Controls.Add(lstNetRestTarget);
            grpNetworkRestore.Controls.Add(btnRestoreNet);
            grpNetworkRestore.Controls.Add(btnRefreshRestNet);
            grpNetworkRestore.Controls.Add(lblNetRestWarn);
            grpNetworkRestore.Dock = DockStyle.Fill;
            grpNetworkRestore.Location = new Point(13, 102);
            grpNetworkRestore.Margin = new Padding(3, 12, 3, 3);
            grpNetworkRestore.Name = "grpNetworkRestore";
            grpNetworkRestore.Size = new Size(522, 185);
            grpNetworkRestore.TabIndex = 1;
            grpNetworkRestore.TabStop = false;
            grpNetworkRestore.Text = "3. 네트워크 설정 (IP)";
            // 
            // lblNetRest1
            // 
            lblNetRest1.AutoSize = true;
            lblNetRest1.Location = new Point(15, 30);
            lblNetRest1.Name = "lblNetRest1";
            lblNetRest1.Size = new Size(73, 15);
            lblNetRest1.TabIndex = 0;
            lblNetRest1.Text = "백업됨 (현재)";
            // 
            // lblNetRest2
            // 
            lblNetRest2.AutoSize = true;
            lblNetRest2.Location = new Point(271, 30);
            lblNetRest2.Name = "lblNetRest2";
            lblNetRest2.Size = new Size(90, 15);
            lblNetRest2.TabIndex = 1;
            lblNetRest2.Text = "대상 어댑터 선택";
            // 
            // lstNetRestSource
            // 
            lstNetRestSource.CheckOnClick = true;
            lstNetRestSource.Location = new Point(15, 52);
            lstNetRestSource.Name = "lstNetRestSource";
            lstNetRestSource.Size = new Size(250, 76);
            lstNetRestSource.TabIndex = 2;
            // 
            // lstNetRestTarget
            // 
            lstNetRestTarget.ItemHeight = 15;
            lstNetRestTarget.Location = new Point(271, 52);
            lstNetRestTarget.Name = "lstNetRestTarget";
            lstNetRestTarget.Size = new Size(250, 79);
            lstNetRestTarget.TabIndex = 3;
            // 
            // btnRestoreNet
            // 
            btnRestoreNet.BackColor = Color.Honeydew;
            btnRestoreNet.FlatStyle = FlatStyle.Flat;
            btnRestoreNet.Location = new Point(15, 137);
            btnRestoreNet.Name = "btnRestoreNet";
            btnRestoreNet.Size = new Size(250, 36);
            btnRestoreNet.TabIndex = 4;
            btnRestoreNet.Text = "선택한 설정 복원(적용)";
            btnRestoreNet.UseVisualStyleBackColor = false;
            // 
            // btnRefreshRestNet
            // 
            btnRefreshRestNet.BackColor = Color.WhiteSmoke;
            btnRefreshRestNet.FlatStyle = FlatStyle.Flat;
            btnRefreshRestNet.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefreshRestNet.Location = new Point(271, 137);
            btnRefreshRestNet.Name = "btnRefreshRestNet";
            btnRefreshRestNet.Size = new Size(90, 36);
            btnRefreshRestNet.TabIndex = 5;
            btnRefreshRestNet.Text = "새로고침";
            btnRefreshRestNet.UseVisualStyleBackColor = false;
            // 
            // lblNetRestWarn
            // 
            lblNetRestWarn.AutoSize = true;
            lblNetRestWarn.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblNetRestWarn.ForeColor = Color.Crimson;
            lblNetRestWarn.Location = new Point(10, 350);
            lblNetRestWarn.Name = "lblNetRestWarn";
            lblNetRestWarn.Size = new Size(294, 13);
            lblNetRestWarn.TabIndex = 6;
            lblNetRestWarn.Text = "※ 대상 어댑터를 잘못 선택하면 인터넷 연결이 끊길 수 있습니다.";
            // 
            // grpAppsRestore
            // 
            grpAppsRestore.Controls.Add(lblRestApp1);
            grpAppsRestore.Controls.Add(btnRestApp1);
            grpAppsRestore.Controls.Add(btnInstApp1);
            grpAppsRestore.Controls.Add(lblRestApp2);
            grpAppsRestore.Controls.Add(btnRestApp2);
            grpAppsRestore.Controls.Add(btnInstApp2);
            grpAppsRestore.Controls.Add(lblRestApp3);
            grpAppsRestore.Controls.Add(btnRestApp3);
            grpAppsRestore.Controls.Add(btnInstApp3);
            grpAppsRestore.Dock = DockStyle.Fill;
            grpAppsRestore.Location = new Point(541, 102);
            grpAppsRestore.Margin = new Padding(3, 12, 3, 3);
            grpAppsRestore.Name = "grpAppsRestore";
            grpAppsRestore.Size = new Size(325, 185);
            grpAppsRestore.TabIndex = 2;
            grpAppsRestore.TabStop = false;
            grpAppsRestore.Text = "5. 응용프로그램 데이터";
            // 
            // lblRestApp1
            // 
            lblRestApp1.Location = new Point(15, 30);
            lblRestApp1.Name = "lblRestApp1";
            lblRestApp1.Size = new Size(85, 23);
            lblRestApp1.TabIndex = 0;
            lblRestApp1.Text = "DesktopCal";
            // 
            // btnRestApp1
            // 
            btnRestApp1.BackColor = Color.Honeydew;
            btnRestApp1.FlatStyle = FlatStyle.Flat;
            btnRestApp1.Location = new Point(105, 26);
            btnRestApp1.Name = "btnRestApp1";
            btnRestApp1.Size = new Size(65, 28);
            btnRestApp1.TabIndex = 1;
            btnRestApp1.Text = "복원";
            btnRestApp1.UseVisualStyleBackColor = false;
            // 
            // btnInstApp1
            // 
            btnInstApp1.BackColor = Color.WhiteSmoke;
            btnInstApp1.FlatStyle = FlatStyle.Flat;
            btnInstApp1.Location = new Point(175, 26);
            btnInstApp1.Name = "btnInstApp1";
            btnInstApp1.Size = new Size(65, 28);
            btnInstApp1.TabIndex = 2;
            btnInstApp1.Text = "설치";
            btnInstApp1.UseVisualStyleBackColor = false;
            // 
            // lblRestApp2
            // 
            lblRestApp2.Location = new Point(15, 62);
            lblRestApp2.Name = "lblRestApp2";
            lblRestApp2.Size = new Size(85, 23);
            lblRestApp2.TabIndex = 3;
            lblRestApp2.Text = "SMemo";
            // 
            // btnRestApp2
            // 
            btnRestApp2.BackColor = Color.Honeydew;
            btnRestApp2.FlatStyle = FlatStyle.Flat;
            btnRestApp2.Location = new Point(105, 58);
            btnRestApp2.Name = "btnRestApp2";
            btnRestApp2.Size = new Size(65, 28);
            btnRestApp2.TabIndex = 4;
            btnRestApp2.Text = "복원";
            btnRestApp2.UseVisualStyleBackColor = false;
            // 
            // btnInstApp2
            // 
            btnInstApp2.BackColor = Color.WhiteSmoke;
            btnInstApp2.FlatStyle = FlatStyle.Flat;
            btnInstApp2.Location = new Point(175, 58);
            btnInstApp2.Name = "btnInstApp2";
            btnInstApp2.Size = new Size(65, 28);
            btnInstApp2.TabIndex = 5;
            btnInstApp2.Text = "설치";
            btnInstApp2.UseVisualStyleBackColor = false;
            // 
            // lblRestApp3
            // 
            lblRestApp3.Location = new Point(15, 94);
            lblRestApp3.Name = "lblRestApp3";
            lblRestApp3.Size = new Size(85, 23);
            lblRestApp3.TabIndex = 6;
            lblRestApp3.Text = "StickyNotes";
            // 
            // btnRestApp3
            // 
            btnRestApp3.BackColor = Color.Honeydew;
            btnRestApp3.FlatStyle = FlatStyle.Flat;
            btnRestApp3.Location = new Point(105, 90);
            btnRestApp3.Name = "btnRestApp3";
            btnRestApp3.Size = new Size(65, 28);
            btnRestApp3.TabIndex = 7;
            btnRestApp3.Text = "복원";
            btnRestApp3.UseVisualStyleBackColor = false;
            // 
            // btnInstApp3
            // 
            btnInstApp3.BackColor = Color.WhiteSmoke;
            btnInstApp3.FlatStyle = FlatStyle.Flat;
            btnInstApp3.Location = new Point(175, 90);
            btnInstApp3.Name = "btnInstApp3";
            btnInstApp3.Size = new Size(65, 28);
            btnInstApp3.TabIndex = 8;
            btnInstApp3.Text = "설치";
            btnInstApp3.UseVisualStyleBackColor = false;
            // 
            // grpCertsRestore
            // 
            grpCertsRestore.Controls.Add(btnRestoreCerts);
            grpCertsRestore.Dock = DockStyle.Fill;
            grpCertsRestore.Location = new Point(13, 302);
            grpCertsRestore.Margin = new Padding(3, 12, 3, 3);
            grpCertsRestore.Name = "grpCertsRestore";
            grpCertsRestore.Size = new Size(522, 72);
            grpCertsRestore.TabIndex = 3;
            grpCertsRestore.TabStop = false;
            grpCertsRestore.Text = "2. 인증서 (NPKI/GPKI)";
            // 
            // btnRestoreCerts
            // 
            btnRestoreCerts.BackColor = Color.Honeydew;
            btnRestoreCerts.FlatStyle = FlatStyle.Flat;
            btnRestoreCerts.Location = new Point(15, 22);
            btnRestoreCerts.Name = "btnRestoreCerts";
            btnRestoreCerts.Size = new Size(300, 36);
            btnRestoreCerts.TabIndex = 0;
            btnRestoreCerts.Text = "통합 인증서 복원 (NPKI & GPKI)";
            btnRestoreCerts.UseVisualStyleBackColor = false;
            // 
            // grpPrintersRestore
            // 
            grpPrintersRestore.Controls.Add(btnRestorePrinters);
            grpPrintersRestore.Dock = DockStyle.Fill;
            grpPrintersRestore.Location = new Point(541, 302);
            grpPrintersRestore.Margin = new Padding(3, 12, 3, 3);
            grpPrintersRestore.Name = "grpPrintersRestore";
            grpPrintersRestore.Size = new Size(325, 72);
            grpPrintersRestore.TabIndex = 4;
            grpPrintersRestore.TabStop = false;
            grpPrintersRestore.Text = "4. 프린터 (Printers)";
            // 
            // btnRestorePrinters
            // 
            btnRestorePrinters.BackColor = Color.Honeydew;
            btnRestorePrinters.FlatStyle = FlatStyle.Flat;
            btnRestorePrinters.Location = new Point(15, 22);
            btnRestorePrinters.Name = "btnRestorePrinters";
            btnRestorePrinters.Size = new Size(290, 36);
            btnRestorePrinters.TabIndex = 0;
            btnRestorePrinters.Text = "전체복원 (Full)";
            btnRestorePrinters.UseVisualStyleBackColor = false;
            btnRestorePrinters.Click += btnRestorePrinters_Click;
            // 
            // grpBrowsersRestore
            // 
            gridRestore.SetColumnSpan(grpBrowsersRestore, 2);
            grpBrowsersRestore.Controls.Add(chkChromeRest);
            grpBrowsersRestore.Controls.Add(btnInstChrome);
            grpBrowsersRestore.Controls.Add(chkEdgeRest);
            grpBrowsersRestore.Controls.Add(btnInstEdge);
            grpBrowsersRestore.Controls.Add(btnRestoreBrowsers);
            grpBrowsersRestore.Controls.Add(lblRestoreNote);
            grpBrowsersRestore.Location = new Point(13, 389);
            grpBrowsersRestore.Margin = new Padding(3, 12, 3, 3);
            grpBrowsersRestore.Name = "grpBrowsersRestore";
            grpBrowsersRestore.Size = new Size(853, 101);
            grpBrowsersRestore.TabIndex = 5;
            grpBrowsersRestore.TabStop = false;
            grpBrowsersRestore.Text = "1. 웹 브라우저";
            // 
            // chkChromeRest
            // 
            chkChromeRest.Checked = true;
            chkChromeRest.CheckState = CheckState.Checked;
            chkChromeRest.Location = new Point(15, 32);
            chkChromeRest.Name = "chkChromeRest";
            chkChromeRest.Size = new Size(85, 24);
            chkChromeRest.TabIndex = 0;
            chkChromeRest.Text = "Chrome";
            // 
            // btnInstChrome
            // 
            btnInstChrome.BackColor = Color.WhiteSmoke;
            btnInstChrome.FlatStyle = FlatStyle.Flat;
            btnInstChrome.Location = new Point(340, 32);
            btnInstChrome.Name = "btnInstChrome";
            btnInstChrome.Size = new Size(99, 26);
            btnInstChrome.TabIndex = 1;
            btnInstChrome.Text = "설치";
            btnInstChrome.UseVisualStyleBackColor = false;
            // 
            // chkEdgeRest
            // 
            chkEdgeRest.Checked = true;
            chkEdgeRest.CheckState = CheckState.Checked;
            chkEdgeRest.Location = new Point(15, 62);
            chkEdgeRest.Name = "chkEdgeRest";
            chkEdgeRest.Size = new Size(85, 24);
            chkEdgeRest.TabIndex = 2;
            chkEdgeRest.Text = "Edge";
            // 
            // btnInstEdge
            // 
            btnInstEdge.BackColor = Color.WhiteSmoke;
            btnInstEdge.FlatStyle = FlatStyle.Flat;
            btnInstEdge.Location = new Point(340, 60);
            btnInstEdge.Name = "btnInstEdge";
            btnInstEdge.Size = new Size(99, 26);
            btnInstEdge.TabIndex = 3;
            btnInstEdge.Text = "설치";
            btnInstEdge.UseVisualStyleBackColor = false;
            // 
            // btnRestoreBrowsers
            // 
            btnRestoreBrowsers.BackColor = Color.Honeydew;
            btnRestoreBrowsers.FlatStyle = FlatStyle.Flat;
            btnRestoreBrowsers.Location = new Point(106, 32);
            btnRestoreBrowsers.Name = "btnRestoreBrowsers";
            btnRestoreBrowsers.Size = new Size(228, 54);
            btnRestoreBrowsers.TabIndex = 4;
            btnRestoreBrowsers.Text = "선택한 브라우저 복원";
            btnRestoreBrowsers.UseVisualStyleBackColor = false;
            // 
            // lblRestoreNote
            // 
            lblRestoreNote.AutoSize = true;
            lblRestoreNote.ForeColor = Color.Firebrick;
            lblRestoreNote.Location = new Point(444, 32);
            lblRestoreNote.Name = "lblRestoreNote";
            lblRestoreNote.Size = new Size(237, 15);
            lblRestoreNote.TabIndex = 5;
            lblRestoreNote.Text = "※ 복원 후 브라우저 실행 오류 발생시 설치 필요";
            // 
            // grpLog
            // 
            grpLog.Controls.Add(lblPercent);
            grpLog.Controls.Add(txtLog);
            grpLog.Controls.Add(progressBar);
            grpLog.Dock = DockStyle.Bottom;
            grpLog.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpLog.Location = new Point(0, 531);
            grpLog.Name = "grpLog";
            grpLog.Size = new Size(900, 150);
            grpLog.TabIndex = 1;
            grpLog.TabStop = false;
            grpLog.Text = "로그 (Log)";
            grpLog.Enter += grpLog_Enter;
            // 
            // lblPercent
            // 
            lblPercent.BackColor = Color.Transparent;
            lblPercent.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPercent.Location = new Point(816, 53);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new Size(56, 27);
            lblPercent.TabIndex = 0;
            lblPercent.Text = "0%";
            lblPercent.TextAlign = ContentAlignment.MiddleCenter;
            lblPercent.Visible = true;
            lblPercent.Click += lblPercent_Click;
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.WhiteSmoke;
            txtLog.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtLog.Location = new Point(5, 22);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(890, 88);
            txtLog.TabIndex = 0;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(5, 117);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(890, 27);
            progressBar.TabIndex = 2;
            progressBar.Visible = true;
            // 
            // lblBrowserRestWarn
            // 
            lblBrowserRestWarn.AutoSize = true;
            lblBrowserRestWarn.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblBrowserRestWarn.ForeColor = Color.Crimson;
            lblBrowserRestWarn.Location = new Point(15, 98);
            lblBrowserRestWarn.Name = "lblBrowserRestWarn";
            lblBrowserRestWarn.Size = new Size(100, 23);
            lblBrowserRestWarn.TabIndex = 0;
            lblBrowserRestWarn.Text = "※ 복원 시 기존 브라우저 데이터가 삭제되고 백업본으로 교체됩니다.";
            // 
            // tabCheck
            // 
            tabCheck.Controls.Add(grpCheckSummary);
            tabCheck.Controls.Add(grpCheckSelection);
            tabCheck.Location = new Point(4, 24);
            tabCheck.Name = "tabCheck";
            tabCheck.Padding = new Padding(10);
            tabCheck.Size = new Size(882, 493);
            tabCheck.TabIndex = 2;
            tabCheck.Text = "백업확인";
            tabCheck.UseVisualStyleBackColor = true;
            // 
            // grpCheckSelection
            // 
            grpCheckSelection.Controls.Add(lblCheckList);
            grpCheckSelection.Controls.Add(cmbCheckSessions);
            grpCheckSelection.Controls.Add(lblCheckSelected);
            grpCheckSelection.Controls.Add(btnCheckRefresh);
            grpCheckSelection.Dock = DockStyle.Top;
            grpCheckSelection.Location = new Point(10, 10);
            grpCheckSelection.Name = "grpCheckSelection";
            grpCheckSelection.Size = new Size(862, 80);
            grpCheckSelection.TabIndex = 0;
            grpCheckSelection.TabStop = false;
            grpCheckSelection.Text = "확인할 백업 세션 선택";
            // 
            // lblCheckList
            // 
            lblCheckList.AutoSize = true;
            lblCheckList.Location = new Point(15, 23);
            lblCheckList.Name = "lblCheckList";
            lblCheckList.Size = new Size(57, 15);
            lblCheckList.TabIndex = 0;
            lblCheckList.Text = "백업 선택:";
            // 
            // cmbCheckSessions
            // 
            cmbCheckSessions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCheckSessions.FormattingEnabled = true;
            cmbCheckSessions.Location = new Point(15, 41);
            cmbCheckSessions.Name = "cmbCheckSessions";
            cmbCheckSessions.Size = new Size(300, 23);
            cmbCheckSessions.TabIndex = 1;
            // 
            // lblCheckSelected
            // 
            lblCheckSelected.AutoSize = true;
            lblCheckSelected.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblCheckSelected.Location = new Point(330, 23);
            lblCheckSelected.Name = "lblCheckSelected";
            lblCheckSelected.Size = new Size(68, 15);
            lblCheckSelected.TabIndex = 2;
            lblCheckSelected.Text = "선택됨: 없음";
            // 
            // btnCheckRefresh
            // 
            btnCheckRefresh.BackColor = Color.WhiteSmoke;
            btnCheckRefresh.FlatStyle = FlatStyle.Flat;
            btnCheckRefresh.Location = new Point(330, 41);
            btnCheckRefresh.Name = "btnCheckRefresh";
            btnCheckRefresh.Size = new Size(120, 34);
            btnCheckRefresh.TabIndex = 3;
            btnCheckRefresh.Text = "목록 새로고침";
            btnCheckRefresh.UseVisualStyleBackColor = false;
            btnCheckRefresh.UseVisualStyleBackColor = false;
            // 
            // grpCheckSummary
            // 
            grpCheckSummary.Controls.Add(rtbSummary);
            grpCheckSummary.Dock = DockStyle.Fill;
            grpCheckSummary.Location = new Point(10, 90);
            grpCheckSummary.Name = "grpCheckSummary";
            grpCheckSummary.Padding = new Padding(10, 5, 10, 10);
            grpCheckSummary.Size = new Size(862, 393);
            grpCheckSummary.TabIndex = 1;
            grpCheckSummary.TabStop = false;
            grpCheckSummary.Text = "백업 데이터 요약 (Summary)";
            // 
            // rtbSummary
            // 
            rtbSummary.BackColor = Color.White;
            rtbSummary.BorderStyle = BorderStyle.None;
            rtbSummary.Dock = DockStyle.Fill;
            rtbSummary.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rtbSummary.Location = new Point(10, 21);
            rtbSummary.Name = "rtbSummary";
            rtbSummary.ReadOnly = true;
            rtbSummary.Size = new Size(842, 362);
            rtbSummary.TabIndex = 0;
            rtbSummary.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 681);
            Controls.Add(pnlMiddle);
            Controls.Add(grpLog);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Backup & Restore Tool";
            pnlMiddle.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabBackup.ResumeLayout(false);
            gridBackup.ResumeLayout(false);
            grpSession.ResumeLayout(false);
            grpSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            grpAppsBackup.ResumeLayout(false);
            grpNetworkBackup.ResumeLayout(false);
            grpNetworkBackup.PerformLayout();
            grpCertsBackup.ResumeLayout(false);
            grpPrintersBackup.ResumeLayout(false);
            grpPrintersBackup.PerformLayout();
            grpBrowsersBackup.ResumeLayout(false);
            grpBrowsersBackup.PerformLayout();
            tabRestore.ResumeLayout(false);
            gridRestore.ResumeLayout(false);
            grpSourceRestore.ResumeLayout(false);
            grpSourceRestore.PerformLayout();
            grpNetworkRestore.ResumeLayout(false);
            grpNetworkRestore.PerformLayout();
            grpAppsRestore.ResumeLayout(false);
            grpCertsRestore.ResumeLayout(false);
            grpPrintersRestore.ResumeLayout(false);
            grpBrowsersRestore.ResumeLayout(false);
            grpBrowsersRestore.PerformLayout();
            grpLog.ResumeLayout(false);
            grpLog.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Declare Controls
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBackup;
        private System.Windows.Forms.TabPage tabRestore;
        private System.Windows.Forms.TableLayoutPanel gridBackup;
        private System.Windows.Forms.TableLayoutPanel gridRestore;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Button btnBackupAll;
        private System.Windows.Forms.Button btnRestoreAll;

        // Backup Controls
        private System.Windows.Forms.GroupBox grpSession;
        private System.Windows.Forms.Label lblSessionName;
        private System.Windows.Forms.TextBox txtSession;
        private System.Windows.Forms.Button btnSessionChange;
        private System.Windows.Forms.Button btnSessionDelete;

        private System.Windows.Forms.GroupBox grpBrowsersBackup;
        private System.Windows.Forms.CheckBox chkChrome;
        private System.Windows.Forms.Button btnPwdChrome;
        private System.Windows.Forms.CheckBox chkEdge;
        private System.Windows.Forms.Button btnPwdEdge;
        private System.Windows.Forms.Button btnBackupBrowsers;

        private System.Windows.Forms.GroupBox grpCertsBackup;
        private System.Windows.Forms.Button btnBackupCerts;

        private System.Windows.Forms.GroupBox grpNetworkBackup;
        private System.Windows.Forms.Label lblNetSource;
        private System.Windows.Forms.Label lblNetTarget;
        private System.Windows.Forms.ListBox lstNetBackup;
        private System.Windows.Forms.Button btnBackupNet;
        private System.Windows.Forms.Button btnRefreshNet;

        private System.Windows.Forms.GroupBox grpPrintersBackup;
        private System.Windows.Forms.Button btnPrinterTxt;
        private System.Windows.Forms.Button btnPrinterFull;

        private System.Windows.Forms.GroupBox grpAppsBackup;
        private System.Windows.Forms.Label lblApp1;
        private System.Windows.Forms.Button btnBackupApp1;
        private System.Windows.Forms.Label lblApp2;
        private System.Windows.Forms.Button btnBackupApp2;
        private System.Windows.Forms.Label lblApp3;
        private System.Windows.Forms.Button btnBackupApp3;

        // Restore Controls
        private System.Windows.Forms.GroupBox grpSourceRestore;
        private System.Windows.Forms.Label lblRestList;
        private System.Windows.Forms.ComboBox cmbRestSessions;
        private System.Windows.Forms.Label lblRestSelected;
        private System.Windows.Forms.Button btnRestRefresh;

        private System.Windows.Forms.GroupBox grpBrowsersRestore;
        private System.Windows.Forms.CheckBox chkChromeRest;
        private System.Windows.Forms.Button btnInstChrome;
        private System.Windows.Forms.CheckBox chkEdgeRest;
        private System.Windows.Forms.Button btnInstEdge;
        private System.Windows.Forms.Button btnRestoreBrowsers;

        private System.Windows.Forms.GroupBox grpCertsRestore;
        private System.Windows.Forms.Button btnRestoreCerts;

        private System.Windows.Forms.GroupBox grpNetworkRestore;
        private System.Windows.Forms.Label lblNetRest1;
        private System.Windows.Forms.Label lblNetRest2;
        private System.Windows.Forms.CheckedListBox lstNetRestSource;
        private System.Windows.Forms.ListBox lstNetRestTarget;
        private System.Windows.Forms.Button btnRestoreNet;
        private System.Windows.Forms.Button btnRefreshRestNet;

        private System.Windows.Forms.GroupBox grpPrintersRestore;
        private System.Windows.Forms.Button btnRestorePrinters;

        private System.Windows.Forms.GroupBox grpAppsRestore;
        private System.Windows.Forms.Label lblRestApp1;
        private System.Windows.Forms.Button btnRestApp1;
        private System.Windows.Forms.Button btnInstApp1;
        private System.Windows.Forms.Label lblRestApp2;
        private System.Windows.Forms.Button btnRestApp2;
        private System.Windows.Forms.Button btnInstApp2;
        private System.Windows.Forms.Label lblRestApp3;
        private System.Windows.Forms.Button btnRestApp3;
        private System.Windows.Forms.Button btnInstApp3;
        private System.Windows.Forms.Label lblBrowserWarn;
        private System.Windows.Forms.Label lblPrinterNote;
        private System.Windows.Forms.Label lblBrowserRestWarn;
        private System.Windows.Forms.Label lblNetRestWarn;
        private System.Windows.Forms.Label lblRestoreNote;
        private System.Windows.Forms.CheckedListBox lstNetSource;
        private Label label1;
        private TabPage tabCheck;
        private GroupBox grpCheckSelection;
        private Label lblCheckList;
        private ComboBox cmbCheckSessions;
        private Label lblCheckSelected;
        private Button btnCheckRefresh;
        private GroupBox grpCheckSummary;
        private RichTextBox rtbSummary;
    }
}
