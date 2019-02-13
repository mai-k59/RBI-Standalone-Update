using RBI.DAL.MSSQL;
using RBI.Object;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class GENERIC_MATERIAL_BUS
    {
        GENERIC_MATERIAL_ConnectUtils DAL = new GENERIC_MATERIAL_ConnectUtils();
        public void add(GENERIC_MATERIAL obj)
        {
            DAL.add(obj.MaterialName, obj.DesignPressure, obj.DesignTemperature, obj.MinDesignTemperature, obj.CorrosionAllowance,
                        obj.SigmaPhase, obj.SulfurContent, obj.HeatTreatment, obj.ReferenceTemperature, obj.PTAMaterialCode, obj.HTHAMaterialCode,
                        obj.IsPTA, obj.IsHTHA, obj.Austenitic, obj.Temper, obj.CarbonLowAlloy, obj.NickelBased,
                        obj.ChromeMoreEqual12, obj.CostFactor);
        }
        public void edit(GENERIC_MATERIAL obj)
        {
            DAL.edit(obj.ID,obj.MaterialName, obj.DesignPressure, obj.DesignTemperature, obj.MinDesignTemperature, obj.CorrosionAllowance,
                        obj.SigmaPhase, obj.SulfurContent, obj.HeatTreatment, obj.ReferenceTemperature, obj.PTAMaterialCode, obj.HTHAMaterialCode,
                        obj.IsPTA, obj.IsHTHA, obj.Austenitic, obj.Temper, obj.CarbonLowAlloy, obj.NickelBased,
                        obj.ChromeMoreEqual12, obj.CostFactor);
        }
        public void delete(GENERIC_MATERIAL obj)
        {
            DAL.delete(obj.ID);
        }
        public List<GENERIC_MATERIAL> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
