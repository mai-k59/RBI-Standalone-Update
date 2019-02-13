using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.DAL.MSSQL
{
    class EQUIPMENT_EXTRA_FIELDS_ConnectUtils
    {
        public void add(int EquipmentID, String ObjectField001, String ObjectField002, String ObjectField003, String ObjectField004, String ObjectField005,
                        String ObjectField006, String ObjectField007, String ObjectField008, String ObjectField009, String ObjectField010, String ObjectField011,
                        String ObjectField012, String ObjectField013, String ObjectField014, String ObjectField015, String ObjectField016, String ObjectField017,
                        String ObjectField018, String ObjectField019, String ObjectField020, String ObjectField021, String ObjectField022, String ObjectField023,
                        String ObjectField024, String ObjectField025, String ObjectField026, String ObjectField027, String ObjectField028, String ObjectField029,
                        String ObjectField030, String ObjectField031, String ObjectField032, String ObjectField033, String ObjectField034, String ObjectField035,
                        String ObjectField036, String ObjectField037, String ObjectField038, String ObjectField039, String ObjectField040, String ObjectField041,
                        String ObjectField042, String ObjectField043, String ObjectField044, String ObjectField045, String ObjectField046, String ObjectField047,
                        String ObjectField048, String ObjectField049, String ObjectField050)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] " +
                            " INSERT INTO[dbo].[EQUIPMENT_EXTRA_FIELDS]" +
                            "([EquipmentID]" +
                            ",[ObjectField001]" +
                            ",[ObjectField002]" +
                            ",[ObjectField003]" +
                            ",[ObjectField004]" +
                            ",[ObjectField005]" +
                            ",[ObjectField006]" +
                            ",[ObjectField007]" +
                            ",[ObjectField008]" +
                            ",[ObjectField009]" +
                            ",[ObjectField010]" +
                            ",[ObjectField011]" +
                            ",[ObjectField012]" +
                            ",[ObjectField013]" +
                            ",[ObjectField014]" +
                            ",[ObjectField015]" +
                            ",[ObjectField016]" +
                            ",[ObjectField017]" +
                            ",[ObjectField018]" +
                            ",[ObjectField019]" +
                            ",[ObjectField020]" +
                            ",[ObjectField021]" +
                            ",[ObjectField022]" +
                            ",[ObjectField023]" +
                            ",[ObjectField024]" +
                            ",[ObjectField025]" +
                            ",[ObjectField026]" +
                            ",[ObjectField027]" +
                            ",[ObjectField028]" +
                            ",[ObjectField030]" +
                            ",[ObjectField031]" +
                            ",[ObjectField032]" +
                            ",[ObjectField033]" +
                            ",[ObjectField034]" +
                            ",[ObjectField035]" +
                            ",[ObjectField036]" +
                            ",[ObjectField037]" +
                            ",[ObjectField038]" +
                            ",[ObjectField039]" +
                            ",[ObjectField040]" +
                            ",[ObjectField041]" +
                            ",[ObjectField042]" +
                            ",[ObjectField043]" +
                            ",[ObjectField044]" +
                            ",[ObjectField045]" +
                            ",[ObjectField046]" +
                            ",[ObjectField047]" +
                            ",[ObjectField048]" +
                            ",[ObjectField049]" +
                            ",[ObjectField050])" +
                            "VALUES" +
                             "('" + EquipmentID + "'" +
                            ",'" + ObjectField001 + "'" +
                            ",'" + ObjectField002 + "'" +
                            ",'" + ObjectField003 + "'" +
                            ",'" + ObjectField004 + "'" +
                            ",'" + ObjectField005 + "'" +
                            ",'" + ObjectField006 + "'" +
                            ",'" + ObjectField007 + "'" +
                            ",'" + ObjectField008 + "'" +
                            ",'" + ObjectField009 + "'" +
                            ",'" + ObjectField010 + "'" +
                            ",'" + ObjectField011 + "'" +
                            ",'" + ObjectField012 + "'" +
                            ",'" + ObjectField013 + "'" +
                            ",'" + ObjectField014 + "'" +
                            ",'" + ObjectField015 + "'" +
                            ",'" + ObjectField016 + "'" +
                            ",'" + ObjectField017 + "'" +
                            ",'" + ObjectField018 + "'" +
                            ",'" + ObjectField019 + "'" +
                            ",'" + ObjectField020 + "'" +
                            ",'" + ObjectField021 + "'" +
                            ",'" + ObjectField022 + "'" +
                            ",'" + ObjectField023 + "'" +
                            ",'" + ObjectField024 + "'" +
                            ",'" + ObjectField025 + "'" +
                            ",'" + ObjectField026 + "'" +
                            ",'" + ObjectField027 + "'" +
                            ",'" + ObjectField028 + "'" +
                            ",'" + ObjectField029 + "'" +
                            ",'" + ObjectField030 + "'" +
                            ",'" + ObjectField031 + "'" +
                            ",'" + ObjectField032 + "'" +
                            ",'" + ObjectField033 + "'" +
                            ",'" + ObjectField034 + "'" +
                            ",'" + ObjectField035 + "'" +
                            ",'" + ObjectField036 + "'" +
                            ",'" + ObjectField037 + "'" +
                            ",'" + ObjectField038 + "'" +
                            ",'" + ObjectField039 + "'" +
                            ",'" + ObjectField040 + "'" +
                            ",'" + ObjectField041 + "'" +
                            ",'" + ObjectField042 + "'" +
                            ",'" + ObjectField043 + "'" +
                            ",'" + ObjectField044 + "'" +
                            ",'" + ObjectField045 + "'" +
                            ",'" + ObjectField046 + "'" +
                            ",'" + ObjectField047 + "'" +
                            ",'" + ObjectField048 + "'" +
                            ",'" + ObjectField049 + "'" +
                            ",'" + ObjectField050 + "')";
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
        public void edit(int EquipmentID, String ObjectField001, String ObjectField002, String ObjectField003, String ObjectField004, String ObjectField005,
                        String ObjectField006, String ObjectField007, String ObjectField008, String ObjectField009, String ObjectField010, String ObjectField011,
                        String ObjectField012, String ObjectField013, String ObjectField014, String ObjectField015, String ObjectField016, String ObjectField017,
                        String ObjectField018, String ObjectField019, String ObjectField020, String ObjectField021, String ObjectField022, String ObjectField023,
                        String ObjectField024, String ObjectField025, String ObjectField026, String ObjectField027, String ObjectField028, String ObjectField029,
                        String ObjectField030, String ObjectField031, String ObjectField032, String ObjectField033, String ObjectField034, String ObjectField035,
                        String ObjectField036, String ObjectField037, String ObjectField038, String ObjectField039, String ObjectField040, String ObjectField041,
                        String ObjectField042, String ObjectField043, String ObjectField044, String ObjectField045, String ObjectField046, String ObjectField047,
                        String ObjectField048, String ObjectField049, String ObjectField050)
            {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           " UPDATE[dbo].[EQUIPMENT_EXTRA_FIELDS]" +
                                  "SET[EquipmentID] ='"+EquipmentID+"'" +
                                  ",[ObjectField001] = '"+ObjectField001+"'" +
                                  ",[ObjectField002] = '"+ObjectField002+"'" +
                                  ",[ObjectField003] = '"+ObjectField003+"'" +
                                  ",[ObjectField004] = '"+ObjectField004+"'" +
                                  ",[ObjectField005] = '"+ObjectField005+"'" +
                                  ",[ObjectField006] = '"+ObjectField006+"'" +
                                  ",[ObjectField007] = '"+ObjectField008+"'" +
                                  ",[ObjectField009] = '"+ObjectField009+"'" +
                                  ",[ObjectField010] = '"+ObjectField010+"'" +
                                  ",[ObjectField011] = '"+ObjectField011+"'" +
                                  ",[ObjectField012] = '"+ObjectField012+"'" +
                                  ",[ObjectField013] = '"+ObjectField013+"'" +
                                  ",[ObjectField014] = '"+ObjectField014+"'" +
                                  ",[ObjectField015] = '"+ObjectField015+"'" +
                                  ",[ObjectField016] = '"+ObjectField016+"'" +
                                  ",[ObjectField017] = '"+ObjectField017+"'" +
                                  ",[ObjectField018] = '"+ObjectField018+"'" +
                                  ",[ObjectField020] = '"+ObjectField020+"'" +
                                  ",[ObjectField021] = '"+ObjectField021+"'" +
                                  ",[ObjectField022] = '"+ObjectField022+"'" +
                                  ",[ObjectField023] = '"+ObjectField023+"'" +
                                  ",[ObjectField024] = '"+ObjectField024+"'" +
                                  ",[ObjectField025] = '"+ObjectField025+"'" +
                                  ",[ObjectField026] = '"+ObjectField026+"'" +
                                  ",[ObjectField027] = '"+ObjectField027+"'" +
                                  ",[ObjectField028] = '"+ObjectField028+"'" +
                                  ",[ObjectField029] = '"+ObjectField029+"'" +
                                  ",[ObjectField030] = '"+ObjectField030+"'" +
                                  ",[ObjectField031] = '"+ObjectField031+"'" +
                                  ",[ObjectField032] = '"+ObjectField032+"'" +
                                  ",[ObjectField033] = '"+ObjectField033+"'" +
                                  ",[ObjectField034] = '"+ObjectField034+"'" +
                                  ",[ObjectField035] = '"+ObjectField035+"'" +
                                  ",[ObjectField036] = '"+ObjectField036+"'" +
                                  ",[ObjectField037] = '"+ObjectField037+"'" +
                                  ",[ObjectField038] = '"+ObjectField038+"'" +
                                  ",[ObjectField039] = '"+ObjectField039+"'" +
                                  ",[ObjectField040] = '"+ObjectField040+"'" +
                                  ",[ObjectField041] = '"+ObjectField041+"'" +
                                  ",[ObjectField042] = '"+ObjectField042+"'" +
                                  ",[ObjectField043] = '"+ObjectField043+"'" +
                                  ",[ObjectField044] = '"+ObjectField044+"'" +
                                  ",[ObjectField045] = '"+ObjectField045+"'" +
                                  ",[ObjectField046] = '"+ObjectField046+"'" +
                                  ",[ObjectField047] = '"+ObjectField047+"'" +
                                  ",[ObjectField048] = '"+ObjectField048+"'" +
                                  ",[ObjectField049] = '"+ObjectField049+"'" +
                                  ",[ObjectField050] = '"+ObjectField050+"'" +
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
            String sql = "USE [rbi] DELETE FROM [dbo].[EQUIPMENT_EXTRA_FIELDS] where [EquipmentID]='" + EquipmentID + "'";
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
    }
}
