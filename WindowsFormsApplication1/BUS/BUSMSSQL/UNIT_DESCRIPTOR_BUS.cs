using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class UNIT_DESCRIPTOR_BUS
    {
        UNIT_DESCRIPTOR_ConnectUtils DAL = new UNIT_DESCRIPTOR_ConnectUtils();
        public void add(UNIT_DESCRIPTOR obj)
        {
            DAL.add(obj.UnitDescriptorID, obj.UnitCode, obj.UnitDescriptor);
        }
        public void edit(UNIT_DESCRIPTOR obj)
        {
            DAL.edit(obj.UnitDescriptorID, obj.UnitCode, obj.UnitDescriptor);
        }
        public void delete(UNIT_DESCRIPTOR obj)
        {
            DAL.delete(obj.UnitDescriptorID);
        }
        public List<UNIT_DESCRIPTOR> getDataSource()
        {
            return DAL.getDataSource();
        }
        
    }
}
