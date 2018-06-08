using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TextLibrary;
using System.Xml.Linq;


namespace StandartScreens
{
    public partial class EventViewer : UserControl
    {

        void SetCell(int Col, int Row, object CellValue)
        {
            if ((Row + 1) > (dataGridView1.Rows.Count))
            {
                for (int i = dataGridView1.Rows.Count; i < (Row + 1); i++)
                {
                  //  MessageBox.Show(Row.ToString());
                    object[] values = { "", "", "", "", "", "" };
                    dataGridView1.Rows.Add();
                }
            }
            dataGridView1.Rows[Row].Cells[Col].Value = CellValue;
        }

        public EventViewer(int EventNum, string XmlFileName, AppTexts AppTexts)
        {
            InitializeComponent();
            this.Height = button1.Top + button1.Height + 2;
            button1.Image = imageList1.Images[0];
            XDocument document;
            XElement element;
            dataGridView1.Columns.Add("Col 1", AppTexts.ParameterName(75)); dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns.Add("Col 2", AppTexts.ParameterName(94)); dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns.Add("Col 3", AppTexts.ParameterName(95)); dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns.Add("Col 4", AppTexts.ParameterName(96)); dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns.Add("Col 5", AppTexts.ParameterName(97)); dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns.Add("Col 6", AppTexts.ParameterName(98)); dataGridView1.Columns[5].Width = 200;

            #region ОТкрытие файла
                try
                {
                    document = XDocument.Load(XmlFileName);

                }
                catch
                {
                    throw new Exception("Error open xml file!");
                }

                try
                {
                    element = document.Root.Element("Event"+(EventNum).ToString());
                }
                catch
                {
                    throw new Exception("Errors in xml file!");
                }
            #endregion

            #region Тип события и время
                try
                {
                    titlLabel.Text = AppTexts.ParameterName(93) + (EventNum+1).ToString() + ". " +
                        element.Attribute("Type").Value.ToString();
                    timeLabel.Text = element.Attribute("Time").Value.ToString();
                }
                catch
                {
                    throw new Exception("Errors in xml file!");
                }
            #endregion

            #region Измеряемые параметры
                int measureCount = 0;
                try
                {
                    measureCount = Convert.ToInt16(element.Attribute("MeasureCount").Value.ToString(), 10);

                }
                catch
                {
                    measureCount = 0;
                }

                for (int i = 0; i < measureCount; i++)
                {
                    string str1 = element.Attribute("MeasureName" + i.ToString()).Value.ToString();
                    string str2 = element.Attribute("Measure" + i.ToString()).Value.ToString();
                    SetCell(0, i, str1);
                    SetCell(1, i, str2);
                }
            #endregion

            #region Дискретные входы
                int digInCount = 0;
                try
                {
                    digInCount = Convert.ToInt16(element.Attribute("DigInCount").Value.ToString(), 10);

                }
                catch
                {
                    digInCount = 0;
                }

                for (int i = 0; i < digInCount; i++)
                {
                    string str1 = element.Attribute("DigInName" + i.ToString()).Value.ToString();
                    string str2 = element.Attribute("DigInValue" + i.ToString()).Value.ToString();
                    SetCell(2, i, str1);
                    if (str2.ToUpper() == "TRUE")
                    {
                        dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                    }
                }

            #endregion

            #region Дискретные выходы
                int digOutCount = 0;
                try
                {
                    digOutCount = Convert.ToInt16(element.Attribute("DigOutCount").Value.ToString(), 10);

                }
                catch
                {
                    digOutCount = 0;
                }

                for (int i = 0; i < digOutCount; i++)
                {
                    string str1 = element.Attribute("DigOutName" + i.ToString()).Value.ToString();
                    string str2 = element.Attribute("DigOutValue" + i.ToString()).Value.ToString();
                    SetCell(3, i, str1);
                    if (str2.ToUpper() == "TRUE")
                    {
                        dataGridView1.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
                    }
                }

            #endregion

           #region Предупреждения
                int warnsCount = 0;
                try
                {
                    warnsCount = Convert.ToInt16(element.Attribute("WarningsCount").Value.ToString(), 10);

                }
                catch
                {
                    warnsCount = 0;
                }


                for (int i = 0; i < warnsCount; i++)
                {
                    string str1 = element.Attribute("WarningName" + i.ToString()).Value.ToString();
                    SetCell(4, i, str1);
                    dataGridView1.Rows[i].Cells[4].Style.BackColor = Color.Yellow;
                }

            #endregion

            #region Защиты
                int alarmsCount = 0;
                try
                {
                    alarmsCount = Convert.ToInt16(element.Attribute("AlarmsCount").Value.ToString(), 10);

                }
                catch
                {
                    alarmsCount = 0;
                }


                for (int i = 0; i < alarmsCount; i++)
                {
                    string str1 = element.Attribute("AlarmName" + i.ToString()).Value.ToString();
                    SetCell(5, i, str1);
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.Red;
                }

            #endregion

        }

        bool nowExpand = false;
        private void button1_Click(object sender, EventArgs e)
        {
            nowExpand = !nowExpand;
            if (nowExpand)
            {
                this.Height = dataGridView1.Rows[0].Height * dataGridView1.Rows.Count + dataGridView1.ColumnHeadersHeight + button1.Top + button1.Height + 4;
                button1.Image = imageList1.Images[1];
                panel1.BackColor = Color.LightBlue;
            }
            else
            {
                this.Height = button1.Top + button1.Height + 2;
                button1.Image = imageList1.Images[0];
                panel1.BackColor = Color.White;
            }
        }
    }
}
