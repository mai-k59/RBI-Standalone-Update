using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;


namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCNoInspection : UserControl
    {
        public UCNoInspection()
        {
            InitializeComponent();
        }
        public NO_INSPECTION getData()
        {
            NO_INSPECTION no = new NO_INSPECTION();
            //number inspection
            no.numThinning = txtThinning.Text != "" ? int.Parse(txtThinning.Text) : 0;
            no.numCaustic = txtCaustic.Text != "" ? int.Parse(txtCaustic.Text) : 0;
            no.numAmine = txtAmine.Text != "" ? int.Parse(txtAmine.Text) : 0;
            no.numSulphide = txtSulphide.Text != "" ? int.Parse(txtSulphide.Text) : 0;
            no.numHICSOHIC_H2S = txtH2S.Text != "" ? int.Parse(txtH2S.Text) : 0;
            no.numCarbonate = txtCarbonate.Text != "" ? int.Parse(txtCarbonate.Text) : 0;
            no.numExternal_CLSCC = txtExternalCLSCC.Text != "" ? int.Parse(txtExternalCLSCC.Text) : 0;
            no.numPTA = txtPTA.Text != "" ? int.Parse(txtPTA.Text) : 0;
            no.numCLSCC = txtCLSCC.Text != "" ? int.Parse(txtCLSCC.Text) : 0;
            no.numHSC_HF = txtHSCHF.Text != "" ? int.Parse(txtHSCHF.Text) : 0;
            no.numHICSOHIC_HF = txtHF.Text != "" ? int.Parse(txtHF.Text) : 0;
            no.numExternalCorrosion = txtExternalCorrosion.Text != "" ? int.Parse(txtExternalCorrosion.Text) : 0;
            no.numCUI = txtCUI.Text != "" ? int.Parse(txtCUI.Text) : 0;
            no.numExternalCUI = txtExternalCUI.Text != "" ? int.Parse(txtExternalCUI.Text) : 0;
            no.numHTHA = txtHTHA.Text != "" ? int.Parse(txtHTHA.Text) : 0;
            //catalog
            no.effThinning = cbThinning.Text;
            no.effCaustic = cbCaustic.Text;
            no.effAmine = cbAmine.Text;
            no.effSulphide = cbSulphide.Text;
            no.effHICSOHIC_H2S = cbH2S.Text;
            no.effCarbonate = cbCarbonate.Text;
            no.effExternal_CLSCC = cbExternalCLSCC.Text;
            no.effPTA = cbPTA.Text;
            no.effCLSCC = cbCLSCC.Text;
            no.effHSC_HF = cbHSC_HF.Text;
            no.effHICSOHIC_HF = cbHICSOHICHF.Text;
            no.effExternalCorrosion = cbExternalCorrosion.Text;
            no.effCUI = cbCUI.Text;
            no.effExternalCUI = cbExternalCUI.Text;
            no.effHTHA = cbHTHA.Text;

            return no;
        }
    }
}
