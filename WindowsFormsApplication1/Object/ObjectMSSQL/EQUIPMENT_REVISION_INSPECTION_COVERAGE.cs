using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class EQUIPMENT_REVISION_INSPECTION_COVERAGE
    {
        public int RevisionID { set; get; }
        public int CoverageID { set; get; }
        public String InspPlanName { set; get; }
        public DateTime InspPlanDate { set; get; }
        public String CoverageName { set; get; }
        public DateTime CoverageDate { set; get; }
        public String Remarks { set; get; }
        public String Findings { set; get; }
        public String FindingRTF { set; get; }
    }
}
