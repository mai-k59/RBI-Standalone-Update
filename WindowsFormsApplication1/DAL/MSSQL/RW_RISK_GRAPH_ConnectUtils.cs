using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using RBI.Object.ObjectMSSQL;
namespace RBI.DAL.MSSQL
{
    class RW_RISK_GRAPH_ConnectUtils
    {
        public void add(RW_RISK_GRAPH obj)
        {
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            string sql = "INSERT INTO rbi.dbo.RW_RISK_GRAPH" +
                         "(ID, risktarget, risk1, risk2, risk3, risk4, risk5, risk6, risk7, risk8, risk9, risk10, risk11, risk12, risk13, risk14, risk15)" +
                         "VALUES ('" + obj.ID + "','" + obj.RiskTarget+"','"+obj.Risk[0] + "','" + obj.Risk[1] + "','" + obj.Risk[2] + "','"+obj.Risk[3]+"','"+obj.Risk[4]+"','"+obj.Risk[5]+"','"+obj.Risk[6]+"','"+obj.Risk[7]+"','"+obj.Risk[8]+"','"+obj.Risk[9]+"','"+obj.Risk[10]+"','"+obj.Risk[11]+"','"+obj.Risk[12]+"','"+obj.Risk[13]+"','"+obj.Risk[14]+"')";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("FAIL---->\n" + ex.ToString(), "Error");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public void edit(RW_RISK_GRAPH obj)
        {
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            string sql = "UPDATE rbi.dbo.RW_RISK_GRAPH " +
                         "SET risktarget = '" + obj.RiskTarget+ "',"+
                         "risk1 = '" + obj.Risk[0] + "'," +
                         "risk2 = '" + obj.Risk[1] + "'," +
                         "risk3 = '" + obj.Risk[2] + "'," +
                         "risk4 = '" + obj.Risk[3] + "'," +
                         "risk5 = '" + obj.Risk[4] + "'," +
                         "risk6 = '" + obj.Risk[5] + "'," +
                         "risk7 = '" + obj.Risk[6]+ "'," +
                         "risk8 = '" + obj.Risk[7] + "'," +
                         "risk9 = '" + obj.Risk[8] + "'," +
                         "risk10 = '" + obj.Risk[9] + "'," +
                         "risk11 = '" + obj.Risk[10] + "'," +
                         "risk12 = '" + obj.Risk[11] + "'," +
                         "risk13 = '" + obj.Risk[12] + "'," +
                         "risk14 = '" + obj.Risk[13] + "'," +
                         "risk15 = '" + obj.Risk[14] + "'"+
                         " WHERE ID = '"+obj.ID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EDIT FAIL---->\n" + ex.ToString(), "Error");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        
        public void delete(int ID)
        {
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            string sql = "DELETE FROM rbi.dbo.RW_RISK_GRAPH WHERE ID = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("DELETE FAIL---->\n" + ex.ToString(), "Error");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<double> GetData(int ID)
        {
            List<double> lstRisk = new List<double>();
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            string sql = "SELECT * FROM rbi.dbo.RW_RISK_GRAPH WHERE ID = '" + ID + "'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 1; i < 17; i++)
                        {
                            lstRisk.Add(reader.GetDouble(i));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("GetData FAIL---->\n" + ex.ToString(), "Error");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return lstRisk;
        }
        public bool CheckExistID(int ID)
        {
            bool isExist = false;
            SqlConnection con = MSSQLDBUtils.GetDBConnection();
            con.Open();
            string sql = "SELECT ID FROM rbi.dbo.RW_RISK_GRAPH WHERE ID = '"+ID+"'";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0) && reader.GetInt32(0) != 0)
                            isExist = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("GetData FAIL---->\n" + ex.ToString(), "Error");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return isExist;
        }
    }
}
