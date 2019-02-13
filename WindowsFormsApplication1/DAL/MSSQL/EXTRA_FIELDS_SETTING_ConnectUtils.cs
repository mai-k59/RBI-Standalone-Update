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
    class EXTRA_FIELDS_SETTING_ConnectUtils
    {
        public void add(int ExtraFieldID,String FieldID,String FieldName,String FieldDescription,int SeqNo,
                       String FieldType,int FieldSize,int IsActive,int IsCreated)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO[dbo].[EXTRA_FIELDS_SETTING]" +
                            "([ExtraFieldID]" +
                            ",[FieldID]" +
                            ",[FieldName]" +
                            ",[FieldDescription]" +
                            ",[SeqNo]" +
                            ",[FieldType]" +
                            ",[FieldSize]" +
                            ",[IsActive]" +
                            ",[IsCreated])" +
                            "VALUES" +
                            "('" + ExtraFieldID + "'" +
                            ",'" + FieldID + "'" +
                            ",'" + FieldName + "'" +
                            ",'" + FieldDescription + "'" +
                            ",'" + SeqNo + "'" +
                            ",'" + FieldType + "'" +
                            ",'" + FieldSize + "'" +
                            ",'" + IsActive + "'" +
                            ",'" + IsCreated + "')";
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
        public void edit(int ExtraFieldID,String FieldID,String FieldName,String FieldDescription,int SeqNo,
                       String FieldType,int FieldSize,int IsActive,int IsCreated)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           " UPDATE[dbo].[EXTRA_FIELDS_SETTING]" +
                                  "SET[ExtraFieldID] ='"+ExtraFieldID+"'" +
                                  ",[FieldID] = '"+FieldID+"'" +
                                  ",[FieldName] = '"+FieldName+"'" +
                                  ",[FieldDescription] = '"+FieldDescription+"'" +
                                  ",[SeqNo] = '"+SeqNo+"'" +
                                  ",[FieldType] = '"+FieldType+"'" +
                                  ",[FieldSize] = '"+FieldSize+"'" +
                                  ",[IsActive] = '"+IsActive+"'" +
                                  ",[IsCreated] = '"+IsCreated+"'" +
                                  "WHERE [ExtraFieldID] ='" + ExtraFieldID + "'";
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
        public void delete(int ExtraFieldID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[EXTRA_FIELDS_SETTING] where [ExtraFieldID]='" + ExtraFieldID + "'";
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
        public List<EXTRA_FIELDS_SETTING> getDataSource()
        {
            List<EXTRA_FIELDS_SETTING> list = new List<EXTRA_FIELDS_SETTING>();
            EXTRA_FIELDS_SETTING obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [ExtraFieldID]" +
                        ",[FieldID]" +
                        ",[FieldName]" +
                        ",[FieldDescription]" +
                        ",[SeqNo]" +
                        ",[FieldType]" +
                        ",[FieldSize]" +
                        ",[IsActive]" +
                        ",[IsCreated]" +
                        "  FROM [rbi].[dbo].[EXTRA_FIELDS_SETTING]";
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
                            obj = new EXTRA_FIELDS_SETTING();
                            obj.ExtraFieldID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1)) { obj.FieldID = reader.GetString(1); }
                            if (!reader.IsDBNull(2)) { obj.FieldName = reader.GetString(2); }
                            if (!reader.IsDBNull(3)) { obj.FieldDescription = reader.GetString(3); }
                            if (!reader.IsDBNull(4)) { obj.SeqNo = reader.GetInt32(4); }
                            if (!reader.IsDBNull(5)) { obj.FieldType = reader.GetString(5); }
                            if (!reader.IsDBNull(6)) { obj.FieldSize = reader.GetInt32(6); }
                            obj.IsActive = reader.GetInt32(7);
                            obj.IsCreated = reader.GetInt32(8);
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
