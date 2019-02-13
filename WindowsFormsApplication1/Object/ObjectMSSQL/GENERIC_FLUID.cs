using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class GENERIC_FLUID
    {
        public int GenericFluidID { get; set; }
        public String GenericFluid { get; set; } //gan bang Fluid
        public float NBP { get; set; }
        public float MW { get; set; }
        public float Density { get; set; }
        public int ChemicalFactor { get; set; }//mac dinh la bang 0
        public int HealthDegree { get; set; }
        public int Flammability { get; set; }
        public int Reactivity { get; set; }
    }
}
