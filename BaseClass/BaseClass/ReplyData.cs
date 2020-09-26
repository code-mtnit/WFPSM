using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Collections;

namespace BaseClass
{
    public class ReplyData
    {
        private Consts.SectionType m_Type;

        public Consts.SectionType Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        private ArrayList m_ArrDataContainers = new ArrayList();

        public ArrayList ArrDataContainers
        {
            get { return m_ArrDataContainers; }
            set { m_ArrDataContainers = value; }
        }

        static XmlSerializer serializer = new XmlSerializer(typeof(ReplyData), new Type[] { typeof(DataContainer), typeof(Counter)});

        public ReplyData()
        { }
        
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

        public static ReplyData Deserialize(string ReplyString)
        {
            try
            {
                TextReader reader = new StringReader(ReplyString);
                return (ReplyData)serializer.Deserialize(reader);
            }
            catch (Exception) {}

            return null;
        }
    }

    public class DataContainer
    {
        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private ArrayList m_ArrCounters = new ArrayList();

	    public ArrayList ArrCounters
	    {
		    get { return m_ArrCounters;}
		    set { m_ArrCounters = value;}
	    }
        public DataContainer()
        {

        }

        public DataContainer(string i_Name)
        {
            Name = i_Name;
        }
    }

    public struct Counter
    {
        public string Name;
        public string Value;

        public Counter(string i_Name, string i_Value)
        {
            Name = i_Name;
            Value = i_Value;
        }
    }
}
    