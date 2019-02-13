using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_FULL_COF_HOLE_SIZE
    {
        public int ID { get; set; }
        public String GFF_n { get; set; }
        public float An { get; set; }
        public float Wn { get; set; }
        public float t_n { get; set; }
        public float ld_max_n { get; set; }
        public float mass_add_n { get; set; }
        public float mass_avail_n { get; set; }
        public float rate_n { get; set; }
        public float ld_n { get; set; }
        public float mass_n { get; set; }
        public float eneff_n { get; set; }
        public float factIC_n { get; set; }
        public String ReleaseType_n { get; set; }
    }
}
