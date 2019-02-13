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

    class FACILITY_ConnectUtils
    {
        public void add(int SiteID,String FacilityName,float ManagementFactor)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO[dbo].[FACILITY]" +
                            "([SiteID]" +
                            ",[FacilityName]" +
                            ",[ManagementFactor])" +
                            "VALUES" +
                            "('" + SiteID + "'" +
                            ",'" + FacilityName + "'" +
                            ",'" + ManagementFactor + "')";
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
        public void edit(int FacilityID,int SiteID,String FacilityName,float ManagementFactor)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "UPDATE [dbo].[FACILITY]" +
                            "   SET [SiteID] = '" + SiteID + "'" +
                            "      ,[FacilityName] = '" + FacilityName + "'" +
                            "      ,[ManagementFactor] = '" + ManagementFactor + "'" +
                            " WHERE [FacilityID] = '" + FacilityID + "'";
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
        public void delete(int FacilityID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[FACILITY] WHERE [FacilityID] = '" + FacilityID + "'";
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
        public List<FACILITY> getDataSource()
        {
            List<FACILITY> list = new List<FACILITY>();
            FACILITY obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi]" +
                        "SELECT [FacilityID]" +
                        ",[SiteID]" +
                        ",[FacilityName]" +
                        ",[ManagementFactor]" +
                        "  FROM [rbi].[dbo].[FACILITY]";
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
                            obj = new FACILITY();
                            obj.FacilityID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) { obj.SiteID = reader.GetInt32(1); }
                            obj.FacilityName = reader.GetString(2);
                            obj.ManagementFactor = (float)reader.GetDouble(3);
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
        public FACILITY getData(int FacilityID)
        {
            FACILITY obj = new FACILITY();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi]" +
                        "SELECT [FacilityID]" +
                        ",[SiteID]" +
                        ",[FacilityName]" +
                        ",[ManagementFactor]" +
                        "  FROM [rbi].[dbo].[FACILITY] WHERE [FacilityID] = '"+FacilityID+"'";
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
                            obj.FacilityID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) { obj.SiteID = reader.GetInt32(1); }
                            obj.FacilityName = reader.GetString(2);
                            obj.ManagementFactor = (float)reader.GetDouble(3);
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
            return obj;
        }
        public float getFMS(int SiteID)
        {
            float FMS = 0;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT ManagementFactor FROM [rbi].[dbo].[FACILITY] WHERE SiteID = '"+SiteID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            FMS = (float)reader.GetDouble(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get FMS Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return FMS;
        }
        public String getFacilityName(int faciID)
        {
            String name = "";
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select FacilityName from rbi.dbo.FACILITY where FacilityID = '"+faciID+"'";
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
        public Boolean checkExist(String name)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            Boolean check = false;
            String sql = "USE[rbi]" +
                        "SELECT [FacilityID]" +
                        ",[SiteID]" +
                        ",[FacilityName]" +
                        ",[ManagementFactor]" +
                        "  FROM [rbi].[dbo].[FACILITY] WHERE [FacilityName] = '" + name + "'";
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
                            check = true;
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
            return check;
        }
        public int getIDbyName(String name)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            int check = 0;
            String sql = "USE[rbi]" +
                        "SELECT [FacilityID]" +
                        ",[SiteID]" +
                        ",[FacilityName]" +
                        ",[ManagementFactor]" +
                        "  FROM [rbi].[dbo].[FACILITY] WHERE [FacilityName] = '" + name + "'";
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
                            check = int.Parse(reader[0].ToString());
                        }
                    }
                }
            }
            catch
            {
                check = 0;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return check;
        }
        public int getIDbyName_SiteID(int siteID, string facilityName)
        {
            int id = 0;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            string sql = "select FacilityID from rbi.dbo.FACILITY where SiteID='"+siteID+"' and FacilityName='"+facilityName+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            id = reader.GetInt32(0);
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("sql " + ex.ToString(), "Error");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return id;
        }
        public List<string> getListFacilityName(int siteID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<string> obj = new List<string>();
            string sql = "select FacilityName from rbi.dbo.FACILITY where SiteID = '" + siteID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if(reader.HasRows)
                        obj.Add(reader.GetString(0));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Facility " + ex.ToString(), "Cortek RBI");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return obj;
        }
        public int getLastFacilityID()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            int id = 0;
            String sql = "SELECT MAX(FacilityID) FacilityID FROM rbi.dbo.FACILITY";
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
                            id = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Facility " + ex.ToString(), "Cortek RBI");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return id;
        }
        public List<int> getAlleqIDbyFaciID(int faciID)
        {
            List<int> list = new List<int>();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select EquipmentID from rbi.dbo.EQUIPMENT_MASTER where FacilityID = '" + faciID + "'";
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
                            list.Add(reader.GetInt32(0));
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
        public List<int> getIDbySiteID(int siteID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<int> list = new List<int>();
            String sql = "USE[rbi]" +
                        "SELECT [FacilityID]" +
                        "  FROM [rbi].[dbo].[FACILITY] WHERE SiteID = '" + siteID + "'";
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
                            list.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
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
