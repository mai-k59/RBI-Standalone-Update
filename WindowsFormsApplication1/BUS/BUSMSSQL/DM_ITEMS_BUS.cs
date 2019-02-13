using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class DM_ITEMS_BUS
    {
        DM_ITEMS_ConnectUtils DAL = new DM_ITEMS_ConnectUtils();
        public void add(DM_ITEMS obj)
        {
            DAL.add(obj.DMItemID, obj.DMDescription, obj.DMSeq, obj.DMCategoryID, obj.DMCode, obj.HasDF, obj.FailureMode);
        }
        public void edit(DM_ITEMS obj)
        {
            DAL.edit(obj.DMItemID,obj.DMDescription,obj.DMSeq,obj.DMCategoryID,obj.DMCode,obj.HasDF,obj.FailureMode);
        }
        public void delete(DM_ITEMS obj)
        {
            DAL.delete(obj.DMItemID);
        }
        public List<DM_ITEMS> getDataSource()
        {
            return DAL.getDataSource();
        }

    }
}