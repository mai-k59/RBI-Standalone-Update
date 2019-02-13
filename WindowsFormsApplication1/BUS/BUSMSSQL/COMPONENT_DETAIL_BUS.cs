using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RBI.BUS.BUSMSSQL
{
    class COMPONENT_DETAIL_BUS
    {
        COMPONENT_DETAIL_ConnectUtils DAL = new COMPONENT_DETAIL_ConnectUtils();
        public void add(COMPONENT_DETAIL obj)
        {
            DAL.add( obj.ComponentID, obj.MaterialID, obj.StreamID);
        }
        public void edit(COMPONENT_DETAIL obj)
        {
            DAL.edit(obj.ComponentID, obj.MaterialID, obj.StreamID);
        }
        public void delete(COMPONENT_DETAIL obj)
        {
            DAL.delete(obj.ComponentID);
        }
        public List<COMPONENT_DETAIL> getDataSource()
        {
            return DAL.getDataSource();
        }
        public COMPONENT_DETAIL getData(int ComponentID)
        {
            return DAL.getData(ComponentID);
        }
    }
}

