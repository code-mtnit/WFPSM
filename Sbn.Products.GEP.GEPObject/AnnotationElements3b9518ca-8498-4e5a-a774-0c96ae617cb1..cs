namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), DisplayName(""), Description(""), ItemsType("Sbn.Products.GEP.GEPObject.AnnotationElement")]
    public class AnnotationElements : SbnListObject<AnnotationElement>
    {
        public override object Clone(string sNodeName)
        {
            AnnotationElements elements = new AnnotationElements();
            foreach (AnnotationElement element in this)
            {
                elements.Add((AnnotationElement) element.Clone(sNodeName));
            }
            return elements;
        }
    }
}
