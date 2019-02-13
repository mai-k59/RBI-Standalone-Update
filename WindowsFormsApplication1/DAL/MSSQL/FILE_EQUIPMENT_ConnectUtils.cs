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
    class FILE_EQUIPMENT_ConnectUtils
    {
        public void add(int EquipmentID, String FileDocName, int FileType, String FileDescription, String OriFileName, byte[] FileBinary,
                        String FileSize, String FileExt, DateTime DateUploaded)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "INSERT INTO [dbo].[FILE_EQUIPMENT]" +
                            "([EquipmentID]" +
                            ",[FileDocName]" +
                            ",[FileType]" +
                            ",[FileDescription]" +
                            ",[OriFileName]" +
                            ",[FileBinary]" +
                            ",[FileSize]" +
                            ",[FileExt]" +
                            ",[DateUploaded])" +
                            "VALUES" +
                            "('" + EquipmentID + "'" +
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
        public void edit(int FileID, int EquipmentID, String FileDocName, int FileType, String FileDescription, String OriFileName, byte FileBinary,
                        String FileSize, String FileExt, DateTime DateUploaded)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "UPDATE [dbo].[FILE_EQUIPMENT]" +
                            "   SET [FileID] = '" + FileID + "'" +
                            "      ,[EquipmentID] = '" + EquipmentID + "'" +
                            "      ,[FileDocName] = '" + FileDocName + "'" +
                            "      ,[FileType] = '" + FileType + "'" +
                            "      ,[FileDescription] = '" + FileDescription + "'" +
                            "      ,[OriFileName] = '" + OriFileName + "'" +
                            "      ,[FileBinary] = '" + FileBinary + "'" +
                            "      ,[FileSize] = '" + FileSize + "'" +
                            "      ,[FileExt] = '" + FileExt + "'" +
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
            String sql = "USE [rbi] DELETE FROM [dbo].[FILE_EQUIPMENT] WHERE [FileID] = '" + FileID + "'";
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
        public List<FILE_EQUIPMENT> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<FILE_EQUIPMENT> list = new List<FILE_EQUIPMENT>();
            FILE_EQUIPMENT obj = null;
            String sql = " Use [rbi] Select [FileID]" +
                          ",[EquipmentID]" +
                          ",[FileDocName]" +
                          ",[FileType]" +
                          ",[FileDescription]" +
                          ",[OriFileName]" +
                          ",[FileBinary]" +
                          ",[FileSize]" +
                          ",[FileExt]" +
                          ",[DateUploaded]" +
                          "From [dbo].[FILE_EQUIPMENT]";
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
                            obj = new FILE_EQUIPMENT();
                            obj.FileID = reader.GetInt32(0);
                            obj.EquipmentID = reader.GetInt32(1);
                            obj.FileDocName = reader.GetString(2);
                            obj.FileType = reader.GetInt32(3);
                            if (!reader.IsDBNull(4))
                            {
                                obj.FileDescription = reader.GetString(4);
                            }
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
