namespace Sbn.Products.GAP.GAPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), DisplayName(""), ItemsType("Sbn.Products.GAP.GAPObject.PursuitResponse"), SystemName("GAP")]
    public class PursuitResponses : SbnListObject<PursuitResponse>
    {
        public override object Clone(string sNodeName)
        {
            PursuitResponses responses = new PursuitResponses();
            foreach (PursuitResponse response in this)
            {
                responses.Add((PursuitResponse) response.Clone(sNodeName));
            }
            return responses;
        }
    }
}
