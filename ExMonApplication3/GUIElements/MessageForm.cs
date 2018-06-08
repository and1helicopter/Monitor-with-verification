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
    public partial class MessageForm : Form
    {
        public MessageForm(string MessageString, string ButtonString = "Ok")
        {
            InitializeComponent();
            this.Size = ApplyForm.FormSize;
            label1.Font = ApplyForm.LabelFont;
            button1.Font = ApplyForm.ButtonFont;
            button1.BackColor = ApplyForm.ButtonColor;
            label1.Text = MessageString;
            button1.Text = ButtonString;
        }
    }
}
