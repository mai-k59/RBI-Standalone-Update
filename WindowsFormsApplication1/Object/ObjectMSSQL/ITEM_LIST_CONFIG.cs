using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class ITEM_LIST_CONFIG
    {
        public int ItemListConfigID { get; set; }
        public String UserID { get; set; }
        public String TreeNode { get; set; }
        public int NodeSeq { get; set; }
        public int ParentID { get; set; }
    }
}
