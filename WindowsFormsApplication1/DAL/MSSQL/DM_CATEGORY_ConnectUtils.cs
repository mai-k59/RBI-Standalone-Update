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
    class DM_CATEGORY_ConnectUtils
    {
        public void add(int DMCategoryID, String DMCategoryName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi]"+
                            "INSERT INTO [dbo].[DM_CATEGORY]" +
                            "([DMCategoryID]" +
                            ",[DMCategoryName])" +
                            "VALUES" +
                            "('"+DMCategoryID+"'" +
                            ",'"+DMCategoryName+"')";

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
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
        public void edit(int DMCategoryID, String DMCategoryName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "UPDATE [dbo].[DM_CATEGORY]" +
                        "SET [DMCategoryID] = '"+DMCategoryID+"'" +
                        ",[DMCategoryName] = '"+DMCategoryName+"'" +
                        ",[Modified] = '"+DateTime.Now+"'" +
                        "WHERE [DMCategoryID] = '"+DMCategoryID+"'";
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
        public void delete(int DMCategoryID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "DELETE FROM [dbo].[DM_CATEGORY]" +
                        "WHERE [DMCategoryID] = '" + DMCategoryID + "'";
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
        public List<DM_CATEGORY> getDataSource()
        {
            List<DM_CATEGORY> list = new List<DM_CATEGORY>();
            DM_CATEGORY obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = " Use [rbi] Select [DMCategoryID]"+
                          ",[DMCategoryName]"+
                          "From [rbi].[dbo].[DM_CATEGORY] ";
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
                            obj = new DM_CATEGORY();
                            obj.DMCategoryID = reader.GetInt32(0);
                            obj.DMCategoryName = reader.GetString(1);
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
