using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class API_COMPONENT_TYPE_BUS
    {
        API_ComponentTypeConnectUtils DAL = new API_ComponentTypeConnectUtils();
        public void add (API_COMPONENT_TYPE obj)
        {
            DAL.add(obj.APIComponentTypeID, obj.APIComponentTypeName, obj.GFFSmall,obj.GFFMedium,
                        obj.GFFLarge, obj.GFFRupture, obj.GFFTotal, obj.HoleCostSmall, obj.HoleCostMedium,
                        obj.HoleCostLarge, obj.HoleCostRupture, obj.OutageSmall, obj.OutageMedium, obj.OutageLarge,
                        obj.OutageRupture);
        }
        public void edit(API_COMPONENT_TYPE obj)
        {
            DAL.edit(obj.APIComponentTypeID, obj.APIComponentTypeName, obj.GFFSmall, obj.GFFMedium,
                        obj.GFFLarge, obj.GFFRupture, obj.GFFTotal, obj.HoleCostSmall, obj.HoleCostMedium,
                        obj.HoleCostLarge, obj.HoleCostRupture, obj.OutageSmall, obj.OutageMedium, obj.OutageLarge,
                        obj.OutageRupture);
        }
        public void delete(API_COMPONENT_TYPE obj)
        {
            DAL.delete(obj.APIComponentTypeID);
        }
        public List<API_COMPONENT_TYPE> getDataSource()
        {
            return DAL.getDataSource();
        }
        public API_COMPONENT_TYPE getData(String APIComponentTypeName)
        {
            return DAL.getData(APIComponentTypeName);
        }
        public float getGFFTotal(String ComponentType)
        {
            return DAL.getGFFTotal(ComponentType);
        }
        public String getAPIComponentTypeName(int APIID)
        {
            return DAL.getAPIComponentTypeName(APIID);
        }
        public int getIDbyName(String name)
        {
            return DAL.getIDbyName(name);
        }
    }
}
