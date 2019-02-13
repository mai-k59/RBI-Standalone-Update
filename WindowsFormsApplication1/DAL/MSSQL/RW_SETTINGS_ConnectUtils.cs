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
    class RW_SETTINGS_ConnectUtils
    {
        public void add(int ID, int DefaultAssessmentMethod, String SchemaVersion,String UnlockCode, String CompanyName)
                        
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[RW_SETTINGS]" +
                           "([ID]" +
                           ",[DefaultAssessmentMethod]" +
                           ",[SchemaVersion]" +
                           ",[UnlockCode]" +
                            ",[CompanyName])" +
                           " VALUES" +
                           "(  '" + ID + "'" +
                            ", '" + DefaultAssessmentMethod + "'" +
                            ",'" + SchemaVersion + "'" +
                            "," + UnlockCode + "" +
                             ", '" + CompanyName + "')";
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
        public void edit(int ID, int DefaultAssessmentMethod, String SchemaVersion, String UnlockCode, String CompanyName)
                        
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[RW_SETTINGS] " +
                              "SET[ID] = '" + ID + "'" +
                              ",[DefaultAssessmentMethod] = '" + DefaultAssessmentMethod + "'" +
                              ",[SchemaVersion] = '" + SchemaVersion + "'" +
                              ",[UnlockCode] = '" + UnlockCode + "'" +
                              ",[CompanyName] = '" + CompanyName + "'" +
                              " WHERE [ID] = '" + ID + "'";
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

        public void delete(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_SETTINGS] WHERE [ID] = '" + ID + "'";
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
        public List<RW_SETTINGS> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_SETTINGS> list = new List<RW_SETTINGS>();
            RW_SETTINGS obj = null;
            String sql = "USE [rbi]" +
                        "" +
                        "SELECT [ID]" +
                        ",[DefaultAssessmentMethod]" +
                        ",[SchemaVersion]" +
                        ",[UnlockCode]" +
                        ",[CompanyName]" +
                        "  FROM [rbi].[dbo].[RW_SETTINGS]" +
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
                            obj = new RW_SETTINGS();
                            obj.ID = reader.GetInt32(0);
                            obj.DefaultAssessmentMethod = reader.GetInt32(1);
                            if (!reader.IsDBNull(2))
                            {
                                obj.SchemaVersion = reader.GetString(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.UnlockCode = reader.GetString(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.CompanyName = reader.GetString(4);
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
