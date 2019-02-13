using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class RW_CA_LEVEL_1_BUS
    {
        RW_CA_LEVEL_1_ConnUtils DAL = new RW_CA_LEVEL_1_ConnUtils();
        public void add(RW_CA_LEVEL_1 obj)
        {
            DAL.add(obj.ID, obj.Release_Phase, obj.fact_di, obj.fact_mit, obj.fact_ait, obj.CA_cmd, obj.CA_inj_flame, obj.CA_inj_toxic, obj.CA_inj_ntnf, obj.FC_cmd, obj.FC_affa, obj.FC_prod, obj.FC_inj, obj.FC_envi, obj.FC_total, obj.FCOF_Category);
        }
        public void edit(RW_CA_LEVEL_1 obj)
        {
            DAL.edit(obj.ID,obj.Release_Phase, obj.fact_di, obj.fact_mit, obj.fact_ait, obj.CA_cmd, obj.CA_inj_flame, obj.CA_inj_toxic, obj.CA_inj_ntnf, obj.FC_cmd, obj.FC_affa, obj.FC_prod, obj.FC_inj, obj.FC_envi, obj.FC_total, obj.FCOF_Category);
        }
        public void delete(RW_CA_LEVEL_1 obj)
        {
            DAL.detele(obj.ID);
        }
        public void delete(int ID)
        {
            DAL.detele(ID);
        }
        public RW_CA_LEVEL_1 getData(int ID)
        {
            return DAL.getData(ID);
        }
        public Boolean checkExist(int ID)
        {
            return DAL.checkExist(ID);
        }
    }
}
