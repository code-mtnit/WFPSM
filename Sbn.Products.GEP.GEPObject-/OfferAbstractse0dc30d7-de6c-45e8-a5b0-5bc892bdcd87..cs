namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.OfferAbstract"), DisplayName(""), Description(""), SystemName("GEP")]
    public class OfferAbstracts : SbnListObject<OfferAbstract>
    {
        public override object Clone(string sNodeName)
        {
            OfferAbstracts abstracts = new OfferAbstracts();
            foreach (OfferAbstract @abstract in this)
            {
                abstracts.Add((OfferAbstract) @abstract.Clone(sNodeName));
            }
            return abstracts;
        }
    }
}
