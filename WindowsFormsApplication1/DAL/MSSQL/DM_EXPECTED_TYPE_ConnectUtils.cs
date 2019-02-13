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
    class DM_EXPECTED_TYPE_ConnectUtils
    {
        public void add(int ExpectedTypeID,String ExpectedTypeName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "INSERT INTO [dbo].[DM_EXPECTED_TYPE]" +
                            "([ExpectedTypeID]" +
                            ",[ExpectedTypeName])" +
                           "VALUES" +
                            "('" + ExpectedTypeID + "'" +
                            ",'" + ExpectedTypeName + "')";
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
        public void edit(int ExpectedTypeID,String ExpectedTypeName)
        {
            
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "UPDATE [dbo].[DM_EXPECTED_TYPE]" +
                            "   SET [ExpectedTypeID] = '" + ExpectedTypeID + "'" +
                            "      ,[ExpectedTypeName] = '" + ExpectedTypeName + "'" +
                            " WHERE [ExpectedTypeID] = '" + ExpectedTypeID + "'";
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
        public void delete(int ExpectedTypeID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[DM_EXPECTED_TYPE] WHERE [ExpectedTypeID] = '" + ExpectedTypeID + "'";
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
        public List<DM_EXPECTED_TYPE> getDataSource()
        {
            List<DM_EXPECTED_TYPE> list = new List<DM_EXPECTED_TYPE>();
            DM_EXPECTED_TYPE obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = " Use [rbi] Select [ExpectedTypeID]" +
                          ",[ExpectedTypeName]" +
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
                            obj = new DM_EXPECTED_TYPE();
                            obj.ExpectedTypeID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.ExpectedTypeName = reader.GetString(1);
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
    }
}
