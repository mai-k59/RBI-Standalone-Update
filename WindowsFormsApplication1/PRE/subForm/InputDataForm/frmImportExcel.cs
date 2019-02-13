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
using DevExpress.XtraSplashScreen;
using System.Threading;
using RBI.PRE.subForm.OutputDataForm;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmImportExcel : Form
    {
        public frmImportExcel()
        {
            InitializeComponent();
        }
        public bool ButtonOKClicked { set; get; }
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
                btnImport.Enabled = false;
            }
            
        }
        private bool CheckFormatFile()
        {
            IWorkbook workbook = spreadExcel.Document;
            DevExpress.Spreadsheet.Worksheet worksheet = workbook.Worksheets[0];
            if (!workbook.IsProtected)
                workbook.Protect("hoang", true, false);
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
            if (worksheet.Columns.LastUsedIndex > 31)
            {
                MessageBox.Show("This is Storage Tank excel file! Select again", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return isCorrect;
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if(txtPathFileExcel.Text == "")
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
                MessageBox.Show("This file is not supported! Import again!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // data from file
            SITES_BUS busSite = new SITES_BUS();
            FACILITY_BUS busFacility = new FACILITY_BUS();
            MANUFACTURER_BUS busManufacture = new MANUFACTURER_BUS();
            DESIGN_CODE_BUS busDesign = new DESIGN_CODE_BUS();
            EQUIPMENT_MASTER_BUS busEqMaster = new EQUIPMENT_MASTER_BUS();
            COMPONENT_MASTER_BUS busComMaster = new COMPONENT_MASTER_BUS();
            RW_ASSESSMENT_BUS busAss = new RW_ASSESSMENT_BUS();
            RW_EQUIPMENT_BUS busEq = new RW_EQUIPMENT_BUS();
            RW_COMPONENT_BUS buscom = new RW_COMPONENT_BUS();
            RW_EXTCOR_TEMPERATURE_BUS busExcort = new RW_EXTCOR_TEMPERATURE_BUS();
            RW_STREAM_BUS busStream = new RW_STREAM_BUS();
            RW_MATERIAL_BUS busMaterial = new RW_MATERIAL_BUS();
            RW_COATING_BUS busCoat = new RW_COATING_BUS();
            RW_INPUT_CA_LEVEL_1_BUS busInputCA = new RW_INPUT_CA_LEVEL_1_BUS();
            FACILITY_RISK_TARGET_BUS busRiskTarget = new FACILITY_RISK_TARGET_BUS();
            Bus_PLANT_PROCESS_Excel busExcelProcess = new Bus_PLANT_PROCESS_Excel();
            busExcelProcess.path = txtPathFileExcel.Text;
            List<SITES> listSite = busExcelProcess.getAllSite();
            foreach (SITES s in listSite)
            {
                if (!busSite.checkExist(s.SiteName))
                    busSite.add(s);
                else
                    busSite.edit(s);
            }

            List<FACILITY> listFacility = busExcelProcess.getFacility();
            foreach (FACILITY f in listFacility)
            {
                if (busFacility.checkExist(f.FacilityName))
                    busFacility.edit(f);
                else
                {
                    busFacility.add(f);
                    int FaciID = busFacility.getLastFacilityID();
                    FACILITY_RISK_TARGET riskTarget = new FACILITY_RISK_TARGET();
                    riskTarget.FacilityID = FaciID;
                    busRiskTarget.add(riskTarget);
                }
            }

            List<string> manufacture = busExcelProcess.getAllManufacture();
            for (int i = 0; i < manufacture.Count; i++)
            {
                MANUFACTURER manu = new MANUFACTURER();
                manu.ManufacturerID = busManufacture.getIDbyName(manufacture[i]);
                manu.ManufacturerName = manufacture[i];
                if (busManufacture.getIDbyName(manufacture[i]) == 0)
                    busManufacture.add(manu);
                else
                    busManufacture.edit(manu);
            }

            List<String> designcode = busExcelProcess.getAllDesigncode();
            for (int i = 0; i < designcode.Count; i++)
            {
                DESIGN_CODE design = new DESIGN_CODE();
                design.DesignCodeID = busDesign.getIDbyName(designcode[i]);
                design.DesignCode = designcode[i];
                design.DesignCodeApp = "";
                if (design.DesignCodeID == 0)
                    busDesign.add(design);
                else
                    busDesign.edit(design);
            }

            List<EQUIPMENT_MASTER> listEpMaster = busExcelProcess.getEquipmentMaster();
            foreach (EQUIPMENT_MASTER eqM in listEpMaster)
            {
                if (busEqMaster.check(eqM.EquipmentNumber))
                    busEqMaster.edit(eqM);
                else
                {
                    busEqMaster.add(eqM);
                }
            }

            List<COMPONENT_MASTER> listComMaster = busExcelProcess.getComponentMaster();
            foreach (COMPONENT_MASTER comM in listComMaster)
            {
                if (busComMaster.checkExist(comM.ComponentNumber))
                    busComMaster.edit(comM);
                else
                    busComMaster.add(comM);
            }

            List<RW_ASSESSMENT> listRW_Assessment = busExcelProcess.getAssessment();
            List<int> editExcel = new List<int>();
            List<int> addExcel = new List<int>();
            foreach (RW_ASSESSMENT rwAss in listRW_Assessment)
            {
                //kiem tra xem Proposal add bang file Excel hay add bang tay
                List<int[]> ID_checkAddbyExcel = busAss.getCheckAddExcel_ID(rwAss.ComponentID, rwAss.EquipmentID);
                if (ID_checkAddbyExcel.Count != 0)
                {
                    for (int i = 0; i < ID_checkAddbyExcel.Count; i++)
                    {
                        if (ID_checkAddbyExcel[i][0] != 0) //kiem tra xem co phai Assessment nay duoc them tu file Excel ko, !=0 la them tu file Excel
                        {
                            rwAss.ID = ID_checkAddbyExcel[i][1];
                            editExcel.Add(rwAss.ID);
                            busAss.edit(rwAss);
                        }
                    }
                }
                else
                {
                    rwAss.AddByExcel = 1;
                    busAss.add(rwAss);
                    int assID = busAss.getLastID();
                    addExcel.Add(assID);
                    RW_INPUT_CA_LEVEL_1 inputCA = new RW_INPUT_CA_LEVEL_1();
                    inputCA.ID = assID;
                    busInputCA.add(inputCA);
                    
                }
            }

            List<RW_EQUIPMENT> listRw_eq = busExcelProcess.getRwEquipment();
            for (int i = 0; i < listRw_eq.Count; i++)
            {
                if (editExcel.Count != 0)
                {
                    for (int j = 0; j < editExcel.Count; j++)
                    {
                        if (listRw_eq[i].ID == editExcel[j])
                        {
                            busEq.edit(listRw_eq[i]);
                        }
                    }
                }
                if (addExcel.Count != 0)
                {
                    for (int j = 0; j < addExcel.Count; j++)
                    {
                        if (listRw_eq[i].ID == addExcel[j])
                        {
                            busEq.add(listRw_eq[i]);
                        }
                    }
                }
            }

            List<RW_COMPONENT> listRw_com = busExcelProcess.getRwComponent();
            for (int i = 0; i < listRw_com.Count; i++)
            {
                if (editExcel.Count != 0)
                {
                    for (int j = 0; j < editExcel.Count; j++)
                    {
                        if (listRw_com[i].ID == editExcel[j])
                        {
                            buscom.edit(listRw_com[i]);
                        }
                    }
                }
                if (addExcel.Count != 0)
                {
                    for (int j = 0; j < addExcel.Count; j++)
                    {
                        if (listRw_com[i].ID == addExcel[j])
                        {
                            buscom.add(listRw_com[i]);
                        }
                    }
                }
            }

            List<RW_EXTCOR_TEMPERATURE> listRw_extcor = busExcelProcess.getRwExtTemp();
            for (int i = 0; i < listRw_extcor.Count; i++)
            {
                if (editExcel.Count != 0)
                {
                    for (int j = 0; j < editExcel.Count; j++)
                    {
                        if (listRw_extcor[i].ID == editExcel[j])
                        {
                            busExcort.edit(listRw_extcor[i]);
                        }
                    }
                }
                if (addExcel.Count != 0)
                {
                    for (int j = 0; j < addExcel.Count; j++)
                    {
                        if (listRw_extcor[i].ID == addExcel[j])
                        {
                            busExcort.add(listRw_extcor[i]);
                        }
                    }
                }
            }

            List<RW_STREAM> listRw_stream = busExcelProcess.getRwStream();
            for (int i = 0; i < listRw_stream.Count; i++)
            {
                if (editExcel.Count != 0)
                {
                    for (int j = 0; j < editExcel.Count; j++)
                    {
                        if (listRw_stream[i].ID == editExcel[j])
                        {
                            busStream.edit(listRw_stream[i]);
                        }
                    }
                }
                if (addExcel.Count != 0)
                {
                    for (int j = 0; j < addExcel.Count; j++)
                    {
                        if (listRw_stream[i].ID == addExcel[j])
                        {
                            busStream.add(listRw_stream[i]);
                        }
                    }
                }
            }

            List<RW_MATERIAL> listRw_material = busExcelProcess.getRwMaterial();
            for (int i = 0; i < listRw_material.Count; i++)
            {
                if (editExcel.Count != 0)
                {
                    for (int j = 0; j < editExcel.Count; j++)
                    {
                        if (listRw_material[i].ID == editExcel[j])
                        {
                            busMaterial.edit(listRw_material[i]);
                        }
                    }
                }
                if (addExcel.Count != 0)
                {
                    for (int j = 0; j < addExcel.Count; j++)
                    {
                        if (listRw_material[i].ID == addExcel[j])
                        {
                            busMaterial.add(listRw_material[i]);
                        }
                    }
                }
            }

            List<RW_COATING> listRw_coat = busExcelProcess.getRwCoating();
            for (int i = 0; i < listRw_coat.Count; i++)
            {
                if (editExcel.Count != 0)
                {
                    for (int j = 0; j < editExcel.Count; j++)
                    {
                        if (listRw_coat[i].ID == editExcel[j])
                        {
                            busCoat.edit(listRw_coat[i]);
                        }
                    }
                }
                if (addExcel.Count != 0)
                {
                    for (int j = 0; j < addExcel.Count; j++)
                    {
                        if (listRw_coat[i].ID == addExcel[j])
                        {
                            busCoat.add(listRw_coat[i]);
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

