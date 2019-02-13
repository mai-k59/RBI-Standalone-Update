using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class FILE_COMPONENT_BUS
    {
        FILE_COMPONENT_ConnectUtils DAL = new FILE_COMPONENT_ConnectUtils();
        public void add(FILE_COMPONENT obj)
        {
            DAL.add(obj.ComponentID, obj.FileDocName, obj.FileType, obj.FileDescription, obj.OriFileName, obj.FileBinary[0],
                        obj.FileSize, obj.FileExt, obj.DateUploaded);
        }
        public void edit(FILE_COMPONENT obj)
        {
            DAL.edit(obj.FileID, obj.ComponentID, obj.FileDocName, obj.FileType, obj.FileDescription, obj.OriFileName, obj.FileBinary[0],
                        obj.FileSize, obj.FileExt, obj.DateUploaded);
        }
        public void delete(FILE_COMPONENT obj)
        {
            DAL.delete(obj.FileID);
        }
        public List<FILE_COMPONENT> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
