namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.AnnouncementAttach")]
    public class AnnouncementAttachs : SbnListObject<AnnouncementAttach>
    {
        public override object Clone(string sNodeName)
        {
            AnnouncementAttachs attachs = new AnnouncementAttachs();
            foreach (AnnouncementAttach attach in this)
            {
                attachs.Add((AnnouncementAttach) attach.Clone(sNodeName));
            }
            return attachs;
        }
    }
}
