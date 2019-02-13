using RBI.DAL.MSSQL;
using RBI.Object;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class IMAGE_EQUIPMENT_BUS
    {
        IMAGE_EQUIPMENT_ConnectUtilscs DAL = new IMAGE_EQUIPMENT_ConnectUtilscs();
        public void add(IMAGE_EQUIPMENT obj)
        {
            DAL.add(obj.EquipmentID, obj.ImageName, obj.ImageDescription, obj.ImageBinary, obj.ImageBinarySmall);
        }
        public void edit(IMAGE_EQUIPMENT obj)
        {
            DAL.edit(obj.ImageID, obj.EquipmentID, obj.ImageName, obj.ImageDescription, obj.ImageBinary, obj.ImageBinarySmall);
        }
        public void delete(IMAGE_EQUIPMENT obj)
        {
            DAL.delete(obj.ImageID);

        }
        public List<IMAGE_EQUIPMENT> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
