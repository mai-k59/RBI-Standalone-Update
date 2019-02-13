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
    class USERS_PERMISSION_List_ConnectUtils
    {
        public void add( String Category, String Permission, String Container,
                        String Object, String ObjectType, String Action,int Active, Decimal SortOrder)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[USER_PERMISSON_LIST]" +
                           "([UserID]" +
                           ",[Category]" +
                           ",[Permission]" +
                           "[[Container]" +
                           ",[Object]" +
                           ",[ObjectType]" +
                           ",[Action]" +
                           ",[Active]"+
                           ",[SortOrder])"+
                           
                           " VALUES" +
                           "(  '" + Category + "'" +
                           ", '" + Permission + "'" +
                           ", '" + Container + "'" +
                           ", '" + Object + "'" +
                           ", '" + ObjectType + "'" +
                           ", '" + Action + "'" +
                            ", '" + Active + "'" +
                           ", '" + SortOrder + "')";
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
        public void edit(int PermissionID,String Category, String Permission, String Container,
                        String Object, String ObjectType, String Action, int Active, Decimal SortOrder)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                          "UPDATE [dbo].[USER_PERMISSON_LIST] " +
                          "SET[PermissionID] = '" + PermissionID + "'" +
                          ",[Category] = '" + Category + "'" +
                          ",[Permission] = '" + Permission + "'" +
                          ",[Container] = '" + Container + "'" +
                          ",[Object] = '" + Object + "'" +
                          ",[ObjectType] = '" + ObjectType + "'" +
                          ",[Action] = '" + Action + "'" +
                          ",[Active] = '" + Active + "'" +
                          ",[SortOrder]='" + SortOrder + "'"+
                          
                          " WHERE [PermissionID] = '" + PermissionID + "'";
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
        public void delete(int PermissionID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[USER_PERMISSION_LIST] WHERE [PermissionID] = '" + PermissionID + "'";
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
        public List<USER_PERMISSION_LIST> getDataSource()
        {
            List<USER_PERMISSION_LIST> list = new List<USER_PERMISSION_LIST>();
            USER_PERMISSION_LIST obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [PermissionID]" +
                        ",[Category]" +
                        ",[Permission]" +
                        ",[Container]" +
                        ",[Object]" +
                        ",[ObjectType]" +
                        ",[Action]" +
                        ",[Active]" +
                        ",[SortOrder]" +
                        "  FROM [rbi].[dbo].[USER_PERMISSION_LIST]";
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
                            obj = new USER_PERMISSION_LIST();
                            obj.PermissionID = reader.GetInt32(0);
                            obj.Category = reader.GetString(1);
                            obj.Permission = reader.GetString(2);
                            if (!reader.IsDBNull(3)) { obj.Container = reader.GetString(3); }
                            if (!reader.IsDBNull(4)) { obj.Object = reader.GetString(4); }
                            if (!reader.IsDBNull(5)) { obj.ObjectType = reader.GetString(5); }
                            if (!reader.IsDBNull(6)) { obj.Action = reader.GetString(6); }
                            obj.Active = reader.GetInt32(7);
                            obj.SortOrder = reader.GetInt32(8);
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
