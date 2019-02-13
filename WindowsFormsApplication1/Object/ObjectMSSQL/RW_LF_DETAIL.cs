using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_LF_DETAIL
    {
        public int ID { set; get; }
        public int DMItemID { set; get; }
        public float LF2AP1 { set; get; }
        public float LF2AP2 { set; get; }
        public float LF2AP3 { set; get; }
        public float LF2FactorAP1 { set; get; }
        public float LF2FactorAP2 { set; get; }
        public float LF2FactorAP3 { set; get; }
        public float LF3 { set; get; }
        public float LF3Factor { set; get; }
        public float LCF { set; get; }
        public String LHAP1Category { set; get; }
        public String LHAP2Category { set; get; }
        public String LHAP3Category { set; get; }
        public float LHAP1Value { set; get; }
        public float LHAP2Value { set; get; }
        public float LHAP3Value { set; get; }
        public float CoFValue { set; get; }
        public String CoFCategory { set; get; }
        public float RLI { set; get; }
        public int IsEL { set; get; }
    }
}
