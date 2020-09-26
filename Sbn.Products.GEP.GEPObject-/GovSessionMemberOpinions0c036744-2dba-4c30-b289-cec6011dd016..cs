namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.GovSessionMemberOpinion"), SystemName("GEP")]
    public class GovSessionMemberOpinions : SbnListObject<GovSessionMemberOpinion>
    {
        public override object Clone(string sNodeName)
        {
            GovSessionMemberOpinions opinions = new GovSessionMemberOpinions();
            foreach (GovSessionMemberOpinion opinion in this)
            {
                opinions.Add((GovSessionMemberOpinion) opinion.Clone(sNodeName));
            }
            return opinions;
        }
    }
}
