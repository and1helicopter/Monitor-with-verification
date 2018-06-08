using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormatsConvert;

namespace GUIElements
{
    public partial class MeasureParamPanel : UserControl
    {
        ushort addr = 0;
        public ushort Addr
        {
            get { return addr; }
            set 
            { 
                addr = value;
                textBox2.Text = "0x" + addr.ToString("X4");            
            }
        }

        bool addrCorrect = true;

        public bool AddrCorrect
        {
            get { return addrCorrect; }
        }

        public string ParameterName
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }

        }
       
        public ConvertFormats Format
        {
            get
            {
                return (ConvertFormats)(comboBox1.SelectedIndex);
            }
            set
            {
                comboBox1.SelectedIndex = (int)value;
            }
        }

        public MeasureParamPanel()
        {
            InitializeComponent();

            for (int i=0;i<(int)ConvertFormats.FormatCount;i++)
            {
                comboBox1.Items.Add(((ConvertFormats)i).ToString());
            }
            comboBox1.SelectedIndex = 0;
            Addr = 0;
            Format = ConvertFormats.Percent;
        }

        public event EventHandler RemoveClick;
        private void button1_Click(object sender, EventArgs e)
        {
            if (RemoveClick != null) { RemoveClick(this, e); }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ushort u = addr;
            try
            {
                u = (ushort)ConvertFuncs.StrToShort(textBox2.Text);
                textBox2.BackColor = Color.White;
                addrCorrect = true;
            }
            catch
            {
                textBox2.BackColor = Color.Red;
                addrCorrect = false;
                u = 0;
            }

            addr = u;
        }
    }
}
