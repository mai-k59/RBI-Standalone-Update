using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.BUS.BUSMSSQL;
using RBI.Object.ObjectMSSQL;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class frmNewManufacturer : Form
    {
        public frmNewManufacturer()
        {
            InitializeComponent();
        }
        public bool ButtonOKClicked { set; get; }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtManufacturerName.Text == "")
            {
                MessageBox.Show("Please enter Manufacturer name!", "Manufacturer");
                return;
            }
            else
            {
                MANUFACTURER_BUS manuBus = new MANUFACTURER_BUS();
                List<MANUFACTURER> listManu = manuBus.getDataSource();
                foreach(MANUFACTURER m in listManu)
                {
                    if(m.ManufacturerName == txtManufacturerName.Text)
                    {
                        MessageBox.Show("Manufacturer Name already exist!", "Manufacturer");
                        return;
                    }
                }
                MANUFACTURER ma = new MANUFACTURER();
                ma.ManufacturerName = txtManufacturerName.Text;
                manuBus.add(ma);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
