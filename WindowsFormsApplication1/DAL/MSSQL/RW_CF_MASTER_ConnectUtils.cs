using RBI.Object;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
namespace RBI.DAL.MSSQL
{
    class RW_CF_MASTER_ConnectUtils
    {
        public void add(int ID, float CF1, float CF2, float CF3, float CF4, float CF5, float CF6, float CF7, float CF8, float CF9)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[RW_CF_MASTER]" +
                        "([ID]" +
                        ",[CF1]" +
                        ",[CF2]" +
                        ",[CF3]" +
                        ",[CF4]" +
                        ",[CF5]" +
                        ",[CF6]" +
                        ",[CF7]" +
                        ",[CF8]" +
                        ",[CF9])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + CF1 + "'" +
                        ",'" + CF2 + "'" +
                        ",'" + CF3 + "'" +
                        ",'" + CF4 + "'" +
                        ",'" + CF5 + "'" +
                        ",'" + CF6 + "'" +
                        ",'" + CF7 + "'" +
                        ",'" + CF8 + "'" +
                        ",'" + CF9 + "')" +
                        " ";
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
        public void edit(int ID, float CF1, float CF2, float CF3, float CF4, float CF5, float CF6, float CF7, float CF8, float CF9)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_CF_MASTER]" +
                        "SET [ID] = '" + ID + "'" +
                        ",[CF1] = '" + CF1 + "'" +
                        ",[CF2] = '" + CF2 + "'" +
                        ",[CF3] = '" + CF3 + "'" +
                        ",[CF4] = '" + CF4 + "'" +
                        ",[CF5] = '" + CF5 + "'" +
                        ",[CF6] = '" + CF6 + "'" +
                        ",[CF7] = '" + CF7 + "'" +
                        ",[CF8] = '" + CF8 + "'" +
                        ",[CF9] = '" + CF9 + "'" +
                        
                        " WHERE [ID] = '" + ID + "'" +
                        " ";
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
                        " " +
                        "DELETE FROM [dbo].[RW_CF_MASTER]" +
                        "WHERE [ID]  = '" + ID + "' " +
                        " ";
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
        public List<RW_CF_MASTER> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_CF_MASTER> list = new List<RW_CF_MASTER>();
            RW_CF_MASTER obj = null;
            String sql = " Use [rbi] Select [ID]" +
                          ",[CF1]" +
                          ",[CF2]" +
                          ",[CF3]" +
                          ",[CF4]" +
                          ",[CF5]" +
                          ",[CF6]" +
                          ",[CF7]" +
                          ",[CF8]" +
                          ",[CF9]" +
                          "From [dbo].[RW_CF_MASTER]  ";
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
                            obj = new RW_CF_MASTER();
                            obj.ID = reader.GetInt32(0);
                            if(!reader .IsDBNull(1))
                            {
                                obj.CF1 = reader.GetFloat(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.CF2 = reader.GetFloat(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.CF3 = reader.GetFloat(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.CF4 = reader.GetFloat(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.CF5 = reader.GetFloat(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.CF6 = reader.GetFloat(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.CF7 = reader.GetFloat(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.CF8 = reader.GetFloat(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.CF9 = reader.GetFloat(9);
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


