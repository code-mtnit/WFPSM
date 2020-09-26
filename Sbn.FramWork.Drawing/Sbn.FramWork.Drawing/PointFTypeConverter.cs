using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Sbn.FramWork.Drawing
{
	public class PointFTypeConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(PointF) || base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			object result;
			if (destinationType == typeof(string) && value is PointF)
			{
				PointF pointF = (PointF)value;
				result = pointF.X + "; " + pointF.Y;
			}
			else
			{
				result = base.ConvertTo(context, culture, value, destinationType);
			}
			return result;
		}

		public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
		{
			object result;
			if (propertyValues != null)
			{
				result = new PointF((float)propertyValues["X"], (float)propertyValues["Y"]);
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
