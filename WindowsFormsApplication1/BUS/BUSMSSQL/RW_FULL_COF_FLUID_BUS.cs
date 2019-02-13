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
    class RW_FULL_COF_FLUID_BUS
    {
        RW_FULL_COF_FLUID_ConnectUtils DAL = new RW_FULL_COF_FLUID_ConnectUtils();
        public void add(RW_FULL_COF_FLUID obj)
        {
            DAL.add(obj.ID, obj.Cp, obj.k, obj.GFFTotal, obj.Kv_n, obj.ReleasePhase, obj.Cd, obj.Ptrans, obj.NBP, obj.Density, obj.MW, obj.R, obj.Ps, obj.Ts, obj.Patm, obj.fact_di, obj.fact_mit, obj.fact_AIT, obj.g, obj.h);
        }
    }
}
