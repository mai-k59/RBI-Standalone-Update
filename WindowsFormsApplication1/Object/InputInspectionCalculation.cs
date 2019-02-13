using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object
{
    class InputInspectionCalculation
    {
        public int EquipmentID { set; get; }
        public float GFFTotal { set; get; }
        public float FMS { set; get; }
        public string ComponentNumber { set; get; }
        public string ApiComponentType { set; get; }
        public float[] DFTotal { set; get; }
        public float[] DF 
        { 
            set
            {
                df = value;
            }
            get
            {
                return df;
            }
        }
        public float[] Age { set; get; }
        private float[] df;
    }
}
