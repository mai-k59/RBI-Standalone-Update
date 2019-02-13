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
    class USERS_PERMISSIONS_ConnectUtils
    {
        public void add(String UserID, String Category, String Permission, int Allowed,
                        String Type, int  Active)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[USER_PERMISSONS]" +
                           "([UserID]" +
                           ",[Category]" +
                           ",[Permission]" +
                           ",Allowed]" +
                           ",[Type]" +
                           ",[Active])" +
                           " VALUES" +
                           "( '" + UserID + "'" +
                           ", '" + Category + "'" +
                           ", '" + Permission + "'" +
                           ", '" + Allowed + "'" +
                           ", '" + Type + "'" +
                           ", '" + Active + "')";
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
        public void edit(int UserPermissionID, String UserID, String Category, String Permission, int Allowed,
                        String Type, int Active)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                          "UPDATE [dbo].[USER_PERMISSONS] " +
                          "SET[UserPermissionID] = '" + UserPermissionID + "'" +
                          ",[UserID] = '" + UserID + "'" +
                          ",[Category] = '" + Category + "'" +
                          ",[Permission] = '" + Permission + "'" +
                          ",[Allowed] = '" + Allowed + "'" +
                          ",[Type] = '" + Type + "'" +
                          ",[Active] = '" + Active + "'" +
                          " WHERE [UserPermissionID] = '" + UserPermissionID + "'";
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
        public void delete(int UserPermissionID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[USER_PERMISSIONS] WHERE [UserPermissionID] = '" + UserPermissionID + "'";
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
        public List<USER_PERMISSIONS> getDataSource()
        {
            List<USER_PERMISSIONS> list = new List<USER_PERMISSIONS>();
            USER_PERMISSIONS obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [UserPermissionID]" +
                        ",[UserID]" +
                        ",[Category]" +
                        ",[Permission]" +
                        ",[Allowed]" +
                        ",[Type]" +
                        ",[Active]" +
                        "  FROM [rbi].[dbo].[USER_PERMISSIONS]";
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
                            obj = new USER_PERMISSIONS();
                            obj.UserPermissionID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) { obj.UserID = reader.GetString(1); }
                            if (!reader.IsDBNull(2)) { obj.Category = reader.GetString(2); }
                            if (!reader.IsDBNull(3)) { obj.Permission = reader.GetString(3); }
                            obj.Allowed = reader.GetInt32(4);
                            if (!reader.IsDBNull(5)) { obj.Type = reader.GetString(5); }
                            obj.Active = reader.GetInt32(5);
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
