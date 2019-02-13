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
    class IM_TYPE_ConnectUtils
    {
        public void add(int IMTypeID, String IMTypeName, String IMTypeCode,int IMItemID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "INSERT INTO [dbo].[IM_TYPE]" +
                        "([IMTypeID]" +
                        ",[IMTypeName]" +
                        ",[IMTypeCode]" +
                        ",[IMItemID])" +
                        "VALUES" +
                        "('" + IMTypeID + "'" +
                        ",'" + IMTypeName + "'" +
                        ",'" + IMTypeCode + "'" +
                        ",'" + IMItemID + "')";
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
        public void edit(int IMTypeID, String IMTypeName, String IMTypeCode, int IMItemID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "UPDATE [dbo].[IM_TYPE]" +
                        "SET [IMTypeID] = '" + IMTypeID + "'" +
                        ",[IMTypeName] = '" + IMTypeName + "'" +
                        ",[IMTypeCode] = '" + IMTypeCode + "'" +
                        ",[IMItemID] = '" + IMItemID + "'" +
                        " WHERE [IMTypeID] = '" + IMTypeID + "'";
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
        public void delete(int IMTypeID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "DELETE FROM [dbo].[IM_TYPE]" +
                        " WHERE [IMTypeID] = '" + IMTypeID + "'";
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
        public List<IM_TYPE> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<IM_TYPE> list = new List<IM_TYPE>();
            IM_TYPE obj = null;
            String sql = " Use [rbi] Select [IMTypeID]" +
                          ",[IMTypeName]" +
                          ",[IMTypeCode]" +
                          ",[IMItemID]" +
                          "From [dbo].[IM_ITEMS]";
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
                            obj = new IM_TYPE();
                            obj.IMTypeID = reader.GetInt32(0);
                            obj.IMTypeName = reader.GetString(1);
                            obj.IMTypeCode = reader.GetString(2);
                            obj.IMItemID = reader.GetInt32(3);
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

