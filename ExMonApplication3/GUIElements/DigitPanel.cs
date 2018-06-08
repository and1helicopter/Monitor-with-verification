using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormatsConvert;

namespace GUIElements
{
    public partial class DigitPanel : UserControl
    {
        Label[] lampLabels = new Label[16];
        Label[] nameLabels = new Label[16];

        public Color GreenColor { get; set; }
        int lineHeight = 25;
        int topPosition = 1;

        ushort digitValue = 0;
        Font font;
        public DigitPanel(string[] digitNames, ushort startAddr, Font font, int Width = 320, int Height = 400)
        {
            InitializeComponent();
            this.font = font;
            this.Width = Width;
            this.Height = Height;
            GreenColor = Color.LightGreen;
            lineHeight = Height / 17;
            topPosition = lineHeight / 2;
            InitLampLabels();
            InitNameLabels(digitNames);
        }
        private void InitLampLabels()
        {
            int topPos = topPosition;
            for (int i = 0; i < 16; i++)
            {
                lampLabels[i] = new Label();
                lampLabels[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                lampLabels[i].BackColor = Color.White;
                lampLabels[i].Margin = new Padding(1, 1, 1, 1);
                lampLabels[i].Left = 1 + lampLabels[i].Margin.Left;
                lampLabels[i].Top = topPos;
                topPos = topPos + lineHeight;
                lampLabels[i].Size = new Size(lineHeight - lampLabels[i].Margin.Top - lampLabels[i].Margin.Bottom, lineHeight - lampLabels[i].Margin.Top - lampLabels[i].Margin.Bottom);
                this.Controls.Add(lampLabels[i]);
            }
        }

        private void InitNameLabels(string[] digitNames)
        {
            int topPos = topPosition;
            for (int i = 0; i < 16; i++)
            {
                nameLabels[i] = new Label();
                nameLabels[i].BorderStyle = System.Windows.Forms.BorderStyle.None;
                nameLabels[i].Margin = new Padding(1, 1, 1, 1);
                nameLabels[i].Left = lampLabels[i].Left + lampLabels[i].Margin.Left + lampLabels[i].Width + lampLabels[i].Margin.Right + nameLabels[i].Margin.Left;
                nameLabels[i].Top = topPos;
                topPos = topPos + lineHeight;
                nameLabels[i].Size = new Size(this.Width - 2 * lampLabels[i].Width, lineHeight - lampLabels[i].Margin.Top - lampLabels[i].Margin.Bottom);
                nameLabels[i].Text = digitNames[i];
                nameLabels[i].AutoSize = false;
                nameLabels[i].TextAlign = ContentAlignment.MiddleLeft;
                nameLabels[i].Font = font;
                this.Controls.Add(nameLabels[i]);
            }
        }

        public void UpdateDigits(ushort DigitWord)
        {
            if (digitValue == DigitWord)
            {
                return;
            }

            digitValue = DigitWord;

            for (int i = 0; i < 16; i++)
            {
                if (DigitWord.GetBit(i))
                {
                    lampLabels[i].BackColor = GreenColor;
                }
                else
                {
                    lampLabels[i].BackColor = Color.White;
                }

            }

        }
    }
}
