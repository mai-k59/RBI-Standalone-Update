using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_LF_MASTER_BUS
    {
        RW_LF_MASTER_ConnectUtils DAL = new RW_LF_MASTER_ConnectUtils();
        public void add(RW_LF_MASTER obj)
        {
            DAL.add(obj.ID, obj.LF1Factor, obj.LF4Factor, obj.LF5Factor, obj.LF6Factor, obj.LF6Factor, obj.LF1, obj.LF4, obj.LF5.ToString(), obj.LF6.ToString(), obj.LF7);
        }
        public void edit(RW_LF_MASTER obj)
        {
            DAL.edit(obj.ID, obj.LF1Factor, obj.LF4Factor, obj.LF5Factor, obj.LF6Factor, obj.LF6Factor, obj.LF1, obj.LF4, obj.LF5, obj.LF6, obj.LF7);

        }
        public void delete(RW_LF_MASTER obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_LF_MASTER> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
