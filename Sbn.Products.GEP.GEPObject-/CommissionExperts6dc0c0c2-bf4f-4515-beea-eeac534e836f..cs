namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("کارشناسان کمیسیون"), DisplayName("کارشناسان کمیسیون"), ItemsType("Sbn.Products.GEP.GEPObject.CommissionExpert")]
    public class CommissionExperts : SbnListObject<CommissionExpert>
    {
        public override object Clone(string sNodeName)
        {
            CommissionExperts experts = new CommissionExperts();
            foreach (CommissionExpert expert in this)
            {
                experts.Add((CommissionExpert) expert.Clone(sNodeName));
            }
            return experts;
        }
    }
}
