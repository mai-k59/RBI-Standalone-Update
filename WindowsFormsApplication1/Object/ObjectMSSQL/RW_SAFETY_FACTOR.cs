using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_SAFETY_FACTOR
    {
        public int ID { set; get; }
        public String SafetyFactorScheme { set; get; }
        public float A { set; get; }
        public float B { set; get; }
        public float C { set; get; }
        public float D { set; get; }
        public float E { set; get; }
    }
}
