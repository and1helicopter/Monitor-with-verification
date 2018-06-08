using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextLibrary;

namespace ScopeLoadForms
{
    public partial class AskScopeForm : Form
    {
        public ScopeDialogResults ScopeDialogResult = ScopeDialogResults.Clear;

        public AskScopeForm(AppTexts AppTexts, string OscTitl, ushort OscStatus)
        {
            InitializeComponent();
            label1.Text = OscTitl;
            button1.Text = AppTexts.ParameterName(40);
            button1.Enabled = (OscStatus >= 4); 
            button2.Text = AppTexts.ParameterName(41);
            button3.Text = AppTexts.ParameterName(42);

        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScopeDialogResult = ScopeDialogResults.DownLoad;
            DialogResult = System.Windows.Forms.DialogResult.Yes;    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScopeDialogResult = ScopeDialogResults.Clear;
            DialogResult = System.Windows.Forms.DialogResult.Yes;    
        }




    }
}
