namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("استعلام ها"), DisplayName("استعلام ها"), ItemsType("Sbn.Products.GEP.GEPObject.Inquiry")]
    public class Inquiries : SbnListObject<Inquiry>
    {
        public override object Clone(string sNodeName)
        {
            Inquiries inquiries = new Inquiries();
            foreach (Inquiry inquiry in this)
            {
                inquiries.Add((Inquiry) inquiry.Clone(sNodeName));
            }
            return inquiries;
        }
    }
}
