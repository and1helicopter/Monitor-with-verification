using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniSerialPort;
using TextLibrary;
using FormatsConvert;
using System.IO;

namespace StandartScreens
{
    public partial class DownloadSYMForm : StandartScreenTemplateForm
    {
        AsynchSerialPort serialPort;
        AppTexts appTexts;

        ushort startAddr;
        ushort endAddr;
        int blockCount;

        int loadIndex;
        ushort[] systemProfile = new ushort[0];

        public DownloadSYMForm(AsynchSerialPort AsynchSerialPort,AppTexts AppTexts)
        {
            InitializeComponent();
            serialPort = AsynchSerialPort;
            appTexts = AppTexts;
            Text = appTexts.ParameterName(17);
            label1.Text = appTexts.ParameterName(54);
            label2.Text = appTexts.ParameterName(55);
            button1.Text = appTexts.ParameterName(56);
            button2.Text = appTexts.ParameterName(57);
            button3.Text = appTexts.ParameterName(58);
        }
        public void SetEnable(bool LinkEnable)
        {
            button1.Enabled = button2.Enabled = LinkEnable;
        }

        //********************************************************************************************************//
        //********************************************************************************************************//
        bool CheckParams()
        {
            try
            {
                startAddr = (ushort)ConvertFuncs.StrToShort(textBox1.Text);
            }
            catch
            {
                MessageBox.Show(appTexts.ParameterName(60), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (startAddr > 0x3FFF)
            {
                MessageBox.Show(appTexts.ParameterName(60), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                endAddr = (ushort)ConvertFuncs.StrToShort(textBox2.Text);
            }
            catch
            {
                MessageBox.Show(appTexts.ParameterName(61), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (endAddr > 0x3FFF)
            {
                MessageBox.Show(appTexts.ParameterName(60), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            blockCount = endAddr - startAddr + 1;
            if (blockCount < 16) 
            {
                MessageBox.Show(appTexts.ParameterName(62), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }

            
            if ((blockCount % 16) != 0) 
            {
                MessageBox.Show(appTexts.ParameterName(62), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }
            blockCount = blockCount / 16;

            return true;
        }
        public new void Show()
        {
            button1.Enabled = button2.Enabled = button3.Enabled = true;
            base.Show();
        }

        //************************** ЧТЕНИЕ ДАННЫХ С ПЛАТЫ ******************************************************//
        //********************************************************************************************************//
        private void InitReadParamsRequest()
        {
            loadIndex = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = blockCount;
            systemProfile = new ushort[blockCount * 16];
            button1.Enabled = button2.Enabled = button3.Enabled = false;
            NewReadRequest();
        }
        private void NewReadRequest()
        {
            if ((serialPort.IsOpen)&&(this.Visible))
            {
                serialPort.GetDataRTU((ushort)(loadIndex * 16 + startAddr), 16, ReadDataRecieved);
            }
            else
            {
                button1.Enabled = button2.Enabled = button3.Enabled = true;
            }
        }
        private void ReadDataRecieved(bool DataOk, ushort[] ParamRTU, object param)
        {
            if (InvokeRequired)
            {
                Invoke(new AsynchSerialPort.DataRecievedRTU(ReadDataRecieved), DataOk, ParamRTU, null); 
            }
            else
            {
                if (!this.Visible)
                {
                    return;
                }

                if (DataOk)
                {
                    
                    ParamRTU.CopyTo(systemProfile, 16 * loadIndex);

                    loadIndex++;
                    progressBar1.Value = loadIndex;
                    if (loadIndex == blockCount)
                    {
                        InitSaveToFile();
                        button1.Enabled = button2.Enabled = button3.Enabled = true;
                    }
                    else
                    {
                        NewReadRequest();
                    }
                }
                else
                {
                    MessageBox.Show(appTexts.ParameterName(12), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Enabled = button2.Enabled = button3.Enabled = true;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckParams())
            {
                InitReadParamsRequest();
            }
        }
        private void InitSaveToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "*.sym";
            sfd.Filter = appTexts.ParameterName(59);

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CreateSYMFile(sfd.FileName);
            }
        }
        private void CreateSYMFile(string FileName)
        {
            StreamWriter sw;
            int i2, maxi, index;

            try
            { sw = File.CreateText(FileName); }
            catch
            {
                MessageBox.Show(appTexts.ParameterName(63), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                maxi = blockCount * 16 - 1;
                sw.WriteLine("0x" + startAddr.ToString("X4") + "  0x" + (startAddr + blockCount * 16 - 1).ToString("X4"));
                index = 0;

                for (int i = 0; i < blockCount; i++)
                {
                    sw.WriteLine("0x" + (startAddr + (i) * 16).ToString("X4")
                              + "  0x" + (startAddr + (i + 1) * 16 - 1).ToString("X4"));
                    for (i2 = 0; i2 < 4; i2++)
                    {
                        if (index == (maxi - 3))
                        {
                            sw.WriteLine(
                                            "0x"+systemProfile[index].ToString("X4")+", "+
                                            "0x" + systemProfile[index+1].ToString("X4") + ", " +
                                            "0x" + systemProfile[index+2].ToString("X4") + ", " +
                                            "0x" + systemProfile[index+3].ToString("X4") + "."
                                        );
                        }
                        else
                        {
                            sw.WriteLine(
                                            "0x" + systemProfile[index].ToString("X4") + ", " +
                                            "0x" + systemProfile[index + 1].ToString("X4") + ", " +
                                            "0x" + systemProfile[index + 2].ToString("X4") + ", " +
                                            "0x" + systemProfile[index + 3].ToString("X4") + ", "
                                        );
                        }
                        index = index + 4;
                    }
                }
            }
            catch
            {
                MessageBox.Show(appTexts.ParameterName(64), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sw.Close();
            MessageBox.Show(appTexts.ParameterName(65), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar1.Value = 0;
        }

        //************************** ЧТЕНИЕ ДАННЫХ ИЗ ФАЙЛА *****************************************************//
        //********************************************************************************************************//
        private bool LoadProfileFromFile(string filename)
        {
            ushort newStartAddr, tresh, newBlockCount;
            ushort index = 0;
            string line;
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    List<ushort> fileParams = new List<ushort>();
                    line = sr.ReadLine();
                    fileParams = ConvertFuncs.LineToUshorts(line);

                    if (fileParams.Count != 2)
                    {
                        MessageBox.Show(appTexts.ParameterName(66), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    newStartAddr = fileParams[0];
                    tresh = fileParams[1];
                    newBlockCount = (ushort)((tresh - newStartAddr + 1) / 16);
                    tresh = (ushort)(newStartAddr + 16 * newBlockCount - 1);

                    if (tresh != fileParams[1])
                    {
                        MessageBox.Show(appTexts.ParameterName(66), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    systemProfile = new ushort[16 * newBlockCount];

                    for (int i = 0; i < newBlockCount; i++)
                    {
                        line = sr.ReadLine();
                        fileParams = ConvertFuncs.LineToUshorts(line);
                        if (fileParams.Count != 2)
                        {
                            MessageBox.Show(appTexts.ParameterName(66), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        for (int i1 = 0; i1 < 4; i1++)
                        {
                            line = sr.ReadLine();
                            fileParams = ConvertFuncs.LineToUshorts(line);
                            if (fileParams.Count != 4)
                            {
                                MessageBox.Show(appTexts.ParameterName(66), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                            {
                                systemProfile[index++] = fileParams[0];
                                systemProfile[index++] = fileParams[1];
                                systemProfile[index++] = fileParams[2];
                                systemProfile[index++] = fileParams[3];
                            }
                        }
                    }

                }
            }
            catch
            {
                MessageBox.Show(appTexts.ParameterName(66), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            textBox1.Text = "0x"+newStartAddr.ToString("X4");
            textBox2.Text = "0x" + (newStartAddr + 16 * newBlockCount - 1).ToString("X4");
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.sym";
            ofd.Filter = appTexts.ParameterName(59);

            if (!(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK))
            {
                return;
            }

            if (!LoadProfileFromFile(ofd.FileName))
            {
                return;
            }

            if (!CheckParams())
            {
                return;
            }


            if ((blockCount * 16) != systemProfile.Length)
            {
                MessageBox.Show(appTexts.ParameterName(62), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(appTexts.ParameterName(67), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            InitWriteRequest();
        }
        private void InitWriteRequest()
        {
            loadIndex = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = blockCount;
            button1.Enabled = button2.Enabled = button3.Enabled = false;
            NewWriteRequest();
        }
        private void NewWriteRequest()
        {
            ushort[] writePartBuffer = new ushort[16];
            Array.Copy(systemProfile, loadIndex * 16, writePartBuffer, 0, 16);
            serialPort.SetDataRTU((ushort)(startAddr + loadIndex * 16), WriteDataRecieved, RequestPriority.Normal, writePartBuffer);
        }
        private void WriteDataRecieved(bool DataOk, ushort[] ParamRTU, object param)
        {
            if (InvokeRequired)
            {
                Invoke(new AsynchSerialPort.DataRecievedRTU(WriteDataRecieved), DataOk, ParamRTU, null);
            }
            else
            {
                if (!this.Visible)
                {
                    return;
                }

                if (DataOk)
                {
                    loadIndex++;
                    progressBar1.Value = loadIndex;
                    if (loadIndex == blockCount)
                    {
                        MessageBox.Show(appTexts.ParameterName(68), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button1.Enabled = button2.Enabled = button3.Enabled = true;
                    }
                    else
                    {
                        NewWriteRequest();
                    }
                }
                else
                {
                    MessageBox.Show(appTexts.ParameterName(14), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Enabled = button2.Enabled = button3.Enabled = true;
                }
            }
        }

        //************************** СРАВНЕНИЕ ФАЙЛОВ ***********************************************************//
        //********************************************************************************************************//
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.sym";
            ofd.Filter = appTexts.ParameterName(59);
            ofd.Multiselect = true;

            if (!(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK))
            {
                return;
            }

            if (ofd.FileNames.Length != 2)
            {
                MessageBox.Show(appTexts.ParameterName(69), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<ushort[]> fileProfiles = new List<ushort[]>();
            ushort[] startAddrs = new ushort[2];
            ushort[] endAddrs = new ushort[2];
            string[] fileNames = ofd.FileNames;

            if (!LoadProfileFromFile(fileNames[0]))
            {
                return;
            }
            else
            {
                if (!CheckParams())
                {
                    return;
                }

                startAddrs[0] = startAddr; 
                endAddrs[0] = endAddr;
                ushort[] array1 = new ushort[systemProfile.Length];
                systemProfile.CopyTo(array1, 0);
                fileProfiles.Add(array1);
            }

            if (!LoadProfileFromFile(fileNames[1]))
            {
                return;
            }
            else
            {
                if (!CheckParams())
                {
                    return;
                }

                startAddrs[1] = startAddr;
                endAddrs[1] = endAddr;
                ushort[] array1 = new ushort[systemProfile.Length];
                systemProfile.CopyTo(array1, 0);
                fileProfiles.Add(array1);
            }

            CompareReportForm crf = new CompareReportForm(startAddrs, endAddrs, fileProfiles, fileNames, appTexts);
            crf.Show();
        }

    }
}
