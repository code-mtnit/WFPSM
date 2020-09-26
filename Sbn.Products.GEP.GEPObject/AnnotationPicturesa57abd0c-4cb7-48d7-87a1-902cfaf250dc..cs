namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ItemsType("Sbn.Products.GEP.GEPObject.AnnotationPicture")]
    public class AnnotationPictures : SbnListObject<AnnotationPicture>
    {
        public override object Clone(string sNodeName)
        {
            AnnotationPictures pictures = new AnnotationPictures();
            foreach (AnnotationPicture picture in this)
            {
                pictures.Add((AnnotationPicture) picture.Clone(sNodeName));
            }
            return pictures;
        }
    }
}
