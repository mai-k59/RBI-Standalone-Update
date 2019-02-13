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
    class INSPECTION_PLAN_ConnectUtils
    {
        public void add(String InspPlanName, DateTime InspPlanDate,String Remarks)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "INSERT INTO [dbo].[INSPECTION_PLAN]" +
                        "([InspPlanName]" +
                        ",[InspPlanDate]" +
                        ",[Remarks])" +
                        "VALUES" +
                        "('" + InspPlanName + "'" +
                        ",'" + InspPlanDate + "'" +
                        ",'" + Remarks + "')";
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
        public void edit(int PlanID, String InspPlanName, DateTime InspPlanDate, String Remarks)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "UPDATE [dbo].[INSPECTION_PLAN]" +
                        "SET [InspPlanName] = '" + InspPlanName + "'" +
                        ",[InspPlanDate] = '" + InspPlanDate + "'" +
                        ",[Remarks] = '" + Remarks + "'" +                        
                        "WHERE [PlanID] = '" + PlanID + "'";
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
        public void delete(int PlanID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "DELETE FROM [dbo].[INSPECTION_PLAN]" +
                        "WHERE [PlanID] = '" + PlanID + "'";
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
        public List<INSPECTION_PLAN> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<INSPECTION_PLAN> list = new List<INSPECTION_PLAN>();
            INSPECTION_PLAN obj = null;
            String sql = " Use [rbi] Select [PlanID]" +
                          ",[InspPlanName]" +
                          ",[InspPlanDate]" +
                          ",[Remarks]" +
                          "From [dbo].[INSPECTION_PLAN]";
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
                            obj = new INSPECTION_PLAN();
                            obj.PlanID = reader.GetInt32(0);
                            obj.InspPlanName = reader.GetString(1);
                            if (!reader.IsDBNull(2))
                            {
                                obj.InspPlanDate = reader.GetDateTime(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.Remarks = reader.GetString(3);
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
