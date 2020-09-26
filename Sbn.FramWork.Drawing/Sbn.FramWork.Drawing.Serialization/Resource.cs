using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Sbn.FramWork.Drawing.Serialization
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class Resource
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resource.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Sbn.FramWork.Drawing.Serialization.Resource", typeof(Resource).Assembly);
					Resource.resourceMan = resourceManager;
				}
				return Resource.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resource.resourceCulture;
			}
			set
			{
				Resource.resourceCulture = value;
			}
		}

		internal static string Assembly
		{
			get
			{
				return Resource.ResourceManager.GetString("Assembly", Resource.resourceCulture);
			}
		}

		internal static string AssemblyQualifiedName
		{
			get
			{
				return Resource.ResourceManager.GetString("AssemblyQualifiedName", Resource.resourceCulture);
			}
		}

		internal static string Constant
		{
			get
			{
				return Resource.ResourceManager.GetString("Constant", Resource.resourceCulture);
			}
		}

		internal static string Data
		{
			get
			{
				return Resource.ResourceManager.GetString("Data", Resource.resourceCulture);
			}
		}

		internal static string FieldInfo
		{
			get
			{
				return Resource.ResourceManager.GetString("FieldInfo", Resource.resourceCulture);
			}
		}

		internal static string FieldName
		{
			get
			{
				return Resource.ResourceManager.GetString("FieldName", Resource.resourceCulture);
			}
		}

		internal static string NoConstant
		{
			get
			{
				return Resource.ResourceManager.GetString("NoConstant", Resource.resourceCulture);
			}
		}

		internal static string NoData
		{
			get
			{
				return Resource.ResourceManager.GetString("NoData", Resource.resourceCulture);
			}
		}

		internal static string NoReadeable
		{
			get
			{
				return Resource.ResourceManager.GetString("NoReadeable", Resource.resourceCulture);
			}
		}

		internal static string NoSerializableData
		{
			get
			{
				return Resource.ResourceManager.GetString("NoSerializableData", Resource.resourceCulture);
			}
		}

		internal static string NoWriteable
		{
			get
			{
				return Resource.ResourceManager.GetString("NoWriteable", Resource.resourceCulture);
			}
		}

		internal static string PropertyInfo
		{
			get
			{
				return Resource.ResourceManager.GetString("PropertyInfo", Resource.resourceCulture);
			}
		}

		internal static string Readeable
		{
			get
			{
				return Resource.ResourceManager.GetString("Readeable", Resource.resourceCulture);
			}
		}

		internal static string SerializableData
		{
			get
			{
				return Resource.ResourceManager.GetString("SerializableData", Resource.resourceCulture);
			}
		}

		internal static string SerializableDataCollectionCount
		{
			get
			{
				return Resource.ResourceManager.GetString("SerializableDataCollectionCount", Resource.resourceCulture);
			}
		}

		internal static string TagName
		{
			get
			{
				return Resource.ResourceManager.GetString("TagName", Resource.resourceCulture);
			}
		}

		internal static string Type
		{
			get
			{
				return Resource.ResourceManager.GetString("Type", Resource.resourceCulture);
			}
		}

		internal static string Value
		{
			get
			{
				return Resource.ResourceManager.GetString("Value", Resource.resourceCulture);
			}
		}

		internal static string Writeable
		{
			get
			{
				return Resource.ResourceManager.GetString("Writeable", Resource.resourceCulture);
			}
		}

		internal Resource()
		{
		}
	}
}
