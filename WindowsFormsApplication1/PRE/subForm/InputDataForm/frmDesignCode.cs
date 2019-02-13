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
    public partial class frmDesignCode : Form
    {
        
        public bool ButtonOKClicked { set; get; }
        public frmDesignCode()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtDesignCode.Text == "")
            {
                MessageBox.Show("Please Type Design Code Name!", "Design Code");
                return;
            }
            else
            {
                DESIGN_CODE d = new DESIGN_CODE();
                d.DesignCode = txtDesignCode.Text;
                DESIGN_CODE_BUS dBus = new DESIGN_CODE_BUS();
                List<DESIGN_CODE> listDesignCode = dBus.getDataSource();
                foreach(DESIGN_CODE ds in listDesignCode)
                {
                    if(ds.DesignCode == txtDesignCode.Text)
                    {
                        MessageBox.Show("Design Code already exist!", "Design Code");
                        return;
                    }
                }
                ButtonOKClicked = true;
                dBus.add(d);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
