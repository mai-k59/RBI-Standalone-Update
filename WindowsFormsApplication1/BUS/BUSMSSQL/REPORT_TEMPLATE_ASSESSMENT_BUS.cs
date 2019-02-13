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
    class REPORT_TEMPLATE_ASSESSMENT_BUS
    {
        REPORT_TEMPLATE_ASSESSMENT_ConnectUtils DAL = new REPORT_TEMPLATE_ASSESSMENT_ConnectUtils();
        public void add(REPORT_TEMPLATE_ASSESSMENT obj)
        {
            DAL.add(obj.ID, obj.TemplateID);
        }
        public void edit(REPORT_TEMPLATE_ASSESSMENT obj)
        {
            DAL.edit(obj.ID, obj.TemplateID);
        }
        public void delete(REPORT_TEMPLATE_ASSESSMENT obj)
        {
            DAL.delete(obj.ID);
        }
        public List<REPORT_TEMPLATE_ASSESSMENT> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
