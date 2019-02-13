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
    class DM_ITEMS_ConnectUtils
    {
        public void add(int DMItemID,String DMDescription,int DMSeq,int DMCategoryID,String DMCode,int HasDF,String FailureMode)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO[dbo].[DM_ITEMS]" +
                            "([DMItemID]" +
                            ",[DMDescription]" +
                            ",[DMSeq]" +
                            ",[DMCategoryID]" +
                            ",[DMCode]" +
                            ",[HasDF]" +
                            ",[FailureMode])" +
                            "VALUES" +
                            "('" + DMItemID + "'" +
                            ",'" + DMDescription + "'" +
                            ",'" + DMSeq + "'" +
                            ",'" + DMCategoryID + "'" +
                            ",'" + DMCode + "'" +
                            ",'" + HasDF + "'" +
                            ",'" + FailureMode + "')";
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
        public void edit(int DMItemID,String DMDescription,int DMSeq,int DMCategoryID,String DMCode,int HasDF,String FailureMode)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           " UPDATE[dbo].[DM_ITEMS]" +
                                  "SET[DMItemID] ='"+DMItemID+"'" +
                                  ",[DMDescription] = '"+DMDescription+"'" +
                                  ",[DMSeq] = '"+DMSeq+"'" +
                                  ",[DMCategoryID] = '"+DMCategoryID+"'" +
                                  ",[DMCode] = '"+DMCode+"'" +
                                  ",[HasDF] = '"+HasDF+"'" +
                                  "WHERE [DMItemID] ='" + DMItemID + "'";
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
        public void delete(int DMItemID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[DM_ITEMS] where [DMItemID]='" + DMItemID + "'";
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
        public List<DM_ITEMS> getDataSource()
        {
            List<DM_ITEMS> list = new List<DM_ITEMS>();
            DM_ITEMS obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = " Use [rbi] Select [DMItemID]"+
                          ",[DMDescription]"+
                          ",[DMSeq]"+
                          ",[DMCategoryID]"+
                          ",[DMCode]"+
                          ",[HasDF]"+
                          ",[FailureMode]"+
                          "From [rbi].[dbo].[DM_ITEMS]";
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
                            obj = new DM_ITEMS();
                            obj.DMItemID = reader.GetInt32(0);
                            obj.DMDescription = reader.GetString(1);
                            obj.DMSeq = reader.GetInt32(2);
                            obj.DMCategoryID = reader.GetInt32(3);
                            obj.DMCode = reader.GetString(4);
                            obj.HasDF = reader.GetInt32(5);
                            obj.FailureMode = reader.GetString(6);
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
