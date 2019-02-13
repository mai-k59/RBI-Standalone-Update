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
    public partial class UCStreamTank : UserControl
    {
        string[] itemsExposureAmine = { "High Rich Amine", "Low Lean Amine", "None" };
        string[] itemsAmineSolutionComposition = { "Diethanolamine DEA", "Diglycolamine DGA", "Disopropanolamine DIPA", "Methyldiethanolamine MDEA", "Monoethanolamine MEA", "Sulfinol" };
        string[] itemsTankFluid = { "Gasoline", "Light Diesel Oil", "Heavy Diesel Oil", "Fuel Oil", "Crude Oil", "Heavy Fuel Oil", "Heavy Crude Oil" };
        public UCStreamTank()
        {
            InitializeComponent();
            addItemsExposureAmine();
            addItemsAmineSolutionComposition();
            addItemsTankFluid();
        }
        public UCStreamTank(int ID)
        {
            InitializeComponent();
            addItemsExposureAmine();
            addItemsAmineSolutionComposition();
            addItemsTankFluid();
            ShowDataToControl(ID);
        }
        private void ShowDataToControl(int ID)
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
            txtH2SContent.Text = obj.H2SInWater.ToString();
            chkProcessContainsHydrogen.Checked = Convert.ToBoolean(obj.Hydrogen);
            chkPresenceHydrofluoricAcid.Checked = Convert.ToBoolean(obj.Hydrofluoric);
            chkChlorine.Checked = Convert.ToBoolean(obj.MaterialExposedToClInt);
            txtNaOHConcentration.Text = obj.NaOHConcentration.ToString();
            txtReleaseFluidPercent.Text = obj.ReleaseFluidPercentToxic.ToString();
            txtpHWater.Text = obj.WaterpH.ToString();
            //tank
            for (int i = 0; i < itemsTankFluid.Length; i++)
            {
                if (obj.TankFluidName == itemsTankFluid[i])
                {
                    cbFluidTank.SelectedIndex = i + 1;
                    break;
                }
            }
            txtFluidHeight.Text = obj.FluidHeight.ToString();
            txtPercentageLeavingDike.Text = obj.FluidLeaveDikePercent.ToString();
            txtPercentageLeavingRemainsOnSite.Text = obj.FluidLeaveDikeRemainOnSitePercent.ToString();
            txtPercentageFluidGoingOffsite.Text = obj.FluidGoOffSitePercent.ToString();
        }
        RW_STREAM stream = new RW_STREAM();
        public RW_STREAM getData(int ID)
        {
            stream.ID = ID;
            stream.AmineSolution = cbAmineSolutionComposition.Text;
            stream.AqueousOperation = chkAqueousPhaseDuringOperation.Checked ? 1 : 0;
            stream.AqueousShutdown = chkAqueousPhaseShutdown.Checked ? 1 : 0;
            stream.Caustic = chkEnvironmentContainsCaustic.Checked ? 1 : 0;
            stream.Chloride = txtChlorideIon.Text != "" ? float.Parse(txtChlorideIon.Text) : 0;
            stream.CO3Concentration = txtCO3ConcentrationWater.Text != "" ? float.Parse(txtCO3ConcentrationWater.Text) : 0;
            stream.H2SInWater = txtH2SContent.Text != "" ? float.Parse(txtH2SContent.Text) : 0;
            stream.NaOHConcentration = txtNaOHConcentration.Text != "" ? float.Parse(txtNaOHConcentration.Text) : 0;
            stream.ReleaseFluidPercentToxic = txtReleaseFluidPercent.Text != "" ? float.Parse(txtReleaseFluidPercent.Text) : 0;
            stream.WaterpH = txtpHWater.Text != "" ? float.Parse(txtpHWater.Text) : 0;
            stream.Cyanide = chkPresenceCyanides.Checked ? 1 : 0;
            stream.ExposedToGasAmine = chkExposedAcidGas.Checked ? 1 : 0;
            stream.ExposedToSulphur = chkExposedSulphurBearing.Checked ? 1 : 0;
            stream.ExposureToAmine = cbExposureAmine.Text;
            stream.H2S = chkEnviromentContainsH2S.Checked ? 1 : 0;
            stream.Hydrogen = chkPresenceHydrofluoricAcid.Checked ? 1 : 0;
            stream.MaterialExposedToClInt = chkChlorine.Checked ? 1 : 0;
            //if(tankbottom)
            stream.FluidHeight = txtFluidHeight.Text != "" ? float.Parse(txtFluidHeight.Text) : 0;
            stream.FluidLeaveDikePercent = txtPercentageLeavingDike.Text != "" ? float.Parse(txtPercentageLeavingDike.Text) : 0;
            stream.FluidLeaveDikeRemainOnSitePercent = txtPercentageLeavingRemainsOnSite.Text != "" ? float.Parse(txtPercentageLeavingRemainsOnSite.Text) : 0;
            stream.FluidGoOffSitePercent = txtPercentageFluidGoingOffsite.Text != "" ? float.Parse(txtPercentageFluidGoingOffsite.Text) : 0;
            return stream;
        }
        //public RW_STREAM getData2()
        //{
        //    UCOperatingCondition ucOperating = new UCOperatingCondition();
        //    RW_STREAM temp = new RW_STREAM();
        //    temp = ucOperating.getData();
        //    return temp;
        //}
        public RW_INPUT_CA_TANK getDataforTank(int ID)
        {
            RW_INPUT_CA_TANK tank = new RW_INPUT_CA_TANK();
            tank.ID = ID;
            tank.P_lvdike = txtPercentageLeavingDike.Text != "" ? float.Parse(txtPercentageLeavingDike.Text) : 0;
            tank.P_offsite = txtPercentageFluidGoingOffsite.Text != "" ? float.Parse(txtPercentageFluidGoingOffsite.Text) : 0;
            tank.P_onsite = txtPercentageLeavingRemainsOnSite.Text != "" ? float.Parse(txtPercentageLeavingRemainsOnSite.Text) : 0;
            tank.FLUID_HEIGHT = txtFluidHeight.Text != "" ? float.Parse(txtFluidHeight.Text) : 0;
            tank.TANK_FLUID = cbFluidTank.Text;
            if (tank.TANK_FLUID == "Gasoline")
                tank.API_FLUID = "C6-C8";
            else if (tank.TANK_FLUID == "Light Diesel Oil")
                tank.API_FLUID = "C9-C12";
            else if (tank.TANK_FLUID == "Heavy Diesel Oil")
                tank.API_FLUID = "C13-C16";
            else if (tank.TANK_FLUID == "Fuel Oil" || tank.TANK_FLUID == "Crude Oil")
                tank.API_FLUID = "C17-C25";
            else
                tank.API_FLUID = "C25+";
            return tank;
        }
        public RW_INPUT_CA_TANK getDataCATank()
        {
            RW_INPUT_CA_TANK ca = new RW_INPUT_CA_TANK();
            ca.ID = 1;
            ca.TANK_FLUID = cbFluidTank.Text;
            ca.FLUID_HEIGHT = txtFluidHeight.Text != "" ? float.Parse(txtFluidHeight.Text) : 0;
            ca.P_lvdike = txtPercentageLeavingDike.Text != "" ? float.Parse(txtPercentageLeavingDike.Text) : 0;
            ca.P_onsite = txtPercentageLeavingRemainsOnSite.Text != "" ? float.Parse(txtPercentageLeavingRemainsOnSite.Text) : 0;
            ca.P_offsite = txtPercentageFluidGoingOffsite.Text != "" ? float.Parse(txtPercentageFluidGoingOffsite.Text) : 0;
            return ca;
        }
        private void addItemsTankFluid()
        {
            cbFluidTank.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsTankFluid.Length; i++)
            {
                cbFluidTank.Properties.Items.Add(itemsTankFluid[i], i, i);
            }
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
            if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.') && (ev.KeyChar != '-'))
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

        private void txtH2SContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtH2SContent, e);
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
        private void txtFluidHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtFluidHeight, e);
        }
        private void txtPercentageLeavingRemainsOnSite_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtPercentageLeavingRemainsOnSite, e);
        }
        private void txtPercentageLeavingDike_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtPercentageLeavingDike, e);
        }
        private void txtPercentageFluidGoingOffsite_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtPercentageFluidGoingOffsite, e);
        }
        #endregion

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
        private void cbFluidTank_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
        }

        private void cbFluidTank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                CtrlSPress++;
            }
        }
        #endregion
    }
}
