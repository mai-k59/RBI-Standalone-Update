using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class SAFETY_FACTORS_BUS
    {
        SAFETY_FACTORS_ConnectUtils DAL = new SAFETY_FACTORS_ConnectUtils();
        public void add(SAFETY_FACTORS obj)
        {
            DAL.add(obj.SafetyFactorID, obj.SafetyFactorName, obj.A, obj.B, obj.C, obj.D, obj.E);
        }
        public void edit(SAFETY_FACTORS obj)
        {
            DAL.edit(obj.SafetyFactorID, obj.SafetyFactorName, obj.A, obj.B, obj.C, obj.D, obj.E);
        }
        public void delete(SAFETY_FACTORS obj)
        {
            DAL.delete(obj.SafetyFactorID);
        }
        public List<SAFETY_FACTORS> getDataSource()
        {
            return DAL.getDataSource();
        }

    }
}
