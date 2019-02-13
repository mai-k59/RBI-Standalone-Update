using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class DM_ITEMS
    {
        public int DMItemID { set; get; }
        public String DMDescription { set; get; }
        public int DMSeq { set; get; }
        public int DMCategoryID { set; get; }
        public String DMCode { set; get; }
        public int HasDF { set; get; }
        public String FailureMode { set; get; }
    }
}
