namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), ItemsType("Sbn.Products.GEP.GEPObject.OfferSubject"), SystemName("GEP"), DisplayName("")]
    public class OfferSubjects : SbnListObject<OfferSubject>
    {
        public override object Clone(string sNodeName)
        {
            OfferSubjects subjects = new OfferSubjects();
            foreach (OfferSubject subject in this)
            {
                subjects.Add((OfferSubject) subject.Clone(sNodeName));
            }
            return subjects;
        }
    }
}
