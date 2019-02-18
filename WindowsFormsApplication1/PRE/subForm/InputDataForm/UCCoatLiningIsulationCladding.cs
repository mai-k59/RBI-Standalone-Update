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
    public partial class UCCoatLiningIsulationCladding : UserControl
    {       
        public UCCoatLiningIsulationCladding(int ID, string corrosionRateUnit)
        {
            InitializeComponent();
            ShowDatatoControl(ID, corrosionRateUnit);
            lblCorrosionRate.Text = corrosionRateUnit;
        }

        public void ShowDatatoControl(int ID, string corrosionRate)
        {
            RW_COATING_BUS BUS = new RW_COATING_BUS();
            RW_COATING coat = BUS.getData(ID);
            BUS_UNITS convUnit = new BUS_UNITS();
            String[] extQuality = { "No coating or poor quality", "Medium coating quality", "High coating quality" };
            String[] inType = { "Organic", "Castable refractory", "Strip lined alloy", "Castable refractory severe condition", "Glass lined", "Acid Brick", "Fibreglass" };
            String[] inCon = { "Good", "Average", "Poor", "Unknown" };
            String[] extType = { "Foam Glass", "Pearlite", "Fibreglass", "Mineral Wool", "Calcium Silicate", "Asbestos" };
            String[] isuCon = { "Above average", "Average", "Below average" };
            if (coat.ExternalCoating == 1)
                chkExternalCoat.Checked = true;
            else
                chkExternalCoat.Checked = false;

            if (coat.ExternalInsulation == 1)
                chkExternalIsulation.Checked = true;
            else
                chkExternalIsulation.Checked = false;

            if (coat.InternalCladding == 1)
                chkInternalCladding.Checked = true;
            else
                chkInternalCladding.Checked = false;

            if (coat.InternalCoating == 1)
                chkInternalCoat.Checked = true;
            else
                chkInternalCoat.Checked = false;

            if (coat.InternalLining == 1)
                chkInternalLining.Checked = true;
            else
                chkInternalLining.Checked = false;

            dateExternalCoating.DateTime = coat.ExternalCoatingDate;


            for (int i = 0; i < extQuality.Length; i++)
            {
                if (coat.ExternalCoatingQuality == extQuality[i])
                {
                    cbExternalCoatQuality.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < extType.Length; i++)
            {
                if (coat.ExternalInsulationType == extType[i])
                {
                    cbExternalIsulation.SelectedIndex = i + 1;
                    break;
                }
            }
            for (int i = 0; i < inCon.Length; i++)
            {
                if (coat.InternalLinerCondition == inCon[i])
                {
                    cbInternalLinerCondition.SelectedIndex = i + 1;
                    break;
                }
            }

            if (coat.InsulationContainsChloride == 1)
                chkInsulationContainsChlorides.Checked = true;
            else
                chkInsulationContainsChlorides.Checked = false;

            for (int i = 0; i < inType.Length; i++)
            {
                if (coat.InternalLinerType == inType[i])
                {
                    cbInternalLinerType.SelectedIndex = i + 1;
                    break;
                }
            }

            if (corrosionRate == "mm/yr") txtCladdingCorrosionRate.Text = coat.CladdingCorrosionRate.ToString();
            else txtCladdingCorrosionRate.Text = (coat.CladdingCorrosionRate / convUnit.mil).ToString();

            if (coat.SupportConfigNotAllowCoatingMaint == 1)
                chkSupport.Checked = true;
            else
                chkSupport.Checked = false;

            for (int i = 0; i < isuCon.Length; i++)
            {
                if (coat.InsulationCondition == isuCon[i])
                {
                    cbIsulationCondition.SelectedIndex = i + 1;
                    break;
                }
            }
        }

        public RW_COATING getData(int ID, string corrosionRate)
        {
            RW_COATING coat = new RW_COATING();
            BUS_UNITS convUnit = new BUS_UNITS();
            coat.ID = ID;
            coat.ExternalCoating = chkExternalCoat.Checked ? 1 : 0;
            coat.ExternalInsulation = chkExternalIsulation.Checked ? 1 : 0;
            coat.InternalCladding = chkInternalCladding.Checked ? 1 : 0;
            coat.InternalCoating = chkInternalCoat.Checked ? 1 : 0;
            coat.InternalLining = chkInternalLining.Checked ? 1 : 0;
            coat.ExternalCoatingDate = dateExternalCoating.DateTime;
            coat.ExternalCoatingQuality = cbExternalCoatQuality.Text;
            coat.ExternalInsulationType = cbExternalIsulation.Text;
            coat.InternalLinerCondition = cbInternalLinerCondition.Text;
            coat.InsulationContainsChloride = chkInsulationContainsChlorides.Checked ? 1 : 0;
            coat.InternalLinerType = cbInternalLinerType.Text;
            if (corrosionRate == "mm/yr") coat.CladdingCorrosionRate = txtCladdingCorrosionRate.Text == "" ? 0 : float.Parse(txtCladdingCorrosionRate.Text);
            else coat.CladdingCorrosionRate = txtCladdingCorrosionRate.Text == "" ? 0 : (float.Parse(txtCladdingCorrosionRate.Text) * (float)convUnit.mil);
            coat.SupportConfigNotAllowCoatingMaint = chkSupport.Checked ? 1 : 0;
            coat.InsulationCondition = cbIsulationCondition.Text;
            return coat;
        }


        #region Xu ly su kien Data thay doi
        private int datachange = 0;
        private int ctrlSpress = 0;
        public event DataUCChangedHanlder DataChanged;
        public event CtrlSHandler CtrlS_Press;
        public int CtrlSPress
        {
            get { return ctrlSpress; }
            set
            {
                ctrlSpress = value;
                OnCtrlS_Press(new CtrlSPressEventArgs(ctrlSpress));
            }
        }
        
        protected virtual void OnCtrlS_Press(CtrlSPressEventArgs e)
        {
            if (CtrlS_Press != null)
                CtrlS_Press(this, e);
        }

        public int DataChange
        {
            get { return datachange; }
            set
            {
                datachange = value;
                OnDataChanged(new DataUCChangedEventArgs(datachange));
            }
        }
        protected virtual void OnDataChanged(DataUCChangedEventArgs e)
        {
            if (DataChanged != null)
                DataChanged(this, e);
        }
        #endregion
        
        private void txtCladdingCorrosionRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            string a = txtCladdingCorrosionRate.Text;
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (a.Contains(".") && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }
        private void txtCladdingCorrosionRate_TextChanged(object sender, EventArgs e)
        {
            DataChange += 1;
            if(sender is CheckBox)
            {
                CheckBox chk = sender as CheckBox;
                switch(chk.Name)
                {
                    case "chkExternalCoat":
                        dateExternalCoating.Enabled = cbExternalCoatQuality.Enabled = chk.Checked ? true : false;
                        break;
                    case "chkInternalLining":
                        cbInternalLinerType.Enabled = cbInternalLinerCondition.Enabled = chk.Checked ? true : false;
                        break;
                    case "chkExternalIsulation":
                        cbExternalIsulation.Enabled = cbIsulationCondition.Enabled = chk.Checked ? true : false;
                        break;
                    default:
                        break;

                }
            }
            if(sender is TextBox)
            {
                TextBox txt = sender as TextBox;
                double a = double.Parse(txt.Text);
                if (a < float.MinValue || a > float.MaxValue)
                    MessageBox.Show("Invalid value", "Cortek RBI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkInternalCoat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                CtrlSPress++;
            }
        }
    }
}
