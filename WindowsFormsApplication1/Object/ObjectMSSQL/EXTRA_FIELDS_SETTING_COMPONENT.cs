using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class EXTRA_FIELDS_SETTING_COMPONENT
    {
        public int ExtraFieldID { set; get; }
        public String FieldID { set; get; }
        public String FieldName { set; get; }
        public String FieldDescription { set; get; }
        public int SeqNo { set; get; }
        public String FieldType { set; get; }
        public int FieldSize { set; get; }
        public int IsActive { set; get; }
        public int IsCreated { set; get; }
    }
}
