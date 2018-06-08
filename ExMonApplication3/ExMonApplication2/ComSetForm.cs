using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniSerialPort;
using System.IO.Ports;

namespace ExMonApplication2
{
    public partial class ComSetForm : Form
    {
        AsynchSerialPort serialPort;
        void ErrorMessage(string Titl)
        {
            MessageBox.Show(Titl, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 0 - Нет доступных портов на компе
        /// 1 - Не выбран сом-порт
        /// 2 - 
        /// </summary>
        List<string> texts = new List<string>();
        
        public ComSetForm(AsynchSerialPort AsynchSerialPort, List<string> Texts)
        {
            InitializeComponent();
            serialPort = AsynchSerialPort;
            texts = Texts;

            //foreach (string portName in SerialPort.GetPortNames())
            //{
            //    portsComboBox.Items.Add(portName.ToString());
            //}
            string[] portNames = SerialPort.GetPortNames();
            portsComboBox.Items.Clear();
            portsComboBox.Items.AddRange(portNames);

            if (portsComboBox.Items.Count != 0)
            {
                portsComboBox.SelectedIndex = 0;
                for (int i = 0; i < portsComboBox.Items.Count; i++)
                {
                    string str = portsComboBox.Items[i].ToString();
                    if (str == serialPort.PortName)
                    {
                        portsComboBox.SelectedIndex = i;
                    }
                }
            }

            for (int i = 1; i < 256; i++)
            {
                addrsComboBox.Items.Add(i.ToString());
            }
            addrsComboBox.SelectedIndex = serialPort.SlaveAddr - 1;

            speedComboBox.SelectedIndex = 0;
            for (int i = 0; i < speedComboBox.Items.Count; i++)
            {
                string str = speedComboBox.Items[i].ToString();
                if (str == serialPort.BaudRate.ToString())
                {
                    speedComboBox.SelectedIndex = i;
                }
            }

            if ((serialPort.Parity == Parity.Even) && (serialPort.StopBits == StopBits.One))
            {
                parityComboBox.SelectedIndex = 1;
            }
            else if ((serialPort.Parity == Parity.None) && (serialPort.StopBits == StopBits.Two))
            {
                parityComboBox.SelectedIndex = 2;
            }
            else
            {
                parityComboBox.SelectedIndex = 0;
            }

            ipTextBox.Text = serialPort.IpAddress;
            portNumTextBox.Text = serialPort.PortNum.ToString();
            if (serialPort.SerialPortMode == SerialPortModes.RSMode)
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ushort u;
            try
            {
                u = (ushort)FormatsConvert.ConvertFuncs.StrToShort(portNumTextBox.Text);
            }
            catch
            {
                portNumTextBox.BackColor = Color.Red;
                return;
            }

            serialPort.PortNum = u;

            serialPort.IpAddress = ipTextBox.Text;

            if (radioButton1.Checked)
            {
                serialPort.SerialPortMode = SerialPortModes.TCPMode;
            }
            else
            {
                serialPort.SerialPortMode = SerialPortModes.RSMode;
            }
            
            
            bool rsPresent = ((portsComboBox.Items.Count != 0) & (portsComboBox.SelectedIndex >= 0));
            if ((portsComboBox.Items.Count == 0)&&(radioButton2.Checked))
            {
                ErrorMessage(texts[0]+"!!!");
                return;
            }


            if ((portsComboBox.SelectedIndex < 0) && (radioButton2.Checked))
            {
                ErrorMessage(texts[1]);
                return;
            }

            if (rsPresent)
            serialPort.PortName = portsComboBox.Items[portsComboBox.SelectedIndex].ToString();
            
            serialPort.SlaveAddr = (byte)(addrsComboBox.SelectedIndex + 1);
            int speed = 9600;
            if (!int.TryParse(speedComboBox.Items[speedComboBox.SelectedIndex].ToString(), out speed)) { return; }
            serialPort.BaudRate = speed;
            switch (parityComboBox.SelectedIndex)
            {
                case 0:
                    {
                        serialPort.Parity = Parity.Odd;
                        serialPort.StopBits = StopBits.One;

                    } break;
                case 1:
                    {
                        serialPort.Parity = Parity.Even;
                        serialPort.StopBits = StopBits.One;

                    } break;
                case 2:
                    {
                        serialPort.Parity = Parity.None;
                        serialPort.StopBits = StopBits.Two;
                    } break;
            }
            DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            try
            {
                serialPort.SaveSettingsToFile("Comset.xml");

            }
            catch
            {
                ErrorMessage(texts[11]);
            }


        }

        private void portNumTextBox_TextChanged(object sender, EventArgs e)
        {
            portNumTextBox.BackColor = Color.White;
        }
    }
}
