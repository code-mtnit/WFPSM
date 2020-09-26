namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Controls.Imaging.ImagingObject;
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName("تصویر نامه"), SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.LetterPictures"), Description("تصویر نامه"), ObjectCode("9058")]
    public class LetterPicture : ImageDocument
    {
        private AnnotationPictures _Annotations;
        private string _FileType;

        public LetterPicture()
        {
        }

        public LetterPicture(ImageDocument InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            LetterPicture picture = new LetterPicture {
                ID = base.ID,
                FileType = this._FileType
            };
            if (!object.ReferenceEquals(this.Annotations, null))
            {
                picture.Annotations = (AnnotationPictures) this.Annotations.Clone(sNodeName);
            }
            return picture;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._FileType = "";
            this._Annotations = new AnnotationPictures();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        [Browsable(true), DocumentAttributeID("9368"), AttributeType("AnnotationPictures"), IsMiddleTableExist("False"), RelationTable("LETTERPICTURE_ANNOTATIONS_M"), IsRelational("False"), Description("پی نوشتها"), DisplayName("پی نوشتها"), Category("")]
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
                return "LetterPicture.AnnotationsFirstLevelAttributes";
            }
        }

        public static string at_AnnotationsID
        {
            get
            {
                return "LetterPicture.AnnotationsID";
            }
        }

        public static string at_FileType
        {
            get
            {
                return "LetterPicture.FileType";
            }
        }

        [Category(""), Description(""), Browsable(true), DisplayName(""), DocumentAttributeID("27136"), IsRelational("false"), AttributeType("String")]
        public string FileType
        {
            get
            {
                return this._FileType;
            }
            set
            {
                this._FileType = value;
            }
        }
    }
}
