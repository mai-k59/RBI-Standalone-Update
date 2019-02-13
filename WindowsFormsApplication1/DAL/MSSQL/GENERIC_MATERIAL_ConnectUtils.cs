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
    class GENERIC_MATERIAL_ConnectUtils
    {
        public void add(String MaterialName,float DesignPressure,float DesignTemperature,float MinDesignTemperature,float CorrosionAllowance,
                        float SigmaPhase,String SulfurContent,String HeatTreatment,float ReferenceTemperature,String PTAMaterialCode,String HTHAMaterialCode,
                        int IsPTA,int IsHTHA,int Austenitic,int Temper,int CarbonLowAlloy,int NickelBased,
                        int ChromeMoreEqual12,float CostFactor)
        {
        
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "INSERT INTO [dbo].[GENERIC_FLUID]" +
                            "([MaterialName]" +
                            ",[DesignPressure]" +
                            ",[DesignTemperature]" +
                            ",[MinDesignTemperature]" +
                            ",[CorrosionAllowance]" +
                            ",[SigmaPhase]" +
                            ",[SulfurContent]" +
                            ",[HeatTreatment]" +
                            ",[ReferenceTemperature]" +
                            ",[PTAMaterialCode]" +
                            ",[HTHAMaterialCode]" +
                            ",[IsPTA]" +
                            ",[IsHTHA]" +
                            ",[Austenitic]" +
                            ",[Temper]" +
                            ",[CarbonLowAlloy]" +
                            ",[NickelBased]" +
                            ",[ChromeMoreEqual12]" +
                            ",[CostFactor])" +                          
                            "VALUES" +
                            "('" + MaterialName + "'" +
                            ",'" + DesignPressure + "'" +
                            ",'" + DesignTemperature + "'" +
                            ",'" + MinDesignTemperature + "'" +
                            ",'" + CorrosionAllowance + "'" +
                            ",'" + SigmaPhase + "'" +
                            ",'" + SulfurContent + "'" +
                            ",'" + HeatTreatment + "'" +
                            ",'" + ReferenceTemperature + "'" +
                            ",'" + PTAMaterialCode + "'" +
                            ",'" + HTHAMaterialCode + "'" +
                            ",'" + IsPTA + "'" +
                            ",'" + IsHTHA+ "'" +
                            ",'" + Austenitic + "'" +
                            ",'" + Temper + "'" +
                            ",'" + CarbonLowAlloy + "'" +
                            ",'" + NickelBased + "'" +
                            ",'" + ChromeMoreEqual12 + "'" +
                            ",'" + CostFactor + "')";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
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
        public void edit(int ID,String MaterialName,float DesignPressure,float DesignTemperature,float MinDesignTemperature,float CorrosionAllowance,
                        float SigmaPhase,String SulfurContent,String HeatTreatment,float ReferenceTemperature,String PTAMaterialCode,String HTHAMaterialCode,
                        int IsPTA,int IsHTHA,int Austenitic,int Temper,int CarbonLowAlloy,int NickelBased,
                        int ChromeMoreEqual12,float CostFactor)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "UPDATE [dbo].[GENERIC_MATERIAL]" +
                            "   SET [ID] = '" + ID + "'" +
                            "      ,[MaterialName] = '" + MaterialName + "'" +
                            "      ,[DesignPressure] = '" + DesignPressure + "'" +
                            "      ,[DesignTemperature] = '" + DesignTemperature + "'" +
                            "      ,[MinDesignTemperature] = '" + MinDesignTemperature + "'" +
                            "      ,[CorrosionAllowance] = '" + CorrosionAllowance + "'" +
                            "      ,[SigmaPhase] = '" + SigmaPhase + "'" +
                            "      ,[SulfurContent] = '" + SulfurContent + "'" +
                            "      ,[HeatTreatment] = '" + HeatTreatment + "'" +
                            "      ,[ReferenceTemperature] = '" + ReferenceTemperature + "'" +
                            "      ,[PTAMaterialCode] = '" + PTAMaterialCode + "'" +
                            "      ,[HTHAMaterialCode] = '" + HTHAMaterialCode + "'" +
                            "      ,[IsPTA] = '" + IsPTA + "'" +
                            "      ,[IsHTHA] = '" + IsHTHA + "'" +
                            "      ,[Austenitic] = '" + Austenitic + "'" +
                            "      ,[Temper] = '" + Temper + "'" +
                            "      ,[CarbonLowAlloy] = '" + CarbonLowAlloy + "'" +
                            "      ,[NickelBased] = '" + NickelBased + "'" +
                            "      ,[ChromeMoreEqual12] = '" + ChromeMoreEqual12 + "'" +
                            "      ,[CostFactor] = '" + CostFactor + "'" +
                             " WHERE [ID] = '" + ID + "'";
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
            String sql = "USE [rbi] DELETE FROM [dbo].[GENERIC_MATERIAL] WHERE [ID] = '" + ID + "'";
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
        public List<GENERIC_MATERIAL> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<GENERIC_MATERIAL> list = new List<GENERIC_MATERIAL>();
            GENERIC_MATERIAL obj = null;
            String sql = " Use [rbi] Select [ID]" +     
                            ",[MaterialName]" +
                            ",[DesignPressure]" +
                            ",[DesignTemperature]" +
                            ",[MinDesignTemperature]"+
                            ",[CorrosionAllowance]"+
                            ",[SigmaPhase]"+
                            ",[SulfurContent]"+
                            ",[HeatTreatment]"+
                            ",[ReferenceTemperature]"+
                            ",[PTAMaterialCode]"+
                            ",[HTHAMaterialCode]"+
                            ",[IsPTA]"+
                            ",[IsHTHA]"+
                            ",[Austenitic]"+
                            ",[Temper]"+
                            ",[CarbonLowAlloy]"+
                            ",[NickelBased]"+
                            ",[ChromeMoreEqual12]" +
                            " ,[CostFactor]" +
                          "From [dbo].[GENERIC_MATERIAL]";
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
                            obj = new GENERIC_MATERIAL();
                            obj.ID = reader.GetInt32(0);
                            obj.MaterialName = reader.GetString(1);
                            if (!reader.IsDBNull(2))
                            {
                                obj.DesignPressure = reader.GetFloat(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.DesignTemperature = reader.GetFloat(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.MinDesignTemperature = reader.GetFloat(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.CorrosionAllowance = reader.GetFloat(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.SigmaPhase = reader.GetFloat(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.SulfurContent = reader.GetString(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.HeatTreatment = reader.GetString(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.ReferenceTemperature = reader.GetFloat(9);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.PTAMaterialCode = reader.GetString(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.HTHAMaterialCode = reader.GetString(11);
                            }
                            obj.IsPTA = reader.GetInt32(12);
                            obj.IsHTHA = reader.GetInt32(13);
                            obj.Austenitic = reader.GetInt32(14);
                            obj.Temper = reader.GetInt32(15);
                            obj.CarbonLowAlloy = reader.GetInt32(16);
                            obj.NickelBased = reader.GetInt32(17);
                            obj.ChromeMoreEqual12 = reader.GetInt32(18);
                            
                            if (!reader .IsDBNull(20))
                            {
                                obj.CostFactor = reader.GetFloat(20);
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

    }
}



                           

        

                           
       