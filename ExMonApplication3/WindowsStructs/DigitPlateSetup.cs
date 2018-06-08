using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormatsConvert;

namespace WindowsStructs
{
    public partial class DigitPlateSetup : UserControl
    {
        TextBox[] textBoxs = new TextBox[16];
        CheckBox[] checkBoxs = new CheckBox[16];

        public DigitPlateSetup()
        {
            InitializeComponent();

            for (int i = 0; i < 16; i++)
            {
                textBoxs[i] = new TextBox();
                textBoxs[i].Dock = DockStyle.Fill;
                tableLayoutPanel2.Controls.Add(textBoxs[i]);
                tableLayoutPanel2.SetRow(textBoxs[i], i);
                tableLayoutPanel2.SetColumn(textBoxs[i], 0);
            }
            for (int i=0;i<16;i++)
            {
                checkBoxs[i] = new CheckBox();
                checkBoxs[i].Dock = DockStyle.Fill;
                tableLayoutPanel2.Controls.Add(checkBoxs[i]);
                tableLayoutPanel2.SetColumn(checkBoxs[i], 1);
                tableLayoutPanel2.SetRow(checkBoxs[i], i);
                checkBoxs[i].Checked = true;
            }
        }

        public void SetDigitPlate(DigitPlate DigitPlate)
        {
            textBox1.Text = DigitPlate.Titl;
            textBox2.Text = "0x"+DigitPlate.StartAddr.ToString("X4");
            textBox3.Text = "0x" + DigitPlate.EventStructAddr.ToString("X4");

            ushort step = 1;
            for (int i = 0; i < 16; i++)
            {
                textBoxs[i].Text = DigitPlate.DigitNames[i];
                checkBoxs[i].Checked = ((step & DigitPlate.UseMask) != 0);
                step = (ushort)(step << 1);
            }

            if (DigitPlate.DigitType == DigitType.DigInput)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

            if (DigitPlate.Invert)
            {
                radioButton4.Checked = true;
            }
            else
            {
                radioButton3.Checked = true;
            }
        }

        public bool GetDigitPlate(out DigitPlate DigitPlate)
        {
            bool b = true;
            DigitPlate digitPlate = new DigitPlate();
            digitPlate.Titl = textBox1.Text;

            try
            {
                short u = ConvertFuncs.StrToShort(textBox2.Text);
                digitPlate.StartAddr = (ushort)u;
            }
            catch
            {
                b = false;
            }

            try
            {
                short u = ConvertFuncs.StrToShort(textBox3.Text);
                digitPlate.EventStructAddr = (ushort)u;
            }
            catch
            {
                b = false;
            }

            ushort step = 1;
            ushort value = 0;
            for (int i = 0; i < 16; i++)
            {
                digitPlate.DigitNames[i] = textBoxs[i].Text;
                if (checkBoxs[i].Checked) 
                {
                    value = (ushort)(value | step);
                }
                step = (ushort)(step << 1); 
            }

            digitPlate.UseMask = value;

            if (radioButton1.Checked)
            {
                digitPlate.DigitType = DigitType.DigInput;
            }
            else
            {
                digitPlate.DigitType = DigitType.DigOutput;
            }

            digitPlate.Invert = radioButton4.Checked;
            DigitPlate = digitPlate;
            return b;
        }


    }
}
