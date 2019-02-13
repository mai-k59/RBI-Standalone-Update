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
    class REPORT_TEMPLATE_COMPONENT_DEFAULT_ConnectUtilscs
    {
        public void add(int EquipmentID, int TemplateID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[REPORT_TEMPLATE_COMPONENT_DEFAULT]" +
                        "([EquipmentID]" +
                        ",[TemplateID])" +
                        "VALUES" +
                        "('" + EquipmentID + "'" +
                        ",'" + TemplateID + "')" +
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
        public void edit(int EquipmentID, int TemplateID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[REPORT_TEMPLATE_COMPONENT_DEFAULT]" +
                        "SET [EquipmentID] = '" + EquipmentID + "'" +
                        ",[TemplateID] = '" + TemplateID + "'" +
                        "WHERE [EquipmentID] = '" + EquipmentID + "'" +
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
        public void delete(int EquipmentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "DELETE FROM [dbo].[REPORT_TEMPLATE_COMPONENT_DEFAULT]" +
                        "WHERE [EquipmentID]  = '" + EquipmentID + "' " +
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
        public List<REPORT_TEMPLATE_COMPONENT_DEFAULT> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<REPORT_TEMPLATE_COMPONENT_DEFAULT> list = new List<REPORT_TEMPLATE_COMPONENT_DEFAULT>();
            REPORT_TEMPLATE_COMPONENT_DEFAULT obj = null;
            String sql = " Use [rbi] Select [EquipmentID]" +
                          ",[TemplateID]" +


                          "From [dbo].[REPORT_TEMPLATE_COMPONENT_DEFAULT]  ";
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
                            obj = new REPORT_TEMPLATE_COMPONENT_DEFAULT();
                            obj.EquipmentID = reader.GetInt32(0);
                            obj.TemplateID = reader.GetInt32(1);

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

