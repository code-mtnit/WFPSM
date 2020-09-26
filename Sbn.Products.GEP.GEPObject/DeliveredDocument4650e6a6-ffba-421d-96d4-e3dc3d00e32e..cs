namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, ObjectCode("9287"), SystemName("GEP"), Description("مستند تحويلي"), DisplayName("مستند تحويلي"), ItemsType("Sbn.Products.GEP.GEPObject.DeliveredDocuments")]
    public class DeliveredDocument : SbnObject
    {
        private LetterAttachments _Attachments;
        private Document _CoDocument;
        private DocumentType _CoDocumentType;
        private BasicInfoDetail _DeliveryType;
        private BasicInfoDetail _SecurityLevel;

        public DeliveredDocument()
        {
        }

        public DeliveredDocument(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            DeliveredDocument document = new DeliveredDocument {
                ID = base.ID
            };
            if (!object.ReferenceEquals(this.CoDocument, null))
            {
                document.CoDocument = (Document) this.CoDocument.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Attachments, null))
            {
                document.Attachments = (LetterAttachments) this.Attachments.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoDocumentType, null))
            {
                document.CoDocumentType = (DocumentType) this.CoDocumentType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.DeliveryType, null))
            {
                document.DeliveryType = (BasicInfoDetail) this.DeliveryType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.SecurityLevel, null))
            {
                document.SecurityLevel = (BasicInfoDetail) this.SecurityLevel.Clone(sNodeName);
            }
            return document;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._CoDocument = new Document();
            this._Attachments = new LetterAttachments();
            this._CoDocumentType = new DocumentType();
            this._DeliveryType = new BasicInfoDetail();
            this._SecurityLevel = new BasicInfoDetail();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_AttachmentsID
        {
            get
            {
                return "DeliveredDocument.AttachmentsID";
            }
        }

        public static string at_CoDocument_ActivitiesFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.CoDocument.ActivitiesFirstLevelAttributes";
            }
        }

        public static string at_CoDocument_CreatorPersonFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.CoDocument.CreatorPersonFirstLevelAttributes";
            }
        }

        public static string at_CoDocument_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.CoDocument.DocumentTypeFirstLevelAttributes";
            }
        }

        public static string at_CoDocument_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.CoDocument.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CoDocumentFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.CoDocumentFirstLevelAttributes";
            }
        }

        public static string at_CoDocumentID
        {
            get
            {
                return "DeliveredDocument.CoDocumentID";
            }
        }

        public static string at_CoDocumentType_CoDefaultUIFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.CoDocumentType.CoDefaultUIFirstLevelAttributes";
            }
        }

        public static string at_CoDocumentType_PictureFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.CoDocumentType.PictureFirstLevelAttributes";
            }
        }

        public static string at_CoDocumentType_PropertiesFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.CoDocumentType.PropertiesFirstLevelAttributes";
            }
        }

        public static string at_CoDocumentType_SubSystemFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.CoDocumentType.SubSystemFirstLevelAttributes";
            }
        }

        public static string at_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.CoDocumentTypeFirstLevelAttributes";
            }
        }

        public static string at_CoDocumentTypeID
        {
            get
            {
                return "DeliveredDocument.CoDocumentTypeID";
            }
        }

        public static string at_DeliveryType_ParentFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.DeliveryType.ParentFirstLevelAttributes";
            }
        }

        public static string at_DeliveryTypeFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.DeliveryTypeFirstLevelAttributes";
            }
        }

        public static string at_DeliveryTypeID
        {
            get
            {
                return "DeliveredDocument.DeliveryTypeID";
            }
        }

        public static string at_SecurityLevel_ParentFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.SecurityLevel.ParentFirstLevelAttributes";
            }
        }

        public static string at_SecurityLevelFirstLevelAttributes
        {
            get
            {
                return "DeliveredDocument.SecurityLevelFirstLevelAttributes";
            }
        }

        public static string at_SecurityLevelID
        {
            get
            {
                return "DeliveredDocument.SecurityLevelID";
            }
        }

        [DisplayName("ضمائم"), Category("مشخصات تکمیلی"), DocumentAttributeID("27103"), Browsable(true), Description("ضمائم"), IsRelational("False"), AttributeType("LetterAttachments"), IsMiddleTableExist("False"), RelationTable("DELIVEREDDOC_ATTACHMENTS_M")]
        public LetterAttachments Attachments
        {
            get
            {
                return this._Attachments;
            }
            set
            {
                this._Attachments = value;
            }
        }

        [Category("مشخصات اصلی"), AttributeType("Document"), Browsable(true), IsRelational("False"), Description("سند مرتبط"), DisplayName("سند مرتبط"), IsMiddleTableExist("False"), RelationTable(""), DocumentAttributeID("27102")]
        public Document CoDocument
        {
            get
            {
                return this._CoDocument;
            }
            set
            {
                this._CoDocument = value;
            }
        }

        [AttributeType("DocumentType"), IsMiddleTableExist("False"), RelationTable(""), IsRelational("False"), DocumentAttributeID("27105"), Browsable(true), Description("نوع سند"), DisplayName("نوع سند"), Category("مشخصات اصلی")]
        public DocumentType CoDocumentType
        {
            get
            {
                return this._CoDocumentType;
            }
            set
            {
                this._CoDocumentType = value;
            }
        }

        [DisplayName("نوع تحویل"), Description("نوع تحویل"), IsMiddleTableExist("False"), DocumentAttributeID("27106"), Browsable(true), RelationTable(""), AttributeType("BasicInfoDetail"), Category("مشخصات اصلی"), IsRelational("False")]
        public BasicInfoDetail DeliveryType
        {
            get
            {
                return this._DeliveryType;
            }
            set
            {
                this._DeliveryType = value;
            }
        }

        [Category("مشخصات اصلی"), DisplayName("طبقه بندی"), DocumentAttributeID("27107"), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable(""), Description("طبقه بندی")]
        public BasicInfoDetail SecurityLevel
        {
            get
            {
                return this._SecurityLevel;
            }
            set
            {
                this._SecurityLevel = value;
            }
        }
    }
}
