using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_SAFETY_FACTOR_BUS
    {
        RW_SAFETY_FACTOR_ConnectUtils DAL = new RW_SAFETY_FACTOR_ConnectUtils();
        public void add(RW_SAFETY_FACTOR obj)
        {
            DAL.add(obj.ID, obj.SafetyFactorScheme, obj.A, obj.B, obj.C, obj.D, obj.E);

        }
        public void edit(RW_SAFETY_FACTOR obj)
        {
            DAL.edit(obj.ID, obj.SafetyFactorScheme, obj.A, obj.B, obj.C, obj.D, obj.E);
        }
        public void delete(RW_SAFETY_FACTOR obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_SAFETY_FACTOR> getDataSource()
        {
            return DAL.getDataSource();
        }
        public Boolean isExist(int ID)
        {
            return DAL.isExist(ID);
        }

    }
}
