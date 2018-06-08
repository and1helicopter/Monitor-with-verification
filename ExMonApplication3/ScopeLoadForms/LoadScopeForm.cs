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
        ScopeConfigLoader scopeConfigLoader;
        ScopeStatusesLoader scopeStatusesLoader;

        ushort[] oscilsStatus = new ushort[33];
        string[] oscilTitls = new string[33];
        string[] oscTimeDates = new string[33];
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

            LoadConfig();
            //Activate();
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
        void LoadConfig()
        {
            if (configLoaded) { return; }
            scopeConfigLoader = new ScopeConfigLoader(serialPort);
            scopeConfigLoader.OnLoadingComplete +=new ScopeConfigLoader.LoadingCompleter(scopeConfigLoader_OnLoadingComplete);
        }
        void scopeConfigLoader_OnLoadingComplete(bool LoadingOk)
        {
            if (LoadingOk)
            {
                scopeConfig = scopeConfigLoader.ScopeConfig;
                
              //  MessageBox.Show(scopeConfig.ScopeCount.ToString());
                InitButtons(scopeConfig.ScopeCount);
                configLoaded = true;
                timer1_Tick(this, EventArgs.Empty);
            }
            else
            {
            
                if (this.Visible)
                LoadConfig();
              
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
                LoadStatusesAsynch();
            }
        }
        void LoadStatusesAsynch()
        {
            nowLoadTimeStamps = true;
            scopeStatusesLoader = new ScopeStatusesLoader(serialPort, scopeConfig);
            scopeStatusesLoader.OnLoadingComplete +=new ScopeStatusesLoader.LoadingCompleter(scopeStatusesLoader_OnLoadingComplete);
        }
        void scopeStatusesLoader_OnLoadingComplete(bool LoadingOk)
        {
            if (!LoadingOk)
            {
                InitButtons(0);
            }
            else
            {

                for (int i = 0; i < scopeConfig.ScopeCount; i++)
                {
                    statusButtons[i].Text = scopeStatusesLoader.ButtonsText[i];
                    statusButtons[i].Enabled = scopeStatusesLoader.ButtonsEnabled[i];
                    statusButtons[i].BackColor = scopeStatusesLoader.ButtonsColor[i];
                    oscilsStatus = scopeStatusesLoader.OscilsStatus;
                    oscilTitls = scopeStatusesLoader.OscilTitls;
                    oscTimeDates = scopeStatusesLoader.OscTimeDates;
                }
            }
            nowLoadTimeStamps = false;
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
