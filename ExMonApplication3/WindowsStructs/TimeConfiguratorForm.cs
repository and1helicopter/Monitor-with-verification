using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormatsConvert;

namespace WindowsStructs
{
    public partial class TimeConfiguratorForm : Form
    {
        public TimeConfiguratorForm(TimeConfig TimeConfig)
        {
            InitializeComponent();
            if (TimeConfig.TimeFormat == TimeFormats.ADSPFormat)
            {
                radioButton1.Checked = true;
                stmPanel.Visible = false;
                textBox1.Text = "0x"+TimeConfig.ReadAddr.ToString("X4");
                textBox2.Text = "0x" + TimeConfig.AddrSetTime.ToString("X4");
                textBox3.Text = "0x" + TimeConfig.SetAddr.ToString("X4");
            }
            else if (TimeConfig.TimeFormat == TimeFormats.RTCFormat)
            {
                radioButton2.Checked = true;
                adspPanel.Visible = false;

                textBox2_1.Text = "0x" + TimeConfig.ReadAddr.ToString("X4");
                textBox2_2.Text = "0x" + TimeConfig.SetAddr.ToString("X4");
        
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            adspPanel.Visible = radioButton1.Checked;
            stmPanel.Visible = radioButton2.Checked;
        }



        public TimeConfig CalcTimeConfig()
        {
            TimeConfig timeConfig = new TimeConfig();

            if (radioButton1.Checked)
            {
                timeConfig.TimeFormat = TimeFormats.ADSPFormat;
            }
            else
            {
                timeConfig.TimeFormat = TimeFormats.RTCFormat;
            }

            if (timeConfig.TimeFormat == TimeFormats.ADSPFormat)
            {
                try
                {
                    timeConfig.ReadAddr = ConvertFuncs.UInt16ToWord(textBox1.Text);
                    timeConfig.AddrSetTime = ConvertFuncs.UInt16ToWord(textBox2.Text);
                    timeConfig.SetAddr = ConvertFuncs.UInt16ToWord(textBox3.Text);
                }
                catch
                {
                    throw new Exception("Error in addresses!");
                }

            }
            else if (timeConfig.TimeFormat == TimeFormats.RTCFormat)
            {
                try
                {

                    timeConfig.ReadAddr = ConvertFuncs.UInt16ToWord(textBox2_1.Text);
                    timeConfig.SetAddr = ConvertFuncs.UInt16ToWord(textBox2_2.Text);
                }
                catch
                {
                    throw new Exception("Error in addresses!");
                }

            }
            return timeConfig;




        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
