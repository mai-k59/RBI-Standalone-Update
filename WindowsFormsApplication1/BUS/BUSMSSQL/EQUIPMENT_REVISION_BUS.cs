using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class EQUIPMENT_REVISION_BUS
    {
        EQUIPMENT_REVISION_ConnectUtils DAL = new EQUIPMENT_REVISION_ConnectUtils();
        public void add(EQUIPMENT_REVISION obj)
        {
            DAL.add(obj.EquipmentID, obj.RevisionXML, obj.RevisionNo, obj.IssuedBy, obj.IssuedDate,
                       obj.ReviewedBy, obj.ReviewedDate, obj.IsReviewed, obj.ApprovedBy, obj.ApprovedDate,
                       obj.IsApproved, obj.EndorsedBy, obj.EndorsedDate);

        }
        public void edit(EQUIPMENT_REVISION obj)
        {
            DAL.edit(obj.RevisionID, obj.EquipmentID, obj.RevisionXML, obj.RevisionNo, obj.IssuedBy, obj.IssuedDate,
                       obj.ReviewedBy, obj.ReviewedDate, obj.IsReviewed, obj.ApprovedBy, obj.ApprovedDate,
                       obj.IsApproved, obj.EndorsedBy, obj.EndorsedDate);
        }
        public void delete(EQUIPMENT_REVISION obj)
        {
            DAL.delete(obj.RevisionID);
        }
        public List<EQUIPMENT_REVISION> getDataSource()
        {
            return DAL.getDataSource();
        }

    }
}
