using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_RISK_GRAPH_BUS
    {
        RW_RISK_GRAPH_ConnectUtils DAL = new RW_RISK_GRAPH_ConnectUtils();
        public void add(RW_RISK_GRAPH obj)
        {
            DAL.add(obj);
        }
        public void edit(RW_RISK_GRAPH obj)
        {
            DAL.edit(obj);
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public List<double> GetData(int ID)
        {
            return DAL.GetData(ID);
        }
        public bool CheckExistID(int ID)
        {
            return DAL.CheckExistID(ID);
        }
    }
}
