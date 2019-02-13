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
    class EQUIPMENT_REVISION_INSPECTION_Connectutils
    {
        public void add(int RevisionID,int CoverageDetailID,String ComponentNumber,int CoverageID,int DMItemID,
                        int IMTypeID,DateTime InspectionDate,String EffectivenessCode,int CarriedOut,DateTime CarriedOutDate
                         )
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO[dbo].[EQUIPMENT_REVISION_INSPECTION]" +
                            "([RevisionID]" +
                            ",[CoverageDetailID]" +
                            ",[ComponentNumber]" +
                            ",[CoverageID]" +
                            ",[DMItemID]" +
                            ",[IMTypeID]" +
                            ",[InspectionDate]" +
                            ",[EffectivenessCode]" +
                            ",[CarriedOut]" +
                            ",[CarriedOutDate])" +
                            "VALUES" +
                            "('" + RevisionID + "'" +
                            ",'" + CoverageDetailID + "'" +
                            ",'" + ComponentNumber + "'" +
                            ",'" + CoverageID + "'" +
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
        public void edit(int RevisionID,int CoverageDetailID,String ComponentNumber,int CoverageID,int DMItemID,
                        int IMTypeID,DateTime InspectionDate,String EffectivenessCode,int CarriedOut,DateTime CarriedOutDate)
                        
            {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           " UPDATE[dbo].[EQUIPMENT_REVISION_INSPECTION]" +
                                  "SET[RevisionID] ='"+RevisionID+"'" +
                                  ",[CoverageDetailID] ='"+CoverageDetailID+"'" +
                                  ",[ComponentNumber] = '"+CoverageID+"'" +
                                  ",[DMItemID] = '"+DMItemID+"'" +
                                  ",[IMTypeID] = '"+IMTypeID+"'" +
                                  ",[CoverageID] = '"+CoverageID+"'" +
                                  ",[InspectionDate] = '"+InspectionDate+"'" +
                                  ",[EffectivenessCode] = '"+EffectivenessCode+"'" +
                                  ",[CarriedOut] = '"+CarriedOut+"'" +
                                  ",[CarriedOutDate] = '"+CarriedOutDate+"'" +
                                  "WHERE [RevisionID] ='" + RevisionID + "'" +
                                  "AND [CoverageDetailID] ='" + CoverageDetailID + "'";
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
        public void delete(int RevisionID,int CoverageDetailID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[EQUIPMENT_REVISION_INSPECTION] where [RevisionID]='" + RevisionID + "' AND [CoverageDetailID] ='" + CoverageDetailID + "'";
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
        public List<EQUIPMENT_REVISION_INSPECTION> getDataSource()
        {
            List<EQUIPMENT_REVISION_INSPECTION> list = new List<EQUIPMENT_REVISION_INSPECTION>();
            EQUIPMENT_REVISION_INSPECTION obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi]" +
                        "SELECT [RevisionID]" +
                        ",[CoverageDetailID]" +
                        ",[ComponentNumber]" +
                        ",[CoverageID]" +
                        ",[DMItemID]" +
                        ",[IMTypeID]" +
                        ",[InspectionDate]" +
                        ",[EffectivenessCode]" +
                        ",[CarriedOut]" +
                        ",[CarriedOutDate]" +
                        "FROM [rbi].[dbo].[EQUIPMENT_REVISION_INSPECTION]";
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
                            obj = new EQUIPMENT_REVISION_INSPECTION();
                            obj.RevisionID = reader.GetInt32(0);
                            obj.CoverageDetailID = reader.GetInt32(1);
                            obj.ComponentNumber = reader.GetString(2);
                            obj.CoverageID = reader.GetInt32(3);
                            obj.DMItemID = reader.GetInt32(4);
                            obj.IMTypeID = reader.GetInt32(5);
                            obj.InspectionDate = reader.GetDateTime(6);
                            obj.EffectivenessCode = reader.GetString(7);
                            obj.CarriedOut = reader.GetInt32(8);
                            if (!reader.IsDBNull(9))
                            {
                                obj.CarriedOutDate = reader.GetDateTime(9);
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
