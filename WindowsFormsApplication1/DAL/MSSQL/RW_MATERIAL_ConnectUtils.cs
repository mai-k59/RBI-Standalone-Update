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
    class RW_MATERIAL_ConnectUtils
    {
        public void add(int ID, String MaterialName, float DesignPressure, float DesignTemperature, float MinDesignTemperature,float BrittleFractureThickness, float CorrosionAllowance, float SigmaPhase, String SulfurContent, String HeatTreatment, float ReferenceTemperature, String PTAMaterialCode, String HTHAMaterialCode, int IsPTA, int IsHTHA, int Austenitic,int Temper,int CarbonLowAlloy, int NickelBased,int ChromeMoreEqual12,float AllowableStress,float CostFactor)
                       
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[RW_MATERIAL]" +
                           "([ID]" +
                           ",[MaterialName]" +
                           ",[DesignPressure]" +
                           ",[DesignTemperature]" +
                            ",[MinDesignTemperature]" +
                            ",[BrittleFractureThickness]" +
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
                           ",[AllowableStress]" +
                           ",[CostFactor])"+
                           " VALUES" +
                           "(  '" + ID + "'" +
                            ", '" + MaterialName + "'" +
                            ",'" + DesignPressure + "'" +
                            "," + DesignTemperature + "" +
                             ", '" + MinDesignTemperature + "'" +
                             ", '" + BrittleFractureThickness + "'" +
                           ", '" + CorrosionAllowance + "'" +
                           ", '" + SigmaPhase + "'" +
                           ", '" + SulfurContent + "'" +
                          ",'" + HeatTreatment + "'" +
                              ", '" + ReferenceTemperature + "'" +
                           ", '" + PTAMaterialCode + "'" +
                           ", '" + HTHAMaterialCode + "'" +
                          ",'" + IsPTA + "'" +
                            ", '" + IsHTHA + "'" +
                         ", '" + Austenitic + "'" +
                               ", '" + Temper + "'" +
                         ", '" + CarbonLowAlloy + "'" +
                            ", '" + NickelBased + "'" +
                           ", '" + ChromeMoreEqual12 + "'" +
                           ", '" + AllowableStress + "'"+
                            ",'"+ CostFactor + "')";
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
        public void edit(int ID, String MaterialName, float DesignPressure, float DesignTemperature, float MinDesignTemperature, float BrittleFractureThickness, float CorrosionAllowance, float SigmaPhase, String SulfurContent, String HeatTreatment, float ReferenceTemperature, String PTAMaterialCode, String HTHAMaterialCode, int IsPTA, int IsHTHA, int Austenitic, int Temper, int CarbonLowAlloy, int NickelBased,int ChromeMoreEqual12, float AllowableStress, float CostFactor)
                        
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[RW_MATERIAL] " +
                              "SET[ID] = '" + ID + "'" +
                              ",[MaterialName] = '" + MaterialName + "'" +
                              ",[DesignPressure] = '" + DesignPressure + "'" +
                              ",[DesignTemperature] = '" + DesignTemperature + "'" +
                              ",[MinDesignTemperature] = '" + MinDesignTemperature + "'" +
                             ",[BrittleFractureThickness] = '" + BrittleFractureThickness + "'" +
                             ",[CorrosionAllowance] = '" + CorrosionAllowance + "'" +
                              ",[SigmaPhase] = '" + SigmaPhase + "'" +
                              ",[SulfurContent] = '" + SulfurContent + "'" +
                              ",[HeatTreatment] = '" + HeatTreatment + "'" +
                              ",[ReferenceTemperature] = '" + ReferenceTemperature + "'" +
                              ",[PTAMaterialCode] = '" + PTAMaterialCode + "'" +
                             ",[HTHAMaterialCode] = '" + HTHAMaterialCode + "'" +
                             ",[IsPTA] = '" + IsPTA + "'" +
                              ",[IsHTHA] = '" + IsHTHA + "'" +
                              ",[Austenitic] = '" + Austenitic + "'" +
                              ",[Temper] = '" + Temper + "'" +
                              ",[CarbonLowAlloy]='"+CarbonLowAlloy+"'"+
                              ",[NickelBased]='"+NickelBased+"'"+
                              ",[ChromeMoreEqual12]='"+ ChromeMoreEqual12 +"'"+
                              ",[AllowableStress]='" + AllowableStress + "'" +
                              ",[CostFactor]='" + CostFactor + "'" +
                              " WHERE [ID] = '" + ID + "'";
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
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
        }

        public void delete(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_MATERIAL] WHERE [ID] = '" + ID + "'";
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

        // dung file get data
        // dung file get list( data source)
        public Boolean isExist(int ID)
        {
            Boolean exist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] SELECT * FROM [dbo].[RW_MATERIAL] WHERE [ID] = '" + ID + "'";
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
                            exist = true;
                        }
                    }
                }
            }
            catch 
            {
               
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return exist;
        }
        public List<RW_MATERIAL> getDataSource()
        {
            List<RW_MATERIAL> list = new List<RW_MATERIAL>();
            RW_MATERIAL obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]  SELECT [ID]"+
                        ",[MaterialName]" +
                        ",[DesignPressure]" +
                        ",[DesignTemperature]" +
                        ",[MinDesignTemperature]" +
                        ",[BrittleFractureThickness]" +
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
                        ",[AllowableStress]" +
                        ",[CostFactor]" +
                        "FROM [dbo].[RW_MATERIAL] ";
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
                            obj = new RW_MATERIAL();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.MaterialName = reader.GetString(1);
                            }
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
                                obj.BrittleFractureThickness = reader.GetFloat(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.CorrosionAllowance = reader.GetFloat(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.SigmaPhase = reader.GetFloat(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.SulfurContent = reader.GetString(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.HeatTreatment = reader.GetString(9);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.ReferenceTemperature = reader.GetFloat(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.PTAMaterialCode = reader.GetString(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.HTHAMaterialCode = reader.GetString(12);
                            }
                            obj.IsPTA = reader.GetInt32(13);
                            obj.IsHTHA = reader.GetInt32(14);
                            obj.Austenitic = reader.GetInt32(15);
                            obj.Temper = reader.GetInt32(16);
                            obj.CarbonLowAlloy = reader.GetInt32(17);
                            obj.NickelBased = reader.GetInt32(18);
                            obj.ChromeMoreEqual12 = reader.GetInt32(19);
                            obj.AllowableStress = reader.GetFloat(20);
                            obj.CostFactor = reader.GetFloat(21);
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA SOURCE FAIL!","ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public RW_MATERIAL getData(int id)
        {
            RW_MATERIAL obj = new RW_MATERIAL();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]  SELECT [ID]" +
                        ",[MaterialName]" +
                        ",[DesignPressure]" +
                        ",[DesignTemperature]" +
                        ",[MinDesignTemperature]" +
                        ",[BrittleFractureThickness]" +
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
                        ",[AllowableStress]" +
                        ",[CostFactor]" +
                        "FROM [dbo].[RW_MATERIAL] WHERE [ID] = '" + id + "'";
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
                            if (!reader.IsDBNull(1))
                            {
                                obj.MaterialName = reader.GetString(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.DesignPressure = (float)reader.GetDouble(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.DesignTemperature = (float)reader.GetDouble(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.MinDesignTemperature = (float)reader.GetDouble(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.BrittleFractureThickness = (float)reader.GetDouble(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.CorrosionAllowance = (float)reader.GetDouble(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.SigmaPhase = (float)reader.GetDouble(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.SulfurContent = reader.GetString(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.HeatTreatment = reader.GetString(9);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.ReferenceTemperature = (float)reader.GetDouble(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.PTAMaterialCode = reader.GetString(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.HTHAMaterialCode = reader.GetString(12);
                            }
                            obj.IsPTA = Convert.ToInt32(reader.GetBoolean(13));
                            obj.IsHTHA = Convert.ToInt32(reader.GetBoolean(14));
                            obj.Austenitic = Convert.ToInt32(reader.GetBoolean(15));
                            obj.Temper = Convert.ToInt32(reader.GetBoolean(16));
                            obj.CarbonLowAlloy = Convert.ToInt32(reader.GetBoolean(17));
                            obj.NickelBased = Convert.ToInt32(reader.GetBoolean(18));
                            obj.ChromeMoreEqual12 = Convert.ToInt32(reader.GetBoolean(19));
                            obj.AllowableStress = (float)reader.GetDouble(20);
                            obj.CostFactor = (float)reader.GetDouble(21);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("GET DATA SOURCE FAIL!" + ex.ToString(), "ERROR!");
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
