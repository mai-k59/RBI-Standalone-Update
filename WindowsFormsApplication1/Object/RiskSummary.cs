using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object
{
    public class RiskSummary
    {
        public int ID { set; get; }
        public String SitesName { set; get; }
        public String FacilityName { set; get; }
        public String AssessmentName { set; get; }
        public String EquipmentName { set; get; }
        public String EquipmentNumber { set; get; }
        public String EquipmentDesc { set; get; }
        public String EquipmentType { set; get; }
        public String ComponentName { set; get; }
        public String RepresentFluid { set; get; }
        public String FluidPhase { set; get; }
        public float currentRisk { set; get; }
        public float cofcatFlammable { set; get; }
        public float cofcatPeople { set; get; }
        public float cofcatAsset { set; get; }
        public float cofcatEnv { set; get; }
        public float cofcatReputation { set; get; }
        public float cofcatCombined { set; get; }
        public String componentMaterialGrade { set; get; }
        public float initThinningPoF { set; get; }
        public float initEnvCracking { set; get; }
        public float initOtherPoF { set; get; }
        public float initPoF { set; get; }
        public float extThinningPoF { set; get; }
        public float extEnvCrackingPoF { set; get; }
        public float extOtherPoF { set; get; }
        public float extPoF { set; get; }
        public float PoF { set; get; }
        public float CurrentRiskCalculation { set; get; }
        public float futureRisk { set; get; }
    }
}
