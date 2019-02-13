using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class EQUIPMENT_MASTER
    {
        public int EquipmentID { set; get; }
        public String EquipmentNumber { set; get; }
        public int EquipmentTypeID { set; get; }
        public String EquipmentName { set; get; }
        public DateTime CommissionDate { set; get; }
        public int DesignCodeID { set; get; }
        public int SiteID { set; get; }
        public int FacilityID { set; get; }
        public int ManufacturerID { set; get; }
        public String PFDNo { set; get; }
        public String ProcessDescription { set; get; }
        public String EquipmentDesc { set; get; }
        public int IsArchived { set; get; }
        public DateTime Archived { set; get; }
        public String ArchivedBy { set; get; }
    }
}
