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
    class RW_FULL_COF_BUS
    {
        RW_FULL_COF_ConnectUtils DAL = new RW_FULL_COF_ConnectUtils();
        public void add (RW_FULL_COF obj)
        {
            DAL.add(obj.ID, obj.CoFValue, obj.CoFCategory, obj.CoFMatrixValue);
        }
        public void edit(RW_FULL_COF obj)
        {
            DAL.edit(obj.ID, obj.CoFValue, obj.CoFCategory, obj.CoFMatrixValue);
        }
        public void delete(RW_FULL_COF obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_FULL_COF> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
