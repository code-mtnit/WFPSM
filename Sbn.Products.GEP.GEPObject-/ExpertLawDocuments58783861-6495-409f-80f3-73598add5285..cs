namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), DisplayName(""), Description(""), ItemsType("Sbn.Products.GEP.GEPObject.ExpertLawDocument")]
    public class ExpertLawDocuments : SbnListObject<ExpertLawDocument>
    {
        public override object Clone(string sNodeName)
        {
            ExpertLawDocuments documents = new ExpertLawDocuments();
            foreach (ExpertLawDocument document in this)
            {
                documents.Add((ExpertLawDocument) document.Clone(sNodeName));
            }
            return documents;
        }
    }
}
