using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniSerialPort;

namespace ScopeLoadForms
{
    public partial class ScopeSetupForm : Form
    {
        private ushort          nowHystory;
        private ushort          nowScopeCount = 1;
        private int             nowMaxChannelCount = 4;
        private ushort          nowOscFreq = 1;
        private int             oscillTime = 1024;

        ScopeConfig ScopeConfig { get; set; }


        private List<Label> possibleLabels;
        private List<Label> currentLabels;

        public void InitPossiblePanel()
        {
            possibleLabels = new List<Label>();
            int i;

            this.possibleTableLayoutPanel.RowCount = ScopeSysType.ChannelNames.Count;

            this.possibleTableLayoutPanel.RowStyles[0] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize);
            for (i = 0; i < (ScopeSysType.ChannelNames.Count-1); i++)
            {
                this.possibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            }

            for (i = 0; i < ScopeSysType.ChannelNames.Count; i++)
            {
                possibleLabels.Add(new Label());
                possibleLabels[i].Dock = DockStyle.Fill;
                possibleLabels[i].BorderStyle = BorderStyle.FixedSingle;
                possibleLabels[i].AutoSize = true;
                possibleLabels[i].Margin = sampleNameLabel.Margin;
                possibleLabels[i].Font = sampleNameLabel.Font;
                possibleLabels[i].TextAlign = ContentAlignment.MiddleLeft;
                possibleLabels[i].Text = ScopeSysType.ChannelNames[i];
                possibleTableLayoutPanel.Controls.Add(possibleLabels[i]);
                possibleTableLayoutPanel.SetColumn(possibleLabels[i], 0);
                possibleTableLayoutPanel.SetRow(possibleLabels[i], i);
                possibleLabels[i].BackColor = Color.LightBlue;
                possibleLabels[i].MouseDown += new MouseEventHandler(possibleLabel_MouseDown);
                possibleLabels[i].AllowDrop = true;
                possibleLabels[i].Tag = i;
                possibleLabels[i].DragDrop += new DragEventHandler(possibleLabel_DragDrop);
                possibleLabels[i].DragEnter += new DragEventHandler(currentLabel_DragEnter);
                possibleLabels[i].MouseMove += new MouseEventHandler(possibleLabel_MouseMove);
            }

            currentLabels = new List<Label>();

            currentTableLayoutPanel.RowCount = ScopeSysType.ChannelNames.Count;
            currentTableLayoutPanel.DragDrop += new DragEventHandler(currentLabel_DragDrop);
            currentTableLayoutPanel.DragEnter += new DragEventHandler(currentLabel_DragEnter);
            currentTableLayoutPanel.AllowDrop = true;

            currentParamsPanel.DragDrop += new DragEventHandler(currentLabel_DragDrop);
            currentParamsPanel.DragEnter += new DragEventHandler(currentLabel_DragEnter);
            currentParamsPanel.AllowDrop = true;


            possibleParamPanel.DragDrop += new DragEventHandler(possibleLabel_DragDrop);
            possibleParamPanel.DragEnter += new DragEventHandler(currentLabel_DragEnter);
            possibleParamPanel.AllowDrop = true;

            possibleTableLayoutPanel.RowCount = ScopeSysType.ChannelNames.Count;
            possibleTableLayoutPanel.DragDrop += new DragEventHandler(possibleLabel_DragDrop);
            possibleTableLayoutPanel.DragEnter += new DragEventHandler(currentLabel_DragEnter);
            
            possibleTableLayoutPanel.AllowDrop = true;

            currentTableLayoutPanel.RowStyles[0] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize);
            for (i = 0; i < (ScopeSysType.ChannelNames.Count - 1); i++)
            {
                this.currentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            }

