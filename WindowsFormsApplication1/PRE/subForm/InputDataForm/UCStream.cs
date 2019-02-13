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
using RBI.BUS.BUSMSSQL;
using RBI.Object;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCStream : UserControl
    {

        string[] itemsExposureAmine = { "High Rich Amine", "Low Lean Amine", "None" };
        string[] itemsAmineSolutionComposition = { "Diethanolamine DEA", "Diglycolamine DGA", "Disopropanolamine DIPA", "Methyldiethanolamine MDEA", "Monoethanolamine MEA", "Sulfinol" };
        public UCStream()
        {
            InitializeComponent();
            addItemsExposureAmine();
            addItemsAmineSolutionComposition();
        }
        public UCStream(int ID)
        {
            InitializeComponent();
            addItemsExposureAmine();
            addItemsAmineSolutionComposition();
            ShowDatatoControl(ID);
        }
        public void ShowDatatoControl(int ID)
        {
            RW_STREAM_BUS SteamBus = new RW_STREAM_BUS();
            RW_STREAM obj = SteamBus.getData(ID);
            for (int i = 0; i < itemsAmineSolutionComposition.Length; i++)
            {
                if (obj.AmineSolution == itemsAmineSolutionComposition[i])
                {
                    cbAmineSolutionComposition.SelectedIndex = i + 1;
                    break;
                }
            }
            chkAqueousPhaseDuringOperation.Checked = Convert.ToBoolean(obj.AqueousOperation);
            chkAqueousPhaseShutdown.Checked = Convert.ToBoolean(obj.AqueousShutdown);
            chkToxicConstituents.Checked = Convert.ToBoolean(obj.ToxicConstituent);
            chkEnvironmentContainsCaustic.Checked = Convert.ToBoolean(obj.Caustic);
            txtChlorideIon.Text = obj.Chloride.ToString();
            txtCO3ConcentrationWater.Text = obj.CO3Concentration.ToString();
            chkPresenceCyanides.Checked = Convert.ToBoolean(obj.Cyanide);
            chkExposedAcidGas.Checked = Convert.ToBoolean(obj.ExposedToGasAmine);
            chkExposedSulphurBearing.Checked = Convert.ToBoolean(obj.ExposedToSulphur);
            for (int i = 0; i < itemsExposureAmine.Length; i++)
            {
                if (obj.ExposureToAmine == itemsExposureAmine[i])
                {
                    cbExposureAmine.SelectedIndex = i + 1;
                    break;
                }
            }
            chkEnviromentContainsH2S.Checked = Convert.ToBoolean(obj.H2S);
            txtH2SContentInWater.Text = obj.H2SInWater.ToString();
            chkProcessContainsHydrogen.Checked = Convert.ToBoolean(obj.Hydrogen);
            chkPresenceHydrofluoricAcid.Checked = Convert.ToBoolean(obj.Hydrofluoric);
            chkChlorine.Checked = Convert.ToBoolean(obj.MaterialExposedToClInt);
            txtNaOHConcentration.Text = obj.NaOHConcentration.ToString();
            txtReleaseFluidPercent.Text = obj.ReleaseFluidPercentToxic.ToString();
            txtpHWater.Text = obj.WaterpH.ToString();
        }
        public RW_STREAM getData(int ID)
        {
            RW_STREAM stream = new RW_STREAM();
            RW_ASSESSMENT_BUS assBus = new RW_ASSESSMENT_BUS();
            stream.ID = ID;
            stream.AmineSolution = cbAmineSolutionComposition.Text;
            stream.AqueousOperation = chkAqueousPhaseDuringOperation.Checked ? 1 : 0;
            stream.AqueousShutdown = chkAqueousPhaseShutdown.Checked ? 1 : 0;
            stream.ToxicConstituent = chkToxicConstituents.Checked ? 1 : 0;
            stream.Caustic = chkEnvironmentContainsCaustic.Checked ? 1 : 0;
            stream.Chloride = txtChlorideIon.Text != "" ? float.Parse(txtChlorideIon.Text) : 0;
            stream.CO3Concentration = txtCO3ConcentrationWater.Text != "" ? float.Parse(txtCO3ConcentrationWater.Text) : 0;
            stream.Cyanide = chkPresenceCyanides.Checked ? 1 : 0;
            stream.ExposedToGasAmine = chkExposedAcidGas.Checked ? 1 : 0;
            stream.ExposedToSulphur = chkExposedSulphurBearing.Checked ? 1 : 0;
            stream.ExposureToAmine = cbExposureAmine.Text;
            //stream.FlammableFluidID
            //stream.FlowRate 
            stream.H2S = chkEnviromentContainsH2S.Checked ? 1 : 0;
            stream.H2SInWater = txtH2SContentInWater.Text != "" ? float.Parse(txtH2SContentInWater.Text) : 0;
            stream.Hydrogen = chkProcessContainsHydrogen.Checked ? 1 : 0;
            //stream.H2SPartialPressure
            stream.Hydrofluoric = chkPresenceHydrofluoricAcid.Checked ? 1 : 0;
            stream.MaterialExposedToClInt = chkChlorine.Checked ? 1 : 0;
            //stream.MaxOperatingPressure
            //stream.MaxOperatingTemperature
            //stream.MinOperatingPressure
            //stream.MinOperatingTemperature
            //stream.CriticalExposureTemperature
            //stream.ModelFluidID
            stream.NaOHConcentration = txtNaOHConcentration.Text != "" ? float.Parse(txtNaOHConcentration.Text) : 0;
            //stream.NonFlameToxicFluidID
            stream.ReleaseFluidPercentToxic = txtReleaseFluidPercent.Text != "" ? float.Parse(txtReleaseFluidPercent.Text) : 0;
            //stream.StoragePhase
            //stream.ToxicFluidID
            stream.WaterpH = txtpHWater.Text != "" ? float.Parse(txtpHWater.Text) : 0;
            //stream.TankFluidName
            //stream.FluidHeight
            //stream.FluidLeaveDikePercent
            //stream.FluidLeaveDikeRemainOnSitePercent
            //stream.FluidGoOffSitePercent
            return stream;
        }
        private void addItemsExposureAmine()
        {
            cbExposureAmine.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsExposureAmine.Length; i++)
            {
                cbExposureAmine.Properties.Items.Add(itemsExposureAmine[i], i, i);
            }
        }
        private void addItemsAmineSolutionComposition()
        {
            cbAmineSolutionComposition.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsAmineSolutionComposition.Length; i++)
            {
                cbAmineSolutionComposition.Properties.Items.Add(itemsAmineSolutionComposition[i], i, i);
            }
        }
       

        #region KeyPress Event Handle
        private void keyPressEvent(TextBox textbox, KeyPressEventArgs ev)
        {
            string a = textbox.Text;
            if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.'))
            {
                ev.Handled = true;
            }
            if (a.Contains('.') && ev.KeyChar == '.')
            {
                ev.Handled = true;
            }
        }

        private void txtNaOHConcentration_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtNaOHConcentration, e);
        }

        private void txtChlorideIon_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtChlorideIon, e);
        }

        private void txtH2SContentInWater_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            keyPressEvent(txtH2SContentInWater, e);
        }

        private void txtReleaseFluidPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            keyPressEvent(txtReleaseFluidPercent, e);
        }

        private void txtCO3ConcentrationWater_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            keyPressEvent(txtCO3ConcentrationWater, e);
        }

        private void txtpHWater_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtpHWater, e);
        }
        #endregion

        private void txtNaOHConcentration_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
            try
            {
                if(float.Parse(txtNaOHConcentration.Text) > 100)
                {
                    MessageBox.Show("Invalid value", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNaOHConcentration.Text = "100";
                }
            }
            catch
            {
                txtNaOHConcentration.Text = "0";
            }
        }

        private void txtReleaseFluidPercent_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
            try
            {
                if (float.Parse(txtReleaseFluidPercent.Text) > 100)
                {
                    MessageBox.Show("Invalid value", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReleaseFluidPercent.Text = "100";
                }
            }
            catch
            {
                txtReleaseFluidPercent.Text = "0";
            }
        }

        private void txtpHWater_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
            try
            {
                if (float.Parse(txtpHWater.Text) > 14)
                {
                    MessageBox.Show("Invalid value", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtpHWater.Text = "14";
                }
            }
            catch
            {
                txtpHWater.Text = "0";
            }
        }

        #region Xu ly su kien khi data thay doi
        private int datachange = 0;
        private int ctrlSpress = 0;
        public event DataUCChangedHanlder DataChanged;
        public event CtrlSHandler CtrlS_Press;
        public int DataChange
        {
            get { return datachange; }
            set
            {
                datachange = value;
                OnDataChanged(new DataUCChangedEventArgs(datachange));
            }
        }
        public int CtrlSPress
        {
            get { return ctrlSpress; }
            set
            {
                ctrlSpress = value;
                OnCtrlS_Press(new CtrlSPressEventArgs(ctrlSpress));
            }
        }
        protected virtual void OnDataChanged(DataUCChangedEventArgs e)
        {
            if (DataChanged != null)
                DataChanged(this, e);
        }
        protected virtual void OnCtrlS_Press(CtrlSPressEventArgs e)
        {
            if (CtrlS_Press != null)
                CtrlS_Press(this, e);
        }
        private void txtPrimaryFluid_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
        }

        private void txtPrimaryFluid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                CtrlSPress++;
            }
        }
        #endregion
    }
}
