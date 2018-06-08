using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormatsConvert;

namespace WindowsStructs
{
    public partial class WarningSetup : UserControl
    {
        TextBox[] textBoxs = new TextBox[16];
        public WarningSetup()
        {
            InitializeComponent();
            for (int i = 0; i < 16; i++)
            {
                textBoxs[i] = new TextBox();
                textBoxs[i].Dock = DockStyle.Fill;
                tableLayoutPanel2.Controls.Add(textBoxs[i]);
                tableLayoutPanel2.SetRow(textBoxs[i], i);
                tableLayoutPanel2.SetColumn(textBoxs[i], 0);
            }
        }
        public void SetWarningParam(WarningParam WarningParam)
        {
            textBox1.Text = WarningParam.Titl;
            textBox2.Text = "0x" + WarningParam.EventPosAddr.ToString("X4");

            for (int i = 0; i < 16; i++)
            {
                textBoxs[i].Text = WarningParam.Names[i];
            }
        }
        public bool GetWarningParam(out WarningParam WarningParam)
        {
            WarningParam warningParam = new WarningParam(textBox1.Text);
            try
            {
                short u = ConvertFuncs.StrToShort(textBox2.Text);
                warningParam.EventPosAddr = (ushort)u;
            }
            catch
            {
                WarningParam = warningParam;
                return false;
            }

            for (int i = 0; i < 16; i++)
            {
                warningParam.Names[i] = textBoxs[i].Text;
            }
            WarningParam = warningParam;
            return true;
        }

    }
}
