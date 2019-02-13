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
    class REPORT_TEMPLATE_BUS
    {
        REPORT_TEMPLATE_ConnectUtils DAL = new REPORT_TEMPLATE_ConnectUtils();
        public void add(REPORT_TEMPLATE obj)
        {
            DAL.add(obj.TemplateName, obj.TemplateDescription,obj.OriginalFile, obj.ReportIdentifier, obj.ReportID, obj.ReportType, obj.ReportVersion,obj.Predefined, obj.TemplateBinary);
        }
        public void edit(REPORT_TEMPLATE obj)
        {
            DAL.edit(obj.TemplateID, obj.TemplateName, obj.TemplateDescription, obj.OriginalFile, obj.ReportIdentifier, obj.ReportID, obj.ReportType, obj.ReportVersion, obj.Predefined, obj.TemplateBinary);
        }
        public void delete(REPORT_TEMPLATE obj)
        {
            DAL.delete(obj.TemplateID);
        }
        public List<REPORT_TEMPLATE> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
