namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.GovernmentReportPicture"), SystemName("GEP")]
    public class GovernmentReportPictures : SbnListObject<GovernmentReportPicture>
    {
        public override object Clone(string sNodeName)
        {
            GovernmentReportPictures pictures = new GovernmentReportPictures();
            foreach (GovernmentReportPicture picture in this)
            {
                pictures.Add((GovernmentReportPicture) picture.Clone(sNodeName));
            }
            return pictures;
        }
    }
}
