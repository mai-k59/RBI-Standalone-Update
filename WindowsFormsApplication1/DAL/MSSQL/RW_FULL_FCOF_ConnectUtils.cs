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
    class RW_FULL_FCOF_ConnectUtils
    {
        public void add(int ID, double FCoFValue, String FCoFCategory,int AIL,double envcost,double equipcost,double prodcost, double popdens,double injcost,double FCoFMatrixValue)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[RW_FULL_FCOF]" +
                        "([ID]" +
                        ",[FCoFValue]" +
                        ",[FCoFCategory]" +
                        ",[AIL]" +
                        ",[envcost]" +
                        ",[equipcost]" +
                        ",[prodcost]" +
                        ",[popdens]" +
                        ",[injcost]" +
                        ",[FCoFMatrixValue])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + FCoFValue + "'" +
                        ",'" + FCoFCategory + "'" +
                        ",'" + AIL + "'" +
                        ",'" + envcost + "'" +
                        ",'" + equipcost + "'" +
                        ",'" + prodcost + "'" +
                        ",'" + popdens + "'" +
                        ",'" + injcost + "'" +
                        ",'" + FCoFMatrixValue + "')" +
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
        public void edit(int ID, double FCoFValue, String FCoFCategory, int AIL, double envcost, double equipcost, double prodcost, double popdens, double injcost, double FCoFMatrixValue)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_FULL_FCOF]" +
                        "SET [ID] = '" + ID + "'" +
                        ",[FCoFValue] = '" + FCoFValue + "'" +
                        ",[FCoFCategory] = '" + FCoFCategory + "'" +
                        ",[AIL] = '" + AIL + "'" +
                        ",[envcost] = '" + envcost + "'" +
                        ",[equipcost] = '" + equipcost + "'" +
                        ",[prodcost] = '" + prodcost + "'" +
                        ",[popdens] = '" + popdens + "'" +
                        ",[injcost] = '" + injcost + "'" +
                        ",[FCoFMatrixValue] = '" + FCoFMatrixValue + "'" +
                        
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
                        "DELETE FROM [dbo].[RW_FULL_FCOF]" +
                        " WHERE [ID] ='" + ID + "'" +
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
        /// ge tdatasource
        /// 
        public List<RW_FULL_FCOF> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_FULL_FCOF> list = new List<RW_FULL_FCOF>();
            RW_FULL_FCOF obj = null;
            String sql = " Use [rbi] Select [ID]" +
                        ",[FCoFValue]" +
                        ",[FCoFCategory]" +
                        ",[AIL]" +
                        ",[envcost]" +
                        ",[equipcost]" +
                        ",[prodcost]" +
                        ",[popdens]" +
                        ",[injcost]" +
                        ",[FCoFMatrixValue]" +
                         "From [dbo].[RW_FULL_FCOF]  ";
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
                            obj = new RW_FULL_FCOF();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.FCoFValue = reader.GetFloat(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.FCoFCategory = reader.GetString(2);
                            }
                            obj.AIL = reader.GetInt32(3);
                            if (!reader.IsDBNull(4))
                            {
                                obj.envcost = reader.GetFloat(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.equipcost = reader.GetFloat(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.prodcost = reader.GetFloat(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.popdens = reader.GetFloat(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.injcost = reader.GetFloat(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.FCoFMatrixValue = reader.GetFloat(9);
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
        
        public RW_FULL_FCOF getData(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            RW_FULL_FCOF obj = new RW_FULL_FCOF();
            String sql = "SELECT ID,FCoFValue,FCoFCategory,AIL,envcost,equipcost,prodcost,popdens,injcost, FCoFMatrixValue FROM rbi.dbo.RW_FULL_FCOF WHERE ID = '"+ID+"'";
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
                                obj.FCoFValue = (float)reader.GetDouble(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.FCoFCategory = reader.GetString(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.AIL = Convert.ToInt32(reader.GetBoolean(3));
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.envcost = (float)reader.GetDouble(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.equipcost = (float)reader.GetDouble(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.prodcost = (float)reader.GetDouble(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.popdens = (float)reader.GetDouble(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.injcost = (float)reader.GetDouble(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.FCoFMatrixValue = (float)reader.GetDouble(9);
                            }
                        }
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL !");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return obj;
        }
        public Boolean checkExistFullCoF(int ID)
        {
            Boolean IsExist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select FCoFValue from rbi.dbo.RW_FULL_FCOF where ID = '"+ID+"'";
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
        public float getFCoFValue(int ID)
        {
            float CoF = 0;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select FCoFValue from rbi.dbo.RW_FULL_FCOF where ID = '" + ID + "'";
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
                            CoF = (float)reader.GetDouble(0);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL !");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return CoF;
        }
    }
}
