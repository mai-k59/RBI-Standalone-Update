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

namespace RBI.PRE.subForm.OutputDataForm
{
    public partial class UCRiskFactor : UserControl
    {
        public UCRiskFactor()
        {
            InitializeComponent();
        }
        public UCRiskFactor(int ID)
        {
            InitializeComponent();
            riskPoF(ID);
            riskCA(ID);
            //ShowDataOutputCA(ID);
            //initData_Shell(ID);
            //initData_Tank(ID);
            initData_CA(ID);
        }
        public String type { set; get; }
        public void riskPoF(int ID)
        {
            RW_FULL_POF_BUS bus = new RW_FULL_POF_BUS();
            RW_FULL_POF obj = bus.getData(ID);

            cbThinningType.Text = obj.ThinningType;
            textEdit1.Text = obj.GFFTotal.ToString();
            textEdit2.Text = obj.FMS.ToString();
            txt0Thinning.Text = obj.ThinningAP1.ToString();
            txt36Thinning.Text = obj.ThinningAP2.ToString();
            txt72Thinning.Text = obj.ThinningAP3.ToString();

            txt0StressCorrosion.Text = obj.SCCAP1.ToString();
            txt36StressCorrosion.Text = obj.SCCAP2.ToString();
            txt72StressCorrosion.Text = obj.SCCAP3.ToString();

            txt0External.Text = obj.ExternalAP1.ToString();
            txt36External.Text = obj.ExternalAP2.ToString();
            txt72External.Text = obj.ExternalAP3.ToString();

            txt0HighTemperature.Text = obj.HTHA_AP1.ToString();
            txt36HighTemperature.Text = obj.HTHA_AP2.ToString();
            txt72HighTemperature.Text = obj.HTHA_AP3.ToString();

            txt0BrittleFracture.Text = obj.BrittleAP1.ToString();
            txt36BrittleFracture.Text = obj.BrittleAP2.ToString();
            txt72BrittleFracture.Text = obj.BrittleAP3.ToString();

            txt0Piping.Text = obj.FatigueAP1.ToString();
            txt36Piping.Text = obj.FatigueAP2.ToString();
            txt72Piping.Text = obj.FatigueAP3.ToString();

            txt0Other.Text = obj.SemiAP1.ToString();
            txt32Other.Text = obj.SemiAP2.ToString();
            txt72Other.Text = obj.SemiAP3.ToString();

            txt0TotalGeneralThinning.Text = obj.ThinningGeneralAP1.ToString();
            txt36TotalGeneralThinning.Text = obj.ThinningGeneralAP2.ToString();
            txt72TotalGeneralThinning.Text = obj.ThinningGeneralAP3.ToString();

            txt0TotalLocalThinning.Text = obj.ThinningLocalAP1.ToString();
            txt36TotalLocalThinning.Text = obj.ThinningLocalAP2.ToString();
            txt72TotalLocalThinning.Text = obj.ThinningLocalAP3.ToString();

            txt0FinalTotalDamage.Text = obj.TotalDFAP1.ToString();
            txt36FinalTotalDamage.Text = obj.TotalDFAP2.ToString();
            txt72FinalTotalDamage.Text = obj.TotalDFAP3.ToString();

            txt0PoF.Text = obj.PoFAP1.ToString();
            txt36PoF.Text = obj.PoFAP2.ToString();
            txt72PoF.Text = obj.PoFAP3.ToString();

            txt0PoFCategory.Text = obj.PoFAP1Category;
            txt36PoFCategory.Text = obj.PoFAP2Category;
            txt72PoFCategory.Text = obj.PoFAP3Category;
        }
        public void riskCA(int ID)
        {
            RW_FULL_FCOF_BUS fullPoFBus = new RW_FULL_FCOF_BUS();
            RW_FULL_FCOF fullPoF = fullPoFBus.getData(ID);
            txtProductionCost.Text = fullPoF.prodcost.ToString();
            txtEquipmentCost.Text = fullPoF.equipcost.ToString();
            txtPopdens.Text = fullPoF.popdens.ToString();
            txtInjureCost.Text = fullPoF.injcost.ToString();
            txtEnvironmentCost.Text = fullPoF.envcost.ToString();
            txtFC.Text = fullPoF.FCoFValue.ToString();
            txtCA.Text = fullPoF.FCoFCategory;
        }
        public void ShowDataOutputCA(int ID)
        {
            //RW_CA_TANK_BUS busTank = new RW_CA_TANK_BUS();
            //RW_CA_TANK ca = busTank.getData(ID);
            //txtCA.Text = ca.ConsequenceCategory;
            //txtFC.Text = ca.Consequence.ToString();
            RW_CA_LEVEL_1_BUS busCA = new RW_CA_LEVEL_1_BUS();
            RW_CA_LEVEL_1 ca = busCA.getData(ID);
            txtCAcmd.Text = ca.CA_cmd.ToString();
            txtCAinj.Text = ca.CA_inj_flame.ToString();
            txtFCcmd.Text = ca.FC_cmd.ToString();
            txtFCinj.Text = ca.FC_inj.ToString();
            txtFCaffa.Text = ca.FC_affa.ToString();
            txtFCprod.Text = ca.FC_prod.ToString();
            txtFCenviron.Text = ca.FC_envi.ToString();
        }

