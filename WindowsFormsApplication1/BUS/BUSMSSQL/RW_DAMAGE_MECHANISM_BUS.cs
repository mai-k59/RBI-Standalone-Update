using RBI.DAL.MSSQL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_DAMAGE_MECHANISM_BUS
    {
        RW_DAMAGE_MECHANISM_ConnectUtils DAL = new RW_DAMAGE_MECHANISM_ConnectUtils();
        public void add(RW_DAMAGE_MECHANISM obj)
        {
            DAL.add(obj.ID, obj.DMItemID, obj.IsActive, obj.Notes, obj.ExpectedTypeID, obj.IsEL, obj.ELValue,
                       obj.IsDF, obj.IsUserDisabled, obj.DF1, obj.DF2, obj.DF3, obj.DFBase, obj.RLI,
                        obj.HighestInspectionEffectiveness, obj.SecondInspectionEffectiveness, obj.NumberOfInspections,
                        obj.LastInspDate, obj.InspDueDate);
        }
        public void edit(RW_DAMAGE_MECHANISM obj)
        {
            DAL.edit(obj.ID, obj.DMItemID, obj.IsActive, obj.Notes, obj.ExpectedTypeID, obj.IsEL, obj.ELValue,
                       obj.IsDF, obj.IsUserDisabled, obj.DF1, obj.DF2, obj.DF3, obj.DFBase, obj.RLI,
                        obj.HighestInspectionEffectiveness, obj.SecondInspectionEffectiveness, obj.NumberOfInspections,
                        obj.LastInspDate, obj.InspDueDate);

        }
        public void delete(RW_DAMAGE_MECHANISM obj)
        {
            DAL.delete(obj.DMItemID, obj.ID);
        }
        public List<RW_DAMAGE_MECHANISM > getDataSource()
        {
            return DAL.getDataSource();
        }
       
        public Boolean checkExistDM(int ID, int DM_ID)
        {
            return DAL.checkExistDamageMechanism(ID, DM_ID);
        }
        public List<InspectionPlant> GetListInspectionPlant()
        {
            return DAL.GetListInspectionPlant();
        }
    }
}
