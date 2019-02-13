using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_THICKNESS
    {
        public int ID { set; get; }
        public int PointID { set; get; }
        public int ThicknessID { set; get; }
        public DateTime ThicknessDate { set; get; }
        public float MinReading { set; get; }
        public float MaxReading { set; get; }
        public String Orientation { set; get; }
        public String InspectionComment { set; get; }
        public String AnalysisComment { set; get; }
        public int ValidReading { set; get; }
    }
}
