using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUIElements
{
    public partial class LabelButton : UserControl
    {
        public string Title
        {
            get
            {
                return label1.Text;
            }

            set
            {
                label1.Text = value;
            }
        }

        public Image Image
        {
            get
            {
                return button1.Image;
            }
            set
            {
                button1.Image = value;
            }

        }

        public Padding ButtonMargin
        {
            get
            {
                return button1.Margin;
            }
            set
            {
                button1.Margin = value;
            }

        }

        public Color ButtonColor
        {
            get
            {
                return button1.BackColor;
            }
            set
            {
                button1.BackColor = value;
            }
        }

        public event EventHandler ButtonClick;


        public LabelButton()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ButtonClick != null) { ButtonClick(sender, e); }
        }
    }
}
