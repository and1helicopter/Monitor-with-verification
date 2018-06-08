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
    public partial class WarningSelect2 : Basic16BitSelect
    {
        public string Titl { get; set; }
        public Icon Icon { get; set; }

        List<WarningParam> warningParams = new List<WarningParam>();
        public void SetWarningParams(List<WarningParam> WarningParams)
        {
            warningParams = WarningParams;
            string[] strs = new string[WarningParams.Count];
            for (int i = 0; i < strs.Length; i++)
            {
                strs[i] = warningParams[i].Titl;
            }
            SetParameters(strs);
        }
        public List<WarningParam> GetWarningParams()
        {
            return warningParams;
        }

        public override void AddParamProcedure(string Titl)
        {
            warningParams.Add(new WarningParam(Titl));
        }

        public override void RotateParams(int Index1, int Index2)
        {
            WarningParam dp1 = (WarningParam)warningParams[Index1].Clone();
            warningParams[Index1] = warningParams[Index2];
            warningParams[Index2] = dp1;
        }
        
        public override void DeleteProcedure(int DeleteSelectedIndex)
        {
            warningParams.RemoveAt(DeleteSelectedIndex - 1);
        }
       
        public override void ViewProcedure(int SelectedIndex)
        {
            WarningSetupForm wsf = new WarningSetupForm(warningParams[SelectedIndex - 1]);
            wsf.Icon = Icon;
            wsf.Text = warningParams[SelectedIndex - 1].Titl;
            if (wsf.ShowDialog() == DialogResult.OK)
            {
                warningParams[SelectedIndex - 1] = wsf.NewWarningParam;
                titlLabels[SelectedIndex - 1].Text = wsf.NewWarningParam.Titl;
            }
        }

        public WarningSelect2()
        {
            InitializeComponent();
        }
    }
}
