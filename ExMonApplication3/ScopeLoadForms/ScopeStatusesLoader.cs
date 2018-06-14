using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UniSerialPort;
using System.ComponentModel;
using System.Drawing;

namespace ScopeLoadForms
{
    public class ScopeStatusesLoader
    {
        BackgroundWorker backgroundWorker;
        AsynchSerialPort serialPort;
        AutoResetEvent waitResponce = new AutoResetEvent(false);
        ScopeConfig scopeConfig;

        public delegate void LoadingCompleter(bool LoadingOk);
        public event LoadingCompleter OnLoadingComplete;

        int loadTimeStampStep = 0;

        ushort[] oscilsStatus = new ushort[33];

        public ushort[] OscilsStatus
        {
            get { return oscilsStatus; }
        }
        string[] oscilTitls = new string[33];

        public string[] OscilTitls
        {
            get { return oscilTitls; }
        }
        string[] oscTimeDates = new string[33];

        public string[] OscTimeDates
        {
            get { return oscTimeDates; }
        }

        string[] buttonsText = new string[33];

        public string[] ButtonsText
        {
            get { return buttonsText; }
            set { buttonsText = value; }
        }
        Color[] buttonsColor = new Color[33];

        public Color[] ButtonsColor
        {
            get { return buttonsColor; }
            set { buttonsColor = value; }
        }
        bool[] buttonsEnabled = new bool[33];

        public bool[] ButtonsEnabled
        {
            get { return buttonsEnabled; }
            set { buttonsEnabled = value; }
        }

        string oscillString = "Осциллограмма";
        string emptyString = "ПУСТО";
        string recordingString = "ИДЕТ ЗАПИСЬ";
        string hystoryString = "ЗАПИСЬ ПРЕДЫС-\nТОРИИ";
        string readyString = "ГОТОВА К ЗАПИСИ";


        public ScopeStatusesLoader(AsynchSerialPort AsynchSerialPort, ScopeConfig ScopeConfig)
        {
            serialPort = AsynchSerialPort;

            if (serialPort == null)
            {
                throw new Exception("Invalid serial port!");
            }

            if (!serialPort.IsOpen)
            {
                throw new Exception("Serial port not open!");
            }

            scopeConfig = ScopeConfig;
            StartLoading();
        }

        public void StartLoading()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            //backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync(null);
        }


        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            serialPort.GetDataRTU(ScopeSysType.OscilStatusAddr, 32, EndLoadStatuses);
            waitResponce.WaitOne();
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            for (int i = 0; i < scopeConfig.ScopeCount; i++)
            {
                if (oscilsStatus[i] >= 4)
                {
                    loadTimeStampStep = i;
                    serialPort.GetDataRTU((ushort)(ScopeSysType.TimeStampAddr + i * 8), 8, UpdateTimeStamp);
                    waitResponce.WaitOne();
                    if (backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            e.Result = true;
        }

        void UpdateTimeStamp(bool DataOk, ushort[] ParamRTU, object param)
        {
            if (!DataOk)
            {
                backgroundWorker.CancelAsync();
                waitResponce.Set();
                return;
            }

            string str, str2;
            str = (ParamRTU[5] & 0x3F).ToString("X2") + "/" + (ParamRTU[6] & 0x1F).ToString("X2") + "/20" + (ParamRTU[7] & 0xFF).ToString("X2");
            str2 = (ParamRTU[3] & 0x3F).ToString("X2") + ":" + (ParamRTU[2] & 0x7F).ToString("X2") + ":" + (ParamRTU[1] & 0x7F).ToString("X2") + "." + ParamRTU[4].ToString("D3");

            buttonsText[loadTimeStampStep] = (loadTimeStampStep + 1).ToString() + ".\n" + str + "\n" + str2;
            oscilTitls[loadTimeStampStep] = oscillString + " N" + (loadTimeStampStep + 1).ToString() + " " + str + " " + str2;
            oscTimeDates[loadTimeStampStep] = str + " " + str2;
            waitResponce.Set();
        }

        void EndLoadStatuses(bool DataOk, ushort[] ParamRTU, object param)
        {
            if (!DataOk)
            {
                backgroundWorker.CancelAsync();
                waitResponce.Set();
                return;
            }

            oscilsStatus = ParamRTU;
            for (int i = 0; i < scopeConfig.ScopeCount; i++)
            {
                if (oscilsStatus[i] == 0)
                {
                    oscilTitls[i] = oscillString +" N" + (i + 1).ToString() + ".";
                    buttonsText[i] = (i + 1).ToString() + ".\n"+emptyString;
                    buttonsColor[i] = Color.Gray;
                    buttonsEnabled[i] = false;
                }
                else if (oscilsStatus[i] >= 4)
                {
                    buttonsColor[i] = Color.Lime; 
                    buttonsEnabled[i] = true; 
                }


                else if (oscilsStatus[i] == 3)
                {
                    buttonsColor[i] = Color.LightBlue;
                    buttonsEnabled[i] = false;
                    oscilTitls[i] = oscillString + " N" + (i + 1).ToString() + ".";
                    buttonsText[i] = (i + 1).ToString() + ".\n" + recordingString;
                }

                else if (oscilsStatus[i] == 1)
                {
                    buttonsColor[i] = Color.Yellow;
                    buttonsEnabled[i] = false;
                    oscilTitls[i] = oscillString + " N" + (i + 1).ToString() + ".";
                    buttonsText[i] = (i + 1).ToString() + ".\n" + hystoryString;
                }

                else
                {
                    buttonsColor[i] = Color.Yellow;
                    buttonsEnabled[i] = true;
                    oscilTitls[i] = oscillString + " N" + (i + 1).ToString() + ".";
                    buttonsText[i] = (i + 1).ToString() + ".\n" + readyString + "\n";
                }
            }
            waitResponce.Set();
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (OnLoadingComplete != null) { OnLoadingComplete(!e.Cancelled); }
        }
    }
}
