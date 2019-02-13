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
    class EQUIPMENT_REVISION_INSPECTION_COVERAGE_ConnectUtils
    {
        public void add(int RevisionID, int CoverageID,String InspPlanName,DateTime InspPlanDate,String CoverageName,
                       DateTime CoverageDate,String Remarks,String Findings,String FindingRTF)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO[dbo].[EQUIPMENT_REVISION_INSPECTION_COVERAGE]" +
                            "([RevisionID]" +
                            ",[CoverageID]" +
                            ",[InspPlanName]" +
                            ",[InspPlanDate]" +
                            ",[CoverageName]" +
                            ",[CoverageDate]" +
                            ",[Remarks]" +
                            ",[Findings]" +
                            ",[FindingRTF])" +
                            "VALUES" +
                            "('" + RevisionID + "'" +
                            ",'" + CoverageID + "'" +
                            ",'" + InspPlanName + "'" +
                            ",'" + InspPlanDate + "'" +
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
        public void edit(int RevisionID, int CoverageID,String InspPlanName,DateTime InspPlanDate,String CoverageName,
                       DateTime CoverageDate,String Remarks,String Findings,String FindingRTF)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           " UPDATE[dbo].[EQUIPMENT_REVISION_INSPECTION_COVERAGE]" +
                                  "SET[RevisionID] ='"+RevisionID+"'" +
                                  ",[CoverageID] = '"+CoverageID+"'" +
                                  ",[InspPlanName] = '"+InspPlanName+"'" +
                                  ",[InspPlanDate] = '"+InspPlanDate+"'" +
                                  ",[CoverageName] = '"+CoverageName+"'" +
                                  ",[CoverageDate] = '"+CoverageDate+"'" +
                                  ",[Remarks] = '"+Remarks+"'" +
                                  ",[Findings] = '"+Findings+"'" +
                                  ",[FindingRTF] = '"+FindingRTF+"'" +
                                  "WHERE [RevisionID] ='" + RevisionID + "'" +
                                  "AND [CoverageID] ='" + CoverageID + "'";
            
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
        public void delete(int RevisionID, int CoverageID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[EQUIPMENT_REVISION_INSPECTION_COVERAGE] where [RevisionID]='" + RevisionID + "' AND [CoverageID] ='" + CoverageID + "'";
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
        public List<EQUIPMENT_REVISION_INSPECTION_COVERAGE> getDataSource()
        {
            List<EQUIPMENT_REVISION_INSPECTION_COVERAGE> list = new List<EQUIPMENT_REVISION_INSPECTION_COVERAGE>();
            EQUIPMENT_REVISION_INSPECTION_COVERAGE obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi]" +
                        "SELECT [RevisionID]" +
                        ",[CoverageID]" +
                        ",[InspPlanName]" +
                        ",[InspPlanDate]" +
                        ",[CoverageName]" +
                        ",[CoverageDate]" +
                        ",[Remarks]" +
                        ",[Findings]" +
                        ",[FindingRTF]" +
                        "FROM [rbi].[dbo].[EQUIPMENT_REVISION_INSPECTION_COVERAGE]";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new EQUIPMENT_REVISION_INSPECTION_COVERAGE();
                            obj.RevisionID = reader.GetInt32(0);
                            obj.CoverageID = reader.GetInt32(1);
                            obj.InspPlanName = reader.GetString(2);
                            if (!reader.IsDBNull(3))
                            {
                                obj.InspPlanDate = reader.GetDateTime(3);
                            }
                            obj.CoverageName = reader.GetString(4);
                            if (!reader.IsDBNull(5))
                            {
                                obj.CoverageDate = reader.GetDateTime(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.Remarks = reader.GetString(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.Findings = reader.GetString(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.FindingRTF = reader.GetString(8);
                            }
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
