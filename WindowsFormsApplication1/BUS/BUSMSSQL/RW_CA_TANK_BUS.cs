using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class RW_CA_TANK_BUS
    {
        RW_CA_TANK_ConnUtils DAL = new RW_CA_TANK_ConnUtils();
        public void add(RW_CA_TANK obj)
        {
            DAL.add(obj.ID, obj.Hydraulic_Water, obj.Hydraulic_Fluid, obj.Seepage_Velocity, obj.Flow_Rate_D1, obj.Flow_Rate_D2, obj.Flow_Rate_D3, obj.Flow_Rate_D4, obj.Leak_Duration_D1, obj.Leak_Duration_D2, obj.Leak_Duration_D3, obj.Leak_Duration_D4, obj.Release_Volume_Leak_D1, obj.Release_Volume_Leak_D2, obj.Release_Volume_Leak_D3, obj.Release_Volume_Leak_D4, obj.Release_Volume_Rupture, obj.Liquid_Height, obj.Volume_Fluid, obj.Time_Leak_Ground, obj.Volume_SubSoil_Leak_D1, obj.Volume_SubSoil_Leak_D4, obj.Volume_Ground_Water_Leak_D1, obj.Volume_Ground_Water_Leak_D4, obj.Barrel_Dike_Leak, obj.Barrel_Dike_Rupture, obj.Barrel_Onsite_Leak, obj.Barrel_Onsite_Rupture, obj.Barrel_Offsite_Leak, obj.Barrel_Offsite_Rupture, obj.Barrel_Water_Leak, obj.Barrel_Water_Rupture, obj.FC_Environ_Leak, obj.FC_Environ_Rupture, obj.FC_Environ, obj.Material_Factor, obj.Component_Damage_Cost, obj.Business_Cost, obj.Consequence, obj.ConsequenceCategory);
        }
        public void edit(RW_CA_TANK obj)
        {
            DAL.edit(obj.ID, obj.Hydraulic_Water, obj.Hydraulic_Fluid, obj.Seepage_Velocity, obj.Flow_Rate_D1, obj.Flow_Rate_D2, obj.Flow_Rate_D3, obj.Flow_Rate_D4, obj.Leak_Duration_D1, obj.Leak_Duration_D2, obj.Leak_Duration_D3, obj.Leak_Duration_D4, obj.Release_Volume_Leak_D1, obj.Release_Volume_Leak_D2, obj.Release_Volume_Leak_D3, obj.Release_Volume_Leak_D4, obj.Release_Volume_Rupture, obj.Liquid_Height, obj.Volume_Fluid, obj.Time_Leak_Ground, obj.Volume_SubSoil_Leak_D1, obj.Volume_SubSoil_Leak_D4, obj.Volume_Ground_Water_Leak_D1, obj.Volume_Ground_Water_Leak_D4, obj.Barrel_Dike_Leak, obj.Barrel_Dike_Rupture, obj.Barrel_Onsite_Leak, obj.Barrel_Onsite_Rupture, obj.Barrel_Offsite_Leak, obj.Barrel_Offsite_Rupture, obj.Barrel_Water_Leak, obj.Barrel_Water_Rupture, obj.FC_Environ_Leak, obj.FC_Environ_Rupture, obj.FC_Environ, obj.Material_Factor, obj.Component_Damage_Cost, obj.Business_Cost, obj.Consequence, obj.ConsequenceCategory);
        }
        public void delete(RW_CA_TANK obj)
        {
            DAL.delete(obj.ID);
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public RW_CA_TANK getData(int ID)
        {
            return DAL.getData(ID);
        }
        public bool  CheckExistID(int ID)
        {
            return DAL.CheckExistID(ID);
        }
    }
}
