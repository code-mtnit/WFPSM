namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName(""), SystemName("GEP"), Description(""), ItemsType("Sbn.Products.GEP.GEPObject.GovernmentReport")]
    public class GovernmentReports : SbnListObject<GovernmentReport>
    {
        public override object Clone(string sNodeName)
        {
            GovernmentReports reports = new GovernmentReports();
            foreach (GovernmentReport report in this)
            {
                reports.Add((GovernmentReport) report.Clone(sNodeName));
            }
            return reports;
        }
    }
}
