using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class SITES_BUS
    {
        SITES_ConnectUtils DAL = new SITES_ConnectUtils();

        public void add(SITES obj)
        {
            DAL.add(obj.SiteName);
        }
        public void edit(SITES obj)
        {
            DAL.edit(obj.SiteID, obj.SiteName);
        }
        
        public void delete(SITES obj)
        {
            DAL.delete(obj.SiteID);
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public List<SITES> getData()
        {
            return DAL.getDataSource();
        }
        public String getSiteName(int SiteID)
        {
            return DAL.getSiteName(SiteID);
        }
        public Boolean checkExist(String name)
        {
            return DAL.checkExist(name);
        }
        public int getIDbyName(String name)
        {
            return DAL.getIDbyName(name);
        }
        public List<string> getListSiteName()
        {
            return DAL.getListSiteName();
        }
    }
}
