using RBI.DAL.MSSQL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object.ObjectMSSQL_CAL;

namespace RBI.DAL.MSSQL_CAL
{
    class MSSQL_RBI_CAL_ConnUtils
    {
        SqlConnection conn = null;

        // get all data from TBL_52
        public float[] GET_TBL_52(String fluid)
        {
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            float[] data = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            String sql = "USE [rbi] SELECT [MW],[Density],[NBP],[ideal],[A],[B],[C],[D],[E],[Auto] FROM [dbo].[TBL_52_CA_PROPERTIES_LEVEL_1] WHERE [Fluid] = '" + fluid + "'";
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
                            data[0] = (float)reader.GetDouble(0);
                            data[1] = (float)reader.GetDouble(1);
                            data[2] = (float)reader.GetDouble(2);
                            data[3] = reader.GetInt32(3);
                            data[4] = (float)reader.GetDouble(4);
                            data[5] = (float)reader.GetDouble(5);
                            data[6] = (float)reader.GetDouble(6);
                            data[7] = (float)reader.GetDouble(7);
                            data[8] = (float)reader.GetDouble(8);
                            data[9] = (float)reader.GetDouble(9);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("GET TBL_52 FAIL! " + e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        public String GET_RELEASE_PHASE(String fluid)
        {
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String data = null;
            String sql = "USE [rbi] SELECT [Ambient] FROM [dbo].[TBL_52_CA_PROPERTIES_LEVEL_1] WHERE [Fluid] = '" + fluid + "'";
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
                            data = reader.GetString(0);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET TBL_52 FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get all data from TBL_58
        public float[] GET_TBL_58(String fluid)
        {
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            float[] data = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            String sql = "USE [rbi] " +
                          "SELECT [CAINL_gas_a]" +
                          ",[CAINL_gas_b]" +
                          ",[CAINL_liquid_a]" +
                          ",[CAINL_liquid_b]" +
                          ",[CAIL_gas_a]" +
                          ",[CAIL_gas_b]" +
                          ",[CAIL_liquid_a]" +
                          ",[CAIL_liquid_b]" +
                          ",[IAINL_gas_a]" +
                          ",[IAINL_gas_b]" +
                          ",[IAINL_liquid_a]" +
                          ",[IAINL_liquid_b]" +
                          ",[IAIL_gas_a]" +
                          ",[IAIL_gas_b]" +
                          ",[IAIL_liquid_a]" +
                          ",[IAIL_liquid_b]" +
                        "  FROM [rbi].[dbo].[TBL_58_CA_COMPONENT_DM] WHERE [Fluid] = '" + fluid + "'";
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
                            data[0] = (float)reader.GetDouble(0);
                            data[1] = (float)reader.GetDouble(1);
                            data[2] = (float)reader.GetDouble(2);
                            data[3] = (float)reader.GetDouble(3);
                            data[4] = (float)reader.GetDouble(4);
                            data[5] = (float)reader.GetDouble(5);
                            data[6] = (float)reader.GetDouble(6);
                            data[7] = (float)reader.GetDouble(7);
                            data[8] = (float)reader.GetDouble(8);
                            data[9] = (float)reader.GetDouble(9);
                            data[10] = (float)reader.GetDouble(10);
                            data[11] = (float)reader.GetDouble(11);
                            data[12] = (float)reader.GetDouble(12);
                            data[13] = (float)reader.GetDouble(13);
                            data[14] = (float)reader.GetDouble(14);
                            data[15] = (float)reader.GetDouble(15);
                        }
                    }
                }
                for (int i = 0; i < 15; i++)
                {
                    if (data[i] == 0)
                    {
                        data[i] = 1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA TBL_58 FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get all data from TBL_59
        public float[] GET_TBL_59(String fluid)
        {
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            float[] data = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            String sql = "USE [rbi] " +
                        "SELECT [CAINL_gas_a]" +
                        ",[CAINL_gas_b]" +
                        ",[CAINL_liquid_a]" +
                        ",[CAINL_liquid_b]" +
                        ",[CALL_gas_a]" +
                        ",[CALL_gas_b]" +
                        ",[CALL_liquid_a]" +
                        ",[CALL_liquid_b]" +
                        ",[IAINL_gas_a]" +
                        ",[IAINL_gas_b]" +
                        ",[IAINL_liquid_a]" +
                        ",[IAINL_liquid_b]" +
                        ",[IAIL_gas_a]" +
                        ",[IAIL_gas_b]" +
                        ",[IAIL_liquid_a]" +
                        ",[IAIL_liquid_b]" +
                        "  FROM [rbi].[dbo].[TBL_59_COMPONENT_DAMAGE_PERSON] WHERE [Fluid] = '" + fluid + "'";
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
                            data[0] = (float)reader.GetDouble(0);
                            data[1] = (float)reader.GetDouble(1);
                            data[2] = (float)reader.GetDouble(2);
                            data[3] = (float)reader.GetDouble(3);
                            data[4] = (float)reader.GetDouble(4);
                            data[5] = (float)reader.GetDouble(5);
                            data[6] = (float)reader.GetDouble(6);
                            data[7] = (float)reader.GetDouble(7);
                            data[8] = (float)reader.GetDouble(8);
                            data[9] = (float)reader.GetDouble(9);
                            data[10] = (float)reader.GetDouble(10);
                            data[11] = (float)reader.GetDouble(11);
                            data[12] = (float)reader.GetDouble(12);
                            data[13] = (float)reader.GetDouble(13);
                            data[14] = (float)reader.GetDouble(14);
                            data[15] = (float)reader.GetDouble(15);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA TBL_59 FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get all data from TBL_213
        public float[] GET_TBL_213(float thickness)
        {
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            float[] data = { 0, 0, 0, 0 };
            String sql = "USE [rbi]" +
                        "SELECT [CurveA]" +
                        ",[CurveB]" +
                        ",[CurveC]" +
                        ",[CurveD]" +
                        "  FROM [rbi].[dbo].[TBL_213_DM_IMPACT_EXEMPTION] WHERE [ComponentThickness] = '" + thickness + "'";
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
                            data[0] = (float)reader.GetDouble(0);
                            data[1] = (float)reader.GetDouble(1);
                            data[2] = (float)reader.GetDouble(2);
                            data[3] = (float)reader.GetDouble(3);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA 213 FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get all data from TBL_204
        public int[] GET_TBL_204(String susceptibility)
        {
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            int[] data = { 0, 0, 0, 0, 0, 0, 0 };
            String sql = "USE [rbi] " +
                        "SELECT[No Inspection]" +
                        ",[1D]" +
                        ",[1C]" +
                        ",[1B]" +
                        ",[2D]" +
                        ",[2C]" +
                        ",[2B]" +
                        "  FROM [rbi].[dbo].[TBL_204_DM_HTHA] WHERE  [Susceptibility] = '" + susceptibility + "'";
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
                            data[0] = reader.GetInt32(0);
                            data[1] = reader.GetInt32(1);
                            data[2] = reader.GetInt32(2);
                            data[3] = reader.GetInt32(3);
                            data[4] = reader.GetInt32(4);
                            data[5] = reader.GetInt32(5);
                            data[6] = reader.GetInt32(6);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET TBL_204 FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get data from TBL_214
        public float GET_TBL_214(float DeltaT, float Size)
        {
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            float data = 0;
            String sql = "USE [rbi] SELECT [" + Size + "] FROM[rbi].[dbo].[TBL_214_DM_NOT_PWHT] WHERE [Tmin-Tref] = '" + DeltaT + "'";
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
                            data = (float)reader.GetDouble(0);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA TBL_214 FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get data from TBL_215
        public float GET_TBL_215(float DeltaT, float Size)
        {
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            float data = 0;
            String sql = "USE [rbi] SELECT [" + Size + "] FROM[rbi].[dbo].[TBL_215_DM_PWHT] WHERE [Tmin-Tref] = '" + DeltaT + "'";
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
                            data = (float)reader.GetDouble(0);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET TBL_215 FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        public List<TOXIC_511_512> GET_TBL_511_512()
        {
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi] SELECT * FROM [rbi].[dbo].[TBL_511_512_CA_GAS_TOXIC]";
            List<TOXIC_511_512> list = new List<TOXIC_511_512>();
            TOXIC_511_512 obj = null;
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
                            obj = new TOXIC_511_512();
                            obj.ToxicName = reader.GetString(0);
                            obj.ReleaseDuration = reader.GetString(1);
                            obj.a = (float)reader.GetDouble(2);
                            obj.b = (float)reader.GetDouble(3);
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA TOXIC FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public List<TOXIC_513> GET_TBL_513()
        {
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<TOXIC_513> list = new List<TOXIC_513>();
            TOXIC_513 obj = null;
            String sql = "USE[rbi] SELECT * FROM [rbi].[dbo].[TBL_513_CA_TOXIC]";
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
                            obj = new TOXIC_513();
                            obj.TOXIC_NAME = reader.GetString(0);
                            obj.TOXIC_TYPE = reader.GetString(1);
                            obj.DURATION = reader.GetString(2);
                            obj.a = (float)reader.GetDouble(3);
                            obj.b = (float)reader.GetDouble(4);
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA TOXIC FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        // get DATA FROM TBL_511
        public int GET_TBL_511(float ART, int INSP, String Effective)
        {
            int data = 0;
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = null;
            if (Effective == "E")
            {
                sql = "USE[rbi] SELECT [E] FROM [rbi].[dbo].[TBL_511_DFB_THIN] WHERE [art] ='" + ART + "'";
            }
            else
            {
                sql = "USE[rbi] SELECT [" + Effective + "] FROM [rbi].[dbo].[TBL_511_DFB_THIN] WHERE [art] ='" + ART + "' AND [insp] = '" + INSP + "'";
            }
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
                            data = reader.GetInt32(0);
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("GET DF_THIN FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get DATA FROM TBL_512
        public int GET_TBL_512(double ART, String Effective)
        {
            int data = 0;
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi] SELECT [" + Effective + "] FROM [rbi].[dbo].[TBL_512_DFB_THIN_TANK_BOTTOM] WHERE [art] ='" + ART + "'";
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
                            data = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DF_THIN FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get DATA FROM TBL_64
        public float GET_TBL_64(int YEAR, String SUSCEP)
        {
            float data = 0;
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi] SELECT [" + SUSCEP + "] FROM [rbi].[dbo].[TBL_64_DM_LINNING_INORGANIC] WHERE [YearsSinceLastInspection] = '" + YEAR + "'";
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
                            data = (float)reader.GetDouble(0);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                //MessageBox.Show("GET DF_LIN FAIL! "+e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get DATA FROM TBL_65
        public float GET_TBL_65(int YEAR, String SUSCEP)
        {
            float data = 0;
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "SELECT "+SUSCEP+" FROM dbo.TBL_65_DM_LINNING_ORGANIC WHERE YearInService = '"+YEAR+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                        data = (float)reader.GetDouble(0);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"GET DF_LIN FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get DATA FROM TBL_74
        public int GET_TBL_74(int SVI, String FIELD)
        {
            int data = 1;
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi] SELECT [" + FIELD + "] FROM [dbo].[TBL_74_SCC_DM_PWHT] WHERE [SVI] ='" + SVI + "'";
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
                            data = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA TBL_74 FAIL");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get DATA TBL_3B21_SI
        public float GET_TBL_3B21(int ConversionFactor)
        {
            float data = 1;
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi] SELECT [SIUnits] FROM [dbo].[TBL_3B21_SI_CONVERSION] WHERE [conversionFactory] = '" + ConversionFactor + "'";
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
                            data = (float)reader.GetDouble(0);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET SI DATA FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get DATA TBL_71_PROPERTIES
        public float[] GET_TBL_71_PROPERTIES(String FluidTank)
        {
            float[] data = { 0, 0, 0 };
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi] SELECT [Molecular Weight],[Liquid Density],[Liquid Density Viscosity] FROM [dbo].[TBL_71_PROPERTIES_STORAGE_TANK] WHERE [Fluid]='" + FluidTank + "'";
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
                            data[0] = (float)reader.GetDouble(0);
                            data[1] = (float)reader.GetDouble(1);
                            data[2] = (float)reader.GetDouble(2);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA TBL_71 FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get DATA TBL_72
        public float[] GET_TBL_72_SOIL(String SOIL_TYPE)
        {
            float[] data = { 0, 0, 0 };
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE[rbi] SELECT [Hydraulic Conductivity for Water Lower Bound (in s)],[Hydraulic Conductivity for Water Upper Bound (in s)],[Soil Porosity] FROM [rbi].[dbo].[TBL_72_SOIL_TYPE_AND_PROPERTIES_ATMOSPHERIC] WHERE [Soil Type] = '" + SOIL_TYPE + "'";
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
                            data[0] = (float)reader.GetDouble(0);
                            data[1] = (float)reader.GetDouble(1);
                            data[2] = (float)reader.GetDouble(2);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA TBL_72 FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
        // get DATA TBL_76
        public List<float> GET_TBL_76(string ENVIRON_SENSI)
        {
            List<float> data = new List<float>();
            conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String SQL = "USE [rbi] SELECT [" + ENVIRON_SENSI + "] FROM [dbo].[TBL_76_PARAMETER_EVIRON_SENSITIVITY]";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            data.Add((float)reader.GetDouble(0));
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA TBL_76 FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return data;
        }
    }
}
