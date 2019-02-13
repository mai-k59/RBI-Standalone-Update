using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class USERS_BUS
    {
        USERS_ConnectUtils DAL = new USERS_ConnectUtils();
        public void add(USERS obj)
        {
            DAL.add(obj.UserID,obj.Title, obj.FirstName,obj.LastName,obj.JobTitle,obj.Department,obj.Company,obj.UserGroupName,obj.ADAuthentication,obj.SysUser,obj.IsActive,obj.LicenseKey,obj.Password);
        }
        public void edit(USERS obj)
        {
            DAL.edit(obj.UserID, obj.Title, obj.FirstName, obj.LastName, obj.JobTitle, obj.Department, obj.Company, obj.UserGroupName, obj.ADAuthentication, obj.SysUser, obj.IsActive, obj.LicenseKey, obj.Password);
        }
        public void delete(USERS obj)
        {
            DAL.delete(obj.UserID);
        
        }
        public List<USERS> getDataSource()
        {
            return DAL.getDataSource();
        }

    }
}
