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
    class RW_THICKNESS_ConnectUtils
    {
        public void add(int ID,int PointID, DateTime ThicknessDate,float MinReading, String Orientation, float MaxReading, String InspectionComment, String AnalysisComment, int ValidReading)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[RW_THICKNESS]" +
                           "([ID]" +
                           ",[PointID]" +
                           ",[ThicknessDate]"+
                           ",[MinReading]"+
                            ",[MaxReading]" +
                           ",[Orientation]" +
                           ",[InspectionComment]" +
                           ",[AnalysisComment]" +
                           ",[ValidReading])" +                          
                           " VALUES" +
                           "(  '" + ID + "'" +
                            ", '" + PointID + "'" +
                            ",'"+ ThicknessDate + "'"+
                            ","+ MinReading + ""+
                             ", '" + MaxReading + "'" +
                           ", '" + Orientation + "'" +
                           ", '" + InspectionComment + "'" +
                           ", '" + AnalysisComment + "'"+
                            ", '" + ValidReading + "')";
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
        public void edit(int ID, int PointID, DateTime ThicknessDate, float MinReading, String Orientation,
                     float MaxReading, String InspectionComment, String AnalysisComment, int ValidReading)
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[RW_THICKNESS] " +
                              "SET[ID] = '" + ID + "'" +
                              ",[PointID] = '" + PointID + "'" +
                              ",[ThicknessDate] = '" + ThicknessDate + "'" +
                               ",[MinReading] = '" + MinReading + "'" +
                                ",[MaxReading] = '" + MaxReading + "'" +
                               ",[Orientation] = '" + Orientation + "'" +
                              ",[InspectionComment] = '" + InspectionComment + "'" +
                              ",[AnalysisComment] = '" + AnalysisComment + "'" +
                              ",[ValidReading] = '" + ValidReading + "'" +
                              " WHERE [ID] = '" +ID + "'";
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

        public void delete(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_THICKNESS] WHERE [ID] = '" + ID + "'";
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
        public List<RW_THICKNESS> getDataSource()
        {
            List<RW_THICKNESS> list = new List<RW_THICKNESS>();
            RW_THICKNESS obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [ID]" +
                        ",[PointID]" +
                        ",[ThicknessID]" +
                        ",[ThicknessDate]" +
                        ",[MinReading]" +
                        ",[MaxReading]" +
                        ",[Orientation]" +
                        ",[InspectionComment]" +
                        ",[AnalysisComment]" +
                        ",[ValidReading]" +
                        "  FROM [rbi].[dbo].[RW_THICKNESS]";
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
                            obj = new RW_THICKNESS();
                            obj.ID = reader.GetInt32(0);
                            obj.PointID = reader.GetInt32(1);
                            obj.ThicknessID = reader.GetInt32(2);
                            if (!reader.IsDBNull(3)) { obj.ThicknessDate = reader.GetDateTime(3); }
                            if (!reader.IsDBNull(4)) { obj.MinReading = reader.GetFloat(4); }
                            if (!reader.IsDBNull(5)) { obj.MaxReading = reader.GetFloat(5); }
                            if (!reader.IsDBNull(6)) { obj.Orientation = reader.GetString(6); }
                            if (!reader.IsDBNull(7)) { obj.InspectionComment = reader.GetString(7); }
                            if (!reader.IsDBNull(8)) { obj.AnalysisComment = reader.GetString(8); }
                            obj.ValidReading = reader.GetInt32(9);
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
