using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_SETTINGS
    {
        public int ID { set; get; }
        public int DefaultAssessmentMethod { set; get; }
        public String SchemaVersion { set; get; }
        public String UnlockCode { set; get; }
        public String CompanyName { set; get; }
    }
}
