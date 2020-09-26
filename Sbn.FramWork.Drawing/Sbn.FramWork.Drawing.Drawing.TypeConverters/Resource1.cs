using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Sbn.FramWork.Drawing.Drawing.TypeConverters
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	public class Resource1
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resource1.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Sbn.FramWork.Drawing.Drawing.TypeConverters.Resource1", typeof(Resource1).Assembly);
					Resource1.resourceMan = resourceManager;
				}
				return Resource1.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return Resource1.resourceCulture;
			}
			set
			{
				Resource1.resourceCulture = value;
			}
		}

		public static string GridManager
		{
			get
			{
				return Resource1.ResourceManager.GetString("GridManager", Resource1.resourceCulture);
			}
		}

		public static string ShapeAppearance
		{
			get
			{
				return Resource1.ResourceManager.GetString("ShapeAppearance", Resource1.resourceCulture);
			}
		}

		internal Resource1()
		{
		}
	}
}
