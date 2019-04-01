using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsStructs;
using UniSerialPort;
using TextLibrary;
using FormatsConvert;

namespace StandartScreens
{
    public partial class DigitPlateForm : StandartScreenTemplateForm
    {
        AsynchSerialPort serialPort;
        //AppTexts Texts;

        ushort startAddr;
        bool invert = false;
        Label[] lampLabels = new Label[16];
        Label[] nameLabels = new Label[16];
        CheckBox[] orCheckBoxs = new CheckBox[16];
        CheckBox[] andCheckBoxs = new CheckBox[16];
        CheckBox orAllCheckBox = new CheckBox();
        CheckBox andAllCheckBox = new CheckBox();

        ushort maskOR = 0x0000;
        ushort maskAND = 0xFFFF;

        bool portBusy = false;



        //************************************ ДИНАМИЧЕСКОЕ СОЗДАНИЕ КОНТРОЛОВ *******************************************//
        //****************************************************************************************************************//
        void CreateLampLabels()
        {
            for (int i = 0; i < 16; i++)
            {
                lampLabels[i] = new Label();
                lampLabels[i].Margin = new Padding(1);
                lampLabels[i].AutoSize = false;
                lampLabels[i].Dock = DockStyle.Fill;
                lampLabels[i].BorderStyle = BorderStyle.FixedSingle;
                lampLabels[i].BackColor = Color.White;
                tableLayoutPanel1.Controls.Add(lampLabels[i]);
                tableLayoutPanel1.SetRow(lampLabels[i], 2 + i % 8);
                tableLayoutPanel1.SetColumn(lampLabels[i], 4 * (i / 8));
            }

        }
        void CreateNameLabels(DigitPlate DigitPlate)
        {
            for (int i = 0; i < 16; i++)
            {
                nameLabels[i] = new Label();
                nameLabels[i].Text = DigitPlate.DigitNames[i];
                nameLabels[i].Margin = new Padding(1,5,1,5);
                //nameLabels[i].TextAlign = ContentAlignment.MiddleLeft;
                nameLabels[i].Dock = DockStyle.Fill;
                nameLabels[i].AutoEllipsis = true;
                tableLayoutPanel1.Controls.Add(nameLabels[i]);
                tableLayoutPanel1.SetRow(nameLabels[i], 2 + i % 8);
                tableLayoutPanel1.SetColumn(nameLabels[i], 1 + 4 * (i / 8));


            }

        }
        void CreateCheckBoxs()
        {
            for (int i = 0; i < 16; i++)
            {
                orCheckBoxs[i] = new CheckBox();
                orCheckBoxs[i].Margin = new Padding(15, 3, 3, 3);
                orCheckBoxs[i].Dock = DockStyle.Fill;
                orCheckBoxs[i].Tag = i;
                orCheckBoxs[i].CheckedChanged += new EventHandler(orCheckBox_CheckedChanged);
                tableLayoutPanel1.Controls.Add(orCheckBoxs[i]);
                tableLayoutPanel1.SetRow(orCheckBoxs[i], 2 + i % 8);
                tableLayoutPanel1.SetColumn(orCheckBoxs[i], 2 + 4 * (i / 8));


                andCheckBoxs[i] = new CheckBox();
                andCheckBoxs[i].Margin = new Padding(15, 3, 3, 3);
                andCheckBoxs[i].Dock = DockStyle.Fill;
                andCheckBoxs[i].Tag = i;
                andCheckBoxs[i].CheckedChanged += new EventHandler(andCheckBox_CheckedChanged);
                tableLayoutPanel1.Controls.Add(andCheckBoxs[i]);
                tableLayoutPanel1.SetRow(andCheckBoxs[i], 2 + i % 8);
                tableLayoutPanel1.SetColumn(andCheckBoxs[i], 3 + 4 * (i / 8));
            }

            {
                orAllCheckBox = new CheckBox();
                orAllCheckBox.Margin = new Padding(15, 3, 3, 3);
                orAllCheckBox.Dock = DockStyle.Fill;
                orAllCheckBox.CheckedChanged += new EventHandler(orAllCheckBox_CheckedChanged);
                tableLayoutPanel1.Controls.Add(orAllCheckBox);
                tableLayoutPanel1.SetRow(orAllCheckBox, 1);
                tableLayoutPanel1.SetColumn(orAllCheckBox, 2);
            }
            {
                andAllCheckBox = new CheckBox();
                andAllCheckBox.Margin = new Padding(15, 3, 3, 3);
                andAllCheckBox.Dock = DockStyle.Fill;
                andAllCheckBox.CheckedChanged += new EventHandler(andAllCheckBox_CheckedChanged);
                tableLayoutPanel1.Controls.Add(andAllCheckBox);
                tableLayoutPanel1.SetRow(andAllCheckBox, 1);
                tableLayoutPanel1.SetColumn(andAllCheckBox, 3);
            }
        }



