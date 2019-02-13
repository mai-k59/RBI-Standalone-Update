using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class USERS
    {
        public String UserID { set; get; }
        public String Title { set; get; }
        public String FirstName { set; get; }
        public String LastName { set; get; }
        public String JobTitle { set; get; }
        public String Department { set; get; }
        public String Company { set; get; }
        public String UserGroupName { set; get; }
        public int ADAuthentication { set; get; }
        public int SysUser { set; get; }
        public int IsActive { set; get; }
        public String LicenseKey { set; get; }
        public String Password { set; get; }
    }
}
