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
    class API_ComponentTypeConnectUtils
    {
        public void add(int APIComponentTypeID, String APIComponentTypeName, float GFFSmall, float GFFMedium,
                        float GFFLarge, float GFFRupture, float GFFTotal, float HoleCostSmall, float HoleCostMedium,
                        float HoleCostLarge, float HoleCostRupture, float OutageSmall, float OutageMedium, float OutageLarge,
                        float OutageRupture)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql =   "USE [rbi]"+
                           "INSERT INTO [dbo].[API_COMPONENT_TYPE]"+
                           "([APIComponentTypeID]"+
                           ",[APIComponentTypeName]"+
                           ",[GFFSmall]"+
                           ",[GFFMedium]"+
                           ",[GFFLarge]"+
                           ",[GFFRupture]"+
                           ",[GFFTotal]"+
                           ",[HoleCostSmall]"+
                           ",[HoleCostMedium]"+
                           ",[HoleCostLarge]"+
                           ",[HoleCostRupture]"+
                           ",[OutageSmall]"+
                           ",[OutageMedium]"+
                           ",[OutageLarge]"+
                           ",[OutageRupture])"+
                           " VALUES"+
                           "( '"+APIComponentTypeID+"'"+
                           ", '"+APIComponentTypeName+"'"+
                           ", '"+GFFSmall+"'"+
                           ", '"+GFFMedium+"'"+
                           ", '"+GFFLarge+"'"+
                           ", '"+GFFRupture+"'"+
                           ", '"+GFFTotal+"'"+
                           ", '"+HoleCostSmall+"'"+
                           ", '"+HoleCostMedium+"'"+
                           ", '"+HoleCostLarge+"'"+
                           ", '"+HoleCostRupture+"'"+
                           ", '"+OutageSmall+"'"+
                           ", '"+OutageMedium+"'"+
                           ", '"+OutageLarge+"'"+
                           ", '"+OutageRupture+"')";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "ADD FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int APIComponentTypeID, String APIComponentTypeName, float GFFSmall, float GFFMedium,
                       float GFFLarge, float GFFRupture, float GFFTotal, float HoleCostSmall, float HoleCostMedium,
                       float HoleCostLarge, float HoleCostRupture, float OutageSmall, float OutageMedium, float OutageLarge,
                       float OutageRupture)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]"+
                          "UPDATE [dbo].[API_COMPONENT_TYPE] " +
                          "SET[APIComponentTypeID] = '"+APIComponentTypeID+"'" +
                          ",[APIComponentTypeName] = '"+APIComponentTypeName+"'" +
                          ",[GFFSmall] = '"+GFFSmall+"'" +
                          ",[GFFMedium] = '"+GFFMedium+"'" +
                          ",[GFFLarge] = '"+GFFLarge+"'" +
                          ",[GFFRupture] = '"+GFFRupture+"'" +
                          ",[GFFTotal] = '"+GFFTotal+"'" +
                          ",[HoleCostSmall] = '"+HoleCostSmall+"'" +
                          ",[HoleCostMedium] = '"+HoleCostMedium+"'" +
                          ",[HoleCostLarge] = '"+HoleCostLarge+"'" +
                          ",[HoleCostRupture] = '"+HoleCostRupture+"'" +
                          ",[OutageSmall] = '"+OutageSmall+"'" +
                          ",[OutageMedium] = '"+OutageMedium+"'" +
                          ",[OutageLarge] = '"+OutageLarge+"'" +
                          ",[OutageRupture] = '"+OutageRupture+"'" +
                          ",[Modified] = '"+DateTime.Now+"'" +
                          " WHERE [APIComponentTypeID] = '"+APIComponentTypeID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "EDIT FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void delete(int APIComponentTypeID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]  DELETE FROM [dbo].[API_COMPONENT_TYPE] WHERE [dbo].[API_COMPONENT_TYPE] = '" + APIComponentTypeID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
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
        public API_COMPONENT_TYPE getData(String APIComponentTypeName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            API_COMPONENT_TYPE obj = new API_COMPONENT_TYPE();
            String sql = " Use [rbi] Select [APIComponentTypeID]"+
                          ",[APIComponentTypeName]" +
                          ",[GFFSmall]" +
                          ",[GFFMedium]" +
                          ",[GFFLarge]" +
                          ",[GFFRupture]" +
                          ",[GFFTotal]" +
                          ",[HoleCostSmall]" +
                          ",[HoleCostMedium]" +
                          ",[HoleCostLarge]" +
                          ",[HoleCostRupture]" +
                          ",[OutageSmall]" +
                          ",[OutageMedium]" +
                          ",[OutageLarge]" +
                          ",[OutageRupture]" +
                          "From [dbo].[API_COMPONENT_TYPE] Where [APIComponentTypeName] ='" + APIComponentTypeName + "'";
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
                            obj.APIComponentTypeID = reader.GetInt32(0);
                            obj.APIComponentTypeName = APIComponentTypeName;
                            obj.GFFSmall = (float)reader.GetDouble(2);
                            obj.GFFMedium = (float)reader.GetDouble(3);
                            obj.GFFLarge = (float)reader.GetDouble(4);
                            obj.GFFRupture = (float)reader.GetDouble(5);
                            obj.GFFTotal = (float)reader.GetDouble(6);
                            obj.HoleCostSmall = (float)reader.GetDouble(7);
                            obj.HoleCostMedium=(float) reader.GetDouble(8);
                            obj.HoleCostLarge = (float)reader.GetDouble(9);
                            obj.HoleCostRupture = (float)reader.GetDouble(10);
                            obj.OutageSmall = (float)reader.GetDouble(11);
                            obj.OutageMedium = (float)reader.GetDouble(12);
                            obj.OutageLarge = (float)reader.GetDouble(13);
                            obj.OutageRupture = (float)reader.GetDouble(14);
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
            return obj;
        }
        public List<API_COMPONENT_TYPE> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<API_COMPONENT_TYPE> list = new List<API_COMPONENT_TYPE>();
            API_COMPONENT_TYPE obj = null;
            String sql = " Use [rbi] Select [APIComponentTypeID]" +
                          ",[APIComponentTypeName]" +
                          ",[GFFSmall]" +
                          ",[GFFMedium]" +
                          ",[GFFLarge]" +
                          ",[GFFRupture]" +
                          ",[GFFTotal]" +
                          ",[HoleCostSmall]" +
                          ",[HoleCostMedium]" +
                          ",[HoleCostLarge]" +
                          ",[HoleCostRupture]" +
                          ",[OutageSmall]" +
                          ",[OutageMedium]" +
                          ",[OutageLarge]" +
                          ",[OutageRupture]" +
                          "From [dbo].[API_COMPONENT_TYPE]";
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
                            obj = new API_COMPONENT_TYPE();
                            obj.APIComponentTypeID = reader.GetInt32(0);
                            obj.APIComponentTypeName = reader.GetString(1);
                            obj.GFFSmall = (float)reader.GetDouble(2);
                            obj.GFFMedium = (float)reader.GetDouble(3);
                            obj.GFFLarge = (float)reader.GetDouble(4);
                            obj.GFFRupture = (float)reader.GetDouble(5);
                            obj.GFFTotal = (float)reader.GetDouble(6);
                            obj.HoleCostSmall = (float)reader.GetDouble(7);
                            obj.HoleCostMedium = (float)reader.GetDouble(8);
                            obj.HoleCostLarge = (float)reader.GetDouble(9);
                            obj.HoleCostRupture = (float)reader.GetDouble(10);
                            obj.OutageSmall = (float)reader.GetDouble(11);
                            obj.OutageMedium = (float)reader.GetDouble(12);
                            obj.OutageLarge = (float)reader.GetDouble(13);
                            obj.OutageRupture = (float)reader.GetDouble(14);
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
        public float getGFFTotal(String ComponentType)
        {
            float GFFTotal = 0;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT GFFTotal FROM [rbi].[dbo].[API_COMPONENT_TYPE] WHERE APIComponentTypeName = '"+ComponentType+"'";
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
                            GFFTotal = (float)reader.GetDouble(0);
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
            return GFFTotal;
        }
        public String getAPIComponentTypeName(int APIID)
        {
            String APIName = "";
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT APIComponentTypeName FROM [rbi].[dbo].[API_COMPONENT_TYPE] WHERE APIComponentTypeID = '"+APIID+"'";
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
                            if (!reader.IsDBNull(0))
                                APIName = reader.GetString(0);
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
            return APIName;
        }
        public int getIDbyName(string name)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            int ID = 0;
            String sql = " Use [rbi] Select [APIComponentTypeID]" +
                          ",[APIComponentTypeName]" +
                          "From [dbo].[API_COMPONENT_TYPE] WHERE [APIComponentTypeName] = '" + name + "'";
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
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return ID;
        }
    }
}
