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
    public partial class UCComponentProperties : UserControl
    {
        #region Parameter
        string[] itemsBrinnellHardness = { "Below 200", "Between 200 and 237", "Greater than 237" };
        //string[] itemsInsulationCondition = { "Above average", "Average", "Below average" };
        string[] itemsProtrusionComplexity = { "Above average", "Average", "Below average" };
        string[] itemsCyclicLoading = { "None", "PRV chatter", "Reciprocating machinery", "Valve with high pressure drop" };
        string[] itemsBranchDiameter = {"Any branch less than or equal to 2\" Nominal OD", "All branches greater than 2\" Nominal OD"};
        string[] itemsBranchJointType = {"None","Piping tee weldolets", "Saddle in fittings", "Sweepolets", "Threaded, socket welded, or saddle on"};
        string[] itemsNumberPipeFittings = {"More than 10", "6 to 10", "Up to 5"};
        string[] itemsPipeCondition = { "Broken gussets or gussets welded directly to pipe", "Good condition","Missing or damage supports, improper support"};
        string[] itemsPreviousFailure = {"Greater than one", "None", "One"};
        string[] itemsAmountShaking = { "Minor", "Moderate", "Severe" };
        string[] itemsAccumulatedTimeShaking = {"13 to 52 weeks", "2 to 13 weeks", "Less than 2 weeks"};
        string[] itemsCorrectiveAction = { "Engineering Analysis", "Experience", "None" };
        private int datachange = 0;
        private int ctrlSpress = 0;
        #endregion

        //public UCComponentProperties(int ID)
        //{
          //   InitializeComponent();
         //   additemsBrinnellHardness();
         //   additemsProtrusionComplexity();
         //   additemsCyclicLoading();
         //  additemsBranchDiameter();
            //additemsBranchJointType();
            //additemsNumberPipeFittings();
            //additemsPipeCondition();
            //additemsPreviousFailure();
            //additemsAmountShaking();
            //additemsAccumulatedTimeShaking();
            //additemsCorrectiveAction();
            //ShowDatatoControl(ID);
         //}
        
        public UCComponentProperties(int ID, string diameterUnit, string thicknessUnit, string corrosionRateUnit)
        {
            InitializeComponent();
            additemsBrinnellHardness();
            additemsProtrusionComplexity();
            additemsCyclicLoading();
            additemsBranchDiameter();
            additemsBranchJointType();
            additemsNumberPipeFittings();
            additemsPipeCondition();
            additemsPreviousFailure();
            additemsAmountShaking();
            additemsAccumulatedTimeShaking();
            additemsCorrectiveAction();
            ShowDatatoControl(ID, diameterUnit, thicknessUnit, corrosionRateUnit);
            lblDiameter.Text = diameterUnit;
            lblCurrentThickness.Text = lblNominalThickness.Text = lblMinReqThickness.Text = thicknessUnit;
            lblCorrosionRate.Text = corrosionRateUnit;
        }

        public void ShowDatatoControl(int ID, string diameter, string thickness, string corrosionRate)
        {
            RW_COMPONENT_BUS comBus = new RW_COMPONENT_BUS();
            BUS_UNITS convUnit = new BUS_UNITS();
            List<RW_COMPONENT> listComponent = comBus.getDataSource();
            foreach (RW_COMPONENT comp in listComponent)
            {
                if (comp.ID == ID)
                {
                    ////// mai
                    if (diameter == "in") txtNominalDiameter.Text = (comp.NominalDiameter / convUnit.inch).ToString(); // converst mm sang in
                    else if (diameter == "mm") txtNominalDiameter.Text = comp.NominalDiameter.ToString(); // giữ nguyên
                    else txtNominalDiameter.Text = (comp.NominalDiameter/1000).ToString(); // converst mm sang m
                    if (thickness == "mm") 
                    {
                        txtNominalThickness.Text = comp.NominalThickness.ToString(); //giữ nguyên
                        txtCurrentThickness.Text = comp.CurrentThickness.ToString();// giữ nguyên
                        txtMinRequiredThickness.Text = comp.MinReqThickness.ToString();//  giữ nguyên
                    }
                    else if (thickness == "in")
                    {
                        txtNominalThickness.Text = (comp.NominalThickness / convUnit.inch).ToString(); //converst mm sang in
                        txtCurrentThickness.Text = (comp.CurrentThickness / convUnit.inch).ToString(); //converst mm sang in
                        txtMinRequiredThickness.Text = (comp.MinReqThickness / convUnit.inch).ToString(); //converst mm sang in
                    }
                    else
                    {
                        txtNominalThickness.Text = (comp.NominalThickness / 1000).ToString(); // converst mm sang m
                        txtCurrentThickness.Text = (comp.CurrentThickness/ 1000).ToString(); // converst mm sang m
                        txtMinRequiredThickness.Text = (comp.MinReqThickness / 1000).ToString(); // converst mm sang m
                    } 

                    if (corrosionRate == "mm/yr") txtCurrentCorrosionRate.Text = comp.CurrentCorrosionRate.ToString(); // converst mm sang mm
                    else txtCurrentCorrosionRate.Text = (comp.CurrentCorrosionRate/convUnit.mil).ToString(); // converst mm sang mil

                    //// end mai

                    chkPresenceCracks.Checked = comp.CracksPresent == 1 ? true : false;
                    chkPresenceInjectionMixPoint.Checked = comp.ChemicalInjection == 1 ? true : false;
                    chkHighlyEffectiveMixPoint.Checked = comp.HighlyInjectionInsp == 1 ? true : false;
                    chkDamageFoundDuringInspection.Checked = comp.DamageFoundInspection == 1 ? true : false;
                    txtDeltaFATT.Text = comp.DeltaFATT.ToString();
                    chkVisibleAudible.Checked = comp.ShakingDetected == 1 ? true : false;
                    chkTrampElements.Checked = comp.TrampElements == 1 ? true : false;

                    for (int i = 0; i < itemsAccumulatedTimeShaking.Length; i++)
                    {
                        if (comp.ShakingTime == itemsAccumulatedTimeShaking[i])
                            cbAccumalatedTimeShakingPipe.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsCorrectiveAction.Length; i++)
                    {
                        if (comp.CorrectiveAction == itemsCorrectiveAction[i])
                            cbCorrectiveAction.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsCyclicLoading.Length; i++)
                    {
                        if (comp.CyclicLoadingWitin15_25m == itemsCyclicLoading[i])
                            cbCyclicLoading.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsBranchDiameter.Length; i++)
                    {
                        if (comp.BranchDiameter == itemsBranchDiameter[i])
                            cbBranchDiameter.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsBranchJointType.Length; i++)
                    {
                        if (comp.BranchJointType == itemsBranchJointType[i])
                            cbJointTypeBranch.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsBrinnellHardness.Length; i++)
                    {
                        if (comp.BrinnelHardness == itemsBrinnellHardness[i])
                            cbMaxBrillnessHardness.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsNumberPipeFittings.Length; i++)
                    {
                        if (comp.NumberPipeFittings == itemsNumberPipeFittings[i])
                            cbNumberFittingPipe.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsPipeCondition.Length; i++)
                    {
                        if (comp.PipeCondition == itemsPipeCondition[i])
                            cbPipeCondition.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsPreviousFailure.Length; i++)
                    {
                        if (comp.PreviousFailures == itemsPreviousFailure[i])
                            cbPreviousFailures.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsAmountShaking.Length; i++)
                    {
                        if (comp.ShakingAmount == itemsAmountShaking[i])
                            cbAmountShakingPipe.SelectedIndex = i + 1;
                    }
                    for (int i = 0; i < itemsProtrusionComplexity.Length; i++)
                    {
                        if (comp.ComplexityProtrusion == itemsProtrusionComplexity[i])
                            cbComplexityProtrusion.SelectedIndex = i + 1;
                    }
                }
            }
        }

        public RW_COMPONENT getData(int ID, string diameter, string thickness, string corrosionRate) // save vao base
        {
            RW_COMPONENT comp = new RW_COMPONENT();
            RW_ASSESSMENT_BUS assBus = new RW_ASSESSMENT_BUS();
            BUS_UNITS convUnit = new BUS_UNITS();
            comp.ID = ID;
            // mai
            if (diameter == "mm") comp.NominalDiameter = txtNominalDiameter.Text != "" ? float.Parse(txtNominalDiameter.Text) : 0;
            else if (diameter == "in") comp.NominalDiameter = txtNominalDiameter.Text != "" ? (float)(double.Parse(txtNominalDiameter.Text)*convUnit.inch) : 0; // in sang mm
            else comp.NominalDiameter = txtNominalDiameter.Text != "" ? float.Parse(txtNominalDiameter.Text)*1000 : 0; // m sang mm
            
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

            if (corrosionRate == "mm/yr") comp.CurrentCorrosionRate = txtCurrentCorrosionRate.Text != "" ? (float)double.Parse(txtCurrentCorrosionRate.Text) : 0;
            else comp.CurrentCorrosionRate = txtCurrentCorrosionRate.Text != "" ? (float)(double.Parse(txtCurrentCorrosionRate.Text) * convUnit.mil) : 0; // mil/yr sang mm/yr
            
            // end mai
            comp.BranchDiameter = cbBranchDiameter.Text;
            comp.BranchJointType = cbJointTypeBranch.Text;
            comp.BrinnelHardness = cbMaxBrillnessHardness.Text;
            comp.CracksPresent = chkPresenceCracks.Checked ? 1 : 0;
            comp.ComplexityProtrusion = cbComplexityProtrusion.Text;
            comp.ChemicalInjection = chkPresenceInjectionMixPoint.Checked ? 1 : 0;
            comp.HighlyInjectionInsp = chkHighlyEffectiveMixPoint.Checked ? 1 : 0;
            comp.CorrectiveAction = cbCorrectiveAction.Text;
            comp.CyclicLoadingWitin15_25m = cbCyclicLoading.Text;
            comp.DamageFoundInspection = chkDamageFoundDuringInspection.Checked ? 1 : 0;
            comp.DeltaFATT = txtDeltaFATT.Text != "" ? float.Parse(txtDeltaFATT.Text) : 0;
            comp.NumberPipeFittings = cbNumberFittingPipe.Text;
            comp.PipeCondition = cbPipeCondition.Text;
            comp.PreviousFailures = cbPreviousFailures.Text;
            comp.ShakingAmount = cbAmountShakingPipe.Text;
            comp.ShakingDetected = chkVisibleAudible.Checked ? 1 : 0;
            comp.ShakingTime = cbAccumalatedTimeShakingPipe.Text;
            comp.TrampElements = chkTrampElements.Checked ? 1 : 0;
            //comp.ShellHeight cua shell
            //comp.ReleasePreventionBarrier =  cua tank
            //comp.ConcreteFoundation = cua tank bottom
            //comp.SeverityOfVibration cua tank
            return comp;
        }

        #region Add Data to Combobox
        private void additemsBrinnellHardness()
        {
            cbMaxBrillnessHardness.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsBrinnellHardness.Length; i++)
            {
                cbMaxBrillnessHardness.Properties.Items.Add(itemsBrinnellHardness[i], i, i);
            }
        }
        private void additemsProtrusionComplexity()
        {
            cbComplexityProtrusion.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsProtrusionComplexity.Length; i++)
            {
                cbComplexityProtrusion.Properties.Items.Add(itemsProtrusionComplexity[i], i, i);
            }
        }
        private void additemsCyclicLoading()
        {
            cbCyclicLoading.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsCyclicLoading.Length; i++)
            {
                cbCyclicLoading.Properties.Items.Add(itemsCyclicLoading[i], i, i);
            }
        }
        private void additemsBranchDiameter()
        {
            cbBranchDiameter.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsBranchDiameter.Length; i++)
            {
                cbBranchDiameter.Properties.Items.Add(itemsBranchDiameter[i], i, i);
            }
        }

        private void additemsBranchJointType()
        {
            cbJointTypeBranch.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsBranchJointType.Length; i++)
            {
                cbJointTypeBranch.Properties.Items.Add(itemsBranchJointType[i], i, i);
            }
        }
        private void additemsNumberPipeFittings()
        {
            cbNumberFittingPipe.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsNumberPipeFittings.Length; i++)
            {
                cbNumberFittingPipe.Properties.Items.Add(itemsNumberPipeFittings[i], i, i);
            }
        }
        private void additemsPipeCondition()
        {
            cbPipeCondition.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsPipeCondition.Length; i++)
            {
                cbPipeCondition.Properties.Items.Add(itemsPipeCondition[i], i, i);
            }
        }
        private void additemsPreviousFailure()
        {
            cbPreviousFailures.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsPreviousFailure.Length; i++)
            {
                cbPreviousFailures.Properties.Items.Add(itemsPreviousFailure[i], i, i);
            }
        }
        private void additemsAmountShaking()
        {
            cbAmountShakingPipe.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsAmountShaking.Length; i++)
            {
                cbAmountShakingPipe.Properties.Items.Add(itemsAmountShaking[i], i, i);
            }
        }

        private void additemsAccumulatedTimeShaking()
        {
            cbAccumalatedTimeShakingPipe.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsAccumulatedTimeShaking.Length; i++)
            {
                cbAccumalatedTimeShakingPipe.Properties.Items.Add(itemsAccumulatedTimeShaking[i], i, i);
            }
        }
        private void additemsCorrectiveAction()
        {
            cbCorrectiveAction.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < itemsCorrectiveAction.Length; i++)
            {
                cbCorrectiveAction.Properties.Items.Add(itemsCorrectiveAction[i], i, i);
            }
        }
        #endregion
        
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
        private void txtNominalDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtNominalDiameter, e);
        }

        private void txtCurrentThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCurrentThickness, e);
        }

        private void txtCurrentCorrosionRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtCurrentCorrosionRate, e);
        }

        private void txtNominalThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtNominalThickness, e);
        }

        private void txtMinRequiredThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMinRequiredThickness, e);
        }

        private void txtDeltaFATT_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtDeltaFATT, e);
        }
        #endregion


        #region Xu ly su kien khi data thay doi
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
        private void txtNominalDiameter_TextChanged(object sender, EventArgs e)
        {
            DataChange++;
        }

        private void txtNominalDiameter_KeyDown(object sender, KeyEventArgs e)
        {
            KeyPress1(e);
        }
        #endregion

        
    }
}
