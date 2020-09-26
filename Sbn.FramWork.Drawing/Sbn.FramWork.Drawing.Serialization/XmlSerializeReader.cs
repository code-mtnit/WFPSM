using System;
using System.Xml;

namespace Sbn.FramWork.Drawing.Serialization
{
	public class XmlSerializeReader
	{
		private XmlDocument _xmlDocument = new XmlDocument();

		public XmlDocument XmlDocument
		{
			get
			{
				return this._xmlDocument;
			}
			set
			{
				this._xmlDocument = value;
			}
		}

		public object ReadXml(string fileName, SerializableData serializableData)
		{
			this._xmlDocument.Load(fileName);
			try
			{
				this.ReadXml(this._xmlDocument.ChildNodes[1], serializableData);
			}
			catch
			{
				throw new XmlSerializationException(this._xmlDocument, serializableData);
			}
			return serializableData;
		}

		protected virtual void ReadXml(XmlNode xmlNode, SerializableData serializableData)
		{
			XmlAttribute xmlAttribute = xmlNode.Attributes["name"];
			XmlAttribute xmlAttribute2 = xmlNode.Attributes["type"];
			XmlAttribute xmlAttribute3 = xmlNode.Attributes["assembly"];
			XmlAttribute xmlAttribute4 = xmlNode.Attributes["assemblyQualifiedName"];
			string name = xmlNode.Name;
			XmlAttribute xmlAttribute5 = xmlNode.Attributes["value"];
			serializableData.TagName = name;
			serializableData.Type = xmlAttribute2.Value;
			serializableData.Assembly = xmlAttribute3.Value;
			serializableData.AssemblyQualifiedName = xmlAttribute4.Value;
			serializableData.FieldName = xmlAttribute.Value;
			serializableData.Value = xmlAttribute5.Value;
			foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
			{
				SerializableData serializableData2 = new SerializableData();
				serializableData.SerializableDataCollection.Add(serializableData2);
				this.ReadXml(xmlNode2, serializableData2);
			}
		}
	}
}
