using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class EQUIPMENT_REVISION_INSPECTION_COVERAGE_BUS
    {
        EQUIPMENT_REVISION_INSPECTION_COVERAGE_ConnectUtils DAL = new EQUIPMENT_REVISION_INSPECTION_COVERAGE_ConnectUtils();
        public void add(EQUIPMENT_REVISION_INSPECTION_COVERAGE obj)
        {
            DAL.add(obj.RevisionID, obj.CoverageID, obj.InspPlanName, obj.InspPlanDate, obj.CoverageName,
                       obj.CoverageDate, obj.Remarks, obj.Findings, obj.FindingRTF);
        }
        public void edit(EQUIPMENT_REVISION_INSPECTION_COVERAGE obj)
        {
            DAL.edit(obj.RevisionID, obj.CoverageID, obj.InspPlanName, obj.InspPlanDate, obj.CoverageName,
                       obj.CoverageDate, obj.Remarks, obj.Findings, obj.FindingRTF);
        }
        public void delete(EQUIPMENT_REVISION_INSPECTION_COVERAGE obj)
        {
            DAL.delete(obj.RevisionID, obj.CoverageID);
        }
        public List<EQUIPMENT_REVISION_INSPECTION_COVERAGE> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
