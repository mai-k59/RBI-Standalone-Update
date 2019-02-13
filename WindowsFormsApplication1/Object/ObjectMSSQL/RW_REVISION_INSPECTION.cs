using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_REVISION_INSPECTION
    {
        public int ID { set; get; }
        public int CoverageDetailID { set; get; }
        public String InspPlanName { set; get; }
        public String CoverageName { set; get; }
        public int DMItemID { set; get; }
        public int IMTypeID { set; get; }
        public DateTime InspectionDate { set; get; }
        public String EffectivenessCode { set; get; }
        public String Findings { set; get; }
        public String FindingRTF { set; get; }
    }
}
