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
    class RW_EXTCOR_TEMPERATURE_BUS
    {
        RW_EXTCOR_TEMPERATURE_ConnectUtils DAL = new RW_EXTCOR_TEMPERATURE_ConnectUtils();
        public void add(RW_EXTCOR_TEMPERATURE obj)
        {
            DAL.add(obj.ID, obj.Minus12ToMinus8,obj.Minus8ToPlus6, obj.Plus6ToPlus32, obj.Plus32ToPlus71, obj.Plus71ToPlus107, obj.Plus107ToPlus121, obj.Plus121ToPlus135, obj.Plus135ToPlus162, obj.Plus162ToPlus176, obj.MoreThanPlus176);
        }
        public void edit(RW_EXTCOR_TEMPERATURE obj)
        {
            DAL.edit(obj.ID, obj.Minus12ToMinus8, obj.Minus8ToPlus6, obj.Plus6ToPlus32, obj.Plus32ToPlus71, obj.Plus71ToPlus107, obj.Plus107ToPlus121, obj.Plus121ToPlus135, obj.Plus135ToPlus162, obj.Plus162ToPlus176, obj.MoreThanPlus176);

        }
        public void delete(RW_EXTCOR_TEMPERATURE obj)
        {
            DAL.delete(obj.ID);
        }
        public void delete(int ID)
        {
            DAL.delete(ID);
        }
        public List<RW_EXTCOR_TEMPERATURE> getDataSource()
        {
            return DAL.getDataSource();
        }
        public RW_EXTCOR_TEMPERATURE getData(int ID)
        {
            return DAL.getData(ID);
        }
        public Boolean checkExistExtTemp(int ID)
        {
            return DAL.checkExistExtTemp(ID);
        }
    }
}
