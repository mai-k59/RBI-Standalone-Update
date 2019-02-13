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
    class IM_TYPE_BUS
    {
        IM_TYPE_ConnectUtils DAL = new IM_TYPE_ConnectUtils();
        public void add(IM_TYPE obj )
        {
            DAL.add(obj.IMTypeID, obj.IMTypeName, obj.IMTypeCode, obj.IMItemID);
        }
        public void edit(IM_TYPE obj)
        {
            DAL.edit(obj.IMTypeID, obj.IMTypeName, obj.IMTypeCode, obj.IMItemID);
        }
        public void delete(IM_TYPE obj)
        {
            DAL.delete(obj.IMTypeID);
        }
        public List<IM_TYPE> getDataSource()
        {
            return DAL.getDataSource();
        }
        
    }
}
