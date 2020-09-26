using System;
using System.Reflection;
using System.Runtime.Remoting;

namespace Sbn.FramWork.Drawing.Serialization
{
	public class SerializableDataComposer : SerializableDataController
	{
		public virtual object Compose(SerializableData serializableData)
		{
			object result = this.CreateObject(serializableData);
			this.FillObject(ref result, serializableData);
			return result;
		}

		protected virtual object CreateObject(SerializableData serializableData)
		{
			Type type = base.GetType(serializableData);
			if (type != null)
			{
				object obj = Activator.CreateInstance(type, null);
				ObjectHandle objectHandle = obj as ObjectHandle;
				if (objectHandle != null)
				{
					obj = objectHandle.Unwrap();
				}
				return obj;
			}
			throw new XmlSerializationException(null, serializableData);
		}

		protected virtual void FillObject(ref object data, SerializableData serializableData)
		{
			foreach (SerializableData current in serializableData.SerializableDataCollection)
			{
				this.FillObjectField(data, data.GetType(), current);
			}
		}

		protected virtual void FillObjectField(object data, Type type, SerializableData serializableData)
		{
			object newObject = this.GetNewObject(serializableData);
			this.Filler(data, type, new object[]
			{
				newObject
			}, serializableData);
		}

		protected virtual object GetNewObject(SerializableData serializableData)
		{
			Type type = base.GetType(serializableData);
			object result;
			if (type.IsArray)
			{
				result = this.CreateArray(serializableData);
			}
			else if (base.IsCollection(type))
			{
				result = this.CreateCollection(serializableData);
			}
			else
			{
				result = this.GetObject(serializableData);
			}
			return result;
		}

		protected virtual void Filler(object dataToFill, Type type, object[] parameters, SerializableData serializableData)
		{
			XmlClassSerializable xmlClassSerializableAttribute = base.GetXmlClassSerializableAttribute(type);
			bool flag = this.IsDeepSerializable(type);
			BindingFlags flags = this.GetFlags(type, xmlClassSerializableAttribute);
			PropertyInfo property = base.GetProperty(type, serializableData.FieldName, flags);
			FieldInfo field = base.GetField(type, serializableData.FieldName, flags);
			try
			{
				if ((property != null && property.CanWrite) || (field != null && !field.IsLiteral))
				{
					type.InvokeMember(serializableData.FieldName, flags, null, dataToFill, parameters);
				}
				else if (!type.BaseType.Equals(typeof(object)) && type.BaseType != null && flag)
				{
					this.FillObjectField(dataToFill, type.BaseType, serializableData);
				}
				else if (base.IsCollection(type) && !base.IsArray(type))
				{
					this.InvokeAddingMethod(dataToFill, parameters);
				}
			}
			catch
			{
				throw new XmlSerializationException(dataToFill, serializableData, property, field);
			}
		}

		protected virtual object GetObject(SerializableData serializableData)
		{
			object obj = null;
			Type type = base.GetType(serializableData);
			TypeCode typeCode = Type.GetTypeCode(type);
			if (this.IsCreateableSerializableData(serializableData))
			{
				obj = this.CreateObject(serializableData);
			}
			else
			{
				try
				{
					obj = this.ConvertType(serializableData);
				}
				catch
				{
					throw new XmlSerializationException(obj, serializableData);
				}
			}
			this.FillObject(ref obj, serializableData);
			return obj;
		}

		protected virtual object CreateArray(SerializableData serializableData)
		{
			object obj = null;
			try
			{
				Type type = base.GetType(serializableData.SerializableDataCollection[0]);
				Array array = Array.CreateInstance(type, serializableData.SerializableDataCollection.Count);
				for (int i = 0; i < serializableData.SerializableDataCollection.Count; i++)
				{
					object value;
					if (!this.IsBaseType(type))
					{
						value = this.Compose(serializableData.SerializableDataCollection[i]);
					}
					else
					{
						value = this.ConvertType(serializableData.SerializableDataCollection[i]);
					}
					array.SetValue(value, i);
				}
				obj = array;
				this.FillObject(ref obj, serializableData);
			}
			catch
			{
				throw new XmlSerializationException(obj, serializableData);
			}
			return obj;
		}

		protected virtual object CreateCollection(SerializableData serializableData)
		{
			object obj = this.CreateObject(serializableData);
			Type type = obj.GetType();
			foreach (SerializableData current in serializableData.SerializableDataCollection)
			{
				object obj2 = this.Compose(current);
				this.Filler(obj, obj.GetType(), new object[]
				{
					obj2
				}, current);
			}
			return obj;
		}

