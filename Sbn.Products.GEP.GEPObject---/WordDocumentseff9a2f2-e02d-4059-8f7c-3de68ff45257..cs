namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description("فايلهاي تايپي"), SystemName("GEP"), DisplayName("فايلهاي تايپي"), ItemsType("Sbn.Products.GEP.GEPObject.WordDocument")]
    public class WordDocuments : SbnListObject<WordDocument>
    {
        public override object Clone(string sNodeName)
        {
            WordDocuments documents = new WordDocuments();
            foreach (WordDocument document in this)
            {
                documents.Add((WordDocument) document.Clone(sNodeName));
            }
            return documents;
        }
    }
}
