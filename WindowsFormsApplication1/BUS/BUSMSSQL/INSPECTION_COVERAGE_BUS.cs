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
    class INSPECTION_COVERAGE_BUS
    {
        INSPECTION_COVERAGE_ConnectUtils DAL = new INSPECTION_COVERAGE_ConnectUtils();
        public void add(INSPECTION_COVERAGE obj)
        {
            DAL.add(obj.PlanID, obj.CoverageName, obj.CoverageDate, obj.Remarks, obj.Findings, obj.FindingRTF);
        }
        public void edit(INSPECTION_COVERAGE obj)
        {
            DAL.edit(obj.CoverageID, obj.PlanID, obj.CoverageName, obj.CoverageDate, obj.Remarks, obj.Findings, obj.FindingRTF);
        }
        public void delete(INSPECTION_COVERAGE obj)
        {
            DAL.delete(obj.CoverageID);
        }
        public List<INSPECTION_COVERAGE> getDataSource()
        {
            return DAL.getDataSource();
        }

    }
}
