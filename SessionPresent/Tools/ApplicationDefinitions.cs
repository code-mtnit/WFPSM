using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using BaseClass;


namespace SessionPresent.Tools
{
    [Serializable()]
    public class ApplicationDefinitions
    {

        private CenterInfo m_CurrCenter;

        public CenterInfo CurrCenter
        {
            get { return m_CurrCenter; }
            set { m_CurrCenter = value; }
        }

        private ClientInfo m_CurrClient;

        public ClientInfo CurrClient
        {
            get { return m_CurrClient; }
            set { m_CurrClient = value; }
        }

        private ArrayList m_ArrClients = new ArrayList();

        public ArrayList ArrClients
        {
            get { return m_ArrClients; }
            set { m_ArrClients = value; }
        }

        public string m_Interval;
        public int m_Port;

        public ArrayList m_ProcessArrCounters = new ArrayList();
        public ArrayList m_PerformanceArrCounters = new ArrayList();
        public ArrayList m_PerformanceMultiArrCounters = new ArrayList();

        static XmlSerializer serializer = new XmlSerializer(typeof(ApplicationDefinitions), new Type[] { typeof(ClientInfo) });

        public string Serialize()
        {
            TextWriter writer = new StringWriter();
            XmlWriterSettings xs = new XmlWriterSettings();
            xs.OmitXmlDeclaration = true;
            XmlWriter xw = XmlTextWriter.Create(writer, xs);
            serializer.Serialize(xw, this);
            xw.Flush();

            return writer.ToString();
        }

        public static ApplicationDefinitions Deserialize(string DefinitionString)
        {
            TextReader reader = new StringReader(DefinitionString);
            return (ApplicationDefinitions)serializer.Deserialize(reader);
        }
    }

}
