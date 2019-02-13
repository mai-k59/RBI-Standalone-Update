using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_RISK_TARGET_BUS
    {
        RW_RISK_TARGET_ConnectUtils DAL = new RW_RISK_TARGET_ConnectUtils();
        public void add(RW_RISK_TARGET obj)
        {
            DAL.add(obj.ID, obj.RiskTarget_A, obj.RiskTarget_B, obj.RiskTarget_C,obj.RiskTarget_E, obj.RiskTarget_D, obj.RiskTarget_CA, obj.RiskTarget_FC);
        }
        public void edit(RW_RISK_TARGET obj)
        {
            DAL.edit(obj.ID, obj.RiskTarget_A, obj.RiskTarget_B, obj.RiskTarget_C, obj.RiskTarget_E, obj.RiskTarget_D, obj.RiskTarget_CA, obj.RiskTarget_FC);
        }
        public void delete(RW_RISK_TARGET obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_RISK_TARGET> getDataSource()
        {
            return DAL.getDataSource();
        }
        public Boolean isExist(int ID)
        {
            return DAL.isExist(ID);
        }
    }
}
