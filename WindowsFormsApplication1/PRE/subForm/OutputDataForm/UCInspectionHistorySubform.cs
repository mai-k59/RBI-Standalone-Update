using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using RBI.Object.ObjectMSSQL;
using RBI.BUS.BUSMSSQL;

namespace RBI.PRE.subForm.OutputDataForm
{
    public partial class UCInspectionHistorySubform : UserControl
    {
        RW_INSPECTION_HISTORY_BUS inspectionHistoryBus = new RW_INSPECTION_HISTORY_BUS();
        RW_ASSESSMENT_BUS assessmentBus = new RW_ASSESSMENT_BUS();
        COMPONENT_MASTER_BUS comMasterBus = new COMPONENT_MASTER_BUS();
        public UCInspectionHistorySubform()
        {
            InitializeComponent();
        }
        public UCInspectionHistorySubform(int ID)
        {
            InitializeComponent();
            setupGridControl(ID);
            this.Dock = DockStyle.Fill;
        }
        private void setupGridControl(int ID)
        {
            string[] title = { "Inspection Plan Name", "Inspection Coverage Name",  "Equipment Number", "Component Number" , "Damage Mechanisms", "Inspection Type", "Inspection Date", "Inspection Effectiveness"};
            string[] Header = { "InspectionPlanName", "InspectionCoverageName", "EquipmentNumber", "ComponentNumber", "DamageMechanisms", "InspectionType", "InspectionDate", "InspectionEffectiveness" };
            int[] ComID = assessmentBus.getEquipmentID_ComponentID(ID);
            String comNum = comMasterBus.getComponentNumber(ComID[1]);
            List<RW_INSPECTION_HISTORY> list = inspectionHistoryBus.getDataComp(comNum);
            if(list.Count > 0)
            {
                gridControl1.DataSource = list;
                gridView1.Columns.Remove(gridView1.Columns["ID"]);
                gridView1.Columns.Remove(gridView1.Columns["SiteName"]);
                gridView1.Columns.Remove(gridView1.Columns["FacilityName"]);
                for (int i = 0; i < title.Length; i++)
                {
                    gridView1.Columns[i].Caption = title[i];
                }
                gridView1.OptionsView.AllowHtmlDrawHeaders = true;
                gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
                gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                gridView1.BestFitColumns();
            }
            else
            {
               
            }

        }
    }
}
