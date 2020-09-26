namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), SystemName("GEP"), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.OfferCommission")]
    public class OfferCommissions : SbnListObject<OfferCommission>
    {
        public override object Clone(string sNodeName)
        {
            OfferCommissions commissions = new OfferCommissions();
            foreach (OfferCommission commission in this)
            {
                commissions.Add((OfferCommission) commission.Clone(sNodeName));
            }
            return commissions;
        }
    }
}
