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
    class INSPECTION_COVERAGE_DETAIL_ConnectUtils
    {
        public void add(int CoverageID,int ComponentID,int DMItemID,int IMTypeID, DateTime InspectionDate, String EffectivenessCode, int CarriedOut, DateTime CarriedOutDate)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "INSERT INTO [dbo].[INSPECTION_COVERAGE_DETAIL]" +
                        "([CoverageID]" +
                        ",[ComponentID]" +
                        ",[DMItemID]" +
                        ",[IMTypeID]" +
                        ",[InspectionDate]" +
                        ",[EffectivenessCode]" +
                        ",[CarriedOut]" +
                        ",[CarriedOutDate])" +
                        "VALUES" +
                        "('" + CoverageID + "'" +
                        ",'" + ComponentID + "'" +
                        ",'" + DMItemID + "'" +
                        ",'" + IMTypeID + "'" +
                        ",'" + InspectionDate + "'" +
                        ",'" + EffectivenessCode + "'" +
                        ",'" + CarriedOut + "'" +
                        ",'" + CarriedOutDate + "')";
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
        public void edit(int CoverageDetailID, int CoverageID, int ComponentID, int DMItemID, int IMTypeID, DateTime InspectionDate, String EffectivenessCode, int CarriedOut, DateTime CarriedOutDate)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "UPDATE [dbo].[INSPECTION_COVERAGE_DETAIL]" +
                        "SET [CoverageID] = '" + CoverageID + "'" +
                        ",[ComponentID] = '" + ComponentID + "'" +
                        ",[DMItemID] = '" + DMItemID + "'" +
                        ",[IMTypeID] ='" + IMTypeID + "'" +
                        ",[InspectionDate] = '" + InspectionDate + "'" +
                        ",[EffectivenessCode] = '" + EffectivenessCode + "'" +
                        ",[CarriedOut] = '" + CarriedOut + "'" +
                        ",[CarriedOutDate] = '" + CarriedOutDate + "'" +                        
                        "WHERE [CoverageDetailID] = '" + CoverageDetailID + "'";

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
        public void delete(int CoverageDetailID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "DELETE FROM [dbo].[INSPECTION_COVERAGE_DETAIL]" +
                        "WHERE [CoverageDetailID] = '" + CoverageDetailID + "'";
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
        public List<INSPECTION_COVERAGE_DETAIL> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<INSPECTION_COVERAGE_DETAIL> list = new List<INSPECTION_COVERAGE_DETAIL>();
            INSPECTION_COVERAGE_DETAIL obj = null;
            String sql = " Use [rbi] Select [CoverageDetailID]" +
                          ",[CoverageID]" +
                          ",[ComponentID]" +
                          ",[DMItemID]" +
                          ",[IMTypeID]" +
                          ",[InspectionDate]" +
                          ",[EffectivenessCode]" +
                          ",[CarriedOut]" +
                          ",[CarriedOutDate]" +
                          "From [dbo].[INSPECTION_COVERAGE_DETAIL]";
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
                            obj = new INSPECTION_COVERAGE_DETAIL();
                            obj.CoverageDetailID = reader.GetInt32(0);
                            obj.CoverageID = reader.GetInt32(1);
                            obj.ComponentID = reader.GetInt32(2);
                            obj.DMItemID = reader.GetInt32(3);
                            obj.IMTypeID = reader.GetInt32(4);
                            obj.InspectionDate = reader.GetDateTime(5);
                            obj.EffectivenessCode = reader.GetString(6);
                            obj.CarriedOut = reader.GetInt32(7);
                            if (!reader.IsDBNull(8))
                            {
                                obj.CarriedOutDate = reader.GetDateTime(8);
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


