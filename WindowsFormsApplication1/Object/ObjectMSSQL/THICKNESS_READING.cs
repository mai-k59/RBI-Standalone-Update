using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class THICKNESS_READING
    {
        public int ThicknessID { set; get; }
        public int PointID { set; get; }
        public DateTime ThicknessDate { set; get; }
        public String Orientation { set; get; }
        public float MaxReading { set; get; }
        public float ThicknessReading { set; get; }
        public float CorrosionRate { set; get; }
        public int ValidReading { set; get; }
        public String Comment { set; get; }
    }
}
