using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class IMAGE_FACILITY
    {
        public int ImageID { get; set; }
        public int FacilityID { get; set; }
        public String ImageName { get; set; }
        public String ImageDescription { get; set; }
        public byte[] ImageBinary { get; set; }
        public byte[] ImageBinarySmall { get; set; }
    }
}
