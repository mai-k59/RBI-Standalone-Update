using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class DM_CATEGORY_BUS
    {
        DM_CATEGORY_ConnectUtils DAL = new DM_CATEGORY_ConnectUtils();
        public void add(DM_CATEGORY obj)
        {
            DAL.add(obj.DMCategoryID, obj.DMCategoryName);
        }
        public void edit(DM_CATEGORY obj)
        {
            DAL.edit(obj.DMCategoryID, obj.DMCategoryName);
        }
        public void delete(DM_CATEGORY obj)
        {
            DAL.delete(obj.DMCategoryID);
        }
        public List<DM_CATEGORY> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
