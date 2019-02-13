using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
using RBI.BUS.BUSMSSQL;
using RBI.Object;

namespace RBI.PRE.subForm.InputDataForm
{
    public delegate void DataUCChangedHanlder(object sender, DataUCChangedEventArgs e);
    public delegate void CtrlSHandler(object sender, CtrlSPressEventArgs e);
    public partial class UCAssessmentInfo : UserControl
    {
        private int datachange;
        private int ctrlSpress;
        public event DataUCChangedHanlder DataChanged;
        public event CtrlSHandler CtrlS_Press;
        public int CtrlSPress
        {
            get { return ctrlSpress; }
            set
            {
                if (ctrlSpress == value) return; 
                ctrlSpress = value;
                OnCtrlS_Press(new CtrlSPressEventArgs(ctrlSpress));
            }
        }
        public int DataChange
        {
            get { return datachange; }
            set
            {
                if (datachange == value) return;
                datachange = value;
                OnDataChanged(new DataUCChangedEventArgs(datachange));
            }
        }

        protected virtual void OnCtrlS_Press(CtrlSPressEventArgs e)
        {
            if (CtrlS_Press != null)
                CtrlS_Press(this, e);
        }
        protected virtual void OnDataChanged(DataUCChangedEventArgs e)
        {
            if (DataChanged != null)
                DataChanged(this, e);
        }
        List<COMPONENT_TYPE> listComponentType = new List<COMPONENT_TYPE>();
        COMPONENT_TYPE__BUS componentTypeBus = new COMPONENT_TYPE__BUS();
        
        
        public UCAssessmentInfo()
        {
            InitializeComponent();
            listComponentType = componentTypeBus.getDataSource();
        }
        public UCAssessmentInfo(int id)
        {
            InitializeComponent();
            showDatatoControl(id);
            
        }
        public String ProposalName;
        public RW_ASSESSMENT getData(int ID)
        {
            RW_ASSESSMENT_BUS assBus = new RW_ASSESSMENT_BUS();
            int[] temp = assBus.getEquipmentID_ComponentID(ID);
            RW_ASSESSMENT ass = new RW_ASSESSMENT();
            ass.ID = ID;
            ass.AssessmentDate = dateAssessmentDate.DateTime;
            ass.RiskAnalysisPeriod = txtRiskAnalysisPeriod.Text != "" ? int.Parse(txtRiskAnalysisPeriod.Text) : 0;
            ass.IsEquipmentLinked = chkRiskLinksEquipmentRisk.Checked ? 1 : 0;
            //ass.RecordType = cbReportTemplate.Text;
            ass.ProposalName = txtAssessmentName.Text;
            ass.AdoptedDate = DateTime.Now;
            ass.RecommendedDate = DateTime.Now;
            ass.EquipmentID = temp[0];
            ass.ComponentID = temp[1];
            return ass;
        }
        public RW_EQUIPMENT getData1()
        {
            RW_EQUIPMENT eq = new RW_EQUIPMENT();
            eq.CommissionDate = dateComissionDate.DateTime;
            return eq;
        }
        public void showDatatoControl(int ID)
        {
            EQUIPMENT_TYPE_BUS eqTypeBus = new EQUIPMENT_TYPE_BUS();
            EQUIPMENT_MASTER_BUS equipmentMasterBus = new EQUIPMENT_MASTER_BUS();
            DESIGN_CODE_BUS designCodeBus = new DESIGN_CODE_BUS();
            SITES_BUS siteBus = new SITES_BUS();
            FACILITY_BUS facilityBus = new FACILITY_BUS();
            MANUFACTURER_BUS manuBus = new MANUFACTURER_BUS();
            RW_ASSESSMENT_BUS rwAssBus = new RW_ASSESSMENT_BUS();
            COMPONENT_MASTER_BUS comMaBus = new COMPONENT_MASTER_BUS();
            COMPONENT_TYPE__BUS comTypeBus = new COMPONENT_TYPE__BUS();
            API_COMPONENT_TYPE_BUS apiComponentBus = new API_COMPONENT_TYPE_BUS();

            int[] equipmentID_componentID = rwAssBus.getEquipmentID_ComponentID(ID);
            EQUIPMENT_MASTER eqMa = equipmentMasterBus.getData(equipmentID_componentID[0]);
            COMPONENT_MASTER comMa = comMaBus.getData(equipmentID_componentID[1]);
            RW_ASSESSMENT ass = rwAssBus.getData(ID);
            txtAssessmentName.Text = ass.ProposalName;
            dateAssessmentDate.DateTime = ass.AssessmentDate;
            txtRiskAnalysisPeriod.Text = ass.RiskAnalysisPeriod.ToString();

            txtEquipmentNumber.Text = eqMa.EquipmentNumber;
            txtEquipmentType.Text = eqTypeBus.getEquipmentTypeName(eqMa.EquipmentTypeID);
            txtSites.Text = siteBus.getSiteName(eqMa.SiteID);
            txtDesignCode.Text = designCodeBus.getDesignCodeName(eqMa.DesignCodeID);
            txtFacility.Text = facilityBus.getFacilityName(eqMa.FacilityID);
            txtManufacturer.Text = manuBus.getManuName(eqMa.ManufacturerID);
            dateComissionDate.DateTime = eqMa.CommissionDate;
            txtEquipmentName.Text = eqMa.EquipmentName;
            txtProcessDesciption.Text = eqMa.ProcessDescription;

            txtComponentNumber.Text = comMa.ComponentNumber;
            txtComponentType.Text = comTypeBus.getComponentTypeName(comMa.ComponentTypeID);
            txtAPIComponentType.Text = apiComponentBus.getAPIComponentTypeName(comMa.APIComponentTypeID);
            txtComponentName.Text = comMa.ComponentName;
            chkRiskLinksEquipmentRisk.Checked = comMa.IsEquipmentLinked == 1 ? true : false;  
        }


        //public event 
        private void txtAssessmentName_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
        }
        
        private void txtAssessmentName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                CtrlSPress++;
            }
        }

        private void txtRiskAnalysisPeriod_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
        }


        private void txtRiskAnalysisPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {

            string a = txtRiskAnalysisPeriod.Text;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar == '-')// && !Char.IsControl(e.KeyChar) && e.KeyChar == '-')
            {
                //DataChange++;
                e.Handled = true;
            }
        }

        private void dateAssessmentDate_DateTimeChanged(object sender, EventArgs e)
        {
            if ((DateTime) dateAssessmentDate.EditValue > DateTime.Now)
            {
                MessageBox.Show("Invalid Value!", "Error");
                dateAssessmentDate.EditValue = DateTime.Now;
            }
        }
    }
}
