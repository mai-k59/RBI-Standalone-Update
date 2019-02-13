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
    public partial class frmNewComponent : Form
    {
        List<EQUIPMENT_MASTER> listEquipment = new List<EQUIPMENT_MASTER>();
        EQUIPMENT_MASTER_BUS equipmentBus = new EQUIPMENT_MASTER_BUS();
        List<API_COMPONENT_TYPE> listAPIComponent = new List<API_COMPONENT_TYPE>();
        API_COMPONENT_TYPE_BUS API_BUS = new API_COMPONENT_TYPE_BUS();
        List<COMPONENT_TYPE> listComponent = new List<COMPONENT_TYPE>();
        COMPONENT_TYPE__BUS componentBus = new COMPONENT_TYPE__BUS();
        List<DESIGN_CODE> listDesignCode = new List<DESIGN_CODE>();
        DESIGN_CODE_BUS designCodeBus = new DESIGN_CODE_BUS();
        List<SITES> listSite = new List<SITES>();
        SITES_BUS siteBus = new SITES_BUS();
        List<FACILITY> listFacility = new List<FACILITY>();
        FACILITY_BUS facilityBus = new FACILITY_BUS();
        COMPONENT_MASTER_BUS componentMaster_Bus = new COMPONENT_MASTER_BUS();
        public bool ButtonOKClicked { set; get; }
        public bool doubleEditClicked { set; get; }
        private int componentID = 0;
        private string equipmentNumber;
        private string facilityName;
        private string siteName;
        private string oldName;
        public frmNewComponent()
        {
            InitializeComponent();
            addDatatoControl();
        }
        public frmNewComponent(int ID) //COMPONENT ID
        {
            InitializeComponent();
            this.componentID = ID;
            ShowDataToControl(ID);
            cbAPIComponentType.Enabled = false;
            cbComponentType.Enabled = false;
            oldName = txtComponentNumber.Text;
            label5.Text = "Edit Component";
        }
        public frmNewComponent(string equipmentNumber, string facilityName, string siteName)
        {
            InitializeComponent();
            this.equipmentNumber = equipmentNumber;
            this.facilityName = facilityName;
            this.siteName = siteName;
            addDatatoControl();
        }
        private void ShowDataToControl(int ID)
        {
            COMPONENT_MASTER com = componentMaster_Bus.getData(ID);
            int eqID = componentMaster_Bus.getEquipmentID(ID);
            //Equipment Number
            List<string> eqNum = equipmentBus.getListEquipmentNumber();
            cbEquipmentNumber.Properties.Items.Clear();
            cbEquipmentNumber.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < eqNum.Count; i++)
            {
                cbEquipmentNumber.Properties.Items.Add(eqNum[i], i, i);
                if (eqNum[i] == equipmentBus.getEquipmentNumber(eqID))
                {
                    cbEquipmentNumber.SelectedIndex = i + 1;
                }
            }
            cbEquipmentNumber.Enabled = false;
            //Equipment Type
            EQUIPMENT_TYPE_BUS eqTypeBus = new EQUIPMENT_TYPE_BUS();
            txtEquipmentType.Text = eqTypeBus.getEquipmentTypeName(equipmentBus.getEquipmentTypeID(eqID));
            txtEquipmentType.Enabled = false;
            //Sites
            cbSites.Properties.Items.Add(siteBus.getSiteName(equipmentBus.getSiteID(eqID)), 0, 0);
            cbSites.SelectedIndex = 0;
            cbSites.Enabled = false;
            //Facility
            int faciID = equipmentBus.getFacilityID(eqID);
            cbFacility.Properties.Items.Add(facilityBus.getFacilityName(faciID),0,0);
            cbFacility.SelectedIndex = 0;
            cbFacility.Enabled = false;
            //Component Number
            txtComponentNumber.Text = componentMaster_Bus.getComponentNumber(ID);

            //<lọc dữ liệu cho trường hợp tank>
            int _equipmentTypeID = equipmentBus.getEqTypeID(ID);
            if (_equipmentTypeID == 11)
            {
                string[] componentTypeName = { "Shell", "Tank Bottom" };
                string[] APIcomp = { "COURSE-1", "COURSE-10", "COURSE-2", "COURSE-3", "COURSE-4", "COURSE-5", "COURSE-6", "COURSE-7", "COURSE-8", "COURSE-9", "TANKBOTTOM" };
                cbComponentType.Properties.Items.Clear();
                cbComponentType.Properties.Items.Add("", -1, -1);
                for (int i = 0; i < componentTypeName.Length; i++)
                {
                    cbComponentType.Properties.Items.Add(componentTypeName[i], i, i);
                    if (componentTypeName[i] == componentBus.getComponentTypeName(componentMaster_Bus.getComponentTypeID(ID)))
                    {
                        cbComponentType.SelectedIndex = i + 1;
                    }
                }
                cbAPIComponentType.Properties.Items.Clear();
                cbAPIComponentType.Properties.Items.Add("", -1, -1);
                for (int i = 0; i < APIcomp.Length; i++)
                {
                    cbAPIComponentType.Properties.Items.Add(APIcomp[i], i, i);
                    if (APIcomp[i] == API_BUS.getAPIComponentTypeName(componentMaster_Bus.getAPIComponentTypeID(eqID)))
                    {
                        cbAPIComponentType.SelectedIndex = i + 1;
                    }
                }
            }
            else
            {
                //get data for API component
                listAPIComponent = API_BUS.getDataSource();
                cbAPIComponentType.Properties.Items.Clear();
                cbAPIComponentType.Properties.Items.Add("", -1, -1);
                for (int i = 0; i < listAPIComponent.Count; i++)
                {
                    cbAPIComponentType.Properties.Items.Add(listAPIComponent[i].APIComponentTypeName, i, i);
                    if (listAPIComponent[i].APIComponentTypeName == API_BUS.getAPIComponentTypeName(componentMaster_Bus.getAPIComponentTypeID(eqID)))
                    {
                        cbAPIComponentType.SelectedIndex = i + 1;
                    }
                }
                //get data for component type
                listComponent = componentBus.getDataSource();
                cbComponentType.Properties.Items.Clear();
                cbComponentType.Properties.Items.Add("", -1, -1);
                for (int i = 0; i < listComponent.Count; i++)
                {
                    cbComponentType.Properties.Items.Add(listComponent[i].ComponentTypeName, i, i);
                    if (listComponent[i].ComponentTypeName == componentBus.getComponentTypeName(componentMaster_Bus.getComponentTypeID(ID)))
                    {
                        cbComponentType.SelectedIndex = i + 1;
                    }
                }
            }
            //</lọc data cho tank>
            txtComponentName.Text = componentMaster_Bus.getComponentName(ID);
            chkLinks.Checked = com.IsEquipmentLinked == 1 ? true : false;
            txtDescription.Text = com.ComponentDesc;
        }
        private void addDatatoControl()
        {
            //get data for site
            listSite = siteBus.getData();
            cbSites.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listSite.Count; i++)
            {
                cbSites.Properties.Items.Add(listSite[i].SiteName, i, i);
                if (listSite[i].SiteName == this.siteName)
                {
                    cbSites.SelectedIndex = i + 1;
                    //get list facility name 
                    List<string> faciName = facilityBus.getListFacilityName(listSite[i].SiteID);
                    cbFacility.Properties.Items.Clear();
                    for (int j = 0; j < faciName.Count; j++)
                    {
                        cbFacility.Properties.Items.Add(faciName[j], j, j);
                        if (faciName[j] == this.facilityName)
                        {
                            cbFacility.SelectedIndex = j;
                        }
                    }
                }
            }

            //get data for equipment number
            listEquipment = equipmentBus.getDataSource();
            cbEquipmentNumber.Properties.Items.Clear();
            cbEquipmentNumber.Properties.Items.Add("", -1, -1);
            for (int i = 0; i < listEquipment.Count; i++)
            {
                cbEquipmentNumber.Properties.Items.Add(listEquipment[i].EquipmentNumber, i, i);
                if (this.equipmentNumber == listEquipment[i].EquipmentNumber)
                {
                    cbEquipmentNumber.SelectedIndex = i + 1;
                }
            }
            //<lọc dữ liệu cho trường hợp tank>
            int _siteID = siteBus.getIDbyName(this.siteName);
            int _facilityID = facilityBus.getIDbyName_SiteID(_siteID, this.facilityName);
            int _equipmentTypeID = equipmentBus.getEquipmentTypeID(_siteID, _facilityID);
            if (_equipmentTypeID == 11)
            {
                string[] componentTypeName = { "Shell", "Tank Bottom" };
                string[] APIcomp = { "COURSE-1", "COURSE-10", "COURSE-2", "COURSE-3", "COURSE-4", "COURSE-5", "COURSE-6", "COURSE-7", "COURSE-8", "COURSE-9", "TANKBOTTOM" };
                cbComponentType.Properties.Items.Clear();
                for (int i = 0; i < componentTypeName.Length; i++)
                {
                    cbComponentType.Properties.Items.Add(componentTypeName[i], i, i);
                }
                cbAPIComponentType.Properties.Items.Clear();
                for (int i = 0; i < APIcomp.Length; i++)
                {
                    cbAPIComponentType.Properties.Items.Add(APIcomp[i], i, i);
                }
            }
            else
            {
                //get data for API component
                listAPIComponent = API_BUS.getDataSource();
                cbAPIComponentType.Properties.Items.Clear();
                cbAPIComponentType.Properties.Items.Add("", -1, -1);
                for (int i = 0; i < listAPIComponent.Count; i++)
                {
                    cbAPIComponentType.Properties.Items.Add(listAPIComponent[i].APIComponentTypeName, i, i);
                }
                //get data for component type
                listComponent = componentBus.getDataSource();
                cbComponentType.Properties.Items.Clear();
                cbComponentType.Properties.Items.Add("", -1, -1);
                for (int i = 0; i < listComponent.Count; i++)
                {
                    cbComponentType.Properties.Items.Add(listComponent[i].ComponentTypeName, i, i);
                }
            }
            //</lọc data cho tank>

            //get equipment type name
            EQUIPMENT_TYPE_BUS eqTypeBus = new EQUIPMENT_TYPE_BUS();
            txtEquipmentType.Text = eqTypeBus.getEquipmentTypeName(_equipmentTypeID);
        }
        public COMPONENT_MASTER getDataComponentMaster()
        {
            COMPONENT_MASTER compMaster = new COMPONENT_MASTER();
            if (doubleEditClicked)
            {
                compMaster.ComponentID = this.componentID;
            }
            compMaster.ComponentName = txtComponentName.Text;
            compMaster.ComponentNumber = txtComponentNumber.Text;
            compMaster.ComponentDesc = txtDescription.Text;
            compMaster.IsEquipmentLinked = Convert.ToInt32(chkLinks.Checked);

            listEquipment = equipmentBus.getDataSource();
            foreach (EQUIPMENT_MASTER e in listEquipment)
            {
                if (e.EquipmentNumber == cbEquipmentNumber.Text)
                {
                    compMaster.EquipmentID = e.EquipmentID;
                }
            }

            listAPIComponent = API_BUS.getDataSource();
            foreach (API_COMPONENT_TYPE a in listAPIComponent)
            {
                if (a.APIComponentTypeName == cbAPIComponentType.Text)
                {
                    compMaster.APIComponentTypeID = a.APIComponentTypeID;
                }
            }

            listComponent = componentBus.getDataSource();
            foreach (COMPONENT_TYPE c in listComponent)
            {
                if (c.ComponentTypeName == cbComponentType.Text)
                {
                    compMaster.ComponentTypeID = c.ComponentTypeID;
                }
            }
            return compMaster;
        }
        public API_COMPONENT_TYPE getData1()
        {
            API_COMPONENT_TYPE api = new API_COMPONENT_TYPE();
            api.APIComponentTypeName = cbAPIComponentType.Text;
            return api;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtComponentNumber.Text == "" || cbComponentType.Text == "" || cbAPIComponentType.Text == "")
                return;
            List<string> comNum = componentMaster_Bus.getAllComponentNumber();
            Console.WriteLine("jshdjksdh " + doubleEditClicked);
            foreach(string s in comNum)
            {
                if (s == txtComponentNumber.Text && s != oldName)
                {
                    MessageBox.Show("Component Number already exist!", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            ButtonOKClicked = true;
            if (doubleEditClicked)
            {
                COMPONENT_MASTER obj = getDataComponentMaster();
                componentMaster_Bus.edit(obj);
            }
            else
            {
                COMPONENT_MASTER obj = getDataComponentMaster();
                componentMaster_Bus.add(getDataComponentMaster());
            }
            this.Close();
        }

        private void txtComponentNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtComponentNumber.Text == "") picComponentNumber.Show();
            else picComponentNumber.Hide();
        }
        private void cbAPIComponentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAPIComponentType.Text == "") picAPIComponent.Show();
            else picAPIComponent.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSites_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbSites.Text != "")
            {
                int _siteID = siteBus.getIDbyName(cbSites.Text);
                List<string> faciname = facilityBus.getListFacilityName(_siteID);
                cbFacility.Properties.Items.Clear();
                for (int i = 0; i < faciname.Count; i++)
                {
                    cbFacility.Properties.Items.Add(faciname[i], i, i);
                }
            }
        }

        private void cbFacility_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbComponentType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbComponentType.Text != "")
            {
                picComponentType.Hide();
            }
            else
            {
                picComponentType.Show();
            }
        }
    }
}
