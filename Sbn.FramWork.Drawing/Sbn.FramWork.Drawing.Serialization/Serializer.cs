using System;

namespace Sbn.FramWork.Drawing.Serialization
{
	public class Serializer
	{
		private XmlSerializeWriter _serializeWriter = new XmlSerializeWriter();

		private XmlSerializeReader _serializeReader = new XmlSerializeReader();

		private SerializableDataComposer _composer = new SerializableDataComposer();

		private SerializableDataDecomposer _decomposer = new SerializableDataDecomposer();

		public XmlSerializeWriter SerializeWriter
		{
			get
			{
				return this._serializeWriter;
			}
			set
			{
				this._serializeWriter = value;
			}
		}

		public XmlSerializeReader SerializeReader
		{
			get
			{
				return this._serializeReader;
			}
			set
			{
				this._serializeReader = value;
			}
		}

		public SerializableDataComposer Composer
		{
			get
			{
				return this._composer;
			}
			set
			{
				this._composer = value;
			}
		}

		public SerializableDataDecomposer Decomposer
		{
			get
			{
				return this._decomposer;
			}
			set
			{
				this._decomposer = value;
			}
		}

		public virtual void Reset()
		{
			this._composer.SerializableDataInfo.Reset();
			this._decomposer.SerializableDataInfo.Reset();
			this._serializeReader.XmlDocument.RemoveAll();
			this._serializeWriter.XmlDocument.RemoveAll();
		}

		public virtual void Serialize(string fileName, object data)
		{
			this._decomposer.Decompose(data);
			this._serializeWriter.WriteXml(fileName, this._decomposer.SerializableDataInfo);
		}

		public virtual object Deserialize(string fileName)
		{
			this._serializeReader.ReadXml(fileName, this._decomposer.SerializableDataInfo);
			return this._composer.Compose(this._decomposer.SerializableDataInfo);
		}
	}
}
