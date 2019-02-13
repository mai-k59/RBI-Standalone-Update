using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class EXTRA_FIELDS_LOOKUP
    {
        public int LookupID { set; get; }
        public int ExtraFieldID { set; get; }
        public String LookupText { set; get; }
        public String LookupValue { set; get; }
    }
}
