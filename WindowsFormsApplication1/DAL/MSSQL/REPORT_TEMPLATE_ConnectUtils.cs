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
    class REPORT_TEMPLATE_ConnectUtils
    {
        public void add(String TemplateName, String TemplateDescription,String OriginalFile, String ReportIdentifier, String ReportID, String ReportType, String ReportVersion,int Predefined, byte[] TemplateBinary)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[REPORT_TEMPLATE]" +
                        "([TemplateName]" +
                        ",[TemplateDescription]" +
                        ",[OriginalFile]" +
                        ",[ReportIdentifier]" +
                        ",[ReportID]" +
                        ",[ReportType]" +
                        ",[ReportVersion]" +
                        ",[Predefined]" +
                        ",[TemplateBinary])" +
                        "VALUES" +
                        "('" + TemplateName + "'" +
                        ",'" + TemplateDescription + "'" +
                        ",'" + OriginalFile + "'" +
                        ",'" + ReportIdentifier + "'" +
                        ",'" + ReportID + "'" +
                        ",'" + ReportType + "'" +
                        ",'" + ReportVersion + "'" +
                        ",'" + Predefined + "'" +
                        ",'" + TemplateBinary + "')" +
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
        public void edit(int TemplateID, String TemplateName, String TemplateDescription, String OriginalFile, String ReportIdentifier, String ReportID, String ReportType, String ReportVersion, int Predefined, byte[] TemplateBinary)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[REPORT_TEMPLATE]" +
                        "SET [TemplateName] = '" + TemplateName + "'" +
                        ",[TemplateDescription] = '" + TemplateDescription + "'" +
                        ",[OriginalFile] = '" + OriginalFile + "'" +
                        ",[ReportIdentifier] = '" + ReportIdentifier + "'" +
                        ",[ReportID] = '" + ReportID + "'" +
                        ",[ReportType] = '" + ReportType + "'" +
                        ",[ReportVersion] = '" + ReportVersion + "'" +
                        ",[Predefined] = '" + Predefined + "'" +
                        ",[TemplateBinary] = '" + TemplateBinary + "'" +
                        
                        "WHERE [TemplateID] = '" + TemplateID + "'" +
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
        public void delete(int TemplateID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "DELETE FROM [dbo].[REPORT_TEMPLATE]" +
                        "WHERE [TemplateID]  = '" + TemplateID + "' " +
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
        public List<REPORT_TEMPLATE> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<REPORT_TEMPLATE> list = new List<REPORT_TEMPLATE>();
            REPORT_TEMPLATE obj = null;
            String sql = " Use [rbi] Select [TemplateID]" +
                          ",[TemplateName]" +
                          ",[TemplateDescription]" +
                          ",[OriginalFile]" +
                          ",[ReportIdentifier]" +
                          ",[ReportID]" +
                          ",[ReportType]" +
                          ",[ReportVersion]" +
                          ",[Predefined]" +
                          ",[TemplateBinary]" +


                          "From [dbo].[REPORT_TEMPLATE]  ";
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
                            obj = new REPORT_TEMPLATE();
                            obj.TemplateID = reader.GetInt32(0);
                            obj.TemplateName = reader.GetString(1);
                            if (!reader.IsDBNull(2))
                            {
                                obj.TemplateDescription = reader.GetString(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.OriginalFile = reader.GetString(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.ReportIdentifier = reader.GetString(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.ReportID = reader.GetString(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.ReportType = reader.GetString(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.ReportVersion = reader.GetString(7);
                            }

                            obj.Predefined = reader.GetInt32(8);
                            if (!reader.IsDBNull(9))
                            {
                                obj.TemplateBinary = (byte[])reader[9];
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

