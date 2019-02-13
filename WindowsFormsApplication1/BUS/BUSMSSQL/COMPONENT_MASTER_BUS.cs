using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class COMPONENT_MASTER_BUS
    {
        COMPONENT_MASTER_ConnectUtils DAL = new COMPONENT_MASTER_ConnectUtils();

        public int getComponentTypeID(int comID)
        {
            return DAL.getComponentTypeID(comID);
        }
        public void add(COMPONENT_MASTER obj)
        {
            DAL.add(obj.ComponentNumber, obj.EquipmentID, obj.ComponentTypeID, obj.ComponentName,obj.ComponentDesc, obj.IsEquipment, obj.IsEquipmentLinked, obj.APIComponentTypeID);
        }
        public void edit(COMPONENT_MASTER obj)
        {
            DAL.edit(obj.ComponentID,obj.ComponentNumber, obj.EquipmentID, obj.ComponentTypeID, obj.ComponentName ,obj.ComponentDesc, obj.IsEquipment, obj.IsEquipmentLinked, obj.APIComponentTypeID);
        }
        public void delete(COMPONENT_MASTER obj)
        {
            DAL.delete(obj.ComponentID);
        }
        public void delete(int comID)
        {
            DAL.delete(comID);
        }
        public List<COMPONENT_MASTER> getDataSource()
        {
            return DAL.getDataSource();
        }
        public int getAPIComponentTypeID(int EqID)
        {
            return DAL.getAPIComponentTypeID(EqID);
        }
        public String getComponentName(int comID)
        {
            return DAL.getComponentName(comID);
        }
        public COMPONENT_MASTER getData(int comID)
        {
            return DAL.getData(comID);
        }
        public Boolean checkExist(String comNum)
        {
            return DAL.checkExist(comNum);
        }
        public int getIDbyName(String comNum)
        {
            return DAL.getIDbyName(comNum);
        }
        public int getEquipmentID(int comID)
        {
            return DAL.getEquipmentID(comID);
        }
        public string getComponentNumber(int comID)
        {
            return DAL.getComponentNumber(comID);
        }
        public List<int> getAllIDbyEquipmentID(int ID)
        {
            return DAL.getIDbyEqID(ID);
        }
        public List<int> GetAllIDbyComponentID(int comID)
        {
            return DAL.GetAllIDbyComponentID(comID);
        }
        public List<string> getAllComponentNumber()
        {
            return DAL.getAllComponentNumber();
        }
        public int getComponentTypeID(string comNumber)
        {
            return DAL.getComponentTypeID(comNumber);
        }
    }
}
