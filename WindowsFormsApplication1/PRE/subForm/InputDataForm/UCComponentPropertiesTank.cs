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
    public partial class UCComponentPropertiesTank : UserControl
    {
        string[] itemsSeverity = { "None", "Low", "Medium", "High" };
        string[] itemsBrinnellHardness = { "Below 200", "Between 200 and 237", "Greater than 237" };
        string[] itemsComplexityProtrusion = { "Above average", "Average", "Below average" };
        private int datachange = 0;
        private int ctrlSpress = 0;
        public UCComponentPropertiesTank()
        {
            InitializeComponent();
        }
        public UCComponentPropertiesTank(int ID, string type)
        {
            InitializeComponent();
            ShowDataToControl(ID);
            if (type == "Shell")
            {
                chkConcreteAsphalt.Enabled = false;
                chkPreventionBarrier.Enabled = false;
            }
            else
                txtShellCourseHeight.Enabled = false;
        }
        private void ShowDataToControl(int ID)
        {
            RW_COMPONENT_BUS busCom = new RW_COMPONENT_BUS();
            RW_COMPONENT com = busCom.getData(ID);
            txtTankDiameter.Text = com.NominalDiameter.ToString();
            txtCurrentThickness.Text = com.CurrentThickness.ToString();
            txtCurrentCorrosionRate.Text = com.CurrentCorrosionRate.ToString();
            txtShellCourseHeight.Text = com.ShellHeight.ToString();
            txtNominalThickness.Text = com.NominalThickness.ToString();
            chkDamageFoundDuringInspection.Checked = com.DamageFoundInspection == 1 ? true : false;
            chkConcreteAsphalt.Checked = com.ConcreteFoundation == 1 ? true : false;
            chkPresenceCracks.Checked = com.CracksPresent == 1 ? true : false;
            chkPreventionBarrier.Checked = com.ReleasePreventionBarrier == 1 ? true : false;
            chkTrampElements.Checked = com.TrampElements == 1 ? true : false;
            txtMinRequiredThickness.Text = com.MinReqThickness.ToString();
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
        public RW_COMPONENT getData(int ID)
        {
            RW_COMPONENT comp = new RW_COMPONENT();
            comp.ID = ID;
            comp.NominalDiameter = txtTankDiameter.Text != "" ? float.Parse(txtTankDiameter.Text) : 0;
            comp.NominalThickness = txtNominalThickness.Text != "" ? float.Parse(txtNominalThickness.Text) : 0;
            comp.CurrentThickness = txtCurrentThickness.Text != "" ? float.Parse(txtCurrentThickness.Text) : 0;
            comp.MinReqThickness = txtMinRequiredThickness.Text != "" ? float.Parse(txtMinRequiredThickness.Text) : 0;
            comp.CurrentCorrosionRate = txtCurrentCorrosionRate.Text != "" ? float.Parse(txtCurrentCorrosionRate.Text) : 0;
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

        public RW_INPUT_CA_TANK getDataforTank(int ID)
        {
            RW_INPUT_CA_TANK tank = new RW_INPUT_CA_TANK();
            tank.ID = ID;
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
