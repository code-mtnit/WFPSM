namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName(""), Description(""), ItemsType("Sbn.Products.GEP.GEPObject.GovAnnouncement"), SystemName("GEP")]
    public class GovAnnouncements : SbnListObject<GovAnnouncement>
    {
        public override object Clone(string sNodeName)
        {
            GovAnnouncements announcements = new GovAnnouncements();
            foreach (GovAnnouncement announcement in this)
            {
                announcements.Add((GovAnnouncement) announcement.Clone(sNodeName));
            }
            return announcements;
        }
    }
}
