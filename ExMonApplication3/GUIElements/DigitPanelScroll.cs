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
    public partial class DigitPanelScroll : UserControl
    {
        Label[] lampLabels;
        Label[] nameLabels;

        public Color GreenColor { get; set; }
        int lineHeight = 27;
        int topPosition = 1;
        int count; //число строк
        int countName; //число строк с названиями
        ulong digitValue = 0;
        Font font;

        private void InitLabels(string[] digitNames)
        {
            countName = 0;
            count = digitNames.Length;
            lampLabels = new Label[count];
            nameLabels = new Label[count];
            int topPos = topPosition;
            int j =  1;
            int i = 0;
            for (int k = 0; k < count; k++)
            {

                if (digitNames[k].StartsWith("!!!"))
                {
                    Label title = new Label();

                    title.BorderStyle = BorderStyle.None;
                    title.Margin = new Padding(1, 1, 1, 1);
                    title.Left = 1;
                    title.Top = topPos;

                    title.Size = new Size(this.Width - SystemInformation.VerticalScrollBarWidth - title.Margin.Left - title.Margin.Right -2, lineHeight);
                    title.Text = digitNames[k].Substring(3);
                    title.AutoSize = false;
                    title.TextAlign = ContentAlignment.MiddleCenter;
                    title.Font = font;
                    this.Controls.Add(title);
                    topPos += lineHeight;
                    j = 1;
                    countName++;
                    continue;
                }
                lampLabels[i] = new Label();
                lampLabels[i].BorderStyle = BorderStyle.FixedSingle;
                lampLabels[i].BackColor = Color.White;
                lampLabels[i].Margin = new Padding(1, 1, 1, 1);
                lampLabels[i].Left = 1 + lampLabels[i].Margin.Left;
                lampLabels[i].Top = topPos;

                lampLabels[i].Size = new Size(lineHeight - lampLabels[i].Margin.Left - lampLabels[i].Margin.Right, lineHeight - lampLabels[i].Margin.Top - lampLabels[i].Margin.Bottom);
                this.Controls.Add(lampLabels[i]);


                nameLabels[i] = new Label();
                nameLabels[i].BorderStyle = BorderStyle.None;
                nameLabels[i].Margin = new Padding(1, 1, 1, 1);
                nameLabels[i].Left = lampLabels[i].Left + lampLabels[i].Margin.Left + lampLabels[i].Width + lampLabels[i].Margin.Right + nameLabels[i].Margin.Left;
                nameLabels[i].Top = topPos;

                nameLabels[i].Size = new Size(this.Width - SystemInformation.VerticalScrollBarWidth - 2 * lampLabels[i].Width, lineHeight - lampLabels[i].Margin.Top - lampLabels[i].Margin.Bottom);
                nameLabels[i].Text = j.ToString("D2") + " " + digitNames[k];
                nameLabels[i].AutoSize = false;
                nameLabels[i].TextAlign = ContentAlignment.MiddleLeft;
                nameLabels[i].Font = font;
                this.Controls.Add(nameLabels[i]);
                i++;
                topPos += lineHeight;
                j++;
            }

        }

        public DigitPanelScroll(string[] digitNames, Font font, int Width = 320, int Height = 400)
        {
            InitializeComponent();
            this.font = font;
            this.Width = Width;
            this.Height = Height;
            GreenColor = Color.Lime;
            lineHeight = Height / 17;
            topPosition = lineHeight / 4;
            InitLabels(digitNames);
        }

        public void UpdateDigits(ushort[] ParamRTU)
        {
            //if (digitValue == DigitWord)
            //{
            //    return;
            //}
            //digitValue = DigitWord;


            for (int j = 0; j < ParamRTU.Length; j++)
            {

                for (int i = 0; i < 16; i++)
                {

                    if (i + 16 * j >= lampLabels.Length - countName)
                        break;

                    if (ParamRTU[j].GetBit(i))
                    {
                        lampLabels[i + 16 * j].BackColor = GreenColor;
                    }
                    else
                    {
                        lampLabels[i + 16 * j].BackColor = Color.White;
                    }
                }
            }

        }
    }
}
