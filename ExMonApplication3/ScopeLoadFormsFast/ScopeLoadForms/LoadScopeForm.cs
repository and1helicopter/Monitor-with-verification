using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextLibrary;
using UniSerialPort;

namespace ScopeLoadForms
{
    public partial class LoadScopeForm : Form
    {
        AsynchSerialPort serialPort;
        AppTexts Texts;
        List<Button> statusButtons = new List<Button>();
        bool buttonsAlreadyCreated = false;


        ScopeConfig scopeConfig = new ScopeConfig();
        bool configLoaded = false;


        ushort[] oscilsStatus = new ushort[33];
        string[] oscilTitls = new string[33];
        string[] oscTimeDates = new string[33];
        int loadTimeStampStep = 0;
        bool nowLoadTimeStamps = false;
       


        public LoadScopeForm(AppTexts AppTexts, AsynchSerialPort AsynchSerialPort)
        {
            InitializeComponent();
            serialPort = AsynchSerialPort;
            Texts = AppTexts;
            Text = AppTexts.ParameterName(39);
            setupButton.ToolTipText = AppTexts.ParameterName(43);
            recordButton.ToolTipText = AppTexts.ParameterName(44);
        }

        public new void Show()
        {
            RemoveButtons();
            try
            {
                ScopeSysType.InitScopeSysType();
            }
            catch
            {
                Hide();
                return;
            }
            configLoaded = false;
            nowLoadTimeStamps = false;

            LoadConfigStepOne();
            base.Show();
        }
        private void LoadScopeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }


        
        //*********************** СОЗДАНИЕ КНОПОК ВЫБОРА ОСЦИЛЛОГРАММЫ *******************************************//
        //********************************************************************************************************//
        delegate void CreateStatusButtonsHandler(int Count);
        public void InitButtons(int BtnCount)
        {
            if (InvokeRequired)
            {
                Invoke(new CreateStatusButtonsHandler(InitButtons), BtnCount);
            }
            else
            {
                if (buttonsAlreadyCreated) { return; }
                int i;
                statusButtons = new List<Button>();

                Size size = new Size(100, 100);
                Size size1 = new Size(300, 100);

                for (i = 0; i < BtnCount; i++)
                {
                    statusButtons.Add(new Button());
                    statusButtons[i].Text = (i + 1).ToString() + ".\n";// +TextsParams.ParameterName(337);
                    statusButtons[i].Size = size;
                    statusButtons[i].Font = new Font("Arial", 9);
                    statusButtons[i].Tag = i;
                    statusButtons[i].Dock = DockStyle.None;
                    statusButtons[i].Tag = i;
                    statusButtons[i].BackColor = Color.LightGray;
                    statusButtons[i].Click += new EventHandler(LoadButtonClick);
                }

                for (i = BtnCount; i > 0; i--)
                {
                    flowLayoutPanel2.Controls.Add(statusButtons[i - 1]);
                }
                buttonsAlreadyCreated = true;
            }
        }
        void RemoveButtons()
        {
            for (int i = 0; i < statusButtons.Count; i++)
            {
                flowLayoutPanel2.Controls.Remove(statusButtons[i]);
            }
            statusButtons.Clear();
            buttonsAlreadyCreated = false;
        }
        
        //************************ ЗАГРУЗКА КОНФИГУРАЦИИ *********************************************************//
        //********************************************************************************************************//
        void LoadConfigStepOne()
        {
            if (configLoaded) { return; }
            serialPort.GetDataRTU(ScopeSysType.ChannelCountAddr, 1, LoadConfigRecieveOne);
        }
        void LoadConfigRecieveOne(bool DataOk, ushort[] ParamRTU)
        {
            if (DataOk)
            {
                scopeConfig.ChannelCount = ParamRTU[0];
                LoadConfigStepTwo();
            }
            else
            {
                LoadConfigStepOne();
            }
        }

        void LoadConfigStepTwo()
        {
            serialPort.GetDataRTU(ScopeSysType.ScopeCountAddr, 1, LoadConfigRecieveTwo);
        }
        void LoadConfigRecieveTwo(bool DataOk, ushort[] ParamRTU)
        {
            if (DataOk)
            {
                scopeConfig.ScopeCount = ParamRTU[0];
                LoadConfigStepThree();
            }
            else
            {
                LoadConfigStepTwo();
            }
        }

