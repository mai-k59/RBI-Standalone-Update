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
    class RW_INPUT_CA_TANK_ConnUtils
    {
        public void Add(int ID, float FLUID_HEIGHT, float SHELL_COURSE_HEIGHT, float TANK_DIAMETTER, int Prevention_Barrier, String Environ_Sensitivity, float P_lvdike, float P_onsite, float P_offsite, String Soil_Type, String TANK_FLUID, String API_FLUID, float SW, float ProductionCost)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "INSERT INTO [dbo].[RW_INPUT_CA_TANK] " +
                        "([ID]"+
                        ",[FLUID_HEIGHT] " +
                        ",[SHELL_COURSE_HEIGHT] " +
                        ",[TANK_DIAMETTER] " +
                        ",[Prevention_Barrier] " +
                        ",[Environ_Sensitivity] " +
                        ",[P_lvdike] " +
                        ",[P_onsite] " +
                        ",[P_offsite] " +
                        ",[Soil_Type] " +
                        ",[TANK_FLUID] " +
                        ",[API_FLUID] " +
                        ",[SW] " +
                        ",[ProductionCost]) " +
                        "VALUES " +
                        "('" + ID + "' " +
                        ",'" + FLUID_HEIGHT + "' " +
                        ",'" + SHELL_COURSE_HEIGHT + "' " +
                        ",'" + TANK_DIAMETTER + "' " +
                        ",'" + Prevention_Barrier + "' " +
                        ",'" + Environ_Sensitivity + "' " +
                        ",'" + P_lvdike + "' " +
                        ",'" + P_onsite + "' " +
                        ",'" + P_offsite + "' " +
                        ",'" + Soil_Type + "' " +
                        ",'" + TANK_FLUID + "' " +
                        ",'" + API_FLUID + "'" +
                        ",'" + SW + "' "+
                        ",'" + ProductionCost + "') ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ADD FAIL!", "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void Edit(int ID,float FLUID_HEIGHT, float SHELL_COURSE_HEIGHT, float TANK_DIAMETTER, int Prevention_Barrier, String Environ_Sensitivity, float P_lvdike, float P_onsite, float P_offsite, String Soil_Type, String TANK_FLUID, String API_FLUID, float SW, float ProductionCost)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "UPDATE [dbo].[RW_INPUT_CA_TANK] " +
                        " SET [FLUID_HEIGHT] = '" + FLUID_HEIGHT + "' " +
                        ",[SHELL_COURSE_HEIGHT] = '" + SHELL_COURSE_HEIGHT + "' " +
                        ",[TANK_DIAMETTER] = '" + TANK_DIAMETTER + "' " +
                        ",[Prevention_Barrier] = '" + Prevention_Barrier + "' " +
                        ",[Environ_Sensitivity] = '" + Environ_Sensitivity + "' " +
                        ",[P_lvdike] = '" + P_lvdike + "' " +
                        ",[P_onsite] = '" + P_onsite + "' " +
                        ",[P_offsite] = '" + P_offsite + "' " +
                        ",[Soil_Type] = '" + Soil_Type + "' " +
                        ",[TANK_FLUID] = '" + TANK_FLUID + "' " +
                        ",[API_FLUID] = '" + API_FLUID + "' " +
                        ",[SW] = '" + SW + "' " +
                        ",[ProductionCost] = '" + ProductionCost + "' " +
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
                MessageBox.Show("EDIT FAIL!", "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void Delete(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_INPUT_CA_TANK] WHERE [ID] = '"+ID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("DELETE ERROR!", "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public RW_INPUT_CA_TANK getData(int ID)
        {
            RW_INPUT_CA_TANK obj = new RW_INPUT_CA_TANK();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "SELECT [FLUID_HEIGHT]" +
                        ",[SHELL_COURSE_HEIGHT]" +
                        ",[TANK_DIAMETTER]" +
                        ",[Prevention_Barrier]" +
                        ",[Environ_Sensitivity]" +
                        ",[P_lvdike]" +
                        ",[P_onsite]" +
                        ",[P_offsite]" +
                        ",[Soil_Type]" +
                        ",[TANK_FLUID]" +
                        ",[API_FLUID]" +
                        ",[SW]" +
                        " FROM [rbi].[dbo].[RW_INPUT_CA_TANK] WHERE [ID] = '" + ID + "'";
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
                            obj.FLUID_HEIGHT = (float)reader.GetDouble(0);
                            obj.SHELL_COURSE_HEIGHT = (float)reader.GetDouble(1);
                            obj.TANK_DIAMETTER = (float)reader.GetDouble(2);
                            obj.Prevention_Barrier = reader.GetInt32(3);
                            obj.Environ_Sensitivity = reader.GetString(4);
                            obj.P_lvdike = (float)reader.GetDouble(5);
                            obj.P_onsite = (float)reader.GetDouble(6);
                            obj.P_offsite = (float)reader.GetDouble(7);
                            obj.Soil_Type = reader.GetString(8);
                            obj.TANK_FLUID = reader.GetString(9);
                            obj.API_FLUID = reader.GetString(10);
                            obj.SW = (float)reader.GetDouble(11);
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
                conn.Dispose();
            }
            return obj;
        }
        public float getProductionCost(int ID)
        {
            float obj = 0;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select ProductionCost from rbi.dbo.RW_INPUT_CA_TANK where ID = '"+ID+"'";
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
                            obj = (float)reader.GetDouble(0);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA FAIL!", "ERROR!");
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
