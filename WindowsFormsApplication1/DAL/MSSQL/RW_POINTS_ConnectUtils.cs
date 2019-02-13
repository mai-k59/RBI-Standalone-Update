using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.DAL.MSSQL
{
    class RW_POINTS_ConnectUtils
    {
        public void add(int ID, int PointID, String PointName, String GaugePoint, String PointLocation, String PIDNo, String FittingDesc, String Specification, String Size,float MinReqThickness, float ThicknessReading,DateTime ThicknessDate,float NominalThickness,float EstimatedCorrosionRate,float CalculatedCorrosionRate,float CalculatedRemainingLife, float k)
                       
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[RW_POINTS]" +
                           "([ID]" +
                           ",[PointID]" +
                           ",[PointName]" +
                           ",[GaugePoint]" +
                            ",[PointLocation]" +
                            ",[PIDNo]" +
                           ",[FittingDesc]" +
                           ",[Specification]" +
                           ",[Size]" +
                           ",[MinReqThickness]"+
                             ",[ThicknessReading]" +
                           ",[ThicknessDate]" +
                           ",[NominalThickness]" +
                           ",[EstimatedCorrosionRate]" +
                           ",[Modified]" +
                           ",[CalculatedCorrosionRate]"+
                           ",[CalculatedRemainingLife]"+
                           ",[CalculatedRemainingLife]"+
                           ",[k])"+
                           " VALUES" +
                           "(  '" + ID + "'" +
                            ", '" + PointID + "'" +
                            ",'" + PointName + "'" +
                            "," + GaugePoint + "" +
                             ", '" + PointLocation + "'" +
                             ", '" + PIDNo + "'" +
                           ", '" + FittingDesc + "'" +
                           ", '" + Specification + "'" +
                           ", '" + Size + "'"+
                          ",'"+ MinReqThickness + "'"+
                              ", '" + ThicknessReading + "'" +
                           ", '" + ThicknessDate + "'" +
                           ", '" + NominalThickness + "'" +
                          ",'" + EstimatedCorrosionRate + "'" +
                            ", '" + CalculatedCorrosionRate + "'" +
                         ", '" + CalculatedRemainingLife + "'" +
                         ", '" + k + "')";
                          
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "ADD FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int ID, int PointID, String PointName, String GaugePoint, String PointLocation, String PIDNo, String FittingDesc, String Specification, String Size, float MinReqThickness, float ThicknessReading, DateTime ThicknessDate, float NominalThickness, float EstimatedCorrosionRate, float CalculatedCorrosionRate, float CalculatedRemainingLife, float k)
                      
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[RW_POINTS] " +
                              "SET[ID] = '" + ID + "'" +
                              ",[PointID] = '" + PointID + "'" +
                              ",[PointName] = '" + PointName + "'" +
                              ",[GaugePoint] = '" + GaugePoint + "'" +
                              ",[PointLocation] = '" + PointLocation + "'" +
                             ",[PIDNo] = '" + PIDNo + "'" +
                             ",[FittingDesc] = '" + FittingDesc + "'" +
                              ",[Specification] = '" + Specification + "'" +
                              ",[Size] = '" + Size + "'" +
                               ",[MinReqThickness] = '" + MinReqThickness + "'" +
                              ",[ThicknessReading] = '" + ThicknessReading + "'" +
                              ",[ThicknessDate] = '" + ThicknessDate + "'" +
                             ",[NominalThickness] = '" + NominalThickness + "'" +
                             ",[EstimatedCorrosionRate] = '" + EstimatedCorrosionRate + "'" +
                              ",[CalculatedCorrosionRate] = '" + CalculatedCorrosionRate + "'" +
                              ",[CalculatedRemainingLife] = '" + CalculatedRemainingLife + "'" +
                              ",[k] = '" + k + "'" +
                              " WHERE [PointID] = '" + PointID + "'";
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "EDIT FAIL!");
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public void delete(int PointID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_POINTS] WHERE [PointID] = '" + PointID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "DELETE FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        // dung file get data
        // dung file get list( data source)
        public List<RW_POINTS> getDataSource()
        {
            List<RW_POINTS> list = new List<RW_POINTS>();
            RW_POINTS obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [ID]" +
                        ",[PointID]" +
                        ",[PointName]" +
                        ",[GaugePoint]" +
                        ",[PointLocation]" +
                        ",[PIDNo]" +
                        ",[FittingDesc]" +
                        ",[Specification]" +
                        ",[Size]" +
                        ",[MinReqThickness]" +
                        ",[ThicknessReading]" +
                        ",[ThicknessDate]" +
                        ",[NominalThickness]" +
                        ",[EstimatedCorrosionRate]" +
                        ",[CalculatedCorrosionRate]" +
                        ",[CalculatedRemainingLife]" +
                        ",[k]" +
                        "  FROM [rbi].[dbo].[RW_POINTS]";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_POINTS();
                            obj.ID = reader.GetInt32(0);
                            obj.PointID = reader.GetInt32(1);
                            if (!reader.IsDBNull(2)) { obj.PointName = reader.GetString(2); }
                            if (!reader.IsDBNull(3)) { obj.GaugePoint = reader.GetString(3); }
                            if (!reader.IsDBNull(4)) { obj.PointLocation = reader.GetString(4); }
                            if (!reader.IsDBNull(5)) { obj.PIDNo = reader.GetString(5); }
                            if (!reader.IsDBNull(6)) { obj.FittingDesc = reader.GetString(6); }
                            if (!reader.IsDBNull(7)) { obj.Specification = reader.GetString(7); }
                            if (!reader.IsDBNull(8)) { obj.Size = reader.GetString(8); }
                            if (!reader.IsDBNull(9)) { obj.MinReqThickness = reader.GetFloat(9); }
                            if (!reader.IsDBNull(10)) { obj.ThicknessReading = reader.GetFloat(10); }
                            if (!reader.IsDBNull(11)) { obj.ThicknessDate = reader.GetDateTime(11); }
                            if (!reader.IsDBNull(12)) { obj.NominalThickness = reader.GetFloat(12); }
                            if (!reader.IsDBNull(13)) { obj.EstimatedCorrosionRate = reader.GetFloat(13); }
                            if (!reader.IsDBNull(14)) { obj.CalculatedCorrosionRate = reader.GetFloat(14); }
                            if (!reader.IsDBNull(15)) { obj.CalculatedRemainingLife = reader.GetFloat(15); }
                            if (!reader.IsDBNull(16)) { obj.k = reader.GetFloat(16); }
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA SOURCE FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
    }
}
