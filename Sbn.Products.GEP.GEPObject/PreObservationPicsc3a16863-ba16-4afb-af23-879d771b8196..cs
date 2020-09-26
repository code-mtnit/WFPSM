namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName(""), Description(""), ItemsType("Sbn.Products.GEP.GEPObject.PreObservationPic"), SystemName("GEP")]
    public class PreObservationPics : SbnListObject<PreObservationPic>
    {
        public override object Clone(string sNodeName)
        {
            PreObservationPics pics = new PreObservationPics();
            foreach (PreObservationPic pic in this)
            {
                pics.Add((PreObservationPic) pic.Clone(sNodeName));
            }
            return pics;
        }
    }
}
