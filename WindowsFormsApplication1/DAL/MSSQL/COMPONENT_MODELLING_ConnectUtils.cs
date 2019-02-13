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
    class COMPONENT_MODELLING_ConnectUtils
    {
        public void add(int ComponentID,String ObjectName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "INSERT INTO [dbo].[COMPONENT_MODELLING]" +
                            "([ComponentID]" +
                            ",[ObjectName])" +
                            "VALUES" +
                            "('" + ComponentID + "'" +
                            ",'" + ObjectName + "')";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
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
        public void edit(int ID, int ComponentID, String ObjectName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "UPDATE [dbo].[COMPONENT_MODELLING]" +
                            "SET [ComponentID] = '" + ComponentID + "'" +
                            ",[ObjectName] = '" + ObjectName + "'" +
                            ",[Modified] = '" + DateTime.Now + "'" +
                            "WHERE [ID] ='" + ID + "'";
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
        public void delete(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "DELETE FROM [dbo].[COMPONENT_MODELLING] " +
                            "WHERE [ID] ='" + ID + "'";
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
        public List<COMPONENT_MODELLING> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<COMPONENT_MODELLING> list = new List<COMPONENT_MODELLING>();
            COMPONENT_MODELLING obj = null;
            String sql = "USE [rbi] SELECT [ID]" +
                        ",[ComponentID]" +
                        ",[ObjectName]" +
                        "  FROM [rbi].[dbo].[COMPONENT_MODELLING] ";
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
                            obj = new COMPONENT_MODELLING();
                            obj.ID = reader.GetInt32(0);
                            obj.ComponentID = reader.GetInt32(1);
                            obj.ObjectName = reader.GetString(2);
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
