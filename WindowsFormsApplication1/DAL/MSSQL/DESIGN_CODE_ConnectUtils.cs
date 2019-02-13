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
    class DESIGN_CODE_ConnectUtils
    {
        public void add(String DesignCode, String DesignCodeApp)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "INSERT INTO [dbo].[DESIGN_CODE]" +
                        "([DesignCode]" +
                        ",[DesignCodeApp])" +
                        "VALUES" +
                        "('" + DesignCode + "'" +
                        ",'" + DesignCodeApp + "')";
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
        public void edit(int DesignCodeID, String DesignCode, String DesignCodeApp)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "UPDATE [dbo].[DESIGN_CODE]" +
                        "SET [DesignCode] = '" + DesignCode + "'" +
                        ",[DesignCodeApp] = '" + DesignCodeApp + "'" +
                        ",[Modified] = '" + DateTime.Now + "'" +
                        "WHERE [DesignCodeID] = '" + DesignCodeID + "'";
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
        public void delete(int DesignCodeID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "DELETE FROM [dbo].[DESIGN_CODE]" +
                        "WHERE [DesignCodeID] = '" + DesignCodeID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
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
        public List<DESIGN_CODE> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<DESIGN_CODE> list = new List<DESIGN_CODE>();
            DESIGN_CODE obj = null;
            String sql = " Use [rbi] Select [DesignCodeID]"+
                          ",[DesignCode]"+
                          ",[DesignCodeApp]"+
                          "From [rbi].[dbo].[DESIGN_CODE] ";
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
                            obj = new DESIGN_CODE();
                            obj.DesignCodeID = reader.GetInt32(0);
                            obj.DesignCode = reader.GetString(1);
                            if (!reader.IsDBNull(2))
                            {
                                obj.DesignCodeApp = reader.GetString(2);
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
        public String getDesignCodeName(int designCodeID)
        {
            String name = "";
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select DesignCode from rbi.dbo.DESIGN_CODE where DesignCodeID = '"+designCodeID+"'";
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
            String sql = " Use [rbi] Select [DesignCodeID]" +
                          ",[DesignCode]" +
                          ",[DesignCodeApp]" +
                          "From [rbi].[dbo].[DESIGN_CODE] WHERE [DesignCode] ='" + name + "' ";
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
                ID = 0;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return ID;
        }
        public List<string> getListDesignCodeName()
        {
            List<string> name = new List<string>();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select DesignCode from rbi.dbo.DESIGN_CODE";
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
