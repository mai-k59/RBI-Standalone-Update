using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_POINTS_BUS
    {
        RW_POINTS_ConnectUtils DAL = new RW_POINTS_ConnectUtils();
        public void add(RW_POINTS obj)
        {
            DAL.add(obj.ID, obj.PointID, obj.GaugePoint, obj.PointLocation, obj.PIDNo, obj.FittingDesc, obj.Specification,obj.PointName,obj.Size,obj.MinReqThickness,obj.ThicknessReading,obj.ThicknessDate,obj.NominalThickness,obj.EstimatedCorrosionRate,obj.CalculatedCorrosionRate,obj.CalculatedRemainingLife,obj.k);
        }
        public void edit(RW_POINTS obj)
        {
            DAL.edit(obj.ID, obj.PointID, obj.GaugePoint, obj.PointLocation, obj.PIDNo, obj.FittingDesc, obj.Specification, obj.PointName, obj.Size, obj.MinReqThickness, obj.ThicknessReading, obj.ThicknessDate, obj.NominalThickness, obj.EstimatedCorrosionRate, obj.CalculatedCorrosionRate, obj.CalculatedRemainingLife, obj.k);
        }
        public void delete(RW_POINTS obj)
        {
            DAL.delete(obj.PointID);
        }
        public List<RW_POINTS> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
