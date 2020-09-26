namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.LawDocumentTemplate")]
    public class LawDocumentTemplates : SbnListObject<LawDocumentTemplate>
    {
        public override object Clone(string sNodeName)
        {
            LawDocumentTemplates templates = new LawDocumentTemplates();
            foreach (LawDocumentTemplate template in this)
            {
                templates.Add((LawDocumentTemplate) template.Clone(sNodeName));
            }
            return templates;
        }
    }
}
