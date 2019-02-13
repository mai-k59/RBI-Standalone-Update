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
    class MANUFACTURER_ConnectUtils
    {
        public void add(String ManufacturerName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[MANUFACTURER]" +
                        "([ManufacturerName])" +
                        "VALUES" +
                        "('" + ManufacturerName + "')" +
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
        public void edit(int ManufacturerID, String ManufacturerName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[MANUFACTURER]" +
                        "SET [ManufacturerName] = '" + ManufacturerName + "'" +
                        
                        "WHERE [ManufacturerID] = '" + ManufacturerID + "'" +
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
        public void delete(int ManufacturerID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "DELETE FROM [dbo].[MANUFACTURER]" +
                        "WHERE [ManufacturerID] = '" + ManufacturerID + "' " +
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
        public List<MANUFACTURER> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<MANUFACTURER> list = new List<MANUFACTURER>();
            MANUFACTURER obj = null;
            String sql = " Use [rbi] Select [ManufacturerID]" +
                          ",[ManufacturerName]" +
                          "From [dbo].[MANUFACTURER]  ";
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
                            obj = new MANUFACTURER();
                            obj.ManufacturerID = reader.GetInt32(0);
                            obj.ManufacturerName = reader.GetString(1);
                            

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

        public String getManufacturerName(int manuID)
        {
            String name = "";
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select ManufacturerName from rbi.dbo.MANUFACTURER where ManufacturerID = '"+manuID+"'";
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
                            name = reader.GetString(0);
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
            return name;
        }
        public int getIDbyName(String name)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            int ID = 0;
            String sql = " Use [rbi] Select [ManufacturerID]" +
                          ",[ManufacturerName]" +
                          "From [dbo].[MANUFACTURER]  WHERE [ManufacturerName] ='" + name + "'";
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
                            ID = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch
            {
                ID = 0;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return ID;
        }
        public List<string> getListManufactureName()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<string> name = new List<string>();
            //MANUFACTURER obj = null;
            String sql = "select ManufacturerName from rbi.dbo.MANUFACTURER";
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
                            name.Add(reader.GetString(0));
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
            return name;
        }
    }
}

