using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_MATERIAL_BUS
    {
        RW_MATERIAL_ConnectUtils DAL = new RW_MATERIAL_ConnectUtils();
        public void add(RW_MATERIAL obj)
        {
            DAL.add(obj.ID, obj.MaterialName, obj.DesignPressure, obj.DesignTemperature, obj.MinDesignTemperature, obj.BrittleFractureThickness, obj.CorrosionAllowance, obj.SigmaPhase, obj.SulfurContent, obj.HeatTreatment, obj.ReferenceTemperature, obj.PTAMaterialCode, obj.HTHAMaterialCode, obj.IsPTA, obj.IsHTHA, obj.Austenitic, obj.Temper, obj.CarbonLowAlloy, obj.NickelBased, obj.ChromeMoreEqual12, obj.AllowableStress, obj.CostFactor);
        }
        public void edit(RW_MATERIAL obj)
        {
            DAL.edit(obj.ID, obj.MaterialName, obj.DesignPressure, obj.DesignTemperature, obj.MinDesignTemperature, obj.BrittleFractureThickness, obj.CorrosionAllowance, obj.SigmaPhase, obj.SulfurContent, obj.HeatTreatment, obj.ReferenceTemperature, obj.PTAMaterialCode, obj.HTHAMaterialCode, obj.IsPTA, obj.IsHTHA, obj.Austenitic, obj.Temper, obj.CarbonLowAlloy, obj.NickelBased, obj.ChromeMoreEqual12, obj.AllowableStress, obj.CostFactor);
        }
        public void delete(RW_MATERIAL obj)
        {
            DAL.delete(obj.ID);
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public List<RW_MATERIAL> getDataSource()
        {
            return DAL.getDataSource();
        }
        public Boolean isExist(int ID)
        {
            return DAL.isExist(ID);
        }
        public RW_MATERIAL getData(int ID)
        {
            return DAL.getData(ID);
        }
    }
}
