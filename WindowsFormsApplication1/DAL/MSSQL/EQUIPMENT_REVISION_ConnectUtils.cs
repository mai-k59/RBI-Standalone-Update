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
    class EQUIPMENT_REVISION_ConnectUtils
    {
        public void add(int EquipmentID, String RevisionXML, int RevisionNo, String IssuedBy, DateTime IssuedDate,
                       String ReviewedBy, DateTime ReviewedDate, int IsReviewed, String ApprovedBy, DateTime ApprovedDate,
                       int IsApproved, String EndorsedBy, DateTime EndorsedDate)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO[dbo].[EQUIPMENT_REVISION]" +
                            "([EquipmentID]" +
                            ",[RevisionXML]" +
                            ",[RevisionNo]" +
                            ",[IssuedBy]" +
                            ",[IssuedDate]" +
                            ",[ReviewedBy]" +
                            ",[ReviewedDate]" +
                            ",[IsReviewed]" +
                            ",[ApprovedBy]" +
                            ",[pprovedDate]" +
                            ",[IsApproved]" +
                            ",[EndorsedBy]" +
                            ",[EndorsedDate])" +
                            "VALUES" +
                            "('" + EquipmentID + "'" +
                            ",'" + RevisionXML + "'" +
                            ",'" + RevisionNo + "'" +
                            ",'" + IssuedBy + "'" +
                            ",'" + IssuedDate + "'" +
                            ",'" + ReviewedBy + "'" +
                            ",'" + ReviewedDate + "'" +
                            ",'" + IsReviewed + "'" +
                            ",'" + ApprovedBy + "'" +
                            ",'" + ApprovedDate + "'" +
                            ",'" + IsApproved + "'" +
                            ",'" + EndorsedBy + "'" +
                            ",'" + EndorsedDate + "')";

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
        public void edit(int RevisionID, int EquipmentID, String RevisionXML, int RevisionNo, String IssuedBy, DateTime IssuedDate,
                       String ReviewedBy, DateTime ReviewedDate, int IsReviewed, String ApprovedBy, DateTime ApprovedDate,
                       int IsApproved, String EndorsedBy, DateTime EndorsedDate)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           " UPDATE[dbo].[EQUIPMENT_REVISION]" +
                                  "SET[RevisionID] ='" + RevisionID + "'" +
                                  ",[EquipmentID] = '" + EquipmentID + "'" +
                                  ",[RevisionXML] = '" + RevisionXML + "'" +
                                  ",[RevisionNo] = '" + RevisionNo + "'" +
                                  ",[IssuedBy] = '" + IssuedBy + "'" +
                                  ",[IssuedDate] = '" + IssuedDate + "'" +
                                  ",[ReviewedBy] = '" + ReviewedBy + "'" +
                                  ",[ReviewedDate] = '" + ReviewedDate + "'" +
                                  ",[IsReviewed] = '" + IsReviewed + "'" +
                                  ",[ApprovedBy] = '" + ApprovedBy + "'" +
                                  ",[ApprovedDate] = '" + ApprovedDate + "'" +
                                  ",[IsApproved] = '" + IsApproved + "'" +
                                  ",[EndorsedBy] = '" + EndorsedBy + "'" +
                                  ",[EndorsedDate] = '" + EndorsedDate + "'" +
                                  "WHERE [RevisionID] ='" + RevisionID + "'";
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
        public void delete(int RevisionID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[EQUIPMENT_REVISION] where [RevisionID]='" + RevisionID + "'";
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
        public List<EQUIPMENT_REVISION> getDataSource()
        {
            List<EQUIPMENT_REVISION> list = new List<EQUIPMENT_REVISION>();
            EQUIPMENT_REVISION obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "SELECT [RevisionID]" +
                        ",[EquipmentID]" +
                        ",[RevisionXML]" +
                        ",[RevisionNo]" +
                        ",[IssuedBy]" +
                        ",[IssuedDate]" +
                        ",[ReviewedBy]" +
                        ",[ReviewedDate]" +
                        ",[IsReviewed]" +
                        ",[ApprovedBy]" +
                        ",[ApprovedDate]" +
                        ",[IsApproved]" +
                        ",[EndorsedBy]" +
                        ",[EndorsedDate]" +
                        "FROM [rbi].[dbo].[EQUIPMENT_REVISION]";
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
                            obj = new EQUIPMENT_REVISION();
                            obj.RevisionID = reader.GetInt32(0);
                            obj.EquipmentID = reader.GetInt32(1);
                            obj.RevisionXML = reader.GetString(2);
                            obj.RevisionNo = reader.GetInt32(3);
                            if (!reader.IsDBNull(4))
                            {
                                obj.IssuedBy = reader.GetString(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.IssuedDate = reader.GetDateTime(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.ReviewedBy = reader.GetString(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.ReviewedDate = reader.GetDateTime(7);
                            }
                            obj.IsReviewed = reader.GetInt32(8);
                            if (!reader.IsDBNull(9))
                            {
                                obj.ApprovedBy = reader.GetString(9);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.ApprovedDate = reader.GetDateTime(10);
                            }
                            obj.IsApproved = reader.GetInt32(11);
                            if (!reader.IsDBNull(12))
                            {
                                obj.EndorsedBy = reader.GetString(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.EndorsedDate = reader.GetDateTime(13);
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
