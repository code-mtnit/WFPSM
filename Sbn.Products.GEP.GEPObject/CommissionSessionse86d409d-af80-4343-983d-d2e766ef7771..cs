namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("جلسات کمیسیون"), DisplayName("جلسات کمیسیون"), ItemsType("Sbn.Products.GEP.GEPObject.CommissionSession")]
    public class CommissionSessions : SbnListObject<CommissionSession>
    {
        public override object Clone(string sNodeName)
        {
            CommissionSessions sessions = new CommissionSessions();
            foreach (CommissionSession session in this)
            {
                sessions.Add((CommissionSession) session.Clone(sNodeName));
            }
            return sessions;
        }
    }
}
