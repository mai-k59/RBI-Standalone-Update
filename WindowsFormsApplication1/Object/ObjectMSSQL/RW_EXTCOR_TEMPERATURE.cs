using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_EXTCOR_TEMPERATURE
    {
        public int ID { get; set; }
        public float Minus12ToMinus8 { get; set; }
        public float Minus8ToPlus6 { get; set; }
        public float Plus6ToPlus32 { get; set; }
        public float Plus32ToPlus71 { get; set; }
        public float Plus71ToPlus107 { get; set; }
        public float Plus107ToPlus121 { get; set; }
        public float Plus121ToPlus135 { get; set; }
        public float Plus135ToPlus162 { get; set; }
        public float Plus162ToPlus176 { get; set; }
        public float MoreThanPlus176 { get; set; }
    }
}
