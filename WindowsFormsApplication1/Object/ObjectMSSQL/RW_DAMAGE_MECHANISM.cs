using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_DAMAGE_MECHANISM
    {
        public int ID { get; set; }
        public int DMItemID { get; set; }
        public int IsActive { get; set; }
        public String Notes { get; set; }
        public int ExpectedTypeID { get; set; }
        public int IsEL { get; set; }
        public float ELValue { get; set; }
        public int IsDF { get; set; }
        public int IsUserDisabled { get; set; }
        public float DF1 { get; set; }
        public float DF2 { get; set; }
        public float DF3 { get; set; }
        public float DFBase { get; set; }
        public float RLI { get; set; }
        public String HighestInspectionEffectiveness { get; set; }
        public String SecondInspectionEffectiveness { get; set; }
        public int NumberOfInspections { get; set; }
        public DateTime LastInspDate { get; set; }
        public DateTime InspDueDate { get; set; }
    }
}
