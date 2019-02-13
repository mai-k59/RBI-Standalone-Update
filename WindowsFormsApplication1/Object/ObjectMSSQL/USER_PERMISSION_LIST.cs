using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class USER_PERMISSION_LIST
    {
        public int PermissionID { set; get; }
        public String Category { set; get; }
        public String Permission { set; get; }
        public String Container { set; get; }
        public String Object { set; get; }
        public String ObjectType { set; get; }
        public String Action { set; get; }
        public int Active { set; get; }
        public decimal SortOrder { set; get; }
    }
}
