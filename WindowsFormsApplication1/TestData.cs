using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI
{
    class TestData
    {
        public int ID { set; get; }
        public int ParentID { set; get; }
        public String Context { set; get; }
        public TestData(int id, int parentNode, String context)
        {
            ID = id;
            ParentID = parentNode;
            Context = context;
        }
    }
}
