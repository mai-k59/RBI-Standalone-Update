using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_INPUT_CA_TANK
    {
        public int ID { set; get; }
        public float FLUID_HEIGHT { set; get; }
        public float SHELL_COURSE_HEIGHT { set; get; }
        public float TANK_DIAMETTER { set; get; }
        public int Prevention_Barrier { set; get; }
        public String Environ_Sensitivity { set; get; }
        public float P_lvdike { set; get; }
        public float P_onsite { set; get; }
        public float P_offsite { set; get; }
        public String Soil_Type { set; get; }
        public String TANK_FLUID { set; get; }
        public String API_FLUID { set; get; }
        public float SW { set; get; }
        public float ProductionCost { set; get; }
    }
}
