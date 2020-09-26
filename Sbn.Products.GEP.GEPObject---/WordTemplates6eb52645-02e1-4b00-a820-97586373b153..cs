namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.WordTemplate"), SystemName("GEP")]
    public class WordTemplates : SbnListObject<WordTemplate>
    {
        public override object Clone(string sNodeName)
        {
            WordTemplates templates = new WordTemplates();
            foreach (WordTemplate template in this)
            {
                templates.Add((WordTemplate) template.Clone(sNodeName));
            }
            return templates;
        }
    }
}
