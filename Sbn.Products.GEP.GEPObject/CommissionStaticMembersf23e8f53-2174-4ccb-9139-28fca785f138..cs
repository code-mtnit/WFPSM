namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.CommissionStaticMember"), Description(""), DisplayName(""), SystemName("GEP")]
    public class CommissionStaticMembers : SbnListObject<CommissionStaticMember>
    {
        public override object Clone(string sNodeName)
        {
            CommissionStaticMembers members = new CommissionStaticMembers();
            foreach (CommissionStaticMember member in this)
            {
                members.Add((CommissionStaticMember) member.Clone(sNodeName));
            }
            return members;
        }
    }
}
