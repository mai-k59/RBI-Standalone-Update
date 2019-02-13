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
    class FILE_COMPONENT_ConnectUtils
    {
        public void add (int ComponentID,String FileDocName,int FileType,String FileDescription,String OriFileName,byte FileBinary,
                        String FileSize,String FileExt,DateTime DateUploaded)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "INSERT INTO [dbo].[FILE_COMPONENT]" +
                            "([ComponentID]" +
                            ",[FileDocName]" +
                            ",[FileType]" +
                            ",[FileDescription]" +
                            ",[OriFileName]" +
                            ",[FileBinary]" +
                            ",[FileSize]" +
                            ",[FileExt]" +
                            ",[DateUploaded])" +
                            "VALUES" +
                            "('" + ComponentID + "'" +
                            ",'" + FileDocName + "'" +
                            ",'" + FileType + "'" +
                            ",'" + FileDescription + "'" +
                            ",'" + OriFileName + "'" +
                            ",'" + FileBinary + "'" +
                            ",'" + FileSize + "'" +
                            ",'" + FileExt + "'" +
                            ",'" + DateUploaded + "')";
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
        public void edit(int FileID,int ComponentID,String FileDocName,int FileType,String FileDescription,String OriFileName,byte FileBinary,
                        String FileSize,String FileExt,DateTime DateUploaded)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "UPDATE [dbo].[FILE_COMPONENT]" +
                            "   SET [FileID] = '" + FileID + "'" +
                            "      ,[ComponentID] = '" + ComponentID + "'" +
                            "      ,[FileDocName] = '" + FileDocName + "'" +
                            "      ,[FileType] = '" + FileType + "'" +
                            "      ,[FileDescription] = '" + FileDescription + "'" +
                            "      ,[OriFileName] = '" + OriFileName + "'" +
                            "      ,[FileBinary] = '" + FileBinary + "'" +
                            "      ,[FileSize] = '" + FileSize + "'" +
                            "      ,[FileExt] = '" + FileExt+ "'" +
                            "      ,[DateUploaded] = '" + DateUploaded + "'" +
                            " WHERE [FileID] = '" + FileID + "'";
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
        public void delete(int FileID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[FILE_COMPONENT] WHERE [FileID] = '" + FileID + "'";
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
        public List<FILE_COMPONENT> getDataSource()
        {
            List<FILE_COMPONENT> list = new List<FILE_COMPONENT>();
            FILE_COMPONENT obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [FileID]" +
                        ",[ComponentID]" +
                        ",[FileDocName]" +
                        ",[FileType]" +
                        ",[FileDescription]" +
                        ",[OriFileName]" +
                        ",[FileBinary]" +
                        ",[FileSize]" +
                        ",[FileExt]" +
                        ",[DateUploaded]" +
                        "  FROM [rbi].[dbo].[FILE_COMPONENT]";
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
                            obj = new FILE_COMPONENT();
                            obj.FileID = reader.GetInt32(0);
                            obj.ComponentID = reader.GetInt32(1);
                            obj.FileDocName = reader.GetString(2);
                            obj.FileType = reader.GetInt32(3);
                            if (!reader.IsDBNull(4)) { obj.FileDescription = reader.GetString(4); }
                            obj.OriFileName = reader.GetString(5);
                            obj.FileBinary = (byte[])reader[6];
                            obj.FileSize = reader.GetString(7);
                            obj.FileExt = reader.GetString(8);
                            obj.DateUploaded = reader.GetDateTime(9);
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA SOURCE FAIL!");
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
