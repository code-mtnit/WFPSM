using System;
using System.ComponentModel;

namespace JThomas.Extensions
{
	public class ReferencedDescriptionAttribute : DescriptionAttribute
	{
		public ReferencedDescriptionAttribute(Type referencedType, string propertyName)
		{
			string descriptionValue = "Referenced description not available";
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(referencedType);
			if (properties != null)
			{
				PropertyDescriptor propertyDescriptor = properties[propertyName];
				if (propertyDescriptor != null)
				{
					AttributeCollection attributes = propertyDescriptor.Attributes;
					DescriptionAttribute descriptionAttribute = (DescriptionAttribute)attributes[typeof(DescriptionAttribute)];
					if (!string.IsNullOrEmpty(descriptionAttribute.Description))
					{
						descriptionValue = descriptionAttribute.Description;
					}
				}
			}
			base.DescriptionValue = descriptionValue;
		}
	}
}
