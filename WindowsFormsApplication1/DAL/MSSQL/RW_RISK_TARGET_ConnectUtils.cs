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
    class RW_RISK_TARGET_ConnectUtils
    {
        public void add(int ID,  float RiskTarget_A, float RiskTarget_B, float RiskTarget_C, float RiskTarget_D, float RiskTarget_E, float RiskTarget_CA,float RiskTarget_FC)
                       
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[RW_RISK_TARGET]" +
                           "([ID]" +
                           ",[RiskTarget_A]" +
                           ",[RiskTarget_B]" +
                           ",[RiskTarget_C]" +
                           ",[RiskTarget_D]" +
                           ",[RiskTarget_E]" +
                            ",[RiskTarget_CA]" +
                           ",[RiskTarget_FC])" +
                           " VALUES" +
                           "(  '" + ID + "'" +
                            ", '" + RiskTarget_A + "'" +
                           ", '" + RiskTarget_B + "'" +
                           ", '" + RiskTarget_C + "'" +
                           ", '" + RiskTarget_D + "'"+
                            ", '" + RiskTarget_E + "'" +
                             ", '" + RiskTarget_CA + "'"+
                            ", '" + RiskTarget_FC + "')";
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
        public void edit(int ID, float RiskTarget_A, float RiskTarget_B, float RiskTarget_C, float RiskTarget_D, float RiskTarget_E, float RiskTarget_CA, float RiskTarget_FC)
                      
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[RW_RISK_TARGET] " +
                              "SET[ID] = '" + ID + "'" +
                              ",[RiskTarget_A] = '" + RiskTarget_A + "'" +
                               ",[RiskTarget_B] = '" + RiskTarget_B + "'" +
                              ",[RiskTarget_C] = '" + RiskTarget_C + "'" +
                              ",[RiskTarget_D] = '" + RiskTarget_D + "'" +
                              ",[RiskTarget_E] = '" + RiskTarget_E + "'" +
                               ",[RiskTarget_CA] = '" + RiskTarget_CA + "'" +
                              ",[RiskTarget_FC] = '" + RiskTarget_FC + "'" +
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
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_RISK_TARGET] WHERE [ID] = '" + ID + "'";
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
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            Boolean exist = false;
            String sql = "USE [rbi] SELECT * FROM [dbo].[RW_RISK_TARGET] WHERE [ID] = '" + ID + "'";
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
                            exist = true;
                        }
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
        public List<RW_RISK_TARGET> getDataSource()
        {
            List<RW_RISK_TARGET> list = new List<RW_RISK_TARGET>();
            RW_RISK_TARGET obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]  " +
                        "SELECT [ID]" +
                        ",[RiskTarget_A]" +
                        ",[RiskTarget_B]" +
                        ",[RiskTarget_C]" +
                        ",[RiskTarget_D]" +
                        ",[RiskTarget_E]" +
                        ",[RiskTarget_CA]" +
                        ",[RiskTarget_FC]" +
                        "  FROM [rbi].[dbo].[RW_RISK_TARGET] ";
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
                            obj = new RW_RISK_TARGET();
                            obj.ID = reader.GetInt32(0);
                            obj.RiskTarget_A = reader.GetFloat(1);
                            obj.RiskTarget_B = reader.GetFloat(2);
                            obj.RiskTarget_C = reader.GetFloat(3);
                            obj.RiskTarget_D = reader.GetFloat(4);
                            obj.RiskTarget_E = reader.GetFloat(5);
                            obj.RiskTarget_CA = reader.GetFloat(6);
                            obj.RiskTarget_FC = reader.GetFloat(7);
                            list.Add(obj);
                        }
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
            return list;
        }
    }
}
