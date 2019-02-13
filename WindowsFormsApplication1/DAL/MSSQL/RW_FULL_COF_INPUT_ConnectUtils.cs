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
    class RW_FULL_COF_INPUT_ConnectUtils
    {
        public void add(int ID, String Mitigation, String DetectionType, String IsolationType, double mass_comp, double mass_inv)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[RW_FULL_COF_INPUT]" +
                        "([ID]" +
                        ",[Mitigation]" +
                        ",[DetectionType]" +
                        ",[IsolationType]" +
                        ",[mass_comp]" +
                        ",[mass_inv])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + Mitigation + "'" +
                        ",'" + DetectionType + "'" +
                        ",'" + IsolationType + "'" +
                        ",'" + mass_comp + "'" +
                        ",'" + mass_inv + "')" +
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
                MessageBox.Show(e.ToString(), "ADD FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int ID, String Mitigation, String DetectionType, String IsolationType, double mass_comp, double mass_inv)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_FULL_COF_INPUT]" +
                        "SET [ID] = '" + ID + "'" +
                        ",[Mitigation] = '" + Mitigation + "'" +
                        ",[DetectionType] = '" + DetectionType + "'" +
                        ",[IsolationType] = '" + IsolationType + "'" +
                        ",[mass_comp] = '" + mass_comp + "'" +
                        ",[mass_inv] = '" + mass_inv + "'" +
                       
                        " WHERE [ID] = '" + ID + "'" +
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
                MessageBox.Show(e.ToString(), "EDIT FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void delete(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "DELETE FROM [dbo].[RW_FULL_COF_INPUT]" +
                        " WHERE [ID] ='" + ID + "'" +
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
        ///get datasource
        ///
        public List<RW_FULL_COF_INPUT> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_FULL_COF_INPUT> list = new List<RW_FULL_COF_INPUT>();
            RW_FULL_COF_INPUT obj = null;
            String sql = " Use[rbi] Select[ID]" +
                        ",[Mitigation]" +
                        ",[DetectionType]" +
                        ",[IsolationType]" +
                        ",[mass_comp]" +
                        ",[mass_inv]" +
                          "From [dbo].[RW_FULL_COF_INPUT]  ";
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
                            obj = new RW_FULL_COF_INPUT();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.Mitigation = reader.GetString(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.DetectionType = reader.GetString(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.IsolationType = reader.GetString(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.mass_comp = reader.GetFloat(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.mass_inv = reader.GetFloat(5);
                            }
                            list.Add(obj);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL");
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
