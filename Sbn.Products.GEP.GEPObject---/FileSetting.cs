using Sbn.Core;
using Sbn.Libs.AssemblyTools;
using System;
using System.ComponentModel;

namespace Sbn.Products.GEP.GEPObject
{
    [Serializable, DisplayName("تنظیمات"), Description("تنظیمات"), SystemName("GEP"), ObjectCode(""), ItemsType("Sbn.Products.GEP.GEPObject.FileSettings")]
    public class FileSetting : SbnObject
    {
       
        public string Name { get; set; }
        public string value { get; set; }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override SbnObject Clone(string sNodeName)
        {
            FileSetting fileSetting = new FileSetting();
            if (this.Name != null)
            {
                fileSetting.Name = (string)this.Name.Clone();
            }
            if (this.value != null)
            {
                fileSetting.value = (string)this.value.Clone();
            }
            return fileSetting;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
