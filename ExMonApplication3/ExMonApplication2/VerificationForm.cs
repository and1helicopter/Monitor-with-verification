using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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
            new Info("0x0128", "0", "0x0144", "8"),
            new Info("0x0128", "1", "0x0144", "9"),
            new Info("0x0128", "2", "0x0144", "10"),
            new Info("0x0128", "3", "0x0144", "11"),
            new Info("0x0128", "4", "0x0144", "12"),
            new Info("0x0128", "5", "0x0144", "13"),
            new Info("0x0128", "6", "0x0144", "14"),
            new Info("0x0128", "7", "0x0144", "15")
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

	    private readonly List<Info> _statusTemp = new List<Info>();
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

	        ChanneldataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
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
				if(_statusTemp.Count == 0)
					_statusCurrent.ForEach(info=>_statusTemp.Add(new Info(info.AddrInput, info.BitInput, info.AddrOutput, info.BitOutput)));
	            _statusCurrent = _statusTemp;


				if (ChanneldataGridView.RowCount > numericUpDown2.Value)
	            {
		            ChanneldataGridView.Rows.RemoveAt(ChanneldataGridView.RowCount - 1);
					if(_statusTemp.Count != 0)
						_statusTemp.Remove(_statusTemp.Last());
	            }
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
            public string AddrInput { get; set; }
            public string BitInput { get; set; }
			public string AddrOutput { get; set; }
			public string BitOutput { get; set; }
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
	        numericUpDown2.Enabled = true;
            SetGrid(_statusCurrent, true);
        }

        readonly Dictionary<string, ushort> _testListInput = new Dictionary<string, ushort>();
        readonly Dictionary<string, ushort> _testListOutput = new Dictionary<string, ushort>();

		readonly Dictionary<string, bool> _writeStatus = new Dictionary<string, bool>();
	    readonly Dictionary<string, bool> _readStatus = new Dictionary<string, bool>();
	    readonly Dictionary<string, bool> _readInput = new Dictionary<string, bool>();
	    readonly Dictionary<string, bool> _readOutput = new Dictionary<string, bool>();

	    readonly Dictionary<string, ushort> _tempValueOutput = new Dictionary<string, ushort>();

		private int _cycle;

        private void button1_Click(object sender, EventArgs e)
        {
	        _stop = false;
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
            progressBar1.Maximum = (int)numericUpDown1.Value;
            progressBar1.Value = 0;

            _testListInput.Clear();
            _testListOutput.Clear();
	        _writeStatus.Clear();
	        _readStatus.Clear();
	        _readOutput.Clear();
	        _readInput.Clear();
	        _tempValueOutput.Clear();
			foreach (var current in _statusCurrent)
            {
                if (!_testListInput.ContainsKey(current.AddrInput))
                    _testListInput.Add(current.AddrInput, 0);
	            if (!_testListOutput.ContainsKey(current.AddrOutput))
	            {
					_testListOutput.Add(current.AddrOutput, 0);
				}
	            if (!_writeStatus.ContainsKey(current.AddrOutput))
	            {
		            _writeStatus.Add(current.AddrOutput, false);
				}
	            if (!_readStatus.ContainsKey(current.AddrOutput))
	            {
		            _readStatus.Add(current.AddrOutput, false);
	            }
	            if (!_readInput.ContainsKey(current.AddrInput))
	            {
		            _readInput.Add(current.AddrInput, false);
				}
				if (!_readOutput.ContainsKey(current.AddrOutput))
				{
					_readOutput.Add(current.AddrOutput, false);
				}
	            if (!_tempValueOutput.ContainsKey(current.AddrOutput))
	            {
		            _tempValueOutput.Add(current.AddrOutput, 0);
	            }
			}

			CycleCheack xxxCycleCheack = Start;
			xxxCycleCheack.Invoke();

        }

		delegate void CycleCheack();

	    private void Start()
	    {
		    //Устанавливаем значаения 
		    //Сброс
		    foreach (var outputAddr in _testListOutput)
		    {
				SetOutput(false, outputAddr.Key);
			}
		}

        private void OneCycle()
        {
			//Получаем значение 
			GetInput();
	        GetOutput();//Сравниваю как получу все данные
		}

		//Сравниваем
		private void Varification()
		{
			if (!_readInput.ContainsValue(false) && !_readOutput.ContainsValue(false))
			{
				foreach (var current in _statusCurrent)
				{
					if (_tempValueOutput[current.AddrOutput] != _testListOutput[current.AddrOutput])
					{
						//Добавить ошибку
					}
					//Получаем значение бита
					var input = (_testListInput[current.AddrInput] & (1 << Convert.ToUInt16(current.BitInput))) >> Convert.ToUInt16(current.BitInput);
					var output = (_testListOutput[current.AddrOutput] & (1 << Convert.ToUInt16(current.BitOutput))) >> Convert.ToUInt16(current.BitOutput);

					if (input != output)
					{
						current.Value++;
					}

					_readStatus[current.AddrOutput] = true;
				}
			}

			//Проверка
			if (!_readStatus.ContainsValue(false))
			{
				foreach (var status in _readInput.Keys.ToList())
				{
					_readInput[status] = false;
				}

				foreach (var status in _readOutput.Keys.ToList())
				{
					_readOutput[status] = false;
				}

				foreach (var status in _readStatus.Keys.ToList())
				{
					_readStatus[status] = false;
				}

				CycleCheack xxxCycleCheack = Start;
				xxxCycleCheack.Invoke();
			}
		}

		//Чтение значений
		private void GetInput()
	    {
		    foreach (var addr in AddrInput())
		    {
			    _serialPort.GetDataRTU(addr, 1, InputAnswer, addr);
		    }
		}

	    private IEnumerable<ushort> AddrInput()
	    {
		    foreach (var input in _testListInput)
		    {
			    yield return ushort.Parse(input.Key.Substring(2), NumberStyles.HexNumber);
		    }
	    }

		private void InputAnswer(bool dataOk, ushort[] paramRtu, object param)
	    {
		    if (dataOk)
		    {
			    var str = "0x" + Convert.ToUInt16(param).ToString("X4");
			    if (_testListInput.ContainsKey(str))
			    {
				    _testListInput[str] = paramRtu[0];
				    _readInput[str] = true;
			    }
			}

		    Varification();
		}

		private void GetOutput()
	    {
		    foreach (var addr in AddrOutput())
		    {
			    _serialPort.GetDataRTU((ushort) (addr + 3), 1, OutputAnswer, addr);
		    }
	    }

		private IEnumerable<ushort> AddrOutput()
	    {
		    foreach (var output in _testListOutput)
		    {
			    yield return ushort.Parse(output.Key.Substring(2), NumberStyles.HexNumber);
		    }
	    }

	    private void OutputAnswer(bool dataOk, ushort[] paramRtu, object param)
	    {
		    if (dataOk)
		    {
			    var str = "0x" + Convert.ToUInt16(param).ToString("X4");
			    if (_testListOutput.ContainsKey(str))
			    {
					_testListOutput[str] = paramRtu[0];
				    _readOutput[str] = true;
			    }
			}

		    Varification();
		}
		//Установить
		private void SetOutput(bool mode, string addrOutput) //mode: false - unset, true - set
	    {
		    var addr = ushort.Parse(addrOutput.Substring(2), NumberStyles.HexNumber);


		    CalcDigitMasks(_testListOutput[addrOutput], addrOutput, mode, out var maskOr, out var maskAnd);

		    var param = new { Mode = mode, Addr = addr, MaskOr = maskOr, MaskAnd = maskAnd };

			_serialPort.SetDataRTU((ushort) (addr + 1), AnswerSet, param, maskOr, maskAnd);
		}

		private void AnswerSet(bool dataOk, ushort[] paramRtu, dynamic param)
	    {
		    if (dataOk)
		    {
				if (_stop)return; 
				Thread.Sleep(250);

			    bool mode = param.Mode;
			    ushort valAddr = param.Addr;

				string addr = "0x" + Convert.ToUInt16(valAddr).ToString("X4");
			    _tempValueOutput[addr] = param.MaskOr;
			    //Читаю и сравниваю

				if (mode)
					_writeStatus[addr] = true;

			    if (!_writeStatus.ContainsValue(false))
			    {
				    _cycle++;
				    foreach (var status in _writeStatus.Keys.ToList())
				    {
					    _writeStatus[status] = false;
				    }

				    UpdateLoadDataProgressBarInvoke();

					if(_cycle < numericUpDown1.Value)
						OneCycle();
			    }
			    else
			    {
					if(_cycle < numericUpDown1.Value)
						SetOutput(!mode, addr);
				}

				if (_cycle >= numericUpDown1.Value)
			    {
					//Резульат
				    MessageVerification();
					//Сброс всех состояний
					UpdateEnableToolsInvoke(true);
				    _cycle = 0;
					UpdateLoadDataProgressBarInvoke();
				}
		    }
	    }


	    //Расчет
	    private void CalcDigitMasks(ushort value, string addrOutput, bool mode, out ushort maskOr, out ushort maskAnd)
	    {
		    ushort m1 = value;
		    ushort m2 = 0x0000;

		    foreach (var current in _statusCurrent)
		    {
			    if (current.AddrOutput == addrOutput)
			    {
				    if (mode)
				    {
					    m1 = (ushort) (m1 | (1 << Convert.ToUInt16(current.BitOutput)));
				    }
				    else
				    {
						m2 = (ushort)(m2 | (1 << Convert.ToUInt16(current.BitOutput)));
				    }
			    }
			}

			maskOr = m1;
		    maskAnd = (ushort)((m2) ^ 0xFFFF);
	    }



		private void UpdateEnableTools(bool str)
        {
            numericUpDown1.Enabled = str;
	        if (str && radioButton4.Checked)
		        numericUpDown2.Enabled = true;
	        else
		        numericUpDown2.Enabled = false;
            radioButton1.Enabled = str;
            radioButton2.Enabled = str;
            radioButton3.Enabled = str;
            radioButton4.Enabled = str;
	        button1.Enabled = str;
	        button2.Enabled = !str;
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
                MessageBox.Show(new Form { TopMost = true }, @"Error", @"Finish", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UpdateListBoxInvoke("No Error");
                UpdateListBoxInvoke("Finish");
                MessageBox.Show(new Form { TopMost = true }, @"Succsess", @"Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Отобразить элементы управления
            UpdateEnableToolsInvoke(true);
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

	    bool _stop;

		private void button2_Click(object sender, EventArgs e)
		{
			_stop = true;
			_cycle = 0;
			UpdateListBoxInvoke("Stop...");
			MessageVerification();
			UpdateEnableToolsInvoke(true);
			UpdateLoadDataProgressBarInvoke();
		}

		private void ChanneldataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var columnIndex = e.ColumnIndex;
			var rowIndex = e.RowIndex;

			if (columnIndex == 0)
			{
				_statusCurrent[rowIndex].AddrOutput = ChanneldataGridView[columnIndex, rowIndex].Value.ToString();
			}
			else if (columnIndex == 1)
			{
				_statusCurrent[rowIndex].BitOutput = ChanneldataGridView[columnIndex, rowIndex].Value.ToString();
			}
			else if (columnIndex == 2)
			{
				_statusCurrent[rowIndex].AddrInput = ChanneldataGridView[columnIndex, rowIndex].Value.ToString();
			}
			else if (columnIndex == 3)
			{
				_statusCurrent[rowIndex].BitInput = ChanneldataGridView[columnIndex, rowIndex].Value.ToString();
			}
		}
	}
}
