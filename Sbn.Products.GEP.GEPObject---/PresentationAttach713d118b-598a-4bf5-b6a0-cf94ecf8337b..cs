namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Controls.Imaging.ImagingObject;
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description("ضميمه دستور مستقل"), SystemName("GEP"), DisplayName("ضميمه دستور مستقل"), ObjectCode("9266"), ItemsType("Sbn.Products.GEP.GEPObject.PresentationAttachs")]
    public class PresentationAttach : ImageDocument
    {
        public PresentationAttach()
        {
        }

        public PresentationAttach(ImageDocument InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            return new PresentationAttach { ID = base.ID };
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
