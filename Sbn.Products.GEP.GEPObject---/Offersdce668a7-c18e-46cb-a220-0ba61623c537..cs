namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.Offer"), SystemName("GEP")]
    public class Offers : SbnListObject<Offer>
    {
        public override object Clone(string sNodeName)
        {
            Offers offers = new Offers();
            foreach (Offer offer in this)
            {
                offers.Add((Offer)offer.Clone(sNodeName));
            }
            return offers;
        }
        public override string ToString()
        {
            string s = "";
            foreach (Offer offer in this)
            {
                s += "," + offer.OfficialCode + "";

            }
            return s;
        }

    }
}
