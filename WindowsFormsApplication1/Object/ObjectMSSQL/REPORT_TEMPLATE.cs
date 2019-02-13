using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class REPORT_TEMPLATE
    {
        public int TemplateID { get; set; }
        public String TemplateName { get; set; }
        public String TemplateDescription { get; set; }
        public String OriginalFile { get; set; }
        public String ReportIdentifier { get; set; }
        public String ReportID { get; set; }
        public String ReportType { get; set; }
        public String ReportVersion { get; set; }
        public int Predefined { get; set; }
        public byte[] TemplateBinary { get; set; }
    }
}
