using System;
using System.Reflection;

namespace Sbn.FramWork.Drawing.Serialization
{
	public class XmlSerializationException : ApplicationException
	{
		private object _data = null;

		private SerializableData _serializableData = null;

		private PropertyInfo _propertyInfo = null;

		private FieldInfo _fieldInfo = null;

		public object DataInfo
		{
			get
			{
				return this._data;
			}
		}

		public SerializableData SerializableDataInfo
		{
			get
			{
				return this._serializableData;
			}
		}

		public PropertyInfo Property
		{
			get
			{
				return this._propertyInfo;
			}
		}

		public FieldInfo Field
		{
			get
			{
				return this._fieldInfo;
			}
		}

		public override string Message
		{
			get
			{
				string str = base.Message;
				str += ((this._data != null) ? (this.GetFormattedText(Resource.Data) + this._data.ToString()) : this.GetFormattedText(Resource.NoData));
				str += ((this._serializableData != null) ? string.Concat(new string[]
				{
					this.GetFormattedText(Resource.SerializableData),
					this.GetFormattedText(Resource.Assembly),
					this._serializableData.Assembly,
					this.GetFormattedText(Resource.AssemblyQualifiedName),
					this._serializableData.AssemblyQualifiedName,
					this.GetFormattedText(Resource.FieldName),
					this._serializableData.FieldName,
					this.GetFormattedText(Resource.TagName),
					this._serializableData.TagName,
					this.GetFormattedText(Resource.Type),
					this._serializableData.Type,
					this.GetFormattedText(Resource.Value),
					this._serializableData.Value,
					this.GetFormattedText(Resource.SerializableDataCollectionCount),
					this._serializableData.SerializableDataCollection.Count.ToString()
				}) : this.GetFormattedText(Resource.NoSerializableData));
				string text = string.Empty;
				if (this._propertyInfo != null)
				{
					text = Resource.PropertyInfo + " " + this._propertyInfo.Name + ": ";
					text += (this._propertyInfo.CanRead ? Resource.Readeable : (Resource.NoReadeable + "\n"));
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						Resource.PropertyInfo,
						" ",
						this._propertyInfo.Name,
						": "
					});
					text += (this._propertyInfo.CanWrite ? Resource.Writeable : (Resource.NoWriteable + "\n"));
				}
				string text3 = string.Empty;
				if (this._fieldInfo != null)
				{
					text3 = Resource.FieldInfo + " " + this._fieldInfo.Name + ": ";
					text3 += (this._fieldInfo.IsLiteral ? Resource.Constant : (Resource.NoConstant + "\n"));
				}
				return str + text + text3;
			}
		}

		public XmlSerializationException(object data, SerializableData serializableData)
		{
			this._data = data;
			this._serializableData = serializableData;
		}

		public XmlSerializationException(object data, SerializableData serializableData, PropertyInfo propertyInfo, FieldInfo fieldInfo)
		{
			this._data = data;
			this._serializableData = serializableData;
			this._propertyInfo = propertyInfo;
			this._fieldInfo = fieldInfo;
		}

		protected string GetFormattedText(string text)
		{
			return "\n" + text + ": ";
		}
	}
}
