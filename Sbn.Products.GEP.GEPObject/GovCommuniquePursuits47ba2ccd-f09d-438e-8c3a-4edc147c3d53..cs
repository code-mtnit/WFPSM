namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.GovCommuniquePursuit"), SystemName("GEP")]
    public class GovCommuniquePursuits : SbnListObject<GovCommuniquePursuit>
    {
        public override object Clone(string sNodeName)
        {
            GovCommuniquePursuits pursuits = new GovCommuniquePursuits();
            foreach (GovCommuniquePursuit pursuit in this)
            {
                pursuits.Add((GovCommuniquePursuit) pursuit.Clone(sNodeName));
            }
            return pursuits;
        }
    }
}
