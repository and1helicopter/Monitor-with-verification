using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using TextLibrary;
using System.Collections;
using FormatsConvert;

namespace WindowsStructs
{
    public partial class EventCodesForm : Form
    {
        AppTexts appTexts;
        public EventCodesForm(AppTexts AppTexts, Hashtable EventCodes)
        {
            InitializeComponent();
            appTexts = AppTexts;
            this.Text = AppTexts.ParameterName(76);
            dataGridView1.Columns[0].HeaderText = AppTexts.ParameterName(77);
            dataGridView1.Columns[1].HeaderText = AppTexts.ParameterName(78);
            
            string[] keys = EventCodes.Keys.Cast<string>().ToArray();
            Array.Sort(keys);

            foreach (string s in keys)
            {
                object[] values = { s, EventCodes[s].ToString()  };
                dataGridView1.Rows.Add(values);
            }
        }

        public Hashtable NewEventCodes { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            NewEventCodes = new Hashtable();

            if (MessageBox.Show("Внести изменения в профиль?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                DialogResult = System.Windows.Forms.DialogResult.No;
                return;
            }


            try
            {
                for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
                {
                    short u = ConvertFuncs.StrToShort(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    string st1 = "0x" + u.ToString("X4");
                    string st2 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    NewEventCodes.Add(st1, st2);
                    
                }
            }
            catch
            {
                MessageBox.Show("Неправильно заданы коды события!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }

        //******************ЗАГРУЗКА ИЗ ФАЙЛА СТАРОГО ФОРМАТА**********************************//
        //*************************************************************************************//
        //*************************************************************************************//
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
            int eventCount;
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
                element = document.Root.Element("EventLogSetup");
                eventCount = Convert.ToInt16(element.Attribute("Count").Value.ToString(), 10);
            }
            catch
            {
                MessageBox.Show(appTexts.ParameterName(103), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Hashtable loadEventTypes = new Hashtable();

            for (int i = 0; i < eventCount; i++)
            {
                try
                {
                    element = document.Root.Element("EventType"+(i+1).ToString());
                    string str1 = element.Attribute("Code").Value.ToString();
                    string str2 = element.Attribute("Name").Value.ToString();

                    loadEventTypes.Add(str1, str2);
                }
                catch
                {
                    MessageBox.Show(appTexts.ParameterName(103), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            dataGridView1.Rows.Clear();
            string[] keys = loadEventTypes.Keys.Cast<string>().ToArray();
            Array.Sort(keys);

            foreach (string s in keys)
            {
                object[] values = { s, loadEventTypes[s].ToString() };
                dataGridView1.Rows.Add(values);
            }

        }
    }
}
