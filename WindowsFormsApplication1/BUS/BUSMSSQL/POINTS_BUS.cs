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
    class POINTS_BUS
    {
        POINTS_ConnectUtils DAL = new POINTS_ConnectUtils();
        public void add(POINTS obj)
        {
            DAL.add(obj.PointName, obj.ComponentID, obj.CorrosionRate, obj.NominalThickness, obj.MinReqThickness, obj.ThicknessCurrent, obj.ThicknessPrevious, obj.DateCurrent, obj.DatePrevious);
        }
        public void edit(POINTS obj)
        {
            DAL.edit(obj.PointID, obj.PointName, obj.ComponentID, obj.CorrosionRate, obj.NominalThickness, obj.MinReqThickness, obj.ThicknessCurrent, obj.ThicknessPrevious, obj.DateCurrent, obj.DatePrevious);

        }
        public void delete(POINTS obj)
        {
            DAL.delete(obj.PointID);
        }
        public List<POINTS> getDataSource()
        {
            return DAL.getDataSource();
        }

    }
}
