using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
using RBI.BUS.BUSMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmEquipment : Form
    {
        SITES_BUS siteBus = new SITES_BUS();
        List<SITES> listSite = new List<SITES>();
        FACILITY_BUS faciBus = new FACILITY_BUS();
        List<FACILITY> listFacility = new List<FACILITY>();
        List<EQUIPMENT_TYPE> listEquipType = new List<EQUIPMENT_TYPE>();
        EQUIPMENT_TYPE_BUS equipType = new EQUIPMENT_TYPE_BUS();
        EQUIPMENT_MASTER_BUS equipMasterBus = new EQUIPMENT_MASTER_BUS();
        List<EQUIPMENT_MASTER> listEquipmentMaster = new List<EQUIPMENT_MASTER>();
        List<DESIGN_CODE> listDesignCode = new List<DESIGN_CODE>();
        DESIGN_CODE_BUS designCodeBus = new DESIGN_CODE_BUS();
        List<MANUFACTURER> listManufacture = new List<MANUFACTURER>();
        MANUFACTURER_BUS manuBus = new MANUFACTURER_BUS();
        private String siteName;
        private String facilityName;
        public bool ButtonOKCliked { set; get; }
        public bool doubleEditClicked { set; get; }
        private int EquipmentID = 0;
        private string oldName;
        public frmEquipment()
        {
            InitializeComponent();
            addDatatoControl();
        }
        public frmEquipment(int ID)
        {
            InitializeComponent();
            this.EquipmentID = ID;
            ShowDatatoControl(ID);
            cbEquipmentType.Enabled = false;
            oldName = txtEquipmentNumber.Text;
            label9.Text = "Edit Equipment";
        }
        public frmEquipment(String siteName, String facilityName)
        {
            InitializeComponent();
            this.siteName = siteName;
            this.facilityName = facilityName;
            addDatatoControl();
        }
        private void ShowDatatoControl(int ID)
        {
            EQUIPMENT_MASTER eq = equipMasterBus.getData(ID);
            //lay toan bo equipment type name
            List<string> eqTypeName = equipType.getListEquipmentTypeName();
            txtEquipmentNumber.Text = eq.EquipmentNumber;
            cbEquipmentType.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < eqTypeName.Count; i++)
            {
                cbEquipmentType.Properties.Items.Add(eqTypeName[i], i, i);
                if (eqTypeName[i] == equipType.getEquipmentTypeName(eq.EquipmentTypeID))
                {
                    cbEquipmentType.SelectedIndex = i + 1;
                }
            }
            txtEquipmentName.Text = eq.EquipmentName;
            //Site
            List<string> listSite = siteBus.getListSiteName();
            cbSite.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listSite.Count; i++)
            {
                cbSite.Properties.Items.Add(listSite[i], i, i);
                if (siteBus.getSiteName(eq.SiteID) == listSite[i])
                {
                    cbSite.SelectedIndex = i + 1;
                }
            }
            cbSite.Enabled = false;

            //Facility
            List<string> listFacility = faciBus.getListFacilityName(eq.SiteID);
            cbFacility.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listFacility.Count; i++)
            {
                cbFacility.Properties.Items.Add(listFacility[i], i, i);
                if (listFacility[i] == faciBus.getFacilityName(eq.FacilityID))
                {
                    cbFacility.SelectedIndex = i + 1;
                }
            }
            cbFacility.Enabled = false;

            //Design Code
            List<string> listDesignCode = designCodeBus.getListDesignCodeName();
            cbDesignCode.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listDesignCode.Count; i++)
            {
                cbDesignCode.Properties.Items.Add(listDesignCode[i], i, i);
                if (listDesignCode[i] == designCodeBus.getDesignCodeName(eq.DesignCodeID))
                {
                    cbDesignCode.SelectedIndex = i + 1;
                }
            }
            //Manu
            List<string> listManu = manuBus.getListManufactureName();
            cbManufacturer.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listManu.Count; i++)
            {
                cbManufacturer.Properties.Items.Add(listManu[i], i, i);
                if (listManu[i] == manuBus.getManuName(eq.ManufacturerID))
                {
                    cbManufacturer.SelectedIndex = i + 1;
                }
            }
            dateCommission.DateTime = eq.CommissionDate;
            txtPDFNo.Text = eq.PFDNo;
            txtProcessDescription.Text = eq.ProcessDescription;
            txtDescription.Text = eq.EquipmentDesc;
        }
        private void addDatatoControl()
        {
            //add site name to combobox
            listSite = siteBus.getData();
            cbSite.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listSite.Count; i++)
            {
                cbSite.Properties.Items.Add(listSite[i].SiteName, i, i);
                if (listSite[i].SiteName == siteName)
                {
                    cbSite.SelectedIndex = i + 1;
                }
            }
            //add facility name to combobox
            if (this.siteName != null || this.siteName != "")
            {
                int _siteID = siteBus.getIDbyName(this.siteName);
                List<string> _faciName = faciBus.getListFacilityName(_siteID);
                cbFacility.Properties.Items.Clear();
                cbFacility.Properties.Items.Add("", -1, -1);
                for (int i = 0; i < _faciName.Count; i++)
                {
                    cbFacility.Properties.Items.Add(_faciName[i], i, i);
                    if (_faciName[i] == facilityName)
                    {
                        cbFacility.SelectedIndex = i + 1;
                    }
                }
            }
            //add equipment type
            listEquipType = equipType.getDataSource();
            cbEquipmentType.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listEquipType.Count; i++)
            {
                cbEquipmentType.Properties.Items.Add(listEquipType[i].EquipmentTypeName, i, i);
            }
            //add manufacturer
            listManufacture = manuBus.getDataSource();
            cbManufacturer.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listManufacture.Count; i++)
            {
                cbManufacturer.Properties.Items.Add(listManufacture[i].ManufacturerName, i, i);
            }
            //add design code
            listDesignCode = designCodeBus.getDataSource();
            cbDesignCode.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listDesignCode.Count; i++)
            {
                cbDesignCode.Properties.Items.Add(listDesignCode[i].DesignCode, i, i);
            }
        }
        private EQUIPMENT_MASTER getDataEquipmentMaster()
        {
            EQUIPMENT_MASTER eqMaster = new EQUIPMENT_MASTER();
            if (doubleEditClicked)
            {
                eqMaster.EquipmentID = this.EquipmentID;
            }
            eqMaster.SiteID = siteBus.getIDbyName(cbSite.Text);
            eqMaster.FacilityID = faciBus.getIDbyName_SiteID(eqMaster.SiteID, cbFacility.Text);
            eqMaster.EquipmentTypeID = equipType.getIDbyName(cbEquipmentType.Text);
            eqMaster.DesignCodeID = designCodeBus.getIDbyName(cbDesignCode.Text);
            eqMaster.ManufacturerID = manuBus.getIDbyName(cbManufacturer.Text);
            eqMaster.EquipmentNumber = txtEquipmentNumber.Text;
            eqMaster.EquipmentName = txtEquipmentName.Text;
            eqMaster.CommissionDate = dateCommission.DateTime;
            eqMaster.PFDNo = txtPDFNo.Text;
            eqMaster.ProcessDescription = txtProcessDescription.Text;
            eqMaster.EquipmentDesc = txtDescription.Text;
            eqMaster.IsArchived = 1;
            eqMaster.Archived = DateTime.Now;
            return eqMaster;
        }
        public EQUIPMENT_TYPE getDataEquipmentType()
        {
            EQUIPMENT_TYPE eqType = new EQUIPMENT_TYPE();
            eqType.EquipmentTypeName = cbEquipmentType.Text;
            return eqType;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtEquipmentNumber.Text == "" || cbEquipmentType.Text == "" || dateCommission.DateTime == null || cbDesignCode.Text == "" || cbManufacturer.Text == "")
                return;
            EQUIPMENT_MASTER_BUS bs = new EQUIPMENT_MASTER_BUS();
            List<string> eqNum = bs.getListEquipmentNumber();
            foreach(string s in eqNum)
            {
                if (s == txtEquipmentNumber.Text && s != oldName)
                {
                    MessageBox.Show("Equipment number already exists!", "Cortek", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (doubleEditClicked)
            {
                bs.edit(getDataEquipmentMaster());
            }
            else
            {
                bs.add(getDataEquipmentMaster());
            }
            ButtonOKCliked = true;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        frmDesignCode design = new frmDesignCode();
        private void btnAddNewDesignCode_Click(object sender, EventArgs e)
        {
            design.ShowDialog();
        }
        private void btnAddSite_Click(object sender, EventArgs e)
        {
            frmNewSite site = new frmNewSite();
            site.ShowDialog();
        }
        private void btnAddFacility_Click(object sender, EventArgs e)
        {
            frmFacilityInput faci = new frmFacilityInput();
            faci.ShowDialog();
        }
        frmNewManufacturer manu = new frmNewManufacturer();
        private void btnManufacturer_Click(object sender, EventArgs e)
        {
            manu.ShowDialog();
        }

        private void cbDesignCode_Click(object sender, EventArgs e)
        {
            if (design.ButtonOKClicked)
            {
                List<DESIGN_CODE> listDesignCode1 = new List<DESIGN_CODE>();
                DESIGN_CODE_BUS designCode1 = new DESIGN_CODE_BUS();
                listDesignCode1 = designCode1.getDataSource();
                cbDesignCode.Properties.Items.Add("", -1, -1);
                for (int i = 0; i < listDesignCode.Count; i++)
                {
                    cbDesignCode.Properties.Items.Add(listDesignCode1[i].DesignCode, i, i);
                }
            }
        }

        private void cbManufacturer_Click(object sender, EventArgs e)
        {
            if (manu.ButtonOKClicked)
            {
                MANUFACTURER_BUS manuBus = new MANUFACTURER_BUS();
                List<MANUFACTURER> _manu = manuBus.getDataSource();
                cbManufacturer.Properties.Items.Add("", -1, -1);
                for (int i = 0; i < _manu.Count; i++)
                {
                    cbManufacturer.Properties.Items.Add(_manu[i].ManufacturerName, i, i);
                }
            }
        }

        #region Event of Control
        private void txtEquipmentNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtEquipmentNumber.Text == "") picEquipNumber.Show();
            else picEquipNumber.Hide();
        }

        private void cbEquipmentType_TextChanged(object sender, EventArgs e)
        {
            if (cbEquipmentType.Text == "") picEquipType.Show();
            else picEquipType.Hide();
        }

        private void cbManufacturer_TextChanged(object sender, EventArgs e)
        {
            if (cbManufacturer.Text == "") picManufacturer.Show();
            else picManufacturer.Hide();
        }

        private void dateCommission_TextChanged(object sender, EventArgs e)
        {
            if (dateCommission.DateTime == null) picCommissionDate.Show();
            else picCommissionDate.Hide();
        }

        private void txtEquipmentNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void cbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbManufacturer.Text == "") picManufacturer.Show();
            else picManufacturer.Hide();
        }

        private void cbDesignCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDesignCode.Text == "") picDesignCode.Show();
            else picDesignCode.Hide();
        }
        private void cbSite_SelectedValueChanged(object sender, EventArgs e)
        {
            int siteID = siteBus.getIDbyName(cbSite.Text);
            List<string> faciName = faciBus.getListFacilityName(siteID);
            cbFacility.Properties.Items.Clear();
            cbFacility.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < faciName.Count; i++)
            {
                cbFacility.Properties.Items.Add(faciName[i], i, i);
            }
            if (cbSite.Text != "")
            {
                btnAddFacility.Enabled = true;
                cbFacility.Enabled = true;
            }
            else
            {
                btnAddFacility.Enabled = false;
                cbFacility.Enabled = false;
            }
        }
        #endregion

        private void frmEquipment_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
