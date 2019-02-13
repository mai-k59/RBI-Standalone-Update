using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object
{
    class InspectionPlant
    {
        public int IDProposal { set { idProposal = value; } get { return idProposal; } }
        public int DMItemID { set { dmItemID = value; } get { return dmItemID; } }
        public String ItemNo
        {
            set
            {
                itemNo = value;
            }
            get
            {
                return itemNo;
            }
        }
        public String DamageMechanism
        {
            set
            {
                damageMechanism = value;
            }
            get
            {
                return damageMechanism;
            }
        }
        public String Method
        {
            set
            {
                method = value;
            }
            get
            {
                return method;
            }
        }
        public String Coverage
        {
            set
            {
                coverage = value;
            }
            get
            {
                return coverage;
            }
        }
        public String Availability
        {
            set
            {
                availability = value;
            }
            get
            {
                return availability;
            }
        }
        public String LastInspectionDate
        {
            set
            {
                lastInspectionDate = value;
            }
            get
            {
                return lastInspectionDate;
            }
        }
        public String InspectionInterval
        {
            set
            {
                inspectionInterval = value;
            }
            get
            {
                return inspectionInterval;
            }
        }
        public String DueDate
        {
            set
            {
                dueDate = value;
            }
            get
            {
                return dueDate;
            }
        }
        public String System
        {
            set
            {
                system = value;
            }
            get
            {
                return system;
            }
        }
        private int dmItemID;
        private int idProposal;
        private string itemNo;
        private string damageMechanism;
        private string method;
        private string coverage;
        private string availability;
        private string lastInspectionDate;
        private string inspectionInterval;
        private string dueDate;
        private string system;
    }
}
