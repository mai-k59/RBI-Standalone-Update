using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class USER_PERMISSIONS
    {
        public int UserPermissionID { set; get; }
        public String UserID { set; get; }
        public String Category { set; get; }
        public String Permission { set; get; }
        public int Allowed { set; get; }
        public String Type { set; get; }
        public int Active { set; get; }
    }
}
