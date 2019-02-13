using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class THICKNESS_READING_BUS
    {
        THICKNESS_READING_ConnectUtils DAL = new THICKNESS_READING_ConnectUtils();
        public void add(THICKNESS_READING obj)
        {
            DAL.add(obj.PointID, obj.ThicknessDate, obj.Orientation, obj.MaxReading, obj.ThicknessReading, obj.CorrosionRate, obj.ValidReading, obj.Comment);
        }
    }
}
