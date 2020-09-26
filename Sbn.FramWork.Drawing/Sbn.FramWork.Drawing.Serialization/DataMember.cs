using System;
using System.Reflection;

namespace Sbn.FramWork.Drawing.Serialization
{
	public class DataMember
	{
		private MemberInfo _dataInfo = null;

		private Type _typeInfo = null;

		public MemberInfo DataInfo
		{
			get
			{
				return this._dataInfo;
			}
		}

		public Type TypeInfo
		{
			get
			{
				return this._typeInfo;
			}
		}

		public DataMember(MemberInfo dataInfo, Type typeInfo)
		{
			this._dataInfo = dataInfo;
			this._typeInfo = typeInfo;
		}
	}
}
