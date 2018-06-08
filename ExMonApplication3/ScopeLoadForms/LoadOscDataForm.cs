using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using UniSerialPort;
using FormatsConvert;
using TextLibrary;
using System.Diagnostics;

namespace ScopeLoadForms
{
    public partial class LoadOscDataForm : Form
    {
        AsynchSerialPort serialPort;
        ScopeConfig scopeConfig { get; set; }
        int loadOscNum = 0;
        ScopeLoader scopeLoader;
        List<ushort[]> downloadedData;
        string fileName = "";

        public LoadOscDataForm(AsynchSerialPort AsynchSerialPort, string Titl, ScopeConfig ScopeConfig, int LoadOscNum, AppTexts AppTexts)
        {
            InitializeComponent();
            serialPort = AsynchSerialPort;
            this.Text = Titl;
            this.scopeConfig = ScopeConfig;
            loadOscNum = LoadOscNum;
            InitLoadOscillAsynch();
            button1.Text = AppTexts.ParameterName(27);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            scopeLoader.CancelLoad();
        }
        private void LoadScopeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            scopeLoader.CancelLoad();
        }

        void InitLoadOscillAsynch()
        {
            scopeLoader = new ScopeLoader(serialPort, scopeConfig, loadOscNum, RequestPriority.High);
            scopeLoader.OnProcessUpdate += new ScopeLoader.ProcessUpdater(scopeLoader_OnProcessUpdate);
            scopeLoader.OnLoadingComplete +=new ScopeLoader.LoadingCompleter(scopeLoader_OnLoadingComplete);
        }
        void scopeLoader_OnProcessUpdate(int Value)
        {
            progressBar1.Value = Value;
        }
        void scopeLoader_OnLoadingComplete(bool LoadingOk)
        {
            if (!LoadingOk)
            {
                Close();
                return;
            }

            downloadedData = scopeLoader.DownloadedData;
            CreateFileAsynch();
            Close();
        }

        void CreateFileAsynch()
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.DefaultExt = "txt";
            ofd.Filter = "Текстовый файл|*.txt";
            string str = this.Text;
            str = str.Replace("/", ".");
            str = str.Replace(":", ".");
            ofd.FileName = str;

            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) { this.Close(); return; }

            ScopeFile scopeFile = new ScopeFile(ofd.FileName, downloadedData, scopeConfig, this.Text);
            fileName = ofd.FileName;
            scopeFile.OnCreateComplete +=new ScopeFile.CreatingCompleter(scopeFile_OnCreateComplete);

        }
        void scopeFile_OnCreateComplete(bool CreateOk)
        {
            if (CreateOk)
            {
                ExecuteScopeView(fileName);
            }
        }

        private void ExecuteScopeView(string FileName)
        {
           Process proc = new Process();
            proc.StartInfo.FileName = (Path.GetDirectoryName(Application.ExecutablePath) + "/ScopeViewer.exe");
            proc.StartInfo.Arguments = "\"" + FileName + "\"";
            proc.Start();
        }


    }
}
