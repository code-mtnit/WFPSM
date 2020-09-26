namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.ComSessionMemberOpinion"), DisplayName("")]
    public class ComSessionMemberOpinions : SbnListObject<ComSessionMemberOpinion>
    {
        public override object Clone(string sNodeName)
        {
            ComSessionMemberOpinions opinions = new ComSessionMemberOpinions();
            foreach (ComSessionMemberOpinion opinion in this)
            {
                opinions.Add((ComSessionMemberOpinion) opinion.Clone(sNodeName));
            }
            return opinions;
        }
    }
}