            for (i = 0; i < ScopeSysType.ChannelNames.Count; i++)
            {
                currentLabels.Add(new Label());
                currentLabels[i].Dock = DockStyle.Fill;
                currentLabels[i].AutoSize = true;
                currentLabels[i].BorderStyle = BorderStyle.FixedSingle;
                currentLabels[i].Margin = sampleNameLabel.Margin;
                currentLabels[i].Font = sampleNameLabel.Font;
                currentLabels[i].TextAlign = ContentAlignment.MiddleLeft;
                currentLabels[i].Text = ScopeSysType.ChannelNames[i];
                currentTableLayoutPanel.Controls.Add(currentLabels[i]);
                currentTableLayoutPanel.SetColumn(currentLabels[i], 0);
                currentTableLayoutPanel.SetRow(currentLabels[i], i);
                currentLabels[i].BackColor = Color.LightBlue;
                currentLabels[i].Visible = false;
                currentLabels[i].AllowDrop = true;
                currentLabels[i].Tag = i;
                currentLabels[i].DragDrop += new DragEventHandler(currentLabel_DragDrop);
                currentLabels[i].DragEnter += new DragEventHandler(currentLabel_DragEnter);
                currentLabels[i].MouseDown += new MouseEventHandler(currentLabel_MouseDown);
                currentLabels[i].MouseMove += new MouseEventHandler(currentLabel_MouseMove);

            }
        }

        Label startLabel;
        private void currentLabel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Text"))
                e.Effect = DragDropEffects.Copy;
        }

        private void currentLabel_DragDrop(object sender, DragEventArgs e)
        {
            currentLabels[(int)startLabel.Tag].Visible = true;
            possibleLabels[(int)startLabel.Tag].Visible = false;
        }
        
        private void possibleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (CalcCurrentParams() >= nowMaxChannelCount) { return; }
            startLabel = (Label)sender;
            startLabel.DoDragDrop(startLabel.Text, DragDropEffects.Copy);
        }

        private void currentLabel_MouseDown(object sender, MouseEventArgs e)
        {
            startLabel = (Label)sender;
            startLabel.DoDragDrop(startLabel.Text, DragDropEffects.Copy);
        }

        private void currentLabel_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as Label).Cursor = Cursors.Hand;
        }

        private void possibleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (CalcCurrentParams() < nowMaxChannelCount) { (sender as Label).Cursor = Cursors.Hand; }
            else { (sender as Label).Cursor = Cursors.Default; }
           
        }

        private void possibleLabel_DragDrop(object sender, DragEventArgs e)
        {
            currentLabels[(int)startLabel.Tag].Visible = false;
            possibleLabels[(int)startLabel.Tag].Visible = true;
        }

        AsynchSerialPort serialPort;
        public ScopeSetupForm(ScopeConfig NewScopeConfig, AsynchSerialPort AsynchSerialPort)
        {
            InitializeComponent();
            ScopeConfig = NewScopeConfig;
            serialPort = AsynchSerialPort;

            InitPossiblePanel();
            InitChannelCount();
            InitScopeCount();
            InitOscilFreq();
            InitHystory();
            InitCurrentParams();
            
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked) return;
            nowMaxChannelCount = 4;
            CheckMaxScopeCount();
            InitOscTimeLabel();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton2.Checked) return;
            nowMaxChannelCount = 8;
            CheckMaxScopeCount();
            InitOscTimeLabel();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton3.Checked) return;
            nowMaxChannelCount = 16;
            CheckMaxScopeCount();
            InitOscTimeLabel();
        }

        private void CheckMaxScopeCount()
        {
            if (CalcCurrentParams() <= nowMaxChannelCount) { return; }
            int i1, i2;
            i2 = 0;
            for (i1 = 0; i1 < ScopeSysType.ChannelNames.Count; i1++)
            {
                if (currentLabels[i1].Visible) { i2++; }
                if (i2 > nowMaxChannelCount)
                {
                    currentLabels[i1].Visible = false;
                    possibleLabels[i1].Visible = true;
                }
            }
        }

        private ushort CalcCurrentParams()
        {
            ushort u = 0;
            for (int i1 = 0; i1 < ScopeSysType.ChannelNames.Count; i1++)
            {
                if (currentLabels[i1].Visible) { u++; }
            }
            return u;
        }

        private int CalcOscillTime(int chCount, int oscCount, int oscFreq)
        {
            double f = 0;

            switch (oscFreq)
            {
                case 1:     f = 0.25;    break;
                case 3:     f = 0.5;   break;
                case 7:     f = 1;  break;
                case 0:     f = 0.125;      break;
                default:    f = 0.25;    break;
            }

            if (chCount == 0)   { return 0; }
            if (oscCount == 0)  { return 0; }

            double f1 = f * 1024 * 256 / (chCount * oscCount);
            return ((int)(Math.Round(f1)));
        }

        private void InitOscTimeLabel()
        {
            oscillTime = CalcOscillTime(nowScopeCount, nowMaxChannelCount, nowOscFreq);
            oscTimeLabel.Text = "Длительность оcциллограммы: " + oscillTime.ToString() + " мс";
        }



        //****************************************************************************//
        //****************************************************************************//
        //****************************************************************************//
        private void chCountRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked) { return; }
            string str = (sender as RadioButton).Tag.ToString();
            if (ushort.TryParse(str, out nowScopeCount))
            {

            }
            else
            {
                nowScopeCount = 1;
            }

            InitOscTimeLabel();

        }
        private void oscFreqRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked) { return; }
            string str = (sender as RadioButton).Tag.ToString();
            if (ushort.TryParse(str, out nowOscFreq))
            {

            }
            else
            {
                nowOscFreq = 1;
            }

            InitOscTimeLabel();
        }
        //Изменение длительности предыстории
        private void hystoryRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            nowHystory = 0x4000;
        }
        private void hystoryRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            nowHystory = 0x8000;
        }
        private void hystoryRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            nowHystory = 0xC000;
        }

        //****************** ИЗНАЧАЛЬНАЯ ИНИЦИАЛИЗАЦИЯ КОМПОНЕНТОВ ***********************//
        //********************************************************************************//
        //********************************************************************************//
        private void InitChannelCount()
        {
            switch (ScopeConfig.ChannelCount)
            {
                case 4:
                    {
                        radioButton1.Checked = true;
                        nowMaxChannelCount = 4;
                    } break;

                case 8:
                    {
                        radioButton2.Checked = true;
                        nowMaxChannelCount = 8;
                    } break;

                default:
                    {
                        radioButton3.Checked = true;
                        nowMaxChannelCount = 16;
                    } break;
            }

            CheckMaxScopeCount();
            InitOscTimeLabel();
        }
        private void InitScopeCount()
        {
            switch (ScopeConfig.ScopeCount)
            {
                case 1:
                    {
                        chCountRadioButton1.Checked = true;
                        nowScopeCount = 1;

                    } break;

                case 2:
                    {
                        chCountRadioButton2.Checked = true;
                        nowScopeCount = 2;

                    } break;

                case 4:
                    {
                        chCountRadioButton3.Checked = true;
                        nowScopeCount = 4;

                    } break;

                case 8:
                    {
                        chCountRadioButton4.Checked = true;
                        nowScopeCount = 8;

                    } break;

                case 16:
                    {
                        chCountRadioButton5.Checked = true;
                        nowScopeCount = 16;

                    } break;

                case 32:
                    {
                        chCountRadioButton6.Checked = true;
                        nowScopeCount = 32;

                    } break;

            }
            InitOscTimeLabel();

        }
        private void InitOscilFreq()
        {
            switch (ScopeConfig.ScopeFreq)
            {
                case 3:
                    {
                        nowOscFreq = 3;
                        oscFreqRadioButton2.Checked = true;
                    }break;

                case 7:
                    {
                        nowOscFreq = 7;
                        oscFreqRadioButton3.Checked = true;
                    } break;
                default:
                    {
                        nowOscFreq = 1;
                        oscFreqRadioButton1.Checked = true;
                    } break;
            }
            InitOscTimeLabel();


        }
        private void InitHystory()
        {
            switch (ScopeConfig.Hystory)
            {
                case 0x4000:
                    {
                        hystoryRadioButton1.Checked = true;
                        nowHystory = 0x4000;

                    }break;

                case 0xC000:
                    {
                        hystoryRadioButton3.Checked = true;
                        nowHystory = 0xC000;

                    } break;


                default:
                    {
                        hystoryRadioButton2.Checked = true;
                        nowHystory = 0x8000;

                    } break;
            }

            enaScopeCheckBox.Checked = ScopeConfig.ScopeEnabled;
        }
        private void InitCurrentParams()
        {
            int i;
            for (i = 0; i < ScopeConfig.ChannelCount; i++)
            {
                if (ScopeConfig.OscillParams[i] < ScopeSysType.ChannelNames.Count)
                {
                    possibleLabels[ScopeConfig.OscillParams[i]].Visible = false;
                    currentLabels[ScopeConfig.OscillParams[i]].Visible = true;
                }

            }

        }

        //**************ИЗМЕНЕНИЕ КОНФИГУРАЦИИ ОСЦИЛЛОГРАФА *********************************************//
        //***********************************************************************************************//
        //***********************************************************************************************//
        ushort[] newOscillConfig = new ushort[32];
        int writeConfigStep = 0;

        private ushort CalcOscilChNumExp(int count)
        {
            Int16 i = 0;
            switch (count)
            {
                case 1: i = 0; break;
                case 2: i = -1; break;
                case 4: i = -2; break;
                case 8: i = -3; break;
                case 16: i = -4; break;
                case 32: i =-5; break;
            }
            return ((ushort)i);
        }
        private ushort CalcOscilCountRound(int count)
        {
            Int16 i = (Int16)(-count * 8);
            return ((ushort)i);
        }
        private ushort CalcOscilCountInc(int countCh,int countOsc)
        {
            int i = countCh * countOsc;
            i = (int)Math.Round(i / 4.0);
            return ((ushort)i);
        }
        private List<ushort> CalcOscParamList()
        {
            List<ushort> l = new List<ushort>();
            int i = 0;
            for (i = 0; i < ScopeSysType.ChannelNames.Count; i++)
            {
                if (currentLabels[i].Visible) { l.Add(ScopeSysType.ChannelAddrs[i]); }
            }

            if (l.Count > nowMaxChannelCount) { l.Clear(); }

            return l;
        }
        private void CalcNewOscillConfig()
        {
            newOscillConfig = new ushort[32];
            newOscillConfig[0] = 0x0001;    //Флаг изменения конфигурации
            newOscillConfig[1] = (ushort)nowScopeCount;
            newOscillConfig[2] = (ushort)nowOscFreq;
            newOscillConfig[3] = nowHystory;
            newOscillConfig[4] = (ushort)nowMaxChannelCount;
            newOscillConfig[5] = (ushort)(8192.0 / nowScopeCount);
            newOscillConfig[6] = CalcOscilChNumExp(nowScopeCount);
            newOscillConfig[7] = CalcOscilCountRound(nowScopeCount);
            newOscillConfig[8] = CalcOscilCountInc(nowMaxChannelCount,nowScopeCount);
            if (enaScopeCheckBox.Checked)
            {
                newOscillConfig[9] = 0x0001;    //Осциллограф включен
            }
            else
            {
                newOscillConfig[9] = 0x0000;
            }
            
            newOscillConfig[10] = 0x0000;
            newOscillConfig[11] = 0x0000;
            newOscillConfig[12] = 0x0000;
            newOscillConfig[13] = 0x0000;
            newOscillConfig[14] = 0x0000;

            List<ushort> l = CalcOscParamList();
            int i;
            for (i = 0; i < 16; i++)
            {
                if (i < l.Count) { newOscillConfig[15 + i] = l[i]; } else { newOscillConfig[15 + i] = 0; }
            }
            newOscillConfig[31] = 0x0001;//Флаг изменения конфигурации

        }

        private void WriteConfigToSystem()
        {
            writeConfigStep = 0;
            CalcNewOscillConfig();
            WritePartConfigToSystem();
        }

        private void WritePartConfigToSystem()
        {
            ushort[] partParam = new ushort[8];
            int i;
            for (i = 0; i <  8; i++)
            {
                partParam[i] = newOscillConfig[i + writeConfigStep * 8];
            }
            serialPort.SetDataRTU((ushort)(0x20 + ScopeSysType.ParamLoadDataAddr + writeConfigStep * 8), EndWriteConfig, RequestPriority.High, partParam);
        }

        //public void EndRequest(object sender, EventArgs e)
        void EndWriteConfig(bool DataOk, ushort[] ParamRTU)
        {
            if (!DataOk)
            {
                if (this.Visible)
                {
                    MessageBox.Show("Ошибка связи!", "Настройка осциллографа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LinkErrorInvoke();
            }
            else
            {
                writeConfigStep++;
                if (writeConfigStep < 4) { WritePartConfigToSystem(); }
                else
                {
                    MessageBox.Show("Конфигурация осциллографа была изменена!","Настройка осциллографа",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    ScopeConfig.ChangeScopeConfig = true;
                }
            }
        }
        
        private void writeToSystemBtn_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            { MessageBox.Show("Соединение не с системой не установлено!", "Настройка осциллографа", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (MessageBox.Show("Изменить конфигурацию осциллографа?\n" +
                                "Все текущие осциллограммы будут удалены из памяти системы!",
                                "Настройка осциллографа", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Stop
                                ) != System.Windows.Forms.DialogResult.Yes
                ) { return; }

            WriteConfigToSystem();

        }


        //*************ЗАКРЫТИЕ ФОРМЫ, ОСВОБОЖДЕНИЕ РЕСУРСОВ *************************************************//
        //****************************************************************************************************//
        //****************************************************************************************************//
        private void reloadBtn_Click(object sender, EventArgs e)
        {

        }

        //***************************Invok и****************************************************//

        delegate void NoParamDelegate();
        private void LinkError()
        {
            this.Close();
        }
        private void LinkErrorInvoke()
        {
            try
            {
                Invoke(new NoParamDelegate(LinkError), null);
            }
            catch { }
        }











    }
}
