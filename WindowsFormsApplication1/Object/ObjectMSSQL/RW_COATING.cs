using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_COATING
    {
        public int ID { get; set; }
        public int ExternalCoating { get; set; }
        public int ExternalInsulation { get; set; }
        public int InternalCladding { get; set; }
        public int InternalCoating { get; set; }
        public int InternalLining { get; set; }
        public DateTime ExternalCoatingDate { get; set; }
        public String ExternalCoatingQuality { get; set; }
        public String ExternalInsulationType { get; set; }
        public String InsulationCondition { get; set; }
        public int InsulationContainsChloride { get; set; }
        public String InternalLinerCondition { get; set; }
        public String InternalLinerType { get; set; }
        public float CladdingCorrosionRate { get; set; }
        public int SupportConfigNotAllowCoatingMaint { get; set; }
    }
}
