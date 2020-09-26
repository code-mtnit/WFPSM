using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Hatefnet.Products.Controls.Magnifier
{
	public class XmlUtility
	{
		public static void Serialize(object data, string fileName)
		{
			Type type = data.GetType();
			XmlSerializer xmlSerializer = new XmlSerializer(type);
			XmlTextWriter xmlTextWriter = new XmlTextWriter(fileName, Encoding.UTF8);
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlSerializer.Serialize(xmlTextWriter, data);
			xmlTextWriter.Close();
		}

		public static object Deserialize(Type type, string fileName)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(type);
			XmlTextReader xmlTextReader = new XmlTextReader(fileName);
			object result = xmlSerializer.Deserialize(xmlTextReader);
			xmlTextReader.Close();
			return result;
		}
	}
}
