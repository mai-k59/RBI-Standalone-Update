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
    class RW_CORROSION_RATE_TANK_ConnectUtils
    {
        public void add(int ID, float SoilSideCorrosionRate, float ProductSideCorrosionRate, String PotentialCorrosion,
                        String TankPadMaterial, String TankDrainageType,String CathodicProtectionType,String TankBottomType,String SoilSideTemperature,
                        String ProductCondition,String ProductSideTemp,String SteamCoil,String WaterDrawOff,
                        String ProductSideBottom, float ModifiedSoilSideCorrosionRate, float ModifiedProductSideCorrosionRate, float FinalEstimatedCorrosionRate) 
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[RW_CORROSION_RATE_TANK]" +
                        "([ID]" +
                        ",[SoilSideCorrosionRate]" +
                        ",[ProductSideCorrosionRate]" +
                        ",[PotentialCorrosion]" +
                        ",[TankPadMaterial]" +
                        ",[TankDrainageType]" +
                        ",[CathodicProtectionType]" +
                        ",[TankBottomType]" +
                        ",[SoilSideTemperature]" +
                        ",[ProductCondition]" +
                        ",[ProductSideTemp]" +
                        ",[SteamCoil]" +
                        ",[WaterDrawOff]" +
                        ",[ProductCondition]" +
                        ",[ProductSideTemp]" +
                        ",[ModifiedSoilSideCorrosionRate]" +
                        ",[ModifiedProductSideCorrosionRate]" +
                        ",[FinalEstimatedCorrosionRate])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + SoilSideCorrosionRate + "'" +
                        ",'" + ProductSideCorrosionRate + "'" +
                        ",'" + PotentialCorrosion + "'" +
                        ",'" + TankPadMaterial + "'" +
                        ",'" + TankDrainageType + "'" +
                        ",'" + CathodicProtectionType + "'" +
                        ",'" + TankBottomType + "'" +
                        ",'" + SoilSideTemperature + "'" +
                        ",'" + ProductCondition + "'" +
                        ",'" + ProductSideTemp + "'" +
                        ",'" + SteamCoil + "'" +
                        ",'" + WaterDrawOff + "'" +
                        ",'" + ProductCondition + "'" +
                        ",'" + ProductSideTemp + "'" +
                        ",'" + ModifiedSoilSideCorrosionRate + "'" +
                        ",'" + ModifiedProductSideCorrosionRate + "'" +
                        ",'" + FinalEstimatedCorrosionRate + "')" +
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
        public void edit(int CorrosionID,int ID, float SoilSideCorrosionRate, float ProductSideCorrosionRate, String PotentialCorrosion,
                        String TankPadMaterial, String TankDrainageType,String CathodicProtectionType,String TankBottomType,String SoilSideTemperature,
                        String ProductCondition,String ProductSideTemp,String SteamCoil,String WaterDrawOff,
                        String ProductSideBottom, float ModifiedSoilSideCorrosionRate, float ModifiedProductSideCorrosionRate, float FinalEstimatedCorrosionRate)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_CORROSION_RATE_TANK]" +
                        "SET [CorrosionID] = '" + CorrosionID + "'" +
                        "[ID] = '" + ID + "'" +
                        "[SoilSideCorrosionRate] = '" + SoilSideCorrosionRate + "'" +
                        "[ProductSideCorrosionRate] = '" + ProductSideCorrosionRate + "'" +
                        "[PotentialCorrosion] = '" + PotentialCorrosion + "'" +
                        "[TankPadMaterial] = '" + TankPadMaterial + "'" +
                        "[TankDrainageType] = '" + TankDrainageType + "'" +
                        "[CathodicProtectionType] = '" + CathodicProtectionType + "'" +
                        "[TankBottomType] = '" + TankBottomType + "'" +
                        "[SoilSideTemperature] = '" + SoilSideTemperature + "'" +
                        "[ProductCondition] = '" + ProductCondition + "'" +
                        "[ProductSideTemp] = '" + ProductSideTemp + "'" +
                        "[SteamCoil] = '" + SteamCoil + "'" +
                        "[WaterDrawOff] = '" + WaterDrawOff + "'" +
                        "[ProductSideBottom] = '" + ProductSideBottom + "'" +
                        "[ModifiedSoilSideCorrosionRate] = '" + ModifiedSoilSideCorrosionRate + "'" +
                        "[ModifiedProductSideCorrosionRate] = '" + ModifiedProductSideCorrosionRate + "'" +
                        "[FinalEstimatedCorrosionRate] = '" + FinalEstimatedCorrosionRate + "'" +
                       
                        
                        " WHERE [CorrosionID] ='" + CorrosionID + "' " +
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
        public void delete(int CorrosionID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "DELETE FROM [dbo].[RW_CORROSION_RATE_TANK]" +
                        " WHERE [CorrosionID] ='" + CorrosionID + "'  " +
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
        /// get datasource
        /// 
        public List<RW_CORROSION_RATE_TANK> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_CORROSION_RATE_TANK> list = new List<RW_CORROSION_RATE_TANK>();
            RW_CORROSION_RATE_TANK obj = null;
            String sql = "Use[rbi] Select[ID]" +
                          ",[SoilSideCorrosionRate]" +
                        ",[ProductSideCorrosionRate]" +
                        ",[PotentialCorrosion]" +
                        ",[TankPadMaterial]" +
                        ",[TankDrainageType]" +
                        ",[CathodicProtectionType]" +
                        ",[TankBottomType]" +
                        ",[SoilSideTemperature]" +
                        ",[ProductCondition]" +
                        ",[ProductSideTemp]" +
                        ",[SteamCoil]" +
                        ",[WaterDrawOff]" +
                        ",[ProductCondition]" +
                        ",[ProductSideTemp]" +
                        ",[ModifiedSoilSideCorrosionRate]" +
                        ",[ModifiedProductSideCorrosionRate]" +
                        ",[FinalEstimatedCorrosionRate])" +
                          "From [dbo].[RW_CORROSION]  ";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_CORROSION_RATE_TANK();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.SoilSideCorrosionRate = reader.GetFloat(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.ProductSideCorrosionRate = reader.GetFloat(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.PotentialCorrosion = reader.GetString(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.TankPadMaterial = reader.GetString(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.TankDrainageType = reader.GetString(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.CathodicProtectionType = reader.GetString(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.TankBottomType = reader.GetString(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.SoilSideTemperature = reader.GetString(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.ProductCondition = reader.GetString(9);

                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.ProductSideTemp = reader.GetString(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.SteamCoil = reader.GetString(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.WaterDrawOff = reader.GetString(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.ProductSideBottom = reader.GetString(13);
                            }
                            if (!reader.IsDBNull(14))
                            {
                                obj.ModifiedSoilSideCorrosionRate = reader.GetFloat(14);
                            }
                            if (!reader.IsDBNull(15))
                            {
                                obj.ModifiedSoilSideCorrosionRate = reader.GetFloat(15);
                            }
                            if (!reader.IsDBNull(16))
                            {
                                obj.FinalEstimatedCorrosionRate = reader.GetFloat(16);
                            }
                            list.Add(obj);
                        }
                    }
                }
            }
            catch(Exception e)
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
    }
}
