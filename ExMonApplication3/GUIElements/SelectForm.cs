using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUIElements
{
    public partial class SelectForm : Form
    {
        public static Size  FormSize = new Size(300, 300);
        public static Font  ButtonFont = new Font("Arial", 12, FontStyle.Bold);
        public static Font  TitlFont = new Font("Arial", 14, FontStyle.Bold);
        public static Color ButtonDisaColor = Color.LightGray;
        public static int ButtonHeight = 40;


        Button[] buttons = new Button[4];
        Color enaColor;

        int selectedIndex = -1;
        public int SelectedIndex
        {
            get { return selectedIndex; }
        }


        public SelectForm(string Titl, Color EnaColor,int SelectedIndex, params string[] ButtonTexts)
        {
            InitializeComponent();
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            label1.Height = (int)(ButtonHeight * 0.8);
            enaColor = EnaColor;

            this.Size = FormSize;
            for (int i = 0; i < Math.Min(buttons.Length,ButtonTexts.Length); i++)
            {
                buttons[i].Height = ButtonHeight;
                buttons[i].Tag = i;
                buttons[i].Text = ButtonTexts[i];
                buttons[i].Font = ButtonFont;
                buttons[i].BackColor = ButtonDisaColor;
                buttons[i].Click += new EventHandler(ButtonClick);
            }

            for (int i = Math.Min(buttons.Length, ButtonTexts.Length); i < 4; i++)
            {
                buttons[i].Visible = false;
                this.Height = this.Height - ButtonHeight - button1.Margin.Top - button1.Margin.Bottom;
            }
            
            button5.Height = button6.Height = ButtonHeight;
            button5.Font = button6.Font = ButtonFont;
            button5.BackColor = button6.BackColor = ButtonDisaColor;

            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Font = TitlFont;
            label1.Text = Titl;
            this.selectedIndex = Math.Min(SelectedIndex, ButtonTexts.Length - 1);
            buttons[selectedIndex].BackColor = EnaColor;
        }
        private void ButtonClick(object sender, EventArgs e)
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

            if (t > buttons.Length - 1)
            {
                return;
            }

            buttons[selectedIndex].BackColor = ButtonDisaColor;
            selectedIndex = t;
            buttons[selectedIndex].BackColor = enaColor;
        }
    }
}
