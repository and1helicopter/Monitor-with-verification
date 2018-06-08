using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextLibrary;
using WindowsStructs;
using UniSerialPort;
using System.IO;
using FormatsConvert;


namespace StandartScreens
{
    public partial class EventLogForm : StandartScreenTemplateForm
    {
        AppTexts appTexts;
        SystemConfiguration systemConfiguration;
        AsynchSerialPort serialPort;
        EventLogLoader eventLogLoader;
        string fileName = "";


        public EventLogForm(AppTexts AppTexts, AsynchSerialPort AsynchSerialPort, SystemConfiguration SystemConfiguration)
        {
            InitializeComponent();
            this.Text = AppTexts.ParameterName(99);
            loadEventButton.Text = AppTexts.ParameterName(100);
            openFileButton.ToolTipText = AppTexts.ParameterName(105);
            loadSensorPanelBtn.ToolTipText = AppTexts.ParameterName(109);
            appTexts = AppTexts;
            serialPort = AsynchSerialPort;
            systemConfiguration = SystemConfiguration;
        }

        private void loadEventButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "*.xml";
            sfd.Filter = appTexts.ParameterName(102);
            sfd.FileName = DateTime.Now.Day.ToString("D2") + "." + DateTime.Now.Month.ToString("D2") + "." + DateTime.Now.Year.ToString("D4") + " " +
                                 DateTime.Now.Hour.ToString("D2") + "." + DateTime.Now.Minute.ToString("D2") + "." + DateTime.Now.Second.ToString("D2") +
                                 " (" + appTexts.ParameterName(99) + ")";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                loadEventButton.Enabled = false;
                fileName = sfd.FileName;

                progressBar1.Value = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = systemConfiguration.EventCount;
                eventLogLoader = new EventLogLoader(serialPort,systemConfiguration.EventBlockCount,systemConfiguration.LoadEventDataAddr, systemConfiguration.LoadEventAddr, systemConfiguration.EventCount);
                eventLogLoader.LoadindComplete += LoadingComplete;
                eventLogLoader.ProcessUpdate += LoadingProcess;
                eventLogLoader.StartLoading();
            }
        }

        private void LoadingComplete(bool Result)
        {
            if (Result)
            {
                if (!this.Visible) { return; }
                EventLogFile eventLogFile = new EventLogFile(systemConfiguration, appTexts, eventLogLoader.EventData);
                eventLogFile.CreateEventlogXMLFile(fileName);
                EventlogViewerForm elvf = new EventlogViewerForm(fileName, appTexts);
                elvf.Show();
                loadEventButton.Enabled = true; 
            }
            else
            {
                MessageBox.Show(appTexts.ParameterName(101), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                loadEventButton.Enabled = true;
            }
        }

        private void LoadingProcess(int Value)
        {
            progressBar1.Value = Value;
        }

        public void CancelLoad()
        {
            if (eventLogLoader != null)
            {
                eventLogLoader.CancelLoad();
            }
            loadEventButton.Enabled = true;
            progressBar1.Value = 0;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = appTexts.ParameterName(102);

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EventlogViewerForm elvf = new EventlogViewerForm(ofd.FileName, appTexts);
                elvf.Show();
                loadEventButton.Enabled = true;
            }
        }

        private void loadSensorPanelBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
           // ofd.Filter = appTexts.ParameterName(102);

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<ushort[]> loadEventDataPanel = new List<ushort[]>();
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                try
                {
                    for (int i1 = 0; i1 < systemConfiguration.EventCount; i1++)
                    {
                        ushort[] us = new ushort[systemConfiguration.EventBlockCount * 32];
                        for (int i2 = 0; i2 < us.Length; i2++)
                        {
                            us[i2] = (ushort)ConvertFuncs.StrToShort(sr.ReadLine());
                        }
                        loadEventDataPanel.Add(us);
                    }
                    fs.Close();
                    sr.Close();
                }
                catch
                {
                    MessageBox.Show(appTexts.ParameterName(110), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = "*.xml";
                sfd.Filter = appTexts.ParameterName(102);
                sfd.FileName = DateTime.Now.Day.ToString("D2") + "." + DateTime.Now.Month.ToString("D2") + "." + DateTime.Now.Year.ToString("D4") + " " +
                                     DateTime.Now.Hour.ToString("D2") + "." + DateTime.Now.Minute.ToString("D2") + "." + DateTime.Now.Second.ToString("D2") +
                                     " (" + appTexts.ParameterName(99) + ")";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    EventLogFile eventLogFile = new EventLogFile(systemConfiguration, appTexts, loadEventDataPanel);
                    eventLogFile.CreateEventlogXMLFile(sfd.FileName);
                    EventlogViewerForm elvf = new EventlogViewerForm(sfd.FileName, appTexts);
                    elvf.Show();
                }
                
            }
        }

        public void EnableForm(bool FormEnabled)
        {
            loadEventButton.Enabled = FormEnabled;
        }
    }
}
