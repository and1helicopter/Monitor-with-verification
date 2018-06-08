using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using TextLibrary;
using FormatsConvert;

namespace WindowsStructs
{
    public partial class DigitPlateConfigForm : Form
    {
        AppTexts appTexts;

        public List<DigitPlate> DigitPlates
        {
            get
            {
                return digitPlateSelect1.DigitPlates;
            }
            set
            {
                digitPlateSelect1.SetDigitPlate(value);
            }
        }

        public DigitPlateConfigForm(AppTexts AppTexts)
        {
            InitializeComponent();
            appTexts = AppTexts;
        }

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
            int digitCount;
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
                element = document.Root.Element("Digits");
                digitCount = Convert.ToInt16(element.Attribute("Count").Value.ToString(), 10);
            }
            catch
            {
                MessageBox.Show(appTexts.ParameterName(103), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            List<DigitPlate> loadDigitPlates = new List<DigitPlate>();

            for (int i = 0; i < digitCount; i++)
            {
               try
                {
                    element = document.Root.Element("Digit" + (i + 1).ToString());
                    string str1 = element.Attribute("Title").Value.ToString();
                    string str2 = element.Attribute("EventPos").Value.ToString();
                    string str3 = element.Attribute("Addr1").Value.ToString();
                    string str4 = element.Attribute("Type").Value.ToString();
                    string str5 = element.Attribute("Invert").Value.ToString();
                    string str6 = element.Attribute("UseMask").Value.ToString();

                    DigitPlate dp = new DigitPlate(str1);
                    dp.EventStructAddr = (ushort)ConvertFuncs.StrToShort(str2);
                    dp.StartAddr = (ushort)(ConvertFuncs.StrToShort(str3) - 1);
                    if (str4 == "0")
                    {
                        dp.DigitType = DigitType.DigInput;
                    }
                    else
                    {
                        dp.DigitType = DigitType.DigOutput;
                    }
                    dp.Invert = (str5 != "0");

                    dp.UseMask = (ushort)ConvertFuncs.StrToShort(str6);
                    for (int i2 = 0; i2 < 16; i2++)
                    {
                        dp.DigitNames[i2] = element.Attribute("Line"+i2.ToString()).Value.ToString();
                    }
                    
                    loadDigitPlates.Add(dp);
                    
                }
                catch
                {
                    MessageBox.Show(appTexts.ParameterName(103), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DigitPlates = loadDigitPlates;

        }
    }
}
