namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Controls.Imaging.ImagingObject;
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("لايه مربوط به تصاوير يادداشت يا پاراف"), DisplayName("لايه مربوط به تصاوير يادداشت يا پاراف"), ObjectCode("9264"), ItemsType("Sbn.Products.GEP.GEPObject.AnnotationPictures")]
    public class AnnotationPicture : Layer
    {
        private BasicInfoDetail _LayerAccessright;
        private Worker _Owner;
        private AnnotationElements _PicElements;

        public AnnotationPicture()
        {
        }

        public AnnotationPicture(Layer InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            AnnotationPicture picture = new AnnotationPicture {
                ID = base.ID
            };
            if (!object.ReferenceEquals(this.PicElements, null))
            {
                picture.PicElements = (AnnotationElements) this.PicElements.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Owner, null))
            {
                picture.Owner = (Worker) this.Owner.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.LayerAccessright, null))
            {
                picture.LayerAccessright = (BasicInfoDetail) this.LayerAccessright.Clone(sNodeName);
            }
            return picture;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._PicElements = new AnnotationElements();
            this._Owner = new Worker();
            this._LayerAccessright = new BasicInfoDetail();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_LayerAccessright_ParentFirstLevelAttributes
        {
            get
            {
                return "AnnotationPicture.LayerAccessright.ParentFirstLevelAttributes";
            }
        }

        public static string at_LayerAccessrightFirstLevelAttributes
        {
            get
            {
                return "AnnotationPicture.LayerAccessrightFirstLevelAttributes";
            }
        }

        public static string at_LayerAccessrightID
        {
            get
            {
                return "AnnotationPicture.LayerAccessrightID";
            }
        }

        public static string at_Owner_AccessrightsFirstLevelAttributes
        {
            get
            {
                return "AnnotationPicture.Owner.AccessrightsFirstLevelAttributes";
            }
        }

        public static string at_Owner_CoPersonFirstLevelAttributes
        {
            get
            {
                return "AnnotationPicture.Owner.CoPersonFirstLevelAttributes";
            }
        }

        public static string at_Owner_CoPositionFirstLevelAttributes
        {
            get
            {
                return "AnnotationPicture.Owner.CoPositionFirstLevelAttributes";
            }
        }

        public static string at_Owner_RestrictionsFirstLevelAttributes
        {
            get
            {
                return "AnnotationPicture.Owner.RestrictionsFirstLevelAttributes";
            }
        }

        public static string at_Owner_WorkerJobFirstLevelAttributes
        {
            get
            {
                return "AnnotationPicture.Owner.WorkerJobFirstLevelAttributes";
            }
        }

        public static string at_OwnerFirstLevelAttributes
        {
            get
            {
                return "AnnotationPicture.OwnerFirstLevelAttributes";
            }
        }

        public static string at_OwnerID
        {
            get
            {
                return "AnnotationPicture.OwnerID";
            }
        }

        public static string at_PicElementsFirstLevelAttributes
        {
            get
            {
                return "AnnotationPicture.PicElementsFirstLevelAttributes";
            }
        }

        public static string at_PicElementsID
        {
            get
            {
                return "AnnotationPicture.PicElementsID";
            }
        }

        [Browsable(true), DocumentAttributeID("9379"), AttributeType("BasicInfoDetail"), IsRelational("False"), Description("سطح دسترسی"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("سطح دسترسی"), Category("")]
        public BasicInfoDetail LayerAccessright
        {
            get
            {
                return this._LayerAccessright;
            }
            set
            {
                this._LayerAccessright = value;
            }
        }

        [Description("ایجاد کننده"), RelationTable(""), DisplayName("ایجاد کننده"), Category(""), DocumentAttributeID("9370"), Browsable(true), IsRelational("False"), AttributeType("Worker"), IsMiddleTableExist("False")]
        public Worker Owner
        {
            get
            {
                return this._Owner;
            }
            set
            {
                this._Owner = value;
            }
        }

        [DocumentAttributeID("9378"), Description("اجزاء لایه تصاویر"), DisplayName("اجزاء"), Category(""), Browsable(true), IsRelational("False"), AttributeType("AnnotationElements"), IsMiddleTableExist("False"), RelationTable("ANNOTATIONPICTURE_ELMS_M")]
        public AnnotationElements PicElements
        {
            get
            {
                return this._PicElements;
            }
            set
            {
                this._PicElements = value;
            }
        }
    }
}
