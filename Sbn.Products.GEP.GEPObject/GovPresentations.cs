namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.GovPresentation"), SystemName("GEP")]
    public class GovPresentations : SbnListObject<GovPresentation>
    {
        public override object Clone(string sNodeName)
        {
            GovPresentations offers = new  GovPresentations ();
            foreach (GovPresentation offer in this)
            {
                offers.Add((GovPresentation)offer.Clone(sNodeName));
            }
            return offers;
        }
        public override string ToString()
        {
            string s = "";
            foreach (GovPresentation offer in this)
            {
                s += "," + offer.Title + "";

            }
            return s;
        }

    }
}
