using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RBI.BUS.BUSMSSQL;
using RBI.Object.ObjectMSSQL;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmNewSite : Form
    {
        SITES_BUS siteBus = new SITES_BUS();
        List<SITES> listSite = new List<SITES>();
        public bool ButtonOKClicked { set; get; }
        private bool IsFormEditName = false;
        private int siteID = 0;
        public frmNewSite()
        {
            InitializeComponent();
        }
        public frmNewSite(string siteName) //form danh cho edit Site name
        {
            InitializeComponent();
            this.IsFormEditName = true;
            siteID = siteBus.getIDbyName(siteName);
            label2.Text = "Edit site name";
            txtSiteName.Text = siteName;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            listSite = siteBus.getData();
            foreach (SITES site in listSite)
            {
                if (site.SiteName == txtSiteName.Text)
                {
                    MessageBox.Show("Site name already exists!", "Cortek RBI");
                    return;
                }
            }
            SITES s = new SITES();
            s.SiteName = txtSiteName.Text;
            if(IsFormEditName)
            {
                s.SiteID = siteID;
                siteBus.edit(s);
            }
            else
            {
                siteBus.add(s);
            }
            
            ButtonOKClicked = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSiteName_TextChanged(object sender, EventArgs e)
        {
            if (txtSiteName.Text == "") btnOK.Enabled = false;
            else btnOK.Enabled = true;
        }

        private void frmNewSite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}
