using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class EQUIPMENT_REVISION
    {
        public int RevisionID { set; get; }
        public int EquipmentID { set; get; }
        public String RevisionXML { set; get; }
        public int RevisionNo { set; get; }
        public String IssuedBy { set; get; }
        public DateTime IssuedDate { set; get; }
        public String ReviewedBy { set; get; }
        public DateTime ReviewedDate { set; get; }
        public int IsReviewed { set; get; }
        public String ApprovedBy { set; get; }
        public DateTime ApprovedDate { set; get; }
        public int IsApproved { set; get; }
        public String EndorsedBy { set; get; }
        public DateTime EndorsedDate { set; get; }
    }
}
