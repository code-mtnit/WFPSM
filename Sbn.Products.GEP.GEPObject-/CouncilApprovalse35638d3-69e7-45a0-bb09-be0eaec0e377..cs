namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.CouncilApproval")]
    public class CouncilApprovals : SbnListObject<CouncilApproval>
    {
        public override object Clone(string sNodeName)
        {
            CouncilApprovals approvals = new CouncilApprovals();
            foreach (CouncilApproval approval in this)
            {
                approvals.Add((CouncilApproval) approval.Clone(sNodeName));
            }
            return approvals;
        }
    }
}
