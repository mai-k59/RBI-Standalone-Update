using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_INSPECTION_HISTORY
    {
        public int ID { set; get; }
        public String SiteName { set; get; }
        public String FacilityName { set; get; }
        public String InspectionPlanName{set; get;}
        public String InspectionCoverageName{set; get;}
        public String EquipmentNumber{set; get;}
        public String ComponentNumber{set; get;}
        public String DM{set; get;}
        public String InspectionType{set; get;}
        public DateTime InspectionDate{set; get;}
        public String InspectionEffective{set; get;}
    }
}
