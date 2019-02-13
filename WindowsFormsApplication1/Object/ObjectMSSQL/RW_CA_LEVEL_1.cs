using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_CA_LEVEL_1
    {
        public int ID { set; get; }
        public String Release_Phase{set; get;}
        public float fact_di{set; get;}
        public float fact_mit{set; get;}
        public float fact_ait{set; get;}
        public float CA_cmd{set; get;}
        public float CA_inj_flame{set; get;}
        public float CA_inj_toxic{set; get;}
        public float CA_inj_ntnf{set; get;}
        public float FC_cmd{set; get;}
        public float FC_affa{set; get;}
        public float FC_prod{set; get;}
        public float FC_inj{set; get;}
        public float FC_envi{set; get;}
        public float FC_total{set; get;}
        public String FCOF_Category{set; get;}
    }
}
