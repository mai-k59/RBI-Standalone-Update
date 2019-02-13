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
    class USERS_ConnectUtils
    {
        public void add(String UserID, String Title, String FirstName, String LastName,
                        String JobTitle, String Department, String Company, String UserGroupName, int ADAuthentication,
                        int SysUser, int IsActive, String LicenseKey, String Password)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[USERS]" +
                           "([UserID]" +
                           ",[Title]" +
                           ",[FirstName]" +
                           ",[LastName]" +
                           ",[JobTitle]" +
                           ",[Departmen]" +
                           ",[Company]" +
                           ",[UserGroupName]" +
                           ",[ADAuthentication]" +
                           ",[SysUser]" +
                           ",[IsActive]" +
                           ",[LicenseKey]" +
                           ",[Password])" +
                           " VALUES" +
                           "( '" + UserID + "'" +
                           ", '" + Title + "'" +
                           ", '" + FirstName + "'" +
                           ", '" + LastName + "'" +
                           ", '" + JobTitle + "'" +
                           ", '" + Department + "'" +
                           ", '" + Company + "'" +
                           ", '" + UserGroupName + "'" +
                           ", '" + SysUser + "'" +
                           ", '" + IsActive + "'" +
                           ", '" + LicenseKey + "'" +
                           ", '" + Password + "')";
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
        public void edit(String UserID, String Title, String FirstName, String LastName,
                        String JobTitle, String Department, String Company, String UserGroupName, int ADAuthentication,
                        int SysUser, int IsActive, String LicenseKey, String Password)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                          "UPDATE [dbo].[USERS] " +
                          "SET[UserID] = '" + UserID + "'" +
                          ",[Title] = '" + Title + "'" +
                          ",[FirstName] = '" + FirstName + "'" +
                          ",[LastName] = '" + LastName + "'" +
                          ",[JobTitle] = '" + JobTitle + "'" +
                          ",[Department] = '" + Department + "'" +
                          ",[Company] = '" + Company + "'" +
                          ",[UserGroupName] = '" + UserGroupName + "'" +
                          ",[ADAuthentication] = '" + ADAuthentication + "'" +
                          ",[SysUser] = '" + SysUser + "'" +
                          ",[IsActive] = '" + IsActive + "'" +
                          ",[LicenseKey] = '" + LicenseKey + "'" +
                          ",[Password] = '" + Password + "'" +
                          " WHERE [UserID] = '" + UserID + "'";
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
        public void delete(String UserID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[USERS] WHERE [UserID] = '" + UserID + "'";
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
        public List<USERS> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<USERS> list = new List<USERS>();
            USERS obj = null;
            String sql = "Use [rbi] " +
                        "SELECT [UserID]" +
                        ",[Title]" +
                        ",[FirstName]" +
                        ",[LastName]" +
                        ",[JobTitle]" +
                        ",[Department]" +
                        ",[Company]" +
                        ",[UserGroupName]" +
                        ",[ADAuthentication]" +
                        ",[SysUser]" +
                        ",[IsActive]" +
                        ",[LicenseKey]" +
                        ",[Password]" +
                        "  FROM [rbi].[dbo].[USERS]" +
                        " ";
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
                            obj = new USERS();
                            obj.UserID = reader.GetString(0);
                            obj.Title = reader.GetString(1);
                            obj.FirstName = reader.GetString(2);
                            obj.LastName = reader.GetString(3);
                            obj.JobTitle = reader.GetString(4);
                            obj.Department = reader.GetString(5);
                            obj.Company = reader.GetString(6);
                            obj.UserGroupName = reader.GetString(7);
                            obj.ADAuthentication = reader.GetInt32(8);
                            obj.SysUser = reader.GetInt32(9);
                            obj.IsActive = reader.GetInt32(10);
                            try
                            {
                                obj.LicenseKey = reader.GetString(11);
                            }
                            catch
                            {
                                obj.LicenseKey = "";
                            }
                            obj.Password = reader.GetString(12);
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
