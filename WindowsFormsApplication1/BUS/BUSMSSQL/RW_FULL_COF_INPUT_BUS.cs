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
    class RW_FULL_COF_INPUT_BUS
    {
        RW_FULL_COF_INPUT_ConnectUtils DAL = new RW_FULL_COF_INPUT_ConnectUtils();
        public void add(RW_FULL_COF_INPUT obj)
        {
            DAL.add(obj.ID, obj.Mitigation, obj.DetectionType, obj.IsolationType, obj.mass_comp, obj.mass_inv);
        }
        public void edit(RW_FULL_COF_INPUT obj)
        {
            DAL.edit(obj.ID, obj.Mitigation, obj.DetectionType, obj.IsolationType, obj.mass_comp, obj.mass_inv);
        }
        public void delete(RW_FULL_COF_INPUT obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_FULL_COF_INPUT> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
