namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.CommissionSessionMember")]
    public class CommissionSessionMembers : SbnListObject<CommissionSessionMember>
    {
        public override object Clone(string sNodeName)
        {
            CommissionSessionMembers members = new CommissionSessionMembers();
            foreach (CommissionSessionMember member in this)
            {
                members.Add((CommissionSessionMember) member.Clone(sNodeName));
            }
            return members;
        }
    }
}
