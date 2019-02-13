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
    class RW_PRIMARY_FLUID_ConnectUtils
    {
        public void add(int ID, String FluidName, float NBP, float MW, float Density, int ChemicalFactor, int HealthDegree, int Flammability, int Reactivity)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[RW_PRIMARY_FLUID]" +
                           "([ID]" +
                           ",[FluidName]" +
                           ",[NBP]" +
                           ",[MW]" +
                            ",[Density]" +
                            ",[ChemicalFactor]" +
                           ",[HealthDegree]" +
                           ",[Flammability]" +
                           ",[Reactivity])" +
                           " VALUES" +
                           "(  '" + ID + "'" +
                            ", '" + FluidName + "'" +
                            ",'" + NBP + "'" +
                            "," + MW + "" +
                            ", '" + Density + "'" +
                            ", '" + ChemicalFactor + "'" +
                           ", '" + HealthDegree + "'" +
                           ", '" + Flammability + "')" ;
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
        public void edit(int ID, String FluidName, float NBP, float MW, float Density, int ChemicalFactor, int HealthDegree, int Flammability, int Reactivity)
                       
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[RW_PRIMARY_FLUID] " +
                              "SET[ID] = '" + ID + "'" +
                              ",[FluidName] = '" + FluidName + "'" +
                              ",[NBP] = '" + NBP + "'" +
                              ",[MW] = '" + MW + "'" +
                              ",[Density] = '" + Density + "'" +
                             ",[ChemicalFactor] = '" + ChemicalFactor + "'" +
                             ",[HealthDegree] = '" + HealthDegree + "'" +
                              ",[Flammability] = '" + Flammability + "'" +
                              ",[Reactivity] = '" + Reactivity + "'" +
                             

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
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_PRIMARY_FLUID] WHERE [ID] = '" + ID + "'";
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
            String sql = "USE [rbi] SELECT * FROM [dbo].[RW_PRIMARY_FLUID] WHERE [ID] = '" + ID + "'";
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
        public List<RW_PRIMARY_FLUID> getDataSource()
        {
            List<RW_PRIMARY_FLUID> list = new List<RW_PRIMARY_FLUID>();
            RW_PRIMARY_FLUID obj = null;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]  " +
                        "SELECT [ID]" +
                        ",[FluidName]" +
                        ",[NBP]" +
                        ",[MW]" +
                        ",[Density]" +
                        ",[ChemicalFactor]" +
                        ",[HealthDegree]" +
                        ",[Flammability]" +
                        ",[Reactivity]" +
                        "  FROM [rbi].[dbo].[RW_PRIMARY_FLUID]" +
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
                            obj = new RW_PRIMARY_FLUID();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.FluidName = reader.GetString(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.NBP = reader.GetFloat(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.MW = reader.GetFloat(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.Density = reader.GetFloat(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.ChemicalFactor = reader.GetInt32(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.HealthDegree = reader.GetInt32(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.Flammability = reader.GetInt32(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.Reactivity = reader.GetInt32(8);
                            }
                            list.Add(obj);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("GET DATA SOURCE FAIL!", "ERROR!");
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
