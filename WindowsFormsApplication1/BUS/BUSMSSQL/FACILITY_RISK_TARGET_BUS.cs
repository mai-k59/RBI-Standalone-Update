using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class FACILITY_RISK_TARGET_BUS
    {
        FACILITY_RISK_TARGET_ConnectUtils DAL = new FACILITY_RISK_TARGET_ConnectUtils();
        public void add(FACILITY_RISK_TARGET obj)
        {
            DAL.add(obj.FacilityID, (float)obj.RiskTarget_A, (float)obj.RiskTarget_B, (float)obj.RiskTarget_C, (float)obj.RiskTarget_D, (float)obj.RiskTarget_E, (float)obj.RiskTarget_CA,
                        (float)obj.RiskTarget_FC);
        }
        public void edit(FACILITY_RISK_TARGET obj)
        {
            DAL.edit(obj.FacilityID, (float)obj.RiskTarget_A, (float)obj.RiskTarget_B, (float)obj.RiskTarget_C, (float)obj.RiskTarget_D, (float)obj.RiskTarget_E, (float)obj.RiskTarget_CA,
                        (float)obj.RiskTarget_FC);
        }
        public void delete(FACILITY_RISK_TARGET obj)
        {
            DAL.delete(obj.FacilityID);
        }
        public List<FACILITY_RISK_TARGET> getDataSource()
        {
            return DAL.getDataSource();
        }
        public float getRiskTarget(int FacilityID)
        {
            return DAL.getRiskTarget(FacilityID);
        }
        public FACILITY_RISK_TARGET getFacilityRiskTarget(int facilityID)
        {
            return DAL.getFacilityRiskTarget(facilityID);
        }
    }
}
