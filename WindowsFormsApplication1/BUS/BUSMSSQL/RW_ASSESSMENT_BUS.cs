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
    class RW_ASSESSMENT_BUS
    {
        RW_ASSESSMENT_ConnectUtils DAL = new RW_ASSESSMENT_ConnectUtils();
        public void add(RW_ASSESSMENT obj)
        {
            DAL.add(obj.EquipmentID, obj.ComponentID, obj.AssessmentDate, obj.AssessmentMethod, obj.RiskAnalysisPeriod, obj.IsEquipmentLinked, obj.RecordType, obj.ProposalNo, obj.RevisionNo, obj.IsRecommend, obj.ProposalOrRevision, obj.AdoptedBy, obj.AdoptedDate, obj.RecommendedBy, obj.RecommendedDate, obj.ProposalName, obj.AddByExcel);
        }
        public void edit(RW_ASSESSMENT obj)
        {
            DAL.edit(obj.ID, obj.EquipmentID, obj.ComponentID, obj.AssessmentDate, obj.AssessmentMethod, obj.RiskAnalysisPeriod, obj.IsEquipmentLinked, obj.RecordType, obj.ProposalNo, obj.RevisionNo, obj.IsRecommend, obj.ProposalOrRevision, obj.AdoptedBy, obj.AdoptedDate, obj.RecommendedBy, obj.RecommendedDate, obj.ProposalName);
        }
        public void delete(RW_ASSESSMENT obj)
        {
            DAL.delete(obj.ID);
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public List<RW_ASSESSMENT> getDataSource()
        {
            return DAL.getDataSource();
        }
        public int getEquipmentID(int ID)
        {
            return DAL.getEquipmentID(ID);
        }
        public DateTime getAssessmentDate(int ID)
        {
            return DAL.getAssessmentDate(ID);
        }
        public Boolean checkExistAssessment(int ID)
        {
            return DAL.checkExistAssessment(ID);
        }
        public int[] getEquipmentID_ComponentID(int ID)
        {
            return DAL.getEquipmentID_ComponentID(ID);
        }
        public RW_ASSESSMENT getData(int ID)
        {
            return DAL.getData(ID);
        }
        public int countProposal(int compID)
        {
            return DAL.CountProposal(compID);
        }
        public List<int> getAllID()
        {
            return DAL.getAllID();
        }
        public string getAssessmentName(int assID)
        {
            return DAL.getAssessmentName(assID);
        }
        public List<int[]> getCheckAddExcel_ID(int comID, int eqID)
        {
            return DAL.getCheckAddExcel_ID(comID, eqID);
        }
        public int getLastID()
        {
            return DAL.getLastID();
        }
        public List<int> getAllIDbyComponentID(int ID)
        {
            return DAL.getAllIDbyComponentID(ID);
        }
        public List<string> AllName()
        {
            return DAL.AllName();
        }
    }
}
