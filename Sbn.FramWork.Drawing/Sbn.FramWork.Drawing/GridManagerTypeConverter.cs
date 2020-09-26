using Sbn.FramWork.Drawing.Drawing.TypeConverters;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Sbn.FramWork.Drawing
{
	public class GridManagerTypeConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(GridManager) || base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			object result;
			if (destinationType == typeof(string) && value is GridManager)
			{
				GridManager gridManager = (GridManager)value;
				result = Resource1.GridManager;
			}
			else
			{
				result = base.ConvertTo(context, culture, value, destinationType);
			}
			return result;
		}
	}
}
