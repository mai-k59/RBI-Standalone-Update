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
    class IM_ITEMS_BUS
    {
        IM_ITEMS_ConnectUtils DAL = new IM_ITEMS_ConnectUtils();
        public void add(IM_ITEMS obj)
        {
            DAL.add(obj.IMItemID, obj.IMDescription, obj.IMCode);
        }
        public void edit(IM_ITEMS obj)
        {
            DAL.edit(obj.IMItemID, obj.IMDescription, obj.IMCode);
        }
        public void delete(IM_ITEMS obj)
        {
            DAL.delete(obj.IMItemID);
        }
        public List<IM_ITEMS> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
