using Sbn.Core;
using Sbn.Libs.AssemblyTools;
using System;
using System.ComponentModel;

namespace Sbn.Products.GEP.GEPObject
{
    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.FileSetting"), SystemName("GEP"), Description("فهرست تنظیمات"), DisplayName("فهرست تنظیمات")]
    public class FileSettings : SbnListObject<FileSetting>
    {
        public override object Clone(string sNodeName)
        {
            FileSettings settings = new FileSettings();
            foreach (FileSetting setting in this)
            {
                settings.Add((FileSetting)setting.Clone(sNodeName));
            }
            return settings;
        }
    }
}
