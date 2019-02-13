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
    class RW_STREAM_ConnectUtils
    {
        public void add(int ID, String AmineSolution, int AqueousOperation, int AqueousShutdown, int ToxicConstituent, int Caustic, float Chloride, float CO3Concentration, int Cyanide, int ExposedToGasAmine, int ExposedToSulphur, String ExposureToAmine, int FlammableFluidID, float FlowRate, int H2S, float H2SInWater, int Hydrogen, float H2SPartialPressure, int Hydrofluoric, int MaterialExposedToClInt, float MaxOperatingPressure, float MaxOperatingTemperature, float MinOperatingPressure, float MinOperatingTemperature, float CriticalExposureTemperature, int ModelFluidID, float NaOHConcentration, int NonFlameToxicFluidID, float ReleaseFluidPercentToxic, String StoragePhase, int ToxicFluidID, float WaterpH, String TankFluidName, float FluidHeight, float FluidLeaveDikePercent, float FluidLeaveDikeRemainOnSitePercent, float FluidGoOffSitePercent)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[RW_STREAM]" +
                           "([ID]" +
                           ",[AmineSolution]" +
                           ",[AqueousOperation]" +
                           ",[AqueousShutdown]" +
                            ",[ToxicConstituent]" +
                           ",[Caustic]" +
                           ",[Chloride]" +
                           ",[CO3Concentration]" +
                           ",[Cyanide]" +
                           ",[ExposedToGasAmine]" +
                           ",[ExposedToSulphur]" +
                           ",[ExposureToAmine]" +
                           ",[FlammableFluidID]" +
                            ",[FlowRate]" +
                           ",[H2S]" +
                            ",[H2SInWater]" +
                           ",[Hydrogen]" +
                           ",[H2SPartialPressure]" +
                           ",[Hydrofluoric]" +
                           ",[MaterialExposedToClInt]" +
                           ",[MaxOperatingPressure]" +
                           ",[MaxOperatingTemperature]" +
                           ",[MinOperatingPressure]" +
                            ",[MinOperatingTemperature]" +
                           ",[CriticalExposureTemperature]" +
                           ",[ModelFluidID]" +
                           ",[NaOHConcentration]" +
                           ",[NonFlameToxicFluidID ]"+
                           ",[ReleaseFluidPercentToxic]" +
                           ",[StoragePhase]" +
                           ",[ToxicFluidID]" +
                           ",[WaterpH]" +
                           ",[TankFluidName]" +
                           ",[FluidHeight]"+
                           ",[FluidLeaveDikePercent]" +
                           ",[FluidLeaveDikeRemainOnSitePercent]" +
                           ",[FluidGoOffSitePercent])" +
                           " VALUES" +
                                 "(  '" + ID + "'" +
                                 ", '" + AmineSolution + "'" +
                                 ", '" + AqueousOperation + "'" +
                                 ", '" + AqueousShutdown + "'" +
                                 ", '" + ToxicConstituent + "'" +
                                 ", '" + Caustic + "'" +
                                ", '" + Chloride + "'" +
                                ", '" + CO3Concentration + "'"+
                                ", '" + Cyanide + "'" +
                                ", '" + ExposedToGasAmine + "'" +
                                ", '" + ExposedToSulphur + "'" +
                                ", '" + ExposureToAmine + "'"+
                                ", '" + FlammableFluidID + "'" +
                                ", '" + FlowRate + "'" +
                                ", '" + H2S + "'" +
                                ", '" + H2SInWater + "'" +
                                ", '" + Hydrogen + "'" +
                                ", '" + H2SPartialPressure + "'" +
                                ", '" + Hydrofluoric + "'" +
                                ", '" + MaterialExposedToClInt + "'"+
                                 ", '" + MaxOperatingPressure + "'" +
                                ", '" + MaxOperatingTemperature + "'" +
                                ", '" + MinOperatingPressure + "'" +
                                ", '" + MinOperatingTemperature + "'" +
                                 ", '" + CriticalExposureTemperature + "'" +
                                ", '" + ModelFluidID + "'" +
                                ", '" + NaOHConcentration + "'"+
                                 ", '" + NonFlameToxicFluidID + "'" +
                                 ", '" + ReleaseFluidPercentToxic + "'" +
                                ", '" + StoragePhase + "'" +
                                 ", '" + ToxicFluidID + "'" +
                                ", '" + WaterpH + "'"+
                                   ", '" + TankFluidName + "'" +
                                ", '" + FluidHeight + "'" +
                                 ", '" + FluidLeaveDikePercent + "'" +
                                 ", '" + FluidLeaveDikeRemainOnSitePercent + "'" +
                                ", '" + FluidGoOffSitePercent + "')";
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
        public void edit( int ID , String AmineSolution , int AqueousOperation , int AqueousShutdown , int ToxicConstituent , int Caustic , float Chloride , float CO3Concentration , int Cyanide , int ExposedToGasAmine , int ExposedToSulphur , String ExposureToAmine , int FlammableFluidID , float FlowRate ,  int H2S , float H2SInWater , int Hydrogen ,  float H2SPartialPressure , int Hydrofluoric , int MaterialExposedToClInt , float MaxOperatingPressure , float MaxOperatingTemperature , float MinOperatingPressure , float MinOperatingTemperature , float CriticalExposureTemperature ,  int ModelFluidID , float NaOHConcentration , int NonFlameToxicFluidID , float ReleaseFluidPercentToxic , String StoragePhase ,  int ToxicFluidID , float WaterpH , String TankFluidName , float FluidHeight , float FluidLeaveDikePercent , float FluidLeaveDikeRemainOnSitePercent , float FluidGoOffSitePercent)
                        
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[RW_STREAM] " +
                              "SET[ID] = '" + ID + "'" +
                              ",[AmineSolution] = '" + AmineSolution + "'" +
                              ",[AqueousOperation] = '" + AqueousOperation + "'" +
                               ",[AqueousShutdown] = '" + AqueousShutdown + "'" +
                                ",[ToxicConstituent] = '" + ToxicConstituent + "'" +
                               ",[Caustic] = '" + Caustic + "'" +
                              ",[Chloride] = '" + Chloride + "'" +
                              ",[CO3Concentration] = '" + CO3Concentration + "'" +
                              ",[Cyanide] = '" + Cyanide + "'" +
                              ",[ExposedToGasAmine] = '" + ExposedToGasAmine + "'" +
                              ",[ExposedToSulphur] = '" + ExposedToSulphur + "'" +
                              ",[ExposureToAmine] = '" + ExposureToAmine + "'" +
                               ",[FlammableFluidID] = '" + FlammableFluidID + "'" +
                              ",[FlowRate] = '" + FlowRate + "'" +
                               ",[H2S] = '" + H2S + "'" +
                                ",[H2SInWater] = '" + H2SInWater + "'" +
                               ",[Hydrogen] = '" + Hydrogen + "'" +
                              ",[H2SPartialPressure] = '" + H2SPartialPressure + "'" +
                              ",[Hydrofluoric] = '" + Hydrofluoric + "'" +
                              ",[MaterialExposedToClInt] = '" + MaterialExposedToClInt + "'" +
                                 ",[MaxOperatingPressure] = '" + MaxOperatingPressure + "'" +
                              ",[MaxOperatingTemperature] = '" + MaxOperatingTemperature + "'" +
                              ",[MinOperatingPressure] = '" + MinOperatingPressure + "'" +
                              ",[MinOperatingTemperature] = '" + MinOperatingTemperature + "'" +
                              ",[CriticalExposureTemperature] = '" + CriticalExposureTemperature + "'" +

                              ",[ModelFluidID] = '" + ModelFluidID + "'" +
                              ",[NaOHConcentration] = '" + NaOHConcentration + "'" +
                              ",[NonFlameToxicFluidID] = '" + NonFlameToxicFluidID + "'" +
                              ",[ReleaseFluidPercentToxic] = '" + ReleaseFluidPercentToxic + "'" +
                              ",[StoragePhase] = '" + StoragePhase + "'" +
                              ",[ToxicFluidID] = '" + ToxicFluidID + "'" +
                              ",[WaterpH] = '" + WaterpH + "'" +
                              ",[TankFluidName] = '" + TankFluidName + "'" +
                               ",[FluidHeight] = '" + FluidHeight + "'" +
                              ",[FluidLeaveDikePercent] = '" + FluidLeaveDikePercent + "'" +
                              ",[FluidLeaveDikeRemainOnSitePercent] = '" + FluidLeaveDikeRemainOnSitePercent + "'" +
                              ",[FluidGoOffSitePercent] = '" + FluidGoOffSitePercent + "'" +
                              
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
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_STREAM] WHERE [ID] = '" + ID + "'";
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
        public List<RW_STREAM> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_STREAM> list = new List<RW_STREAM>();
            RW_STREAM obj = null;
            String sql = "USE [rbi]" +
                        "" +
                        "SELECT [ID]" +
                        ",[AmineSolution]" +
                        ",[AqueousOperation]" +
                        ",[AqueousShutdown]" +
                        ",[ToxicConstituent]" +
                        ",[Caustic]" +
                        ",[Chloride]" +
                        ",[CO3Concentration]" +
                        ",[Cyanide]" +
                        ",[ExposedToGasAmine]" +
                        ",[ExposedToSulphur]" +
                        ",[ExposureToAmine]" +
                        ",[FlammableFluidID]" +
                        ",[FlowRate]" +
                        ",[H2S]" +
                        ",[H2SInWater]" +
                        ",[Hydrogen]" +
                        ",[H2SPartialPressure]" +
                        ",[Hydrofluoric]" +
                        ",[MaterialExposedToClInt]" +
                        ",[MaxOperatingPressure]" +
                        ",[MaxOperatingTemperature]" +
                        ",[MinOperatingPressure]" +
                        ",[MinOperatingTemperature]" +
                        ",[CriticalExposureTemperature]" +
                        ",[ModelFluidID]" +
                        ",[NaOHConcentration]" +
                        ",[NonFlameToxicFluidID]" +
                        ",[ReleaseFluidPercentToxic]" +
                        ",[StoragePhase]" +
                        ",[ToxicFluidID]" +
                        ",[WaterpH]" +
                        ",[TankFluidName]" +
                        ",[FluidHeight]" +
                        ",[FluidLeaveDikePercent]" +
                        ",[FluidLeaveDikeRemainOnSitePercent]" +
                        ",[FluidGoOffSitePercent]" +
                        "  FROM [rbi].[dbo].[RW_STREAM]" +
                        " ";
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
                            obj = new RW_STREAM();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.AmineSolution = reader.GetString(1);
                            }
                            obj.AqueousOperation = reader.GetInt32(2);
                            obj.AqueousShutdown = reader.GetInt32(3);
                            obj.ToxicConstituent = reader.GetInt32(4);
                            obj.Caustic = reader.GetInt32(5);
                            if (!reader.IsDBNull(6))
                            {
                                obj.Chloride = reader.GetFloat(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.CO3Concentration = reader.GetFloat(7);
                            }
                            obj.Cyanide = reader.GetInt32(8);
                            obj.ExposedToGasAmine = reader.GetInt32(9);
                            obj.ExposedToSulphur = reader.GetInt32(10);
                            if (!reader.IsDBNull(11))
                            {
                                obj.ExposureToAmine = reader.GetString(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.FlammableFluidID = reader.GetInt32(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.FlowRate = reader.GetFloat(13);
                            }
                            obj.H2S = reader.GetInt32(14);
                            if (!reader.IsDBNull(15))
                            {
                                obj.H2SInWater = reader.GetFloat(15);
                            }
                            obj.Hydrogen = reader.GetInt32(16);
                            if (!reader.IsDBNull(17))
                            {
                                obj.H2SPartialPressure = reader.GetFloat(17);
                            }

                            obj.Hydrofluoric = reader.GetInt32(18);
                            obj.MaterialExposedToClInt = reader.GetInt32(19);
                            if (!reader.IsDBNull(20))
                            {
                                obj.MaxOperatingPressure = reader.GetFloat(20);
                            }
                            if (!reader.IsDBNull(21))
                            {
                                obj.MaxOperatingTemperature = reader.GetFloat(21);
                            }
                            if (!reader.IsDBNull(22))
                            {
                                obj.MinOperatingPressure = reader.GetFloat(22);
                            }
                            if (!reader.IsDBNull(23))
                            {
                                obj.MinOperatingTemperature = reader.GetFloat(23);
                            }
                            if (!reader.IsDBNull(24))
                            {
                                obj.CriticalExposureTemperature = reader.GetFloat(24);
                            }
                            obj.ModelFluidID = reader.GetInt32(25);
                            if (!reader.IsDBNull(26))
                            {
                                obj.NaOHConcentration = reader.GetFloat(26);
                            }
                            if (!reader.IsDBNull(27))
                            {
                                obj.NonFlameToxicFluidID = reader.GetInt32(27);
                            }
                            if (!reader.IsDBNull(28))
                            {
                                obj.ReleaseFluidPercentToxic = reader.GetFloat(28);
                            }
                            if (!reader.IsDBNull(29))
                            {
                                obj.StoragePhase = reader.GetString(29);
                            }
                            if (!reader.IsDBNull(30))
                            {
                                obj.ToxicFluidID = reader.GetInt32(30);
                            }
                            if (!reader.IsDBNull(31))
                            {
                                obj.WaterpH = reader.GetFloat(31);
                            }
                            if (!reader.IsDBNull(32))
                            {
                                obj.TankFluidName = reader.GetString(32);
                            }
                            if (!reader.IsDBNull(33))
                            {
                                obj.FluidHeight = reader.GetFloat(33);
                            }
                            if (!reader.IsDBNull(34))
                            {
                                obj.FluidLeaveDikePercent = reader.GetFloat(34);
                            }
                            if (!reader.IsDBNull(35))
                            {
                                obj.FluidLeaveDikeRemainOnSitePercent = reader.GetFloat(35);
                            }
                            if (!reader.IsDBNull(36))
                            {
                                obj.FluidGoOffSitePercent = reader.GetFloat(36);
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
        public RW_STREAM getData(int ID)
        {
            RW_STREAM obj = new RW_STREAM();
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "" +
                        "SELECT [ID]" +
                        ",[AmineSolution]" +
                        ",[AqueousOperation]" +
                        ",[AqueousShutdown]" +
                        ",[ToxicConstituent]" +
                        ",[Caustic]" +
                        ",[Chloride]" +
                        ",[CO3Concentration]" +
                        ",[Cyanide]" +
                        ",[ExposedToGasAmine]" +
                        ",[ExposedToSulphur]" +
                        ",[ExposureToAmine]" +
                        ",[FlammableFluidID]" +
                        ",[FlowRate]" +
                        ",[H2S]" +
                        ",[H2SInWater]" +
                        ",[Hydrogen]" +
                        ",[H2SPartialPressure]" +
                        ",[Hydrofluoric]" +
                        ",[MaterialExposedToClInt]" +
                        ",[MaxOperatingPressure]" +
                        ",[MaxOperatingTemperature]" +
                        ",[MinOperatingPressure]" +
                        ",[MinOperatingTemperature]" +
                        ",[CriticalExposureTemperature]" +
                        ",[ModelFluidID]" +
                        ",[NaOHConcentration]" +
                        ",[NonFlameToxicFluidID]" +
                        ",[ReleaseFluidPercentToxic]" +
                        ",[StoragePhase]" +
                        ",[ToxicFluidID]" +
                        ",[WaterpH]" +
                        ",[TankFluidName]" +
                        ",[FluidHeight]" +
                        ",[FluidLeaveDikePercent]" +
                        ",[FluidLeaveDikeRemainOnSitePercent]" +
                        ",[FluidGoOffSitePercent]" +
                        "  FROM [rbi].[dbo].[RW_STREAM] WHERE [ID]='" + ID + "'" +
                        " ";
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
                                obj.AmineSolution = reader.GetString(1);
                            }
                            obj.AqueousOperation = Convert.ToInt32(reader.GetBoolean(2));
                            obj.AqueousShutdown = Convert.ToInt32(reader.GetBoolean(3));
                            obj.ToxicConstituent = Convert.ToInt32(reader.GetBoolean(4));
                            obj.Caustic = Convert.ToInt32(reader.GetBoolean(5));
                            if (!reader.IsDBNull(6))
                            {
                                obj.Chloride = (float)reader.GetDouble(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.CO3Concentration = (float)reader.GetDouble(7);
                            }
                            obj.Cyanide = Convert.ToInt32(reader.GetBoolean(8));
                            obj.ExposedToGasAmine = Convert.ToInt32(reader.GetBoolean(9));
                            obj.ExposedToSulphur = Convert.ToInt32(reader.GetBoolean(10));
                            if (!reader.IsDBNull(11))
                            {
                                obj.ExposureToAmine = reader.GetString(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.FlammableFluidID = reader.GetInt32(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.FlowRate = (float)reader.GetDouble(13);
                            }
                            obj.H2S = Convert.ToInt32(reader.GetBoolean(14));
                            if (!reader.IsDBNull(15))
                            {
                                obj.H2SInWater = (float)reader.GetDouble(15);
                            }
                            obj.Hydrogen = Convert.ToInt32(reader.GetBoolean(16));
                            if (!reader.IsDBNull(17))
                            {
                                obj.H2SPartialPressure = (float)reader.GetDouble(17);
                            }

                            obj.Hydrofluoric = Convert.ToInt32(reader.GetBoolean(18));
                            obj.MaterialExposedToClInt = Convert.ToInt32(reader.GetBoolean(19));
                            if (!reader.IsDBNull(20))
                            {
                                obj.MaxOperatingPressure = (float)reader.GetDouble(20);
                            }
                            if (!reader.IsDBNull(21))
                            {
                                obj.MaxOperatingTemperature = (float)reader.GetDouble(21);
                            }
                            if (!reader.IsDBNull(22))
                            {
                                obj.MinOperatingPressure = (float)reader.GetDouble(22);
                            }
                            if (!reader.IsDBNull(23))
                            {
                                obj.MinOperatingTemperature = (float)reader.GetDouble(23);
                            }
                            if (!reader.IsDBNull(24))
                            {
                                obj.CriticalExposureTemperature = (float)reader.GetDouble(24);
                            }
                            if (!reader.IsDBNull(25))
                            {
                                obj.ModelFluidID = reader.GetInt32(25);
                            }

                            if (!reader.IsDBNull(26))
                            {
                                obj.NaOHConcentration = (float)reader.GetDouble(26);
                            }
                            if (!reader.IsDBNull(27))
                            {
                                obj.NonFlameToxicFluidID = reader.GetInt32(27);
                            }
                            if (!reader.IsDBNull(28))
                            {
                                obj.ReleaseFluidPercentToxic = (float)reader.GetDouble(28);
                            }
                            if (!reader.IsDBNull(29))
                            {
                                obj.StoragePhase = reader.GetString(29);
                            }
                            if (!reader.IsDBNull(30))
                            {
                                obj.ToxicFluidID = reader.GetInt32(30);
                            }
                            if (!reader.IsDBNull(31))
                            {
                                obj.WaterpH = (float)reader.GetDouble(31);
                            }
                            if (!reader.IsDBNull(32))
                            {
                                obj.TankFluidName = reader.GetString(32);
                            }
                            if (!reader.IsDBNull(33))
                            {
                                obj.FluidHeight = (float)reader.GetDouble(33);
                            }
                            if (!reader.IsDBNull(34))
                            {
                                obj.FluidLeaveDikePercent = (float)reader.GetDouble(34);
                            }
                            if (!reader.IsDBNull(35))
                            {
                                obj.FluidLeaveDikeRemainOnSitePercent = (float)reader.GetDouble(35);
                            }
                            if (!reader.IsDBNull(36))
                            {
                                obj.FluidGoOffSitePercent = (float)reader.GetDouble(36);
                            }
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
        public Boolean checkExistStream(int ID)
        {
            Boolean IsExist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select AqueousOperation from rbi.dbo.RW_STREAM where ID = '"+ID+"'";
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
