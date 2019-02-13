using RBI.DAL.MSSQL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class ITEM_LIST_CONFIG_BUS
    {
        ITEM_LIST_CONFIG_ConnectUtils DAL = new ITEM_LIST_CONFIG_ConnectUtils();
        public void add(ITEM_LIST_CONFIG obj)
        {
            DAL.add(obj.UserID, obj.TreeNode, obj.NodeSeq, obj.ParentID);
        }
        public void edit(ITEM_LIST_CONFIG obj)
        {
            DAL.edit(obj.ItemListConfigID, obj.UserID, obj.TreeNode, obj.NodeSeq, obj.ParentID);
        }
        public void delete(ITEM_LIST_CONFIG obj)
        {
            DAL.delete(obj.ItemListConfigID);
        }
        public List<ITEM_LIST_CONFIG> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
