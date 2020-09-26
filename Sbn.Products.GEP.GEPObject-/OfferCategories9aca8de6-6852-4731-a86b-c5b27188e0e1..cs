namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.OfferCategory"), SystemName("GEP")]
    public class OfferCategories : SbnListObject<OfferCategory>
    {
        public override object Clone(string sNodeName)
        {
            OfferCategories categories = new OfferCategories();
            foreach (OfferCategory category in this)
            {
                categories.Add((OfferCategory) category.Clone(sNodeName));
            }
            return categories;
        }
    }
}
