using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_THICKNESS_BUS
    {
        RW_THICKNESS_ConnectUtils DAL = new RW_THICKNESS_ConnectUtils();
        public void add(RW_THICKNESS obj)
        {
            DAL.add(obj.ID, obj.PointID, obj.ThicknessDate, obj.MinReading, obj.Orientation, obj.MaxReading, obj.InspectionComment, obj.AnalysisComment, obj.ValidReading);

        }
        public void edit(RW_THICKNESS obj)
        {
            DAL.edit(obj.ID, obj.PointID, obj.ThicknessDate, obj.MinReading, obj.Orientation, obj.MaxReading, obj.InspectionComment, obj.AnalysisComment, obj.ValidReading);
        }
        public void delete(RW_THICKNESS obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_THICKNESS> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
