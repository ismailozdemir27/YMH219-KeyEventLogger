namespace KeyEventLogger.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatusBadge;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExportTxt;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.CheckBox chkAutoScroll;

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox txtInputArea;
        private System.Windows.Forms.Label lblInputHint;

        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnResetFilter;

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblStatsHeader;
        private System.Windows.Forms.ListBox lstTopKeys;
        private System.Windows.Forms.Label lblTotalEvents;
        private System.Windows.Forms.Label lblKeyDowns;
        private System.Windows.Forms.Label lblKeyUps;
        private System.Windows.Forms.Label lblUniqueKeys;

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblSecurityNotice;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCountStatus;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvCellStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatusBadge = new System.Windows.Forms.Label();

            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExportTxt = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();

            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtInputArea = new System.Windows.Forms.TextBox();
            this.lblInputHint = new System.Windows.Forms.Label();

            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.btnResetFilter = new System.Windows.Forms.Button();

            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvLogs = new System.Windows.Forms.DataGridView();

            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblStatsHeader = new System.Windows.Forms.Label();
            this.lblTotalEvents = new System.Windows.Forms.Label();
            this.lblKeyDowns = new System.Windows.Forms.Label();
            this.lblKeyUps = new System.Windows.Forms.Label();
            this.lblUniqueKeys = new System.Windows.Forms.Label();
            this.lstTopKeys = new System.Windows.Forms.ListBox();

            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblSecurityNotice = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordCountStatus = new System.Windows.Forms.ToolStripStatusLabel();

            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.pnlStats.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.lblStatusBadge);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1060, 56);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(430, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "⌨️ Eğitsel Key Event Logger (YMH219 NTP Lab)";

            // 
            // lblStatusBadge
            // 
            this.lblStatusBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStatusBadge.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblStatusBadge.ForeColor = System.Drawing.Color.White;
            this.lblStatusBadge.Location = new System.Drawing.Point(820, 12);
            this.lblStatusBadge.Name = "lblStatusBadge";
            this.lblStatusBadge.Size = new System.Drawing.Size(225, 32);
            this.lblStatusBadge.TabIndex = 1;
            this.lblStatusBadge.Text = "■ KAYIT DURDURULDU";
            this.lblStatusBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlToolbar.Controls.Add(this.btnStart);
            this.pnlToolbar.Controls.Add(this.btnStop);
            this.pnlToolbar.Controls.Add(this.btnClear);
            this.pnlToolbar.Controls.Add(this.btnExportTxt);
            this.pnlToolbar.Controls.Add(this.btnExportCsv);
            this.pnlToolbar.Controls.Add(this.chkAutoScroll);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 56);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlToolbar.Size = new System.Drawing.Size(1060, 48);
            this.pnlToolbar.TabIndex = 1;

            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(14, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(130, 32);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "▶ Kaydı Başlat";
            this.btnStart.UseVisualStyleBackColor = false;

            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(150, 8);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(130, 32);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "⏹ Kaydı Durdur";
            this.btnStop.UseVisualStyleBackColor = false;

            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(286, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(130, 32);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "🗑️ Ekranı Temizle";
            this.btnClear.UseVisualStyleBackColor = false;

            // 
            // btnExportTxt
            // 
            this.btnExportTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.btnExportTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportTxt.ForeColor = System.Drawing.Color.White;
            this.btnExportTxt.Location = new System.Drawing.Point(422, 8);
            this.btnExportTxt.Name = "btnExportTxt";
            this.btnExportTxt.Size = new System.Drawing.Size(140, 32);
            this.btnExportTxt.TabIndex = 3;
            this.btnExportTxt.Text = "💾 .TXT Kaydet";
            this.btnExportTxt.UseVisualStyleBackColor = false;

            // 
            // btnExportCsv
            // 
            this.btnExportCsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnExportCsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCsv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportCsv.ForeColor = System.Drawing.Color.White;
            this.btnExportCsv.Location = new System.Drawing.Point(568, 8);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(135, 32);
            this.btnExportCsv.TabIndex = 4;
            this.btnExportCsv.Text = "📊 .CSV Dışa Aktar";
            this.btnExportCsv.UseVisualStyleBackColor = false;

            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Checked = true;
            this.chkAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoScroll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkAutoScroll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.chkAutoScroll.Location = new System.Drawing.Point(920, 16);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(126, 19);
            this.chkAutoScroll.TabIndex = 5;
            this.chkAutoScroll.Text = "Otomatik Kaydır";
            this.chkAutoScroll.UseVisualStyleBackColor = true;

            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.txtInputArea);
            this.grpInput.Controls.Add(this.lblInputHint);
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpInput.Location = new System.Drawing.Point(0, 104);
            this.grpInput.Name = "grpInput";
            this.grpInput.Padding = new System.Windows.Forms.Padding(12, 4, 12, 8);
            this.grpInput.Size = new System.Drawing.Size(1060, 74);
            this.grpInput.TabIndex = 2;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "🎯 Tuş Giriş ve Test Alanı (Klavye olayları bu pencere aktifken yakalanır)";

            // 
            // txtInputArea
            // 
            this.txtInputArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputArea.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtInputArea.Location = new System.Drawing.Point(14, 22);
            this.txtInputArea.Name = "txtInputArea";
            this.txtInputArea.PlaceholderText = "Buraya yazı yazarak klavye olaylarını (KeyDown, KeyUp, KeyPress) test edebilirsiniz...";
            this.txtInputArea.Size = new System.Drawing.Size(780, 26);
            this.txtInputArea.TabIndex = 0;

            // 
            // lblInputHint
            // 
            this.lblInputHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInputHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            this.lblInputHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblInputHint.Location = new System.Drawing.Point(800, 20);
            this.lblInputHint.Name = "lblInputHint";
            this.lblInputHint.Size = new System.Drawing.Size(245, 32);
            this.lblInputHint.TabIndex = 1;
            this.lblInputHint.Text = "İpucu: Form üzerinde basılan tüm tuşlar KeyPreview sayesinde otomatik yakalanır.";

            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.txtSearch);
            this.grpFilter.Controls.Add(this.cmbFilterType);
            this.grpFilter.Controls.Add(this.dtpStartTime);
            this.grpFilter.Controls.Add(this.dtpEndTime);
            this.grpFilter.Controls.Add(this.btnApplyFilter);
            this.grpFilter.Controls.Add(this.btnResetFilter);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpFilter.Location = new System.Drawing.Point(0, 178);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(12, 4, 12, 8);
            this.grpFilter.Size = new System.Drawing.Size(1060, 64);
            this.grpFilter.TabIndex = 3;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "🔍 Kayıt Filtreleme (İsteğe Bağlı Özellik)";

            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(14, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tuş veya Değiştirici Ara (örn: Enter, Shift)...";
            this.txtSearch.Size = new System.Drawing.Size(220, 23);
            this.txtSearch.TabIndex = 0;

            // 
            // cmbFilterType
            // 
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Items.AddRange(new object[] {
            "Tüm Olay Türleri",
            "Sadece KeyDown",
            "Sadece KeyUp",
            "Sadece KeyPress"});
            this.cmbFilterType.Location = new System.Drawing.Point(242, 24);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(140, 23);
            this.cmbFilterType.TabIndex = 1;

            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(390, 24);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(90, 23);
            this.dtpStartTime.TabIndex = 2;

            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(488, 24);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(90, 23);
            this.dtpEndTime.TabIndex = 3;

            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilter.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilter.Location = new System.Drawing.Point(588, 22);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(100, 27);
            this.btnApplyFilter.TabIndex = 4;
            this.btnApplyFilter.Text = "Filtrele";
            this.btnApplyFilter.UseVisualStyleBackColor = false;

            // 
            // btnResetFilter
            // 
            this.btnResetFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnResetFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFilter.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnResetFilter.ForeColor = System.Drawing.Color.White;
            this.btnResetFilter.Location = new System.Drawing.Point(696, 22);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(100, 27);
            this.btnResetFilter.TabIndex = 5;
            this.btnResetFilter.Text = "Sıfırla";
            this.btnResetFilter.UseVisualStyleBackColor = false;

            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitMain.Location = new System.Drawing.Point(0, 242);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.dgvLogs);
            this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(12, 8, 4, 8);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.pnlStats);
            this.splitMain.Panel2.Padding = new System.Windows.Forms.Padding(4, 8, 12, 8);
            this.splitMain.Size = new System.Drawing.Size(1060, 362);
            this.splitMain.SplitterDistance = 780;
            this.splitMain.TabIndex = 4;

            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.AllowUserToResizeRows = false;
            this.dgvLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvLogs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLogs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLogs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dgvHeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            dgvHeaderStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogs.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvLogs.ColumnHeadersHeight = 32;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle.BackColor = System.Drawing.Color.White;
            dgvCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            dgvCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgvCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLogs.DefaultCellStyle = dgvCellStyle;
            this.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogs.EnableHeadersVisualStyles = false;
            this.dgvLogs.Location = new System.Drawing.Point(12, 8);
            this.dgvLogs.MultiSelect = false;
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowHeadersVisible = false;
            this.dgvLogs.RowTemplate.Height = 24;
            this.dgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogs.Size = new System.Drawing.Size(764, 346);
            this.dgvLogs.TabIndex = 0;

            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStats.Controls.Add(this.lstTopKeys);
            this.pnlStats.Controls.Add(this.lblUniqueKeys);
            this.pnlStats.Controls.Add(this.lblKeyUps);
            this.pnlStats.Controls.Add(this.lblKeyDowns);
            this.pnlStats.Controls.Add(this.lblTotalEvents);
            this.pnlStats.Controls.Add(this.lblStatsHeader);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStats.Location = new System.Drawing.Point(4, 8);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(10);
            this.pnlStats.Size = new System.Drawing.Size(262, 346);
            this.pnlStats.TabIndex = 0;

            // 
            // lblStatsHeader
            // 
            this.lblStatsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatsHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatsHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblStatsHeader.Location = new System.Drawing.Point(10, 10);
            this.lblStatsHeader.Name = "lblStatsHeader";
            this.lblStatsHeader.Size = new System.Drawing.Size(240, 24);
            this.lblStatsHeader.TabIndex = 0;
            this.lblStatsHeader.Text = "📊 Tuş İstatistikleri";

            // 
            // lblTotalEvents
            // 
            this.lblTotalEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalEvents.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalEvents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblTotalEvents.Location = new System.Drawing.Point(10, 34);
            this.lblTotalEvents.Name = "lblTotalEvents";
            this.lblTotalEvents.Size = new System.Drawing.Size(240, 20);
            this.lblTotalEvents.TabIndex = 1;
            this.lblTotalEvents.Text = "Toplam Olay: 0";

            // 
            // lblKeyDowns
            // 
            this.lblKeyDowns.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKeyDowns.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKeyDowns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblKeyDowns.Location = new System.Drawing.Point(10, 54);
            this.lblKeyDowns.Name = "lblKeyDowns";
            this.lblKeyDowns.Size = new System.Drawing.Size(240, 20);
            this.lblKeyDowns.TabIndex = 2;
            this.lblKeyDowns.Text = "KeyDown: 0";

            // 
            // lblKeyUps
            // 
            this.lblKeyUps.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKeyUps.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKeyUps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblKeyUps.Location = new System.Drawing.Point(10, 74);
            this.lblKeyUps.Name = "lblKeyUps";
            this.lblKeyUps.Size = new System.Drawing.Size(240, 20);
            this.lblKeyUps.TabIndex = 3;
            this.lblKeyUps.Text = "KeyUp: 0";

            // 
            // lblUniqueKeys
            // 
            this.lblUniqueKeys.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUniqueKeys.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUniqueKeys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblUniqueKeys.Location = new System.Drawing.Point(10, 94);
            this.lblUniqueKeys.Name = "lblUniqueKeys";
            this.lblUniqueKeys.Size = new System.Drawing.Size(240, 24);
            this.lblUniqueKeys.TabIndex = 4;
            this.lblUniqueKeys.Text = "Farklı Tuş: 0";

            // 
            // lstTopKeys
            // 
            this.lstTopKeys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTopKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTopKeys.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lstTopKeys.FormattingEnabled = true;
            this.lstTopKeys.ItemHeight = 13;
            this.lstTopKeys.Location = new System.Drawing.Point(10, 118);
            this.lstTopKeys.Name = "lstTopKeys";
            this.lstTopKeys.Size = new System.Drawing.Size(240, 216);
            this.lstTopKeys.TabIndex = 5;

            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSecurityNotice,
            this.lblRecordCountStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 604);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1060, 24);
            this.statusStrip.TabIndex = 5;

            // 
            // lblSecurityNotice
            // 
            this.lblSecurityNotice.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSecurityNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSecurityNotice.Name = "lblSecurityNotice";
            this.lblSecurityNotice.Size = new System.Drawing.Size(680, 19);
            this.lblSecurityNotice.Spring = true;
            this.lblSecurityNotice.Text = "🛡️ Güvenlik Sınırı: Yalnızca bu pencere odaktayken eğitim amaçlı olay yakalar. Global kanca veya arka plan dinlemesi içermez.";
            this.lblSecurityNotice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lblRecordCountStatus
            // 
            this.lblRecordCountStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRecordCountStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblRecordCountStatus.Name = "lblRecordCountStatus";
            this.lblRecordCountStatus.Size = new System.Drawing.Size(120, 19);
            this.lblRecordCountStatus.Text = "Listelenen: 0 olay";

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 628);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(920, 560);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eğitsel Key Event Logger - YMH219 Nesne Tabanlı Programlama";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
