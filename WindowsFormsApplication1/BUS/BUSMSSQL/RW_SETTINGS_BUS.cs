using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_SETTINGS_BUS
    {
        RW_SETTINGS_ConnectUtils DAL = new RW_SETTINGS_ConnectUtils();
        public void add(RW_SETTINGS obj)
        {
            DAL.add(obj.ID, obj.DefaultAssessmentMethod, obj.SchemaVersion, obj.UnlockCode, obj.CompanyName);

        }
        public void edit(RW_SETTINGS obj)
        {
            DAL.edit(obj.ID, obj.DefaultAssessmentMethod, obj.SchemaVersion, obj.UnlockCode, obj.CompanyName);
        }
        public void delete(RW_SETTINGS obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_SETTINGS> getDataSource()
        {
            return DAL.getDataSource();
        }
       
    }
}
