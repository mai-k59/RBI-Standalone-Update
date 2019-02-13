using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_FULL_FCOF
    {
        public int ID { get; set; }
        public float FCoFValue { get; set; }
        public String FCoFCategory { get; set; }
        public int AIL { get; set; }
        public float envcost { get; set; }
        public float equipcost { get; set; }
        public float prodcost { get; set; }
        public float popdens { get; set; }
        public float injcost { get; set; }
        public float FCoFMatrixValue { get; set; }
    }
}
