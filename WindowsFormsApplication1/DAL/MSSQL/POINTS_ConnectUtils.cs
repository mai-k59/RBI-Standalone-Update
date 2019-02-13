using RBI.Object;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
namespace RBI.DAL.MSSQL
{
    class POINTS_ConnectUtils
    {
        public void add(String PointName,int ComponentID,float CorrosionRate,float NominalThickness, float MinReqThickness,float ThicknessCurrent,float ThicknessPrevious, DateTime DateCurrent, DateTime DatePrevious)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[POINTS]" +
                        "([PointName]" +
                        ",[ComponentID]" +
                        ",[CorrosionRate]" +
                        ",[NominalThickness]" +
                        ",[MinReqThickness]" +
                        ",[ThicknessCurrent]" +
                        ",[ThicknessPrevious]" +
                        ",[DateCurrent]" +
                        ",[DatePrevious])" +
                        "VALUES" +
                        "('" + PointName + "'" +
                        ",'" + ComponentID + "'" +
                        ",'" + CorrosionRate + "'" +
                        ",'" + NominalThickness + "'" +
                        ",'" + MinReqThickness + "'" +
                        ",'" + ThicknessCurrent + "'" +
                        ",'" + ThicknessPrevious + "'" +
                        ",'" + DateCurrent + "'" +
                        ",'" + DatePrevious + "')" +
                        " ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
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
        public void edit(int PointID, String PointName, int ComponentID, float CorrosionRate, float NominalThickness, float MinReqThickness, float ThicknessCurrent, float ThicknessPrevious, DateTime DateCurrent, DateTime DatePrevious)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[POINTS]" +
                        "SET [PointName] = '" + PointName + "'" +
                        ",[ComponentID] = '" + ComponentID + "'" +
                        ",[CorrosionRate] = '" + CorrosionRate + "'" +
                        ",[NominalThickness] = '" + NominalThickness + "'" +
                        ",[MinReqThickness] = '" + MinReqThickness + "'" +
                        ",[ThicknessCurrent] = '" + ThicknessCurrent + "'" +
                        ",[ThicknessPrevious] = '" + ThicknessPrevious + "'" +
                        ",[DateCurrent] = '" + DateCurrent + "'" +
                        ",[DatePrevious] = '" + DatePrevious + "'" +
                       
                        "WHERE [PointID] ='" + PointID + "'" +
                        " ";

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
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
        public void delete(int PointID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "DELETE FROM [dbo].[POINTS]" +
                        "WHERE [PointID]  = '" + PointID + "' " +
                        " ";
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
        public List<POINTS> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<POINTS> list = new List<POINTS>();
            POINTS obj = null;
            String sql = " Use [rbi] Select [PointID]" +
                          ",[PointName]" +
                          ",[ComponentID]" +
                          ",[CorrosionRate]" +
                          ",[NominalThickness]" +
                          ",[MinReqThickness]" +
                          ",[ThicknessCurrent]" +
                          ",[ThicknessPrevious]" +
                          ",[DateCurrent]" +
                          ",[DatePrevious]" +
                          "From [dbo].[POINTS]  ";
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
                            obj = new POINTS();
                            obj.PointID = reader.GetInt32(0);
                            obj.PointName = reader.GetString(1);
                            obj.ComponentID = reader.GetInt32(2);
                            if (!reader.IsDBNull(3))
                            {
                                obj.CorrosionRate = reader .GetFloat(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.NominalThickness = reader .GetFloat(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.MinReqThickness = reader .GetFloat(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.ThicknessCurrent = reader .GetFloat(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.ThicknessPrevious = reader.GetFloat(7);
                            }
                            if (!reader .IsDBNull(8))
                            {
                                obj.DateCurrent = reader.GetDateTime(8);
                            }
                            if (!reader .IsDBNull(9))
                            {
                                obj.DatePrevious = reader.GetDateTime(9);
                            }
                            list.Add(obj);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
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

