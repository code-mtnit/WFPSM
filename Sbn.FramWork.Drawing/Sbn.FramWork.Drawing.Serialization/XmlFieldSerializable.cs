using System;

namespace Sbn.FramWork.Drawing.Serialization
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	public class XmlFieldSerializable : XmlSerializable
	{
		public XmlFieldSerializable()
		{
		}

		public XmlFieldSerializable(string tagName) : base(tagName)
		{
		}
	}
}
