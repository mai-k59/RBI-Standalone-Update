using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object
{
    class Equipment
    {
        String itemNo;
        String name;
        String qty;
        String semi_quanty;
        String quanlitative;
        String processStream;
        String pressure;
        String pha;
        String business;
        String processStreamFluid;
        String operatingPressure;
        String phaRating;
        String businessLossValue;
        //String group;
        //String type;
        //String equipmentDescription;
        String unitCode;

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
        public String Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        public String Qty
        {
            set
            {
                qty = value;
            }
            get
            {
                return qty;
            }
        }
        public String Semi_Quanty
        {
            set
            {
                semi_quanty = value;
            }
            get
            {
                return semi_quanty;
            }
        }
        public String Quanlitative
        {
            set
            {
                quanlitative = value;
            }
            get
            {
                return quanlitative;
            }
        }
        public String ProcessStream
        {
            set
            {
                processStream = value;
            }
            get
            {
                return processStream;
            }
        }
        public String Pressure
        {
            set
            {
                pressure = value;
            }
            get
            {
                return pressure;
            }
        }
        public String PHA
        {
            set
            {
                pha = value;
            }
            get
            {
                return pha;
            }
        }
        public String Business
        {
            set
            {
                business = value;
            }
            get
            {
                return business;
            }
        }
        public String ProcessStreamFluid
        {
            set
            {
                processStreamFluid = value;
            }
            get
            {
                return processStreamFluid;
            }
        }
        public String OperatingPressure
        {
            set
            {
                operatingPressure = value;
            }
            get
            {
                return operatingPressure;
            }
        }
        public String PHARating
        {
            set
            {
                phaRating = value;
            }
            get
            {
                return phaRating;
            }
        }
        public String BusinessLossValue
        {
            set
            {
                businessLossValue = value;
            }
            get
            {
                return businessLossValue;
            }
        }
        //public String Group
        //{
        //    set
        //    {
        //        group = value;
        //    }
        //    get
        //    {
        //        return group;
        //    }
        //}
        //public String Type
        //{
        //    set
        //    {
        //        type = value;
        //    }
        //    get
        //    {
        //        return type;
        //    }
        //}
        //public String EquipmentDescription
        //{
        //    set
        //    {
        //        equipmentDescription = value;
        //    }
        //    get
        //    {
        //        return equipmentDescription;
        //    }
        //}
        public String UnitCode
        {
            set
            {
                unitCode = value;
            }
            get
            {
                return unitCode;
            }
        }
    }
}
