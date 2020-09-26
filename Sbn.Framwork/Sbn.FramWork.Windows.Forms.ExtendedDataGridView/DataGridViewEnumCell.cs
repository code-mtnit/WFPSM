using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Sbn.FramWork.Windows.Forms.ExtendedDataGridView
{
	internal class DataGridViewEnumCell : DataGridViewTextBoxCell
	{
		public static string GetDescription(Enum en)
		{
			Type type = en.GetType();
			MemberInfo[] member = type.GetMember(en.ToString());
			string result;
			if (member != null && member.Length > 0)
			{
				object[] customAttributes = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
				if (customAttributes != null && customAttributes.Length > 0)
				{
					result = ((DescriptionAttribute)customAttributes[0]).Description;
					return result;
				}
			}
			result = en.ToString();
			return result;
		}

		protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
		{
			object result;
			if (value is Enum)
			{
				result = DataGridViewEnumCell.GetDescription((Enum)value);
			}
			else
			{
				result = base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
			}
			return result;
		}
	}
}
