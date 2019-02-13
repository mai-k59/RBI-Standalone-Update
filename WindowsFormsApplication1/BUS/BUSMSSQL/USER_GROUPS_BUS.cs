using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class USER_GROUPS_BUS
    {
        USER_GROUPS_ConnectUtils DAL = new USER_GROUPS_ConnectUtils();
        public void add (USER_GROUPS obj)
        {
            DAL.add(obj.UserGroup, obj.SysGroup, obj.Disabled);
        }
        public void edit(USER_GROUPS obj)
        {
            DAL.add(obj.UserGroup, obj.SysGroup, obj.Disabled);
        }
        public void delete(USER_GROUPS obj)
        {
            DAL.delete(obj.UserGroupID);
        }
        public List<USER_GROUPS> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
