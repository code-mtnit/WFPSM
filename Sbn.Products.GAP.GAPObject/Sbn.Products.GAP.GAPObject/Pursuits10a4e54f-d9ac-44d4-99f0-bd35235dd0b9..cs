namespace Sbn.Products.GAP.GAPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName(""), ItemsType("Sbn.Products.GAP.GAPObject.Pursuit"), SystemName("GAP"), Description("")]
    public class Pursuits : SbnListObject<Pursuit>
    {
        public override object Clone(string sNodeName)
        {
            Pursuits pursuits = new Pursuits();
            foreach (Pursuit pursuit in this)
            {
                pursuits.Add((Pursuit) pursuit.Clone(sNodeName));
            }
            return pursuits;
        }
    }
}
