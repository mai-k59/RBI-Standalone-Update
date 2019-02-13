using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class API_COMPONENT_TYPE
    {
        public int APIComponentTypeID { set; get; }
        public String APIComponentTypeName{set; get;}
        public float GFFSmall{set; get;}
        public float GFFMedium{set; get;}
        public float GFFLarge{set; get;}
        public float GFFRupture{set; get;}
        public float GFFTotal{set; get;}
        public float HoleCostSmall{set; get;}
        public float HoleCostMedium{set; get;}
        public float HoleCostLarge{set; get;}
        public float HoleCostRupture{set; get;}
        public float OutageSmall{set; get;}
        public float OutageMedium{set; get;}
        public float OutageLarge{set; get;}
        public float OutageRupture{set; get;}
    }
}
