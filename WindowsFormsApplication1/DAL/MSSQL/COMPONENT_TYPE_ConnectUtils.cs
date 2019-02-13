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
    class COMPONENT_TYPE_ConnectUtils
    {
        public void add(int ComponentTypeID, String ComponentTypeName, String ComponentTypeCode)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "INSERT INTO [dbo].[COMPONENT_TYPE]" +
                            "([ComponentTypeID]" +
                            ",[ComponentTypeName]" +
                            ",[ComponentTypeCode])" +
                            "VALUES" +
                            "('"+ComponentTypeID+"'" +
                            ",'"+ComponentTypeName+"'" +
                            ",'"+ComponentTypeCode+"')";
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
        public void edit(int ComponentTypeID, String ComponentTypeName, String ComponentTypeCode)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "UPDATE [dbo].[COMPONENT_TYPE]" +
                            "SET [ComponentTypeID] = '" + ComponentTypeID + "'" +
                            ",[ComponentTypeName] = '" + ComponentTypeName + "'" +
                            ",[ComponentTypeCode] = '" + ComponentTypeCode + "'" +
                            ",[Modified] = '" + DateTime.Now + "'" +
                            " WHERE [ComponentTypeID] = '" + ComponentTypeID + "'";
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
        public void delete(int ComponentTypeID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "DELETE FROM[dbo].[COMPONENT_TYPE]" +
                        "WHERE [ComponentTypeID] = '" + ComponentTypeID + "'";
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
        public List<COMPONENT_TYPE> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<COMPONENT_TYPE> list = new List<COMPONENT_TYPE>();
            COMPONENT_TYPE obj = null;
            String sql = " Use [rbi] Select [ComponentTypeID]"+
                          ",[ComponentTypeName]"+
                          ",[ComponentTypeCode]"+
                          "From [rbi].[dbo].[COMPONENT_TYPE]";
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
                            obj = new COMPONENT_TYPE();
                            obj.ComponentTypeID = reader.GetInt32(0);
                            obj.ComponentTypeName = reader.GetString(1);
                            obj.ComponentTypeCode = reader.GetString(2);
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
        public String getComponentTypeName(int typeID)
        {
            String name = "";
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select ComponentTypeName from rbi.dbo.COMPONENT_TYPE where ComponentTypeID = '"+typeID+"'";
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
            String sql = " Use [rbi] Select [ComponentTypeID]" +
                          ",[ComponentTypeName]" +
                          ",[ComponentTypeCode]" +
                          "From [rbi].[dbo].[COMPONENT_TYPE] WHERE [ComponentTypeName] = '" + name + "'";
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
