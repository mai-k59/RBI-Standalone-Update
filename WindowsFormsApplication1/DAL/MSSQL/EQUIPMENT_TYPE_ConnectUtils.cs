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
    class EQUIPMENT_TYPE_ConnectUtils
    {
        public void add(int EquipmentTypeID,String EquipmentTypeCode, String EquipmentTypeName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO[dbo].[EQUIPMENT_TYPE]" +
                            "([EquipmentTypeID]" +
                            ",[EquipmentTypeCode]" +
                            ",[EquipmentTypeName])" +
                            "VALUES" +
                            "('" + EquipmentTypeID + "'" +
                            ",'" + EquipmentTypeCode + "'" +
                            ",'" + EquipmentTypeName + "')";
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
        public void edit(int EquipmentTypeID,String EquipmentTypeCode, String EquipmentTypeName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           " UPDATE[dbo].[EQUIPMENT_TYPER]" +
                                  "SET[EquipmentTypeID] ='"+EquipmentTypeID+"'" +
                                  ",[EquipmentTypeCode] = '"+EquipmentTypeCode+"'" +
                                  ",[EquipmentTypeName] = '"+EquipmentTypeName+"'" +
                                  "WHERE [EquipmentTypeID] ='" + EquipmentTypeID + "'";
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
        public void delete(int EquipmentTypeID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[EQUIPMENT_TYPE] where [EquipmentTypeID]='" + EquipmentTypeID + "'";
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
        public List<EQUIPMENT_TYPE> getDataSource()
        {
            List<EQUIPMENT_TYPE> list = new List<EQUIPMENT_TYPE>();
            EQUIPMENT_TYPE obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [EquipmentTypeID]" +
                        ",[EquipmentTypeCode]" +
                        ",[EquipmentTypeName]" +
                        "FROM [rbi].[dbo].[EQUIPMENT_TYPE]";
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
                            obj = new EQUIPMENT_TYPE();
                            obj.EquipmentTypeID = reader.GetInt32(0);
                            obj.EquipmentTypeCode = reader.GetString(1);
                            obj.EquipmentTypeName = reader.GetString(2);
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
        public EQUIPMENT_TYPE getData(String EquipmentTypeCode)
        {
            EQUIPMENT_TYPE obj = new EQUIPMENT_TYPE();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [EquipmentTypeID]" +
                        ",[EquipmentTypeCode]" +
                        ",[EquipmentTypeName]" +
                        "FROM [rbi].[dbo].[EQUIPMENT_TYPE] WHERE [EquipmentTypeCode] ='"+ EquipmentTypeCode + "'";
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
                            obj.EquipmentTypeID = reader.GetInt32(0);
                            obj.EquipmentTypeCode = reader.GetString(1);
                            obj.EquipmentTypeName = reader.GetString(2);
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
            return obj;
        }
        public String getEquipmentTypeName(int equipmentID)
        {
            String equipmentTypeName = "";
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT [EquipmentTypeName] FROM [rbi].[dbo].[EQUIPMENT_TYPE] WHERE EquipmentTypeID = '" + equipmentID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            equipmentTypeName = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get Equipment Type Name Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return equipmentTypeName;
        }
        public int getIDbyName(String EquipmentTypeName)
        {
            int ID = 0;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "SELECT [EquipmentTypeID]" +
                        ",[EquipmentTypeCode]" +
                        ",[EquipmentTypeName]" +
                        "FROM [rbi].[dbo].[EQUIPMENT_TYPE] WHERE [EquipmentTypeName] ='" + EquipmentTypeName + "'";
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
                            ID = reader.GetInt32(0);
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
            return ID;
        }
        public List<string> getListEquipmentTypeName()
        {
            List<string> name = new List<string>();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            string sql = "select EquipmentTypeName from rbi.dbo.EQUIPMENT_TYPE";
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
                            name.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("get data error " + ex.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return name;
        }
    }
}
