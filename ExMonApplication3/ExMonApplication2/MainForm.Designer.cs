namespace ExMonApplication2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.timeTimer = new System.Windows.Forms.Timer(this.components);
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.connectBtn = new System.Windows.Forms.Button();
			this.disconnectBtn = new System.Windows.Forms.Button();
			this.comSetBtn = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.setupFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.loadSysTypeBtn = new System.Windows.Forms.Button();
			this.configBtn = new System.Windows.Forms.Button();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.setClockBtn = new System.Windows.Forms.Button();
			this.digitsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.digOutComboBox = new System.Windows.Forms.ComboBox();
			this.digInBtn = new System.Windows.Forms.Button();
			this.digOutBtn = new System.Windows.Forms.Button();
			this.digInComboBox = new System.Windows.Forms.ComboBox();
			this.digitTitle = new System.Windows.Forms.Label();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.directBtn = new GUIElements.LabelButton();
			this.directFloatBtn = new GUIElements.LabelButton();
			this.loadSYMBtn = new GUIElements.LabelButton();
			this.scopeLabelButton = new GUIElements.LabelButton();
			this.eventLabelButton = new GUIElements.LabelButton();
			this.jogLabelButton = new GUIElements.LabelButton();
			this.angleLabelButton = new GUIElements.LabelButton();
			this.verificationlabelButton = new GUIElements.LabelButton();
			this.statusStrip1.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.setupFlowLayoutPanel.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.digitsTableLayoutPanel.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeLabel});
			this.statusStrip1.Location = new System.Drawing.Point(3, 422);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(461, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// timeLabel
			// 
			this.timeLabel.Name = "timeLabel";
			this.timeLabel.Size = new System.Drawing.Size(126, 17);
			this.timeLabel.Text = "00:00:00 00/00/2000";
			// 
			// timeTimer
			// 
			this.timeTimer.Enabled = true;
			this.timeTimer.Interval = 500;
			this.timeTimer.Tick += new System.EventHandler(this.timeTimer_Tick);
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.AutoSize = true;
			this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel3.Controls.Add(this.connectBtn);
			this.flowLayoutPanel3.Controls.Add(this.disconnectBtn);
			this.flowLayoutPanel3.Controls.Add(this.comSetBtn);
			this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(155, 53);
			this.flowLayoutPanel3.TabIndex = 6;
			// 
			// connectBtn
			// 
			this.connectBtn.Image = global::ExMonApplication3.Properties.Resources.CONNECT;
			this.connectBtn.Location = new System.Drawing.Point(3, 3);
			this.connectBtn.Name = "connectBtn";
			this.connectBtn.Size = new System.Drawing.Size(45, 45);
			this.connectBtn.TabIndex = 0;
			this.connectBtn.UseVisualStyleBackColor = false;
			this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
			// 
			// disconnectBtn
			// 
			this.disconnectBtn.Enabled = false;
			this.disconnectBtn.Image = global::ExMonApplication3.Properties.Resources.disconnect;
			this.disconnectBtn.Location = new System.Drawing.Point(54, 3);
			this.disconnectBtn.Name = "disconnectBtn";
			this.disconnectBtn.Size = new System.Drawing.Size(45, 45);
			this.disconnectBtn.TabIndex = 1;
			this.disconnectBtn.UseVisualStyleBackColor = false;
			this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
			// 
			// comSetBtn
			// 
			this.comSetBtn.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comSetBtn.ImageIndex = 1;
			this.comSetBtn.ImageList = this.imageList1;
			this.comSetBtn.Location = new System.Drawing.Point(105, 3);
			this.comSetBtn.Name = "comSetBtn";
			this.comSetBtn.Size = new System.Drawing.Size(45, 45);
			this.comSetBtn.TabIndex = 5;
			this.comSetBtn.UseVisualStyleBackColor = false;
			this.comSetBtn.Click += new System.EventHandler(this.comSetBtn_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "network-config_6055.ico");
			this.imageList1.Images.SetKeyName(1, "network-config_6784.ico");
			// 
			// setupFlowLayoutPanel
			// 
			this.setupFlowLayoutPanel.AutoSize = true;
			this.setupFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.setupFlowLayoutPanel.Controls.Add(this.loadSysTypeBtn);
			this.setupFlowLayoutPanel.Controls.Add(this.configBtn);
			this.setupFlowLayoutPanel.Location = new System.Drawing.Point(353, 3);
			this.setupFlowLayoutPanel.Name = "setupFlowLayoutPanel";
			this.setupFlowLayoutPanel.Size = new System.Drawing.Size(104, 53);
			this.setupFlowLayoutPanel.TabIndex = 7;
			// 
			// loadSysTypeBtn
			// 
			this.loadSysTypeBtn.Image = global::ExMonApplication3.Properties.Resources.folder_blue_open_9731;
			this.loadSysTypeBtn.Location = new System.Drawing.Point(3, 3);
			this.loadSysTypeBtn.Name = "loadSysTypeBtn";
			this.loadSysTypeBtn.Size = new System.Drawing.Size(45, 45);
			this.loadSysTypeBtn.TabIndex = 3;
			this.loadSysTypeBtn.UseVisualStyleBackColor = false;
			this.loadSysTypeBtn.Click += new System.EventHandler(this.loadSysTypeBtn_Click);
			// 
			// configBtn
			// 
			this.configBtn.Image = global::ExMonApplication3.Properties.Resources.advancedsettings_8664;
			this.configBtn.Location = new System.Drawing.Point(54, 3);
			this.configBtn.Name = "configBtn";
			this.configBtn.Size = new System.Drawing.Size(45, 45);
			this.configBtn.TabIndex = 2;
			this.configBtn.UseVisualStyleBackColor = false;
			this.configBtn.Click += new System.EventHandler(this.configBtn_Click);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.setupFlowLayoutPanel, 2, 1);
			this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(461, 62);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(353, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105, 1);
			this.label3.TabIndex = 11;
			this.label3.Text = "Сервис";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(164, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(183, 1);
			this.label2.TabIndex = 10;
			this.label2.Text = "Тип системы";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(155, 1);
			this.label1.TabIndex = 9;
			this.label1.Text = "Соединение";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel1.Controls.Add(this.setClockBtn);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(164, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(53, 53);
			this.flowLayoutPanel1.TabIndex = 12;
			// 
			// setClockBtn
			// 
			this.setClockBtn.Enabled = false;
			this.setClockBtn.Image = global::ExMonApplication3.Properties.Resources.xclock_7308;
			this.setClockBtn.Location = new System.Drawing.Point(3, 3);
			this.setClockBtn.Name = "setClockBtn";
			this.setClockBtn.Size = new System.Drawing.Size(45, 45);
			this.setClockBtn.TabIndex = 9;
			this.setClockBtn.UseVisualStyleBackColor = false;
			this.setClockBtn.Click += new System.EventHandler(this.setClockBtn_Click);
			// 
			// digitsTableLayoutPanel
			// 
			this.digitsTableLayoutPanel.ColumnCount = 2;
			this.digitsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.digitsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
			this.digitsTableLayoutPanel.Controls.Add(this.digOutComboBox, 0, 2);
			this.digitsTableLayoutPanel.Controls.Add(this.digInBtn, 1, 1);
			this.digitsTableLayoutPanel.Controls.Add(this.digOutBtn, 1, 2);
			this.digitsTableLayoutPanel.Controls.Add(this.digInComboBox, 0, 1);
			this.digitsTableLayoutPanel.Controls.Add(this.digitTitle, 0, 0);
			this.digitsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.digitsTableLayoutPanel.Location = new System.Drawing.Point(3, 65);
			this.digitsTableLayoutPanel.Name = "digitsTableLayoutPanel";
			this.digitsTableLayoutPanel.RowCount = 3;
			this.digitsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.digitsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.digitsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.digitsTableLayoutPanel.Size = new System.Drawing.Size(461, 125);
			this.digitsTableLayoutPanel.TabIndex = 9;
			// 
			// digOutComboBox
			// 
			this.digOutComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.digOutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.digOutComboBox.Enabled = false;
			this.digOutComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.digOutComboBox.FormattingEnabled = true;
			this.digOutComboBox.Location = new System.Drawing.Point(3, 85);
			this.digOutComboBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
			this.digOutComboBox.Name = "digOutComboBox";
			this.digOutComboBox.Size = new System.Drawing.Size(345, 28);
			this.digOutComboBox.TabIndex = 3;
			// 
			// digInBtn
			// 
			this.digInBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.digInBtn.Enabled = false;
			this.digInBtn.Image = global::ExMonApplication3.Properties.Resources.viewmagfit_8658;
			this.digInBtn.Location = new System.Drawing.Point(354, 37);
			this.digInBtn.Margin = new System.Windows.Forms.Padding(3, 7, 3, 6);
			this.digInBtn.Name = "digInBtn";
			this.digInBtn.Size = new System.Drawing.Size(104, 34);
			this.digInBtn.TabIndex = 0;
			this.digInBtn.UseVisualStyleBackColor = false;
			this.digInBtn.Click += new System.EventHandler(this.digInBtn_Click);
			// 
			// digOutBtn
			// 
			this.digOutBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.digOutBtn.Enabled = false;
			this.digOutBtn.Image = global::ExMonApplication3.Properties.Resources.viewmagfit_8658;
			this.digOutBtn.Location = new System.Drawing.Point(354, 84);
			this.digOutBtn.Margin = new System.Windows.Forms.Padding(3, 7, 3, 6);
			this.digOutBtn.Name = "digOutBtn";
			this.digOutBtn.Size = new System.Drawing.Size(104, 35);
			this.digOutBtn.TabIndex = 1;
			this.digOutBtn.UseVisualStyleBackColor = false;
			this.digOutBtn.Click += new System.EventHandler(this.digOutBtn_Click);
			// 
			// digInComboBox
			// 
			this.digInComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.digInComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.digInComboBox.Enabled = false;
			this.digInComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.digInComboBox.FormattingEnabled = true;
			this.digInComboBox.Location = new System.Drawing.Point(3, 38);
			this.digInComboBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
			this.digInComboBox.Name = "digInComboBox";
			this.digInComboBox.Size = new System.Drawing.Size(345, 28);
			this.digInComboBox.TabIndex = 2;
			// 
			// digitTitle
			// 
			this.digitTitle.AutoSize = true;
			this.digitsTableLayoutPanel.SetColumnSpan(this.digitTitle, 2);
			this.digitTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.digitTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
			this.digitTitle.Location = new System.Drawing.Point(3, 0);
			this.digitTitle.Name = "digitTitle";
			this.digitTitle.Size = new System.Drawing.Size(455, 30);
			this.digitTitle.TabIndex = 4;
			this.digitTitle.Text = "Дискретные модули";
			this.digitTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel2.Controls.Add(this.directBtn);
			this.flowLayoutPanel2.Controls.Add(this.directFloatBtn);
			this.flowLayoutPanel2.Controls.Add(this.loadSYMBtn);
			this.flowLayoutPanel2.Controls.Add(this.scopeLabelButton);
			this.flowLayoutPanel2.Controls.Add(this.eventLabelButton);
			this.flowLayoutPanel2.Controls.Add(this.jogLabelButton);
			this.flowLayoutPanel2.Controls.Add(this.angleLabelButton);
			this.flowLayoutPanel2.Controls.Add(this.verificationlabelButton);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 190);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(461, 232);
			this.flowLayoutPanel2.TabIndex = 10;
			// 
			// directBtn
			// 
			this.directBtn.ButtonColor = System.Drawing.SystemColors.Control;
			this.directBtn.ButtonMargin = new System.Windows.Forms.Padding(3);
			this.directBtn.Image = global::ExMonApplication3.Properties.Resources.accessories_text_editor_1790;
			this.directBtn.Location = new System.Drawing.Point(4, 4);
			this.directBtn.Margin = new System.Windows.Forms.Padding(4);
			this.directBtn.Name = "directBtn";
			this.directBtn.Size = new System.Drawing.Size(68, 117);
			this.directBtn.TabIndex = 0;
			this.directBtn.Title = "label1";
			this.directBtn.ButtonClick += new System.EventHandler(this.directBtn_ButtonClick);
			// 
			// directFloatBtn
			// 
			this.directFloatBtn.ButtonColor = System.Drawing.SystemColors.Control;
			this.directFloatBtn.ButtonMargin = new System.Windows.Forms.Padding(3);
			this.directFloatBtn.Image = global::ExMonApplication3.Properties.Resources.accessories_text_editor_1790;
			this.directFloatBtn.Location = new System.Drawing.Point(80, 4);
			this.directFloatBtn.Margin = new System.Windows.Forms.Padding(4);
			this.directFloatBtn.Name = "directFloatBtn";
			this.directFloatBtn.Size = new System.Drawing.Size(68, 117);
			this.directFloatBtn.TabIndex = 1;
			this.directFloatBtn.Title = "label1";
			this.directFloatBtn.ButtonClick += new System.EventHandler(this.directFloatBtn_ButtonClick);
			// 
			// loadSYMBtn
			// 
			this.loadSYMBtn.ButtonColor = System.Drawing.SystemColors.Control;
			this.loadSYMBtn.ButtonMargin = new System.Windows.Forms.Padding(3);
			this.loadSYMBtn.Image = global::ExMonApplication3.Properties.Resources.smart_media_unmount_8501;
			this.loadSYMBtn.Location = new System.Drawing.Point(156, 4);
			this.loadSYMBtn.Margin = new System.Windows.Forms.Padding(4);
			this.loadSYMBtn.Name = "loadSYMBtn";
			this.loadSYMBtn.Size = new System.Drawing.Size(68, 117);
			this.loadSYMBtn.TabIndex = 2;
			this.loadSYMBtn.Title = "label1";
			this.loadSYMBtn.ButtonClick += new System.EventHandler(this.loadSYMBtn_ButtonClick);
			// 
			// scopeLabelButton
			// 
			this.scopeLabelButton.ButtonColor = System.Drawing.SystemColors.Control;
			this.scopeLabelButton.ButtonMargin = new System.Windows.Forms.Padding(3);
			this.scopeLabelButton.Image = global::ExMonApplication3.Properties.Resources.utilities_system_monitor_9425;
			this.scopeLabelButton.Location = new System.Drawing.Point(232, 4);
			this.scopeLabelButton.Margin = new System.Windows.Forms.Padding(4);
			this.scopeLabelButton.Name = "scopeLabelButton";
			this.scopeLabelButton.Size = new System.Drawing.Size(68, 117);
			this.scopeLabelButton.TabIndex = 3;
			this.scopeLabelButton.Title = "label1";
			this.scopeLabelButton.ButtonClick += new System.EventHandler(this.scopeLabelButton_ButtonClick);
			// 
			// eventLabelButton
			// 
			this.eventLabelButton.ButtonColor = System.Drawing.SystemColors.Control;
			this.eventLabelButton.ButtonMargin = new System.Windows.Forms.Padding(3);
			this.eventLabelButton.Image = global::ExMonApplication3.Properties.Resources.archive_3355;
			this.eventLabelButton.Location = new System.Drawing.Point(308, 4);
			this.eventLabelButton.Margin = new System.Windows.Forms.Padding(4);
			this.eventLabelButton.Name = "eventLabelButton";
			this.eventLabelButton.Size = new System.Drawing.Size(68, 117);
			this.eventLabelButton.TabIndex = 4;
			this.eventLabelButton.Title = "label1";
			this.eventLabelButton.ButtonClick += new System.EventHandler(this.eventLabelButton_ButtonClick);
			// 
			// jogLabelButton
			// 
			this.jogLabelButton.ButtonColor = System.Drawing.SystemColors.Control;
			this.jogLabelButton.ButtonMargin = new System.Windows.Forms.Padding(3);
			this.jogLabelButton.Image = global::ExMonApplication3.Properties.Resources.jog;
			this.jogLabelButton.Location = new System.Drawing.Point(384, 4);
			this.jogLabelButton.Margin = new System.Windows.Forms.Padding(4);
			this.jogLabelButton.Name = "jogLabelButton";
			this.jogLabelButton.Size = new System.Drawing.Size(68, 117);
			this.jogLabelButton.TabIndex = 5;
			this.jogLabelButton.Title = "label1";
			this.jogLabelButton.ButtonClick += new System.EventHandler(this.jogLabelButton_ButtonClick);
			// 
			// angleLabelButton
			// 
			this.angleLabelButton.ButtonColor = System.Drawing.SystemColors.Control;
			this.angleLabelButton.ButtonMargin = new System.Windows.Forms.Padding(3);
			this.angleLabelButton.Image = global::ExMonApplication3.Properties.Resources.binary_6516;
			this.angleLabelButton.Location = new System.Drawing.Point(4, 129);
			this.angleLabelButton.Margin = new System.Windows.Forms.Padding(4);
			this.angleLabelButton.Name = "angleLabelButton";
			this.angleLabelButton.Size = new System.Drawing.Size(68, 117);
			this.angleLabelButton.TabIndex = 6;
			this.angleLabelButton.Title = "label1";
			this.angleLabelButton.ButtonClick += new System.EventHandler(this.angleLabelButton_ButtonClick);
			// 
			// verificationlabelButton
			// 
			this.verificationlabelButton.ButtonColor = System.Drawing.SystemColors.Control;
			this.verificationlabelButton.ButtonMargin = new System.Windows.Forms.Padding(3);
			this.verificationlabelButton.Image = global::ExMonApplication3.Properties.Resources.verification;
			this.verificationlabelButton.Location = new System.Drawing.Point(80, 129);
			this.verificationlabelButton.Margin = new System.Windows.Forms.Padding(4);
			this.verificationlabelButton.Name = "verificationlabelButton";
			this.verificationlabelButton.Size = new System.Drawing.Size(68, 117);
			this.verificationlabelButton.TabIndex = 7;
			this.verificationlabelButton.Title = "label1";
			this.verificationlabelButton.ButtonClick += new System.EventHandler(this.labelButton1_ButtonClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(467, 447);
			this.Controls.Add(this.flowLayoutPanel2);
			this.Controls.Add(this.digitsTableLayoutPanel);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.statusStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "Monitor";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.setupFlowLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.digitsTableLayoutPanel.ResumeLayout(false);
			this.digitsTableLayoutPanel.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.Button configBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel timeLabel;
        private System.Windows.Forms.Timer timeTimer;
        private System.Windows.Forms.Button loadSysTypeBtn;
        private System.Windows.Forms.Button comSetBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel setupFlowLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel digitsTableLayoutPanel;
        private System.Windows.Forms.ComboBox digOutComboBox;
        private System.Windows.Forms.Button digInBtn;
        private System.Windows.Forms.Button digOutBtn;
        private System.Windows.Forms.ComboBox digInComboBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button setClockBtn;
        private System.Windows.Forms.Label digitTitle;
        private System.Windows.Forms.ImageList imageList1;
        private GUIElements.LabelButton directBtn;
        private GUIElements.LabelButton directFloatBtn;
        private GUIElements.LabelButton loadSYMBtn;
        private GUIElements.LabelButton scopeLabelButton;
        private GUIElements.LabelButton eventLabelButton;
        private GUIElements.LabelButton jogLabelButton;
        private GUIElements.LabelButton angleLabelButton;
        private GUIElements.LabelButton verificationlabelButton;
    }
}

