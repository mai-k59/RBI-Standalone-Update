using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class USER_PERMISSIONS_BUS
    {
        USERS_PERMISSIONS_ConnectUtils DAL = new USERS_PERMISSIONS_ConnectUtils();
        public void add(USER_PERMISSIONS obj)
        {
            DAL.add(obj.UserID, obj.Category, obj.Permission, obj.Allowed, obj.Type, obj.Active);
        }
        public void edit(USER_PERMISSIONS obj)
        {
            DAL.edit(obj.UserPermissionID, obj.UserID, obj.Category, obj.Permission, obj.Allowed, obj.Type, obj.Active);
        }
        public void delete(USER_PERMISSIONS obj)
        {
            DAL.delete(obj.UserPermissionID);
        }
        public List<USER_PERMISSIONS> getDataSource()
        {
            return DAL.getDataSource();
        }
        
      
    }
}
