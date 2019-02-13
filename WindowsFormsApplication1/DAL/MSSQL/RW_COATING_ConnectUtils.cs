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
    class RW_COATING_ConnectUtils
    {
        public void add(int ID, int ExternalCoating, int ExternalInsulation, int InternalCladding, int InternalCoating, int InternalLining, DateTime ExternalCoatingDate, String ExternalCoatingQuality, String ExternalInsulationType, String InsulationCondition, int InsulationContainsChloride, String InternalLinerCondition, String InternalLinerType, float CladdingCorrosionRate, int SupportConfigNotAllowCoatingMaint)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[RW_COATING]" +
                        "([ID]" +
                        ",[ExternalCoating]" +
                        ",[ExternalInsulation]" +
                        ",[InternalCladding]" +
                        ",[InternalCoating]" +
                        ",[InternalLining]" +
                        ",[ExternalCoatingDate]" +
                        ",[ExternalCoatingQuality]" +
                        ",[ExternalInsulationType]" +
                        ",[InsulationCondition]" +
                        ",[InsulationContainsChloride]" +
                        ",[InternalLinerCondition]" +
                        ",[InternalLinerType]" +
                        ",[CladdingCorrosionRate]" +
                        ",[SupportConfigNotAllowCoatingMaint])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + ExternalCoating + "'" +
                        ",'" + ExternalInsulation + "'" +
                        ",'" + InternalCladding + "'" +
                        ",'" + InternalCoating + "'" +
                        ",'" + InternalLining + "'" +
                        ",'" + ExternalCoatingDate + "'" +
                        ",'" + ExternalCoatingQuality + "'" +
                        ",'" + ExternalInsulationType + "'" +
                        ",'" + InsulationCondition + "'" +
                        ",'" + InsulationContainsChloride + "'" +
                        ",'" + InternalLinerCondition + "'" +
                        ",'" + InternalLinerType + "'" +
                        ",'" + CladdingCorrosionRate + "'" +
                        ",'" + SupportConfigNotAllowCoatingMaint + "')" +
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
        public void edit(int ID, int ExternalCoating, int ExternalInsulation, int InternalCladding, int InternalCoating, int InternalLining, DateTime ExternalCoatingDate, String ExternalCoatingQuality, String ExternalInsulationType, String InsulationCondition, int InsulationContainsChloride, String InternalLinerCondition, String InternalLinerType, float CladdingCorrosionRate, int SupportConfigNotAllowCoatingMaint)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_COATING]" +
                        "SET [ID] = '" + ID + "'" +
                        ",[ExternalCoating] = '" + ExternalCoating + "'" +
                        ",[ExternalInsulation] = '" + ExternalInsulation + "'" +
                        ",[InternalCladding] = '" + InternalCladding + "'" +
                        ",[InternalCoating] = '" + InternalCoating + "'" +
                        ",[InternalLining] = '" + InternalLining + "'" +
                        ",[ExternalCoatingDate] = '" + ExternalCoatingDate + "'" +
                        ",[ExternalCoatingQuality] = '" + ExternalCoatingQuality + "'" +
                        ",[ExternalInsulationType] = '" + ExternalInsulationType + "'" +
                        ",[InsulationCondition] = '" + InsulationCondition + "'" +
                        ",[InsulationContainsChloride] = '" + InsulationContainsChloride + "'" +
                        ",[InternalLinerCondition] = '" + InternalLinerCondition + "'" +
                        ",[InternalLinerType] = '" + InternalLinerType + "'" +
                        ",[CladdingCorrosionRate] = '" + CladdingCorrosionRate + "'" +
                        ",[SupportConfigNotAllowCoatingMaint] = '" + SupportConfigNotAllowCoatingMaint + "'" +
                        
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
                        "DELETE FROM [dbo].[RW_COATING]" +
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
        public List<RW_COATING> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_COATING> list = new List<RW_COATING>();
            RW_COATING obj = null;
            String sql = " Use [rbi] Select [ID]" +
                          ",[ExternalCoating]" +
                          ",[ExternalInsulation]" +
                          ",[InternalCladding]" +
                          ",[InternalCoating]" +
                          ",[InternalLining]" +
                          ",[ExternalCoatingDate]" +
                          ",[ExternalCoatingQuality]" +
                          ",[ExternalInsulationType]" +
                          ",[InsulationCondition]" +
                          ",[InsulationContainsChloride]" +
                          ",[InternalLinerCondition]" +
                          ",[InternalLinerType]" +
                          ",[CladdingCorrosionRate]" +
                          ",[ConfigNotAllowCoatingMaint]" +
                          "From [dbo].[RW_COATING]  ";
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
                            obj = new RW_COATING();
                            obj.ID = reader.GetInt32(0);
                            obj.ExternalCoating = reader.GetInt32(1);
                            obj.ExternalInsulation = reader.GetInt32(2);
                            obj.InternalCladding = reader.GetInt32(3);
                            obj.InternalCoating = reader.GetInt32(4);
                            obj.InternalLining = reader.GetInt32(5);
                            if (!reader.IsDBNull(6))
                            {
                                obj.ExternalCoatingDate = reader.GetDateTime(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.ExternalCoatingQuality = reader.GetString(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.ExternalInsulationType = reader.GetString(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.InsulationCondition = reader.GetString(9);
                            }
                            
                            obj.InsulationContainsChloride = reader.GetInt32(10);
                            
                            if (!reader.IsDBNull(11))
                            {
                                obj.InternalLinerCondition = reader.GetString(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.InternalLinerType = reader.GetString(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.CladdingCorrosionRate = reader.GetFloat(13);
                            }

                            obj.SupportConfigNotAllowCoatingMaint = reader.GetInt32(14);
                            

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
        public RW_COATING getData(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            RW_COATING obj = new RW_COATING();
            String sql = " Use [rbi] Select [ID], [ExternalCoating]" +
                          ",[ExternalInsulation]" +
                          ",[InternalCladding]" +
                          ",[InternalCoating]" +
                          ",[InternalLining]" +
                          ",[ExternalCoatingDate]" +
                          ",[ExternalCoatingQuality]" +
                          ",[ExternalInsulationType]" +
                          ",[InsulationCondition]" +
                          ",[InsulationContainsChloride]" +
                          ",[InternalLinerCondition]" +
                          ",[InternalLinerType]" +
                          ",[CladdingCorrosionRate]" +
                          ",[SupportConfigNotAllowCoatingMaint]" +
                          "From [dbo].[RW_COATING] WHERE [ID] = '" + ID + "'";
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
                            obj.ID = reader.GetInt32(0);
                            obj.ExternalCoating = Convert.ToInt32(reader.GetBoolean(1));
                            obj.ExternalInsulation = Convert.ToInt32(reader.GetBoolean(2));
                            obj.InternalCladding = Convert.ToInt32(reader.GetBoolean(3));
                            obj.InternalCoating = Convert.ToInt32(reader.GetBoolean(4));
                            obj.InternalLining = Convert.ToInt32(reader.GetBoolean(5));
                            if (!reader.IsDBNull(6))
                            {
                                obj.ExternalCoatingDate = reader.GetDateTime(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.ExternalCoatingQuality = reader.GetString(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.ExternalInsulationType = reader.GetString(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.InsulationCondition = reader.GetString(9);
                            }

                            obj.InsulationContainsChloride = Convert.ToInt32(reader.GetBoolean(10));

                            if (!reader.IsDBNull(11))
                            {
                                obj.InternalLinerCondition = reader.GetString(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.InternalLinerType = reader.GetString(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.CladdingCorrosionRate = (float)reader.GetDouble(13);
                            }

                            obj.SupportConfigNotAllowCoatingMaint = Convert.ToInt32(reader.GetBoolean(14));
                            Console.WriteLine(obj.ExternalCoatingQuality);
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
            return obj;
        }
        
    }
}



