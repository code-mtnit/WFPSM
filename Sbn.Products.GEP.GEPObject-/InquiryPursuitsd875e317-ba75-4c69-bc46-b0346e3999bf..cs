namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.InquiryPursuit")]
    public class InquiryPursuits : SbnListObject<InquiryPursuit>
    {
        public override object Clone(string sNodeName)
        {
            InquiryPursuits pursuits = new InquiryPursuits();
            foreach (InquiryPursuit pursuit in this)
            {
                pursuits.Add((InquiryPursuit) pursuit.Clone(sNodeName));
            }
            return pursuits;
        }
    }
}
