using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class EQUIPMENT_REVISION_INSPECTION
    {
        public int RevisionID { set; get; }
        public int CoverageDetailID { set; get; }
        public String ComponentNumber { set; get; }
        public int CoverageID { set; get; }
        public int DMItemID { set; get; }
        public int IMTypeID { set; get; }
        public DateTime InspectionDate { set; get; }
        public String EffectivenessCode { set; get; }
        public int CarriedOut { set; get; }
        public DateTime CarriedOutDate { set; get; }
    }
}
