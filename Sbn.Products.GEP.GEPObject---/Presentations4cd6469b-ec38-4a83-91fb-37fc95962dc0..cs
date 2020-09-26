namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), SystemName("GEP"), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.Presentation")]
    public class Presentations : SbnListObject<Presentation>
    {
        public override object Clone(string sNodeName)
        {
            Presentations presentations = new Presentations();
            foreach (Presentation presentation in this)
            {
                presentations.Add((Presentation) presentation.Clone(sNodeName));
            }
            return presentations;
        }
    }
}
