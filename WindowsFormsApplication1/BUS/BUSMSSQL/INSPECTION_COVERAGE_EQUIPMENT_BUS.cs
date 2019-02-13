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
    class INSPECTION_COVERAGE_EQUIPMENT_BUS
    {
        INSPECTION_COVERAGE_EQUIPMENT_ConnectUtils DAL = new INSPECTION_COVERAGE_EQUIPMENT_ConnectUtils();
        public void add(INSPECTION_COVERAGE_EQUIPMENT obj)
        {
            DAL.add(obj.CoverageID, obj.EquipmentID);
        }
        public void edit(INSPECTION_COVERAGE_EQUIPMENT obj)
        {
            DAL.edit(obj.CoverageID, obj.EquipmentID);
        }
        public void delete(INSPECTION_COVERAGE_EQUIPMENT obj)
        {
            DAL.delete(obj.CoverageID);
                
        }
        public List<INSPECTION_COVERAGE_EQUIPMENT> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
