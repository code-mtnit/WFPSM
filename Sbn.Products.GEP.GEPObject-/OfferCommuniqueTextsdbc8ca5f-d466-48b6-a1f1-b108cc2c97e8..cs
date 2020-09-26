namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.OfferCommuniqueText"), Description(""), DisplayName("")]
    public class OfferCommuniqueTexts : SbnListObject<OfferCommuniqueText>
    {
        public override object Clone(string sNodeName)
        {
            OfferCommuniqueTexts texts = new OfferCommuniqueTexts();
            foreach (OfferCommuniqueText text in this)
            {
                texts.Add((OfferCommuniqueText) text.Clone(sNodeName));
            }
            return texts;
        }
    }
}
