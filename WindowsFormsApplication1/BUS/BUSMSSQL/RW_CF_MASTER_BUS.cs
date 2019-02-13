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
    class RW_CF_MASTER_BUS
    {
        RW_CF_MASTER_ConnectUtils DAL = new RW_CF_MASTER_ConnectUtils();
        public void add(RW_CF_MASTER obj)
        {
            DAL.add(obj.ID, obj.CF1, obj.CF2, obj.CF3, obj.CF4, obj.CF5, obj.CF6, obj.CF7, obj.CF8, obj.CF9);
        }
        public void edit(RW_CF_MASTER obj)
        {
            DAL.edit(obj.ID, obj.CF1, obj.CF2, obj.CF3, obj.CF4, obj.CF5, obj.CF6, obj.CF7, obj.CF8, obj.CF9);
        }
        public void delete(RW_CF_MASTER obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_CF_MASTER> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
