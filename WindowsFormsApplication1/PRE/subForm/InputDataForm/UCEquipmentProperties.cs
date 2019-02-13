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
using RBI.BUS.BUSMSSQL_CAL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCEquipmentProperties : UserControl
    {
        public UCEquipmentProperties(int ID, string temUnit, string volumeUnit)
        {
            InitializeComponent();
            addItemsOnlineMonitoring();
            addItemsExternalEnvironment();
            addItemsThermalHistory();
            ShowDatatoControl(ID, temUnit, volumeUnit);
            changeUnit(temUnit, volumeUnit);
        }

        #region change unit
        private void changeUnit(string temUnit, string volumeUnit)
        {
            switch (temUnit)
            {
                case "DEG_C":
                    lblMinReqTem.Text = "⁰C";
                    break;
                case "DEG_F":
                    lblMinReqTem.Text = "⁰F";
                    break;
                case "K":
                    lblMinReqTem.Text = "K";
                    break;
            }
            switch (volumeUnit)
            {
                case "m3":
                    lblVolume.Text = "m³";
                    break;
                case "ft3":
                    lblVolume.Text = "ft³";
                    break;
            }
        }
        #endregion
        #region Process Data

        public void ShowDatatoControl(int ID, string temUnit, string volumeUnit)
        {
            RW_EQUIPMENT_BUS eqBus = new RW_EQUIPMENT_BUS();
            BUS_UNITS convUnit = new BUS_UNITS();
            List<RW_EQUIPMENT> listEq = eqBus.getDataSource();
            foreach (RW_EQUIPMENT e in listEq)
            {
                if (e.ID == ID)
                {
                    chkAministrativeControl.Checked = e.AdminUpsetManagement == 1 ? true : false;
                    chkHighlyEffectiveInspection.Checked = e.HighlyDeadlegInsp == 1 ? true : false;
                    chkDowntimeProtection.Checked = e.DowntimeProtectionUsed == 1 ? true : false;
                    chkHeatTraced.Checked = e.HeatTraced == 1 ? true : false;
                    chkInterfaceSoilWater.Checked = e.InterfaceSoilWater == 1 ? true : false;
                    chkEquipmentOperatingManyYear.Checked = e.YearLowestExpTemp == 1 ? true : false;
                    chkMaterialExposedFluid.Checked = e.MaterialExposedToClExt == 1 ? true : false;
                    chkPresenceSulphideOperation.Checked = e.PresenceSulphidesO2 == 1 ? true : false;
                    chkContainsDeadlegs.Checked = e.ContainsDeadlegs == 1 ? true : false;
                    chkCylicOperation.Checked = e.CyclicOperation == 1 ? true : false;
                    chkSteamedOutPriorWaterFlushing.Checked = e.SteamOutWaterFlush == 1 ? true : false;
                    chkPWHT.Checked = e.PWHT == 1 ? true : false;
                    chkLinerOnlineMonitoring.Checked = e.LinerOnlineMonitoring == 1 ? true : false;
                    chkPresenceSulphideShutdown.Checked = e.PresenceSulphidesO2Shutdown == 1 ? true : false;
                    if (temUnit == "DEG_C") txtMinRequiredTemperature.Text = e.MinReqTemperaturePressurisation.ToString();
                    else if (temUnit == "DEG_F") txtMinRequiredTemperature.Text = (convUnit.CelToFah(e.MinReqTemperaturePressurisation)).ToString(); // mai
                    else txtMinRequiredTemperature.Text = (convUnit.CelToKenvin(e.MinReqTemperaturePressurisation)).ToString(); // mai
                    for (int i = 0; i < itemsExternalEnvironment.Length; i++)
                    {

                        if (itemsExternalEnvironment[i] == e.ExternalEnvironment)
                        {
                            cbExternalEnvironment.SelectedIndex = i + 1;
                        }
                    }
                    for (int j = 0; j < itemsOnlineMonitoring.Length; j++)
                    {
                        if (itemsOnlineMonitoring[j] == e.OnlineMonitoring)
                        {
                            cbOnlineMonitoring.SelectedIndex = j + 1;
                        }
                    }
                    for (int i = 0; i < itemsThermalHistory.Length; i++)
                    {
                        if (itemsThermalHistory[i] == e.ThermalHistory)
                        {
                            cbThermalHistory.SelectedIndex = i + 1;
                        }
                    }
                    if (volumeUnit == "m3") txtEquipmentVolume.Text = e.Volume.ToString();
                    else if (volumeUnit == "ft3") txtEquipmentVolume.Text = (e.Volume/convUnit.ft3).ToString(); // mai
                }
            }
        }
        EQUIPMENT_MASTER_BUS busEquipmentMaster = new EQUIPMENT_MASTER_BUS();
        FACILITY_BUS busFacility = new FACILITY_BUS();
        public RW_EQUIPMENT getData(int ID)
        {
            RW_EQUIPMENT eq = new RW_EQUIPMENT();
            RW_ASSESSMENT_BUS assBus = new RW_ASSESSMENT_BUS();
            eq.ID = ID;
            eq.AdminUpsetManagement = chkAministrativeControl.Checked ? 1 : 0;
            eq.ContainsDeadlegs = chkContainsDeadlegs.Checked ? 1 : 0;
            eq.CyclicOperation = chkCylicOperation.Checked ? 1 : 0;
            eq.HighlyDeadlegInsp = chkHighlyEffectiveInspection.Checked ? 1 : 0;
            eq.DowntimeProtectionUsed = chkDowntimeProtection.Checked ? 1 : 0;
            eq.ExternalEnvironment = cbExternalEnvironment.Text;
            eq.HeatTraced = chkHeatTraced.Checked ? 1 : 0;
            eq.InterfaceSoilWater = chkInterfaceSoilWater.Checked ? 1 : 0;
            eq.LinerOnlineMonitoring = chkLinerOnlineMonitoring.Checked ? 1 : 0;
            eq.MaterialExposedToClExt = chkMaterialExposedFluid.Checked ? 1 : 0;
            eq.MinReqTemperaturePressurisation = txtMinRequiredTemperature.Text != "" ? float.Parse(txtMinRequiredTemperature.Text) : 0;
            eq.OnlineMonitoring = cbOnlineMonitoring.Text;
            eq.PresenceSulphidesO2 = chkPresenceSulphideOperation.Checked ? 1 : 0;
            eq.PresenceSulphidesO2Shutdown = chkPresenceSulphideShutdown.Checked ? 1 : 0;
            eq.PressurisationControlled = chkPressurisationControlled.Checked ? 1 : 0;
            eq.PWHT = chkPWHT.Checked ? 1 : 0;
            eq.SteamOutWaterFlush = chkSteamedOutPriorWaterFlushing.Checked ? 1 : 0;
            eq.ManagementFactor = (float)numSystemManagementFactor.Value;
            eq.ThermalHistory = cbThermalHistory.Text;
            eq.YearLowestExpTemp = chkEquipmentOperatingManyYear.Checked ? 1 : 0;
            eq.Volume = txtEquipmentVolume.Text != "" ? float.Parse(txtEquipmentVolume.Text) : 0;
            //eq.CommissionDate = 
            return eq;
        }
        #endregion

        public RW_EQUIPMENT getData(int ID, string temUnit, string volUnit)
        {
            RW_EQUIPMENT eq = new RW_EQUIPMENT();
            RW_ASSESSMENT_BUS assBus = new RW_ASSESSMENT_BUS();
            BUS_UNITS convUnit = new BUS_UNITS();
            eq.ID = ID;
            eq.AdminUpsetManagement = chkAministrativeControl.Checked ? 1 : 0;
            eq.ContainsDeadlegs = chkContainsDeadlegs.Checked ? 1 : 0;
            eq.CyclicOperation = chkCylicOperation.Checked ? 1 : 0;
            eq.HighlyDeadlegInsp = chkHighlyEffectiveInspection.Checked ? 1 : 0;
            eq.DowntimeProtectionUsed = chkDowntimeProtection.Checked ? 1 : 0;
            eq.ExternalEnvironment = cbExternalEnvironment.Text;
            eq.HeatTraced = chkHeatTraced.Checked ? 1 : 0;
            eq.InterfaceSoilWater = chkInterfaceSoilWater.Checked ? 1 : 0;
            eq.LinerOnlineMonitoring = chkLinerOnlineMonitoring.Checked ? 1 : 0;
            eq.MaterialExposedToClExt = chkMaterialExposedFluid.Checked ? 1 : 0;
            double minReqTem = 0;
            if (temUnit == "DEG_C") minReqTem = txtMinRequiredTemperature.Text != "" ? double.Parse(txtMinRequiredTemperature.Text) : 0;
            else if (temUnit == "DEG_F") minReqTem = txtMinRequiredTemperature.Text != "" ? convUnit.FahToCel(double.Parse(txtMinRequiredTemperature.Text)) : 0; // mai
            else minReqTem = txtMinRequiredTemperature.Text != "" ? convUnit.KenvinToCel(double.Parse(txtMinRequiredTemperature.Text)) : 0; // mai
            eq.MinReqTemperaturePressurisation = (float)minReqTem;
            eq.OnlineMonitoring = cbOnlineMonitoring.Text;
            eq.PresenceSulphidesO2 = chkPresenceSulphideOperation.Checked ? 1 : 0;
            eq.PresenceSulphidesO2Shutdown = chkPresenceSulphideShutdown.Checked ? 1 : 0;
            eq.PressurisationControlled = chkPressurisationControlled.Checked ? 1 : 0;
            eq.PWHT = chkPWHT.Checked ? 1 : 0;
            eq.SteamOutWaterFlush = chkSteamedOutPriorWaterFlushing.Checked ? 1 : 0;
            int equipmentID = assBus.getEquipmentID(ID);
            float FMS = busFacility.getFMS(busEquipmentMaster.getFacilityID(equipmentID));
            eq.ManagementFactor = FMS;
            eq.ThermalHistory = cbThermalHistory.Text;
            eq.YearLowestExpTemp = chkEquipmentOperatingManyYear.Checked ? 1 : 0;
            double equipVolume = 0;
            if (volUnit == "m3") equipVolume = txtEquipmentVolume.Text != "" ? float.Parse(txtEquipmentVolume.Text) : 0;
            else equipVolume = txtMinRequiredTemperature.Text != "" ? (float.Parse(txtEquipmentVolume.Text)*convUnit.ft3) : 0; // mai
            eq.Volume = (float)equipVolume;
            //eq.CommissionDate = 
            return eq;
        }

        #region Xu ly su kien
        public event DataUCChangedHanlder DataChanged;
        public event CtrlSHandler CtrlS_Press;
        public int CtrlSPress
        {
            get { return ctrlSpress; }
            set
            {
                ctrlSpress = value;
                OnCtrlS_Press(new CtrlSPressEventArgs(ctrlSpress));
            }
        }
        public int DataChange
        {
            get { return datachange; }
            set
            {
                if (datachange == value) return;
                datachange = value;
                OnDataChanged(new DataUCChangedEventArgs(datachange));
            }
        }
        protected virtual void OnCtrlS_Press(CtrlSPressEventArgs e)
        {
            if (CtrlS_Press != null)
                CtrlS_Press(this, e);
        }
        protected virtual void OnDataChanged(DataUCChangedEventArgs e)
        {
            if (DataChanged != null)
                DataChanged(this, e);
        }
        private void txtMinRequiredTemperature_TextChanged(object sender, EventArgs e)
        {
            DataChange += 1;
        }
        
        private void chkAministrativeControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                CtrlSPress++;
            }
        }
        private void txtMinRequiredTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string a = txtMinRequiredTemperature.Text;
            //if(!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
            //if(a.Contains("-") && e.KeyChar == '-')
            //{
            //    e.Handled = true;
            //}
            string a = txtMinRequiredTemperature.Text;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((a.StartsWith("-") && e.KeyChar == '-') || (a.Contains(".") && e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void txtEquipmentVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = txtEquipmentVolume.Text;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (a.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Add data to combobox
        private void addItemsOnlineMonitoring()
        {
            cbOnlineMonitoring.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsOnlineMonitoring.Length; i++)
            {
                cbOnlineMonitoring.Properties.Items.Add(itemsOnlineMonitoring[i], i, i);
            }
        }
        private void addItemsExternalEnvironment()
        {
            cbExternalEnvironment.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsExternalEnvironment.Length; i++)
            {
                cbExternalEnvironment.Properties.Items.Add(itemsExternalEnvironment[i], i, i);
            }
        }
        private void addItemsThermalHistory()
        {
            cbThermalHistory.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsThermalHistory.Length; i++)
            {
                cbThermalHistory.Properties.Items.Add(itemsThermalHistory[i], i, i);
            }
        }
        #endregion

        #region variable
        string[] itemsOnlineMonitoring = {  "Amine high velocity corrosion - Corrosion coupons",
                                            "Amine high velocity corrosion - Electrical resistance probes",
                                            "Amine high velocity corrosion - Key process variable",
                                            "Amine low velocity corrosion - Corrosion coupons",
                                            "Amine low velocity corrosion - Electrical resistance probes",
                                            "Amine low velocity corrosion - Key process variable",
                                            "HCI corrosion - Corrosion coupons",
                                            "HCI corrosion - Electrical resistance probes",
                                            "HCI corrosion - Key process variable",
                                            "HCI corrosion - Key process variable & Electrical resistance probes",
                                            "HF corrosion - Corrosion coupons",
                                            "HF corrosion - Electrical resistance probes",
                                            "HF corrosion - Key process variable",
                                            "High temperature H2S/H2 corrosion - Corrosion coupons",
                                            "High temperature H2S/H2 corrosion - Electrical resistance probes",
                                            "High temperature H2S/H2 corrosion - Key process parameters",
                                            "High temperature Sulfidic / Naphthenic acid corrosion - Corrosion coupons",
                                            "High temperature Sulfidic / Naphthenic acid corrosion - Electrical resistance probes",
                                            "High temperature Sulfidic / Naphthenic acid corrosion - Key process variable",
                                            "No online monitoring",
                                            "Other corrosion - Corrosion coupons",
                                            "Other corrosion - Electrical resistance probes",
                                            "Other corrosion - Key process variable",
                                            "Sour water high velocity corrosion - Corrosion coupons",
                                            "Sour water high velocity corrosion - Electrical resistance probes",
                                            "Sour water high velocity corrosion - Key process variable",
                                            "Sour water low velocity corrosion - Corrosion coupons",
                                            "Sour water low velocity corrosion - Electrical resistance probes",
                                            "Sour water low velocity corrosion - Key process variable",
                                            "Sulfuric acid (H2S/H2) corrosion high velocity - Corrosion coupons",
                                            "Sulfuric acid (H2S/H2) corrosion high velocity - Electrical resistance probes",
                                            "Sulfuric acid (H2S/H2) corrosion high velocity - Key process parameters",
                                            "Sulfuric acid (H2S/H2) corrosion high velocity - Key process parameters & electrical resistance probes",
                                            "Sulfuric acid (H2S/H2) corrosion low velocity - Corrosion coupons",
                                            "Sulfuric acid (H2S/H2) corrosion low velocity - Electrical resistance probes",
                                            "Sulfuric acid (H2S/H2) corrosion low velocity - Key process parameters"
                                            };
        string[] itemsExternalEnvironment = { "Arid/dry", "Marine", "Severe", "Temperate" };
        string[] itemsThermalHistory = { "None", "Solution Annealed", "Stabilised After Welding", "Stabilised Before Welding" };
        private int datachange = 0;
        private int ctrlSpress = 0;
        #endregion

        
    }
}
