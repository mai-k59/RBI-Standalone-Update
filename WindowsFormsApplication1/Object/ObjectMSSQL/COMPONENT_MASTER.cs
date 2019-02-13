using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class COMPONENT_MASTER
    {
        public int ComponentID { set; get; }
        public String ComponentNumber { set; get; }
        public int EquipmentID { set; get; }
        public int ComponentTypeID { set; get; }
        public String ComponentName { set; get; }
        public String ComponentDesc { set; get; }
        public int IsEquipment { set; get; }
        public int IsEquipmentLinked { set; get; }
        public int APIComponentTypeID { set; get; }
    }
}
