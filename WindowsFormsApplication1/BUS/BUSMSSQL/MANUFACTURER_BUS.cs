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
    class MANUFACTURER_BUS
    {
        MANUFACTURER_ConnectUtils DAL = new MANUFACTURER_ConnectUtils();
        public void add(MANUFACTURER obj)
        {
            DAL.add(obj.ManufacturerName);
        }
        public void edit(MANUFACTURER obj)
        {
            DAL.edit(obj.ManufacturerID, obj.ManufacturerName);
        }
        public void delete(MANUFACTURER obj)
        {
            DAL.delete(obj.ManufacturerID);
        }
        public List<MANUFACTURER> getDataSource()
        {
            return DAL.getDataSource();
        }
        public String getManuName(int manuID)
        {
            return DAL.getManufacturerName(manuID);
        }
        public int getIDbyName(string name)
        {
            return DAL.getIDbyName(name);
        }
        public List<string> getListManufactureName()
        {
            return DAL.getListManufactureName();
        }
    }
}
