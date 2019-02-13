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
    class RW_CA_TANK_ConnUtils
    {
        public void add(int ID, float Hydraulic_Water, float Hydraulic_Fluid, float Seepage_Velocity, float Flow_Rate_D1, float Flow_Rate_D2, float Flow_Rate_D3, float Flow_Rate_D4, float Leak_Duration_D1, float Leak_Duration_D2, float Leak_Duration_D3, float Leak_Duration_D4, float Release_Volume_Leak_D1, float Release_Volume_Leak_D2, float Release_Volume_Leak_D3, float Release_Volume_Leak_D4, float Release_Volume_Rupture, float Liquid_Height, float Volume_Fluid, float Time_Leak_Ground, float Volume_SubSoil_Leak_D1, float Volume_SubSoil_Leak_D4, float Volume_Ground_Water_Leak_D1, float Volume_Ground_Water_Leak_D4, float Barrel_Dike_Leak, float Barrel_Dike_Rupture, float Barrel_Onsite_Leak, float Barrel_Onsite_Rupture, float Barrel_Offsite_Leak, float Barrel_Offsite_Rupture, float Barrel_Water_Leak, float Barrel_Water_Rupture, float FC_Environ_Leak, float FC_Environ_Rupture, float FC_Environ, float Material_Factor, float Component_Damage_Cost, float Business_Cost, float Consequence, String ConsequenceCategory)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "INSERT INTO [dbo].[RW_CA_TANK]" +
                        "([ID]" +
                        ",[Hydraulic_Water]" +
                        ",[Hydraulic_Fluid]" +
                        ",[Seepage_Velocity]" +
                        ",[Flow_Rate_D1]" +
                        ",[Flow_Rate_D2]" +
                        ",[Flow_Rate_D3]" +
                        ",[Flow_Rate_D4]" +
                        ",[Leak_Duration_D1]" +
                        ",[Leak_Duration_D2]" +
                        ",[Leak_Duration_D3]" +
                        ",[Leak_Duration_D4]" +
                        ",[Release_Volume_Leak_D1]" +
                        ",[Release_Volume_Leak_D2]" +
                        ",[Release_Volume_Leak_D3]" +
                        ",[Release_Volume_Leak_D4]" +
                        ",[Release_Volume_Rupture]" +
                        ",[Liquid_Height]" +
                        ",[Volume_Fluid]" +
                        ",[Time_Leak_Ground]" +
                        ",[Volume_SubSoil_Leak_D1]" +
                        ",[Volume_SubSoil_Leak_D4]" +
                        ",[Volume_Ground_Water_Leak_D1]" +
                        ",[Volume_Ground_Water_Leak_D4]" +
                        ",[Barrel_Dike_Leak]" +
                        ",[Barrel_Dike_Rupture]" +
                        ",[Barrel_Onsite_Leak]" +
                        ",[Barrel_Onsite_Rupture]" +
                        ",[Barrel_Offsite_Leak]" +
                        ",[Barrel_Offsite_Rupture]" +
                        ",[Barrel_Water_Leak]" +
                        ",[Barrel_Water_Rupture]" +
                        ",[FC_Environ_Leak]" +
                        ",[FC_Environ_Rupture]" +
                        ",[FC_Environ]" +
                        ",[Material_Factor]" +
                        ",[Component_Damage_Cost]" +
                        ",[Business_Cost]" +
                        ",[Consequence]" +
                        ",[ConsequenceCategory])" +
                        " VALUES " +
                        "('" + ID + "'" +
                        ",'" + Hydraulic_Water + "'" +
                        ",'" + Hydraulic_Fluid + "'" +
                        ",'" + Seepage_Velocity + "'" +
                        ",'" + Flow_Rate_D1 + "'" +
                        ",'" + Flow_Rate_D2 + "'" +
                        ",'" + Flow_Rate_D3 + "'" +
                        ",'" + Flow_Rate_D4 + "'" +
                        ",'" + Leak_Duration_D1 + "'" +
                        ",'" + Leak_Duration_D2 + "'" +
                        ",'" + Leak_Duration_D3 + "'" +
                        ",'" + Leak_Duration_D4 + "'" +
                        ",'" + Release_Volume_Leak_D1 + "'" +
                        ",'" + Release_Volume_Leak_D2 + "'" +
                        ",'" + Release_Volume_Leak_D3 + "'" +
                        ",'" + Release_Volume_Leak_D4 + "'" +
                        ",'" + Release_Volume_Rupture + "'" +
                        ",'" + Liquid_Height + "'" +
                        ",'" + Volume_Fluid + "'" +
                        ",'" + Time_Leak_Ground + "'" +
                        ",'" + Volume_SubSoil_Leak_D1 + "'" +
                        ",'" + Volume_SubSoil_Leak_D4 + "'" +
                        ",'" + Volume_Ground_Water_Leak_D1 + "'" +
                        ",'" + Volume_Ground_Water_Leak_D4 + "'" +
                        ",'" + Barrel_Dike_Leak + "'" +
                        ",'" + Barrel_Dike_Rupture + "'" +
                        ",'" + Barrel_Onsite_Leak + "'" +
                        ",'" + Barrel_Onsite_Rupture + "'" +
                        ",'" + Barrel_Offsite_Leak + "'" +
                        ",'" + Barrel_Offsite_Rupture + "'" +
                        ",'" + Barrel_Water_Leak + "'" +
                        ",'" + Barrel_Water_Rupture + "'" +
                        ",'" + FC_Environ_Leak + "'" +
                        ",'" + FC_Environ_Rupture + "'" +
                        ",'" + FC_Environ + "'" +
                        ",'" + Material_Factor + "'" +
                        ",'" + Component_Damage_Cost + "'" +
                        ",'" + Business_Cost + "'" +
                        ",'" + Consequence + "'" +
                        ",'" + ConsequenceCategory + "')";
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ADD DATA FAIL!" + ex.ToString(), "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int ID, float Hydraulic_Water, float Hydraulic_Fluid, float Seepage_Velocity, float Flow_Rate_D1, float Flow_Rate_D2, float Flow_Rate_D3, float Flow_Rate_D4, float Leak_Duration_D1, float Leak_Duration_D2, float Leak_Duration_D3, float Leak_Duration_D4, float Release_Volume_Leak_D1, float Release_Volume_Leak_D2, float Release_Volume_Leak_D3, float Release_Volume_Leak_D4, float Release_Volume_Rupture, float Liquid_Height, float Volume_Fluid, float Time_Leak_Ground, float Volume_SubSoil_Leak_D1, float Volume_SubSoil_Leak_D4, float Volume_Ground_Water_Leak_D1, float Volume_Ground_Water_Leak_D4, float Barrel_Dike_Leak, float Barrel_Dike_Rupture, float Barrel_Onsite_Leak, float Barrel_Onsite_Rupture, float Barrel_Offsite_Leak, float Barrel_Offsite_Rupture, float Barrel_Water_Leak, float Barrel_Water_Rupture, float FC_Environ_Leak, float FC_Environ_Rupture, float FC_Environ, float Material_Factor, float Component_Damage_Cost, float Business_Cost, float Consequence, String ConsequenceCategory)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "UPDATE [dbo].[RW_CA_TANK]" +
                        "SET [Hydraulic_Water] = '" + Hydraulic_Water + "'" +
                        ",[Hydraulic_Fluid] = '" + Hydraulic_Fluid + "'" +
                        ",[Seepage_Velocity] = '" + Seepage_Velocity + "'" +
                        ",[Flow_Rate_D1] = '" + Flow_Rate_D1 + "'" +
                        ",[Flow_Rate_D2] = '" + Flow_Rate_D2 + "'" +
                        ",[Flow_Rate_D3] = '" + Flow_Rate_D3 + "'" +
                        ",[Flow_Rate_D4] = '" + Flow_Rate_D4 + "'" +
                        ",[Leak_Duration_D1] = '" + Leak_Duration_D1 + "'" +
                        ",[Leak_Duration_D2] = '" + Leak_Duration_D2 + "'" +
                        ",[Leak_Duration_D3] = '" + Leak_Duration_D3 + "'" +
                        ",[Leak_Duration_D4] = '" + Leak_Duration_D4 + "'" +
                        ",[Release_Volume_Leak_D1] = '" + Release_Volume_Leak_D1 + "'" +
                        ",[Release_Volume_Leak_D2] = '" + Release_Volume_Leak_D2 + "'" +
                        ",[Release_Volume_Leak_D3] = '" + Release_Volume_Leak_D3 + "'" +
                        ",[Release_Volume_Leak_D4] = '" + Release_Volume_Leak_D4 + "'" +
                        ",[Release_Volume_Rupture] = '" + Release_Volume_Rupture + "'" +
                        ",[Liquid_Height] = '" + Liquid_Height + "'" +
                        ",[Volume_Fluid] = '" + Volume_Fluid + "'" +
                        ",[Time_Leak_Ground] = '" + Time_Leak_Ground + "'" +
                        ",[Volume_SubSoil_Leak_D1] = '" + Volume_SubSoil_Leak_D1 + "'" +
                        ",[Volume_SubSoil_Leak_D4] = '" + Volume_SubSoil_Leak_D4 + "'" +
                        ",[Volume_Ground_Water_Leak_D1] = '" + Volume_Ground_Water_Leak_D1 + "'" +
                        ",[Volume_Ground_Water_Leak_D4] = '" + Volume_Ground_Water_Leak_D4 + "'" +
                        ",[Barrel_Dike_Leak] = '" + Barrel_Dike_Leak + "'" +
                        ",[Barrel_Dike_Rupture] = '" + Barrel_Dike_Rupture + "'" +
                        ",[Barrel_Onsite_Leak] = '" + Barrel_Onsite_Leak + "'" +
                        ",[Barrel_Onsite_Rupture] = '" + Barrel_Onsite_Rupture + "'" +
                        ",[Barrel_Offsite_Leak] = '" + Barrel_Offsite_Leak + "'" +
                        ",[Barrel_Offsite_Rupture] = '" + Barrel_Offsite_Rupture + "'" +
                        ",[Barrel_Water_Leak] = '" + Barrel_Water_Leak + "'" +
                        ",[Barrel_Water_Rupture] = '" + Barrel_Water_Rupture + "'" +
                        ",[FC_Environ_Leak] = '" + FC_Environ_Leak + "'" +
                        ",[FC_Environ_Rupture] = '" + FC_Environ_Rupture + "'" +
                        ",[FC_Environ] = '" + FC_Environ + "'" +
                        ",[Material_Factor] = '" + Material_Factor + "'" +
                        ",[Component_Damage_Cost] = '" + Component_Damage_Cost + "'" +
                        ",[Business_Cost] = '" + Business_Cost + "'" +
                        ",[Consequence] = '" + Consequence + "'" +
                        ",[ConsequenceCategory] = '" + ConsequenceCategory + "'" +
                        " WHERE [ID] = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("EDIT DATA FAIL!" + ex.ToString(), "ERROR!");
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
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_CA_TANK] WHERE [ID] = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("DELETE FAIL!", "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public RW_CA_TANK getData(int ID)
        {
            RW_CA_TANK obj = new RW_CA_TANK();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                        "SELECT [Hydraulic_Water] " +
                        ",[Hydraulic_Fluid] " +
                        ",[Seepage_Velocity] " +
                        ",[Flow_Rate_D1] " +
                        ",[Flow_Rate_D2] " +
                        ",[Flow_Rate_D3] " +
                        ",[Flow_Rate_D4] " +
                        ",[Leak_Duration_D1] " +
                        ",[Leak_Duration_D2] " +
                        ",[Leak_Duration_D3] " +
                        ",[Leak_Duration_D4] " +
                        ",[Release_Volume_Leak_D1] " +
                        ",[Release_Volume_Leak_D2] " +
                        ",[Release_Volume_Leak_D3] " +
                        ",[Release_Volume_Leak_D4] " +
                        ",[Release_Volume_Rupture] " +
                        ",[Liquid_Height] " +
                        ",[Volume_Fluid] " +
                        ",[Time_Leak_Ground] " +
                        ",[Volume_SubSoil_Leak_D1] " +
                        ",[Volume_SubSoil_Leak_D4] " +
                        ",[Volume_Ground_Water_Leak_D1] " +
                        ",[Volume_Ground_Water_Leak_D4] " +
                        ",[Barrel_Dike_Leak] " +
                        ",[Barrel_Dike_Rupture] " +
                        ",[Barrel_Onsite_Leak] " +
                        ",[Barrel_Onsite_Rupture] " +
                        ",[Barrel_Offsite_Leak] " +
                        ",[Barrel_Offsite_Rupture] " +
                        ",[Barrel_Water_Leak] " +
                        ",[Barrel_Water_Rupture] " +
                        ",[FC_Environ_Leak] " +
                        ",[FC_Environ_Rupture] " +
                        ",[FC_Environ] " +
                        ",[Material_Factor] " +
                        ",[Component_Damage_Cost] " +
                        ",[Business_Cost] " +
                        ",[Consequence] " +
                        ",[ConsequenceCategory] " +
                        " FROM [rbi].[dbo].[RW_CA_TANK] WHERE [ID] ='" + ID + "'";
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
                            obj.Hydraulic_Water = (float)reader.GetDouble(0);
                            obj.Hydraulic_Fluid = (float)reader.GetDouble(1);
                            obj.Seepage_Velocity = (float)reader.GetDouble(2);
                            obj.Flow_Rate_D1 = (float)reader.GetDouble(3);
                            obj.Flow_Rate_D2 = (float)reader.GetDouble(4);
                            obj.Flow_Rate_D3 = (float)reader.GetDouble(5);
                            obj.Flow_Rate_D4 = (float)reader.GetDouble(6);
                            obj.Leak_Duration_D1 = (float)reader.GetDouble(7);
                            obj.Leak_Duration_D2 = (float)reader.GetDouble(8);
                            obj.Leak_Duration_D3 = (float)reader.GetDouble(9);
                            obj.Leak_Duration_D4 = (float)reader.GetDouble(10);
                            obj.Release_Volume_Leak_D1 = (float)reader.GetDouble(11);
                            obj.Release_Volume_Leak_D2 = (float)reader.GetDouble(12);
                            obj.Release_Volume_Leak_D3 = (float)reader.GetDouble(13);
                            obj.Release_Volume_Leak_D4 = (float)reader.GetDouble(14);
                            obj.Release_Volume_Rupture = (float)reader.GetDouble(15);
                            obj.Liquid_Height = (float)reader.GetDouble(16);
                            obj.Volume_Fluid = (float)reader.GetDouble(17);
                            obj.Time_Leak_Ground = (float)reader.GetDouble(18);
                            obj.Volume_SubSoil_Leak_D1 = (float)reader.GetDouble(19);
                            obj.Volume_SubSoil_Leak_D4 = (float)reader.GetDouble(20);
                            obj.Volume_Ground_Water_Leak_D1 = (float)reader.GetDouble(21);
                            obj.Volume_Ground_Water_Leak_D4 = (float)reader.GetDouble(22);
                            obj.Barrel_Dike_Leak = (float)reader.GetDouble(23);
                            obj.Barrel_Dike_Rupture = (float)reader.GetDouble(24);
                            obj.Barrel_Onsite_Leak = (float)reader.GetDouble(25);
                            obj.Barrel_Onsite_Rupture = (float)reader.GetDouble(26);
                            obj.Barrel_Offsite_Leak = (float)reader.GetDouble(27);
                            obj.Barrel_Offsite_Rupture = (float)reader.GetDouble(28);
                            obj.Barrel_Water_Leak = (float)reader.GetDouble(29);
                            obj.Barrel_Water_Rupture = (float)reader.GetDouble(30);
                            obj.FC_Environ_Leak = (float)reader.GetDouble(31);
                            obj.FC_Environ_Rupture = (float)reader.GetDouble(32);
                            obj.FC_Environ = (float)reader.GetDouble(33);
                            obj.Material_Factor = (float)reader.GetDouble(34);
                            obj.Component_Damage_Cost = (float)reader.GetDouble(35);
                            obj.Business_Cost = (float)reader.GetDouble(36);
                            obj.Consequence = (float)reader.GetDouble(37);
                            obj.ConsequenceCategory = reader.GetString(38);
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
        public bool CheckExistID(int ID)
        {
            Boolean IsExist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "SELECT Hydraulic_Water FROM rbi.dbo.RW_CA_TANK WHERE ID = '"+ID+"'";
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
