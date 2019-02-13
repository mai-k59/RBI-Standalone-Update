using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class RW_INPUT_CA_LEVEL_1_BUS
    {
        RW_INPUT_CA_LEVEL_1_ConnUtils DAL = new RW_INPUT_CA_LEVEL_1_ConnUtils();
        public void add(RW_INPUT_CA_LEVEL_1 obj)
        {
            DAL.Add(obj.ID, obj.API_FLUID, obj.SYSTEM, obj.Release_Duration, obj.Detection_Type, obj.Isulation_Type, obj.Mitigation_System, obj.Equipment_Cost, obj.Injure_Cost, obj.Environment_Cost, obj.Toxic_Percent, obj.Personal_Density, obj.Material_Cost, obj.Production_Cost, obj.Mass_Inventory, obj.Mass_Component, obj.Stored_Pressure, obj.Stored_Temp);
        }
        public void edit(RW_INPUT_CA_LEVEL_1 obj)
        {
            DAL.Edit(obj.ID, obj.API_FLUID, obj.SYSTEM, obj.Release_Duration, obj.Detection_Type, obj.Isulation_Type, obj.Mitigation_System, obj.Equipment_Cost, obj.Injure_Cost, obj.Environment_Cost, obj.Toxic_Percent, obj.Personal_Density, obj.Material_Cost, obj.Production_Cost, obj.Mass_Inventory, obj.Mass_Component, obj.Stored_Pressure, obj.Stored_Temp);
        }
        public void delete(RW_INPUT_CA_LEVEL_1 obj)
        {
            DAL.Delete(obj.ID);
        }
        public void delete(int ID)
        {
            DAL.Delete(ID);
        }
        public RW_INPUT_CA_LEVEL_1 getData(int ID)
        {
            return DAL.GetData(ID);
        }
    }
}
