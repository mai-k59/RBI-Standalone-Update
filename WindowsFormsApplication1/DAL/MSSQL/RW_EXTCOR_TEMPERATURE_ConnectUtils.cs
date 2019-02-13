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
    class RW_EXTCOR_TEMPERATURE_ConnectUtils
    {
        public void add(int ID, double Minus12ToMinus8, double Minus8ToPlus6, double Plus6ToPlus32, double Plus32ToPlus71, double Plus71ToPlus107, double Plus107ToPlus121, double Plus121ToPlus135, double Plus135ToPlus162, double Plus162ToPlus176, double MoreThanPlus176)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "INSERT INTO [dbo].[RW_EXTCOR_TEMPERATURE]" +
                        "([ID]" +
                        ",[Minus12ToMinus8]" +
                        ",[Minus8ToPlus6]" +
                        ",[Plus6ToPlus32]" +
                        ",[Plus32ToPlus71]" +
                        ",[Plus71ToPlus107]" +
                        ",[Plus107ToPlus121]" +
                        ",[Plus121ToPlus135]" +
                        ",[Plus135ToPlus162]" +
                        ",[Plus162ToPlus176]" +
                        ",[MoreThanPlus176])" +
                        "VALUES" +
                        "('" + ID + "'" +
                        ",'" + Minus12ToMinus8 + "'" +
                        ",'" + Minus8ToPlus6 + "'" +
                        ",'" + Plus6ToPlus32 + "'" +
                        ",'" + Plus32ToPlus71 + "'" +
                        ",'" + Plus71ToPlus107 + "'" +
                        ",'" + Plus107ToPlus121 + "'" +
                        ",'" + Plus121ToPlus135 + "'" +
                        ",'" + Plus135ToPlus162 + "'" +
                        ",'" + Plus162ToPlus176 + "'" +
                        ",'" + MoreThanPlus176 + "')" +
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
        public void edit(int ID, double Minus12ToMinus8, double Minus8ToPlus6, double Plus6ToPlus32, double Plus32ToPlus71, double Plus71ToPlus107, double Plus107ToPlus121, double Plus121ToPlus135, double Plus135ToPlus162, double Plus162ToPlus176, double MoreThanPlus176)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        " " +
                        "UPDATE [dbo].[RW_EXTCOR_TEMPERATURE]" +
                        "SET [ID] = '" + ID + "'" +
                        ",[Minus12ToMinus8] = '" + Minus12ToMinus8 + "'" +
                        ",[Minus8ToPlus6] = '" + Minus8ToPlus6 + "'" +
                        ",[Plus6ToPlus32] = '" + Plus6ToPlus32 + "'" +
                        ",[Plus32ToPlus71] = '" + Plus32ToPlus71 + "'" +
                        ",[Plus71ToPlus107] = '" + Plus71ToPlus107 + "'" +
                        ",[Plus107ToPlus121] = '" + Plus107ToPlus121 + "'" +
                        ",[Plus121ToPlus135] = '" + Plus121ToPlus135 + "'" +
                        ",[Plus135ToPlus162] = '" + Plus135ToPlus162 + "'" +
                        ",[Plus162ToPlus176] = '" + Plus162ToPlus176 + "'" +
                        ",[MoreThanPlus176] = '" + MoreThanPlus176 + "'" +
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
                        "DELETE FROM [dbo].[RW_EXTCOR_TEMPERATURE]" +
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
        //get datasoure
        public List<RW_EXTCOR_TEMPERATURE> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_EXTCOR_TEMPERATURE> list = new List<RW_EXTCOR_TEMPERATURE>();
            RW_EXTCOR_TEMPERATURE obj = null;
            String sql = "Use[rbi] Select[ID]" +
                           ",[Minus12ToMinus8]" +
                        ",[Minus8ToPlus6]" +
                        ",[Plus6ToPlus32]" +
                        ",[Plus32ToPlus71]" +
                        ",[Plus71ToPlus107]" +
                        ",[Plus107ToPlus121]" +
                        ",[Plus121ToPlus135]" +
                        ",[Plus135ToPlus162]" +
                        ",[Plus162ToPlus176]" +
                        ",[MoreThanPlus176]" +
                          "From [dbo].[RW_EXTCOR_TEMPERATURE]";
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
                            obj = new RW_EXTCOR_TEMPERATURE();
                            obj.ID = reader.GetInt32(0);
                            if (!reader.IsDBNull(1))
                            {
                                obj.Minus12ToMinus8 = (float)reader.GetDouble(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.Plus6ToPlus32 = (float)reader.GetDouble(3);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.Plus32ToPlus71 = (float)reader.GetDouble(4);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.Plus71ToPlus107 = (float)reader.GetDouble(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.Plus107ToPlus121 = (float)reader.GetDouble(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.Plus121ToPlus135 = (float)reader.GetDouble(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.Plus135ToPlus162 = (float)reader.GetDouble(7);

                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.Plus162ToPlus176 = (float)reader.GetDouble(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.MoreThanPlus176 = (float)reader.GetDouble(9);
                            }
                            list.Add(obj);
                        }

                    }
                }
            }
            catch (Exception e)
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
        public RW_EXTCOR_TEMPERATURE getData(int ID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            RW_EXTCOR_TEMPERATURE obj = new RW_EXTCOR_TEMPERATURE();
            String sql = "Use[rbi] Select[ID]" +
                        ",[Minus12ToMinus8]" +
                        ",[Minus8ToPlus6]" +
                        ",[Plus6ToPlus32]" +
                        ",[Plus32ToPlus71]" +
                        ",[Plus71ToPlus107]" +
                        ",[Plus107ToPlus121]" +
                        ",[Plus121ToPlus135]" +
                        ",[Plus135ToPlus162]" +
                        ",[Plus162ToPlus176]" +
                        ",[MoreThanPlus176]" +
                          "From [dbo].[RW_EXTCOR_TEMPERATURE] WHERE [ID] ='" + ID + "' ";
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
                                obj.Minus12ToMinus8 = (float)reader.GetDouble(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                obj.Minus8ToPlus6 = (float)reader.GetDouble(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.Plus6ToPlus32 = (float)reader.GetDouble(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.Plus32ToPlus71 = (float)reader.GetDouble(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.Plus71ToPlus107 = (float)reader.GetDouble(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.Plus107ToPlus121 = (float)reader.GetDouble(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.Plus121ToPlus135 = (float)reader.GetDouble(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.Plus135ToPlus162 = (float)reader.GetDouble(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.Plus162ToPlus176 = (float)reader.GetDouble(9);
                            }
                            if(!reader.IsDBNull(10))
                            {
                                obj.MoreThanPlus176 = (float)reader.GetDouble(10);
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return obj;
        }
        public Boolean checkExistExtTemp(int ID)
        {
            Boolean IsExist = false;
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "select Minus12ToMinus8 from rbi.dbo.RW_EXTCOR_TEMPERATURE where ID = '"+ID+"'";
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
