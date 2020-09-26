namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("مستندات تايپي"), DisplayName("مستندات تايپي"), ItemsType("Sbn.Products.GEP.GEPObject.GeneralDocument")]
    public class GeneralDocuments : SbnListObject<GeneralDocument>
    {
        public override object Clone(string sNodeName)
        {
            GeneralDocuments documents = new GeneralDocuments();
            foreach (GeneralDocument document in this)
            {
                documents.Add((GeneralDocument) document.Clone(sNodeName));
            }
            return documents;
        }
    }
}
