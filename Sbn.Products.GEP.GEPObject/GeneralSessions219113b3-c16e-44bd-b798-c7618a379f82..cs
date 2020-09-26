namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName(""), Description(""), ItemsType("Sbn.Products.GEP.GEPObject.GeneralSession"), SystemName("GEP")]
    public class GeneralSessions : SbnListObject<GeneralSession>
    {
        public override object Clone(string sNodeName)
        {
            GeneralSessions sessions = new GeneralSessions();
            foreach (GeneralSession session in this)
            {
                sessions.Add((GeneralSession) session.Clone(sNodeName));
            }
            return sessions;
        }
    }
}
