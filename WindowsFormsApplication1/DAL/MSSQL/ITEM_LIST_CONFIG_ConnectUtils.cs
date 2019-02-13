using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL;
using RBI.Object;
namespace RBI.DAL.MSSQL
{
    class ITEM_LIST_CONFIG_ConnectUtils
    {
        public void add(String UserID, String TreeNode, int NodeSeq, int ParentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "INSERT INTO [dbo].[ITEM_LIST_CONFIG]" +
                        "([UserID]" +
                        ",[TreeNode]" +
                        ",[NodeSeq]" +
                        ",[ParentID])" +
                        "VALUES" +
                        "('" + UserID + "'" +
                        ",'" + TreeNode + "'" +
                        ",'" + NodeSeq + "'" +
                        ",'" + ParentID + "')";

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
        public void edit(int ItemListConfigID, String UserID, String TreeNode, int NodeSeq, int ParentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "UPDATE [dbo].[ITEM_LIST_CONFIG]" +
                        "SET [UserID] = '" + UserID + "'" +
                        ",[TreeNode] = '" + TreeNode + "'" +
                        ",[NodeSeq] = '" + NodeSeq + "'" +
                        ",[ParentID] = '" + ParentID + "'" +
                        
                        "WHERE [ItemListConfigID] = '" + ItemListConfigID + "' ";

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
        public void delete(int ItemListConfigID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "DELETE FROM [dbo].[ITEM_LIST_CONFIG]" +
                        "WHERE [ItemListConfigID] = '" + ItemListConfigID + "' " +
                        " ";
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
        public List<ITEM_LIST_CONFIG> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<ITEM_LIST_CONFIG> list = new List<ITEM_LIST_CONFIG>();
            ITEM_LIST_CONFIG obj = null;
            String sql = " Use [rbi] Select [ItemListConfigID]" +
                          ",[UserID]" +
                          ",[TreeNode]" +
                          ",[NodeSeq]" +
                          ",[ParentID]" +
                          "From [dbo].[ITEM_LIST_CONFIG]  ";
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
                            obj = new ITEM_LIST_CONFIG();
                            obj.ItemListConfigID = reader.GetInt32(0);
                            obj.UserID = reader.GetString(1);
                            obj.TreeNode = reader.GetString(2);
                            obj.NodeSeq = reader.GetInt32(3);

                           
                            if (!reader.IsDBNull(4))
                            {
                                obj.ParentID = reader.GetInt32(4);
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
