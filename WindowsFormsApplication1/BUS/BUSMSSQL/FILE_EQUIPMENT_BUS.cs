using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class FILE_EQUIPMENT_BUS
    {
        FILE_EQUIPMENT_ConnectUtils DAL = new FILE_EQUIPMENT_ConnectUtils();
        public void add(FILE_EQUIPMENT obj)
        {
            DAL.add(obj.EquipmentID, obj.FileDocName, obj.FileType, obj.FileDescription, obj.OriFileName, obj.FileBinary,
                        obj.FileSize, obj.FileExt, obj.DateUploaded);
        }
        public void edit(FILE_EQUIPMENT obj)
        {
            DAL.edit(obj.FileID, obj.EquipmentID, obj.FileDocName, obj.FileType, obj.FileDescription, obj.OriFileName, obj.FileBinary[0],
                        obj.FileSize, obj.FileExt, obj.DateUploaded);
        }
        public void delete(FILE_EQUIPMENT obj)
        {
            DAL.delete(obj.FileID);
        }
        public List<FILE_EQUIPMENT> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
