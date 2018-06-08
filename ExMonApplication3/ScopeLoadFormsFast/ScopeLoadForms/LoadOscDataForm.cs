using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using UniSerialPort;
using FormatsConvert;
using TextLibrary;
using System.Diagnostics;

namespace ScopeLoadForms
{
    public partial class LoadOscDataForm : Form
    {
        AsynchSerialPort serialPort;
        ScopeConfig scopeConfig { get; set; }
        int loadOscNum = 0;

        public LoadOscDataForm(AsynchSerialPort AsynchSerialPort, string Titl, ScopeConfig ScopeConfig, int LoadOscNum, AppTexts AppTexts)
        {
            InitializeComponent();
            serialPort = AsynchSerialPort;
            this.Text = Titl;
            this.scopeConfig = ScopeConfig;
            loadOscNum = LoadOscNum;
            InitLoadOscill();
            button1.Text = AppTexts.ParameterName(27);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            stopRequests = true;
            Close();
        }


        UInt16 loadOscilIndex = 0x0000;
        UInt16 loadOscilStart = 0x0000;
        UInt16 loadOscilCountRound = 0x0000;

        UInt32 CalcMemoryAddr(int nowLoadOscNum)
        {
            UInt16 u;
            u = (UInt16)(loadOscilIndex + loadOscilStart - scopeConfig.Hystory);
            UInt32 m;
            m = (UInt32)(524288 * nowLoadOscNum + 8 * u);
            m = (UInt32)(Math.Round((double)m / scopeConfig.ScopeCount));
            return m;
        }

        int loadOscDataStep = 0;            //0 - загрузка LoadOscilStart
                                            //1 - загрузка непосредственно тела

        List<ushort[]> downloadedData = new List<ushort[]>();

        private void InitLoadOscill()
        {
            loadOscDataStep = 0;
            loadOscilIndex = 0;
            downloadedData = new List<ushort[]>();
            loadOscilCountRound = (UInt16)(scopeConfig.ScopeCount * 8);
            LoadOscDataRequest();
        }

        void EndLoadStepOne(bool DataOk, ushort[] ParamRTU)
        {
            if (!DataOk)
            {
                this.Close();
                return;
            }

            loadOscilStart = ParamRTU[0];
            loadOscDataStep = 1;
            LoadOscDataRequest();
        }

        void EndLoadStepTwo(bool DataOk, ushort[] ParamRTU)
        {
            if (!DataOk)
            {
                this.Close();
                return;
            }

            loadOscDataStep = 2;
            LoadOscDataRequest();
        }

        void EndLoadStepThree(bool DataOk, ushort[] ParamRTU)
        {
            downloadedData.Add(new ushort[32]);
            ParamRTU.CopyTo(downloadedData[downloadedData.Count - 1], 0);

            loadOscilIndex = (UInt16)(loadOscilIndex + loadOscilCountRound);
            UpdateProgressBar(loadOscilIndex);
            if (loadOscilIndex != 0)
            {
                loadOscDataStep = 1;
                LoadOscDataRequest();
            }
            else
            {
                CreateFile();
            }
        }
        bool stopRequests = false;
        void LoadOscDataRequest()
        {
            if (stopRequests) { return; }
            if (!serialPort.IsOpen)
            {
                this.Close();
                return;
            }
            switch (loadOscDataStep)
            {
                //Загрузка стартового адреса
                case 0:
                    {
                        serialPort.GetDataRTU((ushort)(ScopeSysType.LoadOscilStartAddr + loadOscNum), 1, EndLoadStepOne,RequestPriority.High);
                    } break;

                //Загрузка данных
                case 1:
                    {

                            ushort[] writeArr = new ushort[6];
                            UInt32 m;
                            writeArr[0] = 0x0001;
                            writeArr[1] = ScopeSysType.ParamLoadDataAddr;
                            m = CalcMemoryAddr(loadOscNum);
                            writeArr[2] = (ushort)(m & 0x3FFF);
                            m = m & 0x003FC000;
                            m = m >> 6;
                            m = m & 0xFFFF;
                            m = m | 0x8001;
                            writeArr[3] = (ushort)m;
                            writeArr[4] = 32;
                            writeArr[5] = 1;
                            serialPort.SetDataRTU(ScopeSysType.ParamLoadConfigAddr, EndLoadStepTwo, RequestPriority.High, writeArr);
                            
                    } break;
                case 2:
                    {
                        serialPort.GetDataRTU(ScopeSysType.ParamLoadDataAddr, 32, EndLoadStepThree, RequestPriority.High);
                    }break;
            }
        }

