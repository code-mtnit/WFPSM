using System;
using System.Collections.Generic;
using System.Configuration;

namespace Sbn.FramWork.Windows.Forms
{
	internal sealed class gfDataGridViewSetting : ApplicationSettingsBase
	{
		private static gfDataGridViewSetting _defaultInstace = (gfDataGridViewSetting)SettingsBase.Synchronized(new gfDataGridViewSetting());

		public static gfDataGridViewSetting Default
		{
			get
			{
				return gfDataGridViewSetting._defaultInstace;
			}
		}

		[DefaultSettingValue(""), SettingsSerializeAs(SettingsSerializeAs.Binary), UserScopedSetting]
		public Dictionary<string, List<ColumnOrderItem>> ColumnOrder
		{
			get
			{
				return this["ColumnOrder"] as Dictionary<string, List<ColumnOrderItem>>;
			}
			set
			{
				this["ColumnOrder"] = value;
			}
		}
	}
}
