using RBI.DAL.MSSQL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_EQUIPMENT_BUS
    {
        RW_EQUIPMENT_ConnectUtils DAL = new RW_EQUIPMENT_ConnectUtils();
        public void add(RW_EQUIPMENT obj)
        {
            DAL.add(obj.ID, obj.CommissionDate, obj.AdminUpsetManagement, obj.ContainsDeadlegs, obj.CyclicOperation, obj.HighlyDeadlegInsp, obj.DowntimeProtectionUsed, obj.ExternalEnvironment, obj.HeatTraced, obj.InterfaceSoilWater, obj.LinerOnlineMonitoring, obj.MaterialExposedToClExt, obj.MinReqTemperaturePressurisation, obj.OnlineMonitoring, obj.PresenceSulphidesO2, obj.PresenceSulphidesO2Shutdown, obj.PressurisationControlled, obj.PWHT, obj.SteamOutWaterFlush, obj.ManagementFactor, obj.ThermalHistory, obj.YearLowestExpTemp, obj.Volume, obj.TypeOfSoil, obj.EnvironmentSensitivity, obj.DistanceToGroundWater, obj.AdjustmentSettle, obj.ComponentIsWelded, obj.TankIsMaintained);
        }
        public void edit(RW_EQUIPMENT obj)
        {
            DAL.edit(obj.ID, obj.AdminUpsetManagement, obj.ContainsDeadlegs, obj.CyclicOperation, obj.HighlyDeadlegInsp, obj.DowntimeProtectionUsed, obj.ExternalEnvironment, obj.HeatTraced, obj.InterfaceSoilWater, obj.LinerOnlineMonitoring, obj.MaterialExposedToClExt, obj.MinReqTemperaturePressurisation, obj.OnlineMonitoring, obj.PresenceSulphidesO2, obj.PresenceSulphidesO2Shutdown, obj.PressurisationControlled, obj.PWHT, obj.SteamOutWaterFlush, obj.ManagementFactor, obj.ThermalHistory, obj.YearLowestExpTemp, obj.Volume, obj.TypeOfSoil, obj.EnvironmentSensitivity, obj.DistanceToGroundWater, obj.AdjustmentSettle, obj.ComponentIsWelded, obj.TankIsMaintained);
         
        }
        public void delete(RW_EQUIPMENT obj)
        {
            DAL.delete(obj.ID);
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public List<RW_EQUIPMENT> getDataSource()
        {
            return DAL.getDataSource();
        }
        public RW_EQUIPMENT getData(int id)
        {
            return DAL.getdata(id);
        }
        public Boolean checkExistEquipment(int ID)
        {
            return DAL.checkExistEquipment(ID);
        }
        public List<int> getListID()
        {
            return DAL.getListID();
        }
    }
}
