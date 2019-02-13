using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class DM_EXPECTED_TYPE_BUS
    {
        DM_EXPECTED_TYPE_ConnectUtils DAL = new DM_EXPECTED_TYPE_ConnectUtils();
        public void add(DM_EXPECTED_TYPE obj)
        {
            DAL.add(obj.ExpectedTypeID, obj.ExpectedTypeName);
        }
        public void edit(DM_EXPECTED_TYPE obj)
        {
            DAL.edit(obj.ExpectedTypeID, obj.ExpectedTypeName);
        }
        public void delete(DM_EXPECTED_TYPE obj)
        {
            DAL.delete(obj.ExpectedTypeID);
        }
        public List<DM_EXPECTED_TYPE> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
