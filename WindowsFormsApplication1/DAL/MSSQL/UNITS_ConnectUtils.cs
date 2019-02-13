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
    class UNITS_ConnectUtils
    {
        public void add(int UnitID, String UnitName, String SelectedUnit)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[USER_GROUPS]" +
                           "([UnitID]" +
                           ",[UnitName]" +
                           ",[SelectedUnit])" +
                           " VALUES" +
                           "(  '" + UnitID + "'" +
                            ", '" + UnitName + "'" +
                           ", '" + SelectedUnit + "')";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
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
        public void edit(int UnitID, String UnitName, String SelectedUnit)
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[USER_GROUPS] " +
                              "SET[UnitID] = '" + UnitID + "'" +
                              ",[UnitName] = '" + UnitName + "'" +
                              ",[SelectedUnit] = '" + SelectedUnit + "'" +
                              " WHERE [UnitID] = '" + UnitID + "'";
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
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
        }

        public void edit(String UnitName, String SelectedUnit)
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[UNITS] " +
                              "SET " +
                              "[SelectedUnit] = '" + SelectedUnit + "'" +
                              " WHERE [UnitName] = '" + UnitName + "'";
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "EDIT FAIL!");
                }
                finally
                {
                    conn.Close();

                }
            }
        }
        public void delete(int UnitID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[USER_GROUPS] WHERE [UnitID] = '" + UnitID + "'";
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

        // dung file get data
        // dung file get list( data source)
        public List<UNITS> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<UNITS> list = new List<UNITS>();
            UNITS obj = null;
            String sql = "Use [rbi] " +
                        "SELECT [UnitID]" +
                        ",[UnitName]" +
                        ",[SelectedUnit]" +
                        "  FROM [rbi].[dbo].[UNITS]" +
                        " ";
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
                            obj = new UNITS();
                            obj.UnitID = reader.GetInt32(0);
                            obj.UnitName = reader.GetString(1);
                            obj.SelectedUnit = reader.GetString(2);
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
