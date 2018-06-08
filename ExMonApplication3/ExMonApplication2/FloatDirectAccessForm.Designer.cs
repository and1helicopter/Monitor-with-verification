namespace ExMonApplication2
{
    partial class FloatDirectAccessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloatDirectAccessForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addrTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.longTextBox = new System.Windows.Forms.TextBox();
            this.floatTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.readButton = new System.Windows.Forms.Button();
            this.writeBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.addrTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.longTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.floatTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.readButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.writeBtn, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(206, 183);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // addrTextBox
            // 
            this.addrTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addrTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addrTextBox.Location = new System.Drawing.Point(106, 10);
            this.addrTextBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.addrTextBox.Name = "addrTextBox";
            this.addrTextBox.Size = new System.Drawing.Size(97, 25);
            this.addrTextBox.TabIndex = 0;
            this.addrTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.addrTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addrTextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 45);
            this.label1.TabIndex = 4;
            this.label1.Text = "Адрес";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 45);
            this.label3.TabIndex = 3;
            this.label3.Text = "Значение long";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // longTextBox
            // 
            this.longTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.longTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.longTextBox.Location = new System.Drawing.Point(106, 100);
            this.longTextBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.longTextBox.Name = "longTextBox";
            this.longTextBox.Size = new System.Drawing.Size(97, 25);
            this.longTextBox.TabIndex = 2;
            this.longTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.longTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // floatTextBox
            // 
            this.floatTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floatTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.floatTextBox.Location = new System.Drawing.Point(106, 55);
            this.floatTextBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.floatTextBox.Name = "floatTextBox";
            this.floatTextBox.Size = new System.Drawing.Size(97, 25);
            this.floatTextBox.TabIndex = 1;
            this.floatTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.floatTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "Значение float";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // readButton
            // 
            this.readButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readButton.Location = new System.Drawing.Point(3, 143);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(97, 39);
            this.readButton.TabIndex = 3;
            this.readButton.Text = "button1";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // writeBtn
            // 
            this.writeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.writeBtn.Location = new System.Drawing.Point(106, 143);
            this.writeBtn.Name = "writeBtn";
            this.writeBtn.Size = new System.Drawing.Size(97, 39);
            this.writeBtn.TabIndex = 7;
            this.writeBtn.Text = "button2";
            this.writeBtn.UseVisualStyleBackColor = true;
            this.writeBtn.Click += new System.EventHandler(this.writeBtn_Click);
            // 
            // FloatDirectAccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 183);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FloatDirectAccessForm";
            this.Text = "FloatDirectAccessForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FloatDirectAccessForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox longTextBox;
        private System.Windows.Forms.TextBox floatTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addrTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button writeBtn;
    }
}