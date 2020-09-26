namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Controls.Imaging.ImagingObject;
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ObjectCode("9272"), Description("تصوير پاراف يا يادداشت كه با قلم نوري انجام مي شود"), DisplayName("تصوير پاراف يا يادداشت كه با قلم نوري انجام مي شود"), ItemsType("Sbn.Products.GEP.GEPObject.AnnotationElements"), SystemName("GEP")]
    public class AnnotationElement : Element
    {
        public AnnotationElement()
        {
        }

        public AnnotationElement(Element InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            return new AnnotationElement { ID = base.ID };
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
