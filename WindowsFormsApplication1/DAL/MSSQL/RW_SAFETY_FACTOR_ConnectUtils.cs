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
    class RW_SAFETY_FACTOR_ConnectUtils
    {
        public void add(int ID, String SafetyFactorName, float A, float B, float C, float D, float E)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[RW_SAFETY_FACTOR]" +
                           "([ID]" +
                           ",[SafetyFactorName]" +
                           ",[A]" +
                           ",[B]" +
                           ",[C]" +
                           ",[D]" +
                           ",[E])" +
                           " VALUES" +
                           "(  '" + ID + "'" +
                            ", '" + SafetyFactorName + "'" +
                           ", '" + A + "'" +
                           ", '" + B + "'" +
                           ", '" + C + "'" +
                           ", '" + D + "'"+
                           ", '" + E + "')";
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
        public void edit(int ID, String SafetyFactorName, float A, float B, float C, float D, float E)
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[RW_SAFETY_FACTOR] " +
                              "SET[ID] = '" + ID + "'" +
                              ",[SafetyFactorName] = '" + SafetyFactorName + "'" +
                              ",[A] = '" + A + "'" +
                               ",[B] = '" + B + "'" +
                              ",[C] = '" + C + "'" +
                              ",[D] = '" + D + "'" +
                              ",[E] = '" + E + "'" +
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
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_SAFETY_FACTOR] WHERE [ID] = '" + ID + "'";
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
        public Boolean isExist(int ID)
        {
            Boolean exist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] SELECT * FROM [dbo].[RW_SAFETY_FACTOR] WHERE [ID] = '" + ID + "'";
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
                            exist = true;
                    }
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return exist;
        }
        public List<RW_SAFETY_FACTOR> getDataSource()
        {
            List<RW_SAFETY_FACTOR> list = new List<RW_SAFETY_FACTOR>();
            RW_SAFETY_FACTOR obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] SELECT ID]"+
                          ",[SafetyFactorScheme]"+
                          ",[A]"+
                          ",[B]"+
                          ",[C]"+
                          ",[D]"+
                          ",[E] FROM [dbo].[RW_SAFETY_FACTOR] ";
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
                            obj = new RW_SAFETY_FACTOR();
                            obj.ID = reader.GetInt32(0);
                            obj.SafetyFactorScheme = reader.GetString(1);
                            obj.A = reader.GetFloat(2);
                            obj.B = reader.GetFloat(3);
                            obj.C = reader.GetFloat(4);
                            obj.D = reader.GetFloat(5);
                            obj.E = reader.GetFloat(6);
                            list.Add(obj);
                        }
                           
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA SOURCE FAIL!", "ERROR!");
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
