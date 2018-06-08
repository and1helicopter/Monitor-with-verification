using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextLibrary;
using System.Xml.Linq;


namespace StandartScreens
{
    public partial class EventlogViewerForm : Form
    {
        EventViewer eventViewer;
        public EventlogViewerForm(string FileName, AppTexts AppTexts)
        {
            InitializeComponent();
            this.Text = AppTexts.ParameterName(99) + " - " + FileName;
            XDocument document;
            XElement element;
            try
            {
                document = XDocument.Load(FileName);

            }
            catch
            {
                throw new Exception("Error open xml file!");
            }

            try
            {
                element = document.Root.Element("EventLogSetup");
            }
            catch
            {
                throw new Exception("Errors in xml file!");
            }

            int eventCount = 0;
            try
            {
                eventCount = Convert.ToInt16(element.Attribute("EventCount").Value.ToString(), 10);

            }
            catch
            {
                eventCount = 0;
                throw new Exception("Invalid event count in xml file!");
            }

            tableLayoutPanel1.RowCount = eventCount + 1;
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            foreach (RowStyle style in tableLayoutPanel1.RowStyles)
            {
                style.SizeType = SizeType.AutoSize;
            }


            tableLayoutPanel1.RowStyles[eventCount].SizeType = SizeType.Absolute;
            tableLayoutPanel1.RowStyles[eventCount].Height = 0;
          //  MessageBox.Show(tableLayoutPanel1.RowCount.ToString());
            
            for (int i = 0; i < eventCount; i++)
            {
               // tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                eventViewer = new EventViewer(i, FileName, AppTexts);
                eventViewer.Dock = DockStyle.Fill;
                eventViewer.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
                tableLayoutPanel1.Controls.Add(eventViewer);
                tableLayoutPanel1.SetRow(eventViewer, i);
                
            }
        }
    }
}
