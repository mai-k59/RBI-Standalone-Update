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
        public UCOperatingCondition()
        {
            InitializeComponent();
        }
        public UCOperatingCondition(int ID)
        {
            InitializeComponent();
            //getData(ID);
        }
        //mai mai
        public UCOperatingCondition(int ID, string temperatureUnit, string pressureUnit, string flowRateUnit)
        {
            InitializeComponent();
            ShowDataToForm(ID, temperatureUnit, pressureUnit, flowRateUnit);
            switch (temperatureUnit)
            {
                case "DEG_C":
                    lblCritExpoTem.Text = lblmaxOpTem.Text = lblMinOpTem.Text = "⁰C";
                    lbOp1.Text = "% Operating at -12 ⁰C to -8 ⁰C";
                    lbOp2.Text = "% Operating at -8 ⁰C to 6 ⁰C";
                    lbOp3.Text = "% Operating at 6 ⁰C to 32 ⁰C";
                    lbOp4.Text = "% Operating at 32 ⁰C to 71⁰C";
                    lbOp5.Text = "% Operating at 71⁰C to 107⁰C";
                    lbOp6.Text = "% Operating at 107⁰C to 121⁰C";
                    lbOp7.Text = "% Operating at 121⁰C to 135⁰C";
                    lbOp8.Text = "% Operating at 135⁰C to 162⁰C";
                    lbOp9.Text = "% Operating at 162⁰C to 176⁰C";
                    lbOp10.Text = "% Operating at 176⁰C or above";
                    break;
                case "DEG_F":
                    lblCritExpoTem.Text = lblmaxOpTem.Text = lblMinOpTem.Text = "⁰F";
                    lbOp1.Text = "% Operating at 10.4 ⁰F to 17.6 ⁰F";
                    lbOp2.Text = "% Operating at 17.6 ⁰F to 42.8 ⁰F";
                    lbOp3.Text = "% Operating at 42.8 ⁰F to 89.6 ⁰F";
                    lbOp4.Text = "% Operating at 89.6 ⁰F to 159.8 ⁰F";
                    lbOp5.Text = "% Operating at 159.8 ⁰F to 224.6 ⁰F";
                    lbOp6.Text = "% Operating at 224.6 ⁰F to 249.8 ⁰F";
                    lbOp7.Text = "% Operating at 249.8 ⁰F to 275 ⁰F";
                    lbOp8.Text = "% Operating at 275 ⁰F to 323.6 ⁰F";
                    lbOp9.Text = "% Operating at 232.6 ⁰F to 348.8 ⁰F";
                    lbOp10.Text = "% Operating at 348.8 ⁰F or above";
                    break;
                case "K":
                    lblCritExpoTem.Text = lblmaxOpTem.Text = lblMinOpTem.Text = "K";
                    lbOp1.Text = "% Operating at 261 ⁰K to 265 ⁰K";
                    lbOp2.Text = "% Operating at 265 ⁰K to 279 ⁰K";
                    lbOp3.Text = "% Operating at 279 ⁰K to 305 ⁰K";
                    lbOp4.Text = "% Operating at 305 ⁰K to 344 ⁰K";
                    lbOp5.Text = "% Operating at 344 ⁰K to 380 ⁰K";
                    lbOp6.Text = "% Operating at 380 ⁰K to 394 ⁰K";
                    lbOp7.Text = "% Operating at 394 ⁰K to 408 ⁰K";
                    lbOp8.Text = "% Operating at 408 ⁰K to 435 ⁰K";
                    lbOp9.Text = "% Operating at 435 ⁰K to 449 ⁰K";
                    lbOp10.Text = "% Operating at 449 ⁰K or above";
                    break;
            }
            lblMinOpPressure.Text = lblMaxOpPressure.Text = lblHydroPressure.Text = pressureUnit;
            lblFlowRate.Text = flowRateUnit;
        }
        RW_EXTCOR_TEMPERATURE objTemp = new RW_EXTCOR_TEMPERATURE();
        private void ShowDataToForm(int ID, string temperatureUnit, string pressureUnit, string flowRateUnit)
        {
            RW_STREAM_BUS SteamBus = new RW_STREAM_BUS();
            RW_EXTCOR_TEMPERATURE_BUS tempBus = new RW_EXTCOR_TEMPERATURE_BUS();
            RW_STREAM objSteam = SteamBus.getData(ID);
            RW_EXTCOR_TEMPERATURE extTemp = tempBus.getData(ID);
            BUS_UNITS convUnit = new BUS_UNITS();

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
            if (temperatureUnit == "DEG_C")
            {
                
                txtMaximumOperatingTemp.Text = objSteam.MaxOperatingTemperature.ToString();
                txtMinimumOperatingTemp.Text = objSteam.MinOperatingTemperature.ToString();
                txtCriticalExposure.Text = objSteam.CriticalExposureTemperature.ToString();
            }
            else if (temperatureUnit == "DEG_F") // converst C sang F
            {
                
                txtMaximumOperatingTemp.Text = convUnit.CelToFah(objSteam.MaxOperatingTemperature).ToString();
                txtMinimumOperatingTemp.Text = convUnit.CelToFah(objSteam.MinOperatingTemperature).ToString();
                txtCriticalExposure.Text = convUnit.CelToFah(objSteam.CriticalExposureTemperature).ToString();
            }
            else // converst C sang K
            {

                txtMaximumOperatingTemp.Text = convUnit.CelToKenvin(objSteam.MaxOperatingTemperature).ToString();
                txtMinimumOperatingTemp.Text = convUnit.CelToKenvin(objSteam.MinOperatingTemperature).ToString();
                txtCriticalExposure.Text = convUnit.CelToKenvin(objSteam.CriticalExposureTemperature).ToString();
            }

            switch (pressureUnit)
            { 
                case "psi": 
                    {
                        txtMaxOperatingPressure.Text = objSteam.MaxOperatingPressure.ToString();
                        txtMinOperatingPressure.Text = objSteam.MinOperatingPressure.ToString();
                        txtOperatingHydrogen.Text = objSteam.H2SPartialPressure.ToString();
                    }
                    break;
                case "KSI": // psi sang ksi
                    {
                        txtMaxOperatingPressure.Text = (objSteam.MaxOperatingPressure/convUnit.ksi).ToString();
                        txtMinOperatingPressure.Text = (objSteam.MinOperatingPressure/convUnit.ksi).ToString();
                        txtOperatingHydrogen.Text = (objSteam.H2SPartialPressure / convUnit.ksi).ToString();
                    }
                    break;
                case "bar": // psi sang bar
                    {
                        txtMaxOperatingPressure.Text = (objSteam.MaxOperatingPressure/convUnit.bar).ToString();
                        txtMinOperatingPressure.Text = (objSteam.MinOperatingPressure/convUnit.bar).ToString();
                        txtOperatingHydrogen.Text = (objSteam.H2SPartialPressure / convUnit.bar).ToString();
                    }
                    break;
                case "MPa": // psi sang mpa
                    {
                        txtMaxOperatingPressure.Text = (objSteam.MaxOperatingPressure/convUnit.MPa).ToString();
                        txtMinOperatingPressure.Text = (objSteam.MinOperatingPressure / convUnit.MPa).ToString();
                        txtOperatingHydrogen.Text = (objSteam.H2SPartialPressure / convUnit.MPa).ToString();
                    }
                    break;
                case "N/m2": //psi sang N/m2
                    {
                        txtMaxOperatingPressure.Text = (objSteam.MaxOperatingPressure/convUnit.NpM2).ToString();
                        txtMinOperatingPressure.Text = (objSteam.MinOperatingPressure / convUnit.NpM2).ToString();
                        txtOperatingHydrogen.Text = (objSteam.H2SPartialPressure / convUnit.NpM2).ToString();
                    };
                    break;
                default: // psi sang N/cm2
                    {
                        txtMaxOperatingPressure.Text = (objSteam.MaxOperatingPressure/convUnit.NpCM2).ToString();
                        txtMinOperatingPressure.Text = (objSteam.MinOperatingPressure / convUnit.NpCM2).ToString();
                        txtOperatingHydrogen.Text = (objSteam.H2SPartialPressure / convUnit.NpCM2).ToString();
                    }
                    break;
            }

            if(flowRateUnit == "m3/hr") // giữ nguyên
                txtFlowRate.Text = objSteam.FlowRate.ToString();
                
            else txtFlowRate.Text = (objSteam.FlowRate/convUnit.ft3).ToString();  // convert m3/hr sang ft3/h

            
        }
        //RW_EXTCOR_TEMPERATURE objTemp = new RW_EXTCOR_TEMPERATURE();


        public RW_STREAM getDataforStream(int ID, string temperatureUnit, string pressureUnit, string flowRateUnit)
        {
            RW_STREAM str = new RW_STREAM();
            BUS_UNITS convUnit = new BUS_UNITS();

            str.ID = ID;
            if (temperatureUnit == "DEG_C") // converst C sang C
            {
                str.MaxOperatingTemperature = txtMaximumOperatingTemp.Text != "" ? float.Parse(txtMaximumOperatingTemp.Text) : 0;
                str.MinOperatingTemperature = txtMinimumOperatingTemp.Text != "" ? float.Parse(txtMinimumOperatingTemp.Text) : 0;
                str.CriticalExposureTemperature = txtCriticalExposure.Text != "" ? float.Parse(txtCriticalExposure.Text) : 0;
            }
            else if (temperatureUnit == "DEG_F") // converst F sang C
            {
                str.MaxOperatingTemperature = txtMaximumOperatingTemp.Text != "" ? (float)(convUnit.FahToCel(double.Parse(txtMaximumOperatingTemp.Text))) : 0;
                str.MinOperatingTemperature = txtMinimumOperatingTemp.Text != "" ? (float)(convUnit.FahToCel(double.Parse(txtMinimumOperatingTemp.Text))) : 0;
                str.CriticalExposureTemperature = txtCriticalExposure.Text != "" ? (float)(convUnit.FahToCel(double.Parse(txtCriticalExposure.Text))) : 0;
            }
            else // converst K sang C
            {
                str.MaxOperatingTemperature = txtMaximumOperatingTemp.Text != "" ? (float)(convUnit.KenvinToCel(double.Parse(txtMaximumOperatingTemp.Text))) : 0;
                str.MinOperatingTemperature = txtMinimumOperatingTemp.Text != "" ? (float)(convUnit.KenvinToCel(double.Parse(txtMinimumOperatingTemp.Text))) : 0;
                str.CriticalExposureTemperature = txtCriticalExposure.Text != "" ? (float)(convUnit.KenvinToCel(double.Parse(txtCriticalExposure.Text))) : 0;
            }

            switch (pressureUnit)
            {
                case "psi": // psi sang psi dua vao base
                    str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? float.Parse(txtMaxOperatingPressure.Text) : 0;
                    str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) : 0;
                    str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? float.Parse(txtOperatingHydrogen.Text) : 0;
                    break;
                case "KSI": // ksi sang psi
                    str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? (float)(double.Parse(txtMaxOperatingPressure.Text)*convUnit.ksi) : 0;
                    str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? (float)(double.Parse(txtMinOperatingPressure.Text)*convUnit.ksi) : 0;
                    str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? (float)(double.Parse(txtOperatingHydrogen.Text)*convUnit.ksi) : 0;
                    break;
                case "bar": // bar sang psi
                    str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? (float)(double.Parse(txtMaxOperatingPressure.Text)*convUnit.bar) : 0;
                    str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? (float)(double.Parse(txtMinOperatingPressure.Text)*convUnit.bar) : 0;
                    str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? (float)(double.Parse(txtOperatingHydrogen.Text)*convUnit.bar) : 0;
                     break;
                case "MPa": // mpa sang psi
                    str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? (float)(double.Parse(txtMaxOperatingPressure.Text)*convUnit.MPa) : 0;
                    str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? (float)(double.Parse(txtMinOperatingPressure.Text)*convUnit.MPa) : 0;
                    str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? (float)(double.Parse(txtOperatingHydrogen.Text)*convUnit.MPa) : 0;
                     break;
                case "N/m2": //N/m2 sang psi
                    str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? (float)(double.Parse(txtMaxOperatingPressure.Text)*convUnit.NpM2) : 0;
                    str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? (float)(double.Parse(txtMinOperatingPressure.Text)*convUnit.NpM2) : 0;
                    str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? (float)(double.Parse(txtOperatingHydrogen.Text)*convUnit.NpM2) : 0;
                     break;
                default: // N/cm2 sang psi
                    str.MaxOperatingPressure = txtMaxOperatingPressure.Text != "" ? (float)(double.Parse(txtMaxOperatingPressure.Text)*convUnit.NpCM2) : 0;
                    str.MinOperatingPressure = txtMinOperatingPressure.Text != "" ? (float)(double.Parse(txtMinOperatingPressure.Text)*convUnit.NpCM2) : 0;
                    str.H2SPartialPressure = txtOperatingHydrogen.Text != "" ? (float)(double.Parse(txtOperatingHydrogen.Text) * convUnit.NpCM2) : 0;
                     break;

            }

            if (flowRateUnit == "m3/hr") // giữ nguyên
            str.FlowRate = txtFlowRate.Text != "" ? float.Parse(txtFlowRate.Text) : 0;
            else str.FlowRate = txtFlowRate.Text != "" ? (float)(double.Parse(txtFlowRate.Text)*convUnit.ft3) : 0;  // convert ft3/hr sang m3/h
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
        public RW_INPUT_CA_LEVEL_1 getDataforCA()
        {
            RW_INPUT_CA_LEVEL_1 ca = new RW_INPUT_CA_LEVEL_1();
            ca.Stored_Pressure = txtMinOperatingPressure.Text != "" ? float.Parse(txtMinOperatingPressure.Text) * 6.895f : 0;
            ca.Stored_Temp = txtMinimumOperatingTemp.Text != "" ? float.Parse(txtMinimumOperatingTemp.Text) + 273 : 0;
            return ca;
        }

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
