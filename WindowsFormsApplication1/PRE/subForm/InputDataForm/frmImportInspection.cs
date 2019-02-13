using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using RBI.BUS.BUSExcel;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.BUS.BUSMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmImportInspection : Form
    {
        public frmImportInspection()
        {
            InitializeComponent();
        }

        SpreadsheetControl spreadSheet = new SpreadsheetControl();
        string fileName = null;
        string extension = null;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Excel 2003 (*.xls)|*.xls|Excel Document (*.xlsx)|*.xlsx|All File(*)|*";
            op.Title = "Select Inspection History File!";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = op.FileName;
            }
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            label1.Hide();
            fileName = Path.GetFileName(txtPath.Text);
            extension = Path.GetExtension(fileName);
            if (extension == ".xls")
            {
                spreadSheet.LoadDocument(txtPath.Text, DocumentFormat.Xls);
            }
            else if (extension == ".xlsx")
            {
                spreadSheet.LoadDocument(txtPath.Text, DocumentFormat.Xlsx);
            }
            else
            {
                MessageBox.Show("This file is not supported!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            spreadSheet.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(spreadSheet);
            btnSave.Enabled = true;
            btnSaveAs.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = spreadSheet.Document;
            try
            {
                using (FileStream stream = new FileStream(txtPath.Text, FileMode.Create, FileAccess.ReadWrite))
                {
                    if (extension == ".xls")
                        workbook.SaveDocument(stream, DocumentFormat.Xls);
                    else
                        workbook.SaveDocument(stream, DocumentFormat.Xlsx);
                }
                MessageBox.Show("This file has been saved!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("This file is opened in another program!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = spreadSheet.Document;
            SaveFileDialog op = new SaveFileDialog();
            op.Filter = "Excel 2003 (*.xls)|*.xls|Excel Document (*.xlsx)|*.xlsx|All File(*)|*";
            op.Title = "Save Inspection History File";
            op.ShowDialog();
            String pathFile = op.FileName;
            String exten = Path.GetExtension(pathFile);
            if(pathFile != "")
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
        private void btnImport_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want save change?", "Cortek", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IWorkbook workbook = spreadSheet.Document;
                try
                {
                    using (FileStream stream = new FileStream(txtPath.Text, FileMode.Create, FileAccess.ReadWrite))
                    {
                        if (extension == ".xls")
                            workbook.SaveDocument(stream, DocumentFormat.Xls);
                        else
                            workbook.SaveDocument(stream, DocumentFormat.Xlsx);
                    }
                    Bus_INSPECTION_HISTORY_Excel excelBus = new Bus_INSPECTION_HISTORY_Excel();
                    RW_INSPECTION_HISTORY_BUS busHistory = new RW_INSPECTION_HISTORY_BUS();
                    List<RW_INSPECTION_HISTORY> list = excelBus.getListInsp(txtPath.Text);
                    for (int i = 0; i < list.Count; i++)
                    {
                        busHistory.add(list[i]);
                    }
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("This file is opened in another program!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                
            }
        }

}
}
