using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_POINTS
    {
        public int ID { set; get; }
        public int PointID { set; get; }
        public String PointName { set; get; }
        public String GaugePoint { set; get; }
        public String PointLocation { set; get; }
        public String PIDNo { set; get; }
        public String FittingDesc { set; get; }
        public String Specification { set; get; }
        public String Size { set; get; }
        public float MinReqThickness { set; get; }
        public float ThicknessReading { set; get; }
        public DateTime ThicknessDate { set; get; }
        public float NominalThickness { set; get; }
        public float EstimatedCorrosionRate { set; get; }
        public float CalculatedCorrosionRate { set; get; }
        public float CalculatedRemainingLife { set; get; }
        public float k { set; get; }
    }
}
