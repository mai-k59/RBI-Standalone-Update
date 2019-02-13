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
    class RW_CA_LEVEL_1_ConnUtils
    {
        public void add(int ID, String Release_Phase, float fact_di, float fact_mit, float fact_ait, float CA_cmd, float CA_inj_flame, float CA_inj_toxic, float CA_inj_ntnf, float FC_cmd, float FC_affa, float FC_prod, float FC_inj, float FC_envi, float FC_total, String FCOF_Category)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "INSERT INTO [dbo].[RW_CA_LEVEL1] " +
                        "([ID] " +
                        ",[Release_Phase] " +
                        ",[fact_di] " +
                        ",[fact_mit] " +
                        ",[fact_ait] " +
                        ",[CA_cmd] " +
                        ",[CA_inj_flame] " +
                        ",[CA_inj_toxic] " +
                        ",[CA_inj_ntnf] " +
                        ",[FC_cmd] " +
                        ",[FC_affa] " +
                        ",[FC_prod] " +
                        ",[FC_inj] " +
                        ",[FC_envi] " +
                        ",[FC_total] " +
                        ",[FCOF_Category]) " +
                        "VALUES  " +
                        "('" + ID + "'" +
                        ",'" + Release_Phase + "'" +
                        ",'" + fact_di + "'" +
                        ",'" + fact_mit + "'" +
                        ",'" + fact_ait + "'" +
                        ",'" + CA_cmd + "'" +
                        ",'" + CA_inj_flame + "'" +
                        ",'" + CA_inj_toxic + "'" +
                        ",'" + CA_inj_ntnf + "'" +
                        ",'" + FC_cmd + "'" +
                        ",'" + FC_affa + "'" +
                        ",'" + FC_prod + "'" +
                        ",'" + FC_inj + "'" +
                        ",'" + FC_envi + "'" +
                        ",'" + FC_total + "' " +
                        ",'" + FCOF_Category + "')";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ADD DATA ERROR!" + ex.ToString(), "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int ID, String Release_Phase, float fact_di, float fact_mit, float fact_ait, float CA_cmd, float CA_inj_flame, float CA_inj_toxic, float CA_inj_ntnf, float FC_cmd, float FC_affa, float FC_prod, float FC_inj, float FC_envi, float FC_total, String FCOF_Category)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "UPDATE [dbo].[RW_CA_LEVEL1] " +
                        "SET [Release_Phase] = '" + Release_Phase + "'" +
                        ",[fact_di] = '" + fact_di + "'" +
                        ",[fact_mit] = '" + fact_mit + "'" +
                        ",[fact_ait] = '" + fact_ait + "'" +
                        ",[CA_cmd] = '" + CA_cmd + "'" +
                        ",[CA_inj_flame] = '" + CA_inj_flame + "'" +
                        ",[CA_inj_toxic] = '" + CA_inj_toxic + "'" +
                        ",[CA_inj_ntnf] = '" + CA_inj_ntnf + "'" +
                        ",[FC_cmd] = '" + FC_cmd + "'" +
                        ",[FC_affa] = '" + FC_affa + "'" +
                        ",[FC_prod] = '" + FC_prod + "'" +
                        ",[FC_inj] = '" + FC_inj + "'" +
                        ",[FC_envi] = '" + FC_envi + "'" +
                        ",[FC_total] = '" + FC_total + "'" +
                        ",[FCOF_Category] = '" + FCOF_Category + "'" +
                        " WHERE [ID] = '" + ID + "' ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("EDIT DATA FAIL!", "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void detele(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_CA_LEVEL1] WHERE [ID] = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("DELETE DATA FAIL!", "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public RW_CA_LEVEL_1 getData(int ID)
        {
            RW_CA_LEVEL_1 obj = new RW_CA_LEVEL_1();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "SELECT [Release_Phase]" +
                        ",[fact_di]" +
                        ",[fact_mit]" +
                        ",[fact_ait]" +
                        ",[CA_cmd]" +
                        ",[CA_inj_flame]" +
                        ",[CA_inj_toxic]" +
                        ",[CA_inj_ntnf]" +
                        ",[FC_cmd]" +
                        ",[FC_affa]" +
                        ",[FC_prod]" +
                        ",[FC_inj]" +
                        ",[FC_envi]" +
                        ",[FC_total]" +
                        ",[FCOF_Category]" +
                        " FROM [rbi].[dbo].[RW_CA_LEVEL1] WHERE [ID] ='" + ID + "'";
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
                            obj.ID = ID;
                            obj.Release_Phase = reader.GetString(0);
                            obj.fact_di = (float)reader.GetDouble(1);
                            obj.fact_mit = (float)reader.GetDouble(2);
                            obj.fact_ait = (float)reader.GetDouble(3);
                            obj.CA_cmd = (float)reader.GetDouble(4);
                            obj.CA_inj_flame = (float)reader.GetDouble(5);
                            obj.CA_inj_toxic = (float)reader.GetDouble(6);
                            obj.CA_inj_ntnf = (float)reader.GetDouble(7);
                            obj.FC_cmd = (float)reader.GetDouble(8);
                            obj.FC_affa = (float)reader.GetDouble(9);
                            obj.FC_prod = (float)reader.GetDouble(10);
                            obj.FC_inj = (float)reader.GetDouble(11);
                            obj.FC_envi = (float)reader.GetDouble(12);
                            obj.FC_total = (float)reader.GetDouble(13);
                            obj.FCOF_Category = reader.GetString(14);
                        }
                    }
                }
            }
            catch
            {
                obj.ID = 0;
                //MessageBox.Show("GET DATA FAIL!", "ERROR!");
            }
            finally
            {
                conn.Close();
            }
            return obj;
        }
        public Boolean checkExist(int ID)
        {
            Boolean IsExist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select Release_Phase from rbi.dbo.RW_CA_LEVEL1 where ID = '"+ID+"'";
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
    }
}
