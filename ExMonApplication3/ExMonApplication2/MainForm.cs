using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsStructs;
using FormatsConvert;
using System.IO.Ports;
using UniSerialPort;
using System.Runtime.InteropServices;
using SerialPorts;
using TextLibrary;
using ScopeLoadForms;
using StandartScreens;
using System.IO;
using ExMonApplication3;

namespace ExMonApplication2
{
    public partial class MainForm : Form
    {
        SystemConfiguration systemConfiguration = new SystemConfiguration();
        AsynchSerialPort serialPort = new AsynchSerialPort();
        AppTexts AppTexts = AppTexts.Instance;

        bool timeRequestNow = false;

        JogForm jogForm;
        AngleForm angleForm;
        LoadScopeForm loadScopeForm;
        DirectAccessForm directAccessForm;
        FloatDirectAccessForm floatDirectAccess;
        DownloadSYMForm downloadSYMForm;
        List<DigitPlateForm> digInModuls = new List<DigitPlateForm>();
        List<DigitPlateForm> digOutModuls = new List<DigitPlateForm>();
        EventLogForm eventLogForm;
        VerificationForm verificationForm;

        void ErrorMessage(string Titl)
        {
            MessageBox.Show(Titl, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //************************СОЗДАНИЕ ФОРМЫ**********************************************************//
        //*****************************************8******************************************************//
        void InitTexts()
        {
            try
            {
                toolTip1.SetToolTip(connectBtn, TextsParams.ParameterName(2));
                toolTip1.SetToolTip(disconnectBtn, TextsParams.ParameterName(3));
                toolTip1.SetToolTip(setClockBtn, TextsParams.ParameterName(19));
                toolTip1.SetToolTip(loadSysTypeBtn, TextsParams.ParameterName(20));

                directBtn.Title = TextsParams.ParameterName(45);
                directFloatBtn.Title = TextsParams.ParameterName(4);
                toolTip1.SetToolTip(directFloatBtn, TextsParams.ParameterName(4));
                loadSYMBtn.Title = TextsParams.ParameterName(17);
                scopeLabelButton.Title = TextsParams.ParameterName(70);
                eventLabelButton.Title = TextsParams.ParameterName(99);
                jogLabelButton.Title = TextsParams.ParameterName(111);
                angleLabelButton.Title = TextsParams.ParameterName(119);
                digitTitle.Text = TextsParams.ParameterName(108);
                verificationlabelButton.Title = TextsParams.ParameterName(123);
            }
            catch (Exception e)
            {

            }
        }
        public MainForm()
        {
            InitializeComponent();
            InitTexts();

            try
            {
                List<string> args = Environment.GetCommandLineArgs().ToList();
                setupFlowLayoutPanel.Visible = (args[1] == "SETUPMODE");
            }
            catch
            {
                setupFlowLayoutPanel.Visible = false;
            }


            Text = TextsParams.ParameterName(0);
            serialPort.LoadSettingsFromFile("Comset.xml");
            CreateChildForms();
            systemConfiguration.LoadFromFile("SysType.xml");
            InitSystemConfig();
            EnableAllButtons(false);
            serialPort.PortClosed+=new EventHandler(serialPort_PortClosed);
            serialPort.SerialPortError +=new EventHandler(serialPort_SerialPortError);
            serialPort.FatalSerialPortError +=new EventHandler(serialPort_FatalSerialPortError);
        }


        //************************ЗАГРУЗКА НОВОГО ТИПА СИСТЕМ*********************************************//
        //************************************************************************************************//
        private void loadSysTypeBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = AppTexts.ParameterName(102);
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                systemConfiguration = new SystemConfiguration();
                systemConfiguration.LoadFromFile(ofd.FileName);
                InitSystemConfig();
            }
        }
        void InitSystemConfig()
        {
            directBtn.Visible = systemConfiguration.EnaDirectAccess;
            directFloatBtn.Visible = systemConfiguration.EnaFloatDirectAccess;
            digitTitle.Visible = digitsTableLayoutPanel.Visible = systemConfiguration.EnaDigits;
            if (systemConfiguration.EnaDigits)
            {
                this.Height = 365;
            }
            else
            {
                this.Height = 250;
            }

            scopeLabelButton.Visible = systemConfiguration.EnaScope;
            eventLabelButton.Visible = systemConfiguration.EnaEventLog;
            loadSYMBtn.Visible = systemConfiguration.EnaLoadSyms;
            jogLabelButton.Visible = systemConfiguration.EnaJog;
            angleLabelButton.Visible = systemConfiguration.EnaAngle;

            digInComboBox.Items.Clear();
            digOutComboBox.Items.Clear();

            for (int i = 0; i < digInModuls.Count; i++)
            {
                digInModuls[i].Dispose();
            }

            for (int i = 0; i < digOutModuls.Count; i++)
            {
                digOutModuls[i].Dispose();
            }


            digInModuls.Clear();
            digOutModuls.Clear();


            foreach (DigitPlate digitPlate in systemConfiguration.DigitPlates)
            {
                if (digitPlate.DigitType == DigitType.DigInput)
                {
                    digInComboBox.Items.Add(digitPlate.Titl);
                    digInModuls.Add(new DigitPlateForm(serialPort, AppTexts, digitPlate, systemConfiguration.EnaForceDig));
                }
                else if (digitPlate.DigitType == DigitType.DigOutput)
                {
                    digOutComboBox.Items.Add(digitPlate.Titl);
                    digOutModuls.Add(new DigitPlateForm(serialPort, AppTexts, digitPlate, systemConfiguration.EnaForceDig));
                }
            }

            if (digInModuls.Count != 0)
            {
                digInComboBox.SelectedIndex = 0;
            }

            if (digOutModuls.Count != 0)
            {
                digOutComboBox.SelectedIndex = 0;
            }
        }
        void CreateChildForms()
        {
            loadScopeForm = new LoadScopeForm(AppTexts, serialPort);
            directAccessForm = new DirectAccessForm(serialPort, AppTexts);
            jogForm = new JogForm(serialPort, AppTexts);
            angleForm = new AngleForm(serialPort, AppTexts);
            downloadSYMForm = new DownloadSYMForm(serialPort, AppTexts);
            floatDirectAccess = new FloatDirectAccessForm(serialPort, TextsParams.GetListParamNames(4, 14));
            eventLogForm = new EventLogForm(AppTexts, serialPort, systemConfiguration);
            verificationForm = new VerificationForm(serialPort);
        }

