using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm.OutputDataForm
{
    public partial class frm_backup : Form
    {
        public frm_backup()
        {
            InitializeComponent();
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Backup File| *.bak";
            save.Title = "Save Data Backup File";
            save.FileName = "DataLab" + DateTime.Now.ToString("_MM_dd_yyyy_HH_mm_ss") + ".bak";

            if (save.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = save.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm2));
            if (txtPath.Text.Trim().Length != 0)
            {
                //Connect DB
                SqlConnection connect;
                string con = "Data Source = localhost; Initial Catalog=rbi ;Integrated Security = True;";
                connect = new SqlConnection(con);
                connect.Open();

                //Execute SQL---------------
                try
                {
                    SqlCommand command;
                    command = new SqlCommand(@"backup database rbi to disk ='" + txtPath.Text + "' with init,stats=10", connect);
                    command.ExecuteNonQuery();
                    SplashScreenManager.CloseForm();
                    MessageBox.Show("Backup successfully", "Cortek RBI");
                }
                catch
                {
                    SplashScreenManager.CloseForm();
                    MessageBox.Show("Cannot backup data to this destination! \n Backup Fail", "Backup Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Close connection
                connect.Close();
            }
            else
            {
                SplashScreenManager.CloseForm();
                MessageBox.Show("Select a location to save the file", "Warning");
                return;
            }
            this.Close();
        }
    }
}
