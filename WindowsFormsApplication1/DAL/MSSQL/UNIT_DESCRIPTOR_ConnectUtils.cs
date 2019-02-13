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
    class UNIT_DESCRIPTOR_ConnectUtils
    {
        public void add(int UnitDescriptorID, String UnitCode, String UnitDescriptor)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[UNIT_DESCRIPTOR]" +
                           "([UnitDescriptorID]" +
                           ",[UnitCode]" +
                           ",[UnitDescriptor])" +
                           " VALUES" +
                           "(  '" + UnitDescriptorID + "'" +
                            ", '" + UnitCode + "'" +
                           ", '" + UnitDescriptor + "')";
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
        public void edit(int UnitDescriptorID, String UnitCode, String UnitDescriptor)
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[UNIT_DESCRIPTOR] " +
                              "SET[UnitDescriptorID] = '" + UnitDescriptorID + "'" +
                              ",[UnitCode] = '" + UnitCode + "'" +
                              ",[UnitDescriptor] = '" + UnitDescriptor + "'" +
                              " WHERE [UnitDescriptorID] = '" + UnitDescriptorID + "'";
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

        public void delete(int UnitDescriptorID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[UNIT_DESCRIPTOR] WHERE [UnitDescriptorID] = '" + UnitDescriptorID + "'";
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
        public List<UNIT_DESCRIPTOR> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<UNIT_DESCRIPTOR> list = new List<UNIT_DESCRIPTOR>();
            UNIT_DESCRIPTOR obj = null;
            String sql = "Use [rbi] " +
                        "SELECT [UnitDescriptorID]" +
                        ",[UnitCode]" +
                        ",[UnitDescriptor]" +
                        "  FROM [rbi].[dbo].[UNIT_DESCRIPTOR]" +
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
                            obj = new UNIT_DESCRIPTOR();
                            obj.UnitDescriptorID = reader.GetInt32(0);
                            obj.UnitCode = reader.GetString(1);
                            obj.UnitDescriptor = reader.GetString(2);
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
