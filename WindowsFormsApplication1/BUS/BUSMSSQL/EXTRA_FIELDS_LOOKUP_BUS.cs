using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class EXTRA_FIELDS_LOOKUP_BUS
    {
        EXTRA_FIELDS_LOOKUP_ConnectUtils DAL = new EXTRA_FIELDS_LOOKUP_ConnectUtils();
        public void add(EXTRA_FIELDS_LOOKUP obj)
        {
            DAL.add(obj.ExtraFieldID, obj.LookupText, obj.LookupValue);
        }
        public void edit(EXTRA_FIELDS_LOOKUP obj)
        {
            DAL.edit(obj.LookupID, obj.ExtraFieldID, obj.LookupText, obj.LookupValue);
        }
        public void delete(EXTRA_FIELDS_LOOKUP obj)
        {
            DAL.delete(obj.LookupID);
        }
        public List<EXTRA_FIELDS_LOOKUP> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
