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
    public partial class UCOperatingCondition : UserControl
    {
        public UCOperatingCondition(int ID, string temperatureUnit, string pressureUnit, string flowRateUnit)
        {
            InitializeComponent();
            ShowDataToForm(ID, temperatureUnit, pressureUnit, flowRateUnit);
            changeUnit(temperatureUnit, pressureUnit, flowRateUnit);
        }

        #region change unit
        private void changeUnit(string temperatureUnit, string pressureUnit, string flowRateUnit)
        {
            switch (temperatureUnit)
            {
                case "DEG_C":
                    lblCritExpoTem.Text = lblmaxOpTem.Text = lblMinOpTem.Text = "⁰C";
                    lbOp1.Text = "% Operating at -12 ⁰C to -8 ⁰C";
                    lbOp2.Text = "% Operating at -8 ⁰C to 6 ⁰C";
                    lbOp3.Text = "% Operating at 6 ⁰C to 32 ⁰C";
                    lbOp4.Text = "% Operating at 32 ⁰C to 71⁰C";
                    lbOp5.Text = "% Operating at 71 ⁰C to 107 ⁰C";
                    lbOp6.Text = "% Operating at 107 ⁰C to 121 ⁰C";
                    lbOp7.Text = "% Operating at 121 ⁰C to 135 ⁰C";
                    lbOp8.Text = "% Operating at 135 ⁰C to 162 ⁰C";
                    lbOp9.Text = "% Operating at 162 ⁰C to 176 ⁰C";
                    lbOp10.Text = "% Operating at 176 ⁰C or above";
                    break;
                case "DEG_F":
                    lblCritExpoTem.Text = lblmaxOpTem.Text = lblMinOpTem.Text = "⁰F";
                    lbOp1.Text = "% Operating at 10 ⁰F to 18 ⁰F";
                    lbOp2.Text = "% Operating at 18 ⁰F to 43 ⁰F";
                    lbOp3.Text = "% Operating at 43 ⁰F to 90 ⁰F";
                    lbOp4.Text = "% Operating at 90 ⁰F to 160 ⁰F";
                    lbOp5.Text = "% Operating at 160 ⁰F to 225 ⁰F";
                    lbOp6.Text = "% Operating at 225 ⁰F to 250 ⁰F";
                    lbOp7.Text = "% Operating at 250 ⁰F to 275 ⁰F";
                    lbOp8.Text = "% Operating at 275 ⁰F to 325 ⁰F";
                    lbOp9.Text = "% Operating at 325 ⁰F to 350 ⁰F";
                    lbOp10.Text = "% Operating at 350 ⁰F or above";
                    break;
                case "K":
                    lblCritExpoTem.Text = lblmaxOpTem.Text = lblMinOpTem.Text = "K";
                    lbOp1.Text = "% Operating at 261 K to 265 K";
                    lbOp2.Text = "% Operating at 265 K to 279 K";
                    lbOp3.Text = "% Operating at 279 K to 305 K";
                    lbOp4.Text = "% Operating at 305 K to 344 K";
                    lbOp5.Text = "% Operating at 344 K to 380 K";
                    lbOp6.Text = "% Operating at 380 K to 394 K";
                    lbOp7.Text = "% Operating at 394 K to 408 K";
                    lbOp8.Text = "% Operating at 408 K to 435 K";
                    lbOp9.Text = "% Operating at 435 K to 449 K";
                    lbOp10.Text = "% Operating at 449 K or above";
                    break;
            }            
            switch(flowRateUnit)
            {
                case "ft3/hr":
                    lblFlowRate.Text = "ft³/hr";
                    break;
                case "m3/hr":
                    lblFlowRate.Text = "m³/hr";
                    break;
            }
            if (pressureUnit == "N/m2") lblMinOpPressure.Text = lblMaxOpPressure.Text = lblHydroPressure.Text = "N/m²";
            else if (pressureUnit == "N/cm2") lblMinOpPressure.Text = lblMaxOpPressure.Text = lblHydroPressure.Text = "N/cm²";
            else lblMinOpPressure.Text = lblMaxOpPressure.Text = lblHydroPressure.Text = pressureUnit;
        }
        #endregion
        #region Process Data
        RW_EXTCOR_TEMPERATURE objTemp = new RW_EXTCOR_TEMPERATURE();
        private void ShowDataToForm(int ID, string temperatureUnit, string pressureUnit, string flowRateUnit)
        {
            RW_STREAM_BUS SteamBus = new RW_STREAM_BUS();
            RW_EXTCOR_TEMPERATURE_BUS tempBus = new RW_EXTCOR_TEMPERATURE_BUS();
            RW_STREAM objSteam = SteamBus.getData(ID);
            RW_EXTCOR_TEMPERATURE extTemp = tempBus.getData(ID);
            BUS_UNITS convUnit = new BUS_UNITS();
            switch(temperatureUnit)
            {
                case "DEG_C":
                    txtMaximumOperatingTemp.Text = objSteam.MaxOperatingTemperature.ToString();
                    txtMinimumOperatingTemp.Text = objSteam.MinOperatingTemperature.ToString();
                    txtCriticalExposure.Text = objSteam.CriticalExposureTemperature.ToString();
                    break;
                case "DEG_F":
                    txtMaximumOperatingTemp.Text = convUnit.CelToFah(objSteam.MaxOperatingTemperature).ToString();
                    txtMinimumOperatingTemp.Text = convUnit.CelToFah(objSteam.MinOperatingTemperature).ToString();
                    txtCriticalExposure.Text = convUnit.CelToFah(objSteam.CriticalExposureTemperature).ToString();
                    Console.WriteLine("Hha");
                    break;
                case "K":
                    txtMaximumOperatingTemp.Text = convUnit.CelToKenvin(objSteam.MaxOperatingTemperature).ToString();
                    txtMinimumOperatingTemp.Text = convUnit.CelToKenvin(objSteam.MinOperatingTemperature).ToString();
                    txtCriticalExposure.Text = convUnit.CelToKenvin(objSteam.CriticalExposureTemperature).ToString();
                    break;
            }
            switch(pressureUnit)
            {
                case "psi":
                    txtMaxOperatingPressure.Text = objSteam.MaxOperatingPressure.ToString();
                    txtMinOperatingPressure.Text = objSteam.MinOperatingPressure.ToString();
                    txtOperatingHydrogen.Text = objSteam.H2SPartialPressure.ToString();
                    break;
                case "KSI":
                    txtMaxOperatingPressure.Text = (objSteam.MaxOperatingPressure / convUnit.ksi).ToString();
                    txtMinOperatingPressure.Text = (objSteam.MinOperatingPressure / convUnit.ksi).ToString();
                    txtOperatingHydrogen.Text = (objSteam.H2SPartialPressure / convUnit.ksi).ToString();
                    break;
                case "bar":
                    txtMaxOperatingPressure.Text = (objSteam.MaxOperatingPressure / convUnit.bar).ToString();
                    txtMinOperatingPressure.Text = (objSteam.MinOperatingPressure / convUnit.bar).ToString();
                    txtOperatingHydrogen.Text = (objSteam.H2SPartialPressure / convUnit.bar).ToString();
                    break;
                case "MPa":
                    txtMaxOperatingPressure.Text = (objSteam.MaxOperatingPressure / convUnit.MPa).ToString();
                    txtMinOperatingPressure.Text = (objSteam.MinOperatingPressure / convUnit.MPa).ToString();
                    txtOperatingHydrogen.Text = (objSteam.H2SPartialPressure / convUnit.MPa).ToString();
                    break;
                case "N/m2":
                    txtMaxOperatingPressure.Text = (objSteam.MaxOperatingPressure / convUnit.NpM2).ToString();
                    txtMinOperatingPressure.Text = (objSteam.MinOperatingPressure / convUnit.NpM2).ToString();
                    txtOperatingHydrogen.Text = (objSteam.H2SPartialPressure / convUnit.NpM2).ToString();
                    break;
                case "N/cm2":
                    txtMaxOperatingPressure.Text = (objSteam.MaxOperatingPressure / convUnit.NpCM2).ToString();
                    txtMinOperatingPressure.Text = (objSteam.MinOperatingPressure / convUnit.NpCM2).ToString();
                    txtOperatingHydrogen.Text = (objSteam.H2SPartialPressure / convUnit.NpCM2).ToString();
                    break;
            }
            switch(flowRateUnit)
            {
                case "ft3/hr":
                    txtFlowRate.Text = (objSteam.FlowRate / convUnit.ft3).ToString();
                    break;
                case "m3/hr":
                    txtFlowRate.Text = objSteam.FlowRate.ToString();
                    break;
            }

            txtOp12.Text = extTemp.Minus12ToMinus8.ToString();
            txtOp8.Text = extTemp.Minus8ToPlus6.ToString();
            txtOp6.Text = extTemp.Plus6ToPlus32.ToString();
            txtOp32.Text = extTemp.Plus32ToPlus71.ToString();
            txtOp71.Text = extTemp.Plus71ToPlus107.ToString();
            txtOp107.Text = extTemp.Plus107ToPlus121.ToString();
            txtOp121.Text = extTemp.Plus121ToPlus135.ToString();
            txtOp135.Text = extTemp.Plus135ToPlus162.ToString();
            txtOp162.Text = extTemp.Plus162ToPlus176.ToString();
            txtOp176.Text = extTemp.MoreThanPlus176.ToString();
        }

        public RW_STREAM getDataforStream(int ID, string temperatureUnit, string pressureUnit, string flowRateUnit)
        {
            RW_STREAM str = new RW_STREAM();
            BUS_UNITS convUnit = new BUS_UNITS();
            str.ID = ID;            
            if(flowRateUnit == "m3/hr")str.FlowRate = txtFlowRate.Text != "" ? float.Parse(txtFlowRate.Text) : 0;
            else str.FlowRate = txtFlowRate.Text != "" ? float.Parse(txtFlowRate.Text) * (float)convUnit.ft3 : 0;
            switch(temperatureUnit)
            {
                case "DEG_C":
                    str.MaxOperatingTemperature = txtMaximumOperatingTemp.Text != "" ? float.Parse(txtMaximumOperatingTemp.Text) : 0;
                    str.MinOperatingTemperature = txtMinimumOperatingTemp.Text != "" ? float.Parse(txtMinimumOperatingTemp.Text) : 0;
                    str.CriticalExposureTemperature = txtCriticalExposure.Text != "" ? float.Parse(txtCriticalExposure.Text) : 0;
                    break;
                case "DEG_F":
                    str.MaxOperatingTemperature = txtMaximumOperatingTemp.Text != "" ? (float)convUnit.FahToCel(float.Parse(txtMaximumOperatingTemp.Text)) : 0;
                    str.MinOperatingTemperature = txtMinimumOperatingTemp.Text != "" ? (float)convUnit.FahToCel(float.Parse(txtMinimumOperatingTemp.Text)) : 0;
                    str.CriticalExposureTemperature = txtCriticalExposure.Text != "" ? (float)convUnit.FahToCel(float.Parse(txtCriticalExposure.Text)) : 0;
                    break;
                case "K":
                    str.MaxOperatingTemperature = txtMaximumOperatingTemp.Text != "" ? (float)convUnit.KenvinToCel(float.Parse(txtMaximumOperatingTemp.Text)) : 0;
                    str.MinOperatingTemperature = txtMinimumOperatingTemp.Text != "" ? (float)convUnit.KenvinToCel(float.Parse(txtMinimumOperatingTemp.Text)) : 0;
                    str.CriticalExposureTemperature = txtCriticalExposure.Text != "" ? (float)convUnit.KenvinToCel(float.Parse(txtCriticalExposure.Text)) : 0;
                    break;
            }
            switch(pressureUnit)
            {
                case "psi":
                    str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? float.Parse(txtMaxOperatingPressure.Text) : 0;
                    str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) : 0;
                    str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? float.Parse(txtOperatingHydrogen.Text) : 0;
                    break;
                case "KSI":
                    str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? float.Parse(txtMaxOperatingPressure.Text) * (float)convUnit.ksi : 0;
                    str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * (float)convUnit.ksi : 0;
                    str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? float.Parse(txtOperatingHydrogen.Text) * (float)convUnit.ksi : 0;
                    break;
                case "bar":
                    str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? float.Parse(txtMaxOperatingPressure.Text) * (float)convUnit.bar : 0;
                    str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * (float)convUnit.bar : 0;
                    str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? float.Parse(txtOperatingHydrogen.Text) * (float)convUnit.bar : 0;
                    break;
                case "MPa":
                    str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? float.Parse(txtMaxOperatingPressure.Text) * (float)convUnit.MPa : 0;
                    str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * (float)convUnit.MPa : 0;
                    str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? float.Parse(txtOperatingHydrogen.Text) * (float)convUnit.MPa : 0;
                    break;
                case "NpM2":
                    str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? float.Parse(txtMaxOperatingPressure.Text) * (float)convUnit.NpM2 : 0;
                    str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * (float)convUnit.NpM2 : 0;
                    str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? float.Parse(txtOperatingHydrogen.Text) * (float)convUnit.NpM2 : 0;
                    break;
                case "NpCM2":
                    str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? float.Parse(txtMaxOperatingPressure.Text) * (float)convUnit.NpCM2 : 0;
                    str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * (float)convUnit.NpCM2 : 0;
                    str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? float.Parse(txtOperatingHydrogen.Text) * (float)convUnit.NpCM2 : 0;
                    break;
            }
           
            return str;
        }

        public RW_EXTCOR_TEMPERATURE getDataExtcorTemp(int ID)
        {
            RW_EXTCOR_TEMPERATURE ext = new RW_EXTCOR_TEMPERATURE();
            ext.ID = ID;
            ext.Minus12ToMinus8 = txtOp12.Text != "" ? float.Parse(txtOp12.Text) : 0;
            ext.Minus8ToPlus6 = txtOp8.Text != "" ? float.Parse(txtOp8.Text) : 0;
            ext.Plus6ToPlus32 = txtOp6.Text != "" ? float.Parse(txtOp6.Text) : 0;
            ext.Plus32ToPlus71 = txtOp32.Text != "" ? float.Parse(txtOp32.Text) : 0;
            ext.Plus71ToPlus107 = txtOp71.Text != "" ? float.Parse(txtOp71.Text) : 0;
            ext.Plus107ToPlus121 = txtOp107.Text != "" ? float.Parse(txtOp107.Text) : 0;
            ext.Plus121ToPlus135 = txtOp121.Text != "" ? float.Parse(txtOp121.Text) : 0;
            ext.Plus135ToPlus162 = txtOp135.Text != "" ? float.Parse(txtOp135.Text) : 0;
            ext.Plus162ToPlus176 = txtOp162.Text != "" ? float.Parse(txtOp162.Text) : 0;
            ext.MoreThanPlus176 = txtOp176.Text != "" ? float.Parse(txtOp176.Text) : 0;
            return ext;
        }

        public RW_INPUT_CA_LEVEL_1 getDataforCA(int id, string temperatureUnit, string pressureUnit)//thao
        {
            RW_INPUT_CA_LEVEL_1 ca = new RW_INPUT_CA_LEVEL_1();
            BUS_UNITS convUnit = new BUS_UNITS();
            ca.ID = id;
            switch(temperatureUnit)
            {
                case "DEG_C":
                    ca.Stored_Temp = txtMinimumOperatingTemp.Text != "" ? float.Parse(txtMinimumOperatingTemp.Text) + 273 : 0;
                    break;
                case "DEG_F":
                    ca.Stored_Temp = txtMinimumOperatingTemp.Text != "" ? (float)convUnit.FahToCel(float.Parse(txtMinimumOperatingTemp.Text)) + 273 : 0;
                    break;
                case "K":
                    ca.Stored_Temp = txtMinimumOperatingTemp.Text != "" ? (float)convUnit.KenvinToCel(float.Parse(txtMinimumOperatingTemp.Text)) + 273 : 0;
                    break;
            }
            switch(pressureUnit)
            {
                case "psi":
                    ca.Stored_Pressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * 6.895f : 0;
                    break;
                case "KSI":
                    ca.Stored_Pressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * (float)convUnit.ksi * 6.895f : 0;
                    break;
                case "bar":
                    ca.Stored_Pressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * (float)convUnit.bar * 6.895f : 0;
                    break;
                case "MPa":
                    ca.Stored_Pressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * (float)convUnit.MPa * 6.895f : 0;
                    break;
                case "NpM2":
                    ca.Stored_Pressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * (float)convUnit.NpM2 * 6.895f : 0;
                    break;
                case "NpCM2":
                    ca.Stored_Pressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * (float)convUnit.NpCM2 * 6.895f : 0;
                    break;
            }
            return ca;
        }
        #endregion
        #region KeyPress Event Handle
        private void keyPressEvent(TextBox textbox, KeyPressEventArgs ev, bool percent)
        {
            
            string a = textbox.Text;
            if (percent)
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && (ev.KeyChar != '.'))
                {
                    ev.Handled = true;
                }
                if(a.Contains(".") && ev.KeyChar == '.')
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
        private void txtMaximumOperatingTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMaximumOperatingTemp, e, false);
        }

        private void txtMinimumOperatingTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMinimumOperatingTemp, e, false);
        }

        private void txtOperatingHydrogen_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOperatingHydrogen, e, false);
        }

        private void txtCriticalExposure_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCriticalExposure, e, false);
        }

        private void txtMaxOperatingPressure_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMaximumOperatingTemp, e, false);
        }
        private void txtMinOperatingPressure_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMinimumOperatingTemp, e, false);
        }

        private void txtFlowRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtFlowRate, e, false);
        }

        private void txtOp12_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp12, e, true);
        }

        private void txtOp8_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp8, e, true);
        }

        private void txtOp6_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp6, e, true);
        }

        private void txtOp32_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp32, e, true);
        }
        private void txtOp71_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp71, e, true);
        }

        private void txtOp107_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp107, e, true);
        }

        private void txtOp121_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp121, e, true);
        }

        private void txtOp135_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp135, e, true);
        }

        private void txtOp162_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp162, e, true);
        }

        private void txtOp176_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtOp176, e, true);
        }
        private void checkOver100(TextBox txt)
        {
            DataChange++;
            if(txt.Text != "")
            {
                try
                {
                    if (float.Parse(txt.Text) > 100)
                    {
                        MessageBox.Show("Invalid value", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt.Text = "100";
                    }
                }
                catch
                {
                    txt.Text = "100";
                }
            }
        }
        

        private void txtOp12_TextChanged(object sender, EventArgs e)
        {
            checkOver100(txtOp12);
        }

        private void txtOp8_TextChanged(object sender, EventArgs e)
        {
            checkOver100(txtOp8);
        }

        private void txtOp6_TextChanged(object sender, EventArgs e)
        {
            checkOver100(txtOp6);
        }

        private void txtOp32_TextChanged(object sender, EventArgs e)
        {
            checkOver100(txtOp32);
        }

        private void txtOp71_TextChanged(object sender, EventArgs e)
        {
            checkOver100(txtOp71);
        }

        private void txtOp107_TextChanged(object sender, EventArgs e)
        {
            checkOver100(txtOp107);
        }

        private void txtOp121_TextChanged(object sender, EventArgs e)
        {
            checkOver100(txtOp121);
        }

        private void txtOp135_TextChanged(object sender, EventArgs e)
        {
            checkOver100(txtOp135);
        }

        private void txtOp162_TextChanged(object sender, EventArgs e)
        {
            checkOver100(txtOp162);
        }

        private void txtOp176_TextChanged(object sender, EventArgs e)
        {
            checkOver100(txtOp176);
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
        private void txtMaximumOperatingTemp_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
        }
        private void txtMaximumOperatingTemp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                CtrlSPress++;
            }
        }
        #endregion

        
        
    }
}
