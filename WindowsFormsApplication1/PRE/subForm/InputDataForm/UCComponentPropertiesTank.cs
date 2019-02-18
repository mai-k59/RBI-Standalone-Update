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
    public partial class UCComponentPropertiesTank : UserControl
    {
        string[] itemsSeverity = { "None", "Low", "Medium", "High" };
        string[] itemsBrinnellHardness = { "Below 200", "Between 200 and 237", "Greater than 237" };
        string[] itemsComplexityProtrusion = { "Above average", "Average", "Below average" };
        private int datachange = 0;
        private int ctrlSpress = 0;
        public UCComponentPropertiesTank(int ID, string type, string diameterUnit, string thicknessUnit, string corrosionRateUnit)
        {
            InitializeComponent();
            ShowDataToControl(ID, diameterUnit, thicknessUnit, corrosionRateUnit);
            if (type == "Shell")
            {
                chkConcreteAsphalt.Enabled = false;
                chkPreventionBarrier.Enabled = false;
            }
            else
                txtShellCourseHeight.Enabled = false;
            lblDiameter.Text = diameterUnit;
            lblCurrentThickness.Text = lblNominalThickness.Text = lblMinReqThickness.Text = thicknessUnit;
            lblCorrosionRate.Text = corrosionRateUnit;
        }
        private void ShowDataToControl(int ID, string diameter, string thickness, string corrosionRate)
        {
            RW_COMPONENT_BUS busCom = new RW_COMPONENT_BUS();
            RW_COMPONENT com = busCom.getData(ID);
            BUS_UNITS convUnit = new BUS_UNITS();
            if (diameter == "in") txtTankDiameter.Text = (com.NominalDiameter/ convUnit.inch).ToString(); // converst mm sang in
            else if (diameter == "mm") txtTankDiameter.Text = com.NominalDiameter.ToString(); // giữ nguyên
            else txtTankDiameter.Text = (com.NominalDiameter / 1000).ToString(); // converst mm sang m

            if (thickness == "mm")
            {
                txtNominalThickness.Text = com.NominalThickness.ToString(); //giữ nguyên
                txtCurrentThickness.Text = com.CurrentThickness.ToString();// giữ nguyên
                txtMinRequiredThickness.Text = com.MinReqThickness.ToString();//  giữ nguyên
            }
            else if (thickness == "in")
            {
                txtNominalThickness.Text = (com.NominalThickness / convUnit.inch).ToString(); //converst mm sang in
                txtCurrentThickness.Text = (com.CurrentThickness / convUnit.inch).ToString(); //converst mm sang in
                txtMinRequiredThickness.Text = (com.MinReqThickness / convUnit.inch).ToString(); //converst mm sang in
            }
            else
            {
                txtNominalThickness.Text = (com.NominalThickness / 1000).ToString(); // converst mm sang m
                txtCurrentThickness.Text = (com.CurrentThickness / 1000).ToString(); // converst mm sang m
                txtMinRequiredThickness.Text = (com.MinReqThickness / 1000).ToString(); // converst mm sang m
            }

            if (corrosionRate == "mm/yr") txtCurrentCorrosionRate.Text = com.CurrentCorrosionRate.ToString(); // converst mm sang mm
            else txtCurrentCorrosionRate.Text = (com.CurrentCorrosionRate / convUnit.mil).ToString(); // converst mm sang mil
            txtShellCourseHeight.Text = com.ShellHeight.ToString();
            chkDamageFoundDuringInspection.Checked = com.DamageFoundInspection == 1 ? true : false;
            chkConcreteAsphalt.Checked = com.ConcreteFoundation == 1 ? true : false;
            chkPresenceCracks.Checked = com.CracksPresent == 1 ? true : false;
            chkPreventionBarrier.Checked = com.ReleasePreventionBarrier == 1 ? true : false;
            chkTrampElements.Checked = com.TrampElements == 1 ? true : false;
            for(int i = 0; i<itemsBrinnellHardness.Length;i++)
            {
                if(itemsBrinnellHardness[i] == com.BrinnelHardness)
                {
                    cbMaxBrillnessHardness.SelectedIndex = i + 1;
                    break;
                }
            }
            for(int i = 0; i < itemsComplexityProtrusion.Length; i++)
            {
                if(itemsComplexityProtrusion[i] == com.ComplexityProtrusion)
                {
                    cbComplexityProtrusion.SelectedIndex = i + 1;
                    break;
                }
            }
            for(int i = 0; i < itemsSeverity.Length; i++)
            {
                if(itemsSeverity[i] == com.SeverityOfVibration)
                {
                    cbSeverityVibration.SelectedIndex = i + 1;
                    break;
                }
            }
        }
        public RW_COMPONENT getData(int ID, string diameter, string thickness, string corrosionRate)
        {
            RW_COMPONENT comp = new RW_COMPONENT();
            comp.ID = ID;
            BUS_UNITS convUnit = new BUS_UNITS();
            if (diameter == "mm") comp.NominalDiameter = txtTankDiameter.Text != "" ? float.Parse(txtTankDiameter.Text) : 0;
            else if (diameter == "in") comp.NominalDiameter = txtTankDiameter.Text != "" ? (float)(double.Parse(txtTankDiameter.Text) * convUnit.inch) : 0; // in sang mm
            else comp.NominalDiameter = txtTankDiameter.Text != "" ? float.Parse(txtTankDiameter.Text) * 1000 : 0; // m sang mm
            //comp.NominalDiameter = txtTankDiameter.Text != "" ? float.Parse(txtTankDiameter.Text) : 0;
            if (thickness == "mm")
            {
                comp.NominalThickness = txtNominalThickness.Text != "" ? float.Parse(txtNominalThickness.Text) : 0;
                comp.CurrentThickness = txtCurrentThickness.Text != "" ? float.Parse(txtCurrentThickness.Text) : 0;
                comp.MinReqThickness = txtMinRequiredThickness.Text != "" ? float.Parse(txtMinRequiredThickness.Text) : 0;
            }
            else if (thickness == "in")
            {
                comp.NominalThickness = txtNominalThickness.Text != "" ? (float)(double.Parse(txtNominalThickness.Text) * convUnit.inch) : 0; // in sang mm
                comp.CurrentThickness = txtCurrentThickness.Text != "" ? (float)(double.Parse(txtCurrentThickness.Text) * convUnit.inch) : 0; // in sang mm
                comp.MinReqThickness = txtMinRequiredThickness.Text != "" ? (float)(double.Parse(txtMinRequiredThickness.Text) * convUnit.inch) : 0;// in sang mm
            }
            else
            {
                comp.NominalThickness = txtNominalThickness.Text != "" ? (float)(double.Parse(txtNominalThickness.Text) * 1000) : 0; // m sang mm
                comp.CurrentThickness = txtCurrentThickness.Text != "" ? (float)(double.Parse(txtCurrentThickness.Text) * 1000) : 0; // m sang mm
                comp.MinReqThickness = txtMinRequiredThickness.Text != "" ? (float)(double.Parse(txtMinRequiredThickness.Text) * 1000) : 0;// m sang mm
            }
            //comp.NominalThickness = txtNominalThickness.Text != "" ? float.Parse(txtNominalThickness.Text) : 0;
            //comp.CurrentThickness = txtCurrentThickness.Text != "" ? float.Parse(txtCurrentThickness.Text) : 0;
            //comp.MinReqThickness = txtMinRequiredThickness.Text != "" ? float.Parse(txtMinRequiredThickness.Text) : 0;
            if (corrosionRate == "mm/yr") comp.CurrentCorrosionRate = txtCurrentCorrosionRate.Text != "" ? (float)double.Parse(txtCurrentCorrosionRate.Text) : 0;
            else comp.CurrentCorrosionRate = txtCurrentCorrosionRate.Text != "" ? (float)(double.Parse(txtCurrentCorrosionRate.Text) * convUnit.mil) : 0; // mil/yr sang mm/yr
            //comp.CurrentCorrosionRate = txtCurrentCorrosionRate.Text != "" ? float.Parse(txtCurrentCorrosionRate.Text) : 0;
            comp.BrinnelHardness = cbMaxBrillnessHardness.Text;
            comp.SeverityOfVibration = cbSeverityVibration.Text;
            comp.ComplexityProtrusion = cbComplexityProtrusion.Text;
            comp.DamageFoundInspection = chkDamageFoundDuringInspection.Checked ? 1 : 0;
            comp.CracksPresent = chkPresenceCracks.Checked ? 1 : 0;
            comp.TrampElements = chkTrampElements.Checked ? 1 : 0;
            //kiem tra dieu kien API Component Type -> Disable control cua shell hoac cua bottom
            //tank Shell Course
            comp.ShellHeight = txtShellCourseHeight.Text != "" ? float.Parse(txtShellCourseHeight.Text) : 0;
            //tank bottom
            comp.ConcreteFoundation = chkConcreteAsphalt.Checked ? 1 : 0;
            comp.ReleasePreventionBarrier = chkPreventionBarrier.Checked ? 1 : 0;
            return comp;
        }

        public RW_INPUT_CA_TANK getDataforTank(int ID, string diameter)
        {
            RW_INPUT_CA_TANK tank = new RW_INPUT_CA_TANK();
            BUS_UNITS convUnit = new BUS_UNITS();
            tank.ID = ID;
            if (diameter == "mm") tank.TANK_DIAMETTER = txtTankDiameter.Text != "" ? float.Parse(txtTankDiameter.Text) : 0;
            else if (diameter == "in") tank.TANK_DIAMETTER = txtTankDiameter.Text != "" ? (float)(double.Parse(txtTankDiameter.Text) * convUnit.inch) : 0; // in sang mm
            else tank.TANK_DIAMETTER = txtTankDiameter.Text != "" ? float.Parse(txtTankDiameter.Text) * 1000 : 0; // m sang mm
            tank.TANK_DIAMETTER = txtTankDiameter.Text != "" ? float.Parse(txtTankDiameter.Text) : 0;
            tank.Prevention_Barrier = chkPreventionBarrier.Checked ? 1 : 0;
            tank.SHELL_COURSE_HEIGHT = txtShellCourseHeight.Text != "" ? float.Parse(txtShellCourseHeight.Text) : 0;
            return tank;
        }
        private void addItemsBrinnellHardness()
        {
            cbMaxBrillnessHardness.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsBrinnellHardness.Length; i++)
            {
                cbMaxBrillnessHardness.Properties.Items.Add(itemsBrinnellHardness[i], i, i);
            }
        }
        #region Key Press Event

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

        private void txtTankDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtTankDiameter, e);
        }

        private void txtCurrentThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCurrentThickness, e);
        }

        private void txtCurrentCorrosionRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCurrentCorrosionRate, e);
        }

        private void txtShellCourseHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtShellCourseHeight, e);
        }

        private void txtNominalThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtNominalThickness, e);
        }

        private void txtMinRequiredThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMinRequiredThickness, e);
        }
        #endregion

        #region Xu ly su kien data thay doi

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

        private void KeyPress1(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                CtrlSPress++;
            }
        }
        private void txtTankDiameter_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
        }

        private void txtTankDiameter_KeyDown(object sender, KeyEventArgs e)
        {
            KeyPress1(e);
        }
        #endregion
    }
}
