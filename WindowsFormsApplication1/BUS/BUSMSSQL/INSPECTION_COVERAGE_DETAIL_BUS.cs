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
    class INSPECTION_COVERAGE_DETAIL_BUS
    {
        INSPECTION_COVERAGE_DETAIL_ConnectUtils DAL = new INSPECTION_COVERAGE_DETAIL_ConnectUtils();
        public void add(INSPECTION_COVERAGE_DETAIL obj)
        {
            DAL.add(obj.CoverageID, obj.ComponentID, obj.DMItemID, obj.IMTypeID, obj.InspectionDate, obj.EffectivenessCode, obj.CarriedOut, obj.CarriedOutDate);
        }
        public void edit(INSPECTION_COVERAGE_DETAIL obj)
        {
            DAL.edit(obj.CoverageDetailID,obj.CoverageID, obj.ComponentID, obj.DMItemID, obj.IMTypeID, obj.InspectionDate, obj.EffectivenessCode, obj.CarriedOut, obj.CarriedOutDate);
        }
        public void delete(INSPECTION_COVERAGE_DETAIL obj)
        {
            DAL.delete(obj.CoverageDetailID);
        }
        public List<INSPECTION_COVERAGE_DETAIL> getDataSource()
        {
            return DAL.getDataSource();
        }

    }
}
