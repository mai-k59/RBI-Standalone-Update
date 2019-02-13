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
    class RW_LF_MASTER_ConnectUtils
    {
        public void add(int ID, float LF1Factor, float LF4Factor, float LF5Factor, float LF6Factor, float LF7Factor, float LF1, float LF4, String LF5, String LF6, float LF7)
                       
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[RW_LF_MASTER]" +
                           "([ID]" +
                           ",[LF1Factor]" +
                           ",[LF4Factor]" +
                           ",[LF5Factor]" +
                            ",[LF6Factor]" +
                            ",[LF7Factor]" +
                           ",[LF1]" +
                           ",[LF4]" +
                           ",[LF5]" +
                           ",[LF6]" +
                            ",[LF7])" +
                           " VALUES" +
                           "(  '" + ID + "'" +
                            ", '" + LF1Factor + "'" +
                            ",'" + LF4Factor + "'" +
                            "," + LF5Factor + "" +
                            ", '" + LF6Factor + "'" +
                            ", '" + LF7Factor + "'" +
                           ", '" + LF1 + "'" +
                           ", '" + LF4 + "'" +
                           ", '" + LF5 + "'" +
                          ",'" + LF6 + "'" +
                           ", '" + LF7 + "')";
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
        public void edit(int ID, float LF1Factor, float LF4Factor, float LF5Factor, float LF6Factor, float LF7Factor, float LF1, float LF4, float LF5, float LF6, float LF7)
                        
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[RW_LF_MASTER] " +
                              "SET[ID] = '" + ID + "'" +
                              ",[LF1Factor] = '" + LF1Factor + "'" +
                              ",[LF4Factor] = '" + LF4Factor + "'" +
                              ",[LF5Factor] = '" + LF5Factor + "'" +
                              ",[LF6Factor] = '" + LF6Factor + "'" +
                             ",[LF7Factor] = '" + LF7Factor + "'" +
                             ",[LF1] = '" + LF1 + "'" +
                              ",[LF4] = '" +LF4 + "'" +
                              ",[LF5] = '" +LF5 + "'" +
                              ",[LF6] = '" +LF6 + "'" +
                              ",[LF7] = '" + LF7 + "'" +
                              " WHERE [ID] = '" + ID + "'";
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
        }

        public void delete(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_LF_MASTER] WHERE [ID] = '" + ID + "'";
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
        public List<RW_LF_MASTER> getDataSource()
        {
            List<RW_LF_MASTER> list = new List<RW_LF_MASTER>();
            RW_LF_MASTER obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [ID]" +
                        ",[LF1Factor]" +
                        ",[LF4Factor]" +
                        ",[LF5Factor]" +
                        ",[LF6Factor]" +
                        ",[LF7Factor]" +
                        ",[LF1]" +
                        ",[LF4]" +
                        ",[LF5]" +
                        ",[LF6]" +
                        ",[LF7]" +
                        "  FROM [rbi].[dbo].[RW_LF_MASTER]";
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
                            obj = new RW_LF_MASTER();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) { obj.LF1Factor = reader.GetFloat(1); }
                            if (!reader.IsDBNull(2)) { obj.LF4Factor = reader.GetFloat(2); }
                            if (!reader.IsDBNull(3)) { obj.LF5Factor = reader.GetFloat(3); }
                            if (!reader.IsDBNull(4)) { obj.LF6Factor = reader.GetFloat(4); }
                            if (!reader.IsDBNull(5)) { obj.LF7Factor = reader.GetFloat(5); }
                            if (!reader.IsDBNull(6)) { obj.LF1 = reader.GetFloat(6); }
                            if (!reader.IsDBNull(7)) { obj.LF4 = reader.GetFloat(7); }
                            if (!reader.IsDBNull(8)) { obj.LF5 = reader.GetFloat(8); }
                            if (!reader.IsDBNull(9)) { obj.LF6 = reader.GetFloat(9); }
                            if (!reader.IsDBNull(10)) { obj.LF7 = reader.GetFloat(10); }
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
