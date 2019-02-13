using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace RBI.DAL.MSSQL
{
    class SQL_DBConnectUtils
    {
        public static SqlConnection GetDBConnect(String serverName, String DbName)
        {
            //Data Source=.\SQLExpress;Integrated Security=true;AttachDbFilename = C:\MyFolder\MyDataFile.mdf; User Instance = true;
            // String connection = "Server=.\SQLExpress;AttachDbFilename=C:\MyFolder\MyDataFile.mdf;Database=dbname;Trusted_Connection = Yes; ";
            String connection = null;
            SqlConnection cnn;
            connection = @"Server=" + serverName + ";Database=" + DbName + ";Trusted_Connection=True;";
            //connection = "Data Source=(localdb)\\v11.0;AttachDbFilename="+Directory.GetCurrentDirectory()+"\\RiskWISE5ProcessData.mdf;Integrated Security=True";
            //Console.WriteLine("directory " + connection);
            cnn = new SqlConnection(connection);
            return cnn;
        }
    }
}
