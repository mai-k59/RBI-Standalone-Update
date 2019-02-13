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
    class RW_REVISION_INSPECTION_ConnectUtils
    {
        public void add(int ID,int CoverageDetailID, String InspPlanName, String CoverageName, int DMItemID, int IMTypeID, DateTime InspectionDate,String EffectivenessCode, String Findings, String FindingRTF)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[RW_REVISION_INSPECTION]" +
                           "([ID]" +
                           ",[CoverageDetailID]" +
                           ",[InspPlanName]" +
                           ",[CoverageName]" +
                           ",[DMItemID]" +
                           ",[IMTypeID]" +
                            ",[InspectionDate]" +
                           ",[EffectivenessCode]" +
                           ",[Findings]"+
                           ",[FindingRTF])"+
                           " VALUES" +
                           "(  '" + ID + "'" +
                            ", '" + CoverageDetailID + "'" +
                           ", '" + InspPlanName + "'" +
                           ", '" + CoverageName + "'" +
                           ", '" + DMItemID + "'" +
                           ", '" + IMTypeID + "'" +
                           ", '" + InspectionDate + "'" +
                           ", '" + EffectivenessCode + "'" +
                           ",'" + Findings + "'" +
                           ",'" + FindingRTF + "')";
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
        public void edit(int ID, int CoverageDetailID, String InspPlanName, String CoverageName, int DMItemID, int IMTypeID, DateTime InspectionDate, String EffectivenessCode, String Findings, String FindingRTF)
                       
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[RW_REVISION_INSPECTION] " +
                              "SET[ID] = '" + ID + "'" +
                              ",[CoverageDetailID] = '" + CoverageDetailID + "'" +
                               ",[InspPlanName] = '" + InspPlanName + "'" +
                              ",[CoverageName] = '" + CoverageName + "'" +
                              ",[DMItemID] = '" + DMItemID + "'" +
                              ",[IMTypeID] = '" + IMTypeID + "'" +
                               ",[InspectionDate] = '" + InspectionDate + "'" +
                              ",[EffectivenessCode] = '" + EffectivenessCode + "'" +
                                ",[Findings] = '" + Findings + "'" +
                               ",[FindingRTF] = '" + FindingRTF + "'" +
                              " WHERE [ID] = '" + ID + "'" +", AND [CoverageDetailID] = '" + CoverageDetailID + "'" ;
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

        public void delete(int ID, int CoverageDetailID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_REVISION_INSPECTION] WHERE [ID] = '" + ID + "'" + ",AND [CoverageDetailID] = '" + CoverageDetailID + "'";
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
        public List<RW_REVISION_INSPECTION> getDataSource()
        {
            List<RW_REVISION_INSPECTION> list = new List<RW_REVISION_INSPECTION>();
            RW_REVISION_INSPECTION obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [ID]" +
                        ",[CoverageDetailID]" +
                        ",[InspPlanName]" +
                        ",[CoverageName]" +
                        ",[DMItemID]" +
                        ",[IMTypeID]" +
                        ",[InspectionDate]" +
                        ",[EffectivenessCode]" +
                        ",[Findings]" +
                        ",[FindingRTF]" +
                        "  FROM [rbi].[dbo].[RW_REVISION_INSPECTION]";
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
                            obj = new RW_REVISION_INSPECTION();
                            obj.ID = reader.GetInt32(0);
                            obj.CoverageDetailID = reader.GetInt32(1);
                            obj.InspPlanName = reader.GetString(2);
                            obj.CoverageName = reader.GetString(3);
                            obj.DMItemID = reader.GetInt32(4);
                            obj.IMTypeID = reader.GetInt32(5);
                            obj.InspectionDate = reader.GetDateTime(6);
                            obj.EffectivenessCode = reader.GetString(7);
                            if (!reader.IsDBNull(8)) { obj.Findings = reader.GetString(8); }
                            if (!reader.IsDBNull(9)) { obj.FindingRTF = reader.GetString(9); }
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
