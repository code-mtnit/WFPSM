namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), ItemsType("Sbn.Products.GEP.GEPObject.GovSessionMember"), SystemName("GEP"), DisplayName("")]
    public class GovSessionMembers : SbnListObject<GovSessionMember>
    {
        public override object Clone(string sNodeName)
        {
            GovSessionMembers members = new GovSessionMembers();
            foreach (GovSessionMember member in this)
            {
                members.Add((GovSessionMember) member.Clone(sNodeName));
            }
            return members;
        }
    }
}
