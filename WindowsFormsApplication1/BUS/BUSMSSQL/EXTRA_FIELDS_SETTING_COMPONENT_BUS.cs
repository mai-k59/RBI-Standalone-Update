using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class EXTRA_FIELDS_SETTING_COMPONENT_BUS
    {
        EXTRA_FIELDS_SETTING_COMPONENT_ConnectUtils DAL = new EXTRA_FIELDS_SETTING_COMPONENT_ConnectUtils();
        public void add(EXTRA_FIELDS_SETTING_COMPONENT obj)
        {
            DAL.add(obj.ExtraFieldID, obj.FieldID, obj.FieldName, obj.FieldDescription, obj.SeqNo,
                        obj.FieldType, obj.FieldSize, obj.IsActive, obj.IsCreated);

        }
        public void edit(EXTRA_FIELDS_SETTING_COMPONENT obj)
        {
            DAL.edit(obj.ExtraFieldID, obj.FieldID, obj.FieldName, obj.FieldDescription, obj.SeqNo,
                        obj.FieldType, obj.FieldSize, obj.IsActive, obj.IsCreated);
        }
        public void delete(EXTRA_FIELDS_SETTING_COMPONENT obj)
        {
            DAL.delete(obj.ExtraFieldID);
        }
        public List<EXTRA_FIELDS_SETTING_COMPONENT> getDataSource()
        {
            return DAL.getDataSource();
        }
        
    }
}
