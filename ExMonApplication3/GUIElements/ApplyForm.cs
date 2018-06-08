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
    public partial class ApplyForm : Form
    {
        public static Color ButtonColor = Color.LightGray;
        public static Font ButtonFont = new Font("Arial", 12, FontStyle.Bold);
        public static Font LabelFont = new Font("Arial", 14);
        public static Size FormSize = new Size(600, 150);
        public static string YesString = "Да";
        public static string NoString = "Нет";

        public ApplyForm(string MessageString)
        {
            InitializeComponent();
            this.Size = FormSize;
            label1.Font = LabelFont;
            button1.Font = button2.Font = ButtonFont;
            button1.BackColor = button2.BackColor = ButtonColor;
            button1.Text = YesString;
            button2.Text = NoString;
            label1.Text = MessageString;
        }
    }
}
