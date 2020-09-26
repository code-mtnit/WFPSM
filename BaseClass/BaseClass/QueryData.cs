using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace BaseClass
{
    public class QueryData
    {        
        private Consts.SectionType m_Type;

        public Consts.SectionType Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        private ArrayList m_ArrCounters = new ArrayList();

        public ArrayList ArrCounter
        {
            get { return m_ArrCounters; }            
        }


        private ClientInfo m_CurrClient;

        public ClientInfo CurrClient
        {
            get { return m_CurrClient; }
            set { m_CurrClient = value; }
        }

        static XmlSerializer serializer = new XmlSerializer(typeof(QueryData), new Type[] { typeof(ObjectMetaData) });

        public string Serialize() 
        {        
          
            TextWriter writer = new StringWriter();
            XmlWriterSettings xs = new XmlWriterSettings();
            xs.OmitXmlDeclaration = true;
            xs.Encoding = new UTF8Encoding(true);
            XmlWriter xw = XmlTextWriter.Create(writer, xs);

            serializer.Serialize(xw, this);
            xw.Flush();

            return writer.ToString();
        }

        public static QueryData Deserialize(string QueryString)
        {
            try
            {
                TextReader reader = new StringReader(QueryString);
                return (QueryData)serializer.Deserialize(reader);
            }
            catch
            {
                return null;
            }
        }
    }    
}
