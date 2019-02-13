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
    class RW_DAMAGE_MECHANISM_ConnectUtils
    {
        public void add(int ID,int DMItemID,int IsActive,String Notes,int ExpectedTypeID,int IsEL,float ELValue,
                       int IsDF, int IsUserDisabled,float DF1,float DF2,float DF3, float DFBase,float RLI,
                        String HighestInspectionEffectiveness, String SecondInspectionEffectiveness,int NumberOfInspections,
                        DateTime LastInspDate,DateTime InspDueDate)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO [dbo].[RW_DAMAGE_MECHANISM]" +
                            "([ID]" +
                            ",[DMItemID]" +
                            ",[IsActive]" +
                            ",[Notes]" +
                            ",[ExpectedTypeID]" +
                            ",[IsEL]" +
                            ",[ELValue]" +
                            ",[IsDF]" +
                            ",[IsUserDisabled]" +
                            ",[DF1]" +
                            ",[DF2]" +
                            ",[DF3]" +
                            ",[DFBase]" +
                            ",[RLI]" +
                            ",[HighestInspectionEffectiveness]" +
                            ",[SecondInspectionEffectiveness]" +
                            ",[NumberOfInspections]" +
                            ",[LastInspDate]" +
                            ",[InspDueDate])" +
                            "VALUES" +
                            "('" + ID + "'" +
                            ",'" + DMItemID + "'" +
                            ",'" + IsActive + "'" +
                            ",'" + Notes + "'" +
                            ",'" + ExpectedTypeID + "'" +
                            ",'" + IsEL + "'" +
                            ",'" + ELValue + "'" +
                            ",'" + IsDF + "'" +
                            ",'" + IsUserDisabled + "'" +
                            ",'" + DF1 + "'" +
                            ",'" + DF2 + "'" +
                            ",'" + DF3 + "'" +
                            ",'" + DFBase + "'" +
                            ",'" + RLI + "'" +
                            ",'" + HighestInspectionEffectiveness + "'" +
                            ",'" + SecondInspectionEffectiveness + "'" +
                            ",'" + NumberOfInspections + "'" +
                            ",'" + LastInspDate + "'" +
                            ",'" + InspDueDate + "')";
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
        public void edit(int ID,int DMItemID,int IsActive,String Notes,int ExpectedTypeID,int IsEL,float ELValue,
                       int IsDF, int IsUserDisabled,float DF1,float DF2,float DF3, float DFBase,float RLI,
                        String HighestInspectionEffective,String SecondInspectionEffectiveness,int NumberOfInspections,
                        DateTime LastInspDate,DateTime InspDueDate)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "  " +
                           " UPDATE[dbo].[RW_DAMAGE_MECHANISM]" +
                                  "SET[ID] ='"+ID+"'" +
                                  ",[DMItemID] = '"+DMItemID+"'" +
                                  ",[IsActive] = '"+IsActive+"'" +
                                  ",[Notes] = '"+Notes+"'" +
                                  ",[ExpectedTypeID] = '"+ExpectedTypeID+"'" +
                                  ",[IsEL] = '"+IsEL+"'" +
                                  ",[ELValue] = '"+ELValue+"'" +
                                  ",[IsDF] = '"+IsDF+"'" +
                                  ",[IsUserDisabled] = '"+IsUserDisabled+"'" +
                                  ",[DF1] = '"+DF1+"'" +
                                  ",[DF2] = '"+DF2+"'" +
                                  ",[DF3] = '"+DF3+"'" +
                                  ",[DFBase] = '"+DFBase+"'" +
                                  ",[RLI] = '"+RLI+"'" +
                                  ",[HighestInspectionEffectiveness] = '" + HighestInspectionEffective + "'" +
                                  ",[SecondInspectionEffectiveness] = '"+SecondInspectionEffectiveness+"'" +
                                  ",[NumberOfInspections] = '"+NumberOfInspections+"'" +
                                  ",[LastInspDate] = '"+LastInspDate+"'" +
                                  ",[InspDueDate] = '"+InspDueDate+"'" +
                                  ",[Modified] = '"+DateTime.Now+"'" +
                                  "WHERE [ID] ='" + ID + "' AND [DMItemID] ='" + DMItemID + "'" +
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
        public void delete(int DMItemID,int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_DAMAGE_MECHANISM] where [DMItemID]='" + DMItemID + "' AND [ID]='" + ID + "'";
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
        //get datasource
        public List<RW_DAMAGE_MECHANISM> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_DAMAGE_MECHANISM> list = new List<RW_DAMAGE_MECHANISM>();
            RW_DAMAGE_MECHANISM obj = null;
            String sql = "Use[rbi] Select[ID]" +
                           ",[DMItemID]" +
                            ",[IsActive]" +
                            ",[Notes]" +
                            ",[ExpectedTypeID]" +
                            ",[IsEL]" +
                            ",[ELValue]" +
                            ",[IsDF]" +
                            ",[IsUserDisabled]" +
                            ",[DF1]" +
                            ",[DF2]" +
                            ",[DF3]" +
                            ",[DFBase]" +
                            ",[RLI]" +
                            ",[HighestInspectionEffective]" +
                            ",[SecondInspectionEffectiveness]" +
                            ",[NumberOfInspections]" +
                            ",[LastInspDate]" +
                            ",[InspDueDate]" +
                          "From [dbo].[RW_DAMAGE_MECHANISM]  ";
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
                            obj = new RW_DAMAGE_MECHANISM();
                            obj.ID = reader.GetInt32(0);
                            obj.DMItemID = reader.GetInt32(1);
                            obj.IsActive = reader.GetInt32(2);
                            if (!reader.IsDBNull(3))
                            {
                                obj.Notes = reader.GetString(3);
                            }
                            obj.ExpectedTypeID = reader.GetInt32(4);
                            obj.IsEL = reader.GetInt32(5);
                            if (!reader.IsDBNull(6))
                            {
                                obj.ELValue = reader.GetFloat(6);
                            }
                            obj.IsDF = reader.GetInt32(7);
                            obj.IsUserDisabled = reader.GetInt32(8);
                            if (!reader.IsDBNull(9))
                            {
                                obj.DF1 = reader.GetFloat(9);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.DF2 = reader.GetFloat(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.DF3 = reader.GetFloat(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.DFBase = reader.GetFloat(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.RLI = reader.GetFloat(13);
                            }
                            if (!reader.IsDBNull(14))
                            {
                                obj.HighestInspectionEffectiveness = reader.GetString(14);
                            }
                            if (!reader.IsDBNull(15))
                            {
                                obj.SecondInspectionEffectiveness = reader.GetString(15);
                            }
                            if (!reader.IsDBNull(16))
                            {
                                obj.NumberOfInspections = reader.GetInt32(16);
                            }
                            if (!reader.IsDBNull(17))
                            {
                                obj.LastInspDate = reader.GetDateTime(17);
                            }
                            if (!reader.IsDBNull(18))
                            {
                                obj.InspDueDate = reader.GetDateTime(18);
                            }
                            list.Add(obj);
                        }
                    }
                }
            }
            catch (Exception e)
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
        public Boolean checkExistDamageMechanism(int ID, int DM_ID)
        {
            Boolean IsExist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select IsActive from rbi.dbo.RW_DAMAGE_MECHANISM where ID = '"+ID+"' and DMItemID = '"+DM_ID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                            IsExist = false;
                        else
                            IsExist = true;
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
            return IsExist;
        }

        public List<InspectionPlant> GetListInspectionPlant()
        {
            List<InspectionPlant> lstInsp = new List<InspectionPlant>();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "SELECT ID, DMItemID, LastInspDate, InspDueDate FROM [rbi].[dbo].[RW_DAMAGE_MECHANISM]";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if(reader.HasRows)
                        {
                            InspectionPlant ins = new InspectionPlant();
                            if(!reader.IsDBNull(0))
                            {
                                ins.IDProposal = reader.GetInt32(0);
                            }
                            if(!reader.IsDBNull(1))
                            {
                                ins.DMItemID = reader.GetInt32(1);
                            }
                            if(!reader.IsDBNull(2))
                            {
                                ins.LastInspectionDate = reader.GetDateTime(2).ToString();
                            }
                            if(!reader.IsDBNull(3))
                            {
                                ins.DueDate = reader.GetDateTime(3).ToString();
                            }
                            lstInsp.Add(ins);
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
            return lstInsp;
        }
    }
}
