using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class RW_INSPECTION_HISTORY_BUS
    {
        RW_INSPECTION_HISTORY_ConnUtils DAL = new RW_INSPECTION_HISTORY_ConnUtils();
        public void add(RW_INSPECTION_HISTORY obj)
        {
            DAL.add( obj.InspectionPlanName, obj.InspectionCoverageName, obj.EquipmentNumber, obj.ComponentNumber, obj.DM, obj.InspectionType, obj.InspectionDate, obj.InspectionEffective);
        }
        public void edit(RW_INSPECTION_HISTORY obj)
        {
            DAL.edit(obj.ID, obj.InspectionPlanName, obj.InspectionCoverageName, obj.EquipmentNumber, obj.ComponentNumber, obj.DM, obj.InspectionType, obj.InspectionDate, obj.InspectionEffective);
        }
        public void delete(RW_INSPECTION_HISTORY obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_INSPECTION_HISTORY> getDataSource()
        {
            return DAL.getDataSource();
        }
        public List<RW_INSPECTION_HISTORY> getDataComp(String comNum)
        {
            return DAL.getDataComp(comNum);
        }
        public Boolean checkExist(RW_INSPECTION_HISTORY obj)
        {
            return DAL.checkExist(obj.ComponentNumber, obj.DM, obj.InspectionDate);
        }
        public DateTime getLastInsp(String compNum, String DM, DateTime comissionDate)
        {
            return DAL.getLastInspDate(compNum, DM, comissionDate);
        }
        public float getAge(String compNum, String DM, DateTime comissionDate, DateTime AssessmentDate)
        {
            TimeSpan TICK_SPAN = AssessmentDate.Subtract(DAL.getLastInspDate(compNum, DM, comissionDate));
            float DATA = (float)Math.Round((double)TICK_SPAN.Days / 365, 2);
            return DATA;
        }
        public String getHighestInspEffec(String compNum, String DM)
        {
            return DAL.getMaxInspEffec(compNum, DM);
        }
        public int InspectionNumber(String comNum, String DM)
        {
            return DAL.InspectionNumber(comNum, DM);
        }
    }
}
