using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object;

namespace RBI.BUS.BUSMSSQL
{
    class RW_CORROSION_RATE_TANK_BUS
    {
        RW_CORROSION_RATE_TANK_ConnectUtils DAL = new RW_CORROSION_RATE_TANK_ConnectUtils();
        public void add(RW_CORROSION_RATE_TANK obj)
        {
            DAL.add((int)obj.ID, obj.SoilSideCorrosionRate, obj.ProductSideCorrosionRate, obj.PotentialCorrosion,
                        obj.TankPadMaterial, obj.TankDrainageType, obj.CathodicProtectionType, obj.TankBottomType, obj.SoilSideTemperature,
                        obj.ProductCondition, obj.ProductSideTemp, obj.SteamCoil, obj.WaterDrawOff,
                        obj.ProductSideBottom, obj.ModifiedSoilSideCorrosionRate, obj.ModifiedProductSideCorrosionRate, obj.FinalEstimatedCorrosionRate);
        }
        public void edit(RW_CORROSION_RATE_TANK obj)
        {
            DAL.edit(int.Parse(obj.CorrosionID), (int)(obj.ID), obj.SoilSideCorrosionRate, obj.ProductSideCorrosionRate, obj.PotentialCorrosion,
                        obj.TankPadMaterial, obj.TankDrainageType, obj.CathodicProtectionType, obj.TankBottomType, obj.SoilSideTemperature,
                        obj.ProductCondition, obj.ProductSideTemp, obj.SteamCoil, obj.WaterDrawOff,
                        obj.ProductSideBottom, obj.ModifiedSoilSideCorrosionRate, obj.ModifiedProductSideCorrosionRate, obj.FinalEstimatedCorrosionRate);
        }
        public void delete(RW_CORROSION_RATE_TANK obj)
        {
            DAL.delete(int.Parse(obj.CorrosionID));
        }
        public List<RW_CORROSION_RATE_TANK> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
