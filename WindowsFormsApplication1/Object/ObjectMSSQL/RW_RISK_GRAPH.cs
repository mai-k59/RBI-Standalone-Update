using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_RISK_GRAPH
    {
        public int ID { set; get; }
        public float RiskTarget { set; get; }
        public float[] Risk
        {
            set
            {
                risk = value;
            }
            get
            {
                return risk;
            }
        }

        private float[] risk = new float[15];
    }
}
