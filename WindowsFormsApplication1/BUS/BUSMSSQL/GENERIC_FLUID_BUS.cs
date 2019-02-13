
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
    class GENERIC_FLUID_BUS
    {
        GENERIC_FLUID_ConnectUtils DAL = new GENERIC_FLUID_ConnectUtils();
        public void add(GENERIC_FLUID obj)
        {
            DAL.add(obj.GenericFluid, obj.NBP, obj.MW, obj.Density, obj.ChemicalFactor, obj.HealthDegree,
                       obj.Flammability, obj.Reactivity);
        }
        public void edit(GENERIC_FLUID obj)
        {
            DAL.edit(obj.GenericFluidID, obj.GenericFluid, obj.NBP, obj.MW, obj.Density, obj.ChemicalFactor, obj.HealthDegree,
                       obj.Flammability, obj.Reactivity);
        }
        public void delete(GENERIC_FLUID obj)
        {
            DAL.delete(obj.GenericFluidID);
        }
        public List<GENERIC_FLUID> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
