using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class UNITS_BUS
    {
        UNITS_ConnectUtils DAL = new UNITS_ConnectUtils();
        public void add(UNITS obj)
        {
            DAL.add(obj.UnitID, obj.UnitName, obj.SelectedUnit);
        }
        public void edit(UNITS obj)
        {
            DAL.edit(obj.UnitID, obj.UnitName, obj.SelectedUnit);
        }
        public void edit(string unitName, string selectedUnit)
        {
            DAL.edit(unitName, selectedUnit);
        }
        public void delete(UNITS obj)
        {
            DAL.delete(obj.UnitID);
        }
        public List<UNITS> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
