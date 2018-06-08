using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using StandartScreens;
using UniSerialPort;

namespace ExMonApplication3
{
    public partial class VerificationForm : StandartScreenTemplateForm
    {
        AsynchSerialPort _serialPort;
        bool _portBusy;

        readonly object[] _bit =
        {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"
        };

        private readonly List<Info> _status1 = new List<Info>()
        {
            new Info("0x0120", "7", "0x0140", "0"),
            new Info("0x0120", "6", "0x0140", "1"),
            new Info("0x0120", "5", "0x0140", "2"),
            new Info("0x0120", "4", "0x0140", "3"),
            new Info("0x0120", "3", "0x0140", "4"),
            new Info("0x0120", "2", "0x0140", "5"),
            new Info("0x0120", "1", "0x0140", "6"),
            new Info("0x0120", "0", "0x0140", "7"),
            new Info("0x0120", "8", "0x0140", "8"),
            new Info("0x0120", "9", "0x0140", "9"),
            new Info("0x0120", "10", "0x0140", "10"),
            new Info("0x0120", "11", "0x0140", "11"),
            new Info("0x0120", "12", "0x0140", "12"),
            new Info("0x0120", "13", "0x0140", "13"),
            new Info("0x0120", "14", "0x0140", "14"),
            new Info("0x0120", "15", "0x0140", "15")
        };

        private readonly List<Info> _status2 = new List<Info>()
        {
            new Info("0x0124", "7", "0x0144", "0"),
            new Info("0x0124", "6", "0x0144", "1"),
            new Info("0x0124", "5", "0x0144", "2"),
            new Info("0x0124", "4", "0x0144", "3"),
            new Info("0x0124", "3", "0x0144", "4"),
            new Info("0x0124", "2", "0x0144", "5"),
            new Info("0x0124", "1", "0x0144", "6"),
            new Info("0x0124", "0", "0x0144", "7"),
            new Info("0x0128", "8", "0x0144", "8"),
            new Info("0x0128", "9", "0x0144", "9"),
            new Info("0x0128", "10", "0x0144", "10"),
            new Info("0x0128", "11", "0x0144", "11"),
            new Info("0x0128", "12", "0x0144", "12"),
            new Info("0x0128", "13", "0x0144", "13"),
            new Info("0x0128", "14", "0x0144", "14"),
            new Info("0x0128", "15", "0x0144", "15")
        };

        private readonly List<Info> _status3 = new List<Info>()
        {
            new Info("0x012C", "7", "0x0148", "0"),
            new Info("0x012C", "6", "0x0148", "1"),
            new Info("0x012C", "5", "0x0148", "2"),
            new Info("0x012C", "4", "0x0148", "3"),
            new Info("0x012C", "3", "0x0148", "4"),
            new Info("0x012C", "2", "0x0148", "5"),
            new Info("0x012C", "1", "0x0148", "6"),
            new Info("0x012C", "0", "0x0148", "7"),
            new Info("0x012C", "8", "0x0148", "8"),
            new Info("0x012C", "9", "0x0148", "9"),
            new Info("0x012C", "10", "0x0148", "10"),
            new Info("0x012C", "11", "0x0148", "11"),
            new Info("0x012C", "12", "0x0148", "12"),
            new Info("0x012C", "13", "0x0148", "13"),
            new Info("0x012C", "14", "0x0148", "14"),
            new Info("0x012C", "15", "0x0148", "15")
        };

        private List<Info> _statusCurrent = new List<Info>();

        public VerificationForm(AsynchSerialPort AsynchSerialPort)
        {
            InitializeComponent();

            _serialPort = AsynchSerialPort;
            SetGrid(_status1, false);
        }

        private void SetGrid(List<Info> list, bool editable)
        {
            ChanneldataGridView.Rows.Clear();
            numericUpDown2.Value = 0;
            _statusCurrent = list;

            ChanneldataGridView.EditMode = editable?DataGridViewEditMode.EditOnKeystrokeOrF2:DataGridViewEditMode.EditProgrammatically;
            numericUpDown2.Enabled = editable;

            foreach (var itemInfo in list)
            {
                ChanneldataGridView.Rows.Add(itemInfo.AddrOutput, itemInfo.BitOutput, itemInfo.AddrInput, itemInfo.BitInput);
                ChanneldataGridView.Rows[ChanneldataGridView.RowCount - 1].HeaderCell.Value = (ChanneldataGridView.RowCount).ToString();
                numericUpDown2.Value++;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                if (ChanneldataGridView.RowCount > numericUpDown2.Value)
                    ChanneldataGridView.Rows.RemoveAt(ChanneldataGridView.RowCount - 1);
                else if(ChanneldataGridView.RowCount < numericUpDown2.Value)
                {
                    ChanneldataGridView.Rows.Add("0x0000", _bit[0], "0x0000", _bit[0]);

                    var index = ChanneldataGridView.RowCount - 1;
                    ChanneldataGridView.Rows[index].HeaderCell.Value = (index + 1).ToString();
                }
            }
        }

        private class Info
        {
            public string AddrInput { get; }
            public string BitInput { get; }
            public string AddrOutput { get; }
            public string BitOutput { get; }

            public Info(string addrInput, string bitInput, string addrOutput, string bitOutput)
            {
                AddrInput = addrInput;
                BitInput = bitInput;
                AddrOutput = addrOutput;
                BitOutput = bitOutput;
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            SetGrid(_status1, false);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            SetGrid(_status2, false);
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            SetGrid(_status3, false);
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            SetGrid(_statusCurrent, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestListInput.Clear();
            foreach (var current in _statusCurrent)
            {
                if (TestListInput.ContainsKey(int.Parse(current.AddrInput.Substring(2), NumberStyles.HexNumber)))
                {
                    TestListInput[int.Parse(current.AddrInput.Substring(2), NumberStyles.HexNumber)].Add(int.Parse(current.BitInput), false);
                }
                else
                {
                    TestListInput.Add(int.Parse(current.AddrInput.Substring(2), NumberStyles.HexNumber), new Dictionary<int, bool> { { int.Parse(current.BitInput), false } });
                }
            }
        }

        Dictionary<int, Dictionary<int, bool>> TestListInput = new Dictionary<int, Dictionary<int, bool>>();

        
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!_serialPort.IsOpen) { return; }
            if (!this.Visible) { return; }
            if (_portBusy) { return; }
            _portBusy = true;
            //_serialPort.SetDataRTU((ushort)(startAddr + 1), null, RequestPriority.Normal, maskOR, maskAND);
            //_serialPort.GetDataRTU((ushort)(startAddr + 3), 1, DataRecieved);
        }

        private void DataRecieved(bool DataOk, ushort[] ParamRTU)
        {
            //    if (InvokeRequired)
            //    {
            //        Invoke(new AsynchSerialPort.DataRecievedRTU(DataRecieved), DataOk, ParamRTU);
            //    }
            //    else
            //    {

            //        portBusy = false;
            //        if (DataOk)
            //        {
            //            ushort u = ParamRTU[0];
            //            if (invert)
            //            {
            //                u = (ushort)(u ^ 0xFFFF);
            //            }
            //            for (int i = 0; i < 16; i++)
            //            {
            //                if (ConvertFuncs.GetBit(u, i))
            //                {
            //                    lampLabels[i].BackColor = Color.LightGreen;
            //                }
            //                else
            //                {
            //                    lampLabels[i].BackColor = Color.White;
            //                }
            //            }
            //        }

            //    }
        }

    }
}
