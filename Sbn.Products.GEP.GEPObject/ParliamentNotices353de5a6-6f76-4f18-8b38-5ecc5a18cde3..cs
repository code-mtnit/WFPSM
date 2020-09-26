namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName(""), Description(""), SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.ParliamentNotice")]
    public class ParliamentNotices : SbnListObject<ParliamentNotice>
    {
        public override object Clone(string sNodeName)
        {
            ParliamentNotices notices = new ParliamentNotices();
            foreach (ParliamentNotice notice in this)
            {
                notices.Add((ParliamentNotice) notice.Clone(sNodeName));
            }
            return notices;
        }
    }
}
