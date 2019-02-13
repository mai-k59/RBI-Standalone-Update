using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmNewMaterial : Form
    {
        public frmNewMaterial()
        {
            InitializeComponent();
            cbHTHA.Enabled = false;
            cbPTA.Enabled = false;
            addHeatTreatment();
            addSulfurContent();
            addPTA();
            addHTTA();
        }
        private void addHeatTreatment()
        {
            cbHeatTreatment.Properties.Items.Add("");
            cbHeatTreatment.Properties.Items.Add("Annealed");
            cbHeatTreatment.Properties.Items.Add("None");
            cbHeatTreatment.Properties.Items.Add("Normalised Temper");
            cbHeatTreatment.Properties.Items.Add("Quench Temper");
            cbHeatTreatment.Properties.Items.Add("Stress Relieved");
            cbHeatTreatment.Properties.Items.Add("Sub Citical PWHT");
        }
        private void addSulfurContent()
        {
            cbSulphurContent.Properties.Items.Add("");
            cbSulphurContent.Properties.Items.Add("High > 0.01%");
            cbSulphurContent.Properties.Items.Add("Low 0.002 - 0.01%");
            cbSulphurContent.Properties.Items.Add("Ultra Low < 0.002%");
        }
        private void addPTA()
        {
            cbPTA.Properties.Items.Add("");
            cbPTA.Properties.Items.Add("Regular 300 series Stainless Steels and Alloys 600 and 800");
            cbPTA.Properties.Items.Add("L Grade 300 series Stainless Steels");
            cbPTA.Properties.Items.Add("H Grade 300 series Stainless Steels");
            cbPTA.Properties.Items.Add("321 Stainless Steels");
            cbPTA.Properties.Items.Add("347 Stainless Steels, Alloy 20, Alloy 625, All austenitic weld overlay");
            cbPTA.Properties.Items.Add("Not Applicable");
        }
        private void addHTTA()
        {
            cbHTHA.Properties.Items.Add("");
            cbHTHA.Properties.Items.Add("Carbon Steel");
            cbHTHA.Properties.Items.Add("C-0.5Mo (Annealed)");
            cbHTHA.Properties.Items.Add("C-0.5Mo (Normalised)");
            cbHTHA.Properties.Items.Add("1Cr-0.5Mo");
            cbHTHA.Properties.Items.Add("1.25Cr-0.5Mo");
            cbHTHA.Properties.Items.Add("2.25Cr-1Mo");
            cbHTHA.Properties.Items.Add("Not Applicable");
        }

        private void chkPTA_CheckedChanged(object sender, EventArgs e)
        {
            cbPTA.Enabled = chkPTA.Checked ? true : false;
        }

        private void chkHTHA_CheckedChanged(object sender, EventArgs e)
        {
            cbHTHA.Enabled = chkHTHA.Checked ? true : false;
        }

    }
}
