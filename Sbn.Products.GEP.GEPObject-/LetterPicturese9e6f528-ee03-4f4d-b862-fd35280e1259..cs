namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.LetterPicture"), Description(""), DisplayName("")]
    public class LetterPictures : SbnListObject<LetterPicture>
    {
        public override object Clone(string sNodeName)
        {
            LetterPictures pictures = new LetterPictures();
            foreach (LetterPicture picture in this)
            {
                pictures.Add((LetterPicture) picture.Clone(sNodeName));
            }
            return pictures;
        }
    }
}
