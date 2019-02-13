using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL_CAL;
using RBI.BUS.BUSMSSQL_CAL;
using RBI.Object.ObjectMSSQL;
using RBI.BUS.BUSMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCCA : UserControl
    {
        
        BUS_TOXIC bus = new BUS_TOXIC();
        MSSQL_CA_CAL BUS_CA = new MSSQL_CA_CAL();
        string[] itemsFluid = {"Acid","AlCl3","C1-C2","C13-C16","C17-C25","C25+","C3-C4","C5", "C6-C8","C9-C12","CO","DEE","EE","EEA","EG","EO","H2","H2S","HCl","HF","Methanol","Nitric Acid","NO2","Phosgene","PO","Pyrophoric","Steam","Styrene","TDI","Water"};
        string[] itemsFluidPhase = { "Liquid", "Vapor", "Two-phase" };
        string[] itemsDetectionType = { "A", "B", "C" };
        string[] itemsMittigationSystem = {"Fire water deluge system and monitors", "Fire water monitors only", "Foam spray system","Inventory blowdown, couple with isolation system classification B or higher"};
        string[] itemsFrammable = { "C1-C2", "C3-C4", "C5", "C6-C8", "C9-C12", "C13-C16", "C17-C25", "C25+", "H2", "H2S", "HF", "CO", "DEE", "Methanol", "PO", "Styrene", "Aromatics", "EEA", "EE", "EG", "EO" };
        string[] itemsToxic = { "H2S", "HF", "CO", "HCl", "Nitric Acid", "AlCl3", "NO2", "Phosgene", "TDI", "PO", "EE", "EO", "Ammonia", "Chlorine" };
        string[] itemsNoneTF = { "Steam", "Acid", "Caustic" };
        string[] itemsIsulationType = { "A", "B", "C" };
        List<String> timeDuration;
        string ReleasePhase;
        public UCCA()
        {
            InitializeComponent();
            cbReleaseDuration.Enabled = false;
            additemsFluid();
            additemsFluidPhase();
            additemsDetectionType();
            additemsMittigationSystem();
            additemsIsulationType();
        }
        public UCCA(int ID)
        {
            InitializeComponent();
            additemsFluid();
            additemsFluidPhase();
            additemsDetectionType();
            additemsMittigationSystem();
            additemsIsulationType();
            ShowDataToControl(ID);
        }
        public UCCA(int ID, string finacialUnit)
        {
            InitializeComponent();
            additemsFluid();
            additemsFluidPhase();
            additemsDetectionType();
            additemsMittigationSystem();
            additemsIsulationType();
            ShowDataToControl(ID);
            lblEnvCost.Text = finacialUnit + "/Event";
            lblEqCost.Text = finacialUnit + "/m2";
            lblProductionCost.Text = finacialUnit + "/Day";
            lblInjureCost.Text = finacialUnit + "/Fatality";
        }
        private void ShowDataToControl(int ID)
        {
            RW_INPUT_CA_LEVEL_1_BUS caBus = new RW_INPUT_CA_LEVEL_1_BUS();
            RW_INPUT_CA_LEVEL_1 ca = caBus.getData(ID);
            txtEquipmentCost.Text = ca.Equipment_Cost.ToString();
            txtProductionCost.Text = ca.Production_Cost.ToString();
            txtInjureCost.Text = ca.Injure_Cost.ToString();
            txtEnvironmentCost.Text = ca.Environment_Cost.ToString();
            txtMassInvert.Text = ca.Mass_Inventory.ToString();
            txtMassComponent.Text = ca.Mass_Component.ToString();
            txtToxicPercent.Text = ca.Toxic_Percent.ToString();
            txtPersonDensity.Text = ca.Personal_Density.ToString();
            for (int i = 0; i < itemsFluid.Length; i++)
            {
                if (itemsFluid[i] == ca.API_FLUID)
                {
                    cbFluid.SelectedIndex = i + 1;
                    break;
                }
            }
            for (int i = 0; i < itemsFluidPhase.Length; i++)
            {
                if (itemsFluidPhase[i] == ca.SYSTEM)
                {
                    cbFluidPhase.SelectedIndex = i + 1;
                    break;
                }
            }
            //for(int i = 0; i < itemsRe)
            setUpReleaseDuration();
            for(int i = 0; i< timeDuration.Count; i++)
            {
                if(ca.Release_Duration == timeDuration[i])
                {
                    cbReleaseDuration.SelectedIndex = i + 1;
                }
            }
            //cbReleaseDuration.SelectedItem = ca.Release_Duration;

            for (int i = 0; i < itemsMittigationSystem.Length; i++)
            {
                if (itemsMittigationSystem[i] == ca.Mitigation_System)
                {
                    cbMittigationSystem.SelectedIndex = i + 1;
                    break;
                }
            }
            for (int i = 0; i < itemsDetectionType.Length; i++)
            {
                if (itemsDetectionType[i] == ca.Detection_Type)
                {
                    cbDetectionType.SelectedIndex = i + 1;
                    break;
                }
            }
            for (int i = 0; i < itemsIsulationType.Length; i++)
            {
                if (itemsIsulationType[i] == ca.Isulation_Type)
                {
                    cbIsulationType.SelectedIndex = i + 1;
                    break;
                }
            }
        }
        public RW_INPUT_CA_LEVEL_1 getData(int ID)
        {
            RW_INPUT_CA_LEVEL_1 ca = new RW_INPUT_CA_LEVEL_1();
            ca.ID = ID;
            ca.API_FLUID = cbFluid.Text;
            ca.SYSTEM = cbFluidPhase.Text;
            ca.Equipment_Cost = txtEquipmentCost.Text != "" ? float.Parse(txtEquipmentCost.Text) : 0;
            ca.Production_Cost = txtProductionCost.Text != "" ? float.Parse(txtProductionCost.Text) : 0;
            ca.Injure_Cost = txtInjureCost.Text != "" ? float.Parse(txtInjureCost.Text) : 0;
            ca.Environment_Cost = txtEnvironmentCost.Text != "" ? float.Parse(txtEnvironmentCost.Text) : 0;
            ca.Detection_Type = cbDetectionType.Text;
            ca.Isulation_Type = cbIsulationType.Text;
            ca.Mass_Inventory = txtMassInvert.Text != "" ? float.Parse(txtMassInvert.Text) : 0;
            ca.Mass_Component = txtMassComponent.Text != "" ? float.Parse(txtMassComponent.Text) : 0;
            ca.Mitigation_System = cbMittigationSystem.Text;
            ca.Toxic_Percent = txtToxicPercent.Text != "" ? float.Parse(txtToxicPercent.Text) : 0;
            ca.Release_Duration = cbReleaseDuration.Text;
            ca.Personal_Density = txtPersonDensity.Text != "" ? float.Parse(txtPersonDensity.Text) : 0;
            return ca;
        }
        public RW_INPUT_CA_TANK getDataCATank()
        {
            RW_INPUT_CA_TANK ca = new RW_INPUT_CA_TANK();
            ca.API_FLUID = cbFluid.Text;
            return ca;
        }
        
        private void additemsIsulationType()
        {
            cbIsulationType.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsIsulationType.Length; i++)
            {
                cbIsulationType.Properties.Items.Add(itemsIsulationType[i], i, i);
            }
        }
        private void additemsFluid()
        {
            cbFluid.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsFluid.Length; i++)
            {
                cbFluid.Properties.Items.Add(itemsFluid[i], i, i);
            }
        }
        private void additemsFluidPhase()
        {
            cbFluidPhase.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsFluidPhase.Length; i++)
            {
                cbFluidPhase.Properties.Items.Add(itemsFluidPhase[i], i, i);
            }
        }
        private void additemsDetectionType()
        {
            cbDetectionType.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsDetectionType.Length; i++)
            {
                cbDetectionType.Properties.Items.Add(itemsDetectionType[i], i, i);
            }
        }
        private void additemsMittigationSystem()
        {
            cbMittigationSystem.Properties.Items.Add("", -1, -1);
            for(int i = 0; i < itemsMittigationSystem.Length; i++)
            {
                cbMittigationSystem.Properties.Items.Add(itemsMittigationSystem[i], i, i);
            }
        }
        private void clearData()
        {
            cbReleaseDuration.Properties.Items.Clear();
        }
        private void cbFluid_SelectedIndexChanged(object sender, EventArgs e)
        {
            //timeDuration = new List<string>();
            //List<TOXIC_511_512> list511 = bus.getList511_512();
            //List<TOXIC_513> list513 = bus.getList513();
            //if (cbFluidPhase.Text == "Vapor" || cbFluidPhase.Text == "Powder")
            //{
            //    ReleasePhase = "Gas";
            //}
            //else if (cbFluidPhase.Text == "Liquid")
            //{
            //    ReleasePhase = "Liquid";
            //}
            //else
            //{
            //    ReleasePhase = "";
            //}
            //if (cbFluid.Text == "H2S" || cbFluid.Text == "HF" || cbFluid.Text == "Ammonia" || cbFluid.Text == "Chlorine")
            //{
            //    for (int i = 0; i < list511.Count; i++)
            //    {
            //        if (cbFluid.Text == list511[i].ToxicName)
            //        {
            //            timeDuration.Add(list511[i].ReleaseDuration);
            //        }
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < list513.Count; i++)
            //    {
            //        if (cbFluid.Text == list513[i].TOXIC_NAME && ReleasePhase == list513[i].TOXIC_TYPE)
            //        {
            //            timeDuration.Add(list513[i].DURATION);
            //        }
            //    }
            //}
            //if (timeDuration.Count != 0)
            //{
            //    txtToxicPercent.Enabled = true;
            //}
            //else
            //{
            //    txtToxicPercent.Enabled = false;
            //}
            //clearData();
            //cbReleaseDuration.Properties.Items.Add("", -1, -1);
            //for (int i = 0; i < timeDuration.Count; i++)
            //{
            //    cbReleaseDuration.Properties.Items.Add(timeDuration[i], i, i);
            //}
            setUpReleaseDuration();
        }
        private void cbFluidPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            //timeDuration = new List<string>();
            //List<TOXIC_511_512> list511 = bus.getList511_512();
            //List<TOXIC_513> list513 = bus.getList513();
            //if (cbFluidPhase.Text == "Vapor")
            //{
            //    ReleasePhase = "Gas";
            //}
            //else if (cbFluidPhase.Text == "Liquid" || cbFluidPhase.Text == "Powder")
            //{
            //    ReleasePhase = "Liquid";
            //}
            //else
            //{
            //    ReleasePhase = "";
            //}
            //if (cbFluid.Text == "H2S" || cbFluid.Text == "HF" || cbFluid.Text == "Ammonia" || cbFluid.Text == "Chlorine")
            //{
            //    for (int i = 0; i < list511.Count; i++)
            //    {
            //        if (cbFluid.Text == list511[i].ToxicName)
            //        {
            //            timeDuration.Add(list511[i].ReleaseDuration);
            //        }
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < list513.Count; i++)
            //    {
            //        if (cbFluid.Text == list513[i].TOXIC_NAME && ReleasePhase == list513[i].TOXIC_TYPE)
            //        {
            //            timeDuration.Add(list513[i].DURATION);
            //        }
            //    }
            //}
            //if (timeDuration.Count != 0)
            //{
            //    txtToxicPercent.Enabled = true;
            //}
            //else
            //{
            //    txtToxicPercent.Enabled = false;
            //}
            //clearData();
            //cbReleaseDuration.Properties.Items.Add("", -1, -1);
            //for (int i = 0; i < timeDuration.Count; i++)
            //{
            //    cbReleaseDuration.Properties.Items.Add(timeDuration[i], i, i);
            //}
            setUpReleaseDuration();
        }
        private void setUpReleaseDuration()
        {
            timeDuration = new List<string>();
            cbReleaseDuration.Enabled = false;
            List<TOXIC_511_512> list511 = bus.getList511_512();
            List<TOXIC_513> list513 = bus.getList513();
            if (cbFluidPhase.Text == "Vapor")
            {
                ReleasePhase = "Gas";
            }
            else if (cbFluidPhase.Text == "Liquid" || cbFluidPhase.Text == "Powder")
            {
                ReleasePhase = "Liquid";
            }
            else
            {
                ReleasePhase = "";
            }
            if (cbFluid.Text == "H2S" || cbFluid.Text == "HF" || cbFluid.Text == "Ammonia" || cbFluid.Text == "Chlorine")
            {
                for (int i = 0; i < list511.Count; i++)
                {
                    if (cbFluid.Text == list511[i].ToxicName)
                    {
                        cbReleaseDuration.Enabled = true;
                        timeDuration.Add(list511[i].ReleaseDuration);
                    }
                }
            }
            else
            {
                for (int i = 0; i < list513.Count; i++)
                {
                    if (cbFluid.Text == list513[i].TOXIC_NAME && ReleasePhase == list513[i].TOXIC_TYPE)
                    {
                        cbReleaseDuration.Enabled = true;
                        timeDuration.Add(list513[i].DURATION);
                    }
                }
            }
            if (timeDuration.Count != 0)
            {
                txtToxicPercent.Enabled = true;
            }
            else
            {
                txtToxicPercent.Enabled = false;
            }
            clearData();
            cbReleaseDuration.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < timeDuration.Count; i++)
            {
                cbReleaseDuration.Properties.Items.Add(timeDuration[i], i, i);
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
        private void txtEquipmentCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtEquipmentCost, e);
        }

        private void txtProductionCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtProductionCost, e);
        }

        private void txtInjureCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtInjureCost, e);
        }

        private void txtEnvironmentCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtEnvironmentCost, e);
        }

        private void txtMassInvert_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMassInvert, e);
        }

        private void txtMassComponent_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtMassComponent, e);
        }
        private void txtToxicPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtToxicPercent, e);
        }

        private void txtPersonDensity_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPressEvent(txtPersonDensity, e);
        }

        private void txtToxicPercent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(float.Parse(txtToxicPercent.Text) > 100)
                {
                    MessageBox.Show("Invalid value", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtToxicPercent.Text = "100";
                }
            }
            catch
            {
                txtToxicPercent.Text = "0";
            }
        }
        #endregion

        //du lieu cho Release Duration anh Vu viet
        /*
         * Khi nhap du lieu chu y cac diem sau:
         * 1. du lieu ap suat cua RW la Psi , du lieu ta can la kPa: 1Psi = 6.895 kPa( nen dat trong form nay)
         * 2. Cac du lieu ve khi quyen co the bo qua: P_atm = 101 kPa, T_atm = 27*C( nen ap truc tiep, trong form nay)
         * 3. Nhiet do tinh theo do K nen( co the xu ly trong CODE tinh CA): AIT, STORAGE_TEMP
         * 4. Nen Suy nghi co nen them 2 muc khac cho Toxic va NoneFlameNoneToxic hay k?( neu them thi cong them cac gia tri % khac de tinh)
         * 
         * */
    }
}
