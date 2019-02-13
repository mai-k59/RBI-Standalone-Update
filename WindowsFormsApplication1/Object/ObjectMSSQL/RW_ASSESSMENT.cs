using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_ASSESSMENT
    {
        public int ID { get; set; }
        public int EquipmentID { get; set; }
        public int ComponentID { get; set; }
        public DateTime AssessmentDate { get; set; }
        public int AssessmentMethod { get; set; }
        public int RiskAnalysisPeriod { get; set; }
        public int IsEquipmentLinked { get; set; }
        public String RecordType { get; set; }
        public int ProposalNo { get; set; } //sua Number thanh String Name
        public String ProposalName {set; get;}
        public int RevisionNo { get; set; }
        public int IsRecommend { get; set; }
        public String ProposalOrRevision { get; set; }
        public String AdoptedBy { get; set; }
        public DateTime AdoptedDate { get; set; }
        public String RecommendedBy { get; set; }
        public DateTime RecommendedDate { get; set; }
        public int AddByExcel { set; get; }
    }
}
