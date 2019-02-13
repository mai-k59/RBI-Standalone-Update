using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_REVISION_INSPECTION_BUS
    {
        RW_REVISION_INSPECTION_ConnectUtils DAL = new RW_REVISION_INSPECTION_ConnectUtils();
        public void add(RW_REVISION_INSPECTION obj)
        {
            DAL.add(obj.ID, obj.CoverageDetailID, obj.InspPlanName, obj.CoverageName, obj.DMItemID, obj.IMTypeID, obj.InspectionDate, obj.EffectivenessCode, obj.Findings, obj.FindingRTF);
        }
        public void edit(RW_REVISION_INSPECTION obj)
        {
            DAL.edit(obj.ID, obj.CoverageDetailID, obj.InspPlanName, obj.CoverageName, obj.DMItemID, obj.IMTypeID, obj.InspectionDate, obj.EffectivenessCode, obj.Findings, obj.FindingRTF);
        }
        public void delete(RW_REVISION_INSPECTION obj)
        {
            DAL.delete(obj.ID, obj.CoverageDetailID);
        }
        public List<RW_REVISION_INSPECTION> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
