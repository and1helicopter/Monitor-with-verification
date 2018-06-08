using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextLibrary;
using FormatsConvert;

namespace WindowsStructs
{
    public partial class OtherParamsForms : Form
    {
        SystemConfiguration systemConfiguration;
        AppTexts appTexts;

        void SetButtonColor(Button Button, bool FuncEna)
        {
            if (FuncEna)
            {
                Button.BackColor = Color.LightGreen;
            }
            else
            {
                Button.BackColor = SystemColors.Control;
            }
        }

        
        public OtherParamsForms(AppTexts AppTexts, SystemConfiguration SystemConfiguration)
        {
            InitializeComponent();
            appTexts = AppTexts;
            this.Text = AppTexts.ParameterName(81);
            systemConfiguration = SystemConfiguration;

            label1.Text = AppTexts.ParameterName(82);
            label2.Text = AppTexts.ParameterName(83);
            label3.Text = AppTexts.ParameterName(84);
            label4.Text = AppTexts.ParameterName(85);
            label5.Text = AppTexts.ParameterName(86);
            label6.Text = AppTexts.ParameterName(87);
            label7.Text = AppTexts.ParameterName(91);

            textBox1.Text = "0x" + systemConfiguration.StartMeasureAddr.ToString("X4");
            textBox2.Text = "0x" + systemConfiguration.EventCodeAddr.ToString("X4");
            textBox3.Text = "0x" + systemConfiguration.EventTimeAddr.ToString("X4");
            textBox4.Text = "0x" + systemConfiguration.EventBlockCount.ToString("X4");
            textBox5.Text = "0x" + systemConfiguration.LoadEventAddr.ToString("X4");
            textBox6.Text = "0x" + systemConfiguration.LoadEventDataAddr.ToString("X4");
            textBox7.Text = systemConfiguration.EventCount.ToString();

            digInBtn.Text = appTexts.ParameterName(108);        SetButtonColor(digInBtn, systemConfiguration.EnaDigits);
            directAccBtn.Text = appTexts.ParameterName(45);     SetButtonColor(directAccBtn, systemConfiguration.EnaDirectAccess);
            floatDirAccBtn.Text = appTexts.ParameterName(4);    SetButtonColor(floatDirAccBtn, systemConfiguration.EnaFloatDirectAccess);
            scopeBtn.Text = appTexts.ParameterName(39);         SetButtonColor(scopeBtn, systemConfiguration.EnaScope);
            symsBtn.Text = appTexts.ParameterName(17);          SetButtonColor(symsBtn, systemConfiguration.EnaLoadSyms);
            eventLogBtn.Text = appTexts.ParameterName(99);      SetButtonColor(eventLogBtn, systemConfiguration.EnaEventLog);
            jogBtn.Text = appTexts.ParameterName(111);           SetButtonColor(jogBtn, systemConfiguration.EnaJog);
            angleBtn.Text = appTexts.ParameterName(120);         SetButtonColor(angleBtn, systemConfiguration.EnaAngle);
            forceDigBtn.Text = appTexts.ParameterName(122);      SetButtonColor(forceDigBtn, systemConfiguration.EnaForceDig);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(appTexts.ParameterName(88), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = System.Windows.Forms.DialogResult.No;
                short[] us = new short[7];
                try
                {
                    us[0] = ConvertFuncs.StrToShort(textBox1.Text);
                    us[1] = ConvertFuncs.StrToShort(textBox2.Text);
                    us[2] = ConvertFuncs.StrToShort(textBox3.Text);
                    us[3] = ConvertFuncs.StrToShort(textBox4.Text);
                    us[4] = ConvertFuncs.StrToShort(textBox5.Text);
                    us[5] = ConvertFuncs.StrToShort(textBox6.Text);
                    us[6] = ConvertFuncs.StrToShort(textBox7.Text);
                }
                catch
                {
                    MessageBox.Show(appTexts.ParameterName(89), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                systemConfiguration.StartMeasureAddr = (ushort)us[0];
                systemConfiguration.EventCodeAddr = (ushort)us[1];
                systemConfiguration.EventTimeAddr = (ushort)us[2];
                systemConfiguration.EventBlockCount = (ushort)us[3];
                systemConfiguration.LoadEventAddr = (ushort)us[4];
                systemConfiguration.LoadEventDataAddr = (ushort)us[5];
                systemConfiguration.EventCount = (ushort)us[6];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void digInBtn_Click(object sender, EventArgs e)
        {
            systemConfiguration.EnaDigits = !systemConfiguration.EnaDigits;
            SetButtonColor(digInBtn, systemConfiguration.EnaDigits);
        }

        private void directAccBtn_Click(object sender, EventArgs e)
        {
            systemConfiguration.EnaDirectAccess = !systemConfiguration.EnaDirectAccess;
            SetButtonColor(directAccBtn, systemConfiguration.EnaDirectAccess);
        }

        private void floatDirAccBtn_Click(object sender, EventArgs e)
        {
            systemConfiguration.EnaFloatDirectAccess = !systemConfiguration.EnaFloatDirectAccess;
            SetButtonColor(floatDirAccBtn, systemConfiguration.EnaFloatDirectAccess);
        }

        private void scopeBtn_Click(object sender, EventArgs e)
        {
            systemConfiguration.EnaScope = !systemConfiguration.EnaScope;
            SetButtonColor(scopeBtn, systemConfiguration.EnaScope);
        }

        private void eventLogBtn_Click(object sender, EventArgs e)
        {
            systemConfiguration.EnaEventLog = !systemConfiguration.EnaEventLog;
            SetButtonColor(eventLogBtn, systemConfiguration.EnaEventLog);
        }

        private void symsBtn_Click(object sender, EventArgs e)
        {
            systemConfiguration.EnaLoadSyms = !systemConfiguration.EnaLoadSyms;
            SetButtonColor(symsBtn, systemConfiguration.EnaLoadSyms);
        }

        private void jogBtn_Click(object sender, EventArgs e)
        {
            systemConfiguration.EnaJog = !systemConfiguration.EnaJog;
            SetButtonColor(jogBtn, systemConfiguration.EnaJog);
        }

        private void angleBtn_Click(object sender, EventArgs e)
        {
            systemConfiguration.EnaAngle = !systemConfiguration.EnaAngle;
            SetButtonColor(angleBtn, systemConfiguration.EnaAngle);
        }

        private void forceDigBtn_Click(object sender, EventArgs e)
        {
            systemConfiguration.EnaForceDig = !systemConfiguration.EnaForceDig;
            SetButtonColor(forceDigBtn, systemConfiguration.EnaForceDig);
        }

    }
}
