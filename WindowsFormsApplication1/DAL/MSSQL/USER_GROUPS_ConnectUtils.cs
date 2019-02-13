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
    class USER_GROUPS_ConnectUtils
    {
        public void add(String UserGroup ,int SysGroup, int Disabled)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[USER_GROUPS]" +
                           "([UserGroup]" +
                           ",[SysGroup]" +
                           ",[Disabled])" +
                           " VALUES" +
                           "(  '" + UserGroup + "'" +
                            ", '" + SysGroup + "'" +
                           ", '" + Disabled + "')";
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
        public void edit(int UserGroupID,String UserGroup, int SysGroup, int Disabled)
        {
            
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                          "UPDATE [dbo].[USER_GROUPS] " +
                          "SET[UserGroupID] = '" + UserGroupID + "'" +
                          ",[UserGroup] = '" + UserGroup + "'" +
                          ",[SysGroup] = '" + SysGroup + "'" +
                          ",[Disabled] = '" + Disabled + "'" +
                          
                          " WHERE [UserGroupID] = '" + UserGroupID + "'";
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
        public void delete(int UserGroupID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[USER_GROUPS] WHERE [UserGroupID] = '" + UserGroupID + "'";
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
        public List<USER_GROUPS> getDataSource()
        {
            List<USER_GROUPS> list = new List<USER_GROUPS>();
            USER_GROUPS obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "Use [rbi]" +
                        "SELECT [UserGroupID]" +
                        ",[UserGroup]" +
                        ",[SysGroup]" +
                        ",[Disabled]" +
                        "  FROM [rbi].[dbo].[USER_GROUPS]";
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
                            obj = new USER_GROUPS();
                            obj.UserGroupID = reader.GetInt32(0);
                            obj.UserGroup = reader.GetString(1);
                            obj.SysGroup = reader.GetInt32(2);
                            obj.Disabled = reader.GetInt32(3);
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
