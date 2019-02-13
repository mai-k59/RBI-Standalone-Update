using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_MATERIAL
    {
        public int ID { set; get; }
        public String MaterialName { set; get; }
        public float DesignPressure { set; get; }
        public float DesignTemperature { set; get; }
        public float MinDesignTemperature { set; get; }
        public float BrittleFractureThickness { set; get; }
        public float CorrosionAllowance { set; get; }
        public float SigmaPhase { set; get; }
        public String SulfurContent { set; get; }
        public String HeatTreatment { set; get; }
        public float ReferenceTemperature { set; get; }
        public String PTAMaterialCode { set; get; }
        public String HTHAMaterialCode { set; get; }
        public int IsPTA { set; get; }
        public int IsHTHA { set; get; }
        public int Austenitic { set; get; }
        public int Temper { set; get; }
        public int CarbonLowAlloy { set; get; }
        public int NickelBased { set; get; }
        public int ChromeMoreEqual12 { set; get; }
        public float AllowableStress { set; get; }
        public float CostFactor { set; get; }
        
    }
}
