using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
using RBI.BUS.BUSMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmFacilityInput : Form
    {
        
        FACILITY_RISK_TARGET_BUS facilityRisk = new FACILITY_RISK_TARGET_BUS();
        FACILITY_BUS facility = new FACILITY_BUS();
        SITES_BUS siteBus = new SITES_BUS();
        List<SITES> listSite = new List<SITES>();
        RW_RISK_GRAPH_BUS busGraph = new RW_RISK_GRAPH_BUS();
        public bool doubleEditClicked { set; get; }
        public int facilityID = 0;
        public bool ButtonOKClicked { set; get; }
        public frmFacilityInput()
        {
            InitializeComponent();
            listSite = siteBus.getData();
            cbSites.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < listSite.Count; i++)
            {
                cbSites.Properties.Items.Add(listSite[i].SiteName, i, i);
            }
        }
        public frmFacilityInput(int ID)
        {
            InitializeComponent();
            this.facilityID = ID;
            setData2From(ID);
            label7.Text = "Edit Facility";
        }
        public void setData2From(int ID)
        { 
            FACILITY f = facility.getFacility(ID);
            txtFacilityName.Text = f.FacilityName;
            listSite = siteBus.getData();
            cbSites.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listSite.Count; i++)
            {
                cbSites.Properties.Items.Add(listSite[i].SiteName, i, i);
                if(listSite[i].SiteID == f.SiteID)
                {
                    cbSites.SelectedIndex = i + 1;
                }
            }
            cbSites.Enabled = false;
            numManagementSystem.Value = f.ManagementFactor > 10 ? 10 : (decimal)f.ManagementFactor;

            FACILITY_RISK_TARGET f_Target = facilityRisk.getFacilityRiskTarget(ID);
            txtArea.Text = f_Target.RiskTarget_CA.ToString();
            txtFinancial.Text = f_Target.RiskTarget_FC.ToString();
            txtA.Text = f_Target.RiskTarget_A.ToString();
            txtB.Text = f_Target.RiskTarget_B.ToString();
            txtC.Text = f_Target.RiskTarget_C.ToString();
            txtD.Text = f_Target.RiskTarget_D.ToString();
            txtE.Text = f_Target.RiskTarget_E.ToString();
            
        }
        public FACILITY getFacilityName()
        {
            FACILITY faci = new FACILITY();
            if (doubleEditClicked)
            {
                faci.FacilityID = this.facilityID;
            }
            foreach(SITES s in listSite)
            {
                if(s.SiteName == cbSites.Text)
                {
                    faci.SiteID = s.SiteID;
                }
            }
            faci.FacilityName = txtFacilityName.Text;
            faci.ManagementFactor = float.Parse(numManagementSystem.Value.ToString());
            return faci;
        }
        public FACILITY_RISK_TARGET getRiskTarget()
        {
            FACILITY_RISK_TARGET faciRisk = new FACILITY_RISK_TARGET();
            List<FACILITY> fa = facility.getDataSource();
            foreach(FACILITY f in fa)
            {
                if( txtFacilityName.Text == f.FacilityName)
                {
                    faciRisk.FacilityID = f.FacilityID;
                }
            }
            faciRisk.RiskTarget_CA = float.Parse(txtArea.Text);
            faciRisk.RiskTarget_FC = float.Parse(txtFinancial.Text);
            faciRisk.RiskTarget_A = float.Parse(txtA.Text);
            faciRisk.RiskTarget_B = float.Parse(txtB.Text);
            faciRisk.RiskTarget_C = float.Parse(txtC.Text);
            faciRisk.RiskTarget_D = float.Parse(txtD.Text);
            faciRisk.RiskTarget_E = float.Parse(txtE.Text);
            return faciRisk;
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFacilityName.Text == "" || txtArea.Text == "" || txtFinancial.Text == "" || cbSites.Text == "") return;
            if (doubleEditClicked)
            {
                facility.edit(getFacilityName());
                facilityRisk.edit(getRiskTarget());
            }
            else
            {
                List<FACILITY> listFa = facility.getDataSource();
                foreach (FACILITY fa in listFa)
                {
                    if (fa.FacilityName == txtFacilityName.Text)
                    {
                        MessageBox.Show("Facility already exists", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                facility.add(getFacilityName());
                facilityRisk.add(getRiskTarget());
            }
            ButtonOKClicked = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Picture Event
        private void txtFacilityName_TextChanged(object sender, EventArgs e)
        {
            if (txtFacilityName.Text != "") pictureBox1.Hide();
            else pictureBox1.Show();
        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            if (txtArea.Text == "") pictureBox3.Show();
            else pictureBox3.Hide();
        }

        private void txtFinancial_TextChanged(object sender, EventArgs e)
        {
            if (txtFinancial.Text == "") pictureBox4.Show();
            else pictureBox4.Hide();
        }

        private void cbSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSites.Text == "") pictureBox2.Show();
            else pictureBox2.Hide();
        }
        #endregion

        #region Key Press Event
        private void textBox_KeyPress(TextBox textbox, KeyPressEventArgs ev)
        {
            string a = textbox.Text;
            if(!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.'))
            {
                ev.Handled = true;
            }
            if(a.Contains(".") && ev.KeyChar == '.')
            {
                ev.Handled = true;
            }
        }
        private void txtArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(txtArea, e);
        }

        private void txtFinancial_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(txtFinancial, e);
        }

        private void txtE_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(txtE, e);
        }

        private void txtD_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(txtD, e);
        }

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(txtC, e);
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(txtB, e);
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(txtA, e);
        }
        

        private void GioiHanPoF(TextBox txt)
        {
            string a = txt.Text;
            
            if(a == "")
                txt.Text = "0";
            else
            {
                string b = a.Substring(0, 1);
                if (b == ".")
                    txt.Text = "0";
            }
            
            if (float.Parse(txt.Text) > 1)
            {
                MessageBox.Show("Invalid Value", "Cortek RBI");
                txt.Text = "1";
            }
        }

        private void txtE_TextChanged(object sender, EventArgs e)
        {
            GioiHanPoF(txtE);
        }

        private void txtD_TextChanged(object sender, EventArgs e)
        {
            GioiHanPoF(txtD);
        }

        private void txtC_TextChanged(object sender, EventArgs e)
        {
            GioiHanPoF(txtC);
        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {
            GioiHanPoF(txtB);
        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {
            GioiHanPoF(txtA);
        }
        #endregion
    }
}
