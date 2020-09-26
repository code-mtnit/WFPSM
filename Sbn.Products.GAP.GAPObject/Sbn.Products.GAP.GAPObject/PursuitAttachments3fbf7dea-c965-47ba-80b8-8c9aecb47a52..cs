namespace Sbn.Products.GAP.GAPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), SystemName("GAP"), DisplayName(""), ItemsType("Sbn.Products.GAP.GAPObject.PursuitAttachment")]
    public class PursuitAttachments : SbnListObject<PursuitAttachment>
    {
        public override object Clone(string sNodeName)
        {
            PursuitAttachments attachments = new PursuitAttachments();
            foreach (PursuitAttachment attachment in this)
            {
                attachments.Add((PursuitAttachment)attachment.Clone(sNodeName));
            }
            return attachments;
        }
    }
}