        delegate void UpdateProgressBarHandler(int Value);
        public void UpdateProgressBar(int Value)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new UpdateProgressBarHandler(UpdateProgressBar), Value);
                }
                catch
                {

                }
            }
            else
            {
                progressBar1.Value = Value;
            }
        }

        private void LoadScopeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopRequests = true;
        }

        string FileHeaderLine()
        {
            string str = "";
            int i = 0;
            str = " " + "\t";
            for (i = 0; i < scopeConfig.ChannelCount; i++)
            {
                //Если параметр в списке известных, то пишем его в файл
                if (scopeConfig.OscillParams[i] < ScopeSysType.ChannelNames.Count)
                {
                    str = str + ScopeSysType.ChannelNames[scopeConfig.OscillParams[i]] + "\t";
                }
            }
            return str;
        }
        string FileColorLine()
        {
            string str = "";
            int i = 0;
            str = " " + "\t";
            for (i = 0; i < scopeConfig.ChannelCount; i++)
            {
                //Если параметр в списке известных, то пишем его в файл
                if (scopeConfig.OscillParams[i] < ScopeSysType.ChannelNames.Count)
                {
                    str = str + ScopeSysType.ChannelColors[scopeConfig.OscillParams[i]].ToArgb().ToString() + "\t";
                }
            }
            return str;
        }
        string FileOffsetLine()
        {
            string str = "";
            int i = 0;
            str = " " + "\t";
            for (i = 0; i < scopeConfig.ChannelCount; i++)
            {
                //Если параметр в списке известных, то пишем его в файл
                if (scopeConfig.OscillParams[i] < ScopeSysType.ChannelNames.Count)
                {
                    str = str + "0,00000" + "\t";
                }
            }
            return str;
        }
        string FileScaleLine()
        {
            string str = "";
            int i = 0;
            str = " " + "\t";
            for (i = 0; i < scopeConfig.ChannelCount; i++)
            {
                //Если параметр в списке известных, то пишем его в файл
                if (scopeConfig.OscillParams[i] < ScopeSysType.ChannelNames.Count)
                {
                    str = str + "1,00000" + "\t";
                }
            }
            return str;
        }

        string FileReserveLine()
        {
            string str = "";
            int i = 0;
            str = " " + "\t";
            for (i = 0; i < scopeConfig.ChannelCount; i++)
            {
                //Если параметр в списке известных, то пишем его в файл
                if (scopeConfig.OscillParams[i] < ScopeSysType.ChannelNames.Count)
                {
                    str = str + "0" + "\t";
                }
            }
            return str;
        }
        string FileStepLine()
        {
            string str = "";
            int i = 0;
            str = " " + "\t";
            for (i = 0; i < scopeConfig.ChannelCount; i++)
            {
                //Если параметр в списке известных, то пишем его в файл
                if (scopeConfig.OscillParams[i] < ScopeSysType.ChannelNames.Count)
                {
                    str = str + ScopeSysType.ChannelStepLines[scopeConfig.OscillParams[i]].ToString() + "\t";
                }
            }
            return str;
        }
        string FileParamLine(ushort[] paramLine, int lineNum)
        {
            string str = "";
            int i = 0;
            str = lineNum.ToString() + "\t";
            for (i = 0; i < scopeConfig.ChannelCount; i++)
            {
                //Если параметр в списке известных, то пишем его в файл
                if (scopeConfig.OscillParams[i] < ScopeSysType.ChannelNames.Count)
                {
                    string str2 = "0";
                    try
                    {
                        str2 = paramLine[i].ToFormat(ScopeSysType.ChannelFormats[i]).ToString("F5");
                    }
                    catch
                    {
                        str2 = "0";
                    }
                    str = str + str2 + "\t";
                }
            }
            return str;
        }
        List<ushort[]> InitParamsLines()
        {
            ushort countInLine = (ushort)Math.Round(32.0 / scopeConfig.ChannelCount);
            List<ushort[]> paramsLines = new List<ushort[]>();

            for (int i3 = 0; i3 < downloadedData.Count; i3++)
            {
                for (int i = 0; i < countInLine; i++)
                {
                    paramsLines.Add(new ushort[scopeConfig.ChannelCount]);
                    for (int i2 = 0; i2 < scopeConfig.ChannelCount; i2++)
                    {
                        paramsLines[paramsLines.Count - 1][i2] = downloadedData[i3][i * scopeConfig.ChannelCount + i2];
                    }
                }
            }
            return paramsLines;
        }

        delegate void NoParamDelegate();
        void CreateFile()
        {
            if (InvokeRequired)
            {
                Invoke(new NoParamDelegate(CreateFileBody));
            }
            else
            {
                CreateFileBody();
            }
        }
        void CreateFileBody()
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.DefaultExt = "txt";
            ofd.Filter = "Текстовый файл|*.txt";
            string str = this.Text;
            str = str.Replace("/", ".");
            str = str.Replace(":", ".");
            ofd.FileName = str;

            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) { this.Close(); return; }


            StreamWriter sw;
            try
            {
                sw = File.CreateText(ofd.FileName);
            }
            catch
            {
                MessageBox.Show("Ошибка при создании файла!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                sw.WriteLine(this.Text);//;oscTimeDates[createFileNum]);
                sw.WriteLine(scopeConfig.ScopeFreq.ToString());
                sw.WriteLine(FileHeaderLine());
                sw.WriteLine(FileColorLine());
                sw.WriteLine(FileOffsetLine());
                sw.WriteLine(FileScaleLine());
                sw.WriteLine(FileStepLine());

                sw.WriteLine(FileReserveLine());
                sw.WriteLine(FileReserveLine());
                sw.WriteLine(FileReserveLine());
                sw.WriteLine(FileReserveLine());

                List<ushort[]> lu = InitParamsLines();
                for (int i = 0; i < lu.Count; i++)
                {
                    sw.WriteLine(FileParamLine(lu[i], i));
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при записи в файл!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sw.Close();
            this.Close();
            ExecuteScopeView(ofd.FileName);
        }

        private void ExecuteScopeView(string FileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = (Path.GetDirectoryName(Application.ExecutablePath) + "/ScopeView.exe");
            proc.StartInfo.Arguments = "\"" + FileName + "\"";
            proc.Start();
        }


    }
}
