using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class FACILITY
    {
        public int FacilityID { set; get; }
        public int SiteID { set; get; }
        public String FacilityName { set; get; }
        public float ManagementFactor { set; get; }
    }
}
