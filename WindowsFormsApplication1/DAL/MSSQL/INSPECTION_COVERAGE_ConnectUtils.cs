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
    class INSPECTION_COVERAGE_ConnectUtils
    {
        public void add(int PlanID, String CoverageName, DateTime CoverageDate, String Remarks, String Findings, String FindingRTF)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "INSERT INTO [dbo].[INSPECTION_COVERAGE]" +
                        "([PlanID]" +
                        ",[CoverageName]" +
                        ",[CoverageDate]" +
                        ",[Remarks]" +
                        ",[Findings]" +
                        ",[FindingRTF])" +
                        "VALUES" +
                        "('" + PlanID + "'" +
                        ",'" + CoverageName + "'" +
                        ",'" + CoverageDate + "'" +
                        ",'" + Remarks + "'" +
                        ",'" + Findings + "'" +
                        ",'" + FindingRTF + "')";
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
        public void edit(int CoverageID, int PlanID, String CoverageName, DateTime CoverageDate, String Remarks, String Findings, String FindingRTF)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "UPDATE [dbo].[INSPECTION_COVERAGE]" +
                        "SET [PlanID] = '" + PlanID + "'" +
                        ",[CoverageName] = '" + CoverageName + "'" +
                        ",[CoverageDate] = '" + CoverageDate + "'" +
                        ",[Remarks] = '" + Remarks + "'" +
                        ",[Findings] = '" + Findings + "'" +
                        ",[FindingRTF] ='" + FindingRTF + "'" +
                        "WHERE [CoverageID] = '" + CoverageID + "' ";
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
        public void delete(int CoverageID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "DELETE FROM [dbo].[INSPECTION_COVERAGE]" +
                        "WHERE [CoverageID] = '" + CoverageID + "' ";
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
        public List<INSPECTION_COVERAGE> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<INSPECTION_COVERAGE> list = new List<INSPECTION_COVERAGE>();
            INSPECTION_COVERAGE obj = null;
            String sql = " Use [rbi] Select [CoverageID]" +
                          ",[PlanID]" +
                          ",[CoverageName]" +
                          ",[CoverageDate]" +
                          ",[Remarks]" +
                          ",[Findings]" +
                          ",[FindingRTF]" +
                          "From [dbo].[INSPECTION_COVERAGE]";
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
                            obj = new INSPECTION_COVERAGE();
                            obj.CoverageID = reader.GetInt32(0);
                            obj.PlanID = reader.GetInt32(1);
                            obj.CoverageName = reader.GetString(2);
                            if (!reader.IsDBNull(3))
                            {
                                obj.CoverageDate = reader.GetDateTime(3);
                            }
                            if (!reader .IsDBNull (4))
                            {
                                obj.Remarks = reader.GetString(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.Findings = reader.GetString(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.FindingRTF = reader.GetString(6);
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

    
