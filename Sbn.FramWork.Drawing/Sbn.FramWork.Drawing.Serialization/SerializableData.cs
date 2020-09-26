using System;
using System.Collections.ObjectModel;

namespace Sbn.FramWork.Drawing.Serialization
{
	public class SerializableData
	{
		private string _fieldName = string.Empty;

		private string _type = string.Empty;

		private string _assembly = string.Empty;

		private string _assemblyQualifiedName = string.Empty;

		private string _value = string.Empty;

		private string _tagName = string.Empty;

		private Collection<SerializableData> _serializableDataCollection = new Collection<SerializableData>();

		public string FieldName
		{
			get
			{
				return this._fieldName;
			}
			set
			{
				this._fieldName = value;
			}
		}

		public string Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		public string Assembly
		{
			get
			{
				return this._assembly;
			}
			set
			{
				this._assembly = value;
			}
		}

		public string AssemblyQualifiedName
		{
			get
			{
				return this._assemblyQualifiedName;
			}
			set
			{
				this._assemblyQualifiedName = value;
			}
		}

		public string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		public string TagName
		{
			get
			{
				return this._tagName;
			}
			set
			{
				this._tagName = value;
			}
		}

		public Collection<SerializableData> SerializableDataCollection
		{
			get
			{
				return this._serializableDataCollection;
			}
		}

		public virtual void Reset()
		{
			this.FieldName = string.Empty;
			this.TagName = string.Empty;
			this.Assembly = string.Empty;
			this.AssemblyQualifiedName = string.Empty;
			this.Type = string.Empty;
			this.Value = string.Empty;
			this.SerializableDataCollection.Clear();
		}
	}
}
