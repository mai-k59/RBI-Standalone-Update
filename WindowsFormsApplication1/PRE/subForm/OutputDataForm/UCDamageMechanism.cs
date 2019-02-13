using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
namespace RBI.PRE.subForm.InputDataForm
{
    public partial class UCDamageMechanism : UserControl
    {
        public UCDamageMechanism()
        {
            InitializeComponent();
        }
        TreeListNode parentNode1 = null;
        TreeListNode parentNode2 = null;
        TreeListNode parentNode3 = null;
        TreeListNode parentNode4 = null;
        TreeListNode parentNode5 = null;
        TreeListNode childNode = null;

        private RepositoryItemCheckEdit repositoryItemCheckEdit1 = new RepositoryItemCheckEdit();
        private RepositoryItemButtonEdit repositoryItemButtonEdit1 = new RepositoryItemButtonEdit();

        string[] parentNodeName = 
        {
            "1. Mechanical and Metallurgical Mechanism",
            "2. Uniform or Localized Metal Loss",
            "3. Higih Temperature Corrosion",
            "4. Environmental-Assisted Mechanism",
            "5. Other"
         };
        #region array string for childNode 1
        string[] childNode1 =
        {
            "885F Embrittlement",
            "Brittle Fracture",
            "Cavitation",
            "Creep Rupture",
            "Dissimilar Metal Weld Cracking",
            "Erosion/Erosion-Corrosion",
            "Graphitisation",
            "Vibration-Induced Mechanical Fatigue",
            "Refractory Degradation",
            "Reheat Cracking",
            "Short Term Overheating",
            "Sigma Phase Embriilement",
            "Spheroidisation (Softening)",
            "Steam Blankelting",
            "Temper Embrittlement",
            "Themal Fatigue",
            "Thermal Shock",
            "Other Mechanical or Metallurgical"
        };
        #endregion
        #region array string for childNode 2
        string[] childNode2 =
        {
            "Internal Thinning",
            "Internal Lining Degradation",
            "Amine Corrosion",
            "Ammonium Bisulphide Corrosion",
            "Ammonium Chloride Corrosion",
            "Atmospheric Corrosion",
            "Boiler Water Condesate Corrosion",
            "Caustic Corrosion",
            "Chloride Stress Corrosion Under Insulation",
            "CO2 Corrosion",
            "Cooling Water Corrosion",
            "Corrosion Under Insulation",
            "Dealloying",
            "External Corrosion",
            "Flue Gas Dew Point Corrosion",
            "Galvanic Corrosion",
            "Graphite Corrosion",
            "High Temperature H2/H2S Corrosion",
            "Hydrochloric Acid Corrosion",
            "Hydrofluoric Acid Corrosion",
            "Microbiologically-Induced Corrosion",
            "Naphthenic Acid Corrosion",
            "Phenol (Carbonic Acid) Corrosion",
            "Soil Corrosion",
            "Sour Water Corrosion",
            "Sulphuric Acid Corrosion",
            "Titanium Hydriding",
            "Other, Metal Loss"
        };
        #endregion
        #region array string for childNode 3
        string[] childNode3 =
        {
            "Carburisation",
            "Decarburisation",
            "Fuel Ash Corrosion",
            "Metal Dusting",
            "Nitriduing",
            "Oxidation",
            "Sulphidation",
            "Other High Temperture Corrosion",
            "Hydrogen Embrittlement"


        };
        #endregion
        #region array string for childNode 4
        string[] childNode4 =
        {
            "Amine Stress Corrosion Cracking",
            "Ammonia Stress Corosion Cracking",
            "Blistering",
            "Carbonate Stress Corrosion Cracking",
            "Caustic Stress Corrosion Cracking",
            "Chloride Strees Corrosion Cracking",
            "Chloride Strees Corrosion Cracking Under Insulation",
            "Corrosion Fatigue",
            "Deaerator Cracking",
            "External Chloride Stress Corrosion Cracking",
            "HF Produced HIC/SOHIC",
            "High Temperature Hydrogen Attack",
            "HIC/SOHIC-H2S",
            "Liquid Metal Embrittlement",
            "Polythionic Acid Stress Corrosion Cracking",
            "Sulphide Stress Corrosion Cracking (H2S)",
            "Other Environment-Assisted"
        };
        #endregion
        #region array string for childNode 5
        string[] childNode5 =
        {
            "Aluminium Chloride (General + Localised Corrosion)",
            "Ammonia (General + Localised Corrosion)",
            "Cladding Disbondment",
            "Cyanides (General + Localised Corrosion)",
            "Formic Acid (General + Localised Corrosion)",
            "Hydroden Sulphide (General + Localised Corrosion)",
            "Localised Corrosion of Stainless Steel",
            "Oxygen (General + Localised Corrosion)",
            "Polythionic Acid (General + Localised Corrosion)",
            "Under Deposit Attack (Metal Thinning)",
            "Water (General + Localised Corrosion)"
        };
        #endregion
        private void InitData()
        {
            colActive.ColumnEdit = repositoryItemCheckEdit1;
            colEL.ColumnEdit = repositoryItemCheckEdit1;
            colDF.ColumnEdit = repositoryItemCheckEdit1;
            //nhanh thu 1
            treeList1.BeginUnboundLoad();
            parentNode1 = treeList1.AppendNode(
            new object[] { parentNodeName[0] }, -1);
            treeList1.EndUnboundLoad();
            treeList1.SetRowCellValue(parentNode1, colActive, null);
            for (int i = 0; i < childNode1.Length; i++)
            {
                treeList1.BeginUnboundLoad();
                childNode = treeList1.AppendNode(
                new object[] { childNode1[i] }, parentNode1);
                treeList1.EndUnboundLoad();


            }
            //nhanh thu 2
            treeList1.BeginUnboundLoad();
            parentNode2 = treeList1.AppendNode(
            new object[] { parentNodeName[1] }, -1);
            treeList1.EndUnboundLoad();
            for (int i = 0; i < childNode2.Length; i++)
            {
                treeList1.BeginUnboundLoad();
                childNode = treeList1.AppendNode(
                new object[] { childNode2[i] }, parentNode2);
                treeList1.EndUnboundLoad();
            }
            //nhanh thu 3
            treeList1.BeginUnboundLoad();
            parentNode3 = treeList1.AppendNode(
            new object[] { parentNodeName[2] }, -1);
            treeList1.EndUnboundLoad();
            for (int i = 0; i < childNode3.Length; i++)
            {
                treeList1.BeginUnboundLoad();
                childNode = treeList1.AppendNode(
                new object[] { childNode3[i] }, parentNode3);
                treeList1.EndUnboundLoad();
            }
            //nhanh thu 4
            treeList1.BeginUnboundLoad();
            parentNode4 = treeList1.AppendNode(
            new object[] { parentNodeName[3] }, -1);
            treeList1.EndUnboundLoad();
            for (int i = 0; i < childNode4.Length; i++)
            {
                treeList1.BeginUnboundLoad();
                childNode = treeList1.AppendNode(
                new object[] { childNode4[i] }, parentNode4);
                treeList1.EndUnboundLoad();
            }
            //nhanh thu 5
            treeList1.BeginUnboundLoad();
            parentNode5 = treeList1.AppendNode(
            new object[] { parentNodeName[4] }, -1);
            treeList1.EndUnboundLoad();
            for (int i = 0; i < childNode5.Length; i++)
            {
                treeList1.BeginUnboundLoad();
                childNode = treeList1.AppendNode(
                new object[] { childNode5[i] }, parentNode5);
                treeList1.EndUnboundLoad();
            }
            colActive.ColumnEdit = repositoryItemCheckEdit1;
            colRecord.ColumnEdit = repositoryItemButtonEdit1;
        }
    }
}
