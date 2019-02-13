using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.BUS.BUSMSSQL;
using RBI.Object.ObjectMSSQL;
using RBI.Object;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid.Columns;

namespace RBI.PRE.subForm.OutputDataForm
{
    public partial class UCRisk : UserControl
    {
        public UCRisk()
        {
            InitializeComponent();
            initData();
            this.AutoScroll = true;
        }
        public List<RiskSummary> getData()
        {
            RW_ASSESSMENT_BUS assBus = new RW_ASSESSMENT_BUS();
            List<int> allIDAssessment = assBus.getAllID();
            List<RiskSummary> dataRisk = new List<RiskSummary>();
            for (int i = 0; i < allIDAssessment.Count; i++)
            {
                RiskSummary risk = new RiskSummary();
                RW_FULL_POF_BUS busPoF = new RW_FULL_POF_BUS();
                RW_FULL_POF fullPoF = busPoF.getData(allIDAssessment[i]);
                RW_CA_LEVEL_1_BUS busCA = new RW_CA_LEVEL_1_BUS();
                RW_CA_LEVEL_1 CA = busCA.getData(allIDAssessment[i]);
                //get EquipmentID ----> get EquipmentTypeName and APIComponentType
                int equipmentID = assBus.getEquipmentID(allIDAssessment[i]);
                EQUIPMENT_MASTER_BUS eqMaBus = new EQUIPMENT_MASTER_BUS();
                EQUIPMENT_TYPE_BUS eqTypeBus = new EQUIPMENT_TYPE_BUS();
                String equipmentTypename = eqTypeBus.getEquipmentTypeName(eqMaBus.getEquipmentTypeID(equipmentID));
                COMPONENT_MASTER_BUS comMasterBus = new COMPONENT_MASTER_BUS();
                API_COMPONENT_TYPE_BUS apiBus = new API_COMPONENT_TYPE_BUS();
                int apiID = comMasterBus.getAPIComponentTypeID(equipmentID);
                String API_ComponentType_Name = apiBus.getAPIComponentTypeName(apiID);
                RW_INPUT_CA_LEVEL_1_BUS busInputCA = new RW_INPUT_CA_LEVEL_1_BUS();
                RW_INPUT_CA_LEVEL_1 inputCA = busInputCA.getData(allIDAssessment[i]);

                SITES_BUS busSite = new SITES_BUS();
                FACILITY_BUS busFacility = new FACILITY_BUS();
                RW_ASSESSMENT_BUS busAssessment = new RW_ASSESSMENT_BUS();

                risk.SitesName = busSite.getSiteName(eqMaBus.getSiteID(equipmentID));
                risk.FacilityName = busFacility.getFacilityName(eqMaBus.getFacilityID(equipmentID));
                risk.AssessmentName = busAssessment.getAssessmentName(allIDAssessment[i]);
                risk.EquipmentName = eqMaBus.getEquipmentName(equipmentID);
                risk.EquipmentNumber = eqMaBus.getEquipmentNumber(equipmentID);//Equipment Name or Equipment Number can dc gan lai
                risk.EquipmentDesc = eqMaBus.getEquipmentDesc(equipmentID);//Equipment Description gan lai
                risk.EquipmentType = equipmentTypename; //Equipment type
                risk.ComponentName = comMasterBus.getComponentName(equipmentID); //component name
                risk.RepresentFluid = inputCA.API_FLUID; //Represent fluid
                risk.FluidPhase = inputCA.SYSTEM;  //fluid phase
                risk.currentRisk = 0;//current risk
                risk.cofcatFlammable = CA.CA_inj_flame; //cofcat. Flammable
                risk.cofcatPeople = CA.FC_inj;//cofcat people
                risk.cofcatAsset = CA.FC_prod;//cofcat assessment
                risk.cofcatEnv = CA.FC_envi;//cofcat envroment
                risk.cofcatReputation = 0; //cof reputation
                risk.cofcatCombined = CA.FC_total; //combined
                //risk.componentMaterialGrade; //component material glade
                risk.initThinningPoF = fullPoF.ThinningAP1;//Thinning POF
                risk.initEnvCracking = fullPoF.SCCAP1;//Cracking env
                risk.initOtherPoF = fullPoF.HTHA_AP1 + fullPoF.BrittleAP1;//OtherPOF
                risk.initPoF = risk.initThinningPoF + risk.initEnvCracking + risk.initOtherPoF;//Init POF
                risk.extThinningPoF = fullPoF.ExternalAP1;//Ext Thinning POF
                risk.extEnvCrackingPoF = 0;//ExtEnv Cracking
                risk.extOtherPoF = 0;//Ext Other POF
                risk.extPoF = risk.extThinningPoF + risk.extEnvCrackingPoF + risk.extOtherPoF; //Ext POF
                risk.PoF = risk.initPoF + risk.extPoF;//POF
                risk.CurrentRiskCalculation = fullPoF.PoFAP1 * CA.FC_total; //Current risk
                risk.futureRisk = fullPoF.PoFAP2 * CA.FC_total;
                dataRisk.Add(risk);
            }
            return dataRisk;
        }
        private void initData()
        {
            SplashScreenManager.ShowForm(typeof(WaitForm2));
            string[] header = { "Site", "Facility", "Assessment Name", "Equipment Name", "Equipment Number", "Equipment Desc", "Equipment Type", "Components", "Represent.fluid", "Fluid phase", "Current Risk ($/year)", "CoF.Flammable (ft2/failure)", "CoF.People ($/failure)", "CoF.Asset ($/failure)", "CoF.Env ($/failure)", "CoF.Reputation ($/failure)", "CoF.Combined ($/failure)", "Component Material Glade", "InitThinningPOF (failures/year)", "InitEnv.Cracking (failures/year)", "InitOtherPOF (failures/year)", "InitPOF (failures/year)", "ExtThinningPOF (failures/year)", "ExtEnvCrackingProbability (failures/year)", "ExtOtherPOF (failures/year)", "ExtPOF (failures/year)", "POF (failures/year)", "Current Risk ($/year)", "Future Risk ($/year)" };

            gridControlRiskFull.DataSource = getData();
            gridViewRiskFull.Columns.Remove(gridViewRiskFull.Columns["ID"]);
            try
            {
                gridViewRiskFull.BeginSort();
                GridColumn colSite = gridViewRiskFull.Columns["SitesName"];
                GridColumn colFaci = gridViewRiskFull.Columns["FacilityName"];
                colSite.GroupIndex = 0;
                colFaci.GroupIndex = 1;
            }
            finally
            {
                gridViewRiskFull.EndSort();
            }
            for (int i = 0; i < header.Length; i++)
            {
                gridViewRiskFull.Columns[i].Caption = header[i];
            }
            gridViewRiskFull.BestFitColumns();
            SplashScreenManager.CloseForm();
        }
    }
}
