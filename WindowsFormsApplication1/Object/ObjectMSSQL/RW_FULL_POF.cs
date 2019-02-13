using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    class RW_FULL_POF
    {
        public int ID { set; get; }
        public float ThinningAP1 { set; get; }
        public float ThinningAP2 { set; get; }
        public float ThinningAP3 { set; get; }
        public float SCCAP1 { set; get; }
        public float SCCAP2 { set; get; }
        public float SCCAP3 { set; get; }
        public float ExternalAP1 { set; get; }
        public float ExternalAP2 { set; get; }
        public float ExternalAP3 { set; get; }
        public float BrittleAP1 { set; get; }
        public float BrittleAP2 { set; get; }
        public float BrittleAP3 { set; get; }
        public float HTHA_AP1 { set; get; }
        public float HTHA_AP2 { set; get; }
        public float HTHA_AP3 { set; get; }
        public float FatigueAP1 { set; get; }
        public float FatigueAP2 { set; get; }
        public float FatigueAP3 { set; get; }
        public float FMS { set; get; }
        public String ThinningType { set; get; }
        public float GFFTotal { set; get; }
        public float ThinningLocalAP1 { set; get; }
        public float ThinningLocalAP2 { set; get; }
        public float ThinningLocalAP3 { set; get; }
        public float ThinningGeneralAP1 { set; get; }
        public float ThinningGeneralAP2 { set; get; }
        public float ThinningGeneralAP3 { set; get; }
        public float TotalDFAP1 { set; get; }
        public float TotalDFAP2 { set; get; }
        public float TotalDFAP3 { set; get; }
        public float PoFAP1 { set; get; }
        public float PoFAP2 { set; get; }
        public float PoFAP3 { set; get; }
        public float MatrixPoFAP1 { set; get; }
        public float MatrixPoFAP2 { set; get; }
        public float MatrixPoFAP3 { set; get; }
        public float RLI { set; get; }
        public float SemiAP1 { set; get; }
        public float SemiAP2 { set; get; }
        public float SemiAP3 { set; get; }
        public String PoFAP1Category { set; get; }
        public String PoFAP2Category { set; get; }
        public String PoFAP3Category { set; get; }
        public float CoFValue { set; get; }
        public String CoFCategory { set; get; }
        public float CoFMatrixValue { set; get; }
    }
}
