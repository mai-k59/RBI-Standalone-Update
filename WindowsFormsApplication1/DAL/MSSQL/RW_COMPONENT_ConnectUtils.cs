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
    class RW_COMPONENT_ConnectUtils
    {
        public void add(int ID, double NominalDiameter, double NominalThickness, double CurrentThickness, double MinReqThickness, double CurrentCorrosionRate, String BranchDiameter, String BranchJointType, String BrinnelHardness, int ChemicalInjection, int HighlyInjectionInsp, String ComplexityProtrusion, String CorrectiveAction, int CracksPresent, String CyclicLoadingWitin15_25m, int DamageFoundInspection, float DeltaFATT, String NumberPipeFittings, String PipeCondition, String PreviousFailures, String ShakingAmount, int ShakingDetected, String ShakingTime, int TrampElements, float ShellHeight, int ReleasePreventionBarrier, int ConcreteFoundation, String SeverityOfVibration)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[RW_COMPONENT]" +
                        "([ID]" +
                        ",[NominalDiameter]" +
                        ",[NominalThickness]" +
                        ",[CurrentThickness]" +
                        ",[MinReqThickness]" +
                        ",[CurrentCorrosionRate]" +
                        ",[BranchDiameter]" +
                        ",[BranchJointType]" +
                        ",[BrinnelHardness]" +
                        ",[ChemicalInjection]" +
                        ",[HighlyInjectionInsp]" +
                        ",[ComplexityProtrusion]" +
                        ",[CorrectiveAction]" +
                        ",[CracksPresent]" +
                        ",[CyclicLoadingWitin15_25m]" +
                        ",[DamageFoundInspection]" +
                        ",[DeltaFATT]" +
                        ",[NumberPipeFittings]" +
                        ",[PipeCondition]" +
                        ",[PreviousFailures]" +
                        ",[ShakingAmount]" +
                        ",[ShakingDetected]" +
                        ",[ShakingTime]" +
                        ",[TrampElements]" +
                        ",[ShellHeight]" +
                        ",[ReleasePreventionBarrier]" +
                        ",[ConcreteFoundation]" +
                        ",[SeverityOfVibration])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + NominalDiameter + "'" +
                        ",'" + NominalThickness + "'" +
                        ",'" + CurrentThickness + "'" +
                        ",'" + MinReqThickness + "'" +
                        ",'" + CurrentCorrosionRate + "'" +
                        ",'" + BranchDiameter + "'" +
                        ",'" + BranchJointType + "'" +
                        ",'" + BrinnelHardness + "'" +
                        ",'" + ChemicalInjection + "'" +
                        ",'" + HighlyInjectionInsp + "'" +
                        ",'" + ComplexityProtrusion + "'" +
                        ",'" + CorrectiveAction + "'" +
                        ",'" + CracksPresent + "'" +
                        ",'" + CyclicLoadingWitin15_25m + "'" +
                        ",'" + DamageFoundInspection + "'" +
                        ",'" + DeltaFATT + "'" +
                        ",'" + NumberPipeFittings + "'" +
                        ",'" + PipeCondition + "'" +
                        ",'" + PreviousFailures + "'" +
                        ",'" + ShakingAmount + "'" +
                        ",'" + ShakingDetected + "'" +
                        ",'" + ShakingTime + "'" +
                        ",'" + TrampElements + "'" +
                        ",'" + ShellHeight + "'" +
                        ",'" + ReleasePreventionBarrier + "'" +
                        ",'" + ConcreteFoundation + "'" +
                        ",'" + SeverityOfVibration + "')" +
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
        public void edit(int ID, double NominalDiameter, double NominalThickness, double CurrentThickness, double MinReqThickness, double CurrentCorrosionRate, String BranchDiameter, String BranchJointType, String BrinnelHardness, int ChemicalInjection, int HighlyInjectionInsp, String ComplexityProtrusion, String CorrectiveAction, int CracksPresent, String CyclicLoadingWitin15_25m, int DamageFoundInspection, float DeltaFATT, String NumberPipeFittings, String PipeCondition, String PreviousFailures, String ShakingAmount, int ShakingDetected, String ShakingTime, int TrampElements, float ShellHeight, int ReleasePreventionBarrier, int ConcreteFoundation, String SeverityOfVibration)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_COMPONENT]" +
                        "SET [ID] = '" + ID + "'" +
                        ",[NominalDiameter] = '" + NominalDiameter + "'" +
                        ",[NominalThickness] = '" + NominalThickness + "'" +
                        ",[CurrentThickness] = '" + CurrentThickness + "'" +
                        ",[MinReqThickness] = '" + MinReqThickness + "'" +
                        ",[CurrentCorrosionRate] = '" + CurrentCorrosionRate + "'" +
                        ",[BranchDiameter] = '" + BranchDiameter + "'" +
                        ",[BranchJointType] = '" + BranchJointType + "'" +
                        ",[BrinnelHardness] = '" + BrinnelHardness + "'" +
                        ",[ChemicalInjection] = '" + ChemicalInjection + "'" +
                        ",[HighlyInjectionInsp] = '" + HighlyInjectionInsp + "'" +
                        ",[ComplexityProtrusion] = '" + ComplexityProtrusion + "'" +
                        ",[CorrectiveAction] = '" + CorrectiveAction + "'" +
                        ",[CracksPresent] = '" + CracksPresent + "'" +
                        ",[CyclicLoadingWitin15_25m] = '" + CyclicLoadingWitin15_25m + "'" +
                        ",[DamageFoundInspection] = '" + DamageFoundInspection + "'" +
                        ",[DeltaFATT] = '" + DeltaFATT + "'" +
                        ",[NumberPipeFittings] = '" + NumberPipeFittings + "'" +
                        ",[PipeCondition] = '" + PipeCondition + "'" +
                        ",[PreviousFailures] = '" + PreviousFailures + "'" +
                        ",[ShakingAmount] = '" + ShakingAmount + "'" +
                        ",[ShakingDetected] = '" + ShakingDetected + "'" +
                        ",[ShakingTime] = '" + ShakingTime + "'" +
                        ",[TrampElements] = '" + TrampElements + "'" +
                        ",[ShellHeight] = '" + ShellHeight + "'" +
                        ",[ReleasePreventionBarrier] = '" + ReleasePreventionBarrier + "'" +
                        ",[ConcreteFoundation] = '" + ConcreteFoundation + "'" +
                        ",[SeverityOfVibration] = '" + SeverityOfVibration + "'" +
                        
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
                        "DELETE FROM [dbo].[RW_COMPONENT]" +
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
        public List<RW_COMPONENT> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_COMPONENT> list = new List<RW_COMPONENT>();
            RW_COMPONENT obj = null;
            String sql = " Use [rbi] Select [ID]" +
                          ",[NominalDiameter]" +
                          ",[NominalThickness]" +
                          ",[CurrentThickness]" +
                          ",[MinReqThickness]" +
                          ",[CurrentCorrosionRate]" +
                          ",[BranchDiameter]" +
                          ",[BranchJointType]" +
                          ",[BrinnelHardness]" +
                          ",[ChemicalInjection]" +
                          ",[HighlyInjectionInsp]" +
                          ",[ComplexityProtrusion]" +
                          ",[CorrectiveAction]" +
                          ",[CracksPresent]" +
                          ",[CyclicLoadingWitin15_25m]" +
                          ",[DamageFoundInspection]" +
                          ",[DeltaFATT]" +
                          ",[NumberPipeFittings]" +
                          ",[PipeCondition]" +
                          ",[PreviousFailures]" +
                          ",[ShakingAmount]" +
                          ",[ShakingDetected]" +
                          ",[ShakingTime]" +
                          ",[TrampElements]" +
                          ",[ShellHeight]" +
                          ",[ReleasePreventionBarrier]" +
                          ",[ConcreteFoundation]" +
                          ",[SeverityOfVibration]" +
                          "From [dbo].[RW_COMPONENT]  ";
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
                            obj = new RW_COMPONENT();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.NominalDiameter = (float)reader.GetDouble(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.NominalThickness = (float)reader.GetDouble(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.CurrentThickness = (float)reader.GetDouble(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.MinReqThickness = (float)reader.GetDouble(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.CurrentCorrosionRate = (float)reader.GetDouble(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.BranchDiameter = reader.GetString(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.BranchJointType = reader.GetString(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.BrinnelHardness = reader.GetString(8);
                            }

                            obj.ChemicalInjection = Convert.ToInt32(reader.GetBoolean(9));
                            obj.HighlyInjectionInsp = Convert.ToInt32(reader.GetBoolean(10));
                            if(!reader .IsDBNull (11))
                            {
                                obj.ComplexityProtrusion = reader.GetString(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.CorrectiveAction = reader.GetString(12);
                            }
                            obj.CracksPresent = Convert.ToInt32(reader.GetBoolean(13));
                            if(!reader .IsDBNull (14))
                            {
                                obj.CyclicLoadingWitin15_25m = reader.GetString(14);
                            }
                            obj.DamageFoundInspection = Convert.ToInt32(reader.GetBoolean(15));
                            if (!reader.IsDBNull(16))
                            {
                                obj.DeltaFATT = (float)reader.GetDouble(16);
                            }
                            if (!reader.IsDBNull(17))
                            {
                                obj.NumberPipeFittings = reader.GetString(17);
                            }
                            if (!reader.IsDBNull(18))
                            {
                                obj.PipeCondition = reader.GetString(18);
                            }
                            if (!reader.IsDBNull(19))
                            {
                                obj.PreviousFailures = reader.GetString(19);
                            }
                            if (!reader.IsDBNull(20))
                            {
                                obj.ShakingAmount = reader.GetString(20);
                            }
                            obj.ShakingDetected = Convert.ToInt32(reader.GetBoolean(21));
                            if (!reader.IsDBNull(20))
                            {
                                obj.ShakingTime = reader.GetString(22);
                            }
                            obj.TrampElements = Convert.ToInt32(reader.GetBoolean(23));
                            if(!reader .IsDBNull (24))
                            {
                                obj.ShellHeight = (float)reader.GetDouble(24);
                            }
                            obj.ReleasePreventionBarrier = Convert.ToInt32(reader.GetBoolean(25));
                            obj.ConcreteFoundation = Convert.ToInt32(reader.GetBoolean(26));
                            if(!reader .IsDBNull (27))
                            {
                                obj.SeverityOfVibration = reader.GetString(27);
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
        public Boolean checkExistComponent(int ID)
        {
            Boolean IsExist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select NominalDiameter from rbi.dbo.RW_COMPONENT where ID = '"+ID+"'";
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
        public RW_COMPONENT getData(int ID)
        {
            RW_COMPONENT obj = new RW_COMPONENT();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] SELECT [NominalDiameter]" +
                          ",[NominalThickness]" +
                          ",[CurrentThickness]" +
                          ",[MinReqThickness]" +
                          ",[CurrentCorrosionRate]" +
                          ",[BranchDiameter]" +
                          ",[BranchJointType]" +
                          ",[BrinnelHardness]" +
                          ",[ChemicalInjection]" +
                          ",[HighlyInjectionInsp]" +
                          ",[ComplexityProtrusion]" +
                          ",[CorrectiveAction]" +
                          ",[CracksPresent]" +
                          ",[CyclicLoadingWitin15_25m]" +
                          ",[DamageFoundInspection]" +
                          ",[DeltaFATT]" +
                          ",[NumberPipeFittings]" +
                          ",[PipeCondition]" +
                          ",[PreviousFailures]" +
                          ",[ShakingAmount]" +
                          ",[ShakingDetected]" +
                          ",[ShakingTime]" +
                          ",[TrampElements]" +
                          ",[ShellHeight]" +
                          ",[ReleasePreventionBarrier]" +
                          ",[ConcreteFoundation]" +
                          ",[SeverityOfVibration]" +
                      "FROM [rbi].[dbo].[RW_COMPONENT] WHERE [ID] = '" + ID + "'";
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
                            obj.NominalDiameter = (float)reader.GetDouble(0);
                            obj.NominalThickness = (float)reader.GetDouble(1);
                            obj.CurrentThickness = (float)reader.GetDouble(2);
                            obj.MinReqThickness = (float)reader.GetDouble(3);
                            obj.CurrentCorrosionRate = (float)reader.GetDouble(4);
                            obj.DamageFoundInspection = Convert.ToInt32(reader.GetBoolean(14));
                            obj.BrinnelHardness = reader.GetString(7);
                            obj.CracksPresent = Convert.ToInt32(reader.GetBoolean(12));
                            obj.TrampElements = Convert.ToInt32(reader.GetBoolean(22));
                            obj.ShellHeight = (float)reader.GetDouble(23);
                            obj.ReleasePreventionBarrier = Convert.ToInt32(reader.GetBoolean(24));
                            obj.ComplexityProtrusion = reader.GetString(10);
                            obj.ConcreteFoundation = Convert.ToInt32(reader.GetBoolean(25));
                            obj.SeverityOfVibration = reader.GetString(26);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GET DATA FAIL!" + ex.ToString(), "ERROR!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return obj;
        }
        public string GetComponentNumber(int ID)
        {
            string a = "";
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "SELECT ComponentNumber FROM rbi.dbo.COMPONENT_MASTER WHERE ComponentID = '" + ID + "'";
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
                            a = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GET DATA FAIL!" + ex.ToString(), "ERROR!");
            }
            finally
            {
                conn.Close();

            }
            return a;
        }
    }
}


