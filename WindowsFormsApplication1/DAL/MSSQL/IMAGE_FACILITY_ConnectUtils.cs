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
    class IMAGE_FACILITY_ConnectUtils
    {
        public void add(int FacilityID, String ImageName, String ImageDescription, byte[] ImageBinary, byte[] ImageBinarySmall)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "INSERT INTO [dbo].[IMAGE_FACILITY]" +
                        "([FacilityID]" +
                        ",[ImageName]" +
                        ",[ImageDescription]" +
                        ",[ImageBinary]" +
                        ",[ImageBinarySmall])" +
                        "VALUES" +
                        "('" + FacilityID + "'" +
                        ",'" + ImageName + "'" +
                        ",'" + ImageDescription + "'" +
                        ",'" + ImageBinary + "'" +
                        ",'" + ImageBinarySmall + "')";
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
        public void edit(int ImageID, int FacilityID, String ImageName, String ImageDescription, byte[] ImageBinary, byte[] ImageBinarySmall)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "UPDATE [dbo].[IMAGE_FACILITY]" +
                        "SET [FacilityID] = '" + FacilityID + "'" +
                        ",[ImageName] = '" + ImageName + "'" +
                        ",[ImageDescription] = '" + ImageDescription + "'" +
                        ",[ImageBinary] = '" + ImageBinary + "'" +
                        ",[ImageBinarySmall] = '" + ImageBinarySmall + "'" +                       
                        "WHERE [ImageID] = '" + ImageID + "'";

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
        public void delete(int ImageID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "DELETE FROM [dbo].[IMAGE_FACILITY]" +
                        "WHERE [ImageID] = '" + ImageID + "'";
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

        public List<IMAGE_FACILITY> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<IMAGE_FACILITY> list = new List<IMAGE_FACILITY>();
            IMAGE_FACILITY obj = null;
            String sql = " Use [rbi] Select [ImageID]" +
                          ",[FacilityID]" +
                          ",[ImageName]" +
                          ",[ImageDescription]" +
                          ",[ImageBinary]" +
                          ",[ImageBinarySmall]" +
                          "From [dbo].[IMAGE_FACILITY]";
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
                            obj = new IMAGE_FACILITY();
                            obj.ImageID = reader.GetInt32(0);
                            obj.FacilityID = reader.GetInt32(1);
                            obj.ImageName = reader.GetString(2);
                            if (!reader.IsDBNull(3))
                            {
                                obj.ImageDescription = reader.GetString(3);
                            }
                            obj.ImageBinary = (byte[])reader[4];   
                            obj.ImageBinarySmall = (byte[])reader[5];    
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
