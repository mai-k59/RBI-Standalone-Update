using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_FULL_COF_FLUID
    {
        public int ID { get; set; }
        public float Cp { get; set; }
        public float k { get; set; }
        public float GFFTotal { get; set; }
        public float Kv_n { get; set; }
        public String ReleasePhase { get; set; }
        public float Cd { get; set; }
        public float Ptrans { get; set; }
        public float NBP { get; set; }
        public float Density { get; set; }
        public float MW { get; set; }
        public float R { get; set; }
        public float Ps { get; set; }
        public float Ts { get; set; }
        public float Patm { get; set; }
        public float fact_di { get; set; }
        public float fact_mit { get; set; }
        public float fact_AIT { get; set; }
        public float g { get; set; }
        public float h { get; set; }
    }
}
