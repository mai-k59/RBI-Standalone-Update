using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_CA_TANK
    {
        public int ID { set; get; }
        public float Hydraulic_Water { set; get; }
        public float Hydraulic_Fluid { set; get; }
        public float Seepage_Velocity { set; get; }
        public float Flow_Rate_D1 { set; get; }
        public float Flow_Rate_D2 { set; get; }
        public float Flow_Rate_D3 { set; get; }
        public float Flow_Rate_D4 { set; get; }
        public float Leak_Duration_D1 { set; get; }
        public float Leak_Duration_D2 { set; get; }
        public float Leak_Duration_D3 { set; get; }
        public float Leak_Duration_D4 { set; get; }
        public float Release_Volume_Leak_D1 { set; get; }
        public float Release_Volume_Leak_D2 { set; get; }
        public float Release_Volume_Leak_D3 { set; get; }
        public float Release_Volume_Leak_D4 { set; get; }
        public float Release_Volume_Rupture { set; get; }
        public float Liquid_Height { set; get; }
        public float Volume_Fluid { set; get; }
        public float Time_Leak_Ground { set; get; }
        public float Volume_SubSoil_Leak_D1 { set; get; }
        public float Volume_SubSoil_Leak_D4 { set; get; }
        public float Volume_Ground_Water_Leak_D1 { set; get; }
        public float Volume_Ground_Water_Leak_D4 { set; get; }
        public float Barrel_Dike_Leak { set; get; }
        public float Barrel_Dike_Rupture { set; get; }
        public float Barrel_Onsite_Leak { set; get; }
        public float Barrel_Onsite_Rupture { set; get; }
        public float Barrel_Offsite_Leak { set; get; }
        public float Barrel_Offsite_Rupture { set; get; }
        public float Barrel_Water_Leak { set; get; }
        public float Barrel_Water_Rupture { set; get; }
        public float FC_Environ_Leak { set; get; }
        public float FC_Environ_Rupture { set; get; }
        public float FC_Environ { set; get; }
        public float Material_Factor { set; get; }
        public float Component_Damage_Cost { set; get; }
        public float Business_Cost { set; get; }
        public float Consequence { set; get; }
        public String ConsequenceCategory { set; get; }
    }
}
