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
    class RW_COATING_BUS
    {
        RW_COATING_ConnectUtils DAL = new RW_COATING_ConnectUtils();
        public void add(RW_COATING obj)
        {
            DAL.add(obj.ID, obj.ExternalCoating, obj.ExternalInsulation, obj.InternalCladding,obj.InternalCoating, obj.InternalLining, obj.ExternalCoatingDate, obj.ExternalCoatingQuality, obj.ExternalInsulationType, obj.InsulationCondition, obj.InsulationContainsChloride,obj.InternalLinerCondition,obj.InternalLinerType,obj.CladdingCorrosionRate,obj.SupportConfigNotAllowCoatingMaint);
        }
        public void edit(RW_COATING obj)
        {
            DAL.edit(obj.ID, obj.ExternalCoating, obj.ExternalInsulation, obj.InternalCladding, obj.InternalCoating, obj.InternalLining, obj.ExternalCoatingDate, obj.ExternalCoatingQuality, obj.ExternalInsulationType, obj.InsulationCondition, obj.InsulationContainsChloride, obj.InternalLinerCondition, obj.InternalLinerType, obj.CladdingCorrosionRate, obj.SupportConfigNotAllowCoatingMaint);
        }
        public void delete(RW_COATING obj)
        {
            DAL.delete(obj.ID);
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public List<RW_COATING> getDataSource()
        {
            return DAL.getDataSource();
        }
        public RW_COATING getData(int ID)
        {
            return DAL.getData(ID);
        }
    }
}
