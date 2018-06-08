using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsStructs
{
    public partial class WarningSetupForm : Form
    {
        public WarningSetupForm(WarningParam WarningParam)
        {
            InitializeComponent();
            warningSetup1.SetWarningParam(WarningParam);
        }

        
        public WarningParam NewWarningParam { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            WarningParam newWarningParam;
            bool b = warningSetup1.GetWarningParam(out newWarningParam);
            if (b) 
            {
                NewWarningParam = newWarningParam;
                DialogResult = System.Windows.Forms.DialogResult.OK; 
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }
        
    }
}
