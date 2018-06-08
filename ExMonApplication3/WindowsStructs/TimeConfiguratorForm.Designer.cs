namespace WindowsStructs
{
    partial class TimeConfiguratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeConfiguratorForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.adspPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.stmPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2_8 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2_7 = new System.Windows.Forms.TextBox();
            this.textBox2_6 = new System.Windows.Forms.TextBox();
            this.textBox2_5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2_4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2_3 = new System.Windows.Forms.TextBox();
            this.textBox2_2 = new System.Windows.Forms.TextBox();
            this.textBox2_1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.adspPanel.SuspendLayout();
            this.stmPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioButton1);
            this.flowLayoutPanel1.Controls.Add(this.radioButton2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(781, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(103, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "ADSP processor";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(112, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(88, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "stmProcessor";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // adspPanel
            // 
            this.adspPanel.Controls.Add(this.label3);
            this.adspPanel.Controls.Add(this.label2);
            this.adspPanel.Controls.Add(this.label1);
            this.adspPanel.Controls.Add(this.textBox3);
            this.adspPanel.Controls.Add(this.textBox2);
            this.adspPanel.Controls.Add(this.textBox1);
            this.adspPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.adspPanel.Location = new System.Drawing.Point(0, 27);
            this.adspPanel.Name = "adspPanel";
            this.adspPanel.Size = new System.Drawing.Size(781, 104);
            this.adspPanel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Address set data";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Set Time Address";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Read time address";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(155, 68);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(155, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // stmPanel
            // 
            this.stmPanel.Controls.Add(this.label8);
            this.stmPanel.Controls.Add(this.textBox2_8);
            this.stmPanel.Controls.Add(this.label9);
            this.stmPanel.Controls.Add(this.label10);
            this.stmPanel.Controls.Add(this.label11);
            this.stmPanel.Controls.Add(this.textBox2_7);
            this.stmPanel.Controls.Add(this.textBox2_6);
            this.stmPanel.Controls.Add(this.textBox2_5);
            this.stmPanel.Controls.Add(this.label7);
            this.stmPanel.Controls.Add(this.textBox2_4);
            this.stmPanel.Controls.Add(this.label4);
            this.stmPanel.Controls.Add(this.label5);
            this.stmPanel.Controls.Add(this.label6);
            this.stmPanel.Controls.Add(this.textBox2_3);
            this.stmPanel.Controls.Add(this.textBox2_2);
            this.stmPanel.Controls.Add(this.textBox2_1);
            this.stmPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.stmPanel.Location = new System.Drawing.Point(0, 131);
            this.stmPanel.Name = "stmPanel";
            this.stmPanel.Size = new System.Drawing.Size(781, 133);
            this.stmPanel.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(312, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Address set data";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Visible = false;
            // 
            // textBox2_8
            // 
            this.textBox2_8.Location = new System.Drawing.Point(456, 93);
            this.textBox2_8.Name = "textBox2_8";
            this.textBox2_8.Size = new System.Drawing.Size(100, 20);
            this.textBox2_8.TabIndex = 14;
            this.textBox2_8.Visible = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(312, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Address set data";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(312, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Set Time Address";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(312, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "Read time address";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Visible = false;
            // 
            // textBox2_7
            // 
            this.textBox2_7.Location = new System.Drawing.Point(456, 67);
            this.textBox2_7.Name = "textBox2_7";
            this.textBox2_7.Size = new System.Drawing.Size(100, 20);
            this.textBox2_7.TabIndex = 10;
            this.textBox2_7.Visible = false;
            // 
            // textBox2_6
            // 
            this.textBox2_6.Location = new System.Drawing.Point(456, 41);
            this.textBox2_6.Name = "textBox2_6";
            this.textBox2_6.Size = new System.Drawing.Size(100, 20);
            this.textBox2_6.TabIndex = 9;
            this.textBox2_6.Visible = false;
            // 
            // textBox2_5
            // 
            this.textBox2_5.Location = new System.Drawing.Point(456, 15);
            this.textBox2_5.Name = "textBox2_5";
            this.textBox2_5.Size = new System.Drawing.Size(100, 20);
            this.textBox2_5.TabIndex = 8;
            this.textBox2_5.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Address set data";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Visible = false;
            // 
            // textBox2_4
            // 
            this.textBox2_4.Location = new System.Drawing.Point(155, 94);
            this.textBox2_4.Name = "textBox2_4";
            this.textBox2_4.Size = new System.Drawing.Size(100, 20);
            this.textBox2_4.TabIndex = 6;
            this.textBox2_4.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Address set data";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Set Time Address";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Read time address";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2_3
            // 
            this.textBox2_3.Location = new System.Drawing.Point(155, 68);
            this.textBox2_3.Name = "textBox2_3";
            this.textBox2_3.Size = new System.Drawing.Size(100, 20);
            this.textBox2_3.TabIndex = 2;
            this.textBox2_3.Visible = false;
            // 
            // textBox2_2
            // 
            this.textBox2_2.Location = new System.Drawing.Point(155, 42);
            this.textBox2_2.Name = "textBox2_2";
            this.textBox2_2.Size = new System.Drawing.Size(100, 20);
            this.textBox2_2.TabIndex = 1;
            // 
            // textBox2_1
            // 
            this.textBox2_1.Location = new System.Drawing.Point(155, 16);
            this.textBox2_1.Name = "textBox2_1";
            this.textBox2_1.Size = new System.Drawing.Size(100, 20);
            this.textBox2_1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 276);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(781, 69);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Image = global::WindowsStructs.Properties.Resources.ok_4020;
            this.button1.Location = new System.Drawing.Point(133, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 56);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Image = global::WindowsStructs.Properties.Resources.button_cancel_1986;
            this.button2.Location = new System.Drawing.Point(458, 3);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 56);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TimeConfiguratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(781, 345);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.stmPanel);
            this.Controls.Add(this.adspPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimeConfiguratorForm";
            this.Text = "TimeConfigurator";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.adspPanel.ResumeLayout(false);
            this.adspPanel.PerformLayout();
            this.stmPanel.ResumeLayout(false);
            this.stmPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel adspPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel stmPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2_8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2_7;
        private System.Windows.Forms.TextBox textBox2_6;
        private System.Windows.Forms.TextBox textBox2_5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2_4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2_3;
        private System.Windows.Forms.TextBox textBox2_2;
        private System.Windows.Forms.TextBox textBox2_1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}