using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object;

namespace RBI.BUS.BUSMSSQL
{
    class REPORT_TEMPLATE_EQUIPMENT_BUS
    {
        REPORT_TEMPLATE_EQUIPMENT_ConnectUtils DAL = new REPORT_TEMPLATE_EQUIPMENT_ConnectUtils();
        public void add(REPORT_TEMPLATE_EQUIPMENT obj)
        {
            DAL.add(obj.EquipmentID, obj.TemplateID);
        }
        public void edit(REPORT_TEMPLATE_EQUIPMENT obj)
        {
            DAL.edit(obj.EquipmentID, obj.TemplateID);
        }
        public void delete(REPORT_TEMPLATE_EQUIPMENT obj)
        {
            DAL.delete(obj.EquipmentID);
        }
        public List<REPORT_TEMPLATE_EQUIPMENT> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
