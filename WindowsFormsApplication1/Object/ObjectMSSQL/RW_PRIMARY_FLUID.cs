using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_PRIMARY_FLUID
    {
        public int ID { set; get; }
        public String FluidName { set; get; }
        public float NBP { set; get; }
        public float MW { set; get; }
        public float Density { set; get; }
        public int ChemicalFactor { set; get; }
        public int HealthDegree { set; get; }
        public int Flammability { set; get; }
        public int Reactivity { set; get; }
    }
}
