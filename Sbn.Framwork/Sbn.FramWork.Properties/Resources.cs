using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Sbn.FramWork.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Sbn.FramWork.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		internal static Bitmap add
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("add", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap Blue_hills
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Blue_hills", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap delete
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("delete", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap hide_left16
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("hide-left16", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap hide_right16
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("hide-right16", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap IconCSV16
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("IconCSV16", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap IconExcel16
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("IconExcel16", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap navigate_left16
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("navigate-left16", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap navigate_right16
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("navigate-right16", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Icon Rotate
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Rotate", Resources.resourceCulture);
				return (Icon)@object;
			}
		}

		internal static Bitmap text_allcaps
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("text_allcaps", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal Resources()
		{
		}
	}
}
