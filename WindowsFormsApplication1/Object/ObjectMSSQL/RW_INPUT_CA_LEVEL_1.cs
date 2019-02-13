using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_INPUT_CA_LEVEL_1
    {
        public int ID { set; get; }
        public String API_FLUID { set; get; } //Fluid
        public String SYSTEM { set; get; } //Fluid Phase
        public String Release_Duration { set; get; }
        public String Detection_Type { set; get; }
        public String Isulation_Type { set; get; }
        public String Mitigation_System { set; get; }
        public float Equipment_Cost { set; get; }
        public float Injure_Cost { set; get; }
        public float Environment_Cost { set; get; }
        public float Toxic_Percent { set; get; }
        public float Personal_Density { set; get; }
        public float Material_Cost { set; get; }
        public float Production_Cost { set; get; }
        public float Mass_Inventory { set; get; }
        public float Mass_Component { set; get; }
        public float Stored_Pressure { set; get; }
        public float Stored_Temp { set; get; }
    }
}
