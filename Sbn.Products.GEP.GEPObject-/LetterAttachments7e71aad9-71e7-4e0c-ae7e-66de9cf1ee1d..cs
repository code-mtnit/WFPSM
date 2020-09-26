namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.LetterAttachment")]
    public class LetterAttachments : SbnListObject<LetterAttachment>
    {
        public override object Clone(string sNodeName)
        {
            LetterAttachments attachments = new LetterAttachments();
            foreach (LetterAttachment attachment in this)
            {
                attachments.Add((LetterAttachment) attachment.Clone(sNodeName));
            }
            return attachments;
        }
    }
}
