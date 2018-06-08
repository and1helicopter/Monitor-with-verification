namespace ScopeLoadForms
{
    partial class ScopeSetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScopeSetupForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.writeToSystemBtn = new System.Windows.Forms.ToolStripButton();
            this.reloadBtn = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.enaScopeCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.hystoryRadioButton3 = new System.Windows.Forms.RadioButton();
            this.hystoryRadioButton2 = new System.Windows.Forms.RadioButton();
            this.hystoryRadioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.oscFreqRadioButton3 = new System.Windows.Forms.RadioButton();
            this.oscFreqRadioButton2 = new System.Windows.Forms.RadioButton();
            this.oscFreqRadioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chCountRadioButton6 = new System.Windows.Forms.RadioButton();
            this.chCountRadioButton5 = new System.Windows.Forms.RadioButton();
            this.chCountRadioButton4 = new System.Windows.Forms.RadioButton();
            this.chCountRadioButton3 = new System.Windows.Forms.RadioButton();
            this.chCountRadioButton2 = new System.Windows.Forms.RadioButton();
            this.chCountRadioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.oscTimeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.possibleParamPanel = new System.Windows.Forms.Panel();
            this.possibleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sampleNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.currentParamsPanel = new System.Windows.Forms.Panel();
            this.currentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.possibleParamPanel.SuspendLayout();
            this.possibleTableLayoutPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.currentParamsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.writeToSystemBtn,
            this.reloadBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(917, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // writeToSystemBtn
            // 
            this.writeToSystemBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.writeToSystemBtn.Image = ((System.Drawing.Image)(resources.GetObject("writeToSystemBtn.Image")));
            this.writeToSystemBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.writeToSystemBtn.Name = "writeToSystemBtn";
            this.writeToSystemBtn.Size = new System.Drawing.Size(23, 22);
            this.writeToSystemBtn.Text = "Загрузиь конфигурацию в систему";
            this.writeToSystemBtn.Click += new System.EventHandler(this.writeToSystemBtn_Click);
            // 
            // reloadBtn
            // 
            this.reloadBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reloadBtn.Image = ((System.Drawing.Image)(resources.GetObject("reloadBtn.Image")));
            this.reloadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(23, 22);
            this.reloadBtn.Text = "Загрузить конфигурацию с системы";
            this.reloadBtn.Visible = false;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 125);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.enaScopeCheckBox, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.oscTimeLabel, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(913, 121);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // enaScopeCheckBox
            // 
            this.enaScopeCheckBox.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.enaScopeCheckBox, 2);
            this.enaScopeCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enaScopeCheckBox.Location = new System.Drawing.Point(459, 98);
            this.enaScopeCheckBox.Name = "enaScopeCheckBox";
            this.enaScopeCheckBox.Size = new System.Drawing.Size(451, 20);
            this.enaScopeCheckBox.TabIndex = 7;
            this.enaScopeCheckBox.Text = "Осциллографирование включено";
            this.enaScopeCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.hystoryRadioButton3);
            this.groupBox4.Controls.Add(this.hystoryRadioButton2);
            this.groupBox4.Controls.Add(this.hystoryRadioButton1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(687, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(223, 89);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Предыстория";
            // 
            // hystoryRadioButton3
            // 
            this.hystoryRadioButton3.AutoSize = true;
            this.hystoryRadioButton3.Location = new System.Drawing.Point(6, 65);
            this.hystoryRadioButton3.Name = "hystoryRadioButton3";
            this.hystoryRadioButton3.Size = new System.Drawing.Size(48, 17);
            this.hystoryRadioButton3.TabIndex = 6;
            this.hystoryRadioButton3.TabStop = true;
            this.hystoryRadioButton3.Text = "75 %";
            this.hystoryRadioButton3.UseVisualStyleBackColor = true;
            this.hystoryRadioButton3.CheckedChanged += new System.EventHandler(this.hystoryRadioButton3_CheckedChanged);
            // 
            // hystoryRadioButton2
            // 
            this.hystoryRadioButton2.AutoSize = true;
            this.hystoryRadioButton2.Location = new System.Drawing.Point(6, 42);
            this.hystoryRadioButton2.Name = "hystoryRadioButton2";
            this.hystoryRadioButton2.Size = new System.Drawing.Size(48, 17);
            this.hystoryRadioButton2.TabIndex = 5;
            this.hystoryRadioButton2.TabStop = true;
            this.hystoryRadioButton2.Text = "50 %";
            this.hystoryRadioButton2.UseVisualStyleBackColor = true;
            this.hystoryRadioButton2.CheckedChanged += new System.EventHandler(this.hystoryRadioButton2_CheckedChanged);
            // 
            // hystoryRadioButton1
            // 
            this.hystoryRadioButton1.AutoSize = true;
            this.hystoryRadioButton1.Checked = true;
            this.hystoryRadioButton1.Location = new System.Drawing.Point(6, 19);
            this.hystoryRadioButton1.Name = "hystoryRadioButton1";
            this.hystoryRadioButton1.Size = new System.Drawing.Size(48, 17);
            this.hystoryRadioButton1.TabIndex = 4;
            this.hystoryRadioButton1.TabStop = true;
            this.hystoryRadioButton1.Text = "25 %";
            this.hystoryRadioButton1.UseVisualStyleBackColor = true;
            this.hystoryRadioButton1.CheckedChanged += new System.EventHandler(this.hystoryRadioButton1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.oscFreqRadioButton3);
            this.groupBox3.Controls.Add(this.oscFreqRadioButton2);
            this.groupBox3.Controls.Add(this.oscFreqRadioButton1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(459, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 89);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Дискретность";
            // 
            // oscFreqRadioButton3
            // 
            this.oscFreqRadioButton3.AutoSize = true;
            this.oscFreqRadioButton3.Location = new System.Drawing.Point(6, 65);
            this.oscFreqRadioButton3.Name = "oscFreqRadioButton3";
            this.oscFreqRadioButton3.Size = new System.Drawing.Size(52, 17);
            this.oscFreqRadioButton3.TabIndex = 6;
            this.oscFreqRadioButton3.TabStop = true;
            this.oscFreqRadioButton3.Tag = "7";
            this.oscFreqRadioButton3.Text = "1 кГц";
            this.oscFreqRadioButton3.UseVisualStyleBackColor = true;
            this.oscFreqRadioButton3.CheckedChanged += new System.EventHandler(this.oscFreqRadioButton1_CheckedChanged);
            // 
            // oscFreqRadioButton2
            // 
            this.oscFreqRadioButton2.AutoSize = true;
            this.oscFreqRadioButton2.Location = new System.Drawing.Point(6, 42);
            this.oscFreqRadioButton2.Name = "oscFreqRadioButton2";
            this.oscFreqRadioButton2.Size = new System.Drawing.Size(52, 17);
            this.oscFreqRadioButton2.TabIndex = 5;
            this.oscFreqRadioButton2.TabStop = true;
            this.oscFreqRadioButton2.Tag = "3";
            this.oscFreqRadioButton2.Text = "2 кГц";
            this.oscFreqRadioButton2.UseVisualStyleBackColor = true;
            this.oscFreqRadioButton2.CheckedChanged += new System.EventHandler(this.oscFreqRadioButton1_CheckedChanged);
            // 
            // oscFreqRadioButton1
            // 
            this.oscFreqRadioButton1.AutoSize = true;
            this.oscFreqRadioButton1.Checked = true;
            this.oscFreqRadioButton1.Location = new System.Drawing.Point(6, 19);
            this.oscFreqRadioButton1.Name = "oscFreqRadioButton1";
            this.oscFreqRadioButton1.Size = new System.Drawing.Size(52, 17);
            this.oscFreqRadioButton1.TabIndex = 4;
            this.oscFreqRadioButton1.TabStop = true;
            this.oscFreqRadioButton1.Tag = "1";
            this.oscFreqRadioButton1.Text = "4 кГц";
            this.oscFreqRadioButton1.UseVisualStyleBackColor = true;
            this.oscFreqRadioButton1.CheckedChanged += new System.EventHandler(this.oscFreqRadioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chCountRadioButton6);
            this.groupBox2.Controls.Add(this.chCountRadioButton5);
            this.groupBox2.Controls.Add(this.chCountRadioButton4);
            this.groupBox2.Controls.Add(this.chCountRadioButton3);
            this.groupBox2.Controls.Add(this.chCountRadioButton2);
            this.groupBox2.Controls.Add(this.chCountRadioButton1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(231, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 89);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "1";
            this.groupBox2.Text = "Количество осциллограмм";
            // 
            // chCountRadioButton6
            // 
            this.chCountRadioButton6.AutoSize = true;
            this.chCountRadioButton6.Location = new System.Drawing.Point(174, 65);
            this.chCountRadioButton6.Name = "chCountRadioButton6";
            this.chCountRadioButton6.Size = new System.Drawing.Size(37, 17);
            this.chCountRadioButton6.TabIndex = 6;
            this.chCountRadioButton6.TabStop = true;
            this.chCountRadioButton6.Tag = "32";
            this.chCountRadioButton6.Text = "32";
            this.chCountRadioButton6.UseVisualStyleBackColor = true;
            this.chCountRadioButton6.CheckedChanged += new System.EventHandler(this.chCountRadioButton1_CheckedChanged);
            // 
            // chCountRadioButton5
            // 
            this.chCountRadioButton5.AutoSize = true;
            this.chCountRadioButton5.Location = new System.Drawing.Point(174, 42);
            this.chCountRadioButton5.Name = "chCountRadioButton5";
            this.chCountRadioButton5.Size = new System.Drawing.Size(37, 17);
            this.chCountRadioButton5.TabIndex = 5;
            this.chCountRadioButton5.TabStop = true;
            this.chCountRadioButton5.Tag = "16";
            this.chCountRadioButton5.Text = "16";
            this.chCountRadioButton5.UseVisualStyleBackColor = true;
            this.chCountRadioButton5.CheckedChanged += new System.EventHandler(this.chCountRadioButton1_CheckedChanged);
            // 
            // chCountRadioButton4
            // 
            this.chCountRadioButton4.AutoSize = true;
            this.chCountRadioButton4.Location = new System.Drawing.Point(174, 19);
            this.chCountRadioButton4.Name = "chCountRadioButton4";
            this.chCountRadioButton4.Size = new System.Drawing.Size(31, 17);
            this.chCountRadioButton4.TabIndex = 4;
            this.chCountRadioButton4.TabStop = true;
            this.chCountRadioButton4.Tag = "8";
            this.chCountRadioButton4.Text = "8";
            this.chCountRadioButton4.UseVisualStyleBackColor = true;
            this.chCountRadioButton4.CheckedChanged += new System.EventHandler(this.chCountRadioButton1_CheckedChanged);
            // 
            // chCountRadioButton3
            // 
            this.chCountRadioButton3.AutoSize = true;
            this.chCountRadioButton3.Location = new System.Drawing.Point(6, 65);
            this.chCountRadioButton3.Name = "chCountRadioButton3";
            this.chCountRadioButton3.Size = new System.Drawing.Size(31, 17);
            this.chCountRadioButton3.TabIndex = 3;
            this.chCountRadioButton3.TabStop = true;
            this.chCountRadioButton3.Tag = "4";
            this.chCountRadioButton3.Text = "4";
            this.chCountRadioButton3.UseVisualStyleBackColor = true;
            this.chCountRadioButton3.CheckedChanged += new System.EventHandler(this.chCountRadioButton1_CheckedChanged);
            // 
            // chCountRadioButton2
            // 
            this.chCountRadioButton2.AutoSize = true;
            this.chCountRadioButton2.Location = new System.Drawing.Point(6, 42);
            this.chCountRadioButton2.Name = "chCountRadioButton2";
            this.chCountRadioButton2.Size = new System.Drawing.Size(31, 17);
            this.chCountRadioButton2.TabIndex = 2;
            this.chCountRadioButton2.TabStop = true;
            this.chCountRadioButton2.Tag = "2";
            this.chCountRadioButton2.Text = "2";
            this.chCountRadioButton2.UseVisualStyleBackColor = true;
            this.chCountRadioButton2.CheckedChanged += new System.EventHandler(this.chCountRadioButton1_CheckedChanged);
            // 
            // chCountRadioButton1
            // 
            this.chCountRadioButton1.AutoSize = true;
            this.chCountRadioButton1.Checked = true;
            this.chCountRadioButton1.Location = new System.Drawing.Point(6, 19);
            this.chCountRadioButton1.Name = "chCountRadioButton1";
            this.chCountRadioButton1.Size = new System.Drawing.Size(31, 17);
            this.chCountRadioButton1.TabIndex = 1;
            this.chCountRadioButton1.TabStop = true;
            this.chCountRadioButton1.Tag = "1";
            this.chCountRadioButton1.Text = "1";
            this.chCountRadioButton1.UseVisualStyleBackColor = true;
            this.chCountRadioButton1.CheckedChanged += new System.EventHandler(this.chCountRadioButton1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Количество каналов осциллографа";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(7, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(82, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "16 каналов";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "8 каналов";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(70, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "4 канала";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // oscTimeLabel
            // 
            this.oscTimeLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.oscTimeLabel, 2);
            this.oscTimeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.oscTimeLabel.Location = new System.Drawing.Point(3, 95);
            this.oscTimeLabel.Name = "oscTimeLabel";
            this.oscTimeLabel.Size = new System.Drawing.Size(169, 26);
            this.oscTimeLabel.TabIndex = 4;
            this.oscTimeLabel.Text = "Длительность осциллограммы:";
            this.oscTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 150);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(917, 329);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.possibleParamPanel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 321);
            this.panel2.TabIndex = 2;
            // 
            // possibleParamPanel
            // 
            this.possibleParamPanel.AutoScroll = true;
            this.possibleParamPanel.Controls.Add(this.possibleTableLayoutPanel);
            this.possibleParamPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.possibleParamPanel.Location = new System.Drawing.Point(0, 27);
            this.possibleParamPanel.Name = "possibleParamPanel";
            this.possibleParamPanel.Size = new System.Drawing.Size(451, 294);
            this.possibleParamPanel.TabIndex = 5;
            // 
            // possibleTableLayoutPanel
            // 
            this.possibleTableLayoutPanel.AutoSize = true;
            this.possibleTableLayoutPanel.ColumnCount = 1;
            this.possibleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.possibleTableLayoutPanel.Controls.Add(this.sampleNameLabel, 0, 0);
            this.possibleTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.possibleTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.possibleTableLayoutPanel.Name = "possibleTableLayoutPanel";
            this.possibleTableLayoutPanel.RowCount = 1;
            this.possibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.possibleTableLayoutPanel.Size = new System.Drawing.Size(451, 30);
            this.possibleTableLayoutPanel.TabIndex = 7;
            // 
            // sampleNameLabel
            // 
            this.sampleNameLabel.AutoSize = true;
            this.sampleNameLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sampleNameLabel.Location = new System.Drawing.Point(0, 5);
            this.sampleNameLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.sampleNameLabel.Name = "sampleNameLabel";
            this.sampleNameLabel.Size = new System.Drawing.Size(50, 18);
            this.sampleNameLabel.TabIndex = 0;
            this.sampleNameLabel.Text = "label2";
            this.sampleNameLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(451, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Возможные для осциллографирования параметры";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.currentParamsPanel);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(462, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(451, 321);
            this.panel3.TabIndex = 3;
            // 
            // currentParamsPanel
            // 
            this.currentParamsPanel.AllowDrop = true;
            this.currentParamsPanel.AutoScroll = true;
            this.currentParamsPanel.Controls.Add(this.currentTableLayoutPanel);
            this.currentParamsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentParamsPanel.Location = new System.Drawing.Point(0, 27);
            this.currentParamsPanel.Name = "currentParamsPanel";
            this.currentParamsPanel.Size = new System.Drawing.Size(451, 294);
            this.currentParamsPanel.TabIndex = 15;
            // 
            // currentTableLayoutPanel
            // 
            this.currentTableLayoutPanel.AutoSize = true;
            this.currentTableLayoutPanel.ColumnCount = 1;
            this.currentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.currentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.currentTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.currentTableLayoutPanel.Name = "currentTableLayoutPanel";
            this.currentTableLayoutPanel.RowCount = 1;
            this.currentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.currentTableLayoutPanel.Size = new System.Drawing.Size(451, 30);
            this.currentTableLayoutPanel.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 27);
            this.label1.TabIndex = 14;
            this.label1.Text = "Каналы осциллографа";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScopeSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(917, 479);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ScopeSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка осциллографа";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.possibleParamPanel.ResumeLayout(false);
            this.possibleParamPanel.PerformLayout();
            this.possibleTableLayoutPanel.ResumeLayout(false);
            this.possibleTableLayoutPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.currentParamsPanel.ResumeLayout(false);
            this.currentParamsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton oscFreqRadioButton3;
        private System.Windows.Forms.RadioButton oscFreqRadioButton2;
        private System.Windows.Forms.RadioButton oscFreqRadioButton1;
        private System.Windows.Forms.RadioButton chCountRadioButton6;
        private System.Windows.Forms.RadioButton chCountRadioButton5;
        private System.Windows.Forms.RadioButton chCountRadioButton4;
        private System.Windows.Forms.RadioButton chCountRadioButton3;
        private System.Windows.Forms.RadioButton chCountRadioButton2;
        private System.Windows.Forms.RadioButton chCountRadioButton1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel possibleParamPanel;
        private System.Windows.Forms.TableLayoutPanel possibleTableLayoutPanel;
        private System.Windows.Forms.Label sampleNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel currentParamsPanel;
        private System.Windows.Forms.TableLayoutPanel currentTableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label oscTimeLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton hystoryRadioButton3;
        private System.Windows.Forms.RadioButton hystoryRadioButton2;
        private System.Windows.Forms.RadioButton hystoryRadioButton1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton reloadBtn;
        private System.Windows.Forms.ToolStripButton writeToSystemBtn;
        private System.Windows.Forms.CheckBox enaScopeCheckBox;

    }
}