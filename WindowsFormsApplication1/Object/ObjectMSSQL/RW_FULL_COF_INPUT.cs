using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_FULL_COF_INPUT
    {
        public int ID { get; set; }
        public String Mitigation { get; set; }
        public String DetectionType { get; set; }
        public String IsolationType { get; set; }
        public float mass_comp { get; set; }
        public float mass_inv { get; set; }
    }
}
