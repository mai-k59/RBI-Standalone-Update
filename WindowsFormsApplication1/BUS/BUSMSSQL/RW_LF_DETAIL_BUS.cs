using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_LF_DETAIL_BUS
    {
        RW_LF_DETAIL_ConnectUtils DAL = new RW_LF_DETAIL_ConnectUtils();
        public void add(RW_LF_DETAIL obj)
        {
            DAL.add(obj.ID, obj.DMItemID, obj.LF2AP1, obj.LF2AP2, obj.LF2AP3, obj.LF2FactorAP1, obj.LF2FactorAP2, obj.LF2FactorAP3, obj.LF3, obj.LF3Factor, obj.LCF, obj.LHAP1Category, obj.LHAP2Category, obj.LHAP3Category, obj.LHAP1Value, obj.LHAP2Value, obj.LHAP3Value, obj.CoFValue, obj.CoFCategory, obj.RLI, obj.IsEL);
        }
        public void edit(RW_LF_DETAIL obj)
        {
            DAL.edit(obj.ID, obj.DMItemID, obj.LF2AP1, obj.LF2AP2, obj.LF2AP3, obj.LF2FactorAP1, obj.LF2FactorAP2, obj.LF2FactorAP3, obj.LF3, obj.LF3Factor, obj.LCF, obj.LHAP1Category, obj.LHAP2Category, obj.LHAP3Category, obj.LHAP1Value, obj.LHAP2Value, obj.LHAP3Value, obj.CoFValue, obj.CoFCategory, obj.RLI, obj.IsEL);

        }
        public void delete(RW_LF_DETAIL obj)
        {
            DAL.delete(obj.ID, obj.DMItemID);
        }
    }
}
