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
using DevExpress.XtraWaitForm;
using DevExpress.XtraSplashScreen;

namespace RBI.PRE.subForm.OutputDataForm
{
    public partial class frm_restored : Form
    {
        public frm_restored()
        {
            InitializeComponent();
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Back Up File|*.bak";
            op.Title = "Restore Data Base";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = op.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm2));
            if (txtPath.Text.Trim().Length != 0)
            {
                // open connection
                SqlConnection connect;
                string con = "Data Source = localhost; Initial Catalog=master ;Integrated Security = True;";
                connect = new SqlConnection(con);
                connect.Open();

                try
                {
                    //Excute SQL----------------
                    SqlCommand command;
                    command = new SqlCommand("use master", connect);
                    command.ExecuteNonQuery();
                    command = new SqlCommand("alter database rbi set offline with rollback immediate; ", connect);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(@"restore database rbi from disk = '" + txtPath.Text + "'", connect);
                    command.ExecuteNonQuery();
                    command = new SqlCommand("alter database rbi set online with rollback immediate; ", connect);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    SplashScreenManager.CloseForm();
                    MessageBox.Show("Restore Fail", "Cortek RBI");
                    this.Close();
                }
                connect.Close();
                SplashScreenManager.CloseForm();
                Application.Restart();
            }
            else
            {
                SplashScreenManager.CloseForm();
                MessageBox.Show("Please select a file", "Cortek RBI");
                return;
            }
            this.Close();
        }
    }
}
