using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class COMPONENT_MODELLING_BUS
    {
        COMPONENT_MODELLING_ConnectUtils DAL = new COMPONENT_MODELLING_ConnectUtils();
        public void add(COMPONENT_MODELLING obj)
        {
            DAL.add(obj.ComponentID, obj.ObjectName);
        }
        public void edit(COMPONENT_MODELLING obj)
        {
            DAL.edit(obj.ID, obj.ComponentID, obj.ObjectName);
        }
        public void delete(COMPONENT_MODELLING obj)
        {
            DAL.delete(obj.ID);
        }
        public List<COMPONENT_MODELLING> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
