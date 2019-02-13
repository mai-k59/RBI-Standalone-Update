using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class USER_PERMISSION_LIST_BUS
    {
        USERS_PERMISSION_List_ConnectUtils DAL = new USERS_PERMISSION_List_ConnectUtils();
        public void add(USER_PERMISSION_LIST obj)
        {
            DAL.add(obj.Category, obj.Permission, obj.Container, obj.Object, obj.ObjectType, obj.Action, obj.Active, obj.SortOrder);

        }
        public void edit(USER_PERMISSION_LIST obj)
        {
            DAL.edit(obj.PermissionID, obj.Category, obj.Permission, obj.Container, obj.Object, obj.ObjectType, obj.Action, obj.Active, obj.SortOrder);
        }
        public void delete(USER_PERMISSION_LIST obj)
        {
            DAL.delete(obj.PermissionID);
        }
        public List<USER_PERMISSION_LIST> getDataSource()
        {
            return DAL.getDataSource();
        }

    }
}
