namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description("فهرست نظر نهایی کمیسیون"), SystemName("GEP"), DisplayName("فهرست نظر نهایی کمیسیون"), ItemsType("Sbn.Products.GEP.GEPObject.OfferCommissionResult")]
    public class OfferCommissionResults : SbnListObject<OfferCommissionResult>
    {
        public override object Clone(string sNodeName)
        {
            OfferCommissionResults results = new OfferCommissionResults();
            foreach (OfferCommissionResult result in this)
            {
                results.Add((OfferCommissionResult) result.Clone(sNodeName));
            }
            return results;
        }
    }
}
