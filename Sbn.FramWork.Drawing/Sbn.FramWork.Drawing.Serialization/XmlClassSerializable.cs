using System;
using System.Reflection;

namespace Sbn.FramWork.Drawing.Serialization
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
	public class XmlClassSerializable : XmlSerializable
	{
		private bool _deep = true;

		private BindingFlags _flags = BindingFlags.Default;

		public bool Deep
		{
			get
			{
				return this._deep;
			}
		}

		public BindingFlags Flags
		{
			get
			{
				return this._flags;
			}
		}

		public XmlClassSerializable()
		{
		}

		public XmlClassSerializable(string tagName) : base(tagName)
		{
		}

		public XmlClassSerializable(string tagName, bool deep) : base(tagName)
		{
			this._deep = deep;
		}

		public XmlClassSerializable(string tagName, bool deep, BindingFlags flags) : base(tagName)
		{
			this._deep = deep;
			this._flags = flags;
		}
	}
}
