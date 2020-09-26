using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Sbn.FramWork.Drawing.Serialization
{
	public class SerializableDataDecomposer : SerializableDataController
	{
		public virtual void Decompose(object data)
		{
			if (data == null)
			{
				throw new XmlSerializationException(data, null);
			}
			this.FindXmlSerializableClassAttribute(data, base.SerializableDataInfo);
		}

		protected virtual bool FindXmlSerializableClassAttribute(object data, SerializableData serializableData)
		{
			Type type = data.GetType();
			XmlClassSerializable xmlClassSerializableAttribute = base.GetXmlClassSerializableAttribute(type);
			bool result;
			if (xmlClassSerializableAttribute == null)
			{
				result = false;
			}
			else
			{
				this.CreateSerializableData(data, serializableData);
				Collection<DataMember> dataMembers = new Collection<DataMember>();
				this.FillDataMembers(type, dataMembers, true, xmlClassSerializableAttribute.Deep, this.GetFlags(type, xmlClassSerializableAttribute));
				this.FindClassFields(data, serializableData, dataMembers);
				result = true;
			}
			return result;
		}

		protected virtual bool FillCollection(object data, SerializableData serializableData)
		{
			bool result;
			if (!base.IsCollection(data))
			{
				result = false;
			}
			else
			{
				ICollection collection = data as ICollection;
				foreach (object current in collection)
				{
					SerializableData serializableData2 = new SerializableData();
					XmlClassSerializable xmlClassSerializableAttribute = base.GetXmlClassSerializableAttribute(current.GetType());
					if (!this.FindXmlSerializableClassAttribute(current, serializableData2))
					{
						Type type = current.GetType();
						Collection<DataMember> collection2 = new Collection<DataMember>();
						this.FillDataMembers(type, collection2, false, this.IsDeepSerializable(type), this.GetFlags(type, xmlClassSerializableAttribute));
						if (collection2.Count == 0)
						{
							continue;
						}
						this.CreateSerializableData(current, serializableData2);
						this.FindClassFields(current, serializableData2, collection2);
					}
					serializableData.SerializableDataCollection.Add(serializableData2);
				}
				result = true;
			}
			return result;
		}

		protected virtual void FillDataMembers(Type type, Collection<DataMember> dataMembers, bool custom, bool deep, BindingFlags flags)
		{
			MemberInfo[] array = type.FindMembers(MemberTypes.Field | MemberTypes.Property, flags, custom ? new MemberFilter(this.CustomSearching) : new MemberFilter(this.Searching), dataMembers);
			if (!type.BaseType.Equals(typeof(object)) && !type.BaseType.Equals(typeof(ValueType)) && type.BaseType != null && deep)
			{
				this.FillDataMembers(type.BaseType, dataMembers, custom, deep, flags);
			}
		}

		protected virtual bool FillDataMembers(MemberInfo memberInfo, Collection<DataMember> dataMembers)
		{
			bool result;
			if (memberInfo.MemberType == MemberTypes.Field)
			{
				FieldInfo fieldInfo = (FieldInfo)memberInfo;
				DataMember item = new DataMember(memberInfo, fieldInfo.FieldType);
				dataMembers.Add(item);
				result = true;
			}
			else if (memberInfo.MemberType == MemberTypes.Property)
			{
				PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
				DataMember item = new DataMember(memberInfo, propertyInfo.PropertyType);
				dataMembers.Add(item);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		protected virtual bool CustomSearching(MemberInfo memberInfo, object dataMembersFinder)
		{
			Collection<DataMember> collection = dataMembersFinder as Collection<DataMember>;
			bool result;
			if (collection == null)
			{
				result = false;
			}
			else if (memberInfo.GetCustomAttributes(typeof(XmlFieldSerializable), true).GetLength(0) != 1)
			{
				result = false;
			}
			else
			{
				foreach (DataMember current in collection)
				{
					if (current.DataInfo.ToString() == memberInfo.ToString())
					{
						result = false;
						return result;
					}
				}
				result = this.FillDataMembers(memberInfo, collection);
			}
			return result;
		}

		protected virtual bool Searching(MemberInfo memberInfo, object dataMembersFinder)
		{
			Collection<DataMember> collection = dataMembersFinder as Collection<DataMember>;
			return collection != null && this.FillDataMembers(memberInfo, collection);
		}

		protected virtual void FindClassFields(object data, SerializableData serializableData, Collection<DataMember> dataMembers)
		{
			Type type = data.GetType();
			int i = 0;
			while (i < dataMembers.Count)
			{
				SerializableData serializableData2 = new SerializableData();
				if (base.GetXmlClassSerializableAttribute(dataMembers[i].TypeInfo) != null)
				{
					object data2 = type.InvokeMember(dataMembers[i].DataInfo.Name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.GetProperty, null, data, null);
					serializableData2.FieldName = dataMembers[i].DataInfo.Name;
					if (this.FindXmlSerializableClassAttribute(data2, serializableData2))
					{
						goto IL_9D;
					}
				}
				else
				{
					serializableData2 = this.CreateSerializableData(data, dataMembers[i]);
					if (serializableData2 != null)
					{
						goto IL_9D;
					}
				}
				IL_AB:
				i++;
				continue;
				IL_9D:
				serializableData.SerializableDataCollection.Add(serializableData2);
				goto IL_AB;
			}
			this.FillCollection(data, serializableData);
		}

		protected virtual SerializableData CreateSerializableData(object data, DataMember dataMember)
		{
			bool flag = true;
			XmlFieldSerializable xmlFieldSerializableAttribute = base.GetXmlFieldSerializableAttribute(dataMember.DataInfo);
			if (xmlFieldSerializableAttribute == null || xmlFieldSerializableAttribute.TagName == string.Empty)
			{
				flag = false;
			}
			SerializableData serializableData = new SerializableData();
			BindingFlags flags = this.GetFlags(data.GetType());
			PropertyInfo property = base.GetProperty(dataMember.DataInfo.ReflectedType, dataMember.DataInfo.Name, flags);
			object obj;
			SerializableData result;
			if (property != null && property.CanRead)
			{
				obj = property.GetGetMethod(true).Invoke(data, null);
			}
			else
			{
				FieldInfo field = base.GetField(dataMember.DataInfo.ReflectedType, dataMember.DataInfo.Name, flags);
				if (!(field != null))
				{
					result = null;
					return result;
				}
				obj = field.GetValue(data);
			}
			serializableData.Type = dataMember.TypeInfo.FullName;
			serializableData.Assembly = dataMember.TypeInfo.Assembly.ToString();
			serializableData.AssemblyQualifiedName = dataMember.TypeInfo.AssemblyQualifiedName;
			serializableData.Value = ((obj != null) ? obj.ToString() : string.Empty);
			serializableData.TagName = (flag ? xmlFieldSerializableAttribute.TagName : dataMember.TypeInfo.Name);
			serializableData.FieldName = dataMember.DataInfo.Name;
			this.FillCollection(obj, serializableData);
			result = serializableData;
			return result;
		}

		protected virtual void CreateSerializableData(object data, SerializableData serializableData)
		{
			Type type = data.GetType();
			bool flag = true;
			XmlClassSerializable xmlClassSerializableAttribute = base.GetXmlClassSerializableAttribute(type);
			if (xmlClassSerializableAttribute == null || xmlClassSerializableAttribute.TagName == string.Empty)
			{
				flag = false;
			}
			serializableData.Type = type.FullName;
			serializableData.Assembly = type.Assembly.ToString();
			serializableData.AssemblyQualifiedName = type.AssemblyQualifiedName;
			serializableData.Value = (flag ? string.Empty : data.ToString());
			serializableData.TagName = (flag ? xmlClassSerializableAttribute.TagName : type.Name);
		}

		protected override BindingFlags GetFlags(Type type, XmlClassSerializable attribute)
		{
			BindingFlags flags = base.GetFlags(type, attribute);
			return flags | (BindingFlags.GetField | BindingFlags.GetProperty);
		}
	}
}
