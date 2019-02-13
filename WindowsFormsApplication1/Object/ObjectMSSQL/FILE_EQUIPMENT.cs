using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class FILE_EQUIPMENT
    {
        public int FileID { set; get; }
        public int EquipmentID { set; get; }
        public String FileDocName { set; get; }
        public int FileType { set; get; }
        public String FileDescription { set; get; }
        public String OriFileName { set; get; }
        public Byte[] FileBinary { set; get; }
        public String FileSize { set; get; }
        public String FileExt { set; get; }
        public DateTime DateUploaded { set; get; }
    }
}
