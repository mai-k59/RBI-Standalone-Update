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
    class IMAGE_FACILITY_BUS
    {
        IMAGE_FACILITY_ConnectUtils DAL = new IMAGE_FACILITY_ConnectUtils();
        public void add(IMAGE_FACILITY obj)
        {
            DAL.add(obj.FacilityID, obj.ImageName, obj.ImageDescription, obj.ImageBinary, obj.ImageBinarySmall);
        }
        public void edit(IMAGE_FACILITY obj)
        {
            DAL.edit(obj.ImageID, obj.FacilityID, obj.ImageName, obj.ImageDescription, obj.ImageBinary, obj.ImageBinarySmall);
        }
        public void delete(IMAGE_FACILITY obj)
        {
            DAL.delete(obj.ImageID);
        }
        public List<IMAGE_FACILITY> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
