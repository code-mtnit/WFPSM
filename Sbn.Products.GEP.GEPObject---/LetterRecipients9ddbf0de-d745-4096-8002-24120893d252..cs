namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName("فهرست گیرندگان"), SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.LetterRecipient"), Description("فهرست گیرندگان")]
    public class LetterRecipients : SbnListObject<LetterRecipient>
    {
        public override object Clone(string sNodeName)
        {
            LetterRecipients recipients = new LetterRecipients();
            foreach (LetterRecipient recipient in this)
            {
                recipients.Add((LetterRecipient) recipient.Clone(sNodeName));
            }
            return recipients;
        }
    }
}
