using System;
using System.Collections;
using System.Reflection;

namespace Sbn.FramWork.Drawing.Serialization
{
	public abstract class SerializableDataController
	{
		private SerializableData _serializableDataInfo = new SerializableData();

		public SerializableData SerializableDataInfo
		{
			get
			{
				return this._serializableDataInfo;
			}
		}

		public SerializableDataController()
		{
		}

		protected XmlClassSerializable GetXmlClassSerializableAttribute(Type type)
		{
			object[] customAttributes = type.GetCustomAttributes(typeof(XmlClassSerializable), true);
			XmlClassSerializable result;
			if (customAttributes.GetLength(0) != 1)
			{
				result = null;
			}
			else
			{
				ConstructorInfo[] constructors = type.GetConstructors();
				if (constructors.Length == 0 && !type.IsValueType)
				{
					result = null;
				}
				else
				{
					ConstructorInfo[] array = constructors;
					for (int i = 0; i < array.Length; i++)
					{
						ConstructorInfo constructorInfo = array[i];
						if (constructorInfo.GetParameters().Length == 0)
						{
							result = (customAttributes[0] as XmlClassSerializable);
							return result;
						}
					}
					result = (customAttributes[0] as XmlClassSerializable);
				}
			}
			return result;
		}

		protected XmlFieldSerializable GetXmlFieldSerializableAttribute(Type type)
		{
			object[] customAttributes = type.GetCustomAttributes(typeof(XmlFieldSerializable), true);
			XmlFieldSerializable result;
			if (customAttributes.GetLength(0) != 1)
			{
				result = null;
			}
			else
			{
				result = (customAttributes[0] as XmlFieldSerializable);
			}
			return result;
		}

		protected XmlFieldSerializable GetXmlFieldSerializableAttribute(MemberInfo memberInfo)
		{
			object[] customAttributes = memberInfo.GetCustomAttributes(typeof(XmlFieldSerializable), true);
			XmlFieldSerializable result;
			if (customAttributes.GetLength(0) != 1)
			{
				result = null;
			}
			else
			{
				result = (customAttributes[0] as XmlFieldSerializable);
			}
			return result;
		}

		protected bool IsCollection(object data)
		{
			ICollection collection = data as ICollection;
			return collection != null;
		}

		protected bool IsCollection(Type type)
		{
			bool result;
			if (type == null)
			{
				result = false;
			}
			else
			{
				Type @interface = type.GetInterface("System.Collections.ICollection");
				result = !(@interface == null);
			}
			return result;
		}

		protected bool IsArray(Type type)
		{
			return !(type == null) && (type.Equals(typeof(Array)) || this.IsArray(type.BaseType));
		}

		protected PropertyInfo GetProperty(Type type, string name, BindingFlags flags)
		{
			MemberInfo[] array = type.FindMembers(MemberTypes.Property, flags, null, null);
			MemberInfo[] array2 = array;
			PropertyInfo result;
			for (int i = 0; i < array2.Length; i++)
			{
				MemberInfo memberInfo = array2[i];
				if (memberInfo.Name == name)
				{
					result = (memberInfo as PropertyInfo);
					return result;
				}
			}
			result = null;
			return result;
		}

		protected FieldInfo GetField(Type type, string name, BindingFlags flags)
		{
			MemberInfo[] array = type.FindMembers(MemberTypes.Field, flags, null, null);
			MemberInfo[] array2 = array;
			FieldInfo result;
			for (int i = 0; i < array2.Length; i++)
			{
				MemberInfo memberInfo = array2[i];
				if (memberInfo.Name == name)
				{
					result = (memberInfo as FieldInfo);
					return result;
				}
			}
			result = null;
			return result;
		}

		protected Type GetType(SerializableData serializableData)
		{
			return Type.GetType(serializableData.AssemblyQualifiedName);
		}

		protected virtual BindingFlags GetFlags(Type type, XmlClassSerializable attribute)
		{
			bool flag = this.IsDeepSerializable(type);
			BindingFlags bindingFlags = (attribute != null && attribute.Flags != BindingFlags.Default) ? attribute.Flags : (BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (!this.IsBaseType(type) && (attribute == null || attribute.Flags == BindingFlags.Default))
			{
				bindingFlags |= BindingFlags.Instance;
			}
			else if (this.IsBaseType(type))
			{
				bindingFlags = (BindingFlags.Static | BindingFlags.Public);
			}
			if (attribute == null || attribute.Flags == BindingFlags.Default)
			{
				if (!flag)
				{
					bindingFlags |= BindingFlags.DeclaredOnly;
				}
				else
				{
					bindingFlags |= (BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
				}
			}
			return bindingFlags;
		}

		protected virtual BindingFlags GetFlags(Type type)
		{
			XmlClassSerializable xmlClassSerializableAttribute = this.GetXmlClassSerializableAttribute(type);
			return this.GetFlags(type, xmlClassSerializableAttribute);
		}

		protected virtual bool IsDeepSerializable(Type type)
		{
			XmlClassSerializable xmlClassSerializableAttribute = this.GetXmlClassSerializableAttribute(type);
			return xmlClassSerializableAttribute != null && xmlClassSerializableAttribute.Deep;
		}

		protected virtual bool IsBaseType(Type type)
		{
			bool result;
			if (type == null)
			{
				result = true;
			}
			else
			{
				TypeCode typeCode = Type.GetTypeCode(type);
				result = (typeCode == TypeCode.Boolean || typeCode == TypeCode.Byte || typeCode == TypeCode.Char || typeCode == TypeCode.DateTime || typeCode == TypeCode.DBNull || typeCode == TypeCode.Decimal || typeCode == TypeCode.Double || typeCode == TypeCode.Empty || typeCode == TypeCode.Int16 || typeCode == TypeCode.Int32 || typeCode == TypeCode.Int64 || typeCode == TypeCode.SByte || typeCode == TypeCode.Single || typeCode == TypeCode.String || typeCode == TypeCode.UInt16 || typeCode == TypeCode.UInt32 || typeCode == TypeCode.UInt64);
			}
			return result;
		}
	}
}
