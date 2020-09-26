namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), SystemName("GEP"), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.OfferOrgUnit")]
    public class OfferOrgUnits : SbnListObject<OfferOrgUnit>
    {
        public override object Clone(string sNodeName)
        {
            OfferOrgUnits units = new OfferOrgUnits();
            foreach (OfferOrgUnit unit in this)
            {
                units.Add((OfferOrgUnit) unit.Clone(sNodeName));
            }
            return units;
        }
    }
}
