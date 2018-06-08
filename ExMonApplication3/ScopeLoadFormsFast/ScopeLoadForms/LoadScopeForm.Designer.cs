namespace ScopeLoadForms
{
    partial class LoadScopeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadScopeForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.setupButton = new System.Windows.Forms.ToolStripButton();
            this.recordButton = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupButton,
            this.recordButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(484, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // setupButton
            // 
            this.setupButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.setupButton.Image = global::ScopeLoadForms.Properties.Resources.advancedsettings_3297;
            this.setupButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(23, 22);
            this.setupButton.Text = "toolStripButton1";
            this.setupButton.Click += new System.EventHandler(this.setupButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.recordButton.Image = global::ScopeLoadForms.Properties.Resources.recordpressed_2883;
            this.recordButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(23, 22);
            this.recordButton.Text = "toolStripButton1";
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(484, 373);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // LoadScopeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 398);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(500, 120);
            this.Name = "LoadScopeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadScopeForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadScopeForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ToolStripButton setupButton;
        private System.Windows.Forms.ToolStripButton recordButton;
    }
}