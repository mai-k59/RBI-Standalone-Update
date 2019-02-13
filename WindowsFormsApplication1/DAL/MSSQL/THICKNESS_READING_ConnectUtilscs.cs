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
    class THICKNESS_READING_ConnectUtils
    {
        public void add(int PointID, DateTime ThicknessDate, String Orientation, float MaxReading, float ThicknessReading
                        ,float CorrosionRate,int ValidReading,String Comment)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[THICKNESS_READING]" +
                           "([PointID]" +
                           ",[ThicknessDate]" +
                           ",[Orientation]" +
                           ",[MaxReading]" +
                           ",[ThicknessReading]" +
                           ",[CorrosionRate]" +
                           ",[ValidReading]" +
                           ",[Comment])" +
                           " VALUES" +
                           "(  '" + PointID + "'" +
                           ", '" + ThicknessDate + "'" +
                           ", '" + Orientation + "'" +
                           ", '" + MaxReading + "'" +
                           ", '" + ThicknessReading + "'" +
                           ", '" + CorrosionRate + "'" +
                           ", '" + ValidReading + "'" +
                           ", '" + Comment + "')";
                            
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
        public void edit(int ThicknessID,int PointID, DateTime ThicknessDate, String Orientation, float MaxReading,
                        float ThicknessReading, float CorrosionRate, int ValidReading, String Comment)
        {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[THICKNESS_READING] " +
                              "SET[ThicknessID] = '" + ThicknessID + "'" +
                              ",[PointID] = '" + PointID + "'" +
                              ",[ThicknessDate] = '" + ThicknessDate + "'" +
                               ",[Orientation] = '" + Orientation + "'" +
                              ",[MaxReading] = '" + MaxReading + "'" +
                              ",[ThicknessReading] = '" + ThicknessReading + "'" +
                              ",[CorrosionRate] = '" + CorrosionRate + "'" +
                              ",[ValidReading] = '" + ValidReading + "'" +
                              ",[Comment] = '" + Comment + "'" +
                              " WHERE [ThicknessID] = '" + ThicknessID + "'";
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

        public void delete(int ThicknessID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[THICKNESS_READING] WHERE [ThicknessID] = '" + ThicknessID + "'";
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
        public List<THICKNESS_READING> getDataSource()
        {
            List<THICKNESS_READING> list = new List<THICKNESS_READING>();
            THICKNESS_READING obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "Use [rbi]" +
                        "SELECT [ThicknessID]" +
                        ",[PointID]" +
                        ",[ThicknessDate]" +
                        ",[Orientation]" +
                        ",[MaxReading]" +
                        ",[ThicknessReading]" +
                        ",[CorrosionRate]" +
                        ",[ValidReading]" +
                        ",[Comment]" +
                        "  FROM [rbi].[dbo].[THICKNESS_READING]";
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
                            obj = new THICKNESS_READING();
                            obj.ThicknessID = reader.GetInt32(0);
                            obj.PointID = reader.GetInt32(1);
                            if (!reader.IsDBNull(2)) { obj.ThicknessDate = reader.GetDateTime(2); }
                            if (!reader.IsDBNull(3)) { obj.Orientation = reader.GetString(3); }
                            if (!reader.IsDBNull(4)) { obj.MaxReading = reader.GetFloat(4); }
                            if (!reader.IsDBNull(5)) { obj.ThicknessReading = reader.GetFloat(5); }
                            if (!reader.IsDBNull(6)) { obj.CorrosionRate = reader.GetFloat(6); }
                            obj.ValidReading = reader.GetInt32(7);
                            if (!reader.IsDBNull(7)) { obj.Comment = reader.GetString(8); }
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
