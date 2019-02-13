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
    class RW_FULL_COF_HOLE_SIZE_BUS
    {
        RW_FULL_COF_HOLE_SIZE_ConnectUtils DAL = new RW_FULL_COF_HOLE_SIZE_ConnectUtils();
        public void add(RW_FULL_COF_HOLE_SIZE obj)
        {
            DAL.add(obj.ID, obj.GFF_n, obj.An, obj.Wn, obj.t_n, obj.ld_max_n, obj.mass_add_n, obj.mass_avail_n, obj.rate_n, obj.ld_n, obj.mass_n, obj.eneff_n, obj.factIC_n, obj.ReleaseType_n);
        }
        public void edit(RW_FULL_COF_HOLE_SIZE obj)
        {
            DAL.edit(obj.ID, obj.GFF_n, obj.An, obj.Wn, obj.t_n, obj.ld_max_n, obj.mass_add_n, obj.mass_avail_n, obj.rate_n, obj.ld_n, obj.mass_n, obj.eneff_n, obj.factIC_n, obj.ReleaseType_n);
        
        }
        public void delete(RW_FULL_COF_HOLE_SIZE obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_FULL_COF_HOLE_SIZE> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
