using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RBI.BUS.BUSXML
{
    class ReadXML
    {
        private List<String> xmlToList(String path)
        {
            List<String> list = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList xn = doc.GetElementsByTagName("name");
            for(int i = 0; i< xn.Count; i++)
            {
                String data = xn[i].InnerXml.ToString();
                list.Add(data);
            }
            return list;
        }
        public List<String> getListComponet()
        {
            String path = @"Component.xml";
            List<String> list = xmlToList(path);
            return list;
        }
        public List<String> getListType()
        {
            String path = @"Type.xml";
            List<String> list = xmlToList(path);
            return list;
        }
        public List<String> getListMOC()
        {
            String path = @"MOC.xml";
            List<String> list = xmlToList(path);
            return list;
        }
        public List<String> getListLMOC()
        {
            String path = @"LMOC.xml";
            List<String> list = xmlToList(path);
            return list;
        }
        public List<String> getListChemical()
        {
            String path = @"Chemical.xml";
            List<String> list = xmlToList(path);
            return list;
        }
        public List<String> getListContaminants()
        {
            String path = @"Contaminants.xml";
            List<String> list = xmlToList(path);
            return list;
        }
        public List<String> getListOpState()
        {
            String path = @"OpState.xml";
            List<String> list = xmlToList(path);
            return list;
        }
        public List<String> getListTechnique()
        {
            String path = @"Technique.xml";
            List<String> list = xmlToList(path);
            return list;
        }
    }
}
