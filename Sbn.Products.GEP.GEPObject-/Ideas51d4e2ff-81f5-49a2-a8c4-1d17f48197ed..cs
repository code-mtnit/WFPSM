namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.Idea"), SystemName("GEP"), Description(""), DisplayName("")]
    public class Ideas : SbnListObject<Idea>
    {
        public override object Clone(string sNodeName)
        {
            Ideas ideas = new Ideas();
            foreach (Idea idea in this)
            {
                ideas.Add((Idea) idea.Clone(sNodeName));
            }
            return ideas;
        }
    }
}
