using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_FULL_POF_BUS
    {
        RW_FULL_POF_ConnectUtils DAL = new RW_FULL_POF_ConnectUtils();
        public void add(RW_FULL_POF obj)
        {
            DAL.add(obj.ID, obj.ThinningAP1, obj.ThinningAP2, obj.ThinningAP3, obj.SCCAP1, obj.SCCAP2, obj.SCCAP3, obj.ExternalAP1, obj.ExternalAP2, obj.ExternalAP3, obj.BrittleAP1, obj.BrittleAP2, obj.BrittleAP3, obj.HTHA_AP1, obj.HTHA_AP2, obj.HTHA_AP3, obj.FatigueAP1, obj.FatigueAP2, obj.FatigueAP3.ToString(), obj.FMS, obj.ThinningType, obj.GFFTotal, obj.ThinningLocalAP1, obj.ThinningLocalAP2, obj.ThinningLocalAP3, obj.ThinningGeneralAP1, obj.ThinningGeneralAP2, obj.ThinningGeneralAP3, obj.TotalDFAP1, obj.TotalDFAP2, obj.TotalDFAP3, obj.PoFAP1, obj.PoFAP2, obj.PoFAP3, obj.MatrixPoFAP1, obj.MatrixPoFAP2, obj.MatrixPoFAP3, obj.RLI, obj.SemiAP1, obj.SemiAP2, obj.SemiAP3, obj.PoFAP1Category, obj.PoFAP2Category, obj.PoFAP3Category, obj.CoFValue, obj.CoFCategory, obj.CoFMatrixValue);
        }
        public void edit(RW_FULL_POF obj)
        {
            DAL.edit(obj.ID, obj.ThinningAP1, obj.ThinningAP2, obj.ThinningAP3, obj.SCCAP1, obj.SCCAP2, obj.SCCAP3, obj.ExternalAP1, obj.ExternalAP2, obj.ExternalAP3, obj.BrittleAP1, obj.BrittleAP2, obj.BrittleAP3, obj.HTHA_AP1, obj.HTHA_AP2, obj.HTHA_AP3, obj.FatigueAP1, obj.FatigueAP2, obj.FatigueAP3.ToString(), obj.FMS, obj.ThinningType, obj.GFFTotal, obj.ThinningLocalAP1, obj.ThinningLocalAP2, obj.ThinningLocalAP3, obj.ThinningGeneralAP1, obj.ThinningGeneralAP2, obj.ThinningGeneralAP3, obj.TotalDFAP1, obj.TotalDFAP2, obj.TotalDFAP3, obj.PoFAP1, obj.PoFAP2, obj.PoFAP3, obj.MatrixPoFAP1, obj.MatrixPoFAP2, obj.MatrixPoFAP3, obj.RLI, obj.SemiAP1, obj.SemiAP2, obj.SemiAP3, obj.PoFAP1Category, obj.PoFAP2Category, obj.PoFAP3Category, obj.CoFValue, obj.CoFCategory, obj.CoFMatrixValue);
        
        }
        public void delete(RW_FULL_POF obj)
        {
            DAL.delete(obj.ID);
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public List<RW_FULL_POF> getDataSource()
        {
            return DAL.getDataSource();
        }
        public RW_FULL_POF getData(int ID)
        {
            return DAL.getData(ID);
        }
        public Boolean checkExistPoF(int ID)
        {
            return DAL.checkExistPoF(ID);
        }
        public float[] getDF(int ID)
        {
            return DAL.getDF(ID);
        }
    }
}
