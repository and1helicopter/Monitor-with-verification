namespace WindowsStructs
{
    partial class SystemConfiguratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemConfiguratorForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.defaultButton = new System.Windows.Forms.ToolStripButton();
            this.notifyIcon3 = new System.Windows.Forms.NotifyIcon(this.components);
            this.digitLabelButton = new GUIElements.LabelButton();
            this.timeLabelButton = new GUIElements.LabelButton();
            this.measureButton = new GUIElements.LabelButton();
            this.eventsBtn = new GUIElements.LabelButton();
            this.readyButton = new GUIElements.LabelButton();
            this.warnsButton = new GUIElements.LabelButton();
            this.alarmsButton = new GUIElements.LabelButton();
            this.addrsButton = new GUIElements.LabelButton();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.defaultButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(384, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.digitLabelButton);
            this.flowLayoutPanel1.Controls.Add(this.timeLabelButton);
            this.flowLayoutPanel1.Controls.Add(this.measureButton);
            this.flowLayoutPanel1.Controls.Add(this.eventsBtn);
            this.flowLayoutPanel1.Controls.Add(this.readyButton);
            this.flowLayoutPanel1.Controls.Add(this.warnsButton);
            this.flowLayoutPanel1.Controls.Add(this.alarmsButton);
            this.flowLayoutPanel1.Controls.Add(this.addrsButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(384, 219);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "alert_1432.ico");
            this.imageList1.Images.SetKeyName(1, "flag-32_6963.ico");
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon2.Icon")));
            this.notifyIcon2.Text = "notifyIcon2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WindowsStructs.Properties.Resources.folder_blue_open_1278;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "loadButton";
            this.toolStripButton1.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::WindowsStructs.Properties.Resources.filesaveas_1153;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "saveButton";
            this.toolStripButton2.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // defaultButton
            // 
            this.defaultButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.defaultButton.Image = ((System.Drawing.Image)(resources.GetObject("defaultButton.Image")));
            this.defaultButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.defaultButton.Name = "defaultButton";
            this.defaultButton.Size = new System.Drawing.Size(23, 22);
            this.defaultButton.Text = "toolStripButton3";
            this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
            // 
            // notifyIcon3
            // 
            this.notifyIcon3.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon3.Icon")));
            this.notifyIcon3.Text = "notifyIcon2";
            // 
            // digitLabelButton
            // 
            this.digitLabelButton.ButtonColor = System.Drawing.SystemColors.Control;
            this.digitLabelButton.ButtonMargin = new System.Windows.Forms.Padding(3);
            this.digitLabelButton.Image = global::WindowsStructs.Properties.Resources.binary_1556;
            this.digitLabelButton.Location = new System.Drawing.Point(3, 3);
            this.digitLabelButton.Name = "digitLabelButton";
            this.digitLabelButton.Size = new System.Drawing.Size(90, 100);
            this.digitLabelButton.TabIndex = 4;
            this.digitLabelButton.Title = "label1";
            this.digitLabelButton.ButtonClick += new System.EventHandler(this.digitLabelButton_ButtonClick);
            // 
            // timeLabelButton
            // 
            this.timeLabelButton.ButtonColor = System.Drawing.SystemColors.Control;
            this.timeLabelButton.ButtonMargin = new System.Windows.Forms.Padding(3);
            this.timeLabelButton.Image = global::WindowsStructs.Properties.Resources.xclock_8515;
            this.timeLabelButton.Location = new System.Drawing.Point(99, 3);
            this.timeLabelButton.Name = "timeLabelButton";
            this.timeLabelButton.Size = new System.Drawing.Size(90, 100);
            this.timeLabelButton.TabIndex = 5;
            this.timeLabelButton.Title = "label1";
            this.timeLabelButton.ButtonClick += new System.EventHandler(this.timeLabelButton_ButtonClick);
            // 
            // measureButton
            // 
            this.measureButton.ButtonColor = System.Drawing.SystemColors.Control;
            this.measureButton.ButtonMargin = new System.Windows.Forms.Padding(3);
            this.measureButton.Image = global::WindowsStructs.Properties.Resources.view_text_3644;
            this.measureButton.Location = new System.Drawing.Point(195, 3);
            this.measureButton.Name = "measureButton";
            this.measureButton.Size = new System.Drawing.Size(90, 100);
            this.measureButton.TabIndex = 6;
            this.measureButton.Title = "label1";
            this.measureButton.ButtonClick += new System.EventHandler(this.labelButton1_ButtonClick);
            // 
            // eventsBtn
            // 
            this.eventsBtn.ButtonColor = System.Drawing.SystemColors.Control;
            this.eventsBtn.ButtonMargin = new System.Windows.Forms.Padding(3);
            this.eventsBtn.Image = global::WindowsStructs.Properties.Resources.page_white_lightning_6386;
            this.eventsBtn.Location = new System.Drawing.Point(291, 3);
            this.eventsBtn.Name = "eventsBtn";
            this.eventsBtn.Size = new System.Drawing.Size(90, 100);
            this.eventsBtn.TabIndex = 7;
            this.eventsBtn.Title = "label1";
            this.eventsBtn.ButtonClick += new System.EventHandler(this.eventsBtn_ButtonClick);
            // 
            // readyButton
            // 
            this.readyButton.ButtonColor = System.Drawing.SystemColors.Control;
            this.readyButton.ButtonMargin = new System.Windows.Forms.Padding(3);
            this.readyButton.Image = global::WindowsStructs.Properties.Resources.block2_7748;
            this.readyButton.Location = new System.Drawing.Point(3, 109);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(90, 100);
            this.readyButton.TabIndex = 11;
            this.readyButton.Title = "label1";
            this.readyButton.ButtonClick += new System.EventHandler(this.readyButton_ButtonClick);
            // 
            // warnsButton
            // 
            this.warnsButton.ButtonColor = System.Drawing.SystemColors.Control;
            this.warnsButton.ButtonMargin = new System.Windows.Forms.Padding(3);
            this.warnsButton.Image = global::WindowsStructs.Properties.Resources.alert_1432;
            this.warnsButton.Location = new System.Drawing.Point(99, 109);
            this.warnsButton.Name = "warnsButton";
            this.warnsButton.Size = new System.Drawing.Size(90, 100);
            this.warnsButton.TabIndex = 8;
            this.warnsButton.Title = "label1";
            this.warnsButton.ButtonClick += new System.EventHandler(this.warnsButton_ButtonClick);
            this.warnsButton.Load += new System.EventHandler(this.warnsButton_Load);
            // 
            // alarmsButton
            // 
            this.alarmsButton.ButtonColor = System.Drawing.SystemColors.Control;
            this.alarmsButton.ButtonMargin = new System.Windows.Forms.Padding(3);
            this.alarmsButton.Image = global::WindowsStructs.Properties.Resources.flag_32_6963;
            this.alarmsButton.Location = new System.Drawing.Point(195, 109);
            this.alarmsButton.Name = "alarmsButton";
            this.alarmsButton.Size = new System.Drawing.Size(90, 100);
            this.alarmsButton.TabIndex = 9;
            this.alarmsButton.Title = "label1";
            this.alarmsButton.ButtonClick += new System.EventHandler(this.alarmsButton_ButtonClick);
            // 
            // addrsButton
            // 
            this.addrsButton.ButtonColor = System.Drawing.SystemColors.Control;
            this.addrsButton.ButtonMargin = new System.Windows.Forms.Padding(3);
            this.addrsButton.Image = global::WindowsStructs.Properties.Resources.binary_6516;
            this.addrsButton.Location = new System.Drawing.Point(291, 109);
            this.addrsButton.Name = "addrsButton";
            this.addrsButton.Size = new System.Drawing.Size(90, 100);
            this.addrsButton.TabIndex = 10;
            this.addrsButton.Title = "label1";
            this.addrsButton.ButtonClick += new System.EventHandler(this.addrsButton_ButtonClick);
            // 
            // SystemConfiguratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 244);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemConfiguratorForm";
            this.Text = "Конфигуратор типа систем";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private GUIElements.LabelButton digitLabelButton;
        private GUIElements.LabelButton timeLabelButton;
        private GUIElements.LabelButton measureButton;
        private GUIElements.LabelButton eventsBtn;
        private GUIElements.LabelButton warnsButton;
        private GUIElements.LabelButton alarmsButton;
        private GUIElements.LabelButton addrsButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
        private System.Windows.Forms.ToolStripButton defaultButton;
        private GUIElements.LabelButton readyButton;
        private System.Windows.Forms.NotifyIcon notifyIcon3;

    }
}