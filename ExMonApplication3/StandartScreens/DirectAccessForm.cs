using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniSerialPort;
using TextLibrary;
using FormatsConvert;

namespace StandartScreens
{
    public partial class DirectAccessForm : StandartScreenTemplateForm
    {
        AsynchSerialPort serialPort;
        AppTexts appTexts;

        ushort addr = 0;
        ushort value = 0;
        bool portBusy = false;

        public DirectAccessForm(AsynchSerialPort AsynchSerialPort, AppTexts AppTexts)
        {
            InitializeComponent();
            appTexts = AppTexts;
            serialPort = AsynchSerialPort;
            Text = appTexts.ParameterName(45);
            writeBtn.Text = appTexts.ParameterName(9);
            readBtn.Text = appTexts.ParameterName(8);
            addrLabel.Text = appTexts.ParameterName(5);
            valueHexLabel.Text = appTexts.ParameterName(46);
            i160ValueLabel.Text = appTexts.ParameterName(48);
            u160ValueLabel.Text = appTexts.ParameterName(47);

            formatComboBox.Items.Clear();
            
            for (int i = 0; i < (int)ConvertFormats.FormatCount; i++)
            {
                formatComboBox.Items.Add(((ConvertFormats)i).ToString());
            }

            formatComboBox.SelectedIndex = 0;
        }

        bool CheckAddr()
        {
            try
            {
                addr = (ushort)ConvertFuncs.StrToShort(textBox1.Text);
            }
            catch
            {
                return false;
            }
            if (addr > 0x3FFF) { return (false); }
            return (true);
        }
        bool CheckValue()
        {
            try
            {
                value = (ushort)ConvertFuncs.StrToShort(textBox2.Text);
            }
            catch
            {
                return false;
            }
            return (true);
        }
        void SetValues()
        {
            if (CheckValue())
            {
                textBox4.Text = value.ToFormat(ConvertFormats.Int16).ToString("F0");
                textBox3.Text = value.ToFormat(ConvertFormats.Uint16).ToString("F0");
                textBox5.Text = value.ToFormatStr((ConvertFormats)(formatComboBox.SelectedIndex));
            }

            /*
            switch (formatComboBox.SelectedIndex)
            {
                case 0: { textBox5.Text = AdvanceConvert.HexToFormat(value, ConvertFormats.Percent); } break;
                case 1: { textBox5.Text = AdvanceConvert.HexToFormat(value, ConvertFormats.Format8_8); } break;
                case 2: { textBox5.Text = AdvanceConvert.HexToFormat(value, ConvertFormats.Format0_16); } break;
                case 3: { textBox5.Text = AdvanceConvert.HexToFormat(value, ConvertFormats.Hex); } break;
            }
             */
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SetValues();
        }
        private void formatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValues();
        }


        //***************************ЗАПИСЬ ДАННЫХ****************************************************************//
        //********************************************************************************************************//
        private void writeBtn_Click(object sender, EventArgs e)
        {
            if (portBusy)
            {
                return;
            }
            

            if (!CheckAddr())
            {
                MessageBox.Show(appTexts.ParameterName(10), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CheckValue())
            {
                MessageBox.Show(appTexts.ParameterName(49), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            portBusy = true;
            serialPort.SetDataRTU(addr, WriteDataRecieved, RequestPriority.Normal, value); 
        }
        private void WriteDataRecieved(bool DataOk, ushort[] ParamRTU, object param)
        {
            if (InvokeRequired)
            {
                Invoke(new AsynchSerialPort.DataRecievedRTU(WriteDataRecieved), DataOk, ParamRTU, null);
            }
            else
            {
                if (DataOk)
                {
                    toolStripStatusLabel1.Visible = true;
                    toolStripStatusLabel1.Text = appTexts.ParameterName(50);
                }
                else
                {
                    toolStripStatusLabel1.Visible = true;
                    toolStripStatusLabel1.Text = appTexts.ParameterName(51);
                }
                portBusy = false;
            }
        }

        //***************************ЧТЕНИЕ ДАННЫХ****************************************************************//
        //********************************************************************************************************//
        private void readBtn_Click(object sender, EventArgs e)
        {
            if (portBusy)
            {
                return;
            }

            if (!CheckAddr())
            {
                MessageBox.Show(appTexts.ParameterName(10), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            portBusy = true;
            serialPort.GetDataRTU(addr, 1, ReadDataRecieved);
        }
        private void ReadDataRecieved(bool DataOk, ushort[] ParamRTU, object param)
        {
            if (InvokeRequired)
            {
                Invoke(new AsynchSerialPort.DataRecievedRTU(ReadDataRecieved), DataOk, ParamRTU, null);
            }
            else
            {
                if (DataOk)
                {
                    toolStripStatusLabel1.Visible = true;
                    toolStripStatusLabel1.Text = appTexts.ParameterName(52);
                    textBox2.Text = "0x"+ParamRTU[0].ToString("X4");
                }
                else
                {
                    toolStripStatusLabel1.Visible = true;
                    toolStripStatusLabel1.Text = appTexts.ParameterName(53);
                }
                portBusy = false;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13) { return; }
            readBtn_Click(sender, e);
        }


    }
}
