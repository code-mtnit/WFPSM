using Sbn.FramWork.Drawing.Drawing.TypeConverters;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Sbn.FramWork.Drawing
{
	public class AppearanceTypeConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(Appearance) || base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			object result;
			if (destinationType == typeof(string) && value is Appearance)
			{
				Appearance appearance = (Appearance)value;
				result = Resource1.ShapeAppearance;
			}
			else
			{
				result = base.ConvertTo(context, culture, value, destinationType);
			}
			return result;
		}
	}
}
