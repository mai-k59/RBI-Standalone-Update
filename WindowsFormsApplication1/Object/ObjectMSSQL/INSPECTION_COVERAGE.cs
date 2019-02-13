using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class INSPECTION_COVERAGE
    {
        public int CoverageID { get; set; }
        public int PlanID { get; set; }
        public String CoverageName { get; set; }
        public DateTime CoverageDate{get;set;}
        public String Remarks { get; set; }
        public String Findings { get; set; }
        public String FindingRTF { get; set; }
}
}
