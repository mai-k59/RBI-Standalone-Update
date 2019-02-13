using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object
{
    class Component
    {
        String name;
        String description;
        String moc;
        String linerMOC;
        String heightLength;
        String diameter;
        String norminalThickness;
        String ca;
        String designPressure;
        String designTemp;
        String noEquidment;
        String componentType;

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
        public String Description
        {
            set
            {
                description = value;
            }
            get
            {
                return description;
            }
        }
        public String MOC
        {
            set
            {
                moc = value;
            }
            get
            {
                return moc;
            }
        }
        public String LinerMOC
        {
            set
            {
                linerMOC = value;
            }
            get
            {
                return linerMOC;
            }
        }
        public String HeightLength
        {
            set
            {
                heightLength = value;
            }
            get
            {
                return heightLength;
            }
        }
        public String Diameter
        {
            set
            {
                diameter = value;
            }
            get
            {
                return diameter;
            }
        }
        public String NorminalThickness
        {
            set
            {
                norminalThickness = value;
            }
            get
            {
                return norminalThickness;
            }
        }
        public String CA
        {
            set
            {
                ca = value;
            }
            get
            {
                return ca;
            }
        }
        public String DesignPressure
        {
            set
            {
                designPressure = value;
            }
            get
            {
                return designPressure;
            }
        }
        public String DesignTemp
        {
            set
            {
                designTemp = value;
            }
            get
            {
                return designTemp;
            }
        }
        public String NoEquidment
        {
            set
            {
                noEquidment = value;
            }
            get
            {
                return noEquidment;
            }
        }
        public String ComponentType
        {
            set
            {
                componentType = value;
            }
            get
            {
                return componentType;
            }
        }
    }
}
