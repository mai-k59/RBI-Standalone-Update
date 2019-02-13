using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class FILE_FACILITY_BUS
    {
        FILE_FACILITY_ConnectUtils DAL = new FILE_FACILITY_ConnectUtils();
        public void add(FILE_FACILITY obj)
        {
            DAL.add(obj.FacilityID, obj.FileDocName, obj.FileType, obj.FileDescription, obj.OriFileName, obj.FileBinary,
                        obj.FileSize, obj.FileExt, obj.DateUploaded);
        }
        public void edit(FILE_FACILITY obj)
        {
            DAL.edit(obj.FileID,obj.FacilityID, obj.FileDocName, obj.FileType, obj.FileDescription, obj.OriFileName, obj.FileBinary[0],
                        obj.FileSize, obj.FileExt, obj.DateUploaded);
        }
        public void delete(FILE_FACILITY obj)
        {
            DAL.delete(obj.FileID);
        }
        public List<FILE_FACILITY> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
