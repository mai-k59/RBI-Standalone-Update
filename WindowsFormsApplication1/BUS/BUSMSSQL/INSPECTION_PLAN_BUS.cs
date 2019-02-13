using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object;

namespace RBI.BUS.BUSMSSQL
{
    class INSPECTION_PLAN_BUS
    {
        INSPECTION_PLAN_ConnectUtils DAL = new INSPECTION_PLAN_ConnectUtils();
        public void add(INSPECTION_PLAN obj)
        {
            DAL.add(obj.InspPlanName, obj.InspPlanDate, obj.Remarks);
        }
        public void edit(INSPECTION_PLAN obj)
        {
            DAL.edit(obj.PlanID, obj.InspPlanName, obj.InspPlanDate, obj.Remarks);
        }
        public void delete(INSPECTION_PLAN obj)
        {
            DAL.delete(obj.PlanID);
        }
        public List<INSPECTION_PLAN> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
