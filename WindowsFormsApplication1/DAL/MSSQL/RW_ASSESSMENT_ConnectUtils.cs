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
    class RW_ASSESSMENT_ConnectUtils
    {
        public string getAssessmentName(int assID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            string name = null;
            String sql = "select ProposalName from rbi.dbo.RW_ASSESSMENT where ID = '" + assID + "'";
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
                            name = reader.GetString(0);
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
            return name;
        }
        public List<string> AllName()
        {
            List<string> lstName = new List<string>();
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            string sql = "SELECT ProposalName FROM rbi.dbo.RW_ASSESSMENT";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if(reader.HasRows)
                        {
                            lstName.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "Cortek RBI");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return lstName;
        }
        public List<int> getAllID()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            string sql = "select ID from rbi.dbo.RW_ASSESSMENT";
            List<int> obj = new List<int>();
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
                            obj.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("get all list ID " + ex.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return obj;
        }
        public void add(int EquipmentID, int ComponentID,DateTime AssessmentDate, int AssessmentMethod, int RiskAnalysisPeriod,int IsEquipmentLinked,String RecordType,int ProposalNo,int RevisionNo,int IsRecommend,String ProposalOrRevision,String AdoptedBy,DateTime AdoptedDate, String RecommendedBy,DateTime RecommendedDate, String ProposalName, int AddByExcel)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[RW_ASSESSMENT]" +
                        "([EquipmentID]" +
                        ",[ComponentID]" +
                        ",[AssessmentDate]" +
                        ",[AssessmentMethod]" +
                        ",[RiskAnalysisPeriod]" +
                        ",[IsEquipmentLinked]" +
                        ",[RecordType]" +
                        ",[ProposalNo]" +
                        ",[RevisionNo]" +
                        ",[IsRecommend]" +
                        ",[ProposalOrRevision]" +
                        ",[AdoptedBy]" +
                        ",[AdoptedDate]" +
                        ",[RecommendedBy]" +
                        ",[RecommendedDate]" +
                        ",[ProposalName]"+
                        ",[AddByExcel])"+
                        "VALUES" +
                        "('" + EquipmentID + "'" +
                        ",'" + ComponentID + "'" +
                        ",'" + AssessmentDate + "'" +
                        ",'" + AssessmentMethod + "'" +
                        ",'" + RiskAnalysisPeriod + "'" +
                        ",'" + IsEquipmentLinked + "'" +
                        ",'" + RecordType + "'" +
                        ",'" + ProposalNo + "'" +
                        ",'" + RevisionNo + "'" +
                        ",'" + IsRecommend + "'" +
                        ",'" + ProposalOrRevision + "'" +
                        ",'" + AdoptedBy + "'" +
                        ",'" + AdoptedDate + "'" +
                        ",'" + RecommendedBy + "'" +
                        ",'" + RecommendedDate + "'" +
                        ",'" + ProposalName + "'" +
                        ",'" + AddByExcel + "')" +
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
        public void edit(int ID,int EquipmentID, int ComponentID, DateTime AssessmentDate, int AssessmentMethod, int RiskAnalysisPeriod, int IsEquipmentLinked, String RecordType, int ProposalNo, int RevisionNo, int IsRecommend, String ProposalOrRevision, String AdoptedBy, DateTime AdoptedDate, String RecommendedBy, DateTime RecommendedDate, String ProposalName)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_ASSESSMENT]" +
                        "SET [EquipmentID] = '" + EquipmentID + "'" +
                        ",[ComponentID] = '" + ComponentID + "'" +
                        ",[AssessmentDate] = '" + AssessmentDate + "'" +
                        ",[AssessmentMethod] = '" + AssessmentMethod + "'" +
                        ",[RiskAnalysisPeriod] = '" + RiskAnalysisPeriod + "'" +
                        ",[IsEquipmentLinked] = '" + IsEquipmentLinked + "'" +
                        ",[RecordType] = '" + RecordType + "'" +
                        ",[ProposalNo] = '" + ProposalNo + "'" +
                        ",[RevisionNo] = '" + RevisionNo + "'" +
                        ",[IsRecommend] = '" + IsRecommend + "'" +
                        ",[ProposalOrRevision] = '" + ProposalOrRevision + "'" +
                        ",[AdoptedBy] = '" + AdoptedBy + "'" +
                        ",[AdoptedDate] = '" + AdoptedDate + "'" +
                        ",[RecommendedBy] = '" + RecommendedBy + "'" +
                        ",[RecommendedDate] = '" + RecommendedDate + "'" +
                        ",[ProposalName] = '"+ProposalName+"'"+
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
                        "DELETE FROM [dbo].[RW_ASSESSMENT]" +
                        "WHERE [ID]  = '" + ID + "' " +
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
        public List<RW_ASSESSMENT> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_ASSESSMENT> list = new List<RW_ASSESSMENT>();
            RW_ASSESSMENT obj = null;
            String sql = " Use [rbi] Select [ID]" +
                          ",[EquipmentID]" +
                          ",[ComponentID]" +
                          ",[AssessmentDate]" +
                          ",[AssessmentMethod]" +
                          ",[RiskAnalysisPeriod]" +
                          ",[IsEquipmentLinked]" +
                          ",[RecordType]" +
                          ",[ProposalNo]" +
                          ",[RevisionNo]" +
                          ",[IsRecommend]" +
                          ",[ProposalOrRevision]" +
                          ",[AdoptedBy]" +
                          ",[AdoptedDate]" +
                          ",[RecommendedBy]" +
                          ",[RecommendedDate]" +
                          ",[ProposalName]" +
                          "From [dbo].[RW_ASSESSMENT]  ";
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
                            obj = new RW_ASSESSMENT();
                            obj.ID = reader.GetInt32(0);
                            obj.EquipmentID = reader.GetInt32(1);
                            obj.ComponentID = reader.GetInt32(2);
                            if(!reader .IsDBNull (3))
                            {
                                obj.AssessmentDate = reader.GetDateTime(3);
                            }
                            if(!reader .IsDBNull (4))
                            {
                                obj.AssessmentMethod = reader.GetInt32(4);
                            }
                            if(!reader .IsDBNull (5))
                            {
                                obj.RiskAnalysisPeriod = reader.GetInt32(5);
                            }
                            obj.IsEquipmentLinked = reader.GetOrdinal("IsEquipmentLinked");
                            if(!reader .IsDBNull (7))
                            {
                                obj.RecordType = reader.GetString(7);
                            }
                            if(!reader .IsDBNull (8))
                            {
                                obj.ProposalNo = reader.GetInt32(8);
                            }
                            if(!reader .IsDBNull (9))
                            {
                                obj.RevisionNo = reader.GetInt32(9);
                            }
                            obj.IsRecommend = reader.GetOrdinal("IsRecommend");
                            if(!reader .IsDBNull (11))
                            {
                                obj.ProposalOrRevision = reader.GetString(11);
                            }
                            if(!reader.IsDBNull (12))
                            {
                                obj.AdoptedBy = reader.GetString(12);
                            }
                            if(!reader .IsDBNull (13))
                            {
                                obj.AdoptedDate = reader.GetDateTime(13);
                            }
                            if(!reader.IsDBNull (14))
                            {
                                obj.RecommendedBy = reader.GetString(14);
                            }
                            if(!reader.IsDBNull (15))
                            {
                                obj.RecommendedDate = reader.GetDateTime(15);
                            }
                            if(!reader.IsDBNull(16))
                            {
                                obj.ProposalName = reader.GetString(16);
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
        public int getEquipmentID(int ID)
        {
            int eqID = 0;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "SELECT [EquipmentID] FROM [rbi].[dbo].[RW_ASSESSMENT] WHERE ID = '"+ID+"'";
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
                            eqID = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Get Equipment ID Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return eqID;
        }
        public DateTime getAssessmentDate(int ID)
        {
            DateTime assDate = DateTime.Now;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            String sql = "select AssessmentDate from rbi.dbo.RW_ASSESSMENT where ID = '"+ID+"'";
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
                            assDate = reader.GetDateTime(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get Equipment ID Fail------->" + ex.ToString(), "Get Data Fail");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return assDate;
        }
        public Boolean checkExistAssessment(int ID)
        {
            Boolean IsExist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select AssessmentDate from rbi.dbo.RW_ASSESSMENT where ID = '"+ID+"'";
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
        public int[] getEquipmentID_ComponentID(int ID)
        {
            int[] temp = { 0, 0 };
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select EquipmentID, ComponentID from rbi.dbo.RW_ASSESSMENT where ID = '"+ID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp[0] = reader.GetInt32(0);
                        temp[1] = reader.GetInt32(1);
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
            return temp;
        }
        public RW_ASSESSMENT getData(int ID)
        {
            RW_ASSESSMENT ass = new RW_ASSESSMENT();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select ProposalName,AssessmentDate,RiskAnalysisPeriod from rbi.dbo.RW_ASSESSMENT where ID = '" + ID + "'";
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
                            ass.ProposalName = reader.GetString(0);
                            ass.AssessmentDate = reader.GetDateTime(1);
                            ass.RiskAnalysisPeriod = reader.GetInt32(2);
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
            return ass;
        }
        public int CountProposal(int compID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            int count = 0;
            String sql = " Use [rbi] Select COUNT([EquipmentID])" +
                          "From [dbo].[RW_ASSESSMENT] WHERE [ComponentID] = '" + compID + "' ";
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
                            count = reader.GetInt32(0);
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
            return count;
        }
        public List<int[]> getCheckAddExcel_ID(int comID, int eqID)
        {
            List<int[]> temp = new List<int[]>();
            int[] data = new int[2];
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "SELECT AddByExcel,ID FROM rbi.dbo.RW_ASSESSMENT WHERE EquipmentID = '"+eqID+"' AND ComponentID='"+comID+"'";
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
                            data[0] = Convert.ToInt32(reader.GetBoolean(0));
                            data[1] = reader.GetInt32(1);
                            temp.Add(data);
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
            return temp;
        }
        public int getLastID()
        {
            int temp = 0;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "SELECT MAX(ID) FROM rbi.dbo.RW_ASSESSMENT";
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
                            temp = reader.GetInt32(0);
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
            return temp;
        }
        public List<int> getAllIDbyComponentID(int ComponentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            string sql = "Select ID from rbi.dbo.RW_ASSESSMENT where ComponentID = '" + ComponentID + "'";
            List<int> listID = new List<int>();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            listID.Add(reader.GetInt32(0));
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Get list ID fail." + ex.ToString());
            }
            return listID;
        }
    }
}

