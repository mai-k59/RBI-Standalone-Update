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
    class EXTRA_FIELDS_LOOKUP_ConnectUtils
    {
        public void add(int ExtraFieldID,String LookupText, String LookupValue)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO[dbo].[EXTRA_FIELDS_LOOKUP]" +
                            "([ExtraFieldID]" +
                            ",[LookupText]" +
                            ",[LookupValue])" +
                            "VALUES " +
                            "('" + ExtraFieldID + "'" +
                            ",'" + LookupText + "'" +
                            ",'" + LookupValue + "')";
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
        public void edit(int LookupID,int ExtraFieldID,String LookupText, String LookupValue)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           " UPDATE[dbo].[EXTRA_FIELDS_LOOKUP]" +
                                  "SET[LookupID] ='"+LookupID+"'" +
                                  ",[ExtraFieldID] = '"+ExtraFieldID+"'" +
                                  ",[LookupText] = '"+LookupText+"'" +
                                  ",[LookupValue] = '"+LookupValue+"'" +
                                  "WHERE [LookupID] ='" + LookupID + "'";
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
        public void delete(int LookupID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[EXTRA_FIELDS_LOOKUP] where [LookupID]='" + LookupID + "'";
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
        public List<EXTRA_FIELDS_LOOKUP> getDataSource()
        {
            List<EXTRA_FIELDS_LOOKUP> list = new List<EXTRA_FIELDS_LOOKUP>();
            EXTRA_FIELDS_LOOKUP obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [LookupID]" +
                        ",[ExtraFieldID]" +
                        ",[LookupText]" +
                        ",[LookupValue]" +
                        "  FROM [rbi].[dbo].[EXTRA_FIELDS_LOOKUP]";
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
                            obj = new EXTRA_FIELDS_LOOKUP();
                            obj.LookupID = reader.GetInt32(0);
                            obj.ExtraFieldID = reader.GetInt32(1);
                            if (!reader.IsDBNull(2))
                            {
                                obj.LookupText = reader.GetString(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.LookupValue = reader.GetString(3);
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
