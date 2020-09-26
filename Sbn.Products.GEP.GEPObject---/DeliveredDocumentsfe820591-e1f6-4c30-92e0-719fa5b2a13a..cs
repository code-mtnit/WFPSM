namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.DeliveredDocument"), Description(""), DisplayName("")]
    public class DeliveredDocuments : SbnListObject<DeliveredDocument>
    {
        public override object Clone(string sNodeName)
        {
            DeliveredDocuments documents = new DeliveredDocuments();
            foreach (DeliveredDocument document in this)
            {
                documents.Add((DeliveredDocument) document.Clone(sNodeName));
            }
            return documents;
        }
    }
}
