using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class EQUIPMENT_REVISION_INSPECTION_BUS
    {
        EQUIPMENT_REVISION_INSPECTION_Connectutils DAL = new EQUIPMENT_REVISION_INSPECTION_Connectutils();
        public void add(EQUIPMENT_REVISION_INSPECTION obj)
        {
            DAL.add(obj.RevisionID, obj.CoverageDetailID, obj.ComponentNumber, obj.CoverageID, obj.DMItemID,
                        obj.IMTypeID, obj.InspectionDate, obj.EffectivenessCode, obj.CarriedOut, obj.CarriedOutDate);
        }
        public void edit(EQUIPMENT_REVISION_INSPECTION obj)
        {
            DAL.edit(obj.RevisionID, obj.CoverageDetailID, obj.ComponentNumber, obj.CoverageID, obj.DMItemID,
                        obj.IMTypeID, obj.InspectionDate, obj.EffectivenessCode, obj.CarriedOut, obj.CarriedOutDate);
        }
        public void delete(EQUIPMENT_REVISION_INSPECTION obj)
        {
            DAL.delete(obj.RevisionID, obj.CoverageDetailID);
        }
        public List<EQUIPMENT_REVISION_INSPECTION> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
