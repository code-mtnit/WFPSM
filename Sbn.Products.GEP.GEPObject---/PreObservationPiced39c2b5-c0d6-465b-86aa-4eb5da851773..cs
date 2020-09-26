namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Controls.Imaging.ImagingObject;
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ObjectCode("9282"), DisplayName("تصوير ارزيابي مقدماتي"), Description("تصوير ارزيابي مقدماتي"), ItemsType("Sbn.Products.GEP.GEPObject.PreObservationPics"), SystemName("GEP")]
    public class PreObservationPic : ImageDocument
    {
        private AnnotationPictures _Annotations;

        public PreObservationPic()
        {
        }

        public PreObservationPic(ImageDocument InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            PreObservationPic pic = new PreObservationPic {
                ID = base.ID
            };
            if (!object.ReferenceEquals(this.Annotations, null))
            {
                pic.Annotations = (AnnotationPictures) this.Annotations.Clone(sNodeName);
            }
            return pic;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._Annotations = new AnnotationPictures();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        [DisplayName("پی نوشتها"), AttributeType("AnnotationPictures"), IsMiddleTableExist("False"), RelationTable("Anns"), Description("پی نوشتها"), Category(""), DocumentAttributeID("9411"), Browsable(true), IsRelational("False")]
        public AnnotationPictures Annotations
        {
            get
            {
                return this._Annotations;
            }
            set
            {
                this._Annotations = value;
            }
        }

        public static string at_AnnotationsFirstLevelAttributes
        {
            get
            {
                return "PreObservationPic.AnnotationsFirstLevelAttributes";
            }
        }

        public static string at_AnnotationsID
        {
            get
            {
                return "PreObservationPic.AnnotationsID";
            }
        }
    }
}
