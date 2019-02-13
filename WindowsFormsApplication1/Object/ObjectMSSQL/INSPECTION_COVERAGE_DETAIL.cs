using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class INSPECTION_COVERAGE_DETAIL
    {
        public int CoverageDetailID { get; set; }
        public int CoverageID { get; set; }
        public int ComponentID { get; set; }
        public int DMItemID { get; set; }
        public int IMTypeID { get; set; }
        public DateTime InspectionDate { get; set; }
        public String EffectivenessCode { get; set; }
        public int CarriedOut { get; set; }
        public DateTime CarriedOutDate { get; set; }
    }
}
