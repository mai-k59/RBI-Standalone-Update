using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Menu;
using DevExpress.Utils.Menu;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using RBI.DAL;
using RBI.BUS;
using RBI.Object;
using RBI.BUS.BUSExcel;
using RBI.PRE.subForm;
using RBI.Object.ObjectMSSQL;

using RBI.PRE.subForm.InputDataForm;
using RBI.BUS.BUSMSSQL_CAL;
using RBI.PRE.subForm.OutputDataForm;
using RBI.BUS.BUSMSSQL;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;

namespace RBI
{
    
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            InitializeComponent();
            initDataforTreeList();
            initScheme();
            treeListProject.OptionsBehavior.Editable = false;
            treeListProject.OptionsView.ShowIndicator = false;
            treeListProject.OptionsView.ShowColumns = false;
            treeListProject.OptionsView.ShowHorzLines = true;
            treeListProject.OptionsView.ShowVertLines = false;
            treeListProject.ExpandAll();
            InitDictionaryDMMachenism();
            barStaticItem1.Caption = "Ready";
            SplashScreenManager.CloseForm();
        }
        private void initScheme()
        {
            listUnit = busUnit.getDataSource();
            foreach (UNITS obj in listUnit)
            {
                switch (obj.UnitName)
                {
                    case "Pressure":
                        pressure = obj.SelectedUnit;
                        break;
                    case "Stress":
                        stress = obj.SelectedUnit;
                        break;
                    case "Temperature":
                        temperature = obj.SelectedUnit;
                        break;
                    case "Diameter":
                        diameter = obj.SelectedUnit;
                        break;
                    case "Thickness":
                        thickness = obj.SelectedUnit;
                        break;
                    case "Dimensions":
                        dimension = obj.SelectedUnit;
                        break;
                    case "Volume":
                        volume = obj.SelectedUnit;
                        break;
                    case "FlowRate":
                        flowRate = obj.SelectedUnit;
                        break;
                    case "Corrosion":
                        corrosion = obj.SelectedUnit;
                        break;
                    case "CorrosionRate":
                        corrosionRate = obj.SelectedUnit;
                        break;
                    case "FinacialUnit":
                        finacialUnit = obj.SelectedUnit;
                        break;
                }
            }
        }
        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region Button Click

        private void btnBackupData_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_backup back = new frm_backup();
            back.ShowInTaskbar = false;
            back.Show();
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_restored restored = new frm_restored();
            restored.ShowInTaskbar = false;
            restored.Show();
        }

        private void btnImportTank_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmImportExcelTank exTank = new frmImportExcelTank();
            exTank.ShowInTaskbar = false;
            exTank.ShowDialog();
            if (exTank.ButtonOKClicked)
                initDataforTreeList();
        }

        private void btnSites_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNewSite site = new frmNewSite();
            site.ShowInTaskbar = false;
            site.ShowDialog();
            if (site.ButtonOKClicked)
                initDataforTreeList();
        }

        private void btnFacilityRibbon_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFacilityInput faci = new frmFacilityInput();
            faci.ShowInTaskbar = false;
            faci.ShowDialog();
            if (faci.ButtonOKClicked)
                initDataforTreeList();
        }

        private void btnEquipmentRibbon_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmEquipment eq = new frmEquipment();
            eq.ShowInTaskbar = false;
            eq.ShowDialog();
            if (eq.ButtonOKCliked)
                initDataforTreeList();
        }

        private void btnComponentRibbon_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNewComponent com = new frmNewComponent();
            com.ShowInTaskbar = false;
            com.ShowDialog();
            if (com.ButtonOKClicked)
                initDataforTreeList();
        }
        private void btnPlanInsp_ItemClick(object sender, ItemClickEventArgs e)
        {
            createInspectionPlanExcel(false);
        }
        private void btnPlant_ItemClick(object sender, ItemClickEventArgs e)
        {
            RBI.PRE.subForm.InputDataForm.frmNewSite site = new PRE.subForm.InputDataForm.frmNewSite();
            site.ShowDialog();
            if (site.ButtonOKClicked)
            {
                initDataforTreeList();
            }
        }
        private void btnFacility_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFacilityInput facilityInput = new frmFacilityInput();
            facilityInput.ShowDialog();
            if (facilityInput.ButtonOKClicked == true)
            {
                initDataforTreeList();
            }
        }
        private void btnEquipment_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmEquipment eq = new frmEquipment();
            eq.ShowDialog();
            if (eq.ButtonOKCliked)
                initDataforTreeList();
        }
        private void btnComponent_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNewComponent com = new frmNewComponent();
            com.ShowDialog();
            if (com.ButtonOKClicked)
                initDataforTreeList();
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(WaitForm2));
                if (!checkTank)
                {

                    int selectedID = int.Parse(this.xtraTabData.SelectedTabPage.Name);
                    ucTabNormal uc = null;
                    foreach (ucTabNormal u in listUC)
                    {
                        if (selectedID == u.ID)
                        {
                            uc = u;
                            break;
                        }
                    }
                    UCAssessmentInfo uAssTest = uc.ucAss;
                    RW_ASSESSMENT ass = uAssTest.getData(IDProposal);
                    RW_EQUIPMENT eq = uc.ucEq.getData(IDProposal, temperature, volume); // mai
                    eq.CommissionDate = busEquipmentMaster.getComissionDate(ass.EquipmentID);
                    RW_COMPONENT com = uc.ucComp.getData(IDProposal, diameter, thickness, corrosionRate); // mai
                    RW_STREAM stream = uc.ucStream.getData(IDProposal); //mai
                    RW_STREAM op = uc.ucOpera.getDataforStream(IDProposal,temperature, pressure, flowRate); // mai
                    treeListProject.FocusedNode.SetValue(0, ass.ProposalName);
                    xtraTabData.SelectedTabPage.Text = treeListProject.FocusedNode.ParentNode.GetValue(0).ToString() + "[" + ass.ProposalName + "]";
                    //<gan full gia tri cho stream>
                    stream.FlowRate = op.FlowRate;
                    stream.MaxOperatingPressure = op.MaxOperatingPressure;
                    stream.MinOperatingPressure = op.MinOperatingPressure;
                    stream.MaxOperatingTemperature = op.MaxOperatingTemperature;
                    stream.MinOperatingTemperature = op.MinOperatingTemperature;
                    stream.CriticalExposureTemperature = op.CriticalExposureTemperature;
                    stream.H2SPartialPressure = op.H2SPartialPressure;
                    //</object stream>
                    RW_EXTCOR_TEMPERATURE extTemp = uc.ucOpera.getDataExtcorTemp(IDProposal);
                    RW_COATING coat = uc.ucCoat.getData(IDProposal, corrosionRate);
                    RW_MATERIAL ma = uc.ucMaterial.getData(IDProposal, temperature, pressure, stress, corrosion, thickness);
                    RW_INPUT_CA_LEVEL_1 caInput = uc.ucCA.getData(IDProposal);
                    String _tabName = xtraTabData.SelectedTabPage.Text;
                    String componentNumber = _tabName.Substring(0, _tabName.IndexOf("["));
                    String ThinningType = uc.ucRiskFactor.type;
                    Calculation(ThinningType, componentNumber, eq, com, ma, stream, coat, extTemp, caInput);
                    MessageBox.Show("Calculation Finished!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //Save Data
                    SaveDatatoDatabase(ass, eq, com, stream, extTemp, coat, ma, caInput);
                    UCRiskFactor resultRisk = new UCRiskFactor(IDProposal);
                    showUCinTabpage(resultRisk);
                }
                else
                {
                    int selectedID = int.Parse(this.xtraTabData.SelectedTabPage.Name);
                    ucTabTank uc = null;
                    foreach (ucTabTank u in listUCTank)
                    {
                        if (selectedID == u.ID)
                        {
                            uc = u;
                            break;
                        }
                    }
                    
                    int[] eq_comID = busAssessment.getEquipmentID_ComponentID(IDProposal);
                    COMPONENT_MASTER componentMaster = busComponentMaster.getData(eq_comID[1]);
                    
                    String componentTypeName = busComponentType.getComponentTypeName(componentMaster.ComponentTypeID);
                    int APICompID = componentMaster.APIComponentTypeID;
                    
                    String apiComName = busApiComponentType.getAPIComponentTypeName(APICompID);
                    UCAssessmentInfo uAssTest = uc.ucAss;
                    RW_ASSESSMENT ass = uAssTest.getData(IDProposal);
                    RW_EQUIPMENT eq = uc.ucEquipmentTank.getData(IDProposal, temperature, volume);
                    RW_COMPONENT com = uc.ucComponentTank.getData(IDProposal,diameter,thickness,corrosionRate);
                    RW_STREAM stream = uc.ucStreamTank.getData(IDProposal);
                    RW_EXTCOR_TEMPERATURE extTemp = uc.ucOpera.getDataExtcorTemp(IDProposal);
                    RW_COATING coat = uc.ucCoat.getData(IDProposal, corrosionRate);
                    RW_MATERIAL ma = uc.ucMaterialTank.getData(IDProposal, temperature, pressure, stress, thickness, corrosion);
                    RW_INPUT_CA_TANK caTank = new RW_INPUT_CA_TANK();
                    RW_INPUT_CA_TANK caTank1 = uc.ucEquipmentTank.getDataforTank(IDProposal);
                    RW_INPUT_CA_TANK caTank2 = uc.ucStreamTank.getDataforTank(IDProposal);
                    RW_INPUT_CA_TANK caTank3 = uc.ucMaterialTank.getDataforTank(IDProposal);
                    RW_INPUT_CA_TANK caTank4 = uc.ucComponentTank.getDataforTank(IDProposal, diameter);

                    caTank = caTank2;
                    caTank.Soil_Type = caTank1.Soil_Type;
                    caTank.SW = caTank1.SW;
                    caTank.Environ_Sensitivity = caTank1.Environ_Sensitivity;
                    caTank.ProductionCost = caTank3.ProductionCost;
                    caTank.SHELL_COURSE_HEIGHT = caTank4.SHELL_COURSE_HEIGHT;
                    caTank.TANK_DIAMETTER = caTank4.TANK_DIAMETTER;
                    caTank.Prevention_Barrier = caTank4.Prevention_Barrier;

                    String _tabName = xtraTabData.SelectedTabPage.Text;
                    String componentNumber = _tabName.Substring(0, _tabName.IndexOf("["));
                    String ThinningType = uc.ucRiskFactor.type;
                    Calculation_CA_TANK(componentTypeName, apiComName, ThinningType, componentNumber, eq, com, ma, stream, coat, extTemp, caTank);
                    MessageBox.Show("Calculation finished!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    SaveDatatoDatabase(ass, eq, com, stream, extTemp, coat, ma, caTank);
                    UCRiskFactor resultRisk = new UCRiskFactor(IDProposal);
                    //resultRisk.ShowDataOutputCA(IDProposal); //***
                    //resultRisk.riskPoF(IDProposal); //***
                    showUCinTabpage(resultRisk);
                }
                // mai cop
                navRiskFactor.Appearance.ForeColor = Color.Red;
                navEquipment.Appearance.ForeColor = navComponent.Appearance.ForeColor =
                    navOperating.Appearance.ForeColor = navMaterial.Appearance.ForeColor =
                    navCoating.Appearance.ForeColor = navNoInspection.Appearance.ForeColor =
                    navStream.Appearance.ForeColor = navAssessmentInfo.Appearance.ForeColor =
                    navCA.Appearance.ForeColor = navRiskSummary.Appearance.ForeColor =
                    navViewGraph.Appearance.ForeColor = Color.Black;
                // cop xong
                SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa tính được" + ex.ToString(), "Cortek RBI");
                SplashScreenManager.CloseForm();
            }
        }
        private void btnImportExcelData_ItemClick(object sender, ItemClickEventArgs e)
        {
            RBI.PRE.subForm.InputDataForm.frmImportExcel excel = new RBI.PRE.subForm.InputDataForm.frmImportExcel();
            excel.ShowInTaskbar = false;
            excel.ShowDialog();
            if (excel.ButtonOKClicked)
                initDataforTreeList();
        }

        private void btnImportInspection_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmImportInspection insp = new frmImportInspection();
            insp.ShowInTaskbar = false;
            insp.ShowDialog();
        }

        private void btnExportGeneral_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!checkTank)
                createReportExcel(true);
            else
                createReportExcelTank(true);
        }

        private void btnExportDetail_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!checkTank)
                createReportExcel(false);
            else
                createReportExcelTank(false);
        }

        private void btnInspectionPlan_ItemClick(object sender, ItemClickEventArgs e)
        {
            createInspectionPlanExcel(false);
        }
        #endregion

        #region TreeListProject va XtratabData
        private void treeListProject_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            // Create brushes for cells.
            Brush backBrush, foreBrush;
            if (e.Node != (sender as TreeList).FocusedNode)
            {
                backBrush = new LinearGradientBrush(e.Bounds, Color.White, Color.White, LinearGradientMode.ForwardDiagonal);
                foreBrush = Brushes.Black;
            }
            else
            {
                backBrush = new LinearGradientBrush(e.Bounds, Color.LightSteelBlue, Color.LightSteelBlue, LinearGradientMode.ForwardDiagonal);
                foreBrush = new SolidBrush(Color.PeachPuff);
            }

            // Fill the background.
            e.Graphics.FillRectangle(backBrush, e.Bounds);
            // Paint the node value.
            e.Graphics.DrawString(e.CellText, e.Appearance.Font, foreBrush, e.Bounds,
            e.Appearance.GetStringFormat());

            // Prohibit default painting.
            e.Handled = true;
        }
        private void treeListProject_MouseClick(object sender, MouseEventArgs e)
        {
            treeListProject.Appearance.FocusedCell.ForeColor = Color.Red;
        }
        private void initDataforTreeList()
        {
            treeListProject.StateImageList = imageTreeList;
            List<SITES> readListSite = new List<SITES>();
            List<FACILITY> readListFacility = new List<FACILITY>();
            List<EQUIPMENT_MASTER> readListEquipmentMaster = new List<EQUIPMENT_MASTER>();
            List<COMPONENT_MASTER> readListComponentMaster = new List<COMPONENT_MASTER>();
            List<RW_ASSESSMENT> readListAssessment = new List<RW_ASSESSMENT>();
            listTree = new List<TestData>();
            readListSite = busSites.getData();
            readListFacility = busFacility.getDataSource();
            readListEquipmentMaster = busEquipmentMaster.getDataSource();
            readListComponentMaster = busComponentMaster.getDataSource();
            readListAssessment = busAssessment.getDataSource();
            List<int> _siteID = new List<int>();
            List<int> _facilityID = new List<int>();
            List<int> _equipmentID = new List<int>();
            List<int> _componentID = new List<int>();
            List<int> _reportID = new List<int>();
            foreach (SITES s in readListSite)
            {
                listTree.Add(new TestData(s.SiteID, -1, s.SiteName));
            }

            foreach (FACILITY f in readListFacility)
            {
                listTree.Add(new TestData(f.FacilityID + 100000, f.SiteID, f.FacilityName));
            }

            foreach (EQUIPMENT_MASTER e in readListEquipmentMaster)
            {
                listTree.Add(new TestData(e.EquipmentID + 200000, e.FacilityID + 100000, e.EquipmentNumber));
            }
            foreach (COMPONENT_MASTER c in readListComponentMaster)
            {
                listTree.Add(new TestData(c.ComponentID + 300000, c.EquipmentID + 200000, c.ComponentNumber));
            }
            foreach (RW_ASSESSMENT a in readListAssessment)
            {
                listTree.Add(new TestData(a.ID + 400000, a.ComponentID + 300000, a.ProposalName));
            }
            treeListProject.DataSource = listTree;
            treeListProject.RefreshDataSource();
            listTree1 = listTree;
            try
            {
                treeListProject.FocusedNode.Expand();
            }
            catch
            {
                // do nothing
            }
            //treeListProject.ExpandAll();
            //treeListProject.ExpandToLevel(selectedLevel);
        }
        private void treeListProject_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            TreeListNode node = treeListProject.FocusedNode;
            treeListProject.StateImageList = imageTreeList;
            int nodeLevel = e.Node.Level;
            //foreach (TreeListNode item in node.Nodes)
            //{
                switch(nodeLevel)
                {
                    case 0:
                        e.Node.StateImageIndex = 0;
                        break;
                    case 1:
                        e.Node.StateImageIndex = 1;
                        break;
                    case 2:
                        e.Node.StateImageIndex = 2;
                        break;
                    case 3:
                        e.Node.StateImageIndex = 3;
                        break;
                    case 4:
                        e.Node.StateImageIndex = 4;
                        break;
                    default:
                        e.Node.StateImageIndex = 5;
                        break;
                }
            //}
            selectedLevel = nodeLevel;
        }
        private void treeListProject_CustomDrawNodeImages(object sender, CustomDrawNodeImagesEventArgs e)
        {
            TreeListNode node = treeListProject.FocusedNode;
            treeListProject.StateImageList = imageTreeList;
            //foreach (TreeListNode item in node.Nodes)
            //{
                if (e.Node.Level == 0)
                {
                    e.Node.StateImageIndex = 0;
                    e.Node.SelectImageIndex = 0;
                }
                else if (e.Node.Level == 1)
                {
                    e.Node.StateImageIndex = 1;
                    e.Node.SelectImageIndex = 1;
                }
                else if (e.Node.Level == 2)
                {
                    e.Node.StateImageIndex = 2;
                    e.Node.SelectImageIndex = 2;
                }
                else if (e.Node.Level == 3)
                {
                    e.Node.StateImageIndex = 3;
                    e.Node.SelectImageIndex = 3;
                }
                else
                {
                    e.Node.StateImageIndex = 4;
                    e.Node.SelectImageIndex = 4;
                }
            //}
        }
        private void btn_add_Component_click(object sender, EventArgs e)
        {
            string facilityName = treeListProject.FocusedNode.ParentNode.GetValue(0).ToString();
            string equipmentName = treeListProject.FocusedNode.GetValue(0).ToString();
            string siteName = treeListProject.FocusedNode.RootNode.GetValue(0).ToString();
            frmNewComponent com = new frmNewComponent(equipmentName, facilityName, siteName);
            com.ShowDialog();
            if (com.ButtonOKClicked)
                initDataforTreeList();
        }
        private void btn_add_Equipment_click(object sender, EventArgs e)
        {
            string siteName = treeListProject.FocusedNode.ParentNode.GetValue(0).ToString();
            string facilityName = treeListProject.FocusedNode.GetValue(0).ToString();
            frmEquipment eq = new frmEquipment(siteName, facilityName);
            eq.ShowDialog();
            if (eq.ButtonOKCliked)
                initDataforTreeList();
        }
        private void btn_edit_site_name(object sender, EventArgs e)
        {
            string name = treeListProject.FocusedNode.GetDisplayText(0);
            frmNewSite site = new frmNewSite(name);
            site.ShowInTaskbar = false;
            site.ShowDialog();
            if (site.ButtonOKClicked)
                initDataforTreeList();
        }
        private void btn_add_facility_click(object sender, EventArgs e)
        {

            frmFacilityInput faci = new frmFacilityInput();
            faci.ShowDialog();
            if (faci.ButtonOKClicked)
                initDataforTreeList();
        }
        private void addNewRecord(object sender, EventArgs e)
        {
            UCAssessmentInfo ucAss = new UCAssessmentInfo();
            RW_ASSESSMENT rwass = new RW_ASSESSMENT();
            RW_EXTCOR_TEMPERATURE rwExtTemp = new RW_EXTCOR_TEMPERATURE();
            RW_EQUIPMENT rwEq = new RW_EQUIPMENT();
            RW_COMPONENT rwCom = new RW_COMPONENT();
            RW_STREAM rwStream = new RW_STREAM();
            RW_MATERIAL rwMaterial = new RW_MATERIAL();
            RW_COATING rwCoat = new RW_COATING();
            RW_CA_LEVEL_1 rwCA = new RW_CA_LEVEL_1();
            RW_FULL_POF rwFullPoF = new RW_FULL_POF();
            RW_INPUT_CA_LEVEL_1 rwCALevel1 = new RW_INPUT_CA_LEVEL_1();
            RW_CA_TANK rwCATank = new RW_CA_TANK();
            RW_INPUT_CA_TANK rwInputCATank = new RW_INPUT_CA_TANK();
            RW_RISK_GRAPH rwRiskGraph = new RW_RISK_GRAPH();
            /*-----------------Tìm đuôi Proposal có giá trị lớn nhất-------------------*/
            List<string> lstProposalName = busAssessment.AllName();
            List<int> number = new List<int>();
            for(int i = 0; i < lstProposalName.Count; i++)
            {
                if(lstProposalName[i].Contains("New Proposal"))
                {
                    string b = lstProposalName[i].Substring(12);
                    int temp;
                    if (int.TryParse(b, out temp))
                        number.Add(temp);
                }
            }
            int k = 0;
            String ProposalName = "New Proposal ";
            if (lstProposalName.Count != 0)
            {
                 k = number.Max();
                  ProposalName += (k+1).ToString();
            }
            else
            {
                ProposalName += 1;
            }
            /*----------------------------------------------------------------------*/
            String componentNumber = treeListProject.FocusedNode.GetValue(0).ToString();
            List<COMPONENT_MASTER> listComponentMaster = busComponentMaster.getDataSource();
            List<EQUIPMENT_MASTER> listEq = busEquipmentMaster.getDataSource();
            foreach (COMPONENT_MASTER c in listComponentMaster)
            {
                if (c.ComponentNumber == componentNumber)
                {
                    rwass.EquipmentID = c.EquipmentID;
                    rwass.ComponentID = c.ComponentID;
                    foreach (EQUIPMENT_MASTER e1 in listEq)
                    {
                        if (e1.EquipmentID == c.EquipmentID)
                        {
                            rwEq.CommissionDate = e1.CommissionDate;
                            break;
                        }
                    }
                    break;
                }
            }
            rwass.RiskAnalysisPeriod = 36;
            rwass.AssessmentDate = DateTime.Now;
            rwass.ProposalName = ProposalName;
            rwass.AdoptedDate = DateTime.Now;
            rwass.RecommendedDate = DateTime.Now;
            rwass.AddByExcel = 0;
            busAssessment.add(rwass);
            List<RW_ASSESSMENT> listAss = busAssessment.getDataSource();
            int ID = listAss.Max(RW_ASSESSMENT => RW_ASSESSMENT.ID);
            rwEq.ID = ID;
            rwCom.ID = ID;
            rwCoat.ID = ID;
            rwStream.ID = ID;
            rwRiskGraph.ID = ID;
            rwFullPoF.ID = ID;
            rwMaterial.ID = ID;
            rwExtTemp.ID = ID;
            rwCoat.ExternalCoatingDate = DateTime.Now;

            busEquipment.add(rwEq);
            busComponent.add(rwCom);
            busCoating.add(rwCoat);
            busMaterial.add(rwMaterial);
            busStream.add(rwStream);
            busExtcorTemp.add(rwExtTemp);
            busRiskGraph.add(rwRiskGraph);
            int[] eq_comID = busAssessment.getEquipmentID_ComponentID(ID);
            COMPONENT_MASTER componentMaster = busComponentMaster.getData(eq_comID[1]);
            
            String componentTypeName = busComponentType.getComponentTypeName(componentMaster.ComponentTypeID);
            if (componentTypeName == "Shell" || componentTypeName == "Tank Bottom")
            {
                rwCATank.ID = ID;
                rwInputCATank.ID = ID;
                busCATank.add(rwCATank);
                busInputCATank.add(rwInputCATank);
            }
            else
            {
                rwCA.ID = ID;
                rwCALevel1.ID = ID;
                busInputCALevel1.add(rwCALevel1);
                busCALevel1.add(rwCA);
            }
            initDataforTreeList();
        }
        private void deleteRecord(object sender, EventArgs e)
        {
            /*Cần xóa dữ liệu ở các bảng:
             * RW_ASSESSMENT
             * RW_EQUIPMENT
             * RW_COMPONENT
             * RW_EXTCOR_TEMPERATURE
             * RW_COATING
             * RW_MATERIAL
             * RW_INPUT_CA_LEVEL1
             * RW_INPUT_CA_TANK
             * RW_CA_LEVEL1
             * RW_CA_TANK
             * RW_FULL_POF
             * RW_STREAM
             * RW_FULL_FCOF
             */
            DialogResult da = MessageBox.Show("Do you want to delete record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (da == DialogResult.Yes)
            {
                foreach (XtraTabPage x in xtraTabData.TabPages)
                {
                    if (x.Name == IDNodeTreeList.ToString())
                    {
                        if (MessageBox.Show("Record is opening! Do you want close it?", "Cortek RBI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            xtraTabData.TabPages.Remove(x); //close tab nếu nó đang được mở
                            break;
                        }
                        else return;
                    }
                }
                busRiskGraph.delete(IDNodeTreeList);
                busEquipment.delete(IDNodeTreeList);
                busComponent.delete(IDNodeTreeList);
                busExtcorTemp.delete(IDNodeTreeList);
                busCoating.delete(IDNodeTreeList);
                busMaterial.delete(IDNodeTreeList);
                busInputCALevel1.delete(IDNodeTreeList);
                busCATank.delete(IDNodeTreeList);
                busCALevel1.delete(IDNodeTreeList);
                busCATank.delete(IDNodeTreeList);
                busFullPoF.delete(IDNodeTreeList);
                busStream.delete(IDNodeTreeList);
                busFullFCoF.delete(IDNodeTreeList);
                busAssessment.delete(IDNodeTreeList);
                initDataforTreeList();
            }
            else return;
        }

        private void deleteComponent(object sender, EventArgs e)
        {
            /*Cần xóa dữ liệu ở các bảng:
             * RW_ASSESSMENT
             * RW_EQUIPMENT
             * RW_COMPONENT
             * RW_EXTCOR_TEMPERATURE
             * RW_COATING
             * RW_MATERIAL
             * RW_INPUT_CA_LEVEL1
             * RW_INPUT_CA_TANK
             * RW_CA_LEVEL1
             * RW_CA_TANK
             * RW_FULL_POF
             * RW_STREAM
             * RW_FULL_FCOF
             * COMPONENT_MASTER
             */
            List<int> lstAssessmentID = busComponentMaster.GetAllIDbyComponentID(IDNodeTreeList);
            DialogResult da = MessageBox.Show("Do you want to delete component?\nAll Record of Component will be loss", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (da == DialogResult.Yes)
            {
                List<XtraTabPage> temp = new List<XtraTabPage>();
                foreach (XtraTabPage x in xtraTabData.TabPages)
                {
                    foreach(int i in lstAssessmentID)
                    {
                        if (x.Name == i.ToString())
                        {
                            temp.Add(x);
                        }
                    }
                }
                if(temp.Count != 0)
                {
                    if (MessageBox.Show(temp.Count + " Record(s) are opening! Do you want close it?", "Cortek RBI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        foreach (XtraTabPage x in temp)
                        {
                            xtraTabData.TabPages.Remove(x);
                        }
                    }
                    else return;
                }
                List<int> allID = new List<int>();
                allID = busAssessment.getAllIDbyComponentID(IDNodeTreeList);
                foreach (int id in allID)
                {
                    busRiskGraph.delete(id);
                    busEquipment.delete(busEquipment.getData(id));
                    busComponent.delete(busComponent.getData(id));
                    busExtcorTemp.delete(id);
                    busCoating.delete(id);
                    busMaterial.delete(id);
                    busInputCALevel1.delete(id);
                    busInputCATank.delete(id);
                    busCALevel1.delete(id);
                    busCATank.delete(id);
                    busFullPoF.delete(id);
                    busStream.delete(id);
                    busFullFCoF.delete(id);
                    busAssessment.delete(id);
                }
                busComponentMaster.delete(IDNodeTreeList);
                initDataforTreeList();
                treeListProject.ExpandToLevel(treeListProject.FocusedNode.Level);
            }
            else return;
        }

        private void deleteEquipment(object sender, EventArgs e)
        {
            /*Cần xóa dữ liệu ở các bảng:
             * RW_ASSESSMENT
             * RW_EQUIPMENT
             * RW_COMPONENT
             * RW_EXTCOR_TEMPERATURE
             * RW_COATING
             * RW_MATERIAL
             * RW_INPUT_CA_LEVEL1
             * RW_INPUT_CA_TANK
             * RW_CA_LEVEL1
             * RW_CA_TANK
             * RW_FULL_POF
             * RW_STREAM
             * RW_FULL_FCOF
             * COMPONENT_MASTER
             * EQUIPMENT_MASTER
             */
            List<int> lstAssessmentID = busEquipmentMaster.GetAllAssessmentIDbyEquipmentID(IDNodeTreeList);
            DialogResult da = MessageBox.Show("Do you want to delete equipment?\nAll data below will be loss", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (da == DialogResult.Yes)
            {
                
                List<XtraTabPage> temp = new List<XtraTabPage>();
                foreach (XtraTabPage x in xtraTabData.TabPages)
                {
                    foreach (int i in lstAssessmentID)
                    {
                        if (x.Name == i.ToString())
                        {
                            temp.Add(x);
                        }
                    }
                }
                if (temp.Count != 0)
                {
                    if (MessageBox.Show(temp.Count + " Record(s) are opening! Do you want close it?", "Cortek RBI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        foreach (XtraTabPage x in temp)
                        {
                            xtraTabData.TabPages.Remove(x);
                        }
                    }
                    else return;
                }
                List<int> listCompID = busComponentMaster.getAllIDbyEquipmentID(IDNodeTreeList);
                foreach (int compID in listCompID)
                {
                    List<int> allAssessID = busAssessment.getAllIDbyComponentID(compID);
                    foreach (int id in allAssessID)
                    {
                        busRiskGraph.delete(id);
                        busEquipment.delete(busEquipment.getData(id));
                        busComponent.delete(busComponent.getData(id));
                        busExtcorTemp.delete(id);
                        busCoating.delete(id);
                        busMaterial.delete(id);
                        busInputCALevel1.delete(id);
                        busInputCATank.delete(id);
                        busCALevel1.delete(id);
                        busCATank.delete(id);
                        busFullPoF.delete(id);
                        busStream.delete(id);
                        busFullFCoF.delete(id);
                        busAssessment.delete(id);
                    }
                    busComponentMaster.delete(compID);
                }
                busEquipmentMaster.delete(IDNodeTreeList);
                initDataforTreeList();
            }
            else return;
        }
        
        private void deleteFacility(object sender, EventArgs e)
        {
            /*Cần xóa dữ liệu ở các bảng:
             * RW_ASSESSMENT
             * RW_EQUIPMENT
             * RW_COMPONENT
             * RW_EXTCOR_TEMPERATURE
             * RW_COATING
             * RW_MATERIAL
             * RW_INPUT_CA_LEVEL1
             * RW_INPUT_CA_TANK
             * RW_CA_LEVEL1
             * RW_CA_TANK
             * RW_FULL_POF
             * RW_STREAM
             * RW_FULL_FCOF
             * COMPONENT_MASTER
             * EQUIPMENT_MASTER
             * FACILITY
             */
            List<int> lstEquipmentID = busEquipmentMaster.getAllEqIDbyFaciID(IDNodeTreeList);
            DialogResult da = MessageBox.Show("Do you want to delete facility?\nAll data below will be loss", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (da == DialogResult.Yes)
            {
                int k = 0;
                List<XtraTabPage> x = new List<XtraTabPage>();
                k = CountAssessmentOpen(IDNodeTreeList, out x);
                if (k != 0)
                {
                    if (MessageBox.Show(k + " Record(s) are opening! Do you want close it?", "Cortek RBI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        foreach (XtraTabPage x1 in x)
                        {
                            xtraTabData.TabPages.Remove(x1);
                        }
                    }
                    else return;
                }
                foreach (int eqID in lstEquipmentID)
                {
                    List<int> listCompID = busComponentMaster.getAllIDbyEquipmentID(eqID);
                    foreach (int compID in listCompID)
                    {
                        List<int> allAssessID = busAssessment.getAllIDbyComponentID(compID);
                        foreach (int id in allAssessID)
                        {
                            busRiskGraph.delete(id);
                            busEquipment.delete(busEquipment.getData(id));
                            busComponent.delete(busComponent.getData(id));
                            busExtcorTemp.delete(id);
                            busCoating.delete(id);
                            busMaterial.delete(id);
                            busInputCALevel1.delete(id);
                            busInputCATank.delete(id);
                            busCALevel1.delete(id);
                            busCATank.delete(id);
                            busFullPoF.delete(id);
                            busStream.delete(id);
                            busFullFCoF.delete(id);
                            busAssessment.delete(id);
                        }
                        busComponentMaster.delete(compID);
                    }
                    busEquipmentMaster.delete(eqID);
                }
                busFacility.delete(IDNodeTreeList);
                initDataforTreeList();
            }
            else return;
        }
        private int CountAssessmentOpen(int faciID, out List<XtraTabPage> x1)
        {
            List<int> lstEquipmentID = busEquipmentMaster.getAllEqIDbyFaciID(faciID);
            int k = 0;
            List<XtraTabPage> xtab = new List<XtraTabPage>();
            foreach (int i in lstEquipmentID)
            {
                List<int> lstAss = busEquipmentMaster.GetAllAssessmentIDbyEquipmentID(i);
                foreach (XtraTabPage x in xtraTabData.TabPages)
                {
                    foreach (int j in lstAss)
                    {
                        if (j.ToString() == x.Name)
                        {
                            k++;
                            xtab.Add(x);
                        }
                    }
                }
            }
            x1 = xtab;
            return k;
        }
        private void deleteSite(object sender, EventArgs e)
        {
            /*Cần xóa dữ liệu ở các bảng:
             * RW_ASSESSMENT
             * RW_EQUIPMENT
             * RW_COMPONENT
             * RW_EXTCOR_TEMPERATURE
             * RW_COATING
             * RW_MATERIAL
             * RW_INPUT_CA_LEVEL1
             * RW_INPUT_CA_TANK
             * RW_CA_LEVEL1
             * RW_CA_TANK
             * RW_FULL_POF
             * RW_STREAM
             * RW_FULL_FCOF
             * COMPONENT_MASTER
             * EQUIPMENT_MASTER
             * FACILITY
             * SITES
             */
            DialogResult da = MessageBox.Show("Do you want to delete site?\nAll data below will be loss", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (da == DialogResult.Yes)
            {
                int k = 0;
                List<int> listFaciId = busFacility.getAllFaciIDbySiteID(IDNodeTreeList);
                List<XtraTabPage> xtratab = new List<XtraTabPage>();
                foreach(int i in listFaciId)
                {
                    List<XtraTabPage> a = new List<XtraTabPage>();
                    k += CountAssessmentOpen(i, out a);
                    xtratab.AddRange(a);
                }
                if (k != 0)
                {
                    if (MessageBox.Show(k + " Record(s) are opening! Do you want close it?", "Cortek RBI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        foreach (XtraTabPage x in xtratab)
                        {
                            xtraTabData.TabPages.Remove(x);
                        }
                    }
                    else return;
                }
                foreach (int faciID in listFaciId)
                {
                    List<int> listEqID = busEquipmentMaster.getAllEqIDbyFaciID(faciID);
                    foreach (int EqID in listEqID)
                    {
                        List<int> listCompID = busComponentMaster.getAllIDbyEquipmentID(EqID);
                        foreach (int compID in listCompID)
                        {
                            List<int> allID = new List<int>();
                            allID = busAssessment.getAllIDbyComponentID(compID);
                            foreach (int id in allID)
                            {
                                busRiskGraph.delete(id);
                                busEquipment.delete(busEquipment.getData(id));
                                busComponent.delete(busComponent.getData(id));
                                busExtcorTemp.delete(id);
                                busCoating.delete(id);
                                busMaterial.delete(id);
                                busInputCALevel1.delete(id);
                                busInputCATank.delete(id);
                                busCALevel1.delete(id);
                                busCATank.delete(id);
                                busFullPoF.delete(id);
                                busStream.delete(id);
                                busFullFCoF.delete(id);
                                busAssessment.delete(id);
                            }
                            busComponentMaster.delete(compID);
                        }
                        busEquipmentMaster.delete(EqID);
                    }
                    busFacility.delete(faciID);
                }
                busSites.delete(IDNodeTreeList);
            }
            initDataforTreeList();
        }
        private void btn_add_site_click(object sender, EventArgs e)
        {
            frmNewSite site = new frmNewSite();
            site.ShowDialog();
            if (site.ButtonOKClicked)
                initDataforTreeList();
        }
        private void treeListProject_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            
            if (treeListProject.Nodes.Count == 0) //tránh lỗi khi treelist rỗng
                return;
            //<show edit equipment and component>
            int levelNode = treeListProject.FocusedNode.Level;
            switch (levelNode)
            {
                case 1: // edit data cho Facility
                    frmFacilityInput fcInput = new frmFacilityInput(listTree1[hi.Node.Id].ID - hi.Node.Level * 100000);
                    fcInput.doubleEditClicked = true;
                    fcInput.ShowInTaskbar = false;
                    fcInput.ShowDialog();
                    if (fcInput.ButtonOKClicked)
                        initDataforTreeList();
                    return;
                case 2: //edit data cho Equipment
                    frmEquipment eq = new frmEquipment(listTree1[hi.Node.Id].ID - (hi.Node.Level - 1) * 200000);
                    eq.doubleEditClicked = true;
                    eq.ShowInTaskbar = false;
                    eq.ShowDialog();
                    if (eq.ButtonOKCliked)
                        initDataforTreeList();
                    return;
                case 3: //edit data cho Component
                    int comID = listTree1[hi.Node.Id].ID - (hi.Node.Level - 2) * 300000;
                    frmNewComponent comEdit = new frmNewComponent(comID);
                    comEdit.doubleEditClicked = true;
                    comEdit.ShowInTaskbar = false;
                    comEdit.ShowDialog();
                    if (comEdit.ButtonOKClicked)
                        initDataforTreeList();
                    return;
                default:
                    break;
            }
            //</show edit equipment and component>
            if (treeListProject.FocusedNode.Level == 4) //check xem co phai la Proposal
            {
                btnSave.Enabled = true;
                navBarMainmenu.Expanded = false;
                navBarRecord.Visible = true;
                navBarRecord.Expanded = true;
            }
            if (hi.Node != null)
            {
                IDProposal = listTree1[hi.Node.Id].ID - hi.Node.Level * 100000;
                Console.WriteLine("ID Proposal " + IDProposal);
                if (treeListProject.FocusedNode.GetValue(0).ToString() != xtraTabData.SelectedTabPage.Name && treeListProject.FocusedNode.Level == 4)
                {
                    int equipmentID = busAssessment.getEquipmentID(IDProposal);
                    int equipmentTypeID = busEquipmentMaster.getEquipmentTypeID(equipmentID);
                    String EquipmentTypeName = busEquipmentType.getEquipmentTypeName(equipmentTypeID);
                    if (EquipmentTypeName != "Tank")
                    {
                        UCAssessmentInfo _ass = new UCAssessmentInfo(IDProposal);
                        UCEquipmentProperties equipment = new UCEquipmentProperties(IDProposal, temperature, volume);
                        UCComponentProperties component = new UCComponentProperties(IDProposal, diameter, thickness, corrosionRate);
                        UCOperatingCondition op = new UCOperatingCondition(IDProposal, temperature, pressure, flowRate);
                        UCCoatLiningIsulationCladding coat = new UCCoatLiningIsulationCladding(IDProposal, corrosionRate);
                        UCMaterial material = new UCMaterial(IDProposal, temperature, pressure, stress, corrosion, thickness);
                        UCStream stream = new UCStream(IDProposal);
                        UCCA ca = new UCCA(IDProposal, finacialUnit);
                        //UCMaterial material = new UCMaterial(IDProposal);
                        //UCStream stream = new UCStream(IDProposal);
                        //UCCA ca =  new UCCA(IDProposal);
                        UCRiskFactor riskFactor = new UCRiskFactor(IDProposal);
                        UCRiskSummary riskSummary =  new UCRiskSummary(IDProposal);
                        UCDrawGraph drawGraph =  new UCDrawGraph(IDProposal);
                        UCInspectionHistorySubform inspection = new UCInspectionHistorySubform(IDProposal);
                        _ass.DataChanged += ThayDoiDuLieu;
                        _ass.CtrlS_Press += CtrlS_Press;

                        equipment.DataChanged += ThayDoiDuLieu;
                        equipment.CtrlS_Press += CtrlS_Press;

                        component.DataChanged += ThayDoiDuLieu;
                        component.CtrlS_Press += CtrlS_Press;

                        op.DataChanged += ThayDoiDuLieu;
                        op.CtrlS_Press += CtrlS_Press;

                        coat.DataChanged += ThayDoiDuLieu;
                        coat.CtrlS_Press += CtrlS_Press;

                        material.DataChanged += ThayDoiDuLieu;
                        material.CtrlS_Press += CtrlS_Press;

                        stream.DataChanged += ThayDoiDuLieu;
                        stream.CtrlS_Press += CtrlS_Press;
                        
                        checkTank = false;
                        ucTabNormal ucTabnormal = new ucTabNormal(IDProposal, _ass, equipment, component, op, coat, material, stream, ca, riskFactor, riskSummary, inspection, drawGraph);
                        listUC.Add(ucTabnormal);
                        addNewTab(treeListProject.FocusedNode.ParentNode.GetValue(0).ToString() + "[" + treeListProject.FocusedNode.GetValue(0).ToString() + "]", ucTabnormal.ucAss);
                    }
                    else
                    {
                        
                        int componentTypeID = busComponentMaster.getComponentTypeID(treeListProject.FocusedNode.ParentNode.GetValue(0).ToString());
                        string type = null;
                        switch(componentTypeID)
                        {
                            case 8:
                                type = "Shell";
                                break;
                            case 12:
                                type = "Bottom";
                                break;
                            default:
                                break;
                        }
                        navCA.Enabled = false;
                        checkTank = true;
                        UCAssessmentInfo assTank = new UCAssessmentInfo(IDProposal);
                        UCEquipmentPropertiesTank eqTank = new UCEquipmentPropertiesTank(IDProposal, type, temperature, volume);
                        UCComponentPropertiesTank compTank = new UCComponentPropertiesTank(IDProposal, type, diameter, thickness, corrosionRate);
                        UCOperatingCondition conTank = new UCOperatingCondition(IDProposal, temperature, pressure, flowRate);
                        UCCoatLiningIsulationCladding coat = new UCCoatLiningIsulationCladding(IDProposal, corrosionRate);
                        UCMaterialTank materialTank = new UCMaterialTank(IDProposal, temperature, pressure, stress, thickness, corrosion);
                        UCStreamTank streamTank = new UCStreamTank(IDProposal);
                        UCRiskFactor riskFactor = new UCRiskFactor(IDProposal);
                        UCRiskSummary riskSummary = new UCRiskSummary(IDProposal);
                        UCDrawGraph drawGraph = new UCDrawGraph(IDProposal);
                        UCInspectionHistorySubform inspection = new UCInspectionHistorySubform(IDProposal);
                        ucTabTank ucTank = new ucTabTank(IDProposal, assTank, eqTank, compTank, conTank, coat, materialTank, streamTank, riskFactor, riskSummary, inspection, drawGraph);
                        listUCTank.Add(ucTank);
                        addNewTab(treeListProject.FocusedNode.ParentNode.GetValue(0).ToString() + "[" + treeListProject.FocusedNode.GetValue(0).ToString() + "]", ucTank.ucAss);
                    }
                    if (checkTank)
                    {
                        navCA.Visible = false;
                    }
                    else
                    {
                        navCA.Visible = true;
                        navCA.Enabled = true;
                    }
                }
                else
                    return;
            }
        }
        private void treeListProject_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (hi.Node == null)
                return;
            selectedLevel = hi.Node.Level;
            switch (selectedLevel)
            {
                //lấy id của node phục vụ cho việc xóa
                case 0:
                    IDNodeTreeList = listTree[hi.Node.Id].ID;
                    break;
                case 1:
                    IDNodeTreeList = listTree[hi.Node.Id].ID - hi.Node.Level * 100000;
                    break;
                case 2:
                    IDNodeTreeList = listTree[hi.Node.Id].ID - (hi.Node.Level - 1) * 200000;
                    break;
                case 3:
                    IDNodeTreeList = listTree[hi.Node.Id].ID - (hi.Node.Level - 2) * 300000;
                    break;
                case 4:
                    IDNodeTreeList = listTree[hi.Node.Id].ID - (hi.Node.Level - 3) * 400000;
                    break;
                default:
                    break;
            }

            if (e.Menu is TreeListNodeMenu)
            {
                if (selectedLevel == 0)
                {
                    treeListProject.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Add Site", btn_add_site_click));
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Add Facility", btn_add_facility_click));
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Edit Site Name", btn_edit_site_name));
                    e.Menu.Items.Add(new DXMenuItem("Delete Site", deleteSite));
                }
                else if (selectedLevel == 1)
                {
                    treeListProject.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Add Equipment", btn_add_Equipment_click));
                    e.Menu.Items.Add(new DXMenuItem("Delete Facility", deleteFacility));
                }
                else if (selectedLevel == 2)
                {
                    treeListProject.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Add Component", btn_add_Component_click));
                    e.Menu.Items.Add(new DXMenuItem("Delete Equipment", deleteEquipment));
                }
                else if (selectedLevel == 3)
                {
                    treeListProject.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Add Record", addNewRecord));
                    e.Menu.Items.Add(new DXMenuItem("Delete Component", deleteComponent));
                }
                else
                {
                    treeListProject.FocusedNode = ((TreeListNodeMenu)e.Menu).Node;
                    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Delete Record", deleteRecord));
                }
            }
        }
        private void xtraTabData_CloseButtonClick(object sender, EventArgs e)
        {
            //DevExpress.XtraTab.XtraTabControl tabControl = sender as DevExpress.XtraTab.XtraTabControl;
            //DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            //(arg.Page as DevExpress.XtraTab.XtraTabPage).Dispose();
            if (xtraTabData.SelectedTabPage.Text.Contains('*'))
                MessageBox.Show("Save file", "Cortek RBI");
            //previousUC.RemoveAt(tabPageIndex);
            navBarRecord.Visible = false; // Thao
            navBarMainmenu.Expanded = true;
            xtraTabData.SelectedTabPage.Controls.Clear();
            xtraTabData.SelectedTabPage.Dispose();
        }
        private void xtraTabData_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            tabPageIndex = xtraTabData.SelectedTabPageIndex - 1;
            int id_proposal;
            if (int.TryParse(xtraTabData.SelectedTabPage.Name, out id_proposal))
            {
                tabPageIndex = xtraTabData.SelectedTabPageIndex - 1;
                int eqID = busAssessment.getEquipmentID(id_proposal);
                int eqTypeID = busEquipmentMaster.getEqTypeID(eqID);
                navBarRecord.Visible = true; //mai // Hien thi navbar
                // set mau cac thuoc tinh ve mau den mac dinh
                navAssessmentInfo.Appearance.ForeColor = navEquipment.Appearance.ForeColor = 
                    navComponent.Appearance.ForeColor = navOperating.Appearance.ForeColor = 
                    navMaterial.Appearance.ForeColor = navCoating.Appearance.ForeColor = 
                    navNoInspection.Appearance.ForeColor = navStream.Appearance.ForeColor = 
                    navRiskFactor.Appearance.ForeColor = navCA.Appearance.ForeColor = 
                    navRiskSummary.Appearance.ForeColor =
                    navViewGraph.Appearance.ForeColor = Color.Black;
                // end mai
                switch (eqTypeID)
                {
                    case 10: //tank
                    case 11:
                        navCA.Visible = false;
                        checkTank = true;
                        break;
                    default: //thuong
                        navCA.Visible = true;
                        navCA.Enabled = true;
                        checkTank = false;
                        break;
                }
            }
        }
        #endregion
        private void CtrlS_Press(object sender, CtrlSPressEventArgs e)
        {
            string str = xtraTabData.SelectedTabPage.Text;
            int ID = Convert.ToInt32(xtraTabData.SelectedTabPage.Name);
            if (str.Contains("*"))
            {
                Control.ControlCollection ct = xtraTabData.SelectedTabPage.Controls;
                foreach (Control c in ct)
                {
                    if (c is UCAssessmentInfo)
                    {
                        CtrlSPress_SaveData(c.Name, ID, c);
                        initDataforTreeList();
                        int[] comID = busAssessment.getEquipmentID_ComponentID(ID);
                        string comNum = busComponent.GetComponentNumber(comID[1]);
                        string assName = busAssessment.getAssessmentName(ID);
                        xtraTabData.SelectedTabPage.Text = comNum + "[" + assName + "]";
                    }
                    CtrlSPress_SaveData(c.Name, ID, c);
                    barStaticItem2.Caption = "Saved";
                }
                xtraTabData.SelectedTabPage.Text = str.Remove(str.Length - 1); //luu data va bo dau *
            }
        } // mai
        private void ThayDoiDuLieu(object sender, DataUCChangedEventArgs e) // mai
        {
            string str = xtraTabData.SelectedTabPage.Text;
            if (str.Contains("*")) return;
            else xtraTabData.SelectedTabPage.Text += "*";
        }
        private void CtrlSPress_SaveData(string ucName, int ID, object uc)
        {
            switch (ucName)
            {
                case "UCAssessmentInfo":
                    UCAssessmentInfo ass = uc as UCAssessmentInfo;
                    RW_ASSESSMENT rwAss = ass.getData(ID);
                    busAssessment.edit(rwAss);
                    break;
                case "UCEquipmentProperties":
                    UCEquipmentProperties eq = uc as UCEquipmentProperties;
                    RW_EQUIPMENT rwEq = eq.getData(ID, temperature, volume);
                    busEquipment.edit(rwEq);
                    break;
                case "UCEquipmentPropertiesTank":
                    UCEquipmentPropertiesTank eq1 = uc as UCEquipmentPropertiesTank;
                    RW_EQUIPMENT rwEq1 = eq1.getData(ID, temperature, volume);
                    busEquipment.edit(rwEq1);
                    break;
                case "UCComponentProperties":
                    UCComponentProperties com = uc as UCComponentProperties;
                    RW_COMPONENT rwCom = com.getData(ID, diameter, thickness, corrosionRate);
                    busComponent.edit(rwCom);
                    break;
                case "UCComponentPropertiesTank":
                    UCComponentPropertiesTank com1 = uc as UCComponentPropertiesTank;
                    RW_COMPONENT rwCom1 = com1.getData(ID, diameter, thickness, corrosionRate);
                    busComponent.edit(rwCom1);
                    break;
                case "UCMaterial":
                    UCMaterial ma = uc as UCMaterial;
                    RW_MATERIAL rwMa = ma.getData(ID, temperature, pressure, stress, corrosion, thickness);
                    busMaterial.edit(rwMa);
                    break;
                case "UCMaterialTank":
                    UCMaterialTank ma1 = uc as UCMaterialTank;
                    RW_MATERIAL rwMa1 = ma1.getData(ID, temperature, pressure, stress, thickness, corrosion);
                    busMaterial.edit(rwMa1);
                    break;
                case "UCOperatingCondition":
                    UCOperatingCondition op = uc as UCOperatingCondition;
                    RW_STREAM rwStream = op.getDataforStream(ID, temperature, pressure, flowRate);
                    RW_EXTCOR_TEMPERATURE rwExtr = op.getDataExtcorTemp(ID);
                    busStream.edit(rwStream);
                    busExtcorTemp.edit(rwExtr);
                    break;
                case "UCStream":
                    UCStream stream1 = uc as UCStream;
                    RW_STREAM rwStream1 = stream1.getData(ID);
                    busStream.edit(rwStream1);
                    break;
                case "UCStreamTank":
                    UCStreamTank stream = uc as UCStreamTank;
                    RW_STREAM rwStream2 = stream.getData(ID);
                    busStream.edit(rwStream2);
                    break;
                case "UCCA":
                    UCCA ca = uc as UCCA;
                    RW_INPUT_CA_LEVEL_1 rwCA = ca.getData(ID);
                    busInputCALevel1.edit(rwCA);
                    break;
                default:
                    break;
            }
        } // mai
        private void treeListProject_KeyDown(object sender, KeyEventArgs e)
        {
            EditDataForNode(sender);
        }  // mai
        #region Function Tu viet
        private void EditDataForNode(object sender)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            int levelNode = treeListProject.FocusedNode.Level;
            switch (levelNode)
            {
                case 1: // edit data cho Facility
                    frmFacilityInput fcInput = new frmFacilityInput(listTree1[hi.Node.Id].ID - hi.Node.Level * 100000);
                    fcInput.doubleEditClicked = true;
                    fcInput.ShowInTaskbar = false;
                    fcInput.ShowDialog();
                    if (fcInput.ButtonOKClicked)
                        initDataforTreeList();
                    return;
                case 2: //edit data cho Equipment
                    frmEquipment eq = new frmEquipment(listTree1[hi.Node.Id].ID - (hi.Node.Level - 1) * 200000);
                    eq.doubleEditClicked = true;
                    eq.ShowInTaskbar = false;
                    eq.ShowDialog();
                    if (eq.ButtonOKCliked)
                        initDataforTreeList();
                    return;
                case 3: //edit data cho Component
                    int comID = listTree1[hi.Node.Id].ID - (hi.Node.Level - 2) * 300000;
                    frmNewComponent comEdit = new frmNewComponent(comID);
                    comEdit.doubleEditClicked = true;
                    comEdit.ShowInTaskbar = false;
                    comEdit.ShowDialog();
                    if (comEdit.ButtonOKClicked)
                        initDataforTreeList();
                    return;
                default:
                    break;
            }
        }
        private void InitDictionaryDMMachenism()
        {
            for(int i = 0; i < DM_ID.Length; i++)
            {
                damageMachenism.Add(DM_ID[i], DM_Name[i]);
            }
        }
        private void PoF(out RW_FULL_POF full_pof, out InputInspectionCalculation insplant, out MSSQL_DM_CAL calDM, out List<RW_DAMAGE_MECHANISM> DMmachenism, String ThinningType, String componentNumber, RW_EQUIPMENT eq, RW_COMPONENT com, RW_MATERIAL ma, RW_STREAM st, RW_COATING coat, RW_EXTCOR_TEMPERATURE tem)
        {
            InputInspectionCalculation inspl = new InputInspectionCalculation();
            
            #region PoF
            //get EquipmentID ----> get EquipmentTypeName and APIComponentType
            int equipmentID = busAssessment.getEquipmentID(IDProposal);
            String equipmentTypename = busEquipmentType.getEquipmentTypeName(busEquipmentMaster.getEquipmentTypeID(equipmentID));
            int apiID = busComponentMaster.getAPIComponentTypeID(equipmentID);
            string API_ComponentType_Name = busApiComponentType.getAPIComponentTypeName(apiID);
            
            MSSQL_DM_CAL cal = new MSSQL_DM_CAL();
            cal.APIComponentType = API_ComponentType_Name;
            //<input thinning>
            cal.Diametter = com.NominalDiameter;
            cal.NomalThick = com.NominalThickness;
            cal.CurrentThick = com.CurrentThickness;
            cal.MinThickReq = com.MinReqThickness;
            cal.CorrosionRate = com.CurrentCorrosionRate;
            cal.ProtectedBarrier = eq.DowntimeProtectionUsed == 1 ? true : false; //xem lai
            cal.CladdingCorrosionRate = coat.CladdingCorrosionRate;
            cal.InternalCladding = coat.InternalCladding == 1 ? true : false;
            cal.NoINSP_THINNING = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[0]);
            Console.WriteLine("noInspection:" + cal.NoINSP_THINNING);
            cal.EFF_THIN = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[0]);
            cal.OnlineMonitoring = eq.OnlineMonitoring;
            cal.HighlyEffectDeadleg = eq.HighlyDeadlegInsp == 1 ? true : false;
            cal.ContainsDeadlegs = eq.ContainsDeadlegs == 1 ? true : false;
            cal.CA = ma.CorrosionAllowance;
            //tank maintain653 trong Tank
            cal.AdjustmentSettle = eq.AdjustmentSettle;
            cal.ComponentIsWeld = eq.ComponentIsWelded == 1 ? true : false;
            //</thinning>

            //<input linning>
            cal.LinningType = coat.InternalLinerType;
            cal.LINNER_ONLINE = eq.LinerOnlineMonitoring == 1 ? true : false;
            cal.LINNER_CONDITION = coat.InternalLinerCondition;
            cal.INTERNAL_LINNING = coat.InternalLining == 1 ? true : false;
            TimeSpan year = busAssessment.getAssessmentDate(IDProposal) - busInspectionHistory.getLastInsp(componentNumber, DM_Name[1], busEquipmentMaster.getComissionDate(equipmentID));
            cal.YEAR_IN_SERVICE = (int)(year.Days / 365); //Yearinservice hiệu tham số giữa lần tính toán và ngày cài đặt hệ thống
            //</input linning>

            //<input SCC CAUSTIC>
            cal.CAUSTIC_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[2]);
            cal.CAUSTIC_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[2]);
            cal.HEAT_TREATMENT = ma.HeatTreatment;
            cal.NaOHConcentration = st.NaOHConcentration;
            cal.HEAT_TRACE = eq.HeatTraced == 1 ? true : false;
            cal.STEAM_OUT = eq.SteamOutWaterFlush == 1 ? true : false;
            //</SCC CAUSTIC>

            //<input SCC Amine>
            cal.AMINE_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[3]);
            cal.AMINE_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[3]);
            cal.AMINE_EXPOSED = st.ExposedToGasAmine == 1 ? true : false;
            cal.AMINE_SOLUTION = st.AmineSolution;
            //</input SCC Amine>

            //<input SCC Sulphide Stress Cracking>
            cal.ENVIRONMENT_H2S_CONTENT = st.H2S == 1 ? true : false;
            cal.AQUEOUS_OPERATOR = st.AqueousOperation == 1 ? true : false;
            cal.AQUEOUS_SHUTDOWN = st.AqueousShutdown == 1 ? true : false;
            cal.SULPHIDE_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[4]);
            cal.SULPHIDE_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[4]);
            cal.H2SContent = st.H2SInWater;
            cal.PH = st.WaterpH;
            cal.PRESENT_CYANIDE = st.Cyanide == 1 ? true : false;
            cal.BRINNEL_HARDNESS = com.BrinnelHardness;
            //</Sulphide Stress Cracking>

            //<input HIC/SOHIC-H2S>
            cal.SULFUR_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[5]);
            cal.SULFUR_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[5]);
            cal.SULFUR_CONTENT = ma.SulfurContent;
            //</HIC/SOHIC-H2S>

            //<input SCC Damage Factor Carbonate Cracking>
            cal.CO3_CONCENTRATION = st.CO3Concentration;
            cal.CACBONATE_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[6]);
            cal.CACBONATE_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[6]);
            //</SCC Damage Factor Carbonate Cracking>

            //<input PTA Cracking>
            cal.PTA_SUSCEP = ma.IsPTA == 1 ? true : false;
            cal.NICKEL_ALLOY = ma.NickelBased == 1 ? true : false;
            cal.EXPOSED_SULFUR = st.ExposedToSulphur == 1 ? true : false;
            cal.PTA_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[7]);
            cal.PTA_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[7]);
            cal.ExposedSH2OOperation = eq.PresenceSulphidesO2 == 1 ? true : false;
            cal.ExposedSH2OShutdown = eq.PresenceSulphidesO2Shutdown == 1 ? true : false;
            cal.ThermalHistory = eq.ThermalHistory;
            cal.PTAMaterial = ma.PTAMaterialCode;
            cal.DOWNTIME_PROTECTED = eq.DowntimeProtectionUsed == 1 ? true : false;
            //</PTA Cracking>

            //<input CLSCC>
            cal.CLSCC_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[8]);
            cal.CLSCC_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[8]);
            cal.EXTERNAL_EXPOSED_FLUID_MIST = eq.MaterialExposedToClExt == 1 ? true : false;
            cal.INTERNAL_EXPOSED_FLUID_MIST = st.MaterialExposedToClInt == 1 ? true : false;
            cal.CHLORIDE_ION_CONTENT = st.Chloride;
            //</CLSCC>

            //<input HSC-HF>
            cal.HSC_HF_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[9]);
            cal.HSC_HF_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[9]);
            //</HSC-HF>

            //<input External Corrosion>
            cal.EXTERNAL_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[11]);
            cal.EXTERNAL_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[11]);
            //</External Corrosion>

            //<input HIC/SOHIC-HF>
            cal.HICSOHIC_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[10]);
            cal.HICSOHIC_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[10]);
            cal.HF_PRESENT = st.Hydrofluoric == 1 ? true : false;
            //</HIC/SOHIC-HF>

            //<input CUI DM>
            cal.INTERFACE_SOIL_WATER = eq.InterfaceSoilWater == 1 ? true : false;
            cal.SUPPORT_COATING = coat.SupportConfigNotAllowCoatingMaint == 1 ? true : false;
            cal.INSULATION_TYPE = coat.ExternalInsulationType;
            cal.CUI_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[12]);
            cal.CUI_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[12]);
            cal.CUI_INSP_DATE = coat.ExternalCoatingDate;
            cal.CUI_PERCENT_1 = tem.Minus12ToMinus8;
            cal.CUI_PERCENT_2 = tem.Minus8ToPlus6;
            cal.CUI_PERCENT_3 = tem.Plus6ToPlus32;
            cal.CUI_PERCENT_4 = tem.Plus32ToPlus71;
            cal.CUI_PERCENT_5 = tem.Plus71ToPlus107;
            cal.CUI_PERCENT_6 = tem.Plus107ToPlus121;
            cal.CUI_PERCENT_7 = tem.Plus121ToPlus135;
            cal.CUI_PERCENT_8 = tem.Plus135ToPlus162;
            cal.CUI_PERCENT_9 = tem.Plus162ToPlus176;
            cal.CUI_PERCENT_10 = tem.MoreThanPlus176;
            //</CUI DM>

            //<input External CLSCC>
            cal.EXTERN_CLSCC_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[13]);
            cal.EXTERN_CLSCC_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[13]);
            //</External CLSCC>

            //<input External CUI CLSCC>
            cal.EXTERN_CLSCC_CUI_INSP_EFF = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[14]);
            cal.EXTERN_CLSCC_CUI_INSP_NUM = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[14]);
            cal.EXTERNAL_INSULATION = coat.ExternalInsulation == 1 ? true : false;
            cal.COMPONENT_INSTALL_DATE = eq.CommissionDate;
            cal.CRACK_PRESENT = com.CracksPresent == 1 ? true : false;
            cal.EXTERNAL_EVIRONMENT = eq.ExternalEnvironment;
            cal.EXTERN_COAT_QUALITY = coat.ExternalCoatingQuality;
            cal.PIPING_COMPLEXITY = com.ComplexityProtrusion;
            cal.INSULATION_CONDITION = coat.InsulationCondition;
            cal.INSULATION_CHLORIDE = coat.InsulationContainsChloride == 1 ? true : false;
            //</External CUI CLSCC>

            //<input HTHA>
            cal.HTHA_EFFECT = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[15]);
            cal.HTHA_NUM_INSP = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[15]);
            cal.MATERIAL_SUSCEP_HTHA = ma.IsHTHA == 1 ? true : false;
            cal.HTHA_MATERIAL = ma.HTHAMaterialCode; //check lai
            cal.HTHA_PRESSURE = st.H2SPartialPressure * 0.006895f;
            cal.CRITICAL_TEMP = st.CriticalExposureTemperature; //check lai
            cal.DAMAGE_FOUND = com.DamageFoundInspection == 1 ? true : false;
            //</HTHA>

            //<input Brittle>
            cal.LOWEST_TEMP = eq.YearLowestExpTemp == 1 ? true : false;
            //</Brittle>

            //<input temper Embrittle>
            cal.TEMPER_SUSCEP = ma.Temper == 1 ? true : false;
            cal.PWHT = eq.PWHT == 1 ? true : false;
            cal.BRITTLE_THICK = ma.BrittleFractureThickness;
            cal.CARBON_ALLOY = ma.CarbonLowAlloy == 1 ? true : false;
            cal.DELTA_FATT = com.DeltaFATT;
            //</Temper Embrittle>

            //<input 885>
            cal.MAX_OP_TEMP = st.MaxOperatingTemperature;
            cal.MIN_OP_TEMP = st.MinOperatingTemperature;
            cal.MIN_DESIGN_TEMP = ma.MinDesignTemperature;
            cal.REF_TEMP = ma.ReferenceTemperature;
            cal.CHROMIUM_12 = ma.ChromeMoreEqual12 == 1 ? true : false;
            //</885>

            //<input Sigma>
            cal.AUSTENITIC_STEEL = ma.Austenitic == 1 ? true : false;
            cal.PERCENT_SIGMA = ma.SigmaPhase;
            //</Sigma>

            //<input Piping Mechanical>
            cal.EquipmentType = equipmentTypename;
            cal.PREVIOUS_FAIL = com.PreviousFailures;
            cal.AMOUNT_SHAKING = com.ShakingAmount;
            cal.TIME_SHAKING = com.ShakingTime;
            cal.CYLIC_LOAD = com.CyclicLoadingWitin15_25m;
            cal.CORRECT_ACTION = com.CorrectiveAction;
            cal.NUM_PIPE = com.NumberPipeFittings;
            cal.PIPE_CONDITION = com.PipeCondition;
            cal.JOINT_TYPE = com.BranchJointType; //check lai
            cal.BRANCH_DIAMETER = com.BranchDiameter;
            //</Piping Mechanical>

            //<Calculate DF>

            float[] Df = new float[21];
            float[] age = new float[14];
            for (int i = 0; i < 13; i++)
            {
                age[i] = busInspectionHistory.getAge(componentNumber, DM_Name[i], busEquipmentMaster.getComissionDate(equipmentID), busAssessment.getAssessmentDate(IDProposal));
            }
            age[13] = busInspectionHistory.getAge(componentNumber, DM_Name[15], busEquipmentMaster.getComissionDate(equipmentID), busAssessment.getAssessmentDate(IDProposal));
            
            Df[0] = cal.DF_THIN(age[0]);
            Df[1] = cal.DF_LINNING(age[1]);
            Df[2] = cal.DF_CAUSTIC(age[2]);
            Df[3] = cal.DF_AMINE(age[3]);
            Df[4] = cal.DF_SULPHIDE(age[4]);
            Df[5] = cal.DF_HICSOHIC_H2S(age[5]);
            Df[6] = cal.DF_CACBONATE(age[6]);
            Df[7] = cal.DF_PTA(age[7]);
            Df[8] = cal.DF_CLSCC(age[8]);
            Df[9] = cal.DF_HSCHF(age[9]);
            Df[10] = cal.DF_HIC_SOHIC_HF(age[10]);
            Df[11] = cal.DF_EXTERNAL_CORROSION(age[11]);
            Df[12] = cal.DF_CUI(age[12]);
            Df[13] = cal.DF_EXTERN_CLSCC();
            Df[14] = cal.DF_CUI_CLSCC();
            Df[15] = cal.DF_HTHA(age[13]);
            Df[16] = cal.DF_BRITTLE();
            Df[17] = cal.DF_TEMP_EMBRITTLE();
            Df[18] = cal.DF_885();
            Df[19] = cal.DF_SIGMA();
            Df[20] = cal.DF_PIPE();

            
            List<float> DFSCCAgePlus3 = new List<float>();
            List<float> DFSCCAgePlus6 = new List<float>();
            float[] thinningPlusAge = { 0, 0 };
            float[] linningPlusAge = { 0, 0 };
            float[] DF_HTHAPlusAge = { 0, 0 };
            float[] DF_EXTERN_CORROSIONPlusAge = { 0, 0 };
            float[] DF_CUIPlusAge = { 0, 0 };

            List<RW_DAMAGE_MECHANISM> listDamageMachenism = new List<RW_DAMAGE_MECHANISM>();
            RW_FULL_POF fullPOF = new RW_FULL_POF();
            fullPOF.ID = IDProposal;
            for (int i = 0; i < 21; i++)
            {
                if (Df[i] >= 0)
                {
                    RW_DAMAGE_MECHANISM damage = new RW_DAMAGE_MECHANISM();
                    damage.ID = IDProposal;
                    damage.DMItemID = DM_ID[i];
                    damage.IsActive = 1;
                    damage.HighestInspectionEffectiveness = busInspectionHistory.getHighestInspEffec(componentNumber, DM_Name[i]);
                    damage.SecondInspectionEffectiveness = damage.HighestInspectionEffectiveness;
                    damage.NumberOfInspections = busInspectionHistory.InspectionNumber(componentNumber, DM_Name[i]);
                    damage.LastInspDate = busInspectionHistory.getLastInsp(componentNumber, DM_Name[i], eq.CommissionDate);

                    if (damage.LastInspDate.Year < 1753)
                    {
                        damage.LastInspDate = busEquipmentMaster.getComissionDate(equipmentID);
                    }
                    
                    damage.DF1 = Df[i];
                    switch (i)
                    {
                        case 0: //Thinning
                            damage.DF2 = cal.DF_THIN(age[0] + 3);
                            damage.DF3 = cal.DF_THIN(age[0] + 6);
                            thinningPlusAge[0] = damage.DF2;
                            thinningPlusAge[1] = damage.DF3;
                            break;
                        case 1: //Linning
                            damage.DF2 = cal.DF_LINNING(age[1] + 3);
                            damage.DF3 = cal.DF_LINNING(age[1] + 6);
                            linningPlusAge[0] = damage.DF2;
                            linningPlusAge[1] = damage.DF3;
                            break;
                        case 2: //Caustic
                            damage.DF2 = cal.DF_CAUSTIC(age[2] + 3);
                            damage.DF3 = cal.DF_CAUSTIC(age[2] + 6);
                            DFSCCAgePlus3.Add(damage.DF2);
                            DFSCCAgePlus6.Add(damage.DF3);
                            break;
                        case 3: //Amine
                            damage.DF2 = cal.DF_AMINE(age[3] + 3);
                            damage.DF3 = cal.DF_AMINE(age[3] + 6);
                            DFSCCAgePlus3.Add(damage.DF2);
                            DFSCCAgePlus6.Add(damage.DF3);
                            break;
                        case 4: //Sulphide
                            damage.DF2 = cal.DF_SULPHIDE(age[4] + 3);
                            damage.DF3 = cal.DF_SULPHIDE(age[4] + 6);
                            DFSCCAgePlus3.Add(damage.DF2);
                            DFSCCAgePlus6.Add(damage.DF3);
                            break;
                        case 5: //HIC/SOHIC-H2S
                            damage.DF2 = cal.DF_HICSOHIC_H2S(age[5] + 3);
                            damage.DF3 = cal.DF_HICSOHIC_H2S(age[5] + 6);
                            DFSCCAgePlus3.Add(damage.DF2);
                            DFSCCAgePlus6.Add(damage.DF3);
                            break;
                        case 6: //Carbonate
                            damage.DF2 = cal.DF_CACBONATE(age[6] + 3);
                            damage.DF3 = cal.DF_CACBONATE(age[6] + 6);
                            DFSCCAgePlus3.Add(damage.DF2);
                            DFSCCAgePlus6.Add(damage.DF3);
                            break;
                        case 7: //PTA (Polythionic Acid Stress Corrosion Cracking)
                            damage.DF2 = cal.DF_PTA(age[7] + 3);
                            damage.DF3 = cal.DF_PTA(age[7] + 6);
                            DFSCCAgePlus3.Add(damage.DF2);
                            DFSCCAgePlus6.Add(damage.DF3);
                            break;
                        case 8: //CLSCC (Chloride Stress Corrosion Cracking)
                            damage.DF2 = cal.DF_CLSCC(age[8] + 3);
                            damage.DF3 = cal.DF_CLSCC(age[8] + 6);
                            DFSCCAgePlus3.Add(damage.DF2);
                            DFSCCAgePlus6.Add(damage.DF3);
                            break;
                        case 9: //HSC-HF
                            damage.DF2 = cal.DF_HSCHF(age[9] + 3);
                            damage.DF3 = cal.DF_HSCHF(age[9] + 6);
                            DFSCCAgePlus3.Add(damage.DF2);
                            DFSCCAgePlus6.Add(damage.DF3);
                            break;
                        case 10: //HIC/SOHIC-HF
                            damage.DF2 = cal.DF_HIC_SOHIC_HF(age[10] + 3);
                            damage.DF3 = cal.DF_HIC_SOHIC_HF(age[10] + 6);
                            DFSCCAgePlus3.Add(damage.DF2);
                            DFSCCAgePlus6.Add(damage.DF3);
                            break;
                        case 11: //External Corrosion
                            damage.DF2 = cal.DF_EXTERNAL_CORROSION(age[11] + 3);
                            damage.DF3 = cal.DF_EXTERNAL_CORROSION(age[11] + 6);
                            DF_EXTERN_CORROSIONPlusAge[0] = damage.DF2;
                            DF_EXTERN_CORROSIONPlusAge[1] = damage.DF2;
                            break;
                        case 12: //CUI (Corrosion Under Insulation)
                            damage.DF2 = cal.DF_CUI(age[12] + 3);
                            damage.DF3 = cal.DF_CUI(age[12] + 6);
                            DF_CUIPlusAge[0] = damage.DF2;
                            DF_CUIPlusAge[1] = damage.DF3;
                            break;
                        case 15: //HTHA
                            damage.DF2 = cal.DF_HTHA(age[13] + 3);
                            damage.DF3 = cal.DF_HTHA(age[13] + 6);
                            DF_HTHAPlusAge[0] = damage.DF2;
                            DF_HTHAPlusAge[1] = damage.DF3;
                            fullPOF.HTHA_AP1 = damage.DF1;
                            fullPOF.HTHA_AP2 = damage.DF2;
                            fullPOF.HTHA_AP3 = damage.DF3;
                            break;
                        case 16: //Brittle
                            damage.DF2 = damage.DF3 = damage.DF1;
                            fullPOF.BrittleAP1 = fullPOF.BrittleAP2 = fullPOF.BrittleAP3 = damage.DF1;
                            break;
                        case 20: //Piping Fatigure
                            damage.DF2 = damage.DF3 = damage.DF1;
                            fullPOF.FatigueAP1 = fullPOF.FatigueAP2 = fullPOF.FatigueAP3 = damage.DF1;
                            break;
                        default:
                            damage.DF2 = damage.DF1;
                            damage.DF3 = damage.DF1;
                            break;
                    }
                    listDamageMachenism.Add(damage);
                }
            }
            DMmachenism = listDamageMachenism;
            /*  
             * Tính DF_Thin_Total
             *  page 2-11 (125/654)
             *  Df_thinning_total = min[Df_thinning, Df_lining] nếu như có Lining
             *  Df_thinning_total = Df_thinning  
             */
            float[] DF_Thin_Total = { 0, 0, 0 };
            DF_Thin_Total[0] = cal.INTERNAL_LINNING ? Math.Min(Df[0], Df[1]) : Df[0];
            DF_Thin_Total[1] = cal.INTERNAL_LINNING ? Math.Min(thinningPlusAge[0], linningPlusAge[0]) : thinningPlusAge[0];
            DF_Thin_Total[2] = cal.INTERNAL_LINNING ? Math.Min(thinningPlusAge[1], linningPlusAge[1]) : thinningPlusAge[1];


            /*  
             * Tính Df_SCC_Total
             *  Df_SCC_Total = Max(Df_caustic, Df_Anime, Df_SSC, Df_HIC/SOHIC-H2S, Df_Carbonate, Df_PTA, Df_CLSCC, Df_HSC-HF, Df_HIC/SOHIC-HF)
             */
            float[] DF_SCC_Total = { 0, 0, 0 };
            DF_SCC_Total[0] = Df[2];
            for (int i = 2; i < 11; i++)
            {
                if (DF_SCC_Total[0] < Df[i])
                    DF_SCC_Total[0] = Df[i];
            }
            if (DFSCCAgePlus3.Count != 0)
            {
                DF_SCC_Total[1] = DFSCCAgePlus3.Max();
                DF_SCC_Total[2] = DFSCCAgePlus6.Max();
            }

            /*
             * Tính DF_Ext_Total
             * Df_extd_Total = Max(Df_extcor, Df_CUIF, Df_ext-CLSCC, Df_CUI-CLSCC)
             */
            float DF_Ext_Total = Df[11];
            for (int i = 12; i < 15; i++)
            {
                if (DF_Ext_Total < Df[i])
                    DF_Ext_Total = Df[i];
            }
            float[] listDF_Ext1 = { DF_EXTERN_CORROSIONPlusAge[0], DF_CUIPlusAge[0], Df[13], Df[14] };
            float[] listDF_ext2 = { DF_EXTERN_CORROSIONPlusAge[1], DF_CUIPlusAge[1], Df[13], Df[14] };
            float DF_Ext_Total2 = listDF_Ext1[0];
            float DF_ext_total3 = listDF_ext2[0];
            for (int i = 0; i < listDF_Ext1.Length; i++)
            {
                if (DF_Ext_Total2 < listDF_Ext1[i])
                    DF_Ext_Total2 = listDF_Ext1[i];
            }
            for (int i = 0; i < listDF_ext2.Length; i++)
            {
                if (DF_ext_total3 < listDF_ext2[i])
                    DF_ext_total3 = listDF_ext2[i];
            }

            /*
             * Tính DF_Brit_Total
             * Df_Brit = Max((Df_britfract + Df_tempe), Df_885, Df_sigma)
             * 
             */ 
            float DF_Brit_Total = Df[16] + Df[17]; //Df_brittle + Df_temp_Embrittle
            for (int i = 18; i < 21; i++)
            {
                if (DF_Brit_Total < Df[i])
                    DF_Brit_Total = Df[i];
            }
            float[] dftotal = { DF_Thin_Total[0], DF_SCC_Total[0], DF_Ext_Total, DF_Brit_Total };
            
            
            /*
             * Tính Df_Total
             * DF_Total = Max(Df_thinning, DF_ext) + DF_SCC + DF_HTHA + DF_Brit + DF_Pipe ---> if thinning is local 
             */
            float[] DF_Total = { 0, 0, 0 };
            switch (ThinningType)
            {
                case "Local":
                    DF_Total[0] = Math.Max(DF_Thin_Total[0], DF_Ext_Total) + DF_SCC_Total[0] + Df[15] + DF_Brit_Total + Df[20];
                    DF_Total[1] = Math.Max(DF_Thin_Total[1], DF_Ext_Total2) + DF_SCC_Total[1] + DF_HTHAPlusAge[0] + DF_Brit_Total + Df[20];
                    DF_Total[2] = Math.Max(DF_Thin_Total[1], DF_ext_total3) + DF_SCC_Total[2] + DF_HTHAPlusAge[1] + DF_Brit_Total + Df[20];
                    break;
                default:
                    DF_Total[0] = DF_Thin_Total[0] + DF_SCC_Total[0] + Df[15] + DF_Brit_Total + Df[20] + DF_Ext_Total;
                    DF_Total[1] = DF_Thin_Total[1] + DF_SCC_Total[1] + DF_HTHAPlusAge[0] + DF_Brit_Total + Df[20] + DF_Ext_Total2;
                    DF_Total[2] = DF_Thin_Total[1] + DF_SCC_Total[2] + DF_HTHAPlusAge[1] + DF_Brit_Total + Df[20] + DF_ext_total3;
                    break;
            }
            fullPOF.ThinningAP1 = DF_Thin_Total[0];
            fullPOF.ThinningAP2 = DF_Thin_Total[1];
            fullPOF.ThinningAP3 = DF_Thin_Total[2];
            fullPOF.ThinningLocalAP1 = Math.Max(DF_Thin_Total[0], DF_Ext_Total);
            fullPOF.ThinningLocalAP2 = Math.Max(DF_Thin_Total[1], DF_Ext_Total2);
            fullPOF.ThinningLocalAP3 = Math.Max(DF_Thin_Total[2], DF_ext_total3);
            fullPOF.ThinningGeneralAP1 = DF_Thin_Total[0] + DF_Ext_Total;
            fullPOF.ThinningGeneralAP2 = DF_Thin_Total[1] + DF_Ext_Total2;
            fullPOF.ThinningGeneralAP3 = DF_Thin_Total[2] + DF_ext_total3;
            fullPOF.ExternalAP1 = DF_Ext_Total;
            fullPOF.ExternalAP2 = DF_Ext_Total2;
            fullPOF.ExternalAP3 = DF_ext_total3;
            fullPOF.HTHA_AP1 = Df[15];
            fullPOF.HTHA_AP2 = DF_HTHAPlusAge[0];
            fullPOF.HTHA_AP3 = DF_HTHAPlusAge[1];
            fullPOF.BrittleAP1 = DF_Brit_Total;
            fullPOF.BrittleAP2 = DF_Brit_Total;
            fullPOF.BrittleAP3 = DF_Brit_Total;
            fullPOF.FatigueAP1 = Df[20];
            fullPOF.FatigueAP2 = Df[20];
            fullPOF.FatigueAP3 = Df[20];
            fullPOF.SCCAP1 = DF_SCC_Total[0];
            fullPOF.SCCAP2 = DF_SCC_Total[1];
            fullPOF.SCCAP3 = DF_SCC_Total[2];
            fullPOF.TotalDFAP1 = DF_Total[0];
            fullPOF.TotalDFAP2 = DF_Total[1];
            fullPOF.TotalDFAP3 = DF_Total[2];
            fullPOF.PoFAP1Category = cal.PoFCategory(DF_Total[0]);
            fullPOF.PoFAP2Category = cal.PoFCategory(DF_Total[1]);
            fullPOF.PoFAP3Category = cal.PoFCategory(DF_Total[2]);
            //get Managerment Factor 
            float FMS = 0;
            FMS = busFacility.getFMS(busEquipmentMaster.getSiteID(equipmentID));
            fullPOF.FMS = FMS;
            //get GFFtotal
            float GFFTotal = 0;
            GFFTotal = busApiComponentType.getGFFTotal(cal.APIComponentType);
            fullPOF.GFFTotal = GFFTotal;
            //Console.WriteLine("GFF total " + GFFTotal);
            fullPOF.ThinningType = ThinningType;
            fullPOF.PoFAP1 = fullPOF.TotalDFAP1 * fullPOF.FMS * fullPOF.GFFTotal;
            fullPOF.PoFAP2 = fullPOF.TotalDFAP2 * fullPOF.FMS * fullPOF.GFFTotal;
            fullPOF.PoFAP3 = fullPOF.TotalDFAP3 * fullPOF.FMS * fullPOF.GFFTotal;
            fullPOF.PoFAP1 = fullPOF.PoFAP1 > 1 ? 1 : fullPOF.PoFAP1;
            fullPOF.PoFAP2 = fullPOF.PoFAP2 > 1 ? 1 : fullPOF.PoFAP2;
            fullPOF.PoFAP3 = fullPOF.PoFAP3 > 1 ? 1 : fullPOF.PoFAP3;
            full_pof = fullPOF;
            inspl.ComponentNumber = componentNumber;
            inspl.ApiComponentType = API_ComponentType_Name;
            inspl.EquipmentID = equipmentID;
            inspl.Age = age;
            inspl.DF = Df;
            inspl.GFFTotal = fullPOF.GFFTotal;
            inspl.FMS = fullPOF.FMS;
            insplant = inspl;
            inspl.DFTotal = dftotal;
            calDM = cal;
            //lưu kết quả vào bảng RW_DAMAGE_MECHANISM

            //lưu kết quả vào bảng RW_FULL_POF
            if (busFullPoF.checkExistPoF(fullPOF.ID))
                busFullPoF.edit(fullPOF);
            else
                busFullPoF.add(fullPOF);
            #endregion
        }
        private void InspectionPlan(RW_FULL_POF fullpof, InputInspectionCalculation inspl, MSSQL_DM_CAL cal, List<RW_DAMAGE_MECHANISM> DMmachenism, float FC)
        {
            #region INSPECTION HISTORY
            int FaciID = busEquipmentMaster.getFacilityID(inspl.EquipmentID);
            //Console.WriteLine("Some Data " + cal.APIComponentType + "\n" +
            //                  cal.AdjustmentSettle + "\n" +
            //                  cal.AMINE_EXPOSED + "\n" +
            //                  cal.ContainsDeadlegs
            //   );
            float risktaget = busRiskTarget.getRiskTarget(FaciID);
            float DF_thamchieu = risktaget / (FC * inspl.GFFTotal * inspl.FMS);
            Console.WriteLine("DF tham chieu " + DF_thamchieu + " Risk Target " + risktaget + " FC = " + FC);
            float[] tempDf = new float[21];
            int k = 15;
            InputInspectionCalculation a = new InputInspectionCalculation();
            RW_RISK_GRAPH riskGraph = new RW_RISK_GRAPH();
            riskGraph.ID = IDProposal;
            riskGraph.RiskTarget = risktaget;
            float[] age = inspl.Age;
            float[] risk = new float[15];
            float[] DFtotal = new float[15];
            for (int i = 0; i < age.Length; i++)
               Console.WriteLine("age jhsdjhn " + age[i]);
            //int ageAssessment = 10;
            for (int i = 1; i < 16; i++)
            {
                
                tempDf[0] = cal.DF_THIN(age[0] + i);
                tempDf[1] = cal.DF_LINNING(age[1] + i);
                tempDf[2] = cal.DF_CAUSTIC(age[2] + i);
                tempDf[3] = cal.DF_AMINE(age[3] + i);
                tempDf[4] = cal.DF_SULPHIDE(age[4] + i);
                tempDf[5] = cal.DF_HICSOHIC_H2S(age[5] + i);
                tempDf[6] = cal.DF_CACBONATE(age[6] + i);
                tempDf[7] = cal.DF_PTA(age[7] + i);
                tempDf[8] = cal.DF_CLSCC(age[8] + i);
                tempDf[9] = cal.DF_HSCHF(age[9] + i);
                tempDf[10] = cal.DF_HIC_SOHIC_HF(age[10] + i);
                tempDf[11] = cal.DF_EXTERNAL_CORROSION(age[11] + i);
                tempDf[12] = cal.DF_CUI(age[12] + i);
                tempDf[13] = cal.DF_EXTERN_CLSCC();
                tempDf[14] = cal.DF_CUI_CLSCC();
                tempDf[15] = cal.DF_HTHA(age[13] + i);
                tempDf[16] = cal.DF_BRITTLE();
                tempDf[17] = cal.DF_TEMP_EMBRITTLE();
                tempDf[18] = cal.DF_885();
                tempDf[19] = cal.DF_SIGMA();
                tempDf[20] = cal.DF_PIPE();
                float maxThin = cal.INTERNAL_LINNING ? Math.Min(tempDf[0], tempDf[1]) : tempDf[0];
                float maxSCC = tempDf[2];
                float maxExt = tempDf[12];
                for (int j = 3; j < 11; j++)
                {
                    if (maxSCC < tempDf[j])
                        maxSCC = tempDf[j];
                }
                for (int j = 13; j < 15; j++)
                {
                    if (maxExt < tempDf[j])
                        maxExt = tempDf[j];
                }
                float maxBritt = tempDf[16] + tempDf[17]; //Df_brittle + Df_temp_Embrittle
                for (int j = 18; j < 21; j++)
                {
                    if (maxBritt < tempDf[j])
                        maxBritt = tempDf[j];
                }
                DFtotal[i-1] = maxSCC + maxExt + maxThin + tempDf[15] + maxBritt;
                risk[i - 1] = fullpof.FMS * fullpof.GFFTotal * DFtotal[i - 1] * FC;
            }
            for (int i = 1; i < 16; i++ )
            {
                if (DFtotal[i-1] >= DF_thamchieu)
                {
                    k = i;
                    break;
                }
            }
                for (int i = 0; i < risk.Length; i++)
                {
                    Console.WriteLine("asdjahdjhsd " + risk[i]);
                }
            riskGraph.Risk = risk;
            if (busRiskGraph.CheckExistID(riskGraph.ID))
                busRiskGraph.edit(riskGraph);
            else
                busRiskGraph.add(riskGraph);
            foreach (RW_DAMAGE_MECHANISM d in DMmachenism)
            {
                d.InspDueDate = DateTime.Now.AddYears(k);
                if (busDamageMechanism.checkExistDM(d.ID, d.DMItemID))
                    busDamageMechanism.edit(d);
                else
                    busDamageMechanism.add(d);
            }
            //gán cho Object inspection plan
            float[] inspec = inspl.DFTotal;
            for (int i = 0; i < inspec.Length; i++)
            {
                if (inspec[i] != 0)
                {
                    InspectionPlant insp = new InspectionPlant();
                    insp.System = "Inspection Plan";
                    insp.ItemNo = busEquipmentMaster.getEquipmentNumber(inspl.EquipmentID);
                    insp.Method = "No Name";
                    insp.Coverage = "N/A";
                    insp.Availability = "Online";
                    insp.LastInspectionDate = Convert.ToString(busInspectionHistory.getLastInsp(inspl.ComponentNumber, DM_Name[1], busEquipmentMaster.getComissionDate(inspl.EquipmentID)));
                    insp.InspectionInterval = k.ToString();
                    //thay get last inspection = assessment date
                    insp.DueDate = Convert.ToString(busInspectionHistory.getLastInsp(inspl.ComponentNumber, DM_Name[1], busEquipmentMaster.getComissionDate(inspl.EquipmentID)).AddYears(k));
                    switch (i)
                    {
                        case 0:
                            insp.DamageMechanism = "Internal Thinning";
                            break;
                        case 1:
                            insp.DamageMechanism = "SSC Damage Factor";
                            break;
                        case 2:
                            insp.DamageMechanism = "External Damage Factor";
                            break;
                        default:
                            insp.DamageMechanism = "Brittle";
                            break;
                    }
                    listInspectionPlan.Add(insp);
                }
            }
            #endregion
        }
        private void CA(out float fc, string apiComponentTypeName, RW_COMPONENT com, RW_MATERIAL ma, RW_INPUT_CA_LEVEL_1 caInput)
        {
            #region CA
            MSSQL_CA_CAL CA_CAL = new MSSQL_CA_CAL();
            //<input CA Lavel 1>
            CA_CAL.NominalDiameter = com.NominalDiameter;
            CA_CAL.MATERIAL_COST = ma.CostFactor;
            CA_CAL.FLUID = caInput.API_FLUID;
            CA_CAL.FLUID_PHASE = caInput.SYSTEM;
            CA_CAL.API_COMPONENT_TYPE_NAME = apiComponentTypeName;
            CA_CAL.DETECTION_TYPE = caInput.Detection_Type;
            CA_CAL.ISULATION_TYPE = caInput.Isulation_Type;
            CA_CAL.STORED_PRESSURE = caInput.Stored_Pressure;
            CA_CAL.ATMOSPHERIC_PRESSURE = 101;
            CA_CAL.STORED_TEMP = caInput.Stored_Temp;
            CA_CAL.MASS_INVERT = caInput.Mass_Inventory;
            CA_CAL.MASS_COMPONENT = caInput.Mass_Component;
            CA_CAL.MITIGATION_SYSTEM = caInput.Mitigation_System;
            CA_CAL.TOXIC_PERCENT = caInput.Toxic_Percent;
            CA_CAL.RELEASE_DURATION = caInput.Release_Duration;
            CA_CAL.PRODUCTION_COST = caInput.Production_Cost;
            CA_CAL.INJURE_COST = caInput.Injure_Cost;
            CA_CAL.ENVIRON_COST = caInput.Environment_Cost;
            CA_CAL.PERSON_DENSITY = caInput.Personal_Density;
            CA_CAL.EQUIPMENT_COST = caInput.Equipment_Cost;
            //</CA Level 1>

            //<calculate CA>
            RW_CA_LEVEL_1 caLvl1 = new RW_CA_LEVEL_1();
            caLvl1.ID = caInput.ID;
            caLvl1.Release_Phase = CA_CAL.GET_RELEASE_PHASE();
            caLvl1.fact_di = CA_CAL.fact_di();
            caLvl1.fact_mit = CA_CAL.fact_mit();
            caLvl1.fact_ait = CA_CAL.fact_ait();
            caLvl1.CA_cmd = float.IsNaN(CA_CAL.ca_cmd()) ? 0 : CA_CAL.ca_cmd();
            caLvl1.CA_inj_flame = float.IsNaN(CA_CAL.ca_inj_flame()) ? 0 : CA_CAL.ca_inj_flame();
            caLvl1.CA_inj_toxic = float.IsNaN(CA_CAL.ca_inj_tox()) ? 0 : CA_CAL.ca_inj_tox();
            caLvl1.CA_inj_ntnf = float.IsNaN(CA_CAL.ca_inj_nfnt()) ? 0 : CA_CAL.ca_inj_nfnt();
            caLvl1.FC_cmd = float.IsNaN(CA_CAL.fc_cmd()) ? 0 : CA_CAL.fc_cmd();
            caLvl1.FC_affa = float.IsNaN(CA_CAL.fc_affa()) ? 0 : CA_CAL.fc_affa();
            caLvl1.FC_prod = float.IsNaN(CA_CAL.fc_prod()) ? 0 : CA_CAL.fc_prod();
            caLvl1.FC_inj = float.IsNaN(CA_CAL.fc_inj()) ? 0 : CA_CAL.fc_inj();
            caLvl1.FC_envi = float.IsNaN(CA_CAL.fc_environ()) ? 0 : CA_CAL.fc_environ();
            caLvl1.FC_total = float.IsNaN(CA_CAL.fc()) ? 100000000 : CA_CAL.fc();
            fc = caLvl1.FC_total;
            if (caLvl1.FC_total == 0)
            {
                caLvl1.FC_total = 100000000;
            }

            caLvl1.FCOF_Category = CA_CAL.FC_Category(caLvl1.FC_total);
            RW_FULL_FCOF fullFCoF = new RW_FULL_FCOF();
            fullFCoF.ID = caLvl1.ID;
            fullFCoF.FCoFValue = caLvl1.FC_total;
            fullFCoF.FCoFCategory = caLvl1.FCOF_Category;

            //fullFCoF.AIL = 
            fullFCoF.envcost = CA_CAL.ENVIRON_COST;
            fullFCoF.equipcost = CA_CAL.EQUIPMENT_COST;
            fullFCoF.prodcost = CA_CAL.PRODUCTION_COST;
            fullFCoF.popdens = CA_CAL.PERSON_DENSITY;
            fullFCoF.injcost = CA_CAL.INJURE_COST;
            //fullFCoF.FCoFMatrixValue
            //</calculate CA>

            //<Save to Database>
            if (busCALevel1.checkExist(caLvl1.ID))
                busCALevel1.edit(caLvl1);
            else
                busCALevel1.add(caLvl1);

            if (busFullFCoF.checkExist(fullFCoF.ID))
                busFullFCoF.edit(fullFCoF);
            else
                busFullFCoF.add(fullFCoF);
            //</Save to Database>
            #endregion
        }
        private void CA_Tank(out float fc, string API_component, string componentTypeName,RW_EQUIPMENT eq, RW_MATERIAL ma, RW_INPUT_CA_TANK caTank)
        {
            #region CA
            MSSQL_CA_CAL CA = new MSSQL_CA_CAL();
            CA.MATERIAL_COST = ma.CostFactor;
            CA.PRODUCTION_COST = caTank.ProductionCost;
            float FC_Total = 0;
            RW_CA_TANK rwCATank = new RW_CA_TANK();
            if (componentTypeName == "Shell")
            {
                CA.FLUID_HEIGHT = caTank.FLUID_HEIGHT;
                CA.SHELL_COURSE_HEIGHT = caTank.SHELL_COURSE_HEIGHT;
                CA.TANK_DIAMETER = caTank.TANK_DIAMETTER;
                CA.PREVENTION_BARRIER = caTank.Prevention_Barrier == 1 ? true : false;
                CA.EnvironSensitivity = caTank.Environ_Sensitivity;
                CA.P_lvdike = caTank.P_lvdike;
                CA.P_offsite = caTank.P_offsite;
                CA.P_onsite = caTank.P_onsite;
                CA.API_COMPONENT_TYPE_NAME = API_component;

                rwCATank.ID = eq.ID;
                // bieu thuc trung gian
                rwCATank.Flow_Rate_D1 = !float.IsNaN(CA.W_n_Tank(1)) && CA.W_n_Tank(1) > 0 ? CA.W_n_Tank(1) : 0;
                rwCATank.Flow_Rate_D2 = !float.IsNaN(CA.W_n_Tank(2)) && CA.W_n_Tank(2) > 0 ? CA.W_n_Tank(2) : 0;
                rwCATank.Flow_Rate_D3 = !float.IsNaN(CA.W_n_Tank(3)) && CA.W_n_Tank(3) > 0 ? CA.W_n_Tank(3) : 0;
                rwCATank.Flow_Rate_D4 = !float.IsNaN(CA.W_n_Tank(4)) && CA.W_n_Tank(4) > 0 ? CA.W_n_Tank(4) : 0;

                rwCATank.Leak_Duration_D1 = !float.IsNaN(CA.ld_tank(1)) && CA.ld_tank(1) > 0 ? CA.ld_tank(1) : 0;
                rwCATank.Leak_Duration_D2 = !float.IsNaN(CA.ld_tank(2)) && CA.ld_tank(2) > 0 ? CA.ld_tank(2) : 0;
                rwCATank.Leak_Duration_D3 = !float.IsNaN(CA.ld_tank(3)) && CA.ld_tank(3) > 0 ? CA.ld_tank(3) : 0;
                rwCATank.Leak_Duration_D4 = !float.IsNaN(CA.ld_tank(4)) && CA.ld_tank(4) > 0 ? CA.ld_tank(4) : 0;

                rwCATank.Release_Volume_Leak_D1 = !float.IsNaN(CA.Bbl_leak_n(1)) && CA.Bbl_leak_n(1) > 0 ? CA.Bbl_leak_n(1) : 0;
                rwCATank.Release_Volume_Leak_D2 = !float.IsNaN(CA.Bbl_leak_n(2)) && CA.Bbl_leak_n(2) > 0 ? CA.Bbl_leak_n(2) : 0;
                rwCATank.Release_Volume_Leak_D3 = !float.IsNaN(CA.Bbl_leak_n(3)) && CA.Bbl_leak_n(3) > 0 ? CA.Bbl_leak_n(3) : 0;
                rwCATank.Release_Volume_Leak_D4 = !float.IsNaN(CA.Bbl_leak_n(4)) && CA.Bbl_leak_n(4) > 0 ? CA.Bbl_leak_n(4) : 0;

                rwCATank.Release_Volume_Rupture = !float.IsNaN(CA.Bbl_rupture_release()) && CA.Bbl_rupture_release() > 0 ? CA.Bbl_rupture_release() : 0;
                rwCATank.Liquid_Height = CA.FLUID_HEIGHT;
                rwCATank.Volume_Fluid = CA.BBL_TOTAL_SHELL();

                rwCATank.Barrel_Dike_Leak = !float.IsNaN(CA.Bbl_leak_indike()) && CA.Bbl_leak_indike() > 0 ? CA.Bbl_leak_indike() : 0;
                rwCATank.Barrel_Dike_Rupture = !float.IsNaN(CA.Bbl_rupture_indike()) && CA.Bbl_rupture_indike() > 0 ? CA.Bbl_rupture_indike() : 0;

                rwCATank.Barrel_Onsite_Leak = !float.IsNaN(CA.Bbl_leak_ssonsite()) && CA.Bbl_leak_ssonsite() > 0 ? CA.Bbl_leak_ssonsite() : 0;
                rwCATank.Barrel_Onsite_Rupture = !float.IsNaN(CA.Bbl_rupture_ssonsite()) && CA.Bbl_rupture_ssonsite() > 0 ? CA.Bbl_rupture_ssonsite() : 0;

                rwCATank.Barrel_Offsite_Leak = !float.IsNaN(CA.Bbl_leak_ssoffsite()) && CA.Bbl_leak_ssoffsite() > 0 ? CA.Bbl_leak_ssoffsite() : 0;
                rwCATank.Barrel_Offsite_Rupture = !float.IsNaN(CA.Bbl_rupture_ssoffsite()) && CA.Bbl_rupture_ssoffsite() > 0 ? CA.Bbl_rupture_ssoffsite() : 0;

                rwCATank.Barrel_Water_Leak = !float.IsNaN(CA.Bbl_leak_water()) && CA.Bbl_leak_water() > 0 ? CA.Bbl_leak_water() : 0;
                rwCATank.Barrel_Water_Rupture = !float.IsNaN(CA.Bbl_rupture_water()) && CA.Bbl_rupture_water() > 0 ? CA.Bbl_rupture_water() : 0;

                rwCATank.Material_Factor = CA.MATERIAL_COST;

                //bieu thuc tinh toan
                rwCATank.FC_Environ_Rupture = float.IsNaN(CA.FC_rupture_environ()) ? 0 : CA.FC_rupture_environ();
                rwCATank.FC_Environ_Leak = float.IsNaN(CA.FC_leak_environ()) ? 0 : CA.FC_leak_environ();
                rwCATank.FC_Environ = rwCATank.FC_Environ_Rupture + rwCATank.FC_Environ_Leak;
                rwCATank.Business_Cost = float.IsNaN(CA.FC_PROD_SHELL()) ? 0 : CA.FC_PROD_SHELL();
                rwCATank.Component_Damage_Cost = float.IsNaN(CA.fc_cmd()) ? 0 : CA.fc_cmd();
                rwCATank.Consequence = rwCATank.FC_Environ + rwCATank.Business_Cost + rwCATank.Component_Damage_Cost;
                rwCATank.ConsequenceCategory = CA.FC_Category(rwCATank.Consequence);
                FC_Total = rwCATank.Consequence;
                //Console.WriteLine("CA tank " + rwCATank.FC_Environ_Rupture + "\n" +
                //                     rwCATank.FC_Environ_Leak + "\n" +
                //                     rwCATank.FC_Environ + "\n" +
                //                     rwCATank.Business_Cost + "\n" +
                //                     rwCATank.Component_Damage_Cost + "\n" +
                //                     rwCATank.ConsequenceCategory
                //                    );

                if (busCATank.CheckExistID(rwCATank.ID))
                    busCATank.edit(rwCATank);
                else
                    busCATank.add(rwCATank);
            }
            else
            {
                CA.Swg = caTank.SW;
                CA.Soil_type = caTank.Soil_Type;
                CA.TANK_FLUID = caTank.TANK_FLUID;
                CA.FLUID = caTank.API_FLUID;
                CA.API_COMPONENT_TYPE_NAME = "TANKBOTTOM";

                rwCATank.ID = eq.ID;
                // bieu thuc trung gian
                rwCATank.Hydraulic_Water = CA.k_h_water();
                rwCATank.Hydraulic_Fluid = CA.k_h_prod();
                rwCATank.Seepage_Velocity = CA.vel_s_prod();

                rwCATank.Flow_Rate_D1 = float.IsNaN(CA.rate_n_tank_bottom(1)) ? 0 : CA.rate_n_tank_bottom(1);
                rwCATank.Flow_Rate_D4 = float.IsNaN(CA.rate_n_tank_bottom(4)) ? 0 : CA.rate_n_tank_bottom(4);

                rwCATank.Leak_Duration_D1 = float.IsNaN(CA.ld_n_tank_bottom(1)) ? 0 : CA.ld_n_tank_bottom(1);
                rwCATank.Leak_Duration_D4 = float.IsNaN(CA.ld_n_tank_bottom(4)) ? 0 : CA.ld_n_tank_bottom(4);

                rwCATank.Release_Volume_Leak_D1 = float.IsNaN(CA.Bbl_leak_n_bottom(1)) ? 0 : CA.Bbl_leak_n_bottom(1);
                rwCATank.Release_Volume_Leak_D4 = float.IsNaN(CA.Bbl_leak_n_bottom(4)) ? 0 : CA.Bbl_leak_n_bottom(4);

                rwCATank.Release_Volume_Rupture = float.IsNaN(CA.Bbl_rupture_release_bottom()) ? 0 : CA.Bbl_rupture_release_bottom();
                rwCATank.Volume_Fluid = float.IsNaN(CA.BBL_TOTAL_TANKBOTTOM()) ? 0 : CA.BBL_TOTAL_TANKBOTTOM();
                rwCATank.Time_Leak_Ground = float.IsNaN(CA.t_gl_bottom()) ? 0 : CA.t_gl_bottom();

                rwCATank.Volume_SubSoil_Leak_D1 = float.IsNaN(CA.Bbl_leak_subsoil(1)) ? 0 : CA.Bbl_leak_subsoil(1);
                rwCATank.Volume_SubSoil_Leak_D4 = float.IsNaN(CA.Bbl_leak_subsoil(4)) ? 0 : CA.Bbl_leak_subsoil(4);

                rwCATank.Volume_Ground_Water_Leak_D1 = float.IsNaN(CA.Bbl_leak_groundwater(1)) ? 0 : CA.Bbl_leak_groundwater(1);
                rwCATank.Volume_Ground_Water_Leak_D4 = float.IsNaN(CA.Bbl_leak_groundwater(4)) ? 0 : CA.Bbl_leak_groundwater(4);

                rwCATank.Barrel_Dike_Rupture = float.IsNaN(CA.Bbl_rupture_indike_bottom()) ? 0 : CA.Bbl_rupture_indike_bottom();
                rwCATank.Barrel_Onsite_Rupture = float.IsNaN(CA.Bbl_rupture_ssonsite_bottom()) ? 0 : CA.Bbl_rupture_ssonsite_bottom();
                rwCATank.Barrel_Offsite_Rupture = float.IsNaN(CA.Bbl_rupture_ssoffsite_bottom()) ? 0 : CA.Bbl_rupture_ssoffsite_bottom();
                rwCATank.Barrel_Water_Rupture = float.IsNaN(CA.Bbl_rupture_water_bottom()) ? 0 : CA.Bbl_rupture_water_bottom();

                // gia tri tinh toan
                rwCATank.FC_Environ_Rupture = float.IsNaN(CA.FC_rupture_environ_bottom()) ? 0 : CA.FC_rupture_environ_bottom();
                rwCATank.FC_Environ_Leak = float.IsNaN(CA.FC_leak_environ_bottom()) ? 0 : CA.FC_leak_environ_bottom();
                rwCATank.FC_Environ = rwCATank.FC_Environ_Rupture + rwCATank.FC_Environ_Leak;
                rwCATank.Business_Cost = float.IsNaN(CA.FC_PROD_SHELL()) ? 0 : CA.FC_PROD_SHELL();
                rwCATank.Component_Damage_Cost = float.IsNaN(CA.FC_cmd_bottom()) ? 0 : CA.FC_cmd_bottom();
                rwCATank.Consequence = rwCATank.FC_Environ + rwCATank.Business_Cost + rwCATank.Component_Damage_Cost;

                rwCATank.ConsequenceCategory = CA.FC_Category(rwCATank.Consequence);
                if (busCATank.CheckExistID(rwCATank.ID))
                    busCATank.edit(rwCATank);
                else
                    busCATank.add(rwCATank);
                FC_Total = rwCATank.Consequence;
            }
            fc = FC_Total;
            RW_FULL_FCOF fullFCoF = new RW_FULL_FCOF();
            fullFCoF.ID = rwCATank.ID;
            fullFCoF.FCoFValue = FC_Total;
            fullFCoF.FCoFCategory = CA.FC_Category(FC_Total);

            if (busFullFCoF.checkExist(fullFCoF.ID))
                busFullFCoF.edit(fullFCoF);
            else
                busFullFCoF.add(fullFCoF);
            #endregion
        }
        private void Calculation(String ThinningType, String componentNumber, RW_EQUIPMENT eq, RW_COMPONENT com, RW_MATERIAL ma, RW_STREAM st, RW_COATING coat, RW_EXTCOR_TEMPERATURE tem, RW_INPUT_CA_LEVEL_1 caInput)
        {
            InputInspectionCalculation inputInsp;
            MSSQL_DM_CAL cacal;
            List<RW_DAMAGE_MECHANISM> DMmache;
            RW_FULL_POF fullpof;
            float FC = 0;
            PoF(out fullpof, out inputInsp, out cacal, out DMmache, ThinningType, componentNumber, eq, com, ma, st, coat, tem);
            CA(out FC, inputInsp.ApiComponentType, com, ma, caInput);
            InspectionPlan(fullpof,inputInsp, cacal, DMmache, FC);
        }
        private void Calculation_CA_TANK(String componentTypeName, String API_component, String ThinningType, String componentNumber, RW_EQUIPMENT eq, RW_COMPONENT com, RW_MATERIAL ma, RW_STREAM st, RW_COATING coat, RW_EXTCOR_TEMPERATURE tem, RW_INPUT_CA_TANK caTank)
        {
            InputInspectionCalculation insp;
            MSSQL_DM_CAL cacal;
            List<RW_DAMAGE_MECHANISM> DMmachenism;
            float FC = 0;
            RW_FULL_POF fullpof;
            PoF(out fullpof, out  insp, out  cacal, out DMmachenism,ThinningType, componentNumber, eq, com, ma, st, coat, tem);
            CA_Tank(out FC, API_component, componentTypeName, eq, ma, caTank);
            InspectionPlan(fullpof, insp, cacal, DMmachenism, FC);
        }

        private void ShowItemTabpage(int ID, int Num, bool checkTank)
        {
            ucTabNormal uctab = null;
            ucTabTank ucTabTank = null;
            UserControl u = null;
            if (!checkTank)
            {
                foreach (ucTabNormal uc in listUC)
                {
                    if (ID == uc.ID)
                    {
                        uctab = uc;
                        break;
                    }
                }
                switch (Num)
                {
                    case 1:
                        u = uctab.ucAss;
                        break;
                    case 2:
                        u = uctab.ucEq;
                        break;
                    case 3:
                        u = uctab.ucComp;
                        break;
                    case 4:
                        u = uctab.ucOpera;
                        break;
                    case 5:
                        u = uctab.ucCoat;
                        break;
                    case 6:
                        u = uctab.ucMaterial;
                        break;
                    case 7:
                        u = uctab.ucStream;
                        break;
                    case 8:
                        u = uctab.ucCA;
                        break;
                    case 9:
                        u = uctab.ucRiskFactor;
                        break;
                    case 10:
                        u = uctab.ucRiskSummary;
                        break;
                    case 11:
                        u = uctab.ucInspectionHistory;
                        break;
                    case 12:
                        u = uctab.ucDrawGraph;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                foreach (ucTabTank uc in listUCTank)
                {
                    if (ID == uc.ID)
                    {
                        ucTabTank = uc;
                        break;
                    }
                }
                switch (Num)
                {
                    case 1:
                        u = ucTabTank.ucAss;
                        break;
                    case 2:
                        u = ucTabTank.ucEquipmentTank;
                        break;
                    case 3:
                        u = ucTabTank.ucComponentTank;
                        break;
                    case 4:
                        u = ucTabTank.ucOpera;
                        break;
                    case 5:
                        u = ucTabTank.ucCoat;
                        break;
                    case 6:
                        u = ucTabTank.ucMaterialTank;
                        break;
                    case 7:
                        u = ucTabTank.ucStreamTank;
                        break;
                    case 9:
                        u = ucTabTank.ucRiskFactor;
                        break;
                    case 10:
                        u = ucTabTank.ucRiskSummary;
                        break;
                    case 11:
                        u = ucTabTank.ucInspHistory;
                        break;
                    case 12:
                        u = ucTabTank.ucDrawGraph;
                        break;
                    default:
                        break;
                }
            }
            
            if (xtraTabData.SelectedTabPageIndex == 0) return;
            if (xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Contains(u))
            {
                return;
            }
            else
            {
                xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Clear();
                
                switch(Num)
                {   //3 UC cần được cập nhập lại dữ liệu sau mỗi lần tính toán
                    case 9:
                        UCRiskFactor rf = new UCRiskFactor(IDProposal);
                        xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(rf);
                        //rf.Dock = DockStyle.Fill;
                        //rf.AutoScroll = true;
                        break;
                    case 10:
                        UCRiskSummary rs = new UCRiskSummary(IDProposal);
                        xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(rs);
                        //rs.Dock = DockStyle.Fill;
                        
                        break;
                    case 12:
                        UCDrawGraph gr = new UCDrawGraph(IDProposal);
                        xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(gr);
                        //u.Dock = DockStyle.Fill;
                        return;
                    default:
                        xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(u);
                        //u.Dock = DockStyle.Fill;
                        
                        break;
                }
                
            }
        }

        

        private void addNewTab(string tabname, UserControl uc)
        {
            string _tabID = IDProposal.ToString();
            foreach (DevExpress.XtraTab.XtraTabPage tabpage in xtraTabData.TabPages)
            {
                if (tabpage.Name == _tabID)
                {
                    xtraTabData.SelectedTabPage = tabpage;
                    return;
                }
            }
            DevExpress.XtraTab.XtraTabPage tabPage = new DevExpress.XtraTab.XtraTabPage();
            Console.WriteLine("tabpage name: " + tabPage.Name);
            tabPage.AutoScroll = true;
            tabPage.AutoScrollMargin = new Size(20, 20);
            tabPage.AutoScrollMinSize = new Size(tabPage.Width, tabPage.Height);
            if (tabPage.Name.Equals(_tabID))
                tabPage.Show();
            else
                tabPage.Name = _tabID;
            tabPage.Text = tabname;
            tabPage.Controls.Add(uc);
            uc.AutoSize = true;
            if (xtraTabData.TabPages.Contains(tabPage)) return;
            xtraTabData.TabPages.Add(tabPage);
            xtraTabData.SelectedTabPage = tabPage;
            tabPage.Show();
        }
        private void addTabfromMainMenu(string tabname, UserControl uc)
        {
            foreach (DevExpress.XtraTab.XtraTabPage tabpage in xtraTabData.TabPages)
            {
                if (tabpage.Text == tabname)
                {
                    xtraTabData.SelectedTabPage = tabpage;
                    return;
                }
            }
            DevExpress.XtraTab.XtraTabPage tabPage = new DevExpress.XtraTab.XtraTabPage();
            tabPage.Text = tabname;
            string[] _tabname = tabname.Split(' ');
            string name = null;
            foreach (string a in _tabname)
            {
                name += a;
            }
            tabPage.Name = name;
            tabPage.Controls.Add(uc);
            xtraTabData.TabPages.Add(tabPage);
            xtraTabData.SelectedTabPage = tabPage;
            tabPage.Show();
        }

        private void createReportExcel(bool generalClick)
        {
            try
            {

                DevExpress.XtraSpreadsheet.SpreadsheetControl exportData = new SpreadsheetControl();
                exportData.CreateNewDocument();
                IWorkbook workbook = exportData.Document;
                workbook.Worksheets[0].Name = "Process Plant";
                DevExpress.Spreadsheet.Worksheet worksheet = workbook.Worksheets[0];
                string[] header = { "Equipment", "Equipment Description", "Equipment Type", "Components",
                                    "Represent.fluid", "Fluid phase", "Current Risk($/year)", "Cofcat.Flammable(ft2/failure)",	"Cofcat.People($/failure)",	"Cofcat.Asset($/failure)",
	                                "Cofcat.Env($/failure)",	"Cofcat.Reputation($/failure)",	"Cofcat.Combined($/failure)",
                                    "Component Material Glade","InitThinningPOF(failures/year)",	"InitEnv.Cracking(failures/year)",	"InitOtherPOF(failures/year)",	"InitPOF(failures/year)",	"ExtThinningPOF(failures/year)",
	                                "ExtEnvCrackingProbability(failures/year)",	"ExtOtherPOF(failures/year)",	"ExtPOF(failures/year)",	"POF(failures/year)",
	                                "Current Risk($/year)",	"Future Risk($/year)"};
                //Merge Cells
                worksheet.MergeCells(worksheet.Range["A1:D1"]);
                worksheet.MergeCells(worksheet.Range["G1:M1"]);
                worksheet.MergeCells(worksheet.Range["O1:W1"]);
                worksheet.MergeCells(worksheet.Range["X1:Y1"]);

                //Header Name
                worksheet.Import(header, 1, 0, false);
                worksheet.Cells["A1"].Value = "Indentification";
                worksheet.Cells["G1"].Value = "Consequence (COF)";
                worksheet.Cells["O1"].Value = "Probability (POF)";
                worksheet.Cells["X1"].Value = "Risk";

                //Format Cell
                DevExpress.Spreadsheet.Range range1 = worksheet.Range["A2:Y2"];
                Formatting rangeFormat1 = range1.BeginUpdateFormatting();
                rangeFormat1.Alignment.RotationAngle = 90;
                rangeFormat1.Fill.BackgroundColor = Color.Yellow;
                rangeFormat1.Font.FontStyle = SpreadsheetFontStyle.Bold;

                range1.EndUpdateFormatting(rangeFormat1);

                DevExpress.Spreadsheet.Range range2 = worksheet.Range["A1:Y1"];
                Formatting rangeFormat2 = range2.BeginUpdateFormatting();
                rangeFormat2.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                rangeFormat2.Fill.BackgroundColor = Color.Yellow;
                rangeFormat2.Font.FontStyle = SpreadsheetFontStyle.Bold;
                range2.EndUpdateFormatting(rangeFormat2);
                //Boder
                DevExpress.Spreadsheet.Range range3 = worksheet.Range["A1:Y2"];
                range3.SetInsideBorders(Color.Gray, BorderLineStyle.Thin);
                range3.Borders.SetOutsideBorders(Color.Black, BorderLineStyle.Medium);

                //init Data for Excel
                RiskSummary risk = new RiskSummary();
                RW_FULL_POF fullPoF = busFullPoF.getData(IDProposal);
                RW_CA_LEVEL_1 CA = busCALevel1.getData(IDProposal);
                RW_CA_TANK CATank = busCATank.getData(IDProposal);

                RW_ASSESSMENT_BUS assBus = new RW_ASSESSMENT_BUS();
                //get EquipmentID ----> get EquipmentTypeName and APIComponentType
                int equipmentID = assBus.getEquipmentID(IDProposal);
                String equipmentTypename = busEquipmentType.getEquipmentTypeName(busEquipmentMaster.getEquipmentTypeID(equipmentID));
                COMPONENT_MASTER_BUS comMasterBus = new COMPONENT_MASTER_BUS();
                API_COMPONENT_TYPE_BUS apiBus = new API_COMPONENT_TYPE_BUS();
                int apiID = comMasterBus.getAPIComponentTypeID(equipmentID);
                String API_ComponentType_Name = apiBus.getAPIComponentTypeName(apiID);

                RW_INPUT_CA_LEVEL_1 inputCA = busInputCALevel1.getData(IDProposal);
                RW_INPUT_CA_TANK inputCATank = busInputCATank.getData(IDProposal);

                risk.EquipmentNumber = busEquipmentMaster.getEquipmentName(equipmentID);//Equipment Name or Equipment Number can dc gan lai
                risk.EquipmentDesc = busEquipmentMaster.getEquipmentDesc(equipmentID);//Equipment Description gan lai
                risk.EquipmentType = equipmentTypename; //Equipment type
                risk.ComponentName = comMasterBus.getComponentName(equipmentID); //component name
                if (inputCA.ID != 0)
                {
                    risk.RepresentFluid = inputCA.API_FLUID; //Represent fluid
                    risk.FluidPhase = inputCA.SYSTEM;  //fluid phase
                    risk.cofcatFlammable = CA.CA_inj_flame; //cofcat. Flammable
                    risk.cofcatPeople = CA.FC_inj;//cofcat people
                    risk.cofcatAsset = CA.FC_prod;//cofcat assessment
                    risk.cofcatEnv = CA.FC_envi;//cofcat envroment
                    risk.cofcatCombined = CA.FC_total; //combined
                }
                else
                {
                    risk.RepresentFluid = inputCATank.API_FLUID; //Represent fluid tank
                    risk.FluidPhase = "Liquid";  //fluid phase
                    risk.cofcatFlammable = 0; //cofcat. Component Damage Cost
                    risk.cofcatPeople = 0;
                    risk.cofcatAsset = CATank.Business_Cost;//cofcat assessment
                    risk.cofcatEnv = CATank.FC_Environ;//cofcat envroment
                    risk.cofcatCombined = CATank.Consequence; //combined
                }
                risk.currentRisk = 0;//current risk
                risk.cofcatReputation = 0; //cof reputation
                //risk.componentMaterialGrade; //component material glade
                risk.initThinningPoF = fullPoF.ThinningAP1;//Thinning POF
                risk.initEnvCracking = fullPoF.SCCAP1;//Cracking env
                risk.initOtherPoF = fullPoF.HTHA_AP1 + fullPoF.BrittleAP1 + fullPoF.FatigueAP1;//OtherPOF
                risk.initPoF = risk.initThinningPoF + risk.initEnvCracking + risk.initOtherPoF;//Init POF
                risk.extThinningPoF = fullPoF.ExternalAP1;//Ext Thinning POF
                risk.extEnvCrackingPoF = 0;//ExtEnv Cracking
                risk.extOtherPoF = 0;//Ext Other POF
                risk.extPoF = risk.extThinningPoF + risk.extEnvCrackingPoF + risk.extOtherPoF; //Ext POF
                risk.PoF = risk.initPoF + risk.extPoF;//POF
                risk.CurrentRiskCalculation = fullPoF.PoFAP1 * CA.FC_total; //Current risk
                risk.futureRisk = fullPoF.PoFAP2 * CA.FC_total;

                MSSQL_CA_CAL riskCal = new MSSQL_CA_CAL();
                //Write Data to Cells
                if (generalClick)
                {
                    worksheet.Cells["A3"].Value = risk.EquipmentNumber; //Equipment Name or Equipment Number can dc gan lai
                    worksheet.Cells["B3"].Value = risk.EquipmentDesc; //Equipment Description gan lai
                    worksheet.Cells["C3"].Value = risk.EquipmentType; //Equipment type
                    worksheet.Cells["D3"].Value = risk.ComponentName; //component name
                    worksheet.Cells["E3"].Value = risk.RepresentFluid; //Represent fluid
                    worksheet.Cells["F3"].Value = risk.FluidPhase;  //fluid phase
                    worksheet.Cells["G3"].Value = risk.currentRisk == 0 ? "N/A" : riskCal.FC_Category(risk.currentRisk);
                    worksheet.Cells["H3"].Value = risk.cofcatFlammable == 0 ? "N/A" : riskCal.CA_Category(risk.cofcatFlammable);
                    worksheet.Cells["I3"].Value = risk.cofcatPeople == 0 ? "N/A" : riskCal.FC_Category(risk.cofcatPeople);
                    worksheet.Cells["J3"].Value = risk.cofcatAsset == 0 ? "N/A" : riskCal.FC_Category(risk.cofcatAsset);
                    worksheet.Cells["K3"].Value = risk.cofcatEnv == 0 ? "N/A" : riskCal.FC_Category(risk.cofcatEnv);
                    worksheet.Cells["L3"].Value = risk.cofcatReputation == 0 ? "N/A" : riskCal.FC_Category(risk.cofcatReputation);
                    worksheet.Cells["M3"].Value = risk.cofcatCombined == 0 ? "N/A" : riskCal.FC_Category(risk.cofcatCombined);
                    worksheet.Cells["N3"].Value = risk.componentMaterialGrade; //component material glade
                    worksheet.Cells["O3"].Value = risk.initThinningPoF == 0 ? "N/A" : riskCal.FC_Category(risk.initThinningPoF);
                    worksheet.Cells["P3"].Value = risk.initEnvCracking == 0 ? "N/A" : riskCal.FC_Category(risk.initEnvCracking);
                    worksheet.Cells["Q3"].Value = risk.initOtherPoF == 0 ? "N/A" : riskCal.FC_Category(risk.initOtherPoF);
                    worksheet.Cells["R3"].Value = risk.initPoF == 0 ? "N/A" : riskCal.FC_Category(risk.initPoF);
                    worksheet.Cells["S3"].Value = risk.extThinningPoF == 0 ? "N/A" : riskCal.FC_Category(risk.extThinningPoF);
                    worksheet.Cells["T3"].Value = risk.extEnvCrackingPoF == 0 ? "N/A" : riskCal.FC_Category(risk.extEnvCrackingPoF);
                    worksheet.Cells["U3"].Value = risk.extOtherPoF == 0 ? "N/A" : riskCal.FC_Category(risk.extOtherPoF);
                    worksheet.Cells["V3"].Value = risk.extPoF == 0 ? "N/A" : riskCal.FC_Category(risk.extPoF);
                    worksheet.Cells["W3"].Value = risk.PoF == 0 ? "N/A" : riskCal.FC_Category(risk.PoF);
                    worksheet.Cells["X3"].Value = risk.CurrentRiskCalculation == 0 ? "N/A" : riskCal.FC_Category(risk.CurrentRiskCalculation);
                    worksheet.Cells["Y3"].Value = risk.futureRisk == 0 ? "N/A" : riskCal.FC_Category(risk.futureRisk);
                }
                else
                {
                    worksheet.Cells["A3"].Value = risk.EquipmentNumber; //Equipment Name or Equipment Number can dc gan lai
                    worksheet.Cells["B3"].Value = risk.EquipmentDesc; //Equipment Description gan lai
                    worksheet.Cells["C3"].Value = risk.EquipmentType; //Equipment type
                    worksheet.Cells["D3"].Value = risk.ComponentName; //component name
                    worksheet.Cells["E3"].Value = risk.RepresentFluid; //Represent fluid
                    worksheet.Cells["F3"].Value = risk.FluidPhase;  //fluid phase
                    worksheet.Cells["G3"].Value = risk.currentRisk == 0 ? 0 : risk.currentRisk;
                    worksheet.Cells["H3"].Value = risk.cofcatFlammable == 0 ? 0 : risk.cofcatFlammable;
                    worksheet.Cells["I3"].Value = risk.cofcatPeople == 0 ? 0 : risk.cofcatPeople;
                    worksheet.Cells["J3"].Value = risk.cofcatAsset == 0 ? 0 : risk.cofcatAsset;
                    worksheet.Cells["K3"].Value = risk.cofcatEnv == 0 ? 0 : risk.cofcatEnv;
                    worksheet.Cells["L3"].Value = risk.cofcatReputation == 0 ? 0 : risk.cofcatReputation;
                    worksheet.Cells["M3"].Value = risk.cofcatCombined == 0 ? 0 : risk.cofcatCombined;
                    worksheet.Cells["N3"].Value = risk.componentMaterialGrade; //component material glade
                    worksheet.Cells["O3"].Value = risk.initThinningPoF == 0 ? 0 : risk.initThinningPoF;
                    worksheet.Cells["P3"].Value = risk.initEnvCracking == 0 ? 0 : risk.initEnvCracking;
                    worksheet.Cells["Q3"].Value = risk.initOtherPoF == 0 ? 0 : risk.initOtherPoF;
                    worksheet.Cells["R3"].Value = risk.initPoF == 0 ? 0 : risk.initPoF;
                    worksheet.Cells["S3"].Value = risk.extThinningPoF == 0 ? 0 : risk.extThinningPoF;
                    worksheet.Cells["T3"].Value = risk.extEnvCrackingPoF == 0 ? 0 : risk.extEnvCrackingPoF;
                    worksheet.Cells["U3"].Value = risk.extOtherPoF == 0 ? 0 : risk.extOtherPoF;
                    worksheet.Cells["V3"].Value = risk.extPoF == 0 ? 0 : risk.extPoF;
                    worksheet.Cells["W3"].Value = risk.PoF == 0 ? 0 : risk.PoF;
                    worksheet.Cells["X3"].Value = risk.CurrentRiskCalculation == 0 ? 0 : risk.CurrentRiskCalculation;
                    worksheet.Cells["Y3"].Value = risk.futureRisk == 0 ? 0 : risk.futureRisk;
                }
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel 2003 (*.xls)|*.xls|Excel Document (*xlsx)|*.xlsx";
                save.Title = "Save File";
                save.ShowDialog();
                String filePath = save.FileName;
                String extension = Path.GetExtension(filePath);
                if (filePath != "")
                {
                    try
                    {
                        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                        {
                            if (extension == ".xls")
                                exportData.SaveDocument(stream, DocumentFormat.Xls);
                            else
                                exportData.SaveDocument(stream, DocumentFormat.Xlsx);
                            MessageBox.Show("This file has been saved", "Cortek RBI");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Save error!", "Cortek RBI");
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Cannot create file", "Cortek", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void createInspectionPlanExcel(bool IsExportAllData)
        {
            DevExpress.XtraSpreadsheet.SpreadsheetControl exportData = new SpreadsheetControl();
            exportData.CreateNewDocument();
            try
            {
                //<format file Excel>
                IWorkbook workbook = exportData.Document;
                workbook.Worksheets[0].Name = "Process Plant";
                workbook.Worksheets.Insert(1, "Lookup");
                DevExpress.Spreadsheet.Worksheet worksheet = workbook.Worksheets[0];
                DevExpress.Spreadsheet.Worksheet worksheet1 = workbook.Worksheets[1];
                workbook.Worksheets[1].Visible = false;
                string[] header = { "System", "Equipment", "Damage Mechanism", "Method", "Coverage", "Availability", "Last Inspection Date", "Inspection Interval", "Due Date" };
                string[] inspectionType = {"Inspection Type", "ACFM", "Angled Compression Wave", "Angled Shear Wave", "A-scan Thickness Survey", "B-scan", "Chime", 
                                          "Compton Scatter", "Crack Detection", "C-scan", "Digital Ultrasonic Thickness Gauge", "Endoscopy", 
                                          "Gamma Radiography", "Hardness Surveys", "Hydrotesting", "Leak Detection", "Liquid Penetrant Inspection",
                                          "Lorus", "Low frequency", "Magnetic Fluorescent Inspection", "Magnetic Flux Leakage", "Magnetic Particle Inspection", 
                                          "Microstructure Replication", "Naked Eye", "On-line Monitoring", "Passive Thermography", "Penetrant Leak Detection", 
                                          "Pulsed", "Real-time Radiography", "Remote field", "Standard (flat coil)", "Surface Waves", "Teletest", "TOFD", 
                                          "Transient Thermography", "Video", "X-Radiography" };
                //data validation for worksheet1
                for (int i = 0; i < inspectionType.Length; i++)
                {
                    worksheet1.Cells["H" + (i + 1).ToString()].Value = inspectionType[i];
                }
                worksheet1.Cells["H1"].Font.FontStyle = SpreadsheetFontStyle.Bold;

                //header
                worksheet.Import(header, 0, 0, false);
                //format
                DevExpress.Spreadsheet.Range range2 = worksheet.Range["A1:I1"];
                Formatting rangeFormat2 = range2.BeginUpdateFormatting();
                rangeFormat2.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                rangeFormat2.Fill.BackgroundColor = Color.Yellow;
                rangeFormat2.Font.FontStyle = SpreadsheetFontStyle.Bold;
                range2.EndUpdateFormatting(rangeFormat2);
                //Boder
                DevExpress.Spreadsheet.Range range3 = worksheet.Range["A1:I1"];
                range3.SetInsideBorders(Color.Gray, BorderLineStyle.Thin);
                range3.Borders.SetOutsideBorders(Color.Black, BorderLineStyle.Medium);

                //<end format file Excel>

                List<InspectionPlant> lstDmgMechanism = busDamageMechanism.GetListInspectionPlant();
                worksheet.DataValidations.Add(worksheet["D2:D" + lstDmgMechanism.Count.ToString()], DataValidationType.List, ValueObject.FromRange(worksheet1["H2:H" + (inspectionType.Length + 1).ToString()].GetRangeWithAbsoluteReference()));
                if (IsExportAllData)
                {
                    for (int i = 0; i < lstDmgMechanism.Count; i++)
                    {
                        int eqId = busAssessment.getEquipmentID(lstDmgMechanism[i].IDProposal);
                        int faciID = busEquipmentMaster.getFacilityID(eqId);
                        worksheet.Cells["A" + (i + 2).ToString()].Value = busFacility.getFacilityName(faciID);
                        worksheet.Cells["B" + (i + 2).ToString()].Value = busEquipmentMaster.getEquipmentName(eqId);
                        worksheet.Cells["C" + (i + 2).ToString()].Value = damageMachenism[lstDmgMechanism[i].DMItemID]; //DM item
                        worksheet.Cells["D" + (i + 2).ToString()].Value = "ACFM"; //Method
                        worksheet.Cells["E" + (i + 2).ToString()].Value = "N/A"; //listInspec[i].Coverage;
                        worksheet.Cells["F" + (i + 2).ToString()].Value = "Online";//listInspec[i].Availability;
                        worksheet.Cells["G" + (i + 2).ToString()].Value = lstDmgMechanism[i].LastInspectionDate;//listInspec[i].LastInspectionDate;
                        worksheet.Cells["I" + (i + 2).ToString()].Value = lstDmgMechanism[i].DueDate;//listInspec[i].DueDate;
                        TimeSpan interval = Convert.ToDateTime(lstDmgMechanism[i].DueDate) - Convert.ToDateTime(lstDmgMechanism[i].LastInspectionDate);
                        worksheet.Cells["H" + (i + 2).ToString()].Value = interval.Days / 365;
                    }
                }
                else
                {
                    int cnt = 2;
                    for (int i = 0; i < lstDmgMechanism.Count; i++)
                    {
                        if (lstDmgMechanism[i].IDProposal == IDProposal)
                        {
                            int eqId = busAssessment.getEquipmentID(lstDmgMechanism[i].IDProposal);
                            int faciID = busEquipmentMaster.getFacilityID(eqId);
                            worksheet.Cells["A" + cnt.ToString()].Value = busFacility.getFacilityName(faciID);
                            worksheet.Cells["B" + cnt.ToString()].Value = busEquipmentMaster.getEquipmentName(eqId);
                            worksheet.Cells["C" + cnt.ToString()].Value = damageMachenism[lstDmgMechanism[i].DMItemID]; //DM item
                            worksheet.Cells["D" + cnt.ToString()].Value = "ACFM"; //Method
                            worksheet.Cells["E" + cnt.ToString()].Value = "N/A"; //listInspec[i].Coverage;
                            worksheet.Cells["F" + cnt.ToString()].Value = "Online";//listInspec[i].Availability;
                            worksheet.Cells["G" + cnt.ToString()].Value = lstDmgMechanism[i].LastInspectionDate;//listInspec[i].LastInspectionDate;
                            worksheet.Cells["I" + cnt.ToString()].Value = lstDmgMechanism[i].DueDate;//listInspec[i].DueDate;
                            TimeSpan interval = Convert.ToDateTime(lstDmgMechanism[i].DueDate) - Convert.ToDateTime(lstDmgMechanism[i].LastInspectionDate);
                            worksheet.Cells["H" + cnt.ToString()].Value = interval.Days / 365;
                            ++cnt;
                        }
                    }
                }
                worksheet.Columns.AutoFit(0, 8);
            }
            catch
            {
                MessageBox.Show("Cannot create file! Please try again", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 2003 (*.xls)|*.xls|Excel Document (*xlsx)|*.xlsx";
            save.Title = "Save File";
            save.ShowDialog();
            String filePath = save.FileName;
            String extension = Path.GetExtension(filePath);
            if (filePath != "")
            {
                try
                {
                    using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        if (extension == ".xls")
                            exportData.SaveDocument(stream, DocumentFormat.Xls);
                        else
                            exportData.SaveDocument(stream, DocumentFormat.Xlsx);
                        MessageBox.Show("This file has been saved", "Cortek RBI");
                    }
                }
                catch
                {
                    MessageBox.Show("Save error!", "Cortek RBI");
                }
            }
        }
        private void createReportExcelTank(bool generalClick)
        {
            try
            {

                DevExpress.XtraSpreadsheet.SpreadsheetControl exportData = new SpreadsheetControl();
                exportData.CreateNewDocument();
                IWorkbook workbook = exportData.Document;
                workbook.Worksheets[0].Name = "Process Plant";
                DevExpress.Spreadsheet.Worksheet worksheet = workbook.Worksheets[0];
                string[] header = {"Equipment", "Equipment Description",    "Equipment Type",   "Components",
                                "Represent.fluid",  "Fluid phase", "Current Risk($/year)",  "Cofcat.Flammable(ft2/failure)",    "Cofcat.LeakEnviroment($/failure)", "Cofcat.Asset($/failure)",
                                    "Cofcat.Env($/failure)",    "Cofcat.Reputation($/failure)", "Cofcat.Combined($/failure)",
                                "Component Material Glade","InitThinningPOF(failures/year)",    "InitEnv.Cracking(failures/year)",  "InitOtherPOF(failures/year)",  "InitPOF(failures/year)",   "ExtThinningPOF(failures/year)",
                                    "ExtEnvCrackingProbability(failures/year)", "ExtOtherPOF(failures/year)",   "ExtPOF(failures/year)",    "POF(failures/year)",
                                    "Current Risk($/year)", "Future Risk($/year)"};
                //Merge Cells
                worksheet.MergeCells(worksheet.Range["A1:D1"]);
                worksheet.MergeCells(worksheet.Range["G1:M1"]);
                worksheet.MergeCells(worksheet.Range["O1:W1"]);
                worksheet.MergeCells(worksheet.Range["X1:Y1"]);

                //Header Name
                worksheet.Import(header, 1, 0, false);
                worksheet.Cells["A1"].Value = "Indentification";
                worksheet.Cells["G1"].Value = "Consequence (COF)";
                worksheet.Cells["O1"].Value = "Probability (POF)";
                worksheet.Cells["X1"].Value = "Risk";

                //Format Cell
                DevExpress.Spreadsheet.Range range1 = worksheet.Range["A2:Y2"];
                Formatting rangeFormat1 = range1.BeginUpdateFormatting();
                rangeFormat1.Alignment.RotationAngle = 90;
                rangeFormat1.Fill.BackgroundColor = Color.Yellow;
                rangeFormat1.Font.FontStyle = SpreadsheetFontStyle.Bold;

                range1.EndUpdateFormatting(rangeFormat1);

                DevExpress.Spreadsheet.Range range2 = worksheet.Range["A1:Y1"];
                Formatting rangeFormat2 = range2.BeginUpdateFormatting();
                rangeFormat2.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                rangeFormat2.Fill.BackgroundColor = Color.Yellow;
                rangeFormat2.Font.FontStyle = SpreadsheetFontStyle.Bold;
                range2.EndUpdateFormatting(rangeFormat2);
                //Boder
                DevExpress.Spreadsheet.Range range3 = worksheet.Range["A1:Y2"];
                range3.SetInsideBorders(Color.Gray, BorderLineStyle.Thin);
                range3.Borders.SetOutsideBorders(Color.Black, BorderLineStyle.Medium);

                //init Data for Excel
                RiskSummary risk = new RiskSummary();
                RW_FULL_POF fullPoF = busFullPoF.getData(IDProposal);
                RW_CA_LEVEL_1 CA = busCALevel1.getData(IDProposal);
                //get EquipmentID ----> get EquipmentTypeName and APIComponentType
                int equipmentID = busAssessment.getEquipmentID(IDProposal);
                String equipmentTypename = busEquipmentType.getEquipmentTypeName(busEquipmentMaster.getEquipmentTypeID(equipmentID));
                int apiID = busComponentMaster.getAPIComponentTypeID(equipmentID);
                String API_ComponentType_Name = busApiComponentType.getAPIComponentTypeName(apiID);
                RW_INPUT_CA_LEVEL_1 inputCA = busInputCALevel1.getData(IDProposal);
                RW_CA_TANK caTank = busCATank.getData(IDProposal);
                risk.EquipmentNumber = busEquipmentMaster.getEquipmentNumber(equipmentID);//Equipment Name or Equipment Number can dc gan lai
                risk.EquipmentDesc = busEquipmentMaster.getEquipmentDesc(equipmentID);//Equipment Description gan lai
                risk.EquipmentType = equipmentTypename; //Equipment type
                risk.ComponentName = busComponentMaster.getComponentName(equipmentID); //component name
                risk.RepresentFluid = inputCA.API_FLUID; //Represent fluid
                risk.FluidPhase = inputCA.SYSTEM;  //fluid phase
                risk.currentRisk = 0;//current risk
                risk.cofcatFlammable = CA.CA_inj_flame; //cofcat. Flammable
                risk.cofcatPeople = caTank.FC_Environ_Leak;
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

                MSSQL_CA_CAL riskCal = new MSSQL_CA_CAL();
                //Write Data to Cells
                if (generalClick)
                {
                    worksheet.Cells["A3"].Value = risk.EquipmentNumber; //Equipment Name or Equipment Number can dc gan lai
                    worksheet.Cells["B3"].Value = risk.EquipmentDesc; //Equipment Description gan lai
                    worksheet.Cells["C3"].Value = risk.EquipmentType; //Equipment type
                    worksheet.Cells["D3"].Value = risk.ComponentName; //component name
                    worksheet.Cells["E3"].Value = risk.RepresentFluid; //Represent fluid
                    worksheet.Cells["F3"].Value = risk.FluidPhase;  //fluid phase
                    worksheet.Cells["G3"].Value = risk.currentRisk == 0 ? "N/A" : riskCal.FC_Category(risk.currentRisk);
                    worksheet.Cells["H3"].Value = risk.cofcatFlammable == 0 ? "N/A" : riskCal.CA_Category(risk.cofcatFlammable);
                    worksheet.Cells["I3"].Value = risk.cofcatPeople == 0 ? "N/A" : riskCal.FC_Category(risk.cofcatPeople);
                    worksheet.Cells["J3"].Value = risk.cofcatAsset == 0 ? "N/A" : riskCal.FC_Category(risk.cofcatAsset);
                    worksheet.Cells["K3"].Value = risk.cofcatEnv == 0 ? "N/A" : riskCal.FC_Category(risk.cofcatEnv);
                    worksheet.Cells["L3"].Value = risk.cofcatReputation == 0 ? "N/A" : riskCal.FC_Category(risk.cofcatReputation);
                    worksheet.Cells["M3"].Value = risk.cofcatCombined == 0 ? "N/A" : riskCal.FC_Category(risk.cofcatCombined);
                    worksheet.Cells["N3"].Value = risk.componentMaterialGrade; //component material glade
                    worksheet.Cells["O3"].Value = risk.initThinningPoF == 0 ? "N/A" : riskCal.FC_Category(risk.initThinningPoF);
                    worksheet.Cells["P3"].Value = risk.initEnvCracking == 0 ? "N/A" : riskCal.FC_Category(risk.initEnvCracking);
                    worksheet.Cells["Q3"].Value = risk.initOtherPoF == 0 ? "N/A" : riskCal.FC_Category(risk.initOtherPoF);
                    worksheet.Cells["R3"].Value = risk.initPoF == 0 ? "N/A" : riskCal.FC_Category(risk.initPoF);
                    worksheet.Cells["S3"].Value = risk.extThinningPoF == 0 ? "N/A" : riskCal.FC_Category(risk.extThinningPoF);
                    worksheet.Cells["T3"].Value = risk.extEnvCrackingPoF == 0 ? "N/A" : riskCal.FC_Category(risk.extEnvCrackingPoF);
                    worksheet.Cells["U3"].Value = risk.extOtherPoF == 0 ? "N/A" : riskCal.FC_Category(risk.extOtherPoF);
                    worksheet.Cells["V3"].Value = risk.extPoF == 0 ? "N/A" : riskCal.FC_Category(risk.extPoF);
                    worksheet.Cells["W3"].Value = risk.PoF == 0 ? "N/A" : riskCal.FC_Category(risk.PoF);
                    worksheet.Cells["X3"].Value = risk.CurrentRiskCalculation == 0 ? "N/A" : riskCal.FC_Category(risk.CurrentRiskCalculation);
                    worksheet.Cells["Y3"].Value = risk.futureRisk == 0 ? "N/A" : riskCal.FC_Category(risk.futureRisk);
                }
                else
                {
                    worksheet.Cells["A3"].Value = risk.EquipmentNumber; //Equipment Name or Equipment Number can dc gan lai
                    worksheet.Cells["B3"].Value = risk.EquipmentDesc; //Equipment Description gan lai
                    worksheet.Cells["C3"].Value = risk.EquipmentType; //Equipment type
                    worksheet.Cells["D3"].Value = risk.ComponentName; //component name
                    worksheet.Cells["E3"].Value = risk.RepresentFluid; //Represent fluid
                    worksheet.Cells["F3"].Value = risk.FluidPhase;  //fluid phase
                    worksheet.Cells["G3"].Value = risk.currentRisk == 0 ? 0 : risk.currentRisk;
                    worksheet.Cells["H3"].Value = risk.cofcatFlammable == 0 ? 0 : risk.cofcatFlammable;
                    worksheet.Cells["I3"].Value = risk.cofcatPeople == 0 ? 0 : risk.cofcatPeople;
                    worksheet.Cells["J3"].Value = risk.cofcatAsset == 0 ? 0 : risk.cofcatAsset;
                    worksheet.Cells["K3"].Value = risk.cofcatEnv == 0 ? 0 : risk.cofcatEnv;
                    worksheet.Cells["L3"].Value = risk.cofcatReputation == 0 ? 0 : risk.cofcatReputation;
                    worksheet.Cells["M3"].Value = risk.cofcatCombined == 0 ? 0 : risk.cofcatCombined;
                    worksheet.Cells["N3"].Value = risk.componentMaterialGrade; //component material glade
                    worksheet.Cells["O3"].Value = risk.initThinningPoF == 0 ? 0 : risk.initThinningPoF;
                    worksheet.Cells["P3"].Value = risk.initEnvCracking == 0 ? 0 : risk.initEnvCracking;
                    worksheet.Cells["Q3"].Value = risk.initOtherPoF == 0 ? 0 : risk.initOtherPoF;
                    worksheet.Cells["R3"].Value = risk.initPoF == 0 ? 0 : risk.initPoF;
                    worksheet.Cells["S3"].Value = risk.extThinningPoF == 0 ? 0 : risk.extThinningPoF;
                    worksheet.Cells["T3"].Value = risk.extEnvCrackingPoF == 0 ? 0 : risk.extEnvCrackingPoF;
                    worksheet.Cells["U3"].Value = risk.extOtherPoF == 0 ? 0 : risk.extOtherPoF;
                    worksheet.Cells["V3"].Value = risk.extPoF == 0 ? 0 : risk.extPoF;
                    worksheet.Cells["W3"].Value = risk.PoF == 0 ? 0 : risk.PoF;
                    worksheet.Cells["X3"].Value = risk.CurrentRiskCalculation == 0 ? 0 : risk.CurrentRiskCalculation;
                    worksheet.Cells["Y3"].Value = risk.futureRisk == 0 ? 0 : risk.futureRisk;
                }
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel 2003 (*.xls)|*.xls|Excel Document (*xlsx)|*.xlsx";
                save.Title = "Save File";
                save.ShowDialog();
                String filePath = save.FileName;
                String extension = Path.GetExtension(filePath);
                if (filePath != "")
                {
                    try
                    {
                        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                        {
                            if (extension == ".xls")
                                exportData.SaveDocument(stream, DocumentFormat.Xls);
                            else
                                exportData.SaveDocument(stream, DocumentFormat.Xlsx);
                            MessageBox.Show("This file has been saved", "Cortek RBI");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Save error!", "Cortek RBI");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //Thiet bi thuong
        private void SaveDatatoDatabase(RW_ASSESSMENT ass, RW_EQUIPMENT eq, RW_COMPONENT com, RW_STREAM stream, RW_EXTCOR_TEMPERATURE extTemp, RW_COATING coat, RW_MATERIAL ma, RW_INPUT_CA_LEVEL_1 ca)
        {
            busAssessment.edit(ass);
            busEquipment.edit(eq);
            busComponent.edit(com);
            busStream.edit(stream);
            busExtcorTemp.edit(extTemp);
            busCoating.edit(coat);
            busMaterial.edit(ma);
            busInputCALevel1.edit(ca);

        }
        //thiet bi tank
        private void SaveDatatoDatabase(RW_ASSESSMENT ass, RW_EQUIPMENT eq, RW_COMPONENT com, RW_STREAM stream, RW_EXTCOR_TEMPERATURE extTemp, RW_COATING coat, RW_MATERIAL ma, RW_INPUT_CA_TANK ca)
        {
            busAssessment.edit(ass);
            busEquipment.edit(eq);
            busComponent.edit(com);
            busStream.edit(stream);
            busExtcorTemp.edit(extTemp);
            busCoating.edit(coat);
            busMaterial.edit(ma);
            busInputCATank.edit(ca);
        }
        private void showUCinTabpage(UserControl uc)
        {
            if (xtraTabData.SelectedTabPageIndex == 0) return;
            if (xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Contains(uc)) return;
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Clear();
            xtraTabData.TabPages.TabControl.SelectedTabPage.Controls.Add(uc);
        }
        #endregion // mai

        #region Navigation Link
        private void navExportAllInsp_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            createInspectionPlanExcel(true);
        }
        private void navAddNewSite_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmNewSite site = new frmNewSite();
            site.ShowInTaskbar = false;
            site.ShowDialog();
        }

        private void navAddNewFacility_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmFacilityInput faci = new frmFacilityInput();
            faci.ShowInTaskbar = false;
            faci.ShowDialog();
        }

        private void navRiskSummaryMainMenu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCRisk risk = new UCRisk();
            risk.Dock = DockStyle.Fill;
            addTabfromMainMenu("Risk", risk);
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtraTabData.TabPages.TabControl.SelectedTabPageIndex = 0;
            
        }

        private void navFullInspHis_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            UCInspectionHistory history = new UCInspectionHistory();
            history.Dock = DockStyle.Fill;
            addTabfromMainMenu("Inspection History", history);
        }
        private void CheckAndShowTab(string tabname, int serial)
        {
           
            int n = 0;
            if (int.TryParse(tabname, out n))
            {
                ShowItemTabpage(n, serial, checkTank);
            }
                
            else
                return;
        }

        // * mai coppy
        private void ChangeColorForNavLink(object sender)
        {
            DevExpress.XtraNavBar.NavBarItem nav = sender as DevExpress.XtraNavBar.NavBarItem;
            switch (nav.Name)
            {
                case "navAssessmentInfo":
                    navAssessmentInfo.Appearance.ForeColor = Color.Red;
                    navEquipment.Appearance.ForeColor = navComponent.Appearance.ForeColor =
                        navOperating.Appearance.ForeColor = navMaterial.Appearance.ForeColor =
                        navCoating.Appearance.ForeColor = navNoInspection.Appearance.ForeColor =
                        navStream.Appearance.ForeColor = navRiskFactor.Appearance.ForeColor =
                        navCA.Appearance.ForeColor = navRiskSummary.Appearance.ForeColor =
                        navViewGraph.Appearance.ForeColor = Color.Black;
                    break;
                case "navEquipment":
                    navEquipment.Appearance.ForeColor = Color.Red;
                    navAssessmentInfo.Appearance.ForeColor = navComponent.Appearance.ForeColor =
                        navOperating.Appearance.ForeColor = navMaterial.Appearance.ForeColor =
                        navCoating.Appearance.ForeColor = navNoInspection.Appearance.ForeColor =
                        navStream.Appearance.ForeColor = navRiskFactor.Appearance.ForeColor =
                        navCA.Appearance.ForeColor = navRiskSummary.Appearance.ForeColor =
                        navViewGraph.Appearance.ForeColor = Color.Black;
                    break;
                case "navComponent":
                    navComponent.Appearance.ForeColor = Color.Red;
                    navEquipment.Appearance.ForeColor = navAssessmentInfo.Appearance.ForeColor =
                        navOperating.Appearance.ForeColor = navMaterial.Appearance.ForeColor =
                        navCoating.Appearance.ForeColor = navNoInspection.Appearance.ForeColor =
                        navStream.Appearance.ForeColor = navRiskFactor.Appearance.ForeColor =
                        navCA.Appearance.ForeColor = navRiskSummary.Appearance.ForeColor =
                        navViewGraph.Appearance.ForeColor = Color.Black;
                    break;

                case "navOperating":
                    navOperating.Appearance.ForeColor = Color.Red;
                    navEquipment.Appearance.ForeColor = navComponent.Appearance.ForeColor =
                        navAssessmentInfo.Appearance.ForeColor = navMaterial.Appearance.ForeColor =
                        navCoating.Appearance.ForeColor = navNoInspection.Appearance.ForeColor =
                        navStream.Appearance.ForeColor = navRiskFactor.Appearance.ForeColor =
                        navCA.Appearance.ForeColor = navRiskSummary.Appearance.ForeColor =
                        navViewGraph.Appearance.ForeColor = Color.Black;
                    break;
                case "navMaterial":
                    navMaterial.Appearance.ForeColor = Color.Red;
                    navEquipment.Appearance.ForeColor = navComponent.Appearance.ForeColor =
                        navOperating.Appearance.ForeColor = navAssessmentInfo.Appearance.ForeColor =
                        navCoating.Appearance.ForeColor = navNoInspection.Appearance.ForeColor =
                        navStream.Appearance.ForeColor = navRiskFactor.Appearance.ForeColor =
                        navCA.Appearance.ForeColor = navRiskSummary.Appearance.ForeColor =
                        navViewGraph.Appearance.ForeColor = Color.Black;
                    break;
                case "navCoating":
                    navCoating.Appearance.ForeColor = Color.Red;
                    navEquipment.Appearance.ForeColor = navComponent.Appearance.ForeColor =
                        navOperating.Appearance.ForeColor = navMaterial.Appearance.ForeColor =
                        navAssessmentInfo.Appearance.ForeColor = navNoInspection.Appearance.ForeColor =
                        navStream.Appearance.ForeColor = navRiskFactor.Appearance.ForeColor =
                        navCA.Appearance.ForeColor = navRiskSummary.Appearance.ForeColor =
                        navViewGraph.Appearance.ForeColor = Color.Black;
                    break;
                case "navNoInspection":
                    navNoInspection.Appearance.ForeColor = Color.Red;
                    navEquipment.Appearance.ForeColor = navComponent.Appearance.ForeColor =
                        navOperating.Appearance.ForeColor = navMaterial.Appearance.ForeColor =
                        navCoating.Appearance.ForeColor = navAssessmentInfo.Appearance.ForeColor =
                        navStream.Appearance.ForeColor = navRiskFactor.Appearance.ForeColor =
                        navCA.Appearance.ForeColor = navRiskSummary.Appearance.ForeColor =
                        navViewGraph.Appearance.ForeColor = Color.Black;
                    break;
                case "navStream":
                    navStream.Appearance.ForeColor = Color.Red;
                    navEquipment.Appearance.ForeColor = navComponent.Appearance.ForeColor =
                        navOperating.Appearance.ForeColor = navMaterial.Appearance.ForeColor =
                        navCoating.Appearance.ForeColor = navNoInspection.Appearance.ForeColor =
                        navAssessmentInfo.Appearance.ForeColor = navRiskFactor.Appearance.ForeColor =
                        navCA.Appearance.ForeColor = navRiskSummary.Appearance.ForeColor =
                        navViewGraph.Appearance.ForeColor = Color.Black;
                    break;
                case "navRiskFactor":
                    navRiskFactor.Appearance.ForeColor = Color.Red;
                    navEquipment.Appearance.ForeColor = navComponent.Appearance.ForeColor =
                        navOperating.Appearance.ForeColor = navMaterial.Appearance.ForeColor =
                        navCoating.Appearance.ForeColor = navNoInspection.Appearance.ForeColor =
                        navStream.Appearance.ForeColor = navAssessmentInfo.Appearance.ForeColor =
                        navCA.Appearance.ForeColor = navRiskSummary.Appearance.ForeColor =
                        navViewGraph.Appearance.ForeColor = Color.Black;
                    break;
                case "navCA":
                    navCA.Appearance.ForeColor = Color.Red;
                    navEquipment.Appearance.ForeColor = navComponent.Appearance.ForeColor =
                        navOperating.Appearance.ForeColor = navMaterial.Appearance.ForeColor =
                        navCoating.Appearance.ForeColor = navNoInspection.Appearance.ForeColor =
                        navStream.Appearance.ForeColor = navRiskFactor.Appearance.ForeColor =
                        navAssessmentInfo.Appearance.ForeColor = navRiskSummary.Appearance.ForeColor =
                        navViewGraph.Appearance.ForeColor = Color.Black;
                    break;
                case "navRiskSummary":
                    navRiskSummary.Appearance.ForeColor = Color.Red;
                    navEquipment.Appearance.ForeColor = navComponent.Appearance.ForeColor =
                        navOperating.Appearance.ForeColor = navMaterial.Appearance.ForeColor =
                        navCoating.Appearance.ForeColor = navNoInspection.Appearance.ForeColor =
                        navStream.Appearance.ForeColor = navRiskFactor.Appearance.ForeColor =
                        navCA.Appearance.ForeColor = navAssessmentInfo.Appearance.ForeColor =
                        navViewGraph.Appearance.ForeColor = Color.Black;
                    break;
                case "navViewGraph":
                    navViewGraph.Appearance.ForeColor = Color.Red;
                    navEquipment.Appearance.ForeColor = navComponent.Appearance.ForeColor =
                        navOperating.Appearance.ForeColor = navMaterial.Appearance.ForeColor =
                        navCoating.Appearance.ForeColor = navNoInspection.Appearance.ForeColor =
                        navStream.Appearance.ForeColor = navRiskFactor.Appearance.ForeColor =
                        navCA.Appearance.ForeColor = navRiskSummary.Appearance.ForeColor =
                        navAssessmentInfo.Appearance.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }
        }
        //
        
        private void navAssessmentInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangeColorForNavLink(sender); //mai   
            CheckAndShowTab(this.xtraTabData.SelectedTabPage.Name, 1);
        }
        private void navEquipment_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangeColorForNavLink(sender); //mai
            CheckAndShowTab(this.xtraTabData.SelectedTabPage.Name, 2);
        }

        private void navComponent_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangeColorForNavLink(sender); //mai
            CheckAndShowTab(this.xtraTabData.SelectedTabPage.Name, 3);
        }

        private void navOperating_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangeColorForNavLink(sender); //mai
            CheckAndShowTab(this.xtraTabData.SelectedTabPage.Name, 4);
        }

        private void navMaterial_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangeColorForNavLink(sender); //mai
            CheckAndShowTab(this.xtraTabData.SelectedTabPage.Name, 6);
        }

        private void navCoating_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangeColorForNavLink(sender); //mai
            CheckAndShowTab(this.xtraTabData.SelectedTabPage.Name, 5);
        }

        private void navNoInspection_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangeColorForNavLink(sender); //mai
            CheckAndShowTab(this.xtraTabData.SelectedTabPage.Name, 11);
        }

        private void navStream_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangeColorForNavLink(sender); //mai
            CheckAndShowTab(this.xtraTabData.SelectedTabPage.Name, 7);
        }
        private void navRiskFactor_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangeColorForNavLink(sender); //mai
            CheckAndShowTab(this.xtraTabData.SelectedTabPage.Name, 9);
        }
        private void navCA_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangeColorForNavLink(sender); //mai
            CheckAndShowTab(this.xtraTabData.SelectedTabPage.Name, 8);
        }
        private void navRiskSummary_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangeColorForNavLink(sender); //mai
            CheckAndShowTab(this.xtraTabData.SelectedTabPage.Name, 10);
        }
        private void navViewGraph_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ChangeColorForNavLink(sender); //mai
            CheckAndShowTab(this.xtraTabData.SelectedTabPage.Name, 12);
        }
        #endregion

        #region Parameters
        

        //<input DM>
        private int[] DM_ID = { 8, 9, 61, 57, 73, 69, 60, 72, 62, 70, 67, 34, 32, 66, 63, 68, 2, 18, 1, 14, 10 };
        private string[] DM_Name = { "Internal Thinning", "Internal Lining Degradation", "Caustic Stress Corrosion Cracking", 
                                 "Amine Stress Corrosion Cracking", "Sulphide Stress Corrosion Cracking (H2S)", "HIC/SOHIC-H2S",
                                 "Carbonate Stress Corrosion Cracking", "Polythionic Acid Stress Corrosion Cracking",
                                 "Chloride Stress Corrosion Cracking", "Hydrogen Stress Cracking (HF)", "HF Produced HIC/SOHIC",
                                 "External Corrosion", "Corrosion Under Insulation", "External Chloride Stress Corrosion Cracking",
                                 "Chloride Stress Corrosion Cracking Under Insulation", "High Temperature Hydrogen Attack",
                                 "Brittle Fracture", "Temper Embrittlement", "885F Embrittlement", "Sigma Phase Embrittlement",
                                 "Vibration-Induced Mechanical Fatigue" };

        private String[] UnitName = {
            "Pressure",
            "Stress",
            "Temperature",
            "Diameter",
            "Thickness",
            "Dimensions",
            "Volume",
            "FlowRate",
            "Corrosion",
            "CorrosionRate",
            "FinacialUnit"
        };
        private Dictionary<int, string> damageMachenism = new Dictionary<int, string>();
        //</input DM>

        //<treeListProject_MouseDoubleClick>
        private List<UCAssessmentInfo> listUCAssessment = new List<UCAssessmentInfo>();
        private List<UCCoatLiningIsulationCladding> listUCCoating = new List<UCCoatLiningIsulationCladding>();
        private List<UCComponentProperties> listUCComponent = new List<UCComponentProperties>();
        private List<UCEquipmentProperties> listUCEquipment = new List<UCEquipmentProperties>();
        private List<UCMaterial> listUCMaterial = new List<UCMaterial>();
        private List<UCStream> listUCStream = new List<UCStream>();
        private List<UCOperatingCondition> listUCOperating = new List<UCOperatingCondition>();
        private List<UCRiskFactor> listUCRiskFactor = new List<UCRiskFactor>();
        private List<TestData> listTree1 = null;
        private int IDProposal = 0;
        private bool checkTank = false;
        //</treeListProject_MouseDoubleClick>

        //<initDataforTreeList>
        private List<TestData> listTree;
        //</initDataforTreeList>

        //<treeListProject_FocusedNodeChanged>
        private int selectedLevel = -1;
        //</treeListProject_FocusedNodeChanged>

        //<btnPlanInsp_ItemClick>
        private List<InspectionPlant> listInspectionPlan = new List<InspectionPlant>();
        //</btnPlanInsp_ItemClick>
        private List<ucTabNormal> listUC = new List<ucTabNormal>();
        private List<ucTabTank> listUCTank = new List<ucTabTank>();
        private int IDNodeTreeList = 0;
        private int numUC = 0;
        private List<UserControl> previousUC = new List<UserControl>();
        private int tabPageIndex = 0;
        //<BUS>
        SITES_BUS busSites = new SITES_BUS();
        FACILITY_BUS busFacility = new FACILITY_BUS();
        EQUIPMENT_MASTER_BUS busEquipmentMaster = new EQUIPMENT_MASTER_BUS();
        COMPONENT_MASTER_BUS busComponentMaster = new COMPONENT_MASTER_BUS();
        EQUIPMENT_TYPE_BUS busEquipmentType = new EQUIPMENT_TYPE_BUS();
        COMPONENT_TYPE__BUS busComponentType = new COMPONENT_TYPE__BUS();
        RW_ASSESSMENT_BUS busAssessment = new RW_ASSESSMENT_BUS();
        RW_EQUIPMENT_BUS busEquipment = new RW_EQUIPMENT_BUS();
        RW_COMPONENT_BUS busComponent = new RW_COMPONENT_BUS();
        RW_STREAM_BUS busStream = new RW_STREAM_BUS();
        RW_EXTCOR_TEMPERATURE_BUS busExtcorTemp = new RW_EXTCOR_TEMPERATURE_BUS();
        RW_MATERIAL_BUS busMaterial = new RW_MATERIAL_BUS();
        RW_COATING_BUS busCoating = new RW_COATING_BUS();
        RW_INPUT_CA_LEVEL_1_BUS busInputCALevel1 = new RW_INPUT_CA_LEVEL_1_BUS();
        RW_INPUT_CA_TANK_BUS busInputCATank = new RW_INPUT_CA_TANK_BUS();
        RW_CA_LEVEL_1_BUS busCALevel1 = new RW_CA_LEVEL_1_BUS();
        RW_CA_TANK_BUS busCATank = new RW_CA_TANK_BUS();
        RW_FULL_POF_BUS busFullPoF = new RW_FULL_POF_BUS();
        RW_FULL_FCOF_BUS busFullFCoF = new RW_FULL_FCOF_BUS();
        API_COMPONENT_TYPE_BUS busApiComponentType = new API_COMPONENT_TYPE_BUS();
        RW_INSPECTION_HISTORY_BUS busInspectionHistory = new RW_INSPECTION_HISTORY_BUS();
        FACILITY_RISK_TARGET_BUS busRiskTarget = new FACILITY_RISK_TARGET_BUS();
        RW_DAMAGE_MECHANISM_BUS busDamageMechanism = new RW_DAMAGE_MECHANISM_BUS();
        RW_RISK_GRAPH_BUS busRiskGraph = new RW_RISK_GRAPH_BUS();        
        //</BUS>
        #endregion
        #region Unit String
        string pressure = "";
        string stress = "";
        string temperature = "";
        string diameter = "";
        string dimension = "";
        string volume = "";
        string thickness = "";
        string corrosion = "";
        string corrosionRate = "";
        string flowRate = "";
        string finacialUnit = "";
        private List<UNITS> listUnit = new List<UNITS>();
        UNITS_BUS busUnit = new UNITS_BUS();
        #endregion
      
        private void xtraTabData_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Press");
            xtraTabData.SelectedTabPage.Text += "*";
            
        }

        private void btnUnitSeting_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUnits uf = new frmUnits();
            uf.ShowInTaskbar = false;
            uf.ShowDialog();
            if (uf.ButtonOKClicked) 
            {
                initScheme();
                DialogResult dlr =  MessageBox.Show("Your computer need to restart! \nDo you want to restart?", "Warning!", MessageBoxButtons.OKCancel);
                if(dlr == DialogResult.OK)
                System.Windows.Forms.Application.Restart();
            }
        }
        
    }
    
}