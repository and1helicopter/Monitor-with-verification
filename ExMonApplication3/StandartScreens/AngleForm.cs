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
    public partial class AngleForm : StandartScreenTemplateForm
    {
        AsynchSerialPort serialPort;
        AppTexts appTexts;

        ushort[] addr2 = new ushort[]{ 0 };
        ushort addr =  0;
        bool portBusy = false;

        public AngleForm(AsynchSerialPort AsynchSerialPort, AppTexts AppTexts)
        {
            //toolStripStatusLabel1.Text = "";
            InitializeComponent();
            appTexts = AppTexts;
            serialPort = AsynchSerialPort;
            Text = appTexts.ParameterName(120);
            writeBtn1.Text = appTexts.ParameterName(117);
            curLabel.Text = appTexts.ParameterName(115);
            newLabel.Text = appTexts.ParameterName(116);
            paramLabel1.Text = appTexts.ParameterName(121);
            



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

      
       


        //***************************ЗАПИСЬ ДАННЫХ****************************************************************//
        //********************************************************************************************************//
        private void writeBtn1_Click(object sender, EventArgs e)
        {
//            if (portBusy)   return;
          
            double f;
            if (!double.TryParse(textBox1.Text, out f))
            {
                MessageBox.Show("Неправильно задан параметр!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((f > 10) || (f < 5))
            {
                MessageBox.Show("Неправильно задан параметр!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ushort[] w = new ushort[1] { (ushort)(f * 40.96) };
            
 //           portBusy = true;
            serialPort.SetDataRTU(0x05A6, WriteDataRecieved, RequestPriority.Normal, w); 
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
                //portBusy = false;
            }
        }

        
        //***************************ЧТЕНИЕ ДАННЫХ****************************************************************//
        //********************************************************************************************************//
        
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
                    
                    
                    textBox3.Text = ParamRTU[0].ToPercent().ToString("F0");
                    
                    
                }
                else
                {
                    toolStripStatusLabel1.Visible = true;
                    toolStripStatusLabel1.Text = appTexts.ParameterName(53);
                }
                portBusy = false;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.Visible) { return; }
            if (portBusy)
            {
                return;
            }

            serialPort.GetDataRTU(0x05A6, 1, ReadDataRecieved);  
            
            portBusy = true;
        }

       
    }
}
