using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class EQUIPMENT_TYPE_BUS
    {
        EQUIPMENT_TYPE_ConnectUtils DAL = new EQUIPMENT_TYPE_ConnectUtils();
        public void add(EQUIPMENT_TYPE obj)
        {
            DAL.add(obj.EquipmentTypeID, obj.EquipmentTypeCode, obj.EquipmentTypeName);

        }
        public void edit(EQUIPMENT_TYPE obj)
        {
            DAL.edit(obj.EquipmentTypeID, obj.EquipmentTypeCode, obj.EquipmentTypeName);
        }
        public void delete(EQUIPMENT_TYPE obj)
        {
            DAL.delete(obj.EquipmentTypeID);
        }
        public List<EQUIPMENT_TYPE> getDataSource()
        {
            return DAL.getDataSource();
        }
        public String getEquipmentTypeName(int equipmentID)
        {
            return DAL.getEquipmentTypeName(equipmentID);
        }
        public int getIDbyName(String name)
        {
            return DAL.getIDbyName(name);
        }
        public List<string> getListEquipmentTypeName()
        {
            return DAL.getListEquipmentTypeName();
        }
    }
}
