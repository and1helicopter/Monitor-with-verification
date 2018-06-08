using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUIElements;
using System.Xml.Linq;
using System.Collections;
using TextLibrary;
using FormatsConvert;

namespace WindowsStructs
{
    public partial class MeasureParamsSetupForm : Form
    {
        AppTexts appTexts;

        List<MeasureParamPanel> measureParams = new List<MeasureParamPanel>();

        public MeasureParamsSetupForm(List<MeasureParam> MeasureParams, AppTexts AppTexts)
        {
            InitializeComponent();
            appTexts = AppTexts;
            foreach (MeasureParam mp in MeasureParams)
            {
                measureParams.Add(new MeasureParamPanel());
                flowLayoutPanel2.Controls.Add(measureParams[measureParams.Count - 1]);
                measureParams[measureParams.Count - 1].RemoveClick += new EventHandler(RemoveClick);
                measureParams[measureParams.Count - 1].ParameterName = mp.ParameterName;
                measureParams[measureParams.Count - 1].Addr = mp.Addr;
                measureParams[measureParams.Count - 1].Format = mp.Format;
            }

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            measureParams.Add(new MeasureParamPanel());
            flowLayoutPanel2.Controls.Add(measureParams[measureParams.Count - 1]);
            measureParams[measureParams.Count - 1].RemoveClick +=new EventHandler(RemoveClick);

        }

        private void RemoveClick(object sender, EventArgs e)
        {
            MeasureParamPanel measurePanel = (sender as MeasureParamPanel);
            if (measureParams.Contains(measurePanel))
            {
                measureParams.Remove(measurePanel);
            }

            if (flowLayoutPanel2.Controls.Contains(measurePanel))
            {
                flowLayoutPanel2.Controls.Remove(measurePanel);
            }

            measurePanel.Dispose();
        }

        List<MeasureParam> newMeasureParams = new List<MeasureParam>();

        public List<MeasureParam> NewMeasureParams
        {
            get { return newMeasureParams; }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            newMeasureParams = new List<MeasureParam>();
            foreach (MeasureParamPanel p in measureParams)
            {
                newMeasureParams.Add(new MeasureParam(p.ParameterName, p.Addr, p.Format));
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void openOldStyleButton_Click(object sender, EventArgs e)
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
            int measureCounts;
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
                element = document.Root.Element("MeasureParams");
                measureCounts = Convert.ToInt16(element.Attribute("Count").Value.ToString(), 10);
            }
            catch
            {
                MessageBox.Show(appTexts.ParameterName(103), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<MeasureParam> loadMeasureParams = new List<MeasureParam>();

            for (int i = 0; i < measureCounts; i++)
            {
                try
                {
                    element = document.Root.Element("MeasureParam" + (i + 1).ToString());
                    string str1 = element.Attribute("Name").Value.ToString() + ", " + element.Attribute("UnitName").Value.ToString();
                    string str2 = element.Attribute("Addr").Value.ToString();
                    short i2 = ConvertFuncs.StrToShort(str2);
                    string str3 = element.Attribute("Format").Value.ToString();
                    short i3 = ConvertFuncs.StrToShort(str3);
                    MeasureParam mp = new MeasureParam(str1, (ushort)i2, (ConvertFormats)i3);
                    loadMeasureParams.Add(mp);
                }
                catch
                {
                    MessageBox.Show(appTexts.ParameterName(103), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            flowLayoutPanel2.Controls.Clear();
            measureParams.Clear();

            foreach (MeasureParam mp in loadMeasureParams)
            {
                measureParams.Add(new MeasureParamPanel());
                flowLayoutPanel2.Controls.Add(measureParams[measureParams.Count - 1]);
                measureParams[measureParams.Count - 1].RemoveClick += new EventHandler(RemoveClick);
                measureParams[measureParams.Count - 1].ParameterName = mp.ParameterName;
                measureParams[measureParams.Count - 1].Addr = mp.Addr;
                measureParams[measureParams.Count - 1].Format = mp.Format;
            }

        }
    }
}
