using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;

using System.Data.OleDb;
using System.IO;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using RBI.BUS.BUSExcel;
using RBI.Object.ObjectMSSQL;
using RBI.BUS.BUSMSSQL;
using RBI.PRE.subForm.OutputDataForm;
using DevExpress.XtraSplashScreen;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmImportExcelTank : Form
    {
        public bool ButtonOKClicked { set; get; }
        public frmImportExcelTank()
        {
            InitializeComponent();
        }
        
        #region Parameter
        DevExpress.XtraSpreadsheet.SpreadsheetControl spreadExcel = new SpreadsheetControl();
        string fileName = null;
        string extension = null;
        #endregion
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Excel 2003 (*.xls)|*.xls|Excel Document (*.xlsx)|*.xlsx|All File(*)|*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtPathFileExcel.Text = op.FileName;
            }
        }
        private bool CheckFormatFile()
        {
            IWorkbook workbook = spreadExcel.Document;
            DevExpress.Spreadsheet.Worksheet worksheet = workbook.Worksheets[0];
            bool isCorrect = true;
            if (workbook.Worksheets.Count != 7)
            {
                MessageBox.Show("Format is not correct! Please check again", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return
                    false;
            }
            for (int i = 0; i < 6; i++)
            {
                string sheetName = workbook.Worksheets[i].Name;
                switch (i)
                {
                    case 0:
                        if (sheetName != "Equipment")
                        {
                            MessageBox.Show("Sheet Name " + sheetName + " is not correct!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isCorrect = false;
                        }
                        break;
                    case 1:
                        if (sheetName != "Component")
                        {
                            MessageBox.Show("Sheet Name " + sheetName + " is not correct!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isCorrect = false;
                        }
                        break;
                    case 2:
                        if (sheetName != "Operating Condition")
                        {
                            MessageBox.Show("Sheet Name " + sheetName + " is not correct!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isCorrect = false;
                        }
                        break;
                    case 3:
                        if (sheetName != "Stream")
                        {
                            MessageBox.Show("Sheet Name " + sheetName + " is not correct!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isCorrect = false;
                        }
                        break;
                    case 4:
                        if (sheetName != "Material")
                        {
                            MessageBox.Show("Sheet Name " + sheetName + " is not correct!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isCorrect = false;
                        }
                        break;
                    default:
                        if (sheetName != "CoatingCladdingLiningInsulation")
                        {
                            MessageBox.Show("Sheet Name " + sheetName + " is not correct!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isCorrect = false;
                        }
                        break;
                }
            }
            if (worksheet.Columns.LastUsedIndex <= 31)
            {
                MessageBox.Show("This is Plant Process excel file! Select again", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return isCorrect;
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (txtPathFileExcel.Text == "")
            {
                MessageBox.Show("Please select a file", "Cortek RBI");
                return;
            }
            fileName = Path.GetFileName(txtPathFileExcel.Text);
            extension = Path.GetExtension(fileName);
            if (extension == ".xls")
            {
                spreadExcel.LoadDocument(txtPathFileExcel.Text, DocumentFormat.Xls);
                if (!CheckFormatFile()) return;
            }
            else if (extension == ".xlsx")
            {
                spreadExcel.LoadDocument(txtPathFileExcel.Text, DocumentFormat.Xlsx);
                if (!CheckFormatFile()) return;
            }
            else
            {
                MessageBox.Show("This file is not supported!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnImport.Enabled = true;
            pictureBox1.Hide();
            label1.Hide();
            spreadExcel.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(spreadExcel);
            btnSave.Enabled = true;
            btnSaveAs.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = spreadExcel.Document;
            using (FileStream stream = new FileStream(txtPathFileExcel.Text, FileMode.Create, FileAccess.ReadWrite))
            {
                if (extension == ".xls")
                    workbook.SaveDocument(stream, DocumentFormat.Xls);
                else
                    workbook.SaveDocument(stream, DocumentFormat.Xlsx);
            }
            MessageBox.Show("This file has been saved!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm2));
            SITES_BUS busSite = new SITES_BUS();
            FACILITY_BUS busFacility = new FACILITY_BUS();
            MANUFACTURER_BUS busManufacture = new MANUFACTURER_BUS();
            DESIGN_CODE_BUS busDesignCode = new DESIGN_CODE_BUS();
            FACILITY_RISK_TARGET_BUS busRiskTarget = new FACILITY_RISK_TARGET_BUS();
            EQUIPMENT_MASTER_BUS busEquipMaster = new EQUIPMENT_MASTER_BUS();
            COMPONENT_MASTER_BUS busCompMaster = new COMPONENT_MASTER_BUS();
            RW_ASSESSMENT_BUS busAss = new RW_ASSESSMENT_BUS();
            RW_EQUIPMENT_BUS busEquip = new RW_EQUIPMENT_BUS();
            RW_COMPONENT_BUS busCom = new RW_COMPONENT_BUS();
            RW_EXTCOR_TEMPERATURE_BUS busExtcor = new RW_EXTCOR_TEMPERATURE_BUS();
            RW_STREAM_BUS busStream = new RW_STREAM_BUS();
            RW_MATERIAL_BUS busMaterial = new RW_MATERIAL_BUS();
            RW_COATING_BUS busCoating = new RW_COATING_BUS();
            RW_INPUT_CA_TANK_BUS busInputCATank = new RW_INPUT_CA_TANK_BUS();
            Bus_PLANT_PROCESS_Excel busExcel = new Bus_PLANT_PROCESS_Excel();
            busExcel.path = txtPathFileExcel.Text;
            //Sites
            List<SITES> lstSite = busExcel.getAllSite();
            foreach(SITES s in lstSite)
            {
                if(!busSite.checkExist(s.SiteName))
                {
                    busSite.add(s);
                }
                else
                {
                    busSite.edit(s);
                }
            }

            //Facility
            List<FACILITY> lstFacility = busExcel.getFacility();
            foreach(FACILITY f in lstFacility)
            {
                if(busFacility.checkExist(f.FacilityName))
                {
                    busFacility.edit(f);
                }
                else
                {
                    busFacility.add(f);
                    int FaciID = busFacility.getLastFacilityID();
                    FACILITY_RISK_TARGET riskTarget = new FACILITY_RISK_TARGET();
                    riskTarget.FacilityID = FaciID;
                    busRiskTarget.add(riskTarget);
                }
            }

            //Manufacture
            List<string> manufacture = busExcel.getAllManufacture();
            for (int i = 0; i < manufacture.Count; i++ )
            {
                MANUFACTURER manu = new MANUFACTURER();
                manu.ManufacturerID = busManufacture.getIDbyName(manufacture[i]);
                manu.ManufacturerName = manufacture[i];
                if(busManufacture.getIDbyName(manufacture[i]) == 0)
                {
                    busManufacture.add(manu);
                }
                else
                {
                    busManufacture.edit(manu);
                }
            }

            //Design Code
            List<string> designCode = busExcel.getAllDesigncode();
            for (int i = 0; i < designCode.Count; i++ )
            {
                DESIGN_CODE design = new DESIGN_CODE();
                design.DesignCodeID = busDesignCode.getIDbyName(designCode[i]);
                design.DesignCode = designCode[i];
                design.DesignCodeApp = "";
                if(design.DesignCodeID == 0)
                {
                    busDesignCode.add(design);
                }
                else
                {
                    busDesignCode.edit(design);
                }
            }

            //Equipment Master
            List<EQUIPMENT_MASTER> lstEquipMaster = busExcel.getEquipmentMaster();
            foreach(EQUIPMENT_MASTER eq in lstEquipMaster)
            {
                if(busEquipMaster.check(eq.EquipmentNumber))
                {
                    busEquipMaster.edit(eq);
                }
                else
                {
                    busEquipMaster.add(eq);
                }
            }

            //Component Master
            List<COMPONENT_MASTER> lstCompMaster = busExcel.getComponentMaster();
            foreach(COMPONENT_MASTER com in lstCompMaster)
            {
                if(busCompMaster.checkExist(com.ComponentNumber))
                {
                    com.ComponentID = busCompMaster.getIDbyName(com.ComponentNumber);
                    busCompMaster.edit(com);
                }
                else
                {
                    busCompMaster.add(com);
                }
            }

            //Rw Assessment
            List<RW_ASSESSMENT> lstAssessment = busExcel.getAssessment();
            List<int> editExcel = new List<int>();
            List<int> addExcel = new List<int>();
            foreach(RW_ASSESSMENT ass in lstAssessment)
            {
                List<int[]> ID_checkAddbyExcel = busAss.getCheckAddExcel_ID(ass.ComponentID, ass.EquipmentID);
                if(ID_checkAddbyExcel.Count != 0)
                {
                    for (int i = 0; i < ID_checkAddbyExcel.Count; i++)
                    {
                        if (ID_checkAddbyExcel[i][0] != 0) //kiem tra xem co phai Assessment nay duoc them tu file Excel ko
                        {
                            ass.ID = ID_checkAddbyExcel[i][1];
                            editExcel.Add(ass.ID);
                            busAss.edit(ass);
                        }
                    }
                }
                else
                {
                    ass.AddByExcel = 1;
                    busAss.add(ass);
                    int assID = busAss.getLastID();
                    addExcel.Add(assID);
                    RW_INPUT_CA_TANK inputCATank = new RW_INPUT_CA_TANK();
                    inputCATank.ID = assID;
                    busInputCATank.add(inputCATank);
                }
            }

            //RW Equipment
            List<RW_EQUIPMENT> lstEquipment = busExcel.getRwEquipmentTank();
            for (int i = 0; i < lstEquipment.Count; i++ )
            {
                if(editExcel.Count != 0)
                {
                    for(int j = 0; j < editExcel.Count; j++)
                    {
                        if(lstEquipment[i].ID == editExcel[j])
                        {
                            busEquip.edit(lstEquipment[i]);
                        }
                    }
                }
                if (addExcel.Count != 0)
                {
                    
                    for (int j = 0; j < addExcel.Count; j++)
                    {
                        if (lstEquipment[i].ID == addExcel[j])
                        {
                            busEquip.add(lstEquipment[i]);
                        }
                    }
                }
            }

            //RW Component
            List<RW_COMPONENT> lstComponent = busExcel.getRwComponentTank();
            for (int i = 0; i < lstComponent.Count; i++)
            {
                if (editExcel.Count != 0)
                {
                    for (int j = 0; j < editExcel.Count; j++)
                    {
                        if (lstComponent[i].ID == editExcel[j])
                        {
                            busCom.edit(lstComponent[i]);
                        }
                    }
                }
                if (addExcel.Count != 0)
                {
                    for (int j = 0; j < addExcel.Count; j++)
                    {
                        if (lstComponent[i].ID == addExcel[j])
                        {
                            busCom.add(lstComponent[i]);
                        }
                    }
                }
            }

            //RW Extcor temperature
            List<RW_EXTCOR_TEMPERATURE> lstExtcor = busExcel.getRwExtTemp();
            for (int i = 0; i < lstExtcor.Count; i++)
            {
                if (editExcel.Count != 0)
                {
                    for (int j = 0; j < editExcel.Count; j++)
                    {
                        if (lstExtcor[i].ID == editExcel[j])
                        {
                            busExtcor.edit(lstExtcor[i]);
                        }
                    }
                }
                if (addExcel.Count != 0)
                {
                    for (int j = 0; j < addExcel.Count; j++)
                    {
                        if (lstExtcor[i].ID == addExcel[j])
                        {
                            busExtcor.add(lstExtcor[i]);
                        }
                    }
                }
            }

            //RW Stream
            List<RW_STREAM> lstStream = busExcel.getRwStreamTank();
            for (int i = 0; i < lstStream.Count; i++)
            {
                if (editExcel.Count != 0)
                {
                    for (int j = 0; j < editExcel.Count; j++)
                    {
                        if (lstStream[i].ID == editExcel[j])
                        {
                            busStream.edit(lstStream[i]);
                        }
                    }
                }
                if (addExcel.Count != 0)
                {
                    for (int j = 0; j < addExcel.Count; j++)
                    {
                        if (lstStream[i].ID == addExcel[j])
                        {
                            busStream.add(lstStream[i]);
                        }
                    }
                }
            }

            //RW Material
            List<RW_MATERIAL> lstMaterial = busExcel.getRwMaterialTank();
            for (int i = 0; i < lstMaterial.Count; i++)
            {
                if (editExcel.Count != 0)
                {
                    for (int j = 0; j < editExcel.Count; j++)
                    {
                        if (lstMaterial[i].ID == editExcel[j])
                        {
                            busMaterial.edit(lstMaterial[i]);
                        }
                    }
                }
                if (addExcel.Count != 0)
                {
                    for (int j = 0; j < addExcel.Count; j++)
                    {
                        if (lstMaterial[i].ID == addExcel[j])
                        {
                            busMaterial.add(lstMaterial[i]);
                        }
                    }
                }
            }

            //RW Coating
            List<RW_COATING> lstCoating = busExcel.getRwCoating();
            for (int i = 0; i < lstCoating.Count; i++)
            {
                if (editExcel.Count != 0)
                {
                    for (int j = 0; j < editExcel.Count; j++)
                    {
                        if (lstCoating[i].ID == editExcel[j])
                        {
                            busCoating.edit(lstCoating[i]);
                        }
                    }
                }
                if (addExcel.Count != 0)
                {
                    for (int j = 0; j < addExcel.Count; j++)
                    {
                        if (lstCoating[i].ID == addExcel[j])
                        {
                            busCoating.add(lstCoating[i]);
                        }
                    }
                }
            }
            ButtonOKClicked = true;
            SplashScreenManager.CloseForm();
            MessageBox.Show("All data have been saved! You need to add Risk Target in Facility!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = spreadExcel.Document;
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "Excel 2003 (*.xls)|*.xls|Excel Document (*.xlsx)|*.xlsx|All File(*)|*";
            op.Title = "Save Inspection History File";
            op.ShowDialog();
            String pathFile = op.FileName;
            String exten = Path.GetExtension(pathFile);
            if (pathFile != "")
            {
                try
                {
                    using (FileStream stream = new FileStream(pathFile, FileMode.Create, FileAccess.ReadWrite))
                    {
                        if (exten == ".xls")
                            workbook.SaveDocument(stream, DocumentFormat.Xls);
                        else
                            workbook.SaveDocument(stream, DocumentFormat.Xlsx);
                    }
                    MessageBox.Show("This file has been saved!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch
                {
                    MessageBox.Show("Save file error!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}

