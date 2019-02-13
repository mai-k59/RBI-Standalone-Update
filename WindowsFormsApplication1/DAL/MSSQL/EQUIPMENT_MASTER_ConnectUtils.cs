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
    class EQUIPMENT_MASTER_ConnectUtils
    {
        public int getIDbyNumber(String number)
        {
            int check = 0;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = " Use [rbi] Select [EquipmentID]" +
                          ",[EquipmentNumber]" +
                          "From [rbi].[dbo].[EQUIPMENT_MASTER] WHERE [EquipmentNumber] = '" + number + "'";
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
                            check = reader.GetInt32(0);
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
            return check;
        }
        public List<int> getAlleqIDbyFaciID(int faciID)
        {
            List<int> list = new List<int>();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select EquipmentID from rbi.dbo.EQUIPMENT_MASTER where FacilityID = '" + faciID + "'";
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
                            list.Add(reader.GetInt32(0));
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
        public void add(String EquipmentNumber,int EquipmentTypeID,String EquipmentName,DateTime CommissionDate,int DesignCodeID,int SiteID,int FacilityID,int ManufacturerID,String PFDNo,String ProcessDescription,string EquipmentDesc,int IsArchived,DateTime Archived,String ArchivedBy)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO[dbo].[EQUIPMENT_MASTER]" +
                            "([EquipmentNumber]" +
                            ",[EquipmentTypeID]" +
                            ",[EquipmentName]" +
                            ",[CommissionDate]" +
                            ",[DesignCodeID]" +
                            ",[SiteID]" +
                            ",[FacilityID]" +
                            ",[ManufacturerID]" +
                            ",[PFDNo]" +
                            ",[ProcessDescription]" +
                            ",[EquipmentDesc]" +
                            ",[IsArchived]" +
                            ",[Archived]" +
                            ",[ArchivedBy])" +
                            "VALUES" +
                            "('" + EquipmentNumber + "'" +
                            ",'" + EquipmentTypeID + "'" +
                            ",'" + EquipmentName + "'" +
                            ",'" + CommissionDate + "'" +
                            ",'" + DesignCodeID + "'" +
                            ",'" + SiteID + "'" +
                            ",'" + FacilityID + "'" +
                            ",'" + ManufacturerID + "'" +
                            ",'" + PFDNo + "'" +
                            ",'" + ProcessDescription + "'" +
                            ",'" + EquipmentDesc + "'" +
                            ",'" + IsArchived + "'" +
                            ",'" + Archived + "'" +
                            ",'" + ArchivedBy + "')";
                           
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
        public void edit(int EquipmentID,String EquipmentNumber,int EquipmentTypeID,String EquipmentName,DateTime CommissionDate,int DesignCodeID,int SiteID,int FacilityID,int ManufacturerID,String PFDNo,String ProcessDescription,string EquipmentDesc,int IsArchived,DateTime Archived,String ArchivedBy)
            {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           " UPDATE[dbo].[EQUIPMENT_MASTER]" +
                                  "SET [EquipmentNumber] = '"+EquipmentNumber+"'" +
                                  ",[EquipmentTypeID] = '"+EquipmentTypeID+"'" +
                                  ",[EquipmentName] = '"+EquipmentName+"'" +
                                  ",[CommissionDate] = '"+CommissionDate +"'" +
                                  ",[DesignCodeID] = '"+DesignCodeID+"'" +
                                  ",[SiteID] = '"+SiteID+"'" +
                                  ",[FacilityID] = '"+FacilityID+"'" +
                                  ",[ManufacturerID] = '"+ManufacturerID+"'" +
                                  ",[PFDNo] = '"+PFDNo+"'" +
                                  ",[ProcessDescription] = '"+ProcessDescription+"'" +
                                  ",[EquipmentDesc] = '"+EquipmentDesc+"'" +
                                  ",[IsArchived] = '"+IsArchived+"'" +
                                  ",[Archived] = '"+Archived+"'" +
                                  ",[ArchivedBy] = '"+ArchivedBy+"'" +
                                 "WHERE [EquipmentID] ='" + EquipmentID + "'";
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
            String sql = "USE [rbi] DELETE FROM [dbo].[EQUIPMENT_MASTER] where [EquipmentID]='" + EquipmentID + "'";
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
        public List<EQUIPMENT_MASTER> getDataSource()
        {
            List<EQUIPMENT_MASTER> list = new List<EQUIPMENT_MASTER>();
            EQUIPMENT_MASTER obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = " Use [rbi] Select [EquipmentID]"+
                          ",[EquipmentNumber]" +
                          ",[EquipmentTypeID]" +
                          ",[EquipmentName]" +
                          ",[CommissionDate]" +
                          ",[DesignCodeID]" +
                          ",[SiteID]" +
                          ",[FacilityID]" +
                          ",[ManufacturerID]" +
                          ",[PFDNo]" +
                          ",[ProcessDescription]" +
                          ",[EquipmentDesc]" +
                          ",[IsArchived]" +
                          ",[Archived]" +
                          ",[ArchivedBy]" +
                          "From [rbi].[dbo].[EQUIPMENT_MASTER]";
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
                            obj = new EQUIPMENT_MASTER();
                            obj.EquipmentID = reader.GetInt32(0);
                            obj.EquipmentNumber = reader.GetString(1);
                            obj.EquipmentTypeID = reader.GetInt32(2);
                            obj.EquipmentName = reader.GetString(3);
                            obj.CommissionDate = reader.GetDateTime(4);
                            obj.DesignCodeID = reader.GetInt32(5);
                            obj.SiteID = reader.GetInt32(6);
                            obj.FacilityID = reader.GetInt32(7);
                            obj.ManufacturerID = reader.GetInt32(8);
                            if (!reader.IsDBNull(9))
                            {
                                obj.PFDNo = reader.GetString(9);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.ProcessDescription = reader.GetString(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.EquipmentDesc = reader.GetString(11);
                            }
                            obj.IsArchived = reader.GetOrdinal("IsArchived");
                            if (!reader.IsDBNull(13))
                            {
                                obj.Archived = reader.GetDateTime(13);
                            }
                            if (!reader.IsDBNull(14))
                            {
                                obj.ArchivedBy = reader.GetString(14);
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
        public int getSiteID(int eqID)
        {
            int SiteID = 0;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT SiteID FROM [rbi].[dbo].[EQUIPMENT_MASTER] WHERE EquipmentID = '"+eqID+"'";
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
                            SiteID = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get SiteID Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return SiteID;
        }
        public int getEquipmentTypeID(int EquipmentID)
        {
            int eqTypeID = 0;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT EquipmentTypeID FROM [rbi].[dbo].[EQUIPMENT_MASTER] WHERE EquipmentID = '"+EquipmentID+"'";
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
                            eqTypeID = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get SiteID Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return eqTypeID;
        }
        public int getEqTypeID(int EquipmentID)
        {
            int id = 0;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            string sql = "select EquipmentTypeID from rbi.dbo.EQUIPMENT_MASTER where EquipmentID ='" + EquipmentID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            id = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("get equipment Type error " + ex.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return id;
        }
        public int getEquipmentTypeID(int siteID, int facilityID)
        {
            int id = 0;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            string sql = "select EquipmentTypeID from rbi.dbo.EQUIPMENT_MASTER where SiteID='" + siteID + "' and FacilityID='" + facilityID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            id = reader.GetInt32(0);
                        } 
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("get equipment Type error " + ex.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return id;
        }
        public DateTime getCommissionDate(int eqID)
        {
            DateTime commisionDate = DateTime.Now;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "select CommissionDate from rbi.dbo.EQUIPMENT_MASTER where EquipmentID = '"+eqID+"'";
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
                            commisionDate = reader.GetDateTime(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get DateTime Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return commisionDate;
        }
        public String getEquipmentNumber(int eqID)
        {
            String eqNum = "";
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "select EquipmentNumber from rbi.dbo.EQUIPMENT_MASTER where EquipmentID = '"+eqID+"'";
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
                            eqNum = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get DateTime Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return eqNum;
        }
        public String getEquipmentDesc(int eqID)
        {
            String eqNum = "";
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "select EquipmentDesc from rbi.dbo.EQUIPMENT_MASTER where EquipmentID = '"+eqID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows && !reader.IsDBNull(0))
                        {
                                eqNum = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get DateTime Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return eqNum;
        }

        public EQUIPMENT_MASTER getData(int eqID)
        {
            EQUIPMENT_MASTER obj = new EQUIPMENT_MASTER();
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "select EquipmentNumber,EquipmentTypeID,EquipmentName,CommissionDate,DesignCodeID,SiteID,FacilityID,ManufacturerID,PFDNo,ProcessDescription,EquipmentDesc from rbi.dbo.EQUIPMENT_MASTER where EquipmentID = '" + eqID + "'";
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
                            obj.EquipmentNumber = reader.GetString(0);
                            obj.EquipmentTypeID = reader.GetInt32(1);
                            obj.EquipmentName = reader.GetString(2);
                            obj.CommissionDate = reader.GetDateTime(3);
                            obj.DesignCodeID = reader.GetInt32(4);
                            obj.SiteID = reader.GetInt32(5);
                            obj.FacilityID = reader.GetInt32(6);
                            obj.ManufacturerID = reader.GetInt32(7);
                            if(!reader.IsDBNull(8))
                            obj.PFDNo = reader.GetString(8);
                            if (!reader.IsDBNull(9))
                            obj.ProcessDescription = reader.GetString(9);
                            if (!reader.IsDBNull(10))
                            obj.EquipmentDesc = reader.GetString(10);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get DateTime Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return obj;
        }
        public Boolean checkExist(String equipmentNum)
        {
            Boolean check = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = " Use [rbi] Select [EquipmentID]" +
                          ",[EquipmentNumber]" +
                          ",[EquipmentTypeID]" +
                          ",[EquipmentName]" +
                          ",[CommissionDate]" +
                          ",[DesignCodeID]" +
                          ",[SiteID]" +
                          ",[FacilityID]" +
                          ",[ManufacturerID]" +
                          ",[PFDNo]" +
                          ",[ProcessDescription]" +
                          ",[EquipmentDesc]" +
                          ",[IsArchived]" +
                          ",[Archived]" +
                          ",[ArchivedBy]" +
                          "From [rbi].[dbo].[EQUIPMENT_MASTER] WHERE [EquipmentNumber] = '" + equipmentNum + "'";
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
                            check = true;
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
            return check;
        }
        public int getIDbyName(String name)
        {
            int check = 0;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = " Use [rbi] Select [EquipmentID]" +
                          ",[EquipmentNumber]" +
                          "From [rbi].[dbo].[EQUIPMENT_MASTER] WHERE [EquipmentNumber] = '" + name + "'";
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
                            check = reader.GetInt32(0);
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
            return check;
        }
        public int getFacilityID(int eqID)
        {
            int obj = 0;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "select FacilityID from rbi.dbo.EQUIPMENT_MASTER where EquipmentID = '" + eqID + "'";
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
                            obj = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get DateTime Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return obj;
        }
        public String getEquipmentName(int eqID)
        {
            String eqName = "";
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "select EquipmentName from rbi.dbo.EQUIPMENT_MASTER where EquipmentID = '" + eqID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows && !reader.IsDBNull(0))
                        {
                            eqName = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get DateTime Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return eqName;
        }
        public List<string> getListEquipmentNumber()
        {
            List<string> list = new List<string>();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select EquipmentNumber from rbi.dbo.EQUIPMENT_MASTER";
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
                            list.Add(reader.GetString(0));
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
        public List<int> GetAllAssessmentIDbyEquipmentID(int eqID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<int> lstAssID = new List<int>();
            String sql = "SELECT ID FROM rbi.dbo.RW_ASSESSMENT WHERE EquipmentID = '"+eqID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            lstAssID.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Get Data Fail");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return lstAssID;
        }
    }
}
