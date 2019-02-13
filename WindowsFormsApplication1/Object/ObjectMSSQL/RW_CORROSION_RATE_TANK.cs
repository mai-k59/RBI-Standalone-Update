using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_CORROSION_RATE_TANK
    {
        public float ID { get; set; }
        public String CorrosionID { get; set; }
        public float SoilSideCorrosionRate { get; set; }
        public float ProductSideCorrosionRate { get; set; }
        public String PotentialCorrosion { get; set; }
        public String TankPadMaterial { get; set; }
        public String TankDrainageType { get; set; }
        public String CathodicProtectionType { get; set; }
        public String TankBottomType { get; set; }
        public String SoilSideTemperature { get; set; }
        public String ProductCondition { get; set; }
        public String ProductSideTemp { get; set; }
        public String SteamCoil { get; set; }
        public String WaterDrawOff { get; set; }
        public String ProductSideBottom { get; set; }
        public float ModifiedSoilSideCorrosionRate { get; set; }
        public float ModifiedProductSideCorrosionRate { get; set; }
        public float FinalEstimatedCorrosionRate { get; set; }
    }
}
