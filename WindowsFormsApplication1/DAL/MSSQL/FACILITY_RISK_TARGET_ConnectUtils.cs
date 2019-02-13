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
    class FACILITY_RISK_TARGET_ConnectUtils
    {
        public void add(int FacilityID,float RiskTarget_A,float RiskTarget_B,float RiskTarget_C,float RiskTarget_D,float RiskTarget_E,float RiskTarget_CA,
                        float RiskTarget_FC)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "INSERT INTO [dbo].[FACILITY_RISK_TARGET]" +
                            "([FacilityID]" +
                            ",[RiskTarget_A]" +
                            ",[RiskTarget_B]" +
                            ",[RiskTarget_C]" +
                            ",[RiskTarget_D]" +
                            ",[RiskTarget_E]" +
                            ",[RiskTarget_CA]" +
                            ",[RiskTarget_FC])" +
                            "VALUES" +
                            "('" + FacilityID + "'" +
                            ",'" + RiskTarget_A + "'" +
                            ",'" + RiskTarget_B + "'" +
                            ",'" + RiskTarget_C + "'" +
                            ",'" + RiskTarget_D + "'" +
                            ",'" + RiskTarget_E + "'" +
                            ",'" + RiskTarget_CA + "'" +
                            ",'" + RiskTarget_FC + "')";
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
        public void edit(int FacilityID,float RiskTarget_A,float RiskTarget_B,float RiskTarget_C,float RiskTarget_D,float RiskTarget_E,float RiskTarget_CA,
                        float RiskTarget_FC)
        {

            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "UPDATE [dbo].[FACILITY_RISK_TARGET]" +
                            "   SET [FacilityID] = '" + FacilityID + "'" +
                            "      ,[RiskTarget_A] = '" + RiskTarget_A + "'" +
                            "      ,[RiskTarget_B] = '" + RiskTarget_B + "'" +
                            "      ,[RiskTarget_C] = '" + RiskTarget_C + "'" +
                            "      ,[RiskTarget_D] = '" + RiskTarget_D + "'" +
                            "      ,[RiskTarget_E] = '" + RiskTarget_E + "'" +
                            "      ,[RiskTarget_CA] = '" + RiskTarget_CA + "'" +
                            "      ,[RiskTarget_FC] = '" + RiskTarget_FC + "'" +
                            " WHERE [FacilityID] = '" + FacilityID + "'";
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
        public void delete(int FacilityID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[FACILITY_RISK_TARGET] WHERE [FacilityID] = '" + FacilityID + "'";
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
        public List<FACILITY_RISK_TARGET> getDataSource()
        {
            List<FACILITY_RISK_TARGET> list = new List<FACILITY_RISK_TARGET>();
            FACILITY_RISK_TARGET obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [FacilityID]" +
                        ",[RiskTarget_A]" +
                        ",[RiskTarget_B]" +
                        ",[RiskTarget_C]" +
                        ",[RiskTarget_D]" +
                        ",[RiskTarget_E]" +
                        ",[RiskTarget_CA]" +
                        ",[RiskTarget_FC]" +
                        "  FROM [rbi].[dbo].[FACILITY_RISK_TARGET]";
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
                            obj = new FACILITY_RISK_TARGET();
                            obj.FacilityID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) { obj.RiskTarget_A = reader.GetFloat(1); }
                            if (!reader.IsDBNull(2)) { obj.RiskTarget_B = reader.GetFloat(2); }
                            if (!reader.IsDBNull(3)) { obj.RiskTarget_C = reader.GetFloat(3); }
                            if (!reader.IsDBNull(4)) { obj.RiskTarget_D = reader.GetFloat(4); }
                            if (!reader.IsDBNull(5)) { obj.RiskTarget_E = reader.GetFloat(5); }
                            if (!reader.IsDBNull(6)) { obj.RiskTarget_CA = reader.GetFloat(6); }
                            if (!reader.IsDBNull(7)) { obj.RiskTarget_FC = reader.GetFloat(7); }
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
        public FACILITY_RISK_TARGET getFacilityRiskTarget(int faciID)
        {
            FACILITY_RISK_TARGET obj = new FACILITY_RISK_TARGET();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "Select * from rbi.dbo.FACILITY_RISK_TARGET WHERE FacilityID = '" + faciID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj.FacilityID = reader.GetInt32(0);
                            obj.RiskTarget_A = (float)reader.GetDouble(1);
                            obj.RiskTarget_B = (float)reader.GetDouble(2);
                            obj.RiskTarget_C = (float)reader.GetDouble(3);
                            obj.RiskTarget_D = (float)reader.GetDouble(4);
                            obj.RiskTarget_E = (float)reader.GetDouble(5);
                            obj.RiskTarget_CA = (float)reader.GetDouble(6);
                            obj.RiskTarget_FC = (float)reader.GetDouble(7);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return obj;
        }
        public float getRiskTarget(int faciID)
        {

            float risk = 0;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select RiskTarget_FC from rbi.dbo.FACILITY_RISK_TARGET where FacilityID = '"+faciID+"'";
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
                            risk = (float)reader.GetDouble(0);
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
            return risk;
        }
    }
}
