using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class INSPECTION_PLAN
    {
        public int PlanID { get; set; }
        public String InspPlanName { get; set; }
        public DateTime InspPlanDate { get; set; }
        public String Remarks { get; set; }
    }
}
