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
    class IMAGE_COMPONENT_BUS
    {
        IMAGE_COMPONENT_ConnectUtils DAL = new IMAGE_COMPONENT_ConnectUtils();
        public void add(IMAGE_COMPONENT obj)
        {
            DAL.add(obj.ComponentID, obj.ImageName, obj.ImageDescription, obj.ImageBinary[0], obj.ImageBinarySmall[0]);
        }
        public void edit(IMAGE_COMPONENT obj)
        {
            DAL.edit(obj.ImageID,obj.ComponentID, obj.ImageName, obj.ImageDescription, obj.ImageBinary[0], obj.ImageBinarySmall[0]);
        }
        public void delete(IMAGE_COMPONENT obj)
        {
            DAL.delete(obj.ImageID);

        }
        public List<IMAGE_COMPONENT> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
