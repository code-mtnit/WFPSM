namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.AO_Offer")]
    public class AO_Offers : SbnListObject<AO_Offer>
    {
        public override object Clone(string sNodeName)
        {
            AO_Offers offers = new AO_Offers();
            foreach (AO_Offer offer in this)
            {
                offers.Add((AO_Offer) offer.Clone(sNodeName));
            }
            return offers;
        }
    }
}
