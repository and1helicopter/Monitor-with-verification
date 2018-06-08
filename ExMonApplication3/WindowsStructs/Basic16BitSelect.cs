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
    public partial class Basic16BitSelect : UserControl
    {
        protected List<Label>  titlLabels = new List<Label>();
        List<Button> removeBtns = new List<Button>();
        List<Button> viewBtns = new List<Button>();

        public string ParameterText = "Parameter ";
        public string DeleteText = "Delete parameter";

        public Basic16BitSelect()
        {
            InitializeComponent();
        }
        protected void SetParameters(string[] NewParameters)
        {
            panel1.Controls.Clear();
            titlLabels.Clear();
            removeBtns.Clear();
            viewBtns.Clear();

            for (int i = 0; i < NewParameters.Length; i++)
            {
                AddDigitButton(false);
                titlLabels[i].Text = NewParameters[i];
            }

        }
        void AddDigitButton(bool NeedAddToParamList)
        {
            Label b = new Label();
            b.Height = 50;
            b.Width = panel1.Width - 8 - 16 - 50 - 50 - 10;
            b.Text = ParameterText + (titlLabels.Count + 1).ToString();
            panel1.AutoScroll = false;
            panel1.Controls.Add(b);
            titlLabels.Add(b);
            b.Margin = new System.Windows.Forms.Padding(3);
            b.Top = b.Margin.Top + (b.Height + b.Margin.Top + b.Margin.Bottom) * (titlLabels.Count - 1);
            b.Tag = titlLabels.Count;
            b.TextAlign = ContentAlignment.MiddleCenter;
            b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            b.Left = b.Margin.Left;
            b.BackColor = Color.White;

            panel1.AutoScroll = true;

            b.AllowDrop = true;
            b.MouseDown += new MouseEventHandler(ButtonMouseDown);
            b.DragEnter += new DragEventHandler(ButtonDragEnter);
            b.DragDrop += new DragEventHandler(ButtonDragDrop);

            if (NeedAddToParamList)
            AddParamProcedure(b.Text);

            Button removeBtn = new Button();
            removeBtn.Image = imageList1.Images[0];
            removeBtn.Height = b.Height;
            removeBtn.Width = 50;
            removeBtn.Top = b.Top;
            removeBtn.Left = b.Left + b.Width + b.Margin.Right + removeBtn.Margin.Left;
            removeBtn.UseVisualStyleBackColor = false;
            removeBtn.Tag = b.Tag;
            removeBtn.Click += new EventHandler(DeleteButtonClick);

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

        public virtual void AddParamProcedure(string Titl)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddDigitButton(true);
        }

        //********************** ПЕТЕТАСКИВАНИЕ ЭЛЕМЕНТОВ **********************************************************//
        //**********************************************************************************************************//
        private void ButtonMouseDown(object sender, MouseEventArgs e)
        {
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

                RotateParams(index1 - 1, index2 - 1);
                string str = titlLabels[index1 - 1].Text;
                titlLabels[index1 - 1].Text = titlLabels[index2 - 1].Text;
                titlLabels[index2 - 1].Text = str;
            }

        }
        public virtual void RotateParams(int Index1, int Index2)
        {


        }

        //********************** УДАЛЕНИЕ ЭЛЕМЕНТОВ ****************************************************************//
        //**********************************************************************************************************//
        void DeleteButtonClick(object sender, EventArgs e)
        {

            int t = 0;
            if (!int.TryParse((sender as Button).Tag.ToString(), out t)) { return; }
            if (MessageBox.Show(DeleteText + titlLabels[t - 1].Text + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                panel1.Controls.Remove(titlLabels[t - 1]);
                panel1.Controls.Remove(removeBtns[t - 1]);
                panel1.Controls.Remove(viewBtns[t - 1]);


                for (int i = t; i < titlLabels.Count; i++)
                {
                    titlLabels[i].Tag = i;
                    titlLabels[i].Top = titlLabels[i].Top - titlLabels[i].Height - titlLabels[i].Margin.Top - titlLabels[i].Margin.Bottom;
                    removeBtns[i].Top = titlLabels[i].Top;
                    removeBtns[i].Tag = i;

                    viewBtns[i].Top = titlLabels[i].Top;
                    viewBtns[i].Tag = i;
                }

                titlLabels.Remove(titlLabels[t - 1]);
                removeBtns.Remove(removeBtns[t - 1]);
                viewBtns.Remove(viewBtns[t - 1]);
                DeleteProcedure(t);
            }
        }
        public virtual void DeleteProcedure(int DeleteSelectedIndex)
        {

        }


        //********************** РЕДАКТИРОВАНИЕ ЭЛЕМЕНТОВ **********************************************************//
        //**********************************************************************************************************//
        public void ViewButtonClick(object sender, EventArgs e)
        {
            int t = 0;
            if (!int.TryParse((sender as Button).Tag.ToString(), out t)) { return; }
            ViewProcedure(t);
        }
        public virtual void ViewProcedure(int SelectedIndex)
        {

        }


    }
}
