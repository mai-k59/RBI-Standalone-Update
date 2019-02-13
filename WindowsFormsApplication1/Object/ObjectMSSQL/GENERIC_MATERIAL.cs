using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class GENERIC_MATERIAL
    {
        public int ID { get; set; }
        public String MaterialName { get; set; }
        public float DesignPressure { get; set; }
        public float DesignTemperature { get; set; }
        public float MinDesignTemperature { get; set; }
        public float CorrosionAllowance { get; set; }
        public float SigmaPhase { get; set; }
        public String SulfurContent { get; set; }
        public String HeatTreatment { get; set; }
        public float ReferenceTemperature { get; set; }
        public String PTAMaterialCode { get; set; }
        public String HTHAMaterialCode { get; set; }
        public int IsPTA { get; set; }
        public int IsHTHA { get; set; }
        public int Austenitic { get; set; }
        public int Temper { get; set; }
        public int CarbonLowAlloy { get; set; }
        public int NickelBased { get; set; }
        public int ChromeMoreEqual12 { get; set; }
        public float CostFactor { get; set; }
    }
}
