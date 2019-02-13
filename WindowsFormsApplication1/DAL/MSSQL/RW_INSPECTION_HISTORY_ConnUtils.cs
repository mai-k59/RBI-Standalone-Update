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
    class RW_INSPECTION_HISTORY_ConnUtils
    {
        public void add( String InspectionPlanName, String InspectionCoverageName, String EquipmentNumber, String ComponentNumber, String DM, String InspectionType, DateTime InspectionDate, String InspectionEffective)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "INSERT INTO [dbo].[RW_INSPECTION_HISTORY] " +
                        "([InspectionPlanName] " +
                        ",[InspectionCoverageName] " +
                        ",[EquipmentNumber] " +
                        ",[ComponentNumber] " +
                        ",[DM] " +
                        ",[InspectionType] " +
                        ",[InspectionDate] " +
                        ",[InspectionEffective]) " +
                        " VALUES " +
                        "('" + InspectionPlanName + "'" +
                        ",'" + InspectionCoverageName + "'" +
                        ",'" + EquipmentNumber + "'" +
                        ",'" + ComponentNumber + "'" +
                        ",'" + DM + "'" +
                        ",'" + InspectionType + "'" +
                        ",'" + InspectionDate + "'" +
                        ",'" + InspectionEffective + "') ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                // do nothing
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int ID, String InspectionPlanName, String InspectionCoverageName, String EquipmentNumber, String ComponentNumber, String DM, String InspectionType, DateTime InspectionDate, String InspectionEffective)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "UPDATE [dbo].[RW_INSPECTION_HISTORY]" +
                        "   SET [ID] = '" + ID + "'" +
                        ",[InspectionPlanName] = '" + InspectionPlanName + "'" +
                        ",[InspectionCoverageName] = '" + InspectionCoverageName + "'" +
                        ",[EquipmentNumber] = '" + EquipmentNumber + "'" +
                        ",[ComponentNumber] = '" + ComponentNumber + "'" +
                        ",[DM] = '" + DM + "'" +
                        ",[InspectionType] = '" + InspectionType + "'" +
                        ",[InspectionDate] = '" + InspectionDate + "'" +
                        ",[InspectionEffective] = '" + InspectionEffective + "'" +
                        " WHERE [ID] = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                // do nothing
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
            String sql = "USE [rbi] " +
                        "DELETE FROM [dbo].[RW_INSPECTION_HISTORY] WHERE [ID] = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                // do nothing
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public List<RW_INSPECTION_HISTORY> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_INSPECTION_HISTORY> list = new List<RW_INSPECTION_HISTORY>();
            RW_INSPECTION_HISTORY obj = null;
            String sql = "SELECT [ID]" +
                        ",[InspectionPlanName] " +
                        ",[InspectionCoverageName]" +
                        ",[EquipmentNumber]" +
                        ",[ComponentNumber]" +
                        ",[DM]" +
                        ",[InspectionType]" +
                        ",[InspectionDate]" +
                        ",[InspectionEffective]" +
                        "  FROM [rbi].[dbo].[RW_INSPECTION_HISTORY]";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_INSPECTION_HISTORY();
                            obj.ID = reader.GetInt32(0);
                            obj.InspectionPlanName = reader.GetString(1);
                            obj.InspectionCoverageName = reader.GetString(2);
                            obj.EquipmentNumber = reader.GetString(3);
                            obj.ComponentNumber = reader.GetString(4);
                            obj.DM = reader.GetString(5);
                            obj.InspectionType = reader.GetString(6);
                            obj.InspectionDate = reader.GetDateTime(7);
                            obj.InspectionEffective = reader.GetString(8);
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                // do nothing
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<RW_INSPECTION_HISTORY> getDataComp(String CompNum)
        {
            List<RW_INSPECTION_HISTORY> list = new List<RW_INSPECTION_HISTORY>();
            RW_INSPECTION_HISTORY obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "SELECT [ID]" +
                       ",[InspectionPlanName] " +
                       ",[InspectionCoverageName]" +
                       ",[EquipmentNumber]" +
                       ",[ComponentNumber]" +
                       ",[DM]" +
                       ",[InspectionType]" +
                       ",[InspectionDate]" +
                       ",[InspectionEffective]" +
                       "  FROM [rbi].[dbo].[RW_INSPECTION_HISTORY] WHERE [ComponentNumber] ='"+CompNum+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_INSPECTION_HISTORY();
                            obj.ID = reader.GetInt32(0);
                            obj.InspectionPlanName = reader.GetString(1);
                            obj.InspectionCoverageName = reader.GetString(2);
                            obj.EquipmentNumber = reader.GetString(3);
                            obj.ComponentNumber = reader.GetString(4);
                            obj.DM = reader.GetString(5);
                            obj.InspectionType = reader.GetString(6);
                            obj.InspectionDate = reader.GetDateTime(7);
                            obj.InspectionEffective = reader.GetString(8);
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                // do nothing
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        // check Inspection History da ton tai hay chua
        // dieu kien: compNum, DM, namTien hanh Insp phai la duy nhat: vd: comp =1, DM = Thinning, Date = 2017
        // neu trong nam 2017 co tien hanh bat ky lan Insp nao nua thi se chay lenh update cho insp cua nam do
        public Boolean checkExist(String compNum, String DM, DateTime InspDate)
        {
            Boolean exist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "SELECT * FROM [rbi].[dbo].[RW_INSPECTION_HISTORY] WHERE [ComponentNumber] ='" + compNum + "' AND [DM] ='" + DM + "' AND [InspectionDate] like '%" + InspDate.Year + "%'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            exist = true;
                        }
                    }
                }
            }
            catch
            {
                // do nothing
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return exist;
        }

        // lay ra lastInspDate 
        public DateTime getLastInspDate(String compNum, String DM, DateTime ComissionDate)
        {
            DateTime dt = ComissionDate;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT MAX([InspectionDate]) FROM [rbi].[dbo].[RW_INSPECTION_HISTORY] WHERE [ComponentNumber] = '" + compNum + "' and DM = '" + DM + "'";
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
                            dt = reader.GetDateTime(0);
                        }
                    }
                }
            }
            catch
            {
                // do nothing
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return dt;
        }
        // lay ra maxInspec Eff
        public String getMaxInspEffec(String compNum, String DM)
        {
            String eff = "E";
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT MIN([InspectionEffective]) FROM [rbi].[dbo].[RW_INSPECTION_HISTORY] WHERE [ComponentNumber] = '" + compNum + "' and DM = '" + DM + "'";
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
                            if (!reader.IsDBNull(0))
                                eff = reader.GetString(0);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("get Data inspection fail" + ex.ToString(), "Cortek");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return eff;
        }
        // dem so lan inspection
        public int InspectionNumber(String comNum, String DM)
        {
            int num = 0;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT COUNT([InspectionEffective]) FROM [rbi].[dbo].[RW_INSPECTION_HISTORY] WHERE [ComponentNumber] = '" + comNum + "' and DM = '" + DM + "'";
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
                            num = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch
            {
                // do nothing
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return num;
        }

    }
}
