using System;

namespace Sbn.FramWork.Drawing.Serialization
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
	public abstract class XmlSerializable : Attribute
	{
		private string _tagName = string.Empty;

		public string TagName
		{
			get
			{
				return this._tagName;
			}
		}

		public XmlSerializable()
		{
		}

		public XmlSerializable(string tagName)
		{
			this._tagName = tagName;
		}
	}
}