		protected virtual void InvokeAddingMethod(object invoker, object[] parameters)
		{
			MethodInfo method = invoker.GetType().GetMethod("Add");
			if (method == null)
			{
				throw new XmlSerializationException(invoker, null);
			}
			try
			{
				method.Invoke(invoker, parameters);
			}
			catch
			{
				throw new XmlSerializationException(invoker, null);
			}
		}

		protected virtual bool IsCreateableSerializableData(SerializableData serializableData)
		{
			Type type = base.GetType(serializableData);
			TypeCode typeCode = Type.GetTypeCode(type);
			ConstructorInfo[] constructors = type.GetConstructors();
			bool result;
			if (constructors.Length == 0 && !type.IsValueType)
			{
				result = false;
			}
			else
			{
				ConstructorInfo[] array = constructors;
				for (int i = 0; i < array.Length; i++)
				{
					ConstructorInfo constructorInfo = array[i];
					if (constructorInfo.GetParameters().Length == 0)
					{
						result = true;
						return result;
					}
				}
				result = (typeCode == TypeCode.Object);
			}
			return result;
		}

		protected virtual object ConvertType(SerializableData serializableData)
		{
			object result = null;
			Type type = base.GetType(serializableData);
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.Empty:
				if (serializableData.Value == string.Empty)
				{
					result = null;
				}
				else
				{
					result = Convert.ToBoolean(serializableData.Value);
				}
				break;
			case TypeCode.DBNull:
				if (serializableData.Value == string.Empty)
				{
					result = null;
				}
				else
				{
					result = Convert.ToBoolean(serializableData.Value);
				}
				break;
			case TypeCode.Boolean:
				if (serializableData.Value == string.Empty)
				{
					result = false;
				}
				else
				{
					result = bool.Parse(serializableData.Value);
				}
				break;
			case TypeCode.Char:
				if (serializableData.Value == string.Empty)
				{
					result = '\0';
				}
				else
				{
					result = char.Parse(serializableData.Value);
				}
				break;
			case TypeCode.SByte:
				if (serializableData.Value == string.Empty)
				{
					result = -128;
				}
				else
				{
					result = sbyte.Parse(serializableData.Value);
				}
				break;
			case TypeCode.Byte:
				if (serializableData.Value == string.Empty)
				{
					result = 0;
				}
				else
				{
					result = byte.Parse(serializableData.Value);
				}
				break;
			case TypeCode.Int16:
				if (serializableData.Value == string.Empty)
				{
					result = -32768;
				}
				else
				{
					result = short.Parse(serializableData.Value);
				}
				break;
			case TypeCode.UInt16:
				if (serializableData.Value == string.Empty)
				{
					result = 0;
				}
				else
				{
					result = ushort.Parse(serializableData.Value);
				}
				break;
			case TypeCode.Int32:
				if (serializableData.Value == string.Empty)
				{
					result = -2147483648;
				}
				else
				{
					result = int.Parse(serializableData.Value);
				}
				break;
			case TypeCode.UInt32:
				if (serializableData.Value == string.Empty)
				{
					result = 0u;
				}
				else
				{
					result = uint.Parse(serializableData.Value);
				}
				break;
			case TypeCode.Int64:
				if (serializableData.Value == string.Empty)
				{
					result = -9223372036854775808L;
				}
				else
				{
					result = long.Parse(serializableData.Value);
				}
				break;
			case TypeCode.UInt64:
				if (serializableData.Value == string.Empty)
				{
					result = 0uL;
				}
				else
				{
					result = ulong.Parse(serializableData.Value);
				}
				break;
			case TypeCode.Single:
				if (serializableData.Value == string.Empty)
				{
					result = -3.40282347E+38f;
				}
				else
				{
					result = float.Parse(serializableData.Value);
				}
				break;
			case TypeCode.Double:
				if (serializableData.Value == string.Empty)
				{
					result = -1.7976931348623157E+308;
				}
				else
				{
					result = double.Parse(serializableData.Value);
				}
				break;
			case TypeCode.Decimal:
				if (serializableData.Value == string.Empty)
				{
					result = -79228162514264337593543950335m;
				}
				else
				{
					result = decimal.Parse(serializableData.Value);
				}
				break;
			case TypeCode.DateTime:
				if (serializableData.Value == string.Empty)
				{
					result = DateTime.Now;
				}
				else
				{
					result = DateTime.Parse(serializableData.Value);
				}
				break;
			case TypeCode.String:
				result = serializableData.Value;
				break;
			}
			return result;
		}

		protected override BindingFlags GetFlags(Type type, XmlClassSerializable attribute)
		{
			BindingFlags flags = base.GetFlags(type, attribute);
			return flags | (BindingFlags.SetField | BindingFlags.SetProperty);
		}
	}
}
