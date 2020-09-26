namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.Law"), Description(""), DisplayName("")]
    public class Laws : SbnListObject<Law>
    {
        public override object Clone(string sNodeName)
        {
            Laws laws = new Laws();
            foreach (Law law in this)
            {
                laws.Add((Law) law.Clone(sNodeName));
            }
            return laws;
        }
    }
}
