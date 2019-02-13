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
    class RW_COMPONENT_BUS
    {
        RW_COMPONENT_ConnectUtils DAL = new RW_COMPONENT_ConnectUtils();
        public void add(RW_COMPONENT obj)
        {
            DAL.add(obj.ID, obj.NominalDiameter, obj.NominalThickness, obj.CurrentThickness, obj.MinReqThickness, obj.CurrentCorrosionRate, obj.BranchDiameter, obj.BranchJointType, obj.BrinnelHardness, obj.ChemicalInjection, obj.HighlyInjectionInsp, obj.ComplexityProtrusion, obj.CorrectiveAction, obj.CracksPresent, obj.CyclicLoadingWitin15_25m, obj.DamageFoundInspection, obj.DeltaFATT, obj.NumberPipeFittings, obj.PipeCondition, obj.PreviousFailures, obj.ShakingAmount, obj.ShakingDetected, obj.ShakingTime, obj.TrampElements, obj.ShellHeight, obj.ReleasePreventionBarrier, obj.ConcreteFoundation, obj.SeverityOfVibration);
        }
        public void edit(RW_COMPONENT obj)
        {
            DAL.edit(obj.ID, obj.NominalDiameter, obj.NominalThickness, obj.CurrentThickness, obj.MinReqThickness, obj.CurrentCorrosionRate, obj.BranchDiameter, obj.BranchJointType, obj.BrinnelHardness, obj.ChemicalInjection, obj.HighlyInjectionInsp, obj.ComplexityProtrusion, obj.CorrectiveAction, obj.CracksPresent, obj.CyclicLoadingWitin15_25m, obj.DamageFoundInspection, obj.DeltaFATT, obj.NumberPipeFittings, obj.PipeCondition, obj.PreviousFailures, obj.ShakingAmount, obj.ShakingDetected, obj.ShakingTime, obj.TrampElements, obj.ShellHeight, obj.ReleasePreventionBarrier, obj.ConcreteFoundation, obj.SeverityOfVibration);
        }
        public void delete(RW_COMPONENT obj)
        {
            DAL.delete(obj.ID);
                
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public List<RW_COMPONENT> getDataSource()
        {
            return DAL.getDataSource();
        }
        public Boolean checkExistComponent(int ID)
        {
            return DAL.checkExistComponent(ID);
        }
        public RW_COMPONENT getData(int ID)
        {
            return DAL.getData(ID);
        }
        public string GetComponentNumber(int ID)
        {
            return DAL.GetComponentNumber(ID);
        }
    }
}
