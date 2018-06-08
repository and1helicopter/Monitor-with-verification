using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextLibrary;

namespace StandartScreens
{
    public partial class CompareReportForm : Form
    {
        ushort[,] modifyProfiles;
        ushort minStart, maxEnd;

        public CompareReportForm(ushort[] startAddrs, ushort[] endAddrs, List<ushort[]> profiles, string[] fileNames, AppTexts AppTexts)
        {
            InitializeComponent();
            this.Text = AppTexts.ParameterName(58);

            label1.Text = fileNames[0];
            label2.Text = fileNames[1];

            label7.Text = "0x" + startAddrs[0].ToString("X4");
            label8.Text = "0x" + startAddrs[1].ToString("X4");

            label9.Text = "0x" + endAddrs[0].ToString("X4");
            label10.Text = "0x" + endAddrs[1].ToString("X4");

            minStart = startAddrs[0];
            if (startAddrs[1] < minStart) { minStart = startAddrs[1]; }

            maxEnd = endAddrs[0];
            if (endAddrs[1] > maxEnd) { maxEnd = startAddrs[1]; }

            modifyProfiles = new ushort[2, maxEnd - minStart + 1];

            for (ushort i = minStart; i <= maxEnd; i++)
            {
                for (int i2 = 0; i2 < 2; i2++)
                {
                    if ((i >= startAddrs[i2]) && (i <= endAddrs[i2]))
                    {
                        modifyProfiles[i2, i - minStart] = profiles[i2][i - startAddrs[i2]];
                    }
                    else
                    {
                        modifyProfiles[i2, i - minStart] = 0;
                    }
                }
            }

            dataGridView1.Columns.Add("adrrCol", AppTexts.ParameterName(23));
            dataGridView1.Columns.Add("value1Col",  AppTexts.ParameterName(46)+" 1");
            dataGridView1.Columns.Add("value1Col", AppTexts.ParameterName(46) + " 2");

            for (int i = 0; i < (maxEnd - minStart + 1); i++)
            {
                object[] values = { "0x" + (i + minStart).ToString("X4"), "0x"+modifyProfiles[0, i].ToString("X4"), "0x"+modifyProfiles[1, i].ToString("X4") };
                if (!(((i + minStart) >= startAddrs[0]) && ((i + minStart) <= endAddrs[0]))) { values[1] = null; }
                if (!(((i + minStart) >= startAddrs[1]) && ((i + minStart) <= endAddrs[1]))) { values[2] = null; }


                if (modifyProfiles[0, i] != modifyProfiles[1, i])
                    dataGridView1.Rows.Add(values);
            }
        }
    }
}
