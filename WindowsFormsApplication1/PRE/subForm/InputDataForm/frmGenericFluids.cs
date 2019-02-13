using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmGenericFluids : Form
    {
        public frmGenericFluids()
        {
            InitializeComponent();
        }
        private void formatGridView()
        {
            string[] field = { "Fluid", "normalBoilingPoint", "Density", "MW", "ChemicalFactor", "HeathDegree", "Flammability", "Reactivity", "ApplyCPF", "ApplyCMVF" };
            string[] caption = { "Fluid", "Normal Boiling Point", "Density (kg/m3)", "MW", "Chemical Factor", "Health Degree", "flammability", "Reactivity", "Apply to Component Primary Fluid", "Apply to Component Most Volatile Fluid" };
            for (int i = 0; i < field.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = field[i];
                col.Caption = caption[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
                gridView1.Columns[i].Width = 100;
            }
            gridView1.BestFitColumns();
        }
    }
}
