using System;
using System.Collections.Generic;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class EQUIPMENT_MASTER_BUS
    {
        EQUIPMENT_MASTER_ConnectUtils DAL = new EQUIPMENT_MASTER_ConnectUtils();
        public int getIDbyNumber(string number)
        {
            return DAL.getIDbyNumber(number);
        }
        public List<int> getAllEqIDbyFaciID(int ID)
        {
            return DAL.getAlleqIDbyFaciID(ID);
        }
        public void add(EQUIPMENT_MASTER obj)
        {
            DAL.add( obj.EquipmentNumber, obj.EquipmentTypeID, obj.EquipmentName, obj.CommissionDate, obj.DesignCodeID, obj.SiteID, obj.FacilityID, obj.ManufacturerID, obj.PFDNo, obj.ProcessDescription, obj.EquipmentDesc, obj.IsArchived, obj.Archived, obj.ArchivedBy);
        }
        public void edit(EQUIPMENT_MASTER obj)
        {
            DAL.edit(obj.EquipmentID, obj.EquipmentNumber, obj.EquipmentTypeID, obj.EquipmentName, obj.CommissionDate, obj.DesignCodeID, obj.SiteID, obj.FacilityID, obj.ManufacturerID, obj.PFDNo, obj.ProcessDescription, obj.EquipmentDesc, obj.IsArchived, obj.Archived, obj.ArchivedBy);
        }
        public void delete(EQUIPMENT_MASTER obj)
        {
            DAL.delete(obj.EquipmentID);
        }
        public void delete(int eqID)
        {
            DAL.delete(eqID);
        }
        public List<EQUIPMENT_MASTER> getDataSource()
        {
            return DAL.getDataSource();
        }
        public int getSiteID(int eqID)
        {
            return DAL.getSiteID(eqID);
        }
        public int getEquipmentTypeID(int eqID)
        {
            return DAL.getEquipmentTypeID(eqID);
        }
        public int getEquipmentTypeID(int siteID, int facilityID)
        {
            return DAL.getEquipmentTypeID(siteID, facilityID);
        }
        public int getEqTypeID(int EqID)
        {
            return DAL.getEqTypeID(EqID);
        }
        public List<string> getListEquipmentNumber()
        {
            return DAL.getListEquipmentNumber();
        }
        public DateTime getComissionDate(int eqID)
        {
            return DAL.getCommissionDate(eqID);
        }
        public String getEquipmentNumber(int eqID)
        {
            return DAL.getEquipmentNumber(eqID);
        }
        public String getEquipmentDesc(int eqID)
        {
            return DAL.getEquipmentDesc(eqID);
        }
        public EQUIPMENT_MASTER getData(int eqID)
        {
            return DAL.getData(eqID);
        }
        public Boolean check(String equipNum)
        {
            return DAL.checkExist(equipNum);
        }
        public int getIDbyName(String eqNum)
        {
            return DAL.getIDbyName(eqNum);
        }
        public int getFacilityID(int id)
        {
            return DAL.getFacilityID(id);
        }
        public String getEquipmentName(int eqID)
        {
            return DAL.getEquipmentName(eqID);
        }
        public List<int> GetAllAssessmentIDbyEquipmentID(int eqID)
        {
            return DAL.GetAllAssessmentIDbyEquipmentID(eqID);
        }
    }
}
