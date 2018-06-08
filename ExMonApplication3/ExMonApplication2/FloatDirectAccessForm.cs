using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormatsConvert;
using UniSerialPort;

namespace ExMonApplication2
{
    public partial class FloatDirectAccessForm : Form
    {
        AsynchSerialPort serialPort;

        /// <summary>
        /// 0 - заголовок
        /// 1 - address
        /// 2 - float
        /// 3 - long
        /// 4 - read
        /// 5 - write
        /// 6 - Неправильно задан адрес
        /// 7 - адрес длжен быть четным
        /// 8 - ошибка чтения данных
        /// 9 - Неправильно задано значение long
        /// 10- Ошибка записи данных
        /// </summary>
        List<string> texts = new List<string>();

        void ErrorMessage(string Titl)
        {
            MessageBox.Show(Titl, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public FloatDirectAccessForm(AsynchSerialPort AsynchSerialPort, List<string> Texts)
        {
            InitializeComponent();
            serialPort = AsynchSerialPort;
            texts = Texts;
            Text = texts[0];
            label1.Text = texts[1];
            label2.Text = texts[2];
            label3.Text = texts[3];
            readButton.Text = texts[4];
            writeBtn.Text = texts[5];
        }

        bool nowReading = false;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if ((!longTextBox.Focused)||nowReading) { return; }
            try
            {
                ulong u = ConvertFuncs.StrToULong(longTextBox.Text);
                FloatStruct fs = new FloatStruct();
                fs.ULong = u;
                floatTextBox.Text = fs.Float.ToString();
            }
            catch
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((!floatTextBox.Focused)||nowReading) { return; }
            float f = 0;
            if (float.TryParse(floatTextBox.Text, out f))
            {
                FloatStruct fs = new FloatStruct();
                fs.Float = f;
                longTextBox.Text = "0x"+fs.ULong.ToString("X8");
            }

        }

        private void SendReadRequest(ushort Addr)
        {
            serialPort.GetDataRTU(Addr, 2, ReadDataRecieved);
        }

        private void ReadDataRecieved(bool DataOk, ushort[] ParamRTU)
        {
            if (InvokeRequired)
            {
                Invoke(new AsynchSerialPort.DataRecievedRTU(ReadDataRecieved), DataOk, ParamRTU);
            }
            else
            {
                try
                {
                    if (!DataOk)
                    {
                        ErrorMessage(texts[8]);
                    }
                    else
                    {
                        FloatStruct f = new FloatStruct();
                        f.Word1 = ParamRTU[0];
                        f.Word2 = ParamRTU[1];
                        nowReading = true;
                        floatTextBox.Text = f.Float.ToString();
                        longTextBox.Text = "0x" + f.ULong.ToString("X8");
                        nowReading = false;
                    }
                }
                catch
                {

                }
            }
        }

        private void WriteDataRecieved(bool DataOk, ushort[] ParamRTU)
        {
            if (InvokeRequired)
            {
                Invoke(new AsynchSerialPort.DataRecievedRTU(WriteDataRecieved), DataOk, ParamRTU);
            }
            else
            {
                try
                {
                    if (!DataOk)
                    {
                        ErrorMessage(texts[10]);
                    }
                }
                catch
                {

                }
            }
        }

        private bool CheckAddr(out ushort Addr)
        {
            Addr = 0;
            try
            {
                Addr = (ushort)ConvertFuncs.StrToShort(addrTextBox.Text);
            }
            catch
            {
                MessageBox.Show(texts[6],"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            if (Addr > 0x3FFF)
            {
                MessageBox.Show(texts[6], "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ConvertFuncs.GetBit(Addr,0))
            {
                MessageBox.Show(texts[7], "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            ushort Addr = 0;
            if (CheckAddr(out Addr))
            {
                SendReadRequest(Addr);
            }

        }

        private void addrTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().ToUpper() == "RETURN")
            {
                readButton_Click(null, null);
            }

           
        }

        private void writeBtn_Click(object sender, EventArgs e)
        {
            ushort w1 = 0;
            ushort w2 = 0;

            try
            {
                ulong u = ConvertFuncs.StrToULong(longTextBox.Text);
                FloatStruct fs = new FloatStruct();
                fs.ULong = u;
                w1 = fs.Word1;
                w2 = fs.Word2;
            }
            catch
            {
                ErrorMessage(texts[9]);
                return;
            }

            ushort Addr = 0;
            if (!CheckAddr(out Addr))
            {
                ErrorMessage(texts[6]);
                return;
            }

            serialPort.SetDataRTU(Addr, WriteDataRecieved, RequestPriority.Normal, w1, w2);
        }

        private void FloatDirectAccessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }



    }
}
