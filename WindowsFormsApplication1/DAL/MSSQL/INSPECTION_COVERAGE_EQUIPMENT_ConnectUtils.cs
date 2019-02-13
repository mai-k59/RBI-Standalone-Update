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
    class INSPECTION_COVERAGE_EQUIPMENT_ConnectUtils
    {
        public void add(int CoverageID, int EquipmentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "INSERT INTO [dbo].[INSPECTION_COVERAGE_EQUIPMENT]" +
                        "([CoverageID]" +
                        ",[EquipmentID])" +
                        "VALUES" +
                        "('" + CoverageID + "'" +
                        ",'" + EquipmentID + "')";
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
        public void edit(int CoverageID, int EquipmentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "UPDATE [dbo].[INSPECTION_COVERAGE_EQUIPMENT]" +
                        "SET [CoverageID] = '" + CoverageID + "'" +
                        ",[EquipmentID] = '" + EquipmentID + "'" +                      
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
            String sql = "USE [rbi]" +
                        "DELETE FROM [dbo].[INSPECTION_COVERAGE_EQUIPMENT]" +
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
        public List<INSPECTION_COVERAGE_EQUIPMENT> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<INSPECTION_COVERAGE_EQUIPMENT> list = new List<INSPECTION_COVERAGE_EQUIPMENT>();
            INSPECTION_COVERAGE_EQUIPMENT obj = null;
            String sql = " Use [rbi] Select [CoverageID]" +
                          ",[EquipmentID]" +
                          "From [dbo].[INSPECTION_COVERAGE_EQUIPMENT]";
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
                            obj = new INSPECTION_COVERAGE_EQUIPMENT();
                            obj.CoverageID = reader.GetInt32(0);
                            obj.EquipmentID = reader.GetInt32(1);
                           
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