        void LoadConfigStepThree()
        {
            serialPort.GetDataRTU(ScopeSysType.OscilFreqAddr, 1, LoadConfigRecieveThree);
        }
        void LoadConfigRecieveThree(bool DataOk, ushort[] ParamRTU)
        {
            if (DataOk)
            {
                scopeConfig.ScopeFreq = ParamRTU[0];
                LoadConfigStepFour();
            }
            else
            {
                LoadConfigStepThree();
            }
        }

        void LoadConfigStepFour()
        {
            serialPort.GetDataRTU(ScopeSysType.HystoryAddr, 8, LoadConfigRecieveFour);
        }
        void LoadConfigRecieveFour(bool DataOk, ushort[] ParamRTU)
        {
            if (DataOk)
            {
                scopeConfig.Hystory = ParamRTU[0];
                if (ParamRTU[6] != 0)
                {
                    scopeConfig.ScopeEnabled = true;
                }
                else
                {
                    scopeConfig.ScopeEnabled = false;
                }
                LoadConfigStepFive();
            }
            else
            {
                LoadConfigStepFour();
            }
        }

        void LoadConfigStepFive()
        {
            serialPort.GetDataRTU(ScopeSysType.DataStartAddr, 16, LoadConfigRecieveFive);
        }
        void LoadConfigRecieveFive(bool DataOk, ushort[] ParamRTU)
        {
            if (DataOk)
            {
                scopeConfig.InitOscillParams(ParamRTU);
                configLoaded = true;
                InitButtons(scopeConfig.ScopeCount);
                timer1_Tick(null, null);
            }
            else
            {
                LoadConfigStepFive();
            }
        }