        public DigitPlateForm(AsynchSerialPort AsynchSerialPort, AppTexts AppTexts, DigitPlate DigitPlate, bool EnableForce = true)
        {
            InitializeComponent();
            CreateLampLabels();
            CreateNameLabels(DigitPlate);
            if (true) CreateCheckBoxs();
            this.Text = DigitPlate.Titl;
            startAddr = DigitPlate.StartAddr;
            serialPort = AsynchSerialPort;
            invert = DigitPlate.Invert;
            label1.Text = label3.Text = AppTexts.ParameterName(73);
            label2.Text = label4.Text = AppTexts.ParameterName(74);
            label1.Visible = label2.Visible = label3.Visible = label4.Visible = (orCheckBoxs[0] != null);
            if (DigitPlate.DigitType == DigitType.DigOutput)
            {
                this.BackColor = Color.White;
            }
        }
        public new void Show()
        {
            portBusy = false;
            base.Show();
        }


        //*********************************** ИЗМЕНЕНИЕ МАСОК ДИСКРЕТНЫХ СИГНАЛОВ ****************************************//
        //****************************************************************************************************************//
        private void CalcDigitMasks()
        {
            ushort step = 1;
            ushort m1=0;
            ushort m2 =0;
            for (int i = 0; i < 16; i++)
            {
                if (orCheckBoxs[i].Checked)
                {
                    m1 = (ushort)(m1|step);
                }
                if (andCheckBoxs[i].Checked)
                {
                    m2 = (ushort)(m2 | step);
                }
                step = (ushort)(step << 1);
            }
            maskOR = m1;
            maskAND = (ushort)(m2 ^ 0xFFFF);
        }

        private void orAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (orAllCheckBox.Checked && andAllCheckBox.Checked)
                andAllCheckBox.Checked = false;

            foreach (var orCheckBox in orCheckBoxs)
            {
                orCheckBox.Checked = !orCheckBox.Checked;
            }
        }

        private void andAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (orAllCheckBox.Checked && andAllCheckBox.Checked)
                orAllCheckBox.Checked = false;

            foreach (var andCheckBox in andCheckBoxs)
            {
                andCheckBox.Checked = !andCheckBox.Checked;
            }
        }

        private void orCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                int index = (int)((sender as CheckBox).Tag);
                andCheckBoxs[index].Checked = false;
            }
            CalcDigitMasks();
        }

        private void andCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                int index = (int)((sender as CheckBox).Tag);
                orCheckBoxs[index].Checked = false;
            }
            CalcDigitMasks();
        }


        //**************************************ОБМЕН СИГНАЛАМИ***********************************************************//
        //****************************************************************************************************************//
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) { return; }
            if (!this.Visible) { return; }
            if (portBusy) { return; }
            portBusy = true;
            serialPort.SetDataRTU((ushort)(startAddr + 1), null, RequestPriority.Normal, maskOR, maskAND);
            serialPort.GetDataRTU((ushort)(startAddr + 3), 1, DataRecieved);
        }

        private void DataRecieved(bool DataOk, ushort[] ParamRTU, object param)
        {
            if (InvokeRequired)
            {
                Invoke(new AsynchSerialPort.DataRecievedRTU(DataRecieved), DataOk, ParamRTU, null);
            }
            else
            {
                portBusy = false;
                if (DataOk)
                {
                    ushort u = ParamRTU[0];
                    if (invert)
                    {
                        u = (ushort)(u ^ 0xFFFF);
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        if (ConvertFuncs.GetBit(u, i))
                        {
                            lampLabels[i].BackColor = Color.LightGreen;
                        }
                        else
                        {
                            lampLabels[i].BackColor = Color.White;
                        }
                    }
                }

            }
        }
    }
}
