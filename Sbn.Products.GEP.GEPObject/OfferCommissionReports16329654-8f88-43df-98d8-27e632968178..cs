namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName(""), Description(""), ItemsType("Sbn.Products.GEP.GEPObject.OfferCommissionReport"), SystemName("GEP")]
    public class OfferCommissionReports : SbnListObject<OfferCommissionReport>
    {
        public override object Clone(string sNodeName)
        {
            OfferCommissionReports reports = new OfferCommissionReports();
            foreach (OfferCommissionReport report in this)
            {
                reports.Add((OfferCommissionReport) report.Clone(sNodeName));
            }
            return reports;
        }
    }
}
