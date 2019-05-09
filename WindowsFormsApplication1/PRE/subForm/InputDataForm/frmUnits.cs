using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RBI.BUS.BUSMSSQL;
using RBI.Object.ObjectMSSQL;

namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmUnits : DevExpress.XtraEditors.XtraForm
    {
        public frmUnits()
        {
            InitializeComponent();
            initDataScheme();
        }

        private void initDataScheme()
        {
            UNITS_BUS busUnit = new UNITS_BUS();
            lstUnit = busUnit.getDataSource();
            string str = "";
            List<String> selectedUnitList = new List<string>();
            foreach (UNITS obj in lstUnit)
            {
                str += obj.UnitName + " " + obj.SelectedUnit + '\n';
            }
            //MessageBox.Show(str, "Unit Name");
            foreach (UNITS obj in lstUnit)
            {
                if (obj.UnitName == "Pressure")
                {
                    if (obj.SelectedUnit == "KSI") rbtnPressureKSI.Checked = true;
                    else if (obj.SelectedUnit == "bar") rbtnPressureBAR.Checked = true;
                    else if (obj.SelectedUnit == "psi") rbtnPressurePSI.Checked = true;
                    else if (obj.SelectedUnit == "N/cm2") rbtnPressureNpcm2.Checked = true;
                    else if (obj.SelectedUnit == "N/m2") rbtnPressureNpm2.Checked = true;
                    else if (obj.SelectedUnit == "MPa") rbtnPressureMPa.Checked = true;
                }
                else if (obj.UnitName == "Stress")
                {
                    if (obj.SelectedUnit == "KSI") rbtnStressKSI.Checked = true;
                    else if (obj.SelectedUnit == "bar") rbtnStressBAR.Checked = true;
                    else if (obj.SelectedUnit == "psi") rbtnStressPSI.Checked = true;
                    else if (obj.SelectedUnit == "N/cm2") rbtnStressNpcm2.Checked = true;
                    else if (obj.SelectedUnit == "N/m2") rbtnStressNpm2.Checked = true;
                    else if (obj.SelectedUnit == "MPa") rbtnStressMPa.Checked = true;
                }
                else if (obj.UnitName == "Temperature")
                {
                    if (obj.SelectedUnit == "DEG_C") rbtnCel.Checked = true;
                    else if (obj.SelectedUnit == "DEG_F") rbtnFa.Checked = true;
                    else if (obj.SelectedUnit == "K") rbtnKen.Checked = true;
                }
                else if (obj.UnitName == "Diameter")
                {
                    if (obj.SelectedUnit == "in") rbtnDiameterInch.Checked = true;
                    else if (obj.SelectedUnit == "mm") rbtnDiameterMM.Checked = true;
                    else if (obj.SelectedUnit == "m") rbtnDiameterM.Checked = true;
                }
                else if (obj.UnitName == "Thickness")
                {
                    if (obj.SelectedUnit == "in") rbtnThicknessIn.Checked = true;
                    else if (obj.SelectedUnit == "mm") rbtnThicknessMM.Checked = true;
                    else if (obj.SelectedUnit == "m") rbtnThicknessM.Checked = true;
                }
                else if (obj.UnitName == "Dimensions")
                {
                    if (obj.SelectedUnit == "in") rbtnDimensionIn.Checked = true;
                    else if (obj.SelectedUnit == "m") rbtnDimensionM.Checked = true;
                    else if (obj.SelectedUnit == "mm") rbtnDimensionMM.Checked = true;
                }
                else if (obj.UnitName == "Volume")
                {
                    if (obj.SelectedUnit == "m3") rbtnM3.Checked = true;
                    else if (obj.SelectedUnit == "ft3") rbtnFt3.Checked = true;
                }
                else if (obj.UnitName == "FlowRate")
                {
                    if (obj.SelectedUnit == "m3/hr") rbtnM3pHr.Checked = true;
                    else if (obj.SelectedUnit == "ft3/hr") rbtnFt3pHr.Checked = true;
                }
                else if (obj.UnitName == "CorrosionRate")
                {
                    if (obj.SelectedUnit == "mm/yr") rbtnCrMMperYr.Checked = true;
                    else if (obj.SelectedUnit == "mil/yr") rbtnCrMilPerYr.Checked = true;
                }
                else if (obj.UnitName == "Corrosion")
                {
                    if (obj.SelectedUnit == "mm") rbtnCorrosionMM.Checked = true;
                    else if (obj.SelectedUnit == "mil") rbtnMil.Checked = true;
                }
                else if (obj.UnitName == "Scheme")
                {
                    if (obj.SelectedUnit == "European") cbScheme.SelectedIndex = 2;
                    else if (obj.SelectedUnit == "US") cbScheme.SelectedIndex = 1;
                    else if (obj.SelectedUnit == "Custom") cbScheme.SelectedIndex = 0;
                }
                //else if (obj.UnitName == "FinacialUnit")
                //{
                //    if (obj.SelectedUnit == "USD") cbFinaUnit.SelectedIndex = 0;
                //    else if (obj.SelectedUnit == "VND") cbFinaUnit.SelectedIndex = 1;
                //    else if (obj.SelectedUnit == "Euro") cbFinaUnit.SelectedIndex = 2;
                //}
            }
        }
        #region parameter
        List<UNITS> lstUnit = new List<UNITS>();
        String[] UnitName = {
            "Pressure",
            "Stress",
            "Temperature",
            "Diameter",
            "Thickness",
            "Dimensions",
            "Volume",
            "FlowRate",
            "Corrosion",
            "CorrosionRate",
            "FinacialUnit",
            "Scheme"
        };
        public bool ButtonOKClicked { set; get; }
        #endregion

        private void cbScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbScheme.SelectedIndex)
            {
                //case 0:
                //    initDataScheme();
                //    break;
                case 1:
                    showUSScheme();
                    break;
                case 2:
                    showEuropeanScheme();
                    break;
            }
        }

        private void showUSScheme()
        {
            rbtnPressurePSI.Checked = true;
            rbtnStressPSI.Checked = true;
            rbtnThicknessIn.Checked = true;
            rbtnDiameterInch.Checked = true;
            rbtnDimensionIn.Checked = true;
            rbtnFa.Checked = true;
            rbtnMil.Checked = true;
            rbtnCrMilPerYr.Checked = true;
            rbtnFt3pHr.Checked = true;
            rbtnFt3.Checked = true;
        }

        private void showEuropeanScheme()
        {
            rbtnPressurePSI.Checked = true;
            rbtnStressPSI.Checked = true;
            rbtnThicknessMM.Checked = true;
            rbtnDiameterMM.Checked = true;
            rbtnDimensionMM.Checked = true;
            rbtnCel.Checked = true;
            rbtnCorrosionMM.Checked = true;
            rbtnCrMMperYr.Checked = true;
            rbtnM3pHr.Checked = true;
            rbtnM3.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UNITS_BUS busUnit = new UNITS_BUS();
            List<string> listUnit = new List<string>();
            #region Unit String
            string pressure = "";
            string stress = "";
            string temperature = "";
            string diameter = "";
            string dimension = "";
            string volume = "";
            string thickness = "";
            string corrosion = "";
            string corrosionRate = "";
            string flowRate = "";
            string finacialUnit = "";
            string scheme = "";
            #endregion
            #region set pressure
            if (rbtnPressureBAR.Checked) pressure = "bar";
            else if (rbtnPressureKSI.Checked) pressure = "KSI";
            else if (rbtnPressureMPa.Checked) pressure = "MPa";
            else if (rbtnPressureNpcm2.Checked) pressure = "N/cm2";
            else if (rbtnPressureNpm2.Checked) pressure = "N/m2";
            else if (rbtnPressurePSI.Checked) pressure = "psi";

            listUnit.Add(pressure);
            #endregion
            #region set stress
            if (rbtnStressBAR.Checked) stress = "bar";
            else if (rbtnStressKSI.Checked) stress = "KSI";
            else if (rbtnStressMPa.Checked) stress = "MPa";
            else if (rbtnStressNpcm2.Checked) stress = "N/cm2";
            else if (rbtnStressNpm2.Checked) stress = "N/m2";
            else if (rbtnStressPSI.Checked) stress = "psi";

            listUnit.Add(stress);
            #endregion
            #region set temperature
            if (rbtnCel.Checked) temperature = "DEG_C";
            else if (rbtnKen.Checked) temperature = "K";
            else if (rbtnFa.Checked) temperature = "DEG_F";

            listUnit.Add(temperature);
            #endregion
            #region set diameter
            if (rbtnDiameterInch.Checked) diameter = "in";
            else if (rbtnDiameterM.Checked) diameter = "m";
            else if (rbtnDiameterMM.Checked) diameter = "mm";

            listUnit.Add(diameter);
            #endregion
            #region set thickness
            if (rbtnThicknessIn.Checked) thickness = "in";
            else if (rbtnThicknessM.Checked) thickness = "m";
            else if (rbtnThicknessMM.Checked) thickness = "mm";

            listUnit.Add(thickness);
            #endregion
            #region set dimension
            if (rbtnDimensionIn.Checked) dimension = "in";
            else if (rbtnDimensionM.Checked) dimension = "m";
            else if (rbtnDimensionMM.Checked) dimension = "mm";

            listUnit.Add(dimension);
            #endregion
            #region set volume
            if (rbtnM3.Checked) volume = "m3";
            else if (rbtnFt3.Checked) volume = "ft3";

            listUnit.Add(volume);
            #endregion
            #region set Flow Rate
            if (rbtnFt3pHr.Checked) flowRate = "ft3/hr";
            else if (rbtnM3pHr.Checked) flowRate = "m3/hr";

            listUnit.Add(flowRate);
            #endregion
            #region set Corrosion
            if (rbtnCorrosionMM.Checked) corrosion = "mm";
            else if (rbtnMil.Checked) corrosion = "mil";

            listUnit.Add(corrosion);
            #endregion
            #region set Corrrosion Rate
            if (rbtnCrMMperYr.Checked) corrosionRate = "mm/yr";
            else if (rbtnCrMilPerYr.Checked) corrosionRate = "mil/yr";

            listUnit.Add(corrosionRate);
            #endregion
            #region set finacial Unit
            //finacialUnit = cbFinaUnit.SelectedText;
            Console.WriteLine(finacialUnit);
            listUnit.Add(finacialUnit);
            #endregion
            #region set scheme
            scheme = cbScheme.SelectedText;
            listUnit.Add(scheme);
            #endregion

            int i = 0;
            //for (int j = 0; j < listUnit.Count; j++) Console.WriteLine(listUnit[j]);
            foreach (string item in listUnit)
            {
                busUnit.edit(UnitName[i], item);
                ++i;
            }
            ButtonOKClicked = true;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("The changed setting is not save. Do you want exit?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK) this.Close();
        }
    }
}