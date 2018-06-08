using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextLibrary;
using System.Xml.Linq;
using FormatsConvert;

namespace WindowsStructs
{
    public partial class WarningConfigForm : Form
    {
        AppTexts appTexts;
        string loadFromOldFileString = "";

        public WarningConfigForm(string Titl, Icon FormIcon, AppTexts AppTexts, string LoadFromOldFileString)
        {
            InitializeComponent();

            Text = Titl;
            Icon = FormIcon;
            warningSelect21.Titl = Titl;
            warningSelect21.Icon = FormIcon;
            appTexts = AppTexts;
            loadFromOldFileString = LoadFromOldFileString;

        }

        public void SetWarningParams(List<WarningParam> WarningParams)
        {
            warningSelect21.SetWarningParams(WarningParams);
        }

        public List<WarningParam> GetWarningParams()
        {
            return warningSelect21.GetWarningParams();
        }


        //***********************************************************************************************//
        //***********************************************************************************************//
        //***********************************************************************************************//
        private void loadOldStyleButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = appTexts.ParameterName(102);
            ofd.DefaultExt = "*.xml";

            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            XDocument document;
            XElement element;
            int warnigsCount;
            List<WarningParam> loadWarningParams = new List<WarningParam>();
            try
            {
                document = XDocument.Load(ofd.FileName);

            }

            catch
            {
                MessageBox.Show(appTexts.ParameterName(103), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                element = document.Root.Element(loadFromOldFileString);
                warnigsCount = Convert.ToInt16(element.Attribute("CountWord").Value.ToString(), 10);
            }
            catch
            {
                MessageBox.Show(appTexts.ParameterName(103), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            for (int i = 0; i < warnigsCount; i++)
            {
                try
                {
                    WarningParam wp = new WarningParam("");
                    string str1 = element.Attribute("EventPos" + (i).ToString()).Value.ToString();
                    wp.EventPosAddr = (ushort)ConvertFuncs.StrToShort(str1);
                    for (int i2 = 0; i2 < 16; i2++)
                    {
                        wp.Names[i2] = element.Attribute("Line" + (i*16+i2).ToString()).Value.ToString();
                    }
                    loadWarningParams.Add(wp);
                }
                catch
                {
                    MessageBox.Show(appTexts.ParameterName(103), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            warningSelect21.SetWarningParams(loadWarningParams);

        }

    }
}
