using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace BaseClass
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

        private ViewerInfo m_CurrViewer;

        public ViewerInfo CurrViewer
        {
            get { return m_CurrViewer; }
            set { m_CurrViewer = value; }
        }

        private ArrayList m_ArrClients = new ArrayList();

        public ArrayList ArrClients
        {
            get { return m_ArrClients; }
            set { m_ArrClients = value; }
        }


        private ArrayList m_ArrViewers = new ArrayList();

        public ArrayList ArrViewers
        {
            get { return m_ArrViewers; }
            set { m_ArrViewers = value; }
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

    [Serializable()]
    public class ClientInfo
    {
        public string IP;
        public string Name;
        public string HostName;
        public Consts.ClientStatus Status;
        public Consts.NetStatus NetStatus;

        public ClientInfo()
        { }

        public ClientInfo(string i_IP, string i_Name)
        {
            IP = i_IP;
            Name = i_Name;
            
        }

        public ClientInfo(string i_IP, string i_Name, Consts.ClientStatus i_Status)
        {
            IP = i_IP;
            Name = i_Name;
            Status = i_Status;
        }

        public ClientInfo(string i_IP, string i_Name, Consts.ClientStatus i_Status , Consts.NetStatus i_netstatus)
        {
            IP = i_IP;
            Name = i_Name;
            Status = i_Status;
            NetStatus = i_netstatus;
        }
    }


    [Serializable()]
    public class ViewerInfo
    { 
         public string IP;
        public string Name;
        public Consts.ViewerStatus Status;

        public ViewerInfo()
        { }

        public ViewerInfo(string i_IP, string i_Name, Consts.ViewerStatus i_Status)
        {
            IP = i_IP;
            Name = i_Name;
            Status = i_Status;
        }
    }

    [Serializable()]
    public class CenterInfo
    {
        public string IP;
        public string Name;
        public Consts.CenterStatus Status;

        public CenterInfo()
        { }

        public CenterInfo(string i_IP, string i_Name, Consts.CenterStatus i_Status)
        {
            IP = i_IP;
            Name = i_Name;
            Status = i_Status;
        }
    }
}
