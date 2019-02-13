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
    class IM_ITEMS_ConnectUtils
    {
        public void add(int IMItemID, String IMDescription, String IMCode)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "INSERT INTO [dbo].[IM_ITEMS]" +
                        "([IMItemID]" +
                        ",[IMDescription]" +
                        ",[IMCode])" +
                        "VALUES" +
                        "('"+IMItemID+"'" +
                        ",'"+IMDescription+"'" +
                        ",'"+IMCode+"')";
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
        public void edit(int IMItemID, String IMDescription, String IMCode)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "UPDATE [dbo].[IM_ITEMS]" +
                        "SET [IMItemID] = '" + IMItemID + "'" +
                        ",[IMDescription] = '" + IMDescription + "'" +
                        ",[IMCode] = '" + IMCode + "'" +
                        " WHERE [IMItemID] = '" + IMItemID + "'";

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
        public void delete(int IMItemID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "DELETE FROM [dbo].[IM_ITEMS]" +
                        " WHERE [IMItemID] = '" + IMItemID + "'";
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
        public List<IM_ITEMS> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<IM_ITEMS> list = new List<IM_ITEMS>();
            IM_ITEMS obj = null;
            String sql = " Use [rbi] Select [IMItemID]" +
                          ",[IMDescription]" +
                          ",[IMCode]" +                       
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
                            obj = new IM_ITEMS();
                            obj.IMItemID = reader.GetInt32(0);
                            obj.IMDescription = reader.GetString(1);
                            obj.IMCode = reader.GetString(2);

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

