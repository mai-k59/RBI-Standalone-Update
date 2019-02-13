using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using RBI.BUS.BUSMSSQL;

namespace RBI.PRE.subForm.OutputDataForm
{
    public partial class UCDrawGraph : UserControl
    {
        public UCDrawGraph(int ID)
        {
            InitializeComponent();
            DrawGraph(ID);
        }

        private void DrawGraph(int ID)
        {
            RW_RISK_GRAPH_BUS busRiskGraph = new RW_RISK_GRAPH_BUS();
            RW_ASSESSMENT_BUS busAss = new RW_ASSESSMENT_BUS();
            try
            {
                List<double> data = busRiskGraph.GetData(ID);
                int year = busAss.getAssessmentDate(ID).Year;
                for (int i = 1; i < data.Count; i++)
                {
                    chartRisk.Series[0].Points.Add(new SeriesPoint(year + i, new double[] { data[i] }));
                    chartRisk.Series[1].Points.Add(new SeriesPoint(year + i, new double[] { data[0] }));
                }
                Console.WriteLine("Draw Finished");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error------>" + ex.ToString(), "Error");
            }
        }
    }
}
