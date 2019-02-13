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
    class REPORT_TEMPLATE_COMPONENT_DEFAULT_BUS
    {
        REPORT_TEMPLATE_COMPONENT_DEFAULT_ConnectUtilscs DAL = new REPORT_TEMPLATE_COMPONENT_DEFAULT_ConnectUtilscs();
        public void add(REPORT_TEMPLATE_COMPONENT_DEFAULT obj)
        {
            DAL.add(obj.EquipmentID, obj.TemplateID);
        }
        public void edit(REPORT_TEMPLATE_COMPONENT_DEFAULT obj)
        {
            DAL.edit(obj.EquipmentID, obj.TemplateID);
        }
        public void delete(REPORT_TEMPLATE_COMPONENT_DEFAULT obj)
        {
            DAL.delete(obj.EquipmentID);
        }
        public List<REPORT_TEMPLATE_COMPONENT_DEFAULT> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
