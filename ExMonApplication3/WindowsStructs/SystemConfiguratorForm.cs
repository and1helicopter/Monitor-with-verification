using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextLibrary;
using System.Collections;
using System.IO;

namespace WindowsStructs
{
    public partial class SystemConfiguratorForm : Form
    {
        AppTexts Texts { get; set; }
        SystemConfiguration systemConfiguration = new SystemConfiguration();

        public SystemConfiguratorForm(AppTexts AppTexts, SystemConfiguration SystemConfiguration)
        {
            InitializeComponent();
            systemConfiguration = SystemConfiguration;
            NewSystemConfigFlag = false;
            Texts = AppTexts;
            digitLabelButton.Title = Texts.ParameterName(71);
            timeLabelButton.Title = Texts.ParameterName(72);
            measureButton.Title = Texts.ParameterName(75);
            eventsBtn.Title = Texts.ParameterName(76);
            warnsButton.Title = Texts.ParameterName(79);
            alarmsButton.Title = Texts.ParameterName(80);
            addrsButton.Title = Texts.ParameterName(81);
            defaultButton.ToolTipText = Texts.ParameterName(104);
            readyButton.Title = Texts.ParameterName(110);
        }

        //***********************ЧТЕНИЕ И ЗАПИСЬ ИЗ ФАЙЛА***********************************************************//
        //**********************************************************************************************************//
        //**********************************************************************************************************//
        private void saveBtn_Click(object sender, EventArgs e)
        {
            systemConfiguration.SaveToFile();
        }
        private void loadBtn_Click(object sender, EventArgs e)
        {
            systemConfiguration = new SystemConfiguration();
            try
            {
                systemConfiguration.LoadFromFile();
            }
            catch
            {
                systemConfiguration = new SystemConfiguration();
            }
        }

        //**********************************************************************************************************//
        //**********************************************************************************************************//
        //**********************************************************************************************************//
        private void digitLabelButton_ButtonClick(object sender, EventArgs e)
        {
            DigitPlateConfigForm digitConfig = new DigitPlateConfigForm(Texts);
            digitConfig.DigitPlates = systemConfiguration.DigitPlates;
            digitConfig.ShowDialog();
            systemConfiguration.DigitPlates = digitConfig.DigitPlates;
        }
        private void timeLabelButton_ButtonClick(object sender, EventArgs e)
        {
            TimeConfiguratorForm timeConfigForm = new TimeConfiguratorForm(systemConfiguration.TimeConfig);
            if (timeConfigForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TimeConfig t = new TimeConfig();
                try
                {
                    t = timeConfigForm.CalcTimeConfig();

                }
                catch
                {
                    MessageBox.Show("Неправильно заданы адреса!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                systemConfiguration.TimeConfig = t;

            }
        }

        private void labelButton1_ButtonClick(object sender, EventArgs e)
        {
            MeasureParamsSetupForm m = new MeasureParamsSetupForm(systemConfiguration.MeasureParams, Texts);
            if (m.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                systemConfiguration.MeasureParams = m.NewMeasureParams;
            }
        }

        private void eventsBtn_ButtonClick(object sender, EventArgs e)
        {
            EventCodesForm evf = new EventCodesForm(Texts, systemConfiguration.EventCodes);
            if (evf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                systemConfiguration.EventCodes = evf.NewEventCodes;
            }
        }

        private void warnsButton_ButtonClick(object sender, EventArgs e)
        {
            WarningConfigForm wcf = new WarningConfigForm(Texts.ParameterName(90), notifyIcon1.Icon, Texts, "WarningStrings");
            wcf.SetWarningParams(systemConfiguration.WarningParams);
            wcf.ShowDialog();
            systemConfiguration.WarningParams = wcf.GetWarningParams();
        }

        private void addrsButton_ButtonClick(object sender, EventArgs e)
        {
            OtherParamsForms otherParams = new OtherParamsForms(Texts, systemConfiguration);
            otherParams.ShowDialog();
        }

        private void alarmsButton_ButtonClick(object sender, EventArgs e)
        {
            WarningConfigForm wcf = new WarningConfigForm(Texts.ParameterName(80), notifyIcon2.Icon, Texts, "AlarmStrings");
            wcf.SetWarningParams(systemConfiguration.AlarmParams);
            wcf.ShowDialog();
            systemConfiguration.AlarmParams = wcf.GetWarningParams();
        }

        private void readyButton_ButtonClick(object sender, EventArgs e)
        {
            WarningConfigForm wcf = new WarningConfigForm(Texts.ParameterName(110), notifyIcon3.Icon, Texts, "ReadyStrings");
            wcf.SetWarningParams(systemConfiguration.ReadyParams);
            wcf.ShowDialog();
            systemConfiguration.ReadyParams = wcf.GetWarningParams();
        }


        //**********************************************************************************************************//
        //**********************************************************************************************************//
        //**********************************************************************************************************//

        public bool NewSystemConfigFlag { get; set; }
        private void defaultButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Texts.ParameterName(104) + "?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                systemConfiguration.SaveToFile(Path.GetDirectoryName(Application.ExecutablePath) + "/SysType.xml");
                NewSystemConfigFlag = true;
            }
        }

        private void warnsButton_Load(object sender, EventArgs e)
        {

        }


    }
}
