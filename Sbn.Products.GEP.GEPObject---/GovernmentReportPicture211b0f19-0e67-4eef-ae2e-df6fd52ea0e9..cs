namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Controls.Imaging.ImagingObject;
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("تصوير گزارش دولت"), DisplayName("تصوير گزارش دولت"), ItemsType("Sbn.Products.GEP.GEPObject.GovernmentReportPictures"), ObjectCode("9063")]
    public class GovernmentReportPicture : ImageDocument
    {
        public GovernmentReportPicture()
        {
        }

        public GovernmentReportPicture(ImageDocument InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            return new GovernmentReportPicture { ID = base.ID };
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
