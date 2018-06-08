using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsStructs
{
    public partial class DigitPlateSetupForm : Form
    {
        public DigitPlateSetupForm(DigitPlate DigitPlate, int Index)
        {
            InitializeComponent();
            digitPlate = DigitPlate;
            Text = "Дискретный модуль №" + Index.ToString();
            digitPlateSetup1.SetDigitPlate(DigitPlate);
        }

        DigitPlate digitPlate;
        public DigitPlate DigitPlate { get { return digitPlate; } }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Внести изменения в профиль?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DigitPlate dp;
                if (digitPlateSetup1.GetDigitPlate(out dp))
                {
                    digitPlate = dp;
                    DialogResult = System.Windows.Forms.DialogResult.Yes;
                }
                else
                {
                    MessageBox.Show("Неправильно заданы параметры!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Отменить изменения в профиль?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = System.Windows.Forms.DialogResult.No;
            }
        }


    }
}
