namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("فهرست ضمائم دستور مستقل"), DisplayName("فهرست ضمائم دستور مستقل"), ItemsType("Sbn.Products.GEP.GEPObject.PresentationAttach")]
    public class PresentationAttachs : SbnListObject<PresentationAttach>
    {
        public override object Clone(string sNodeName)
        {
            PresentationAttachs attachs = new PresentationAttachs();
            foreach (PresentationAttach attach in this)
            {
                attachs.Add((PresentationAttach) attach.Clone(sNodeName));
            }
            return attachs;
        }
    }
}