        private void cbThinningType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbThinningType.Text == "")
            {
                type = "Local";
            }
            else
            {
                type = cbThinningType.Text;
            } 
        }
        private void initData_CA(int ID)
        {
            RW_ASSESSMENT_BUS busAssess = new RW_ASSESSMENT_BUS();
            COMPONENT_MASTER_BUS busCompMaster = new COMPONENT_MASTER_BUS();
            int[] temp = busAssess.getEquipmentID_ComponentID(ID);
            int compTypeID = busCompMaster.getComponentTypeID(temp[1]);
            if (compTypeID == 12)
            {
                initData_Tank(ID);
                tabCATankBottom.PageVisible = true;
                tabCAShell.PageVisible = false;
                tabCA.PageVisible = false;
            }
            else if (compTypeID == 8)
            {
                initData_Shell(ID);
                tabCA.PageVisible = false;
                tabCATankBottom.PageVisible = false;
                tabCAShell.PageVisible = true;
            }
            else
            {
                riskCA(ID);
                ShowDataOutputCA(ID);
                tabCATankBottom.PageVisible = false;
                tabCAShell.PageVisible = false;
                tabCA.PageVisible = true;
            }
        }

        private void initData_Tank(int ID)
        {
            RW_CA_TANK_BUS busCA_Tank = new RW_CA_TANK_BUS();
            RW_CA_TANK caTank = busCA_Tank.getData(ID);
            tbHdraulicFluid.Text = caTank.Hydraulic_Fluid.ToString();
            tbHdraulicWater.Text = caTank.Hydraulic_Water.ToString();
            tbSeepageVelocity.Text = caTank.Seepage_Velocity.ToString();
            tbFlowRateD1.Text = caTank.Flow_Rate_D1.ToString();
            tbFlowRateD4.Text = caTank.Flow_Rate_D4.ToString();
            tbLeakDurationD1.Text = caTank.Leak_Duration_D1.ToString();
            tbLeakDurationD4.Text = caTank.Leak_Duration_D4.ToString();
            tbRealeaseVolumeFromLeakageD1.Text = caTank.Release_Volume_Leak_D1.ToString();
            tbRealeaseVolumeFromLeakageD4.Text = caTank.Release_Volume_Leak_D4.ToString();
            tbReleaseVolumeFromRupture.Text = caTank.Release_Volume_Rupture.ToString();
            tbTimeToInitiate.Text = caTank.Time_Leak_Ground.ToString();
            tbVolumeSubsoilFromLeakageD1.Text = caTank.Volume_SubSoil_Leak_D1.ToString();
            tbVolumeSubsoilFromLeakageD4.Text = caTank.Volume_SubSoil_Leak_D4.ToString();
            tbVolumeGroundWaterFromLeakageD1.Text = caTank.Volume_Ground_Water_Leak_D1.ToString();
            tbVolumeGroundWaterFromLeakageD4.Text = caTank.Volume_Ground_Water_Leak_D4.ToString();
            tbWithinTheDike.Text = caTank.Barrel_Dike_Rupture.ToString();
            tbWithinTheDike.Text = caTank.Barrel_Dike_Rupture.ToString();
            tbOnsiteRupture.Text = caTank.Barrel_Onsite_Rupture.ToString();
            tbOffsiteRupture.Text = caTank.Barrel_Offsite_Rupture.ToString();
            tbReachWater.Text = caTank.Barrel_Water_Rupture.ToString();
            tbFC_Env_Leakage.Text = caTank.FC_Environ_Leak.ToString();
            tbFC_Env_Rupture.Text = caTank.FC_Environ_Rupture.ToString();
            tbMaterialFactor.Text = caTank.Material_Factor.ToString();

            tbTotalCost.Text = caTank.FC_Environ.ToString();
            tbComponentDamageCost.Text = caTank.Component_Damage_Cost.ToString();
            tbCostOfBusinessInterruption.Text = caTank.Business_Cost.ToString();

            tbTotalConsequence.Text = caTank.Consequence.ToString();
            tbConsequenceCategory.Text = caTank.ConsequenceCategory;
        }

        private void initData_Shell(int ID)
        {
            RW_CA_TANK_BUS busCA_Tank = new RW_CA_TANK_BUS();
            RW_CA_TANK caTank = busCA_Tank.getData(ID);
            tbFlowRateShellD1.Text = caTank.Flow_Rate_D1.ToString();
            tbFlowRateShellD2.Text = caTank.Flow_Rate_D2.ToString();
            tbFlowRateShellD3.Text = caTank.Flow_Rate_D3.ToString();
            tbFlowRateShellD4.Text = caTank.Flow_Rate_D4.ToString();

            tbLeakDurationShellD1.Text = caTank.Leak_Duration_D1.ToString();
            tbLeakDurationShellD2.Text = caTank.Leak_Duration_D2.ToString();
            tbLeakDurationShellD3.Text = caTank.Leak_Duration_D3.ToString();
            tbLeakDurationShellD4.Text = caTank.Leak_Duration_D4.ToString();

            tbReleaseVolumeLeakageShellD1.Text = caTank.Release_Volume_Leak_D1.ToString();
            tbReleaseVolumeLeakageShellD2.Text = caTank.Release_Volume_Leak_D2.ToString();
            tbReleaseVolumeLeakageShellD3.Text = caTank.Release_Volume_Leak_D3.ToString();
            tbReleaseVolumeLeakageShellD4.Text = caTank.Release_Volume_Leak_D4.ToString();

            tbReleaseVolumeRuptureShell.Text = caTank.Release_Volume_Rupture.ToString();
            tbTimeLeakageGroundWaterShell.Text = caTank.Time_Leak_Ground.ToString();
            tbVolumeSubsoilShellD1.Text = caTank.Volume_SubSoil_Leak_D1.ToString();
            tbVolumeSubsoilShellD4.Text = caTank.Volume_SubSoil_Leak_D4.ToString();
            tbVolumeGroundWaterShellD1.Text = caTank.Volume_Ground_Water_Leak_D1.ToString();
            tbVolumeGroundWaterShellD4.Text = caTank.Volume_Ground_Water_Leak_D4.ToString();
            tbDikeRuptureShell.Text = caTank.Barrel_Dike_Rupture.ToString();
            tbOn_siteShell.Text = caTank.Barrel_Onsite_Rupture.ToString();
            tbIn_siteShell.Text = caTank.Barrel_Offsite_Rupture.ToString();
            tbReachWaterRuptureShell.Text = caTank.Barrel_Water_Rupture.ToString();
            tbFCleakageShell.Text = caTank.FC_Environ_Leak.ToString();
            tbFCruptureShell.Text = caTank.FC_Environ_Rupture.ToString();

            tbTotalF_Shell.Text = caTank.FC_Environ.ToString();
            tbComponentDamageCost.Text = caTank.Component_Damage_Cost.ToString();
            tbCostBussinessInterruptionShell.Text = caTank.Business_Cost.ToString();

            tbTotalConsequenceShell.Text = caTank.Consequence.ToString();
            tbConsequenceCategoryShell.Text = caTank.ConsequenceCategory;
        }
    }
}