        //*********************** ЗАГРУЗКА СТАТУСОВ ОСЦИЛЛОГРАММ *************************************************//
        //********************************************************************************************************//
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.Visible) { return; }
            if (!configLoaded)
            {
                return;
            }
            if (!nowLoadTimeStamps)
            {
                LoadStatuses();
            }
        }
        
        void LoadStatuses()
        {
            nowLoadTimeStamps = true;
            serialPort.GetDataRTU(ScopeSysType.OscilStatusAddr, 32, EndLoadStatuses);
        }
        void EndLoadStatuses(bool DataOk, ushort[] ParamRTU)
        {
            if (this.IsDisposed) return;
            if (InvokeRequired)
            {
                AsynchSerialPort.DataRecievedRTU endloadDel = new AsynchSerialPort.DataRecievedRTU(EndLoadStatuses);
                if (this.IsDisposed) return;
                Invoke(endloadDel, DataOk, ParamRTU);
            }
            else
            {

                if (!DataOk)
                {
                    nowLoadTimeStamps = false;
                    return;

                }

                if (statusButtons.Count == 0)
                {
                    nowLoadTimeStamps = false;
                    return;
                }

                oscilsStatus = ParamRTU;
                int i = 0;
                for (i = 0; i < scopeConfig.ScopeCount; i++)
                {
                    if (oscilsStatus[i] == 0)
                    {
                        oscilTitls[i] = "Осциллограмма №" + (i + 1).ToString() + ".";
                        statusButtons[i].Text = (i + 1).ToString() + ".\nПУСТО";
                        statusButtons[i].BackColor = Color.Gray;
                        statusButtons[i].Enabled = false;

                    }
                    else if (oscilsStatus[i] >= 4) { statusButtons[i].BackColor = Color.Lime; statusButtons[i].Enabled = true; }

                    else if (oscilsStatus[i] == 3)
                    {
                        statusButtons[i].BackColor = Color.LightBlue;
                        statusButtons[i].Enabled = true;
                        oscilTitls[i] = "Осциллограмма №" + (i + 1).ToString() + ".";
                        statusButtons[i].Text = (i + 1).ToString() + ".\nИДЕТ ЗАПИСЬ";
                    }
                    else if (oscilsStatus[i] == 1)
                    {
                        statusButtons[i].BackColor = Color.Yellow;
                        statusButtons[i].Enabled = true;
                        oscilTitls[i] = "Осциллограмма №" + (i + 1).ToString() + ".";
                        statusButtons[i].Text = (i + 1).ToString() + ".\nЗАПИСЬ ПРЕДЫС-\nТОРИИ";
                    }
                    else
                    {
                        statusButtons[i].BackColor = Color.Yellow;
                        statusButtons[i].Enabled = true;
                        oscilTitls[i] = "Осциллограмма №" + (i + 1).ToString() + ".";
                        statusButtons[i].Text = (i + 1).ToString() + ".\nГОТОВА К ЗАПИСИ\n";
                    }
                }

                InitLoadTimeStamps();
            }
        }

        private void InitLoadTimeStamps()
        {
            loadTimeStampStep = 0;
            LoadTimeStamps();
        }
        private void LoadTimeStamps()
        {
            if (loadTimeStampStep >= scopeConfig.ScopeCount)
            {
                loadTimeStampStep = 0;
                nowLoadTimeStamps = false;
                return;
            }

            int i = loadTimeStampStep;

                
            while ((oscilsStatus[i] < 4) && (i < scopeConfig.ScopeCount))
            {
                i++;
                if (i == 32) { break; }
            }

            if (i >= scopeConfig.ScopeCount)
            {
                loadTimeStampStep = 0;
                nowLoadTimeStamps = false;
                return;
            }
            else
            {
                loadTimeStampStep = i;
                serialPort.GetDataRTU((ushort)(ScopeSysType.TimeStampAddr + i * 8), 8, UpdateTimeStamp);
            }


        }
        public void UpdateTimeStamp(bool DataOk, ushort[] ParamRTU)
        {
            if (InvokeRequired)
            {
                if (this.IsDisposed) return;
                Invoke(new AsynchSerialPort.DataRecievedRTU(UpdateTimeStamp), DataOk, ParamRTU);
            }
            else
            {
                if (!DataOk)
                {
                    nowLoadTimeStamps = false;
                    return;
                }

                string str, str2;
                str = (ParamRTU[5] & 0x3F).ToString("X2") + "/" + (ParamRTU[6] & 0x1F).ToString("X2") + "/20" + (ParamRTU[7] & 0xFF).ToString("X2");
                str2 = (ParamRTU[3] & 0x3F).ToString("X2") + ":" + (ParamRTU[2] & 0x7F).ToString("X2") + ":" + (ParamRTU[1] & 0x7F).ToString("X2");
                if (statusButtons.Count != 0)
                    statusButtons[loadTimeStampStep].Text
                        = (loadTimeStampStep + 1).ToString() + ".\n" +
                          str + "\n" +
                          str2;
                oscilTitls[loadTimeStampStep] = "Осциллограмма №" + (loadTimeStampStep + 1).ToString() + ". " + str + " " + str2;
                oscTimeDates[loadTimeStampStep] = str + " " + str2;
                loadTimeStampStep++;
                LoadTimeStamps();
            }

        }



        //*********************** ЗАГРУЗКА НЕПОСРЕДСТВЕННО ОСЦИЛЛОГРАММ ******************************************//
        //********************************************************************************************************//
        private void LoadButtonClick(object sender, EventArgs e)
        {
            int t = 0;
            try
            {
                t = (int)(sender as Button).Tag;
            }
            catch
            {
                return;
            }

            AskScopeForm askForm = new AskScopeForm(Texts, oscilTitls[t],oscilsStatus[t]);
            if (askForm.ShowDialog() != System.Windows.Forms.DialogResult.Yes) { return; }

            if (askForm.ScopeDialogResult == ScopeDialogResults.Clear)
            {
               serialPort.SetDataRTU((ushort)(ScopeSysType.OscilStatusAddr + t), null, RequestPriority.Normal, 0);
               return;
            }

            LoadOscDataForm loadOscDataForm = new LoadOscDataForm(serialPort, oscilTitls[t], scopeConfig, t, Texts);
            loadOscDataForm.ShowDialog();
        }


        //*********************** СЕРВИСНЫЕ КНОПКИ ******************** ******************************************//
        //********************************************************************************************************//
        private void setupButton_Click(object sender, EventArgs e)
        {
            ScopeSetupForm scopeSetupForm = new ScopeSetupForm(scopeConfig, serialPort);
            scopeSetupForm.ShowDialog();
            if (scopeConfig.ChangeScopeConfig)
            {
                this.Show();
            }
        }
        private void recordButton_Click(object sender, EventArgs e)
        {
            serialPort.SetDataRTU((ushort)(ScopeSysType.ParamLoadConfigAddr - 2), null, RequestPriority.High, 1);
        }









    }
}
