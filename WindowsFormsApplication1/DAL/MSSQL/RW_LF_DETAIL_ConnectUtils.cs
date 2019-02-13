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
    class RW_LF_DETAIL_ConnectUtils
    {
        public void add(int ID, int DMItemID, float LF2AP1, float LF2AP2, float LF2AP3, float LF2FactorAP1, float LF2FactorAP2, float LF2FactorAP3, float LF3,float LF3Factor, float LCF,String LHAP1Category, String LHAP2Category, String LHAP3Category,float LHAP1Value,float LHAP2Value, float LHAP3Value,float CoFValue,String CoFCategory,float RLI,int IsEL)
                        
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                           "INSERT INTO [dbo].[RW_LF_DETAIL]" +
                           "([ID]" +
                           ",[DMItemID]" +
                           ",[LF2AP1]" +
                           ",[LF2AP2]" +
                            ",[LF2AP3]" +
                            ",[LF2FactorAP1]" +
                           ",[LF2FactorAP2]" +
                           ",[LF2FactorAP3]" +
                           ",[LF3]" +
                           ",[LF3Factor]" +
                            ",[LCF]" +
                            ",[LHAP1Category]" +
                           ",[LHAP2Category]" +
                           ",[LHA3Category]" +
                            ",[LHAP1Value]" +
                            ",[LHAP2Value]" +
                           ",[LHAP3Value]" +
                           ",[CoFValue]" +
                           ",[CoFCategory]" +
                           ",[RLI]" +
                            ",[IsEL])" +
                           " VALUES" +
                           "(  '" + ID + "'" +
                            ", '" + DMItemID + "'" +
                            ",'" + LF2AP1 + "'" +
                            "," + LF2AP2 + "" +
                            ", '" + LF2AP3 + "'" +
                            ", '" + LF2FactorAP1 + "'" +
                           ", '" + LF2FactorAP2 + "'" +
                           ", '" + LF2FactorAP3+ "'" +
                           ", '" + LF3 + "'" +
                          ",'" + LF3Factor + "'" +
                           ", '" + LCF + "'" +
                            ", '" + LHAP1Category + "'" +
                            ",'" + LHAP2Category + "'" +
                            "," + LHAP3Category + "" +
                            ", '" + LHAP1Value + "'" +
                            ", '" + LHAP2Value + "'" +
                           ", '" + LHAP3Value + "'" +
                           ", '" + CoFValue + "'" +
                           ", '" + CoFCategory + "'" +
                          ",'" + RLI + "'" +
                           ", '" + IsEL + "')";
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
        public void edit(int ID, int DMItemID, float LF2AP1, float LF2AP2, float LF2AP3, float LF2FactorAP1, float LF2FactorAP2, float LF2FactorAP3, float LF3, float LF3Factor, float LCF, String LHAP1Category, String LHAP2Category, String LHAP3Category, float LHAP1Value, float LHAP2Value, float LHAP3Value, float CoFValue, String CoFCategory, float RLI, int IsEL)
                     
        {
            {
                SqlConnection conn = MSSQLDBUtils.GetDBConnection();
                conn.Open();
                String sql = "USE [rbi]" +
                              "UPDATE [dbo].[RW_LF_DETAIL] " +
                              "SET[ID] = '" + ID + "'" +
                              ",[DMItemID] = '" + DMItemID + "'" +
                              ",[LF2AP1] = '" + LF2AP1 + "'" +
                              ",[LF2AP2] = '" + LF2AP2 + "'" +
                              ",[LF2AP3] = '" + LF2AP3 + "'" +
                             ",[LF2FactorAP1] = '" + LF2FactorAP1 + "'" +
                             ",[LF2FactorAP2] = '" + LF2FactorAP2 + "'" +
                              ",[LF2FactorAP3] = '" + LF2FactorAP3 + "'" +
                              ",[LF3] = '" + LF3 + "'" +
                              ",[LF3Factor] = '" + LF3Factor + "'" +
                              ",[LCF] = '" + LCF + "'" +
                             ",[LHAP1Category] = '" + LHAP1Category + "'" +
                              ",[LHAP2Category = '" + LHAP2Category + "'" +
                              ",[LHAP3Category] = '" + LHAP3Category + "'" +
                              ",[LHAP1Value] = '" + LHAP1Value + "'" +
                              ",[LHAP2Value] = '" + LHAP3Value + "'" +
                              ",[LHAP3Value] = '" + LHAP3Value + "'" +
                              ",[CoFValue] = '" + CoFValue + "'" +
                             ",[CoFCategory] = '" + CoFCategory + "'" +
                             ",[RLI] = '" + RLI + "'" +
                              ",[IsEL] = '" + IsEL + "'" +
                              " WHERE [ID] = '" + ID + "'" + " AND [DMItemID]='" + DMItemID + "'";
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

        public void delete(int ID, int DMItemID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi] DELETE FROM [dbo].[RW_LF_DETAIL] WHERE [ID] = '" + ID + "'" + " AND [DMItemID]='" + DMItemID + "'";
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
       public List<RW_LF_DETAIL> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<RW_LF_DETAIL> list = new List<RW_LF_DETAIL>();
            RW_LF_DETAIL obj = null;
            String sql = " Use [rbi] Select [ID]" +
                          ",[DMItemID]" +
                          ",[LF2AP1]" +
                          ",[LF2AP2]" +
                          ",[LF2AP3]" +
                          ",[LF2FactorAP1]" +
                          ",[LF2FactorAP2]" +
                          ",[LF2FactorAP3]" +
                          ",[LF3]" +
                          ",[LF3Factor]" +
                          ",[LCF]" +
                          ",[LHAP1Category]" +
                          ",[LHAP2Category]" +
                          ",[LHA3Category]" +
                          ",[LHAP1Value]" +
                          ",[LHAP2Value]" +
                          ",[LHAP3Value]" +
                          ",[CoFValue]" +
                          ",[CoFCategory]" +
                          ",[RLI]" +
                          ",[IsEL]"+
                          "From [dbo].[RW_LF_DETAIL]";
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new RW_LF_DETAIL();
                            obj.ID = reader.GetInt32(0);
                            obj.DMItemID = reader.GetInt32(1);
                            if (!reader.IsDBNull(2))
                            {
                                obj.LF2AP1 = reader.GetFloat(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                obj.LF2AP2 = reader.GetFloat(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                obj.LF2AP3 = reader.GetFloat(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                obj.LF2FactorAP1 = reader.GetFloat(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                obj.LF2FactorAP2 = reader.GetFloat(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                obj.LF2FactorAP3 = reader.GetFloat(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                obj.LF3 = reader.GetFloat(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                obj.LF3Factor = reader.GetFloat(9);
                            }
                            if (!reader.IsDBNull(10))
                            {
                                obj.LCF = reader.GetFloat(10);
                            }
                            if (!reader.IsDBNull(11))
                            {
                                obj.LHAP1Category = reader.GetString(11);
                            }
                            if (!reader.IsDBNull(12))
                            {
                                obj.LHAP2Category = reader.GetString(12);
                            }
                            if (!reader.IsDBNull(13))
                            {
                                obj.LHAP3Category = reader.GetString(13);
                            }
                            if (!reader.IsDBNull(14))
                            {
                                obj.LHAP1Value = reader.GetFloat(14);
                            }
                            if (!reader.IsDBNull(15))
                            {
                                obj.LHAP2Value = reader.GetFloat(15);
                            }
                            if (!reader.IsDBNull(16))
                            {
                                obj.LHAP3Value = reader.GetFloat(16);
                            }
                            if (!reader.IsDBNull(17))
                            {
                                obj.CoFCategory = reader.GetString(17);
                            }
                            if (!reader.IsDBNull(18))
                            {
                                obj.RLI = reader.GetFloat(18);
                            }
                            obj.IsEL = reader.GetInt32(19);
                            list.Add(obj);


                        }
                    } 

                }
           }
            catch (Exception e) {
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
