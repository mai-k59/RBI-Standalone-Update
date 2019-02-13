using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class NO_INSPECTION
    {
        public int numThinning { set; get; }
        public int numCaustic { set; get; }
        public int numAmine { set; get; }
        public int numSulphide { set; get; }
        public int numHICSOHIC_H2S { set; get; }
        public int numCarbonate { set; get; }
        public int numExternal_CLSCC { set; get; }
        public int numPTA { set; get; }
        public int numCLSCC { set; get; }
        public int numHSC_HF { set; get; }
        public int numHICSOHIC_HF { set; get; }
        public int numExternalCorrosion { set; get; }
        public int numCUI { set; get; }
        public int numExternalCUI { set; get; }
        public int numHTHA { set; get; }

        public string effThinning { set; get; }
        public string effCaustic { set; get; }
        public string effAmine { set; get; }
        public string effSulphide { set; get; }
        public string effHICSOHIC_H2S { set; get; }
        public string effCarbonate { set; get; }
        public string effExternal_CLSCC { set; get; }
        public string effPTA { set; get; }
        public string effCLSCC { set; get; }
        public string effHSC_HF { set; get; }
        public string effHICSOHIC_HF { set; get; }
        public string effExternalCorrosion { set; get; }
        public string effCUI { set; get; }
        public string effExternalCUI { set; get; }
        public string effHTHA { set; get; }
    }
}
