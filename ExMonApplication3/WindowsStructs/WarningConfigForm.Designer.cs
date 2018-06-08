namespace WindowsStructs
{
    partial class WarningConfigForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.warningSelect21 = new WindowsStructs.WarningSelect2();
            this.loadOldStyleButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadOldStyleButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(408, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // warningSelect21
            // 
            this.warningSelect21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warningSelect21.Icon = null;
            this.warningSelect21.Location = new System.Drawing.Point(0, 25);
            this.warningSelect21.Name = "warningSelect21";
            this.warningSelect21.Size = new System.Drawing.Size(408, 547);
            this.warningSelect21.TabIndex = 1;
            this.warningSelect21.Titl = null;
            // 
            // loadOldStyleButton
            // 
            this.loadOldStyleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadOldStyleButton.Image = global::WindowsStructs.Properties.Resources.folder_blue_open_1278;
            this.loadOldStyleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadOldStyleButton.Name = "loadOldStyleButton";
            this.loadOldStyleButton.Size = new System.Drawing.Size(23, 22);
            this.loadOldStyleButton.Text = "toolStripButton1";
            this.loadOldStyleButton.Click += new System.EventHandler(this.loadOldStyleButton_Click);
            // 
            // WarningConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 572);
            this.Controls.Add(this.warningSelect21);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WarningConfigForm";
            this.Text = "WarningConfigForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private WarningSelect2 warningSelect21;
        private System.Windows.Forms.ToolStripButton loadOldStyleButton;



    }
}