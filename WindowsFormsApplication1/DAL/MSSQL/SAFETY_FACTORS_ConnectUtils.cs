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
    class  SAFETY_FACTORS_ConnectUtils
    {
        public void add(int SafetyFactorID, String SafetyFactorName, float A, float B, float C, float D, float E)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[SAFETY_FACTORS]" +
                           "([SafetyFactorID]" +
                           ",[SafetyFactorName]" +
                           ",[A]" +
                           ",[B]" +
                           ",[C]" +
                           ",[D]" +
                           ",[E])" +
                           " VALUES" +
                           "(  '" + SafetyFactorID + "'" +
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
        public void edit(int SafetyFactorID, String SafetyFactorName, float A, float B, float C, float D, float E)
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[SAFETY_FACTORS] " +
                              "SET[SafetyFactorID] = '" + SafetyFactorID + "'" +
                              ",[SafetyFactorName] = '" + SafetyFactorName + "'" +
                              ",[A] = '" + A + "'" +
                              ",[B] = '" + B + "'" +
                              ",[C] = '" + C + "'" +
                              ",[D] = '" + D + "'" +
                              ",[E] = '" + E+ "'" +
                              " WHERE [SafetyFactorID] = '" + SafetyFactorID + "'";
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

        public void delete(int SafetyFactorID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[SAFETY_FACTORS] WHERE [SafetyFactorID] = '" + SafetyFactorID + "'";
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
        public List<SAFETY_FACTORS> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<SAFETY_FACTORS> list = new List<SAFETY_FACTORS>();
            SAFETY_FACTORS obj = null;
            String sql = "Use [rbi] " +
                        "SELECT [SafetyFactorID]" +
                        ",[SafetyFactorName]" +
                        ",[A]" +
                        ",[B]" +
                        ",[C]" +
                        ",[D]" +
                        ",[E]" +
                        "  FROM [rbi].[dbo].[SAFETY_FACTORS]" +
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
                            obj = new SAFETY_FACTORS();
                            obj.SafetyFactorID = reader.GetInt32(0);
                            obj.SafetyFactorName = reader.GetString(1);
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
