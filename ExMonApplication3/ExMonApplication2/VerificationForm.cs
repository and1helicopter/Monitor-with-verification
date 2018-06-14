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
        readonly AsynchSerialPort _serialPort;

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

        public VerificationForm(AsynchSerialPort asynchSerialPort)
        {
            InitializeComponent();

            _serialPort = asynchSerialPort;
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
            public int Value { get; set; }

            public Info(string addrInput, string bitInput, string addrOutput, string bitOutput)
            {
                AddrInput = addrInput;
                BitInput = bitInput;
                AddrOutput = addrOutput;
                BitOutput = bitOutput;
                Value = 0;
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

        readonly Dictionary<string, ushort> _testListInput = new Dictionary<string, ushort>();
        readonly Dictionary<string, ushort> _testListOutput = new Dictionary<string, ushort>();

        private int _cycle;

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            UpdateListBoxInvoke("Start...");
            //Формирование списка под ошибки
            foreach (var current in _statusCurrent)
            {
                current.Value = 0;
            }
            //Скрыть элеметы управления
            UpdateEnableToolsInvoke(false);

            //Установить параметры прогресс бара
            progressBar1.Maximum = (int)numericUpDown1.Value * 2;
            progressBar1.Value = 0;

            _testListInput.Clear();
            _testListOutput.Clear();
            foreach (var current in _statusCurrent)
            {
                if (!_testListInput.ContainsKey(current.AddrInput))
                    _testListInput.Add(current.AddrInput, 0);
                if (!_testListOutput.ContainsKey(current.AddrOutput))
                    _testListOutput.Add(current.AddrOutput, 0);
            }

            OneCycle();
        }

        private bool _statusSet;

        private void OneCycle()
        {
            if(_cycle < numericUpDown1.Value * 2)
                RequestOutput();
            else
            {
                _cycle = 0;
                MessageVerification();
            }
        }

        private void UpdateEnableTools(bool str)
        {
            numericUpDown1.Enabled = str;
            radioButton1.Enabled = str;
            radioButton2.Enabled = str;
            radioButton3.Enabled = str;
            radioButton4.Enabled = str;
        }

        private delegate void BoolParamDelegate(bool str);

        private void UpdateEnableToolsInvoke(bool str)
        {
            Invoke(new BoolParamDelegate(UpdateEnableTools), str);
        }

        private void UpdateListBox(string str)
        {
            listBox1.Items.Add(str);
            listBox1.Refresh();
        }

        private delegate void StringParamDelegate(string str);

        private void UpdateListBoxInvoke(string str)
        {
            Invoke(new StringParamDelegate(UpdateListBox), str);
        }

        private void MessageVerification()
        {
            bool errorStatus = _statusCurrent.Find(x => x.Value != 0) != null;

            if (errorStatus)
            {
                foreach (var current in _statusCurrent)
                {

                    if (current.Value != 0)
                    {
                        var str = current.AddrOutput + "[" + current.BitOutput + "]" + "-" + current.AddrInput + "[" + current.BitInput + "]" + "Error";
                        UpdateListBoxInvoke(str);
                    }
                }
                UpdateListBoxInvoke("Finish");
                MessageBox.Show(@"Error", @"Finish", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UpdateListBoxInvoke("No Error");
                UpdateListBoxInvoke("Finish");
                MessageBox.Show(@"Succsess", @"Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Отобразить элементы управления
            UpdateEnableToolsInvoke(true);
        }

        private IEnumerable<ushort> AddrInput()
        {
            foreach (var input in _testListInput)
            {
                yield return ushort.Parse(input.Key.Substring(2), NumberStyles.HexNumber);
            }
        }

        private IEnumerable<ushort> AddrOutput()
        {
            foreach (var output in _testListOutput)
            {
                yield return ushort.Parse(output.Key.Substring(2), NumberStyles.HexNumber);
            }
        }


        private void DataRecievedInput(bool dataOk, ushort[] paramRtu, object param)
        {
            if (dataOk)
            {
                ReadInput();
                var str = "0x" + Convert.ToUInt16(param).ToString("X4");
                if (_testListInput.ContainsKey(str))
                {
                    _testListInput[str] = paramRtu[0];
                }
                if (ReadyInput)
                {
                    _cycle++;
                    Varification();
                    _statusSet = !_statusSet;
                    OneCycle();
                }
            }
        }

        private void Varification()
        {
            //Проверка
            foreach (var current in _statusCurrent)
            {
                //Получаем значение бита
                var input = (_testListInput[current.AddrInput] & (1 << Convert.ToUInt16(current.BitInput))) >> Convert.ToUInt16(current.BitInput);
                var output = (_testListOutput[current.AddrOutput] & (1 << Convert.ToUInt16(current.BitOutput))) >> Convert.ToUInt16(current.BitOutput);
                
                if (input != output)
                {
                    current.Value++;
                }
            }
            //Обновление прогрессбара
            UpdateLoadDataProgressBarInvoke();
        }

        private void UpdateLoadDataProgressBar()
        {
            progressBar1.Value = _cycle;
        }

        private delegate void NoParamDelegate();

        private void UpdateLoadDataProgressBarInvoke()
        {
            Invoke(new NoParamDelegate(UpdateLoadDataProgressBar));
        }

        private void DataRecievedOutput(bool dataOk, ushort[] paramRtu, object param)
        {
            if (dataOk)
            {
                ReadOutput();
                var str = "0x" + Convert.ToUInt16(param).ToString("X4");
                if (_testListOutput.ContainsKey(str))
                {
                    _testListOutput[str] = paramRtu[0];
                    var value = CalcDigitMasks(_testListOutput[str], str, _statusSet);
                    SetOutput(value, str);
                }
            }
        }

        private void SetOutput(ushort value, string addrOutput)
        {
            foreach (var output in _testListOutput)
            {
                if (output.Key == addrOutput)
                {
                    var addr = ushort.Parse(output.Key.Substring(2), NumberStyles.HexNumber);
                    _serialPort.SetDataRTU(addr, SetOutput, output.Key, value);
                }
            }
        }

        private void SetOutput(bool dataOk, ushort[] paramRtu, object param)
        {
            if (dataOk)
            {
                if (ReadyOutput)
                {
                    Requestinput();
                }
            }
        }


        private void Requestinput()
        {
            ReadyInput = false;
            CountInput = 0;
            foreach (var addr in AddrInput())
            {
                _serialPort.GetDataRTU(addr, 1, DataRecievedInput, addr);
            }
        }

        private bool ReadyInput { get; set; }
        private int CountInput { get; set; }

        private void ReadInput()
        {
            CountInput++;
            if (CountInput == _testListInput.Count)
            {
                CountInput = 0;
                ReadyInput = true;
            }
            else
            {
                ReadyInput = false;
            }
        }

        private void RequestOutput()
        {
            ReadyOutput = false;
            CountOutput = 0;
            foreach (var addr in AddrOutput())
            {
                _serialPort.GetDataRTU(addr, 1, DataRecievedOutput, addr);
            }
        }

        private bool ReadyOutput { get; set; }
        private int CountOutput { get; set; }

        private void ReadOutput()
        {
            CountOutput++;
            if (CountOutput == _testListOutput.Count)
            {
                CountOutput = 0;
                ReadyOutput = true;
            }
            else
            {
                ReadyOutput = false;
            }
        }

        private ushort CalcDigitMasks(ushort value, string addrOutput, bool mode)
        {
            foreach (var current in _statusCurrent)
            {
                if (current.AddrOutput == addrOutput)
                {
                    if (!mode)
                    {
                        value = (ushort) (value & (0xFFFF ^ (1 << Convert.ToUInt16(current.BitOutput))));
                    }
                    else
                    {
                        value = (ushort)(value | (1 << Convert.ToUInt16(current.BitOutput)));
                    }
                }
            }
            return value;
        }
    }
}
