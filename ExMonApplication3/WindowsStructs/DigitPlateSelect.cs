using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsStructs
{
    public partial class DigitPlateSelect : UserControl
    {
        List<DigitPlate> digitPlates = new List<DigitPlate>();
        public List<DigitPlate> DigitPlates
        {
            get { return digitPlates; }
        }

        List<Label>      digitLabels = new List<Label>();
        List<Button> removeBtns = new List<Button>();
        List<Button> viewBtns = new List<Button>();
        public DigitPlateSelect()
        {
            InitializeComponent();
        }
        
        public void SetDigitPlate(List<DigitPlate> NewDigitPlates)
        {
            panel1.Controls.Clear();
            digitLabels.Clear();
            removeBtns.Clear();
            viewBtns.Clear();
            digitPlates.Clear();

            for (int i = 0; i < NewDigitPlates.Count; i++)
            {
                AddDigitButton();
                digitLabels[i].Text = NewDigitPlates[i].Titl;
                digitPlates[i] = NewDigitPlates[i];
            }

        }


        void AddDigitButton()
        {
            Label b = new Label();
            b.Height = 50;
            b.Width = panel1.Width - 8-16-50-50-10;
            b.Text = "Дискретная плата №"+(digitLabels.Count+1).ToString();
            panel1.AutoScroll = false;
            panel1.Controls.Add(b);
            digitLabels.Add(b);
            b.Margin = new System.Windows.Forms.Padding(3);
            b.Top = b.Margin.Top + (b.Height+b.Margin.Top+b.Margin.Bottom)*(digitLabels.Count-1) ;
            b.Tag = digitLabels.Count;
            b.TextAlign = ContentAlignment.MiddleCenter;
            b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            b.Left = b.Margin.Left;
            b.BackColor = Color.White;
            
            panel1.AutoScroll = true;
            
            b.AllowDrop = true;
            b.MouseDown += new MouseEventHandler(ButtonMouseDown);
            b.DragEnter += new DragEventHandler(ButtonDragEnter);
            b.DragDrop += new DragEventHandler(ButtonDragDrop);

            digitPlates.Add(new DigitPlate(b.Text));

            Button removeBtn = new Button();
            removeBtn.Image = imageList1.Images[0];
            removeBtn.Height = b.Height;
            removeBtn.Width = 50;
            removeBtn.Top = b.Top;
            removeBtn.Left = b.Left+b.Width+b.Margin.Right+removeBtn.Margin.Left;
            removeBtn.UseVisualStyleBackColor = false;
            removeBtn.Tag = b.Tag;
            removeBtn.Click += new EventHandler(ButtonClick);

            panel1.Controls.Add(removeBtn);
            removeBtns.Add(removeBtn);



            Button viewBtn = new Button();
            viewBtn.Image = imageList1.Images[1];
            viewBtn.Height = b.Height;
            viewBtn.Width = 50;
            viewBtn.Top = b.Top;
            viewBtn.Left = removeBtn.Left + removeBtn.Width + removeBtn.Margin.Right + viewBtn.Margin.Left;
            viewBtn.UseVisualStyleBackColor = false;
            viewBtn.Tag = b.Tag;
            viewBtn.Click += new EventHandler(ViewButtonClick);

            panel1.Controls.Add(viewBtn);

            viewBtns.Add(viewBtn);

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddDigitButton();
        }

        private void ButtonMouseDown(object sender, MouseEventArgs e)
        {
           // MessageBox.Show((sender as Label).Tag.ToString()); return;
            Label source = (Label)sender;
            DoDragDrop(source, DragDropEffects.Copy);
        }

        private void ButtonDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Label)))
            {
                Label b1 = new Label();
                try
                {
                    b1 = (Label)e.Data.GetData(typeof(Label));
                }
                catch
                {
                    return;
                }
                if (panel1.Controls.Contains(b1))
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ButtonDragDrop(object sender, DragEventArgs e)
        {

            Label b1 = new Label();
            try
            {
                b1 = (Label)e.Data.GetData(typeof(Label));
            }
            catch
            {
                return;
            }

            if (panel1.Controls.Contains(b1))
            {

                int index1 = 0;
                int index2 = 0;

                if (!int.TryParse(b1.Tag.ToString(), out index1)) { return; }

                if (!int.TryParse((sender as Label).Tag.ToString(), out index2)) { return; }

                ChangeDigits(index1 - 1, index2 - 1);
            }

        }

        private void ChangeDigits(int Index1, int Index2)
        {
            DigitPlate dp1 = digitPlates[Index1].Copy();
            digitPlates[Index1] = digitPlates[Index2];
            digitPlates[Index2] = dp1;

            digitLabels[Index1].Text = digitPlates[Index1].Titl;
            digitLabels[Index2].Text = digitPlates[Index2].Titl;

        }

        void ButtonClick(object sender, EventArgs e)
        {
            
            int t = 0;
            if (!int.TryParse((sender as Button).Tag.ToString(), out t)) { return; }
            if (MessageBox.Show("Удалить плату " + digitPlates[t - 1].Titl + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                panel1.Controls.Remove(digitLabels[t - 1]);
                panel1.Controls.Remove(removeBtns[t - 1]);
                panel1.Controls.Remove(viewBtns[t - 1]);
                

                for (int i = t; i < digitLabels.Count; i++)
                {
                    digitLabels[i].Tag = i;
                    digitLabels[i].Top = digitLabels[i].Top - digitLabels[i].Height - digitLabels[i].Margin.Top - digitLabels[i].Margin.Bottom;
                    removeBtns[i].Top = digitLabels[i].Top;
                    removeBtns[i].Tag = i;

                    viewBtns[i].Top = digitLabels[i].Top;
                    viewBtns[i].Tag = i;
                }

                digitLabels.Remove(digitLabels[t - 1]);
                removeBtns.Remove(removeBtns[t - 1]);
                digitPlates.Remove(digitPlates[t - 1]);
                viewBtns.Remove(viewBtns[t - 1]);
            }
        }

        void ViewButtonClick(object sender, EventArgs e)
        {

            int t = 0;
            if (!int.TryParse((sender as Button).Tag.ToString(), out t)) { return; }
            DigitPlateSetupForm f = new DigitPlateSetupForm(digitPlates[t-1],t);
            if (f.ShowDialog() == DialogResult.Yes)
            {
                digitPlates[t - 1] = f.DigitPlate;
                digitLabels[t - 1].Text = f.DigitPlate.Titl;
            }
        }













    }
}
