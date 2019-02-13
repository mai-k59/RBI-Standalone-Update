using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class COMPONENT_TYPE__BUS
    {
        COMPONENT_TYPE_ConnectUtils DAL = new COMPONENT_TYPE_ConnectUtils();
        public void add(COMPONENT_TYPE obj)
        {
            DAL.add(obj.ComponentTypeID, obj.ComponentTypeName, obj.ComponentTypeCode);
        }
        public void edit(COMPONENT_TYPE obj)
        {
            DAL.edit(obj.ComponentTypeID, obj.ComponentTypeName, obj.ComponentTypeCode);
        }
        public void delete(COMPONENT_TYPE obj)
        {
            DAL.delete(obj.ComponentTypeID);
        }
        public List<COMPONENT_TYPE> getDataSource()
        {
            return DAL.getDataSource();
        }
        public String getComponentTypeName(int typeID)
        {
            return DAL.getComponentTypeName(typeID);
        }
        public int getIDbyName(String name)
        {
            return DAL.getIDbyName(name);
        }
    }
}
