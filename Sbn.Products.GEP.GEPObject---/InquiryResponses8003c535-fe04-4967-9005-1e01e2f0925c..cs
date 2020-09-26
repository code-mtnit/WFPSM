namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description("فهرستي از پاسخهاي استعلام"), ItemsType("Sbn.Products.GEP.GEPObject.InquiryResponse"), SystemName("GEP"), DisplayName("فهرستي از پاسخهاي استعلام")]
    public class InquiryResponses : SbnListObject<InquiryResponse>
    {
        public override object Clone(string sNodeName)
        {
            InquiryResponses responses = new InquiryResponses();
            foreach (InquiryResponse response in this)
            {
                responses.Add((InquiryResponse) response.Clone(sNodeName));
            }
            return responses;
        }
    }
}
