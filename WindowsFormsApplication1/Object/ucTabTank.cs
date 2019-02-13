using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.PRE.subForm.InputDataForm;
using RBI.PRE.subForm.OutputDataForm;
namespace RBI.Object
{
    class ucTabTank
    {
        public int ID { set; get; }
        public UCAssessmentInfo ucAss { set; get; }
        public UCEquipmentPropertiesTank ucEquipmentTank { set; get; }
        public UCComponentPropertiesTank ucComponentTank { set; get; }
        public UCMaterialTank ucMaterialTank { set; get; }
        public UCStreamTank ucStreamTank { set; get; }
        public UCOperatingCondition ucOpera { set; get; }
        public UCCoatLiningIsulationCladding ucCoat { set; get; }
        public UCRiskFactor ucRiskFactor { set; get; }
        public UCRiskSummary ucRiskSummary { set; get; }
        public UCInspectionHistorySubform ucInspHistory { set; get; }
        public UCDrawGraph ucDrawGraph { set; get; }
        public ucTabTank(int id, UCAssessmentInfo u1, UCEquipmentPropertiesTank u2, UCComponentPropertiesTank u3, UCOperatingCondition u4,
            UCCoatLiningIsulationCladding u5, UCMaterialTank u6, UCStreamTank u7,UCRiskFactor u8, UCRiskSummary u9, UCInspectionHistorySubform u10, UCDrawGraph uc11)
        {
            this.ID = id;
            ucAss = u1;
            ucEquipmentTank = u2;
            ucComponentTank = u3;
            ucOpera = u4;
            ucCoat = u5;
            ucMaterialTank = u6;
            ucStreamTank = u7;
            ucRiskFactor = u8;
            ucRiskSummary = u9;
            ucInspHistory = u10;
            ucDrawGraph = uc11;
        }
    }
}
