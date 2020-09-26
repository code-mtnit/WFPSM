using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace Sbn.FramWork.Drawing.Serialization
{
	public class XmlSerializeWriter
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

		public void WriteXml(string fileName, SerializableData serializableData)
		{
			this.CreateXmlDeclaration();
			this.WriteXml(this._xmlDocument, serializableData);
			this._xmlDocument.Save(fileName);
		}

		protected virtual void WriteXml(XmlNode xmlNode, SerializableData serializableData)
		{
			XmlElement xmlElement = null;
			try
			{
				xmlElement = this._xmlDocument.CreateElement(this.GetFormattedText(serializableData.TagName));
			}
			catch
			{
				throw new XmlSerializationException(this._xmlDocument, serializableData);
			}
			xmlElement.Attributes.Append(this.CreateXmlAttribute("value", serializableData.Value));
			xmlElement.Attributes.Append(this.CreateXmlAttribute("type", serializableData.Type));
			xmlElement.Attributes.Append(this.CreateXmlAttribute("assembly", serializableData.Assembly));
			xmlElement.Attributes.Append(this.CreateXmlAttribute("assemblyQualifiedName", serializableData.AssemblyQualifiedName));
			xmlElement.Attributes.Append(this.CreateXmlAttribute("name", serializableData.FieldName));
			xmlNode.AppendChild(xmlElement);
			foreach (SerializableData current in serializableData.SerializableDataCollection)
			{
				this.WriteXml(xmlElement, current);
			}
		}

		protected virtual void CreateXmlDeclaration()
		{
			XmlDeclaration newChild = this._xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", "no");
			this._xmlDocument.AppendChild(newChild);
		}

		protected XmlAttribute CreateXmlAttribute(string name, string value)
		{
			XmlAttribute xmlAttribute = this._xmlDocument.CreateAttribute(name);
			xmlAttribute.Value = value;
			return xmlAttribute;
		}

		protected virtual string GetFormattedText(string text)
		{
			Regex regex = new Regex("\\W");
			MatchCollection matchCollection = regex.Matches(text);
			foreach (Match match in matchCollection)
			{
				text = text.Replace(match.Value, string.Empty);
			}
			return text;
		}
	}
}
