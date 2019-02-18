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
using RBI.BUS.BUSMSSQL_CAL;
using RBI.Object;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCMaterialTank : UserControl
    {
        string[] itemsSulfurContent = { "High > 0.01%", "Low 0.002 - 0.01%", "Ultra Low < 0.002%" };
        string[] itemsHeatTreatment = {"Annealed", "None", "Normalised Temper", "Quench Temper", "Stress Relieved", "Sub Critical PWHT" };
        string[] itemsPTAMterial = {"321 Stainless Steel",
                                "347 Stainless Steel, Alloy 20, Alloy 625, All austenitic weld overlay",
                                "Regular 300 series Stainless Steels and Alloys 600 and 800",
                                "H Grade 300 series Stainless Steels",
                                "L Grade 300 series Stainless Steels",
                                "Not Applicable"};
 
        public UCMaterialTank(int ID, string temUnit, string pressureUnit, string stressUnit, string thicknessUnit, string corrosionUnit)
        {
            InitializeComponent();
            txtMaterial.Enabled = false;
            addSulfurContent();
            addHeatTreatment();
            addPTAMterial();
            ShowDataToControl(ID, temUnit, pressureUnit, stressUnit, thicknessUnit, corrosionUnit);
            lblAllowableStress.Text = stressUnit;
            lblDesignPressure.Text = pressureUnit;
            lblCorrosion.Text = corrosionUnit;
            lblMaxDesignTem.Text = lblMinDesignTem.Text = lblRefTem.Text = temUnit;
            lblBritFracGovThickness.Text = thicknessUnit;
        }
        
        public void ShowDataToControl(int ID, string temUnit, string pressureUnit, string stressUnit, string thicknessUnit, string corrosionUnit)
        {
            RW_MATERIAL_BUS BUS = new RW_MATERIAL_BUS();
            RW_MATERIAL obj = BUS.getData(ID);
            RW_INPUT_CA_TANK_BUS busTank = new RW_INPUT_CA_TANK_BUS();
            BUS_UNITS convUnit = new BUS_UNITS();
            float tank = busTank.getProductionCost(ID);
            switch(temUnit)
            {
                case "DEG_C":
                    txtMaxDesignTemperature.Text = obj.DesignTemperature.ToString();
                    txtMinDesignTemperature.Text = obj.MinDesignTemperature.ToString();
                    txtReferenceTemperature.Text = obj.ReferenceTemperature.ToString();
                    break;
                case "DEG_F":
                    txtMaxDesignTemperature.Text = (convUnit.CelToFah(obj.DesignTemperature)).ToString();
                    txtMinDesignTemperature.Text = (convUnit.CelToFah(obj.MinDesignTemperature)).ToString();
                    txtReferenceTemperature.Text = (convUnit.CelToFah(obj.ReferenceTemperature)).ToString();
                    break;
                case "K":
                    txtMaxDesignTemperature.Text = (convUnit.CelToKenvin(obj.DesignTemperature)).ToString();
                    txtMinDesignTemperature.Text = (convUnit.CelToKenvin(obj.MinDesignTemperature)).ToString();
                    txtReferenceTemperature.Text = (convUnit.CelToKenvin(obj.ReferenceTemperature)).ToString();
                    break;
            }

            switch(pressureUnit)
            {
                case "psi":
                    txtDesignPressure.Text = obj.DesignPressure.ToString();
                    break;
                case "KSI":
                    txtDesignPressure.Text = (obj.DesignPressure / convUnit.ksi).ToString();
                    break;
                case "bar":
                    txtDesignPressure.Text = (obj.DesignPressure / convUnit.bar).ToString();
                    break;
                case "MPa":
                    txtDesignPressure.Text = (obj.DesignPressure / convUnit.MPa).ToString();
                    break;
                case "N/m2":
                    txtDesignPressure.Text = (obj.DesignPressure / convUnit.NpM2).ToString();
                    break;
                case "N/cm2":
                    txtDesignPressure.Text = (obj.DesignPressure / convUnit.NpCM2).ToString();
                    break;
            }

            switch(thicknessUnit)
            {
                case "mm":
                    txtBrittleFracture.Text = obj.BrittleFractureThickness.ToString();
                    break;
                case "in":
                    txtBrittleFracture.Text = (obj.BrittleFractureThickness / convUnit.inch).ToString();
                    break;
                case "m":
                    txtBrittleFracture.Text = (obj.BrittleFractureThickness / convUnit.meter).ToString();
                    break;
            }

            switch (corrosionUnit)
            {
                case "mm":
                    txtCorrosionAllowance.Text = obj.CorrosionAllowance.ToString();
                    break;
                case "mil":
                    txtCorrosionAllowance.Text = (obj.CorrosionAllowance / convUnit.mil).ToString();
                    break;
            }

            switch (stressUnit)
            {
                case "psi":
                    txtAllowableStress.Text = obj.AllowableStress.ToString();
                    break;
                case "KSI":
                    txtAllowableStress.Text = (obj.AllowableStress / convUnit.ksi).ToString();
                    break;
                case "bar":
                    txtAllowableStress.Text = (obj.AllowableStress / convUnit.bar).ToString();
                    break;
                case "MPa":
                    txtAllowableStress.Text = (obj.AllowableStress / convUnit.MPa).ToString();
                    break;
                case "N/m2":
                    txtAllowableStress.Text = (obj.AllowableStress / convUnit.NpM2).ToString();
                    break;
                case "N/cm2":
                    txtAllowableStress.Text = (obj.AllowableStress / convUnit.NpCM2).ToString();
                    break;
            }
            txtMaterial.Text = obj.MaterialName;                    
            for (int i = 0; i < itemsSulfurContent.Length; i++)
            {
                if (obj.SulfurContent == itemsSulfurContent[i])
                {
                    cbSulfurContent.SelectedIndex = i + 1;
                    break;
                }
            }
            for (int i = 0; i < itemsHeatTreatment.Length; i++)
            {
                if (obj.HeatTreatment == itemsHeatTreatment[i])
                {
                    cbHeatTreatment.SelectedIndex = i + 1;
                    break;
                }
            }
            
            for (int i = 0; i < itemsPTAMterial.Length; i++)
            {
                if (obj.PTAMaterialCode == itemsPTAMterial[i])
                {
                    cbPTAMaterialGrade.SelectedIndex = i + 1;
                    break;
                }
            }
            chkIsPTASeverity.Checked = Convert.ToBoolean(obj.IsPTA);
            chkAusteniticSteel.Checked = Convert.ToBoolean(obj.Austenitic);
            chkCarbonLowAlloySteel.Checked = Convert.ToBoolean(obj.CarbonLowAlloy);
            chkNickelAlloy.Checked = Convert.ToBoolean(obj.NickelBased);
            chkChromium.Checked = Convert.ToBoolean(obj.ChromeMoreEqual12);
            txtMaterialCostFactor.Text = obj.CostFactor.ToString();
            txtProductionCost.Text = tank.ToString();
        }

        public RW_MATERIAL getData(int ID, string temUnit, string pressureUnit, string stressUnit, string thicknessUnit, string corrosionUnit)
        {
            RW_MATERIAL ma = new RW_MATERIAL();
            BUS_UNITS convUnit = new BUS_UNITS();
            ma.ID = ID;
            ma.MaterialName = txtMaterial.Text;
            switch (temUnit)
            {
                case "DEG_C":
                    ma.DesignTemperature = txtMaxDesignTemperature.Text != "" ? float.Parse(txtMaxDesignTemperature.Text) : 0;
                    ma.MinDesignTemperature = txtMinDesignTemperature.Text != "" ? float.Parse(txtMinDesignTemperature.Text) : 0;
                    ma.ReferenceTemperature = txtReferenceTemperature.Text != "" ? float.Parse(txtReferenceTemperature.Text) : 0;
                    break;
                case "DEG_F":
                    ma.DesignTemperature = txtMaxDesignTemperature.Text != "" ? (float)convUnit.FahToCel(float.Parse(txtMaxDesignTemperature.Text)) : 0;
                    ma.MinDesignTemperature = txtMinDesignTemperature.Text != "" ? (float)convUnit.FahToCel(float.Parse(txtMinDesignTemperature.Text)) : 0;
                    ma.ReferenceTemperature = txtReferenceTemperature.Text != "" ? (float)convUnit.FahToCel(float.Parse(txtReferenceTemperature.Text)) : 0;
                    break;
                case "K":
                    ma.DesignTemperature = txtMaxDesignTemperature.Text != "" ? (float)convUnit.KenvinToCel(float.Parse(txtMaxDesignTemperature.Text)) : 0;
                    ma.MinDesignTemperature = txtMinDesignTemperature.Text != "" ? (float)convUnit.KenvinToCel(float.Parse(txtMinDesignTemperature.Text)) : 0;
                    ma.ReferenceTemperature = txtReferenceTemperature.Text != "" ? (float)convUnit.KenvinToCel(float.Parse(txtReferenceTemperature.Text)) : 0;
                    break;
            }

            switch (pressureUnit)
            {
                case "psi":
                    ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) : 0;
                    break;
                case "KSI":
                    ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) * (float)convUnit.ksi : 0;
                    break;
                case "bar":
                    ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) * (float)convUnit.bar : 0;
                    break;
                case "MPa":
                    ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) * (float)convUnit.MPa : 0;
                    break;
                case "N/m2":
                    ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) * (float)convUnit.NpM2 : 0;
                    break;
                case "N/cm2":
                    ma.DesignPressure = txtDesignPressure.Text != "" ? float.Parse(txtDesignPressure.Text) * (float)convUnit.NpCM2 : 0;
                    break;
            }

            switch (stressUnit)
            {
                case "psi":
                    ma.AllowableStress = txtAllowableStress.Text != "" ? float.Parse(txtAllowableStress.Text) : 0;
                    break;
                case "KSI":
                    ma.AllowableStress = txtAllowableStress.Text != "" ? float.Parse(txtAllowableStress.Text) * (float)convUnit.ksi : 0;
                    break;
                case "bar":
                    ma.AllowableStress = txtAllowableStress.Text != "" ? float.Parse(txtAllowableStress.Text) * (float)convUnit.bar : 0;
                    break;
                case "MPa":
                    ma.AllowableStress = txtAllowableStress.Text != "" ? float.Parse(txtAllowableStress.Text) * (float)convUnit.MPa : 0;
                    break;
                case "N/m2":
                    ma.AllowableStress = txtAllowableStress.Text != "" ? float.Parse(txtAllowableStress.Text) * (float)convUnit.NpM2 : 0;
                    break;
                case "N/cm2":
                    ma.AllowableStress = txtAllowableStress.Text != "" ? float.Parse(txtAllowableStress.Text) * (float)convUnit.NpCM2 : 0;
                    break;
            }

            switch (corrosionUnit)
            {
                case "mm":
                    ma.CorrosionAllowance = txtCorrosionAllowance.Text != "" ? float.Parse(txtCorrosionAllowance.Text) : 0;
                    break;
                case "mil":
                    ma.CorrosionAllowance = txtCorrosionAllowance.Text != "" ? float.Parse(txtCorrosionAllowance.Text) * (float)convUnit.mil : 0;
                    break;
            }

            switch (thicknessUnit)
            {
                case "mm":
                    ma.BrittleFractureThickness = txtBrittleFracture.Text != "" ? float.Parse(txtBrittleFracture.Text) : 0;
                    break;
                case "in":
                    ma.BrittleFractureThickness = txtBrittleFracture.Text != "" ? float.Parse(txtBrittleFracture.Text) * (float)convUnit.inch : 0;
                    break;
                case "m":
                    ma.BrittleFractureThickness = txtBrittleFracture.Text != "" ? float.Parse(txtBrittleFracture.Text) * (float)convUnit.meter : 0;
                    break;

            }
            ma.SulfurContent = cbSulfurContent.Text;
            ma.HeatTreatment = cbHeatTreatment.Text;
            ma.PTAMaterialCode = cbPTAMaterialGrade.Text;
            ma.IsPTA = chkIsPTASeverity.Checked ? 1 : 0;
            ma.Austenitic = chkAusteniticSteel.Checked ? 1 : 0;
            ma.CarbonLowAlloy = chkCarbonLowAlloySteel.Checked ? 1 : 0;
            ma.NickelBased = chkNickelAlloy.Checked ? 1 : 0;
            ma.ChromeMoreEqual12 = chkChromium.Checked ? 1 : 0;
            ma.CostFactor = txtMaterialCostFactor.Text != "" ? float.Parse(txtMaterialCostFactor.Text) : 0;
            return ma;
        }
        public RW_INPUT_CA_LEVEL_1 getDataForCA(int ID)
        {
            RW_INPUT_CA_LEVEL_1 ca = new RW_INPUT_CA_LEVEL_1();
            ca.ID = ID;
            ca.Material_Cost = txtMaterialCostFactor.Text != "" ? float.Parse(txtMaterialCostFactor.Text) : 0;
            return ca;
        }
        public RW_INPUT_CA_TANK getDataforTank(int ID)
        {
            RW_INPUT_CA_TANK ca = new RW_INPUT_CA_TANK();
            ca.ID = ID;
            ca.ProductionCost = txtProductionCost.Text != "" ? float.Parse(txtProductionCost.Text) : 0;
            return ca;
        }
        private void chkIsPTASeverity_CheckedChanged(object sender, EventArgs e)// kiem tra lai
        {

        }
        #region Add Data to ComboBox
        private void addSulfurContent()
        {
            cbSulfurContent.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsSulfurContent.Length; i++)
            {
                cbSulfurContent.Properties.Items.Add(itemsSulfurContent[i], i, i);
            }
        }
        private void addHeatTreatment()
        {
            cbHeatTreatment.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsHeatTreatment.Length; i++)
            {
                cbHeatTreatment.Properties.Items.Add(itemsHeatTreatment[i], i, i);
            }
        }
        private void addPTAMterial()
        {
            cbPTAMaterialGrade.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsPTAMterial.Length; i++)
            {
                cbPTAMaterialGrade.Properties.Items.Add(itemsPTAMterial[i], i, i);
            }
        }
        #endregion

        #region Key Press Event
        private void keyPressEvent(TextBox textbox, KeyPressEventArgs ev, bool textTemper)
        {
            string a = textbox.Text;
            if (!textTemper)
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.'))
                {
                    ev.Handled = true;
                }
                if (a.Contains(".") && ev.KeyChar == '.')
                {
                    ev.Handled = true;
                }
            }
            else
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.') && (ev.KeyChar != '-'))
                {
                    ev.Handled = true;
                }
                if ((a.StartsWith("-") && ev.KeyChar == '-') || (a.Contains(".") && ev.KeyChar == '.'))
                {
                    ev.Handled = true;
                }
            }
        }
        private void txtMaxDesignTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMaxDesignTemperature, e, true);
        }

        private void txtDesignPressure_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtDesignPressure, e, false);
        }

        private void txtAllowableStress_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtAllowableStress, e, false);
        }

        private void txtCorrosionAllowance_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCorrosionAllowance, e, false);
        }

        private void txtMinDesignTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMinDesignTemperature, e, true);
        }

        private void txtReferenceTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtReferenceTemperature, e, true);
        }

        private void txtBrittleFracture_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtBrittleFracture, e, false);
        }

        private void txtMaterialCostFactor_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMaterialCostFactor, e, false);
        }
        private void txtProductionCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMaterialCostFactor, e, false);
        }
        #endregion

        #region Xu ly su kien khi Data thay doi
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
        
        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
            if(sender is CheckBox)
            {
                CheckBox chk = sender as CheckBox;
                switch(chk.Name)
                {
                    case "chkIsPTASeverity":
                        cbPTAMaterialGrade.Enabled = chk.Checked ? true : false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void txtMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                CtrlSPress++;
            }
        }
        #endregion

        

    }
}
