namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.OfferCommissionReportPic"), Description(""), DisplayName(""), SystemName("GEP")]
    public class OfferCommissionReportPics : SbnListObject<OfferCommissionReportPic>
    {
        public override object Clone(string sNodeName)
        {
            OfferCommissionReportPics pics = new OfferCommissionReportPics();
            foreach (OfferCommissionReportPic pic in this)
            {
                pics.Add((OfferCommissionReportPic) pic.Clone(sNodeName));
            }
            return pics;
        }
    }
}
