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
    class COMPONENT_DETAIL_ConnectUtils
    {
        public void add(int ComponentID, int MaterialID, int StreamID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO[dbo].[COMPONENT_DETAIL]" +
                            "([ComponentID]" +
                            ",[MaterialID]" +
                            ",[StreamID])" +
                            "VALUES" +
                            "('"+ComponentID+"'" +
                            ",'"+MaterialID+"'" +
                            ",'"+StreamID+"')";
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
        public void edit(int ComponentID, int MaterialID, int StreamID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           " UPDATE[dbo].[COMPONENT_DETAIL]" +
                                  "SET [ComponentID] ='"+ComponentID+"'" +
                                  ",[MaterialID] = '"+MaterialID+"'" +
                                  ",[StreamID] = '"+StreamID+"'" +
                                  ",[Modified] = '"+DateTime.Now+"'" +
                            "WHERE [ComponentID] ='"+ComponentID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
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
        public void delete(int ComponentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[COMPONENT_DETAIL] where [ComponentID]='" + ComponentID + "'";
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
        public COMPONENT_DETAIL getData(int ComponentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            COMPONENT_DETAIL obj = new COMPONENT_DETAIL();
            String sql = " Use [rbi] Select [ComponentID]" +
                          ",[MaterialID]" +
                          ",[StreamID]" +
                          "From [rbi].[dbo].[COMPONENT_DETAIL] Where [ComponentID] ='" + ComponentID + "'";
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
                            obj.ComponentID = reader.GetInt32(0);
                            obj.MaterialID = reader.GetInt32(1);
                            obj.StreamID = reader.GetInt32(2);
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
        public List<COMPONENT_DETAIL> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<COMPONENT_DETAIL> list = new List<COMPONENT_DETAIL>();
            COMPONENT_DETAIL obj = null;
            String sql = " Use [rbi] Select [ComponentID]" +
                          ",[MaterialID]" +
                          ",[StreamID]" +
                          "From [rbi].[dbo].[COMPONENT_DETAIL]";
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
                            obj = new COMPONENT_DETAIL();
                            obj.ComponentID = reader.GetInt32(0);
                            obj.MaterialID = reader.GetInt32(1);
                            obj.StreamID = reader.GetInt32(2);
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
