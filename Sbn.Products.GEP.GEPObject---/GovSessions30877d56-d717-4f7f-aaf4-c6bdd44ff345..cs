namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName(""), Description(""), ItemsType("Sbn.Products.GEP.GEPObject.GovSession"), SystemName("GEP")]
    public class GovSessions : SbnListObject<GovSession>
    {
        public override object Clone(string sNodeName)
        {
            GovSessions sessions = new GovSessions();
            foreach (GovSession session in this)
            {
                sessions.Add((GovSession) session.Clone(sNodeName));
            }
            return sessions;
        }
    }
}
