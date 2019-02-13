using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class FACILITY_BUS
    {
        FACILITY_ConnectUtils DAL = new FACILITY_ConnectUtils();
        
        public void add(FACILITY obj)
        {
            DAL.add(obj.SiteID, obj.FacilityName, obj.ManagementFactor);
        }
        public void edit(FACILITY obj)
        {
            DAL.edit(obj.FacilityID, obj.SiteID, obj.FacilityName, (float)obj.ManagementFactor);
        }
        public void delete(FACILITY obj)
        {
            DAL.delete(obj.FacilityID);
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public List<FACILITY> getDataSource()
        {
            return DAL.getDataSource();
        }
        public float getFMS(int SiteID)
        {
            return DAL.getFMS(SiteID);
        }
        public String getFacilityName(int faciID)
        {
            return DAL.getFacilityName(faciID);
        }
        public Boolean checkExist(String name)
        {
            return DAL.checkExist(name);
        }
        public int getIDbyName(String name)
        {
            return DAL.getIDbyName(name);
        }
        public List<string> getListFacilityName(int siteID)
        {
            return DAL.getListFacilityName(siteID);
        }
        public int getIDbyName_SiteID(int siteID, string facilityName)
        {
            return DAL.getIDbyName_SiteID(siteID, facilityName);
        }
        public FACILITY getFacility(int facilityID)
        {
            return DAL.getData(facilityID);
        }
        public int getLastFacilityID()
        {
            return DAL.getLastFacilityID();
        }
        public List<int> getAllFaciIDbySiteID(int SiteID)
        {
            return DAL.getIDbySiteID(SiteID);
        }
    }
}
