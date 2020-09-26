namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.GovernStaticMember"), DisplayName("اعضاء ثابت دولت"), SystemName("GEP"), Description("اعضاء ثابت دولت")]
    public class GovernStaticMembers : SbnListObject<GovernStaticMember>
    {
        public override object Clone(string sNodeName)
        {
            GovernStaticMembers members = new GovernStaticMembers();
            foreach (GovernStaticMember member in this)
            {
                members.Add((GovernStaticMember) member.Clone(sNodeName));
            }
            return members;
        }
    }
}
