using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class USER_GROUPS
    {
        public int UserGroupID { set; get; }
        public String UserGroup { set; get; }
        public int SysGroup { set; get; }
        public int Disabled { set; get; }
    }
}
