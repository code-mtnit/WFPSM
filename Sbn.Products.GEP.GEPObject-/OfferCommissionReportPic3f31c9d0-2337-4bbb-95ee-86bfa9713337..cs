namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Controls.Imaging.ImagingObject;
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("تصوير گزارش كميسيون"), DisplayName("تصوير گزارش كميسيون"), ObjectCode("9256"), ItemsType("Sbn.Products.GEP.GEPObject.OfferCommissionReportPics")]
    public class OfferCommissionReportPic : ImageDocument
    {
        public OfferCommissionReportPic()
        {
        }

        public OfferCommissionReportPic(ImageDocument InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            return new OfferCommissionReportPic { ID = base.ID };
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