        //************************ЗАПРОС ТЕКУЩЕГО ВРЕМЕНИ ************************************************//
        //************************************************************************************************//
        private void timeTimer_Tick(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) { timeLabel.Text = "Порт закрыт"; timeRequestNow = false; return; }
            if (timeRequestNow) { return; }
            TimeConfig.SendReadTimeRequest(serialPort, TimeRecieved, systemConfiguration.TimeConfig);
        }
        private void TimeRecieved(bool DataOk, ushort[] ParamRTU)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    Invoke(new AsynchSerialPort.DataRecievedRTU(TimeRecieved), DataOk, ParamRTU);
                }
                catch
                {

                }
            }
            else
            {

                try
                {
                    if (!DataOk)
                    {
                        timeLabel.Text = "Нет связи";
                    }
                    else
                    {
                        timeLabel.Text = TimeConfig.ExtractTimeFromArray(ParamRTU, systemConfiguration.TimeConfig);
                    }
                }
                catch
                {

                }

            }
        }

        //************************УСТАНОВКА ТЕКУЩЕГО ВРЕМЕНИ *********************************************//
        //************************************************************************************************//
        private void setClockBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(TextsParams.ParameterName(18), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DateTime dt = DateTime.Now;
                TimeConfig.SendSetTimeRequest(serialPort, systemConfiguration.TimeConfig,
                    dt.Hour, dt.Minute, dt.Second, dt.Day, dt.Month, dt.Year - 2000);
            }

        }


        //************************УСТАНОВКА-РАЗРЫВ СОЕДИНЕНИЯ *********************************************//
        //************************************************************************************************//
        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Open();
            }
            catch
            {
                ErrorMessage(TextsParams.ParameterName(15));
                return;
            }


            if (serialPort.IsOpen)
            {
                EnableAllButtons(true);
            }
            else
            {
                ErrorMessage(TextsParams.ParameterName(15));
            }


        }
        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            disconnectBtn.Enabled = false;
            serialPort.Close();
        }
        private void comSetBtn_Click(object sender, EventArgs e)
        {
            ComSetForm comSet = new ComSetForm(serialPort, TextsParams.GetListParamNames(29,38));
            comSet.ShowDialog();
        }
        void HideAllForms()
        {
            
            loadScopeForm.Hide();
            directAccessForm.Hide();
            downloadSYMForm.Hide();
            floatDirectAccess.Hide();
            jogForm.Hide();
            angleForm.Hide();

            for (int i = 0; i < digInModuls.Count; i++)
            {
                digInModuls[i].Hide();
            }

            for (int i = 0; i < digOutModuls.Count; i++)
            {
                digOutModuls[i].Hide();
            }
            eventLogForm.CancelLoad();
            eventLogForm.Hide();
        }
        void EnableAllButtons(bool EnableForms)
        {
            scopeLabelButton.Enabled = EnableForms;
            directBtn.Enabled = EnableForms;
            directFloatBtn.Enabled = EnableForms;
            loadSYMBtn.Enabled = EnableForms;
            digInComboBox.Enabled = digInBtn.Enabled = EnableForms & (digInModuls.Count > 0);
            digOutComboBox.Enabled = digOutBtn.Enabled = EnableForms & (digOutModuls.Count > 0);
            setClockBtn.Enabled = EnableForms;
           // eventLabelButton.Enabled = EnableForms;
            eventLogForm.EnableForm(EnableForms);
            jogLabelButton.Enabled = EnableForms;
            angleLabelButton.Enabled = EnableForms;
            configBtn.Enabled = !EnableForms;
            loadSysTypeBtn.Enabled = !EnableForms;
            disconnectBtn.Enabled = EnableForms;
            connectBtn.Enabled = !EnableForms;
            comSetBtn.Enabled = !EnableForms;

        }
        void serialPort_PortClosed(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new EventHandler(serialPort_PortClosed), sender, e);
                }
                catch
                {

                }
            }
            else
            {
                HideAllForms();
                EnableAllButtons(false);
            }
        }

        void serialPort_SerialPortError(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(serialPort_SerialPortError),sender,e);
            }
            else
            {
                disconnectBtn_Click(null, null);
            }
        }

        void serialPort_FatalSerialPortError(object sender, EventArgs e)
        {
            MessageBox.Show(AppTexts.ParameterName(106)+"\n"+AppTexts.ParameterName(107),this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
            Application.Exit();
        }

        //************************ВЫЗОВ ДОПОЛНИТЕЛЬНЫХ ОКОН ***********************************************//
        //************************************************************************************************//
        private void scopeLabelButton_ButtonClick(object sender, EventArgs e)
        {
            if (loadScopeForm.Visible)
                loadScopeForm.Activate();
            else
                loadScopeForm.Show();
        }
        private void directBtn_ButtonClick(object sender, EventArgs e)
        {
            if(directAccessForm.Visible)
                directAccessForm.Activate();
            else
                directAccessForm.Show();
            
        }
        private void loadSYMBtn_ButtonClick(object sender, EventArgs e)
        {
            if(downloadSYMForm.Visible)
            
                downloadSYMForm.Activate();
            else
                downloadSYMForm.Show();
        }
        private void digInBtn_Click(object sender, EventArgs e)
        {
            if (digInModuls[digInComboBox.SelectedIndex].Visible)
                
                digInModuls[digInComboBox.SelectedIndex].Activate();
            else
                digInModuls[digInComboBox.SelectedIndex].Show();
        }
        private void digOutBtn_Click(object sender, EventArgs e)
        {
            if (digOutModuls[digOutComboBox.SelectedIndex].Visible)
                
                digOutModuls[digOutComboBox.SelectedIndex].Activate();
            else
                digOutModuls[digOutComboBox.SelectedIndex].Show();
        }
        private void directFloatBtn_ButtonClick(object sender, EventArgs e)
        {
            if (floatDirectAccess.Visible)
               
                floatDirectAccess.Activate();
            else
                floatDirectAccess.Show();
        }

        private void eventLabelButton_ButtonClick(object sender, EventArgs e)
        {
            if (eventLogForm.Visible)
                
                eventLogForm.Activate();
            else
                eventLogForm.Show();
        }

        private void jogLabelButton_ButtonClick(object sender, EventArgs e)
        {
            if (jogForm.Visible)

                jogForm.Activate();
            else
                jogForm.Show();
        }

        private void angleLabelButton_ButtonClick(object sender, EventArgs e)
        {
            if (angleForm.Visible)

                angleForm.Activate();
            else
                angleForm.Show();
        }
        //*************************КНФИГУРАТОР СИСТЕМ******************************************************//
        //************************************************************************************************//
        private void configBtn_Click(object sender, EventArgs e)
        {
            SystemConfiguratorForm systemConfig = new SystemConfiguratorForm(AppTexts,systemConfiguration);
            systemConfig.ShowDialog();
            if (systemConfig.NewSystemConfigFlag)
            {
                systemConfiguration = new SystemConfiguration();
                systemConfiguration.LoadFromFile(Path.GetDirectoryName(Application.ExecutablePath) + "/SysType.xml");
                InitSystemConfig();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(Path.GetDirectoryName(Application.ExecutablePath));
        }

        private void labelButton1_ButtonClick(object sender, EventArgs e)
        {
            if (verificationForm.Visible)

                verificationForm.Activate();
            else
                verificationForm.Show();
        }
    }
}
