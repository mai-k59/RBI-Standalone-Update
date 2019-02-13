using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class POINTS
    {
        public int PointID { get; set; }
        public String PointName { get; set; }
        public int ComponentID { get; set; }
        public float CorrosionRate{get;set;}
        public float NominalThickness { get; set; }
        public float MinReqThickness { get; set; }
        public float ThicknessCurrent { get; set; }
        public float ThicknessPrevious { get; set; }
        public DateTime DateCurrent { get; set; }
        public DateTime  DatePrevious {get;set;}
        }
}
