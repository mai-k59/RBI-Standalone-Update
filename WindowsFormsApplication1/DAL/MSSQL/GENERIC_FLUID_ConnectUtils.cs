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
    class GENERIC_FLUID_ConnectUtils
    {
        public void add(String GenericFluid,float NBP,float MW,float Density,int ChemicalFactor,int HealthDegree,
                       int Flammability,int Reactivity)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "INSERT INTO [dbo].[GENERIC_FLUID]" +
                            "([GenericFluid]" +
                            ",[NBP]" +
                            ",[MW]" +
                            ",[Density]" +
                            ",[ChemicalFactor]" +
                            ",[HealthDegree]" +
                            ",[Flammability]" +
                            ",[Reactivity])" +
                            "VALUES" +
                            "('" + GenericFluid + "'" +
                            ",'" + NBP + "'" +
                            ",'" + MW + "'" +
                            ",'" + Density + "'" +
                            ",'" + ChemicalFactor + "'" +
                            ",'" + HealthDegree + "'" +
                            ",'" + Flammability + "'" +
                            ",'" + Reactivity + "')";
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
        public void edit(int GenericFluidID, String GenericFluid,float NBP,float MW,float Density,int ChemicalFactor,int HealthDegree,
                       int Flammability,int Reactivity)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                            "UPDATE [dbo].[GENERIC_FLUID]" +
                            "   SET [GenericFluidID] = '" + GenericFluidID + "'" +
                            "      ,[GenericFluid] = '" + GenericFluid + "'" +
                            "      ,[NBP] = '" + NBP + "'" +
                            "      ,[MW] = '" + MW + "'" +
                            "      ,[Density] = '" + Density + "'" +
                            "      ,[ChemicalFactor] = '" + ChemicalFactor + "'" +
                            "      ,[HealthDegree] = '" + HealthDegree + "'" +
                            "      ,[Flammability] = '" + Flammability + "'" +
                            "      ,[Reactivity] = '" + Reactivity + "'" +
                            " WHERE [GenericFluidID] = '" + GenericFluidID + "'";
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
        public void delete(int GenericFluidID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[GENERIC_FLUID] WHERE [GenericFluidID] = '" + GenericFluidID + "'";
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
    
    public List<GENERIC_FLUID> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<GENERIC_FLUID> list = new List<GENERIC_FLUID>();
            GENERIC_FLUID obj = null;
            String sql = " Use [rbi] Select [GenericFluidID]" +                    
                          ",[GenericFluid]" +
                          ",[NBP]" +
                          ",[MW]" +
                          ",[Density]" +
                          ",[ChemicalFactor]" +
                          ",[HealthDegree]" +
                          ",[Flammability]" +
                          ",[Reactivity]" +
                          "From [dbo].[GENERIC_FLUID]";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                { 
                    while(reader .Read())
                    {

                    if (reader.HasRows)
                    {
                        obj = new GENERIC_FLUID();
                        obj.GenericFluidID = reader.GetInt32(0);
                        obj.GenericFluid = reader.GetString(1);
                        if(!reader .IsDBNull(2))
                        {
                        obj.NBP = reader.GetFloat(2);
                        }
                        if(!reader .IsDBNull(3))
                        {
                        obj.MW = reader.GetFloat(3);
                        }
                        if(!reader .IsDBNull(4))
                        {
                        obj.Density = reader.GetFloat(4);
                        }
                        if(!reader .IsDBNull(5))
                        {
                        obj.ChemicalFactor = reader.GetInt32(5);
                        }
                        if(!reader .IsDBNull(6))
                        {
                        obj.HealthDegree = reader.GetInt32(6);
                        }
                        if(!reader .IsDBNull(7))
                        {
                        obj.Flammability = reader.GetInt32(7);
                        }
                        if(!reader .IsDBNull(8))
                        {
                        obj.Reactivity = reader.GetInt32(8);
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


