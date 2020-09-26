namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, ObjectCode("9249"), Description("مستند تايپي"), DisplayName("مستند تايپي"), ItemsType("Sbn.Products.GEP.GEPObject.GeneralDocuments"), SystemName("GEP")]
    public class GeneralDocument : SbnObject
    {
        private PersonalFolder _CorrelateFolder;
        private long _CorrelateObjectID;
        private Offer _CorrelateOffer;
        private BasicInfoDetail _DocumentType;
        private WordDocuments _FileVersions;
        private SbnBoolean _IsHidden;
        private SbnBoolean _IsLocked;
        private SbnBoolean _IsProtected;
        private SbnBoolean _IsZipped;
        private string _Extension;
        private WFPerson _Owner;

        public GeneralDocument()
        {
            this._IsLocked = SbnBoolean.OutOfValue;
            this._IsHidden = SbnBoolean.OutOfValue;
            this._IsProtected = SbnBoolean.OutOfValue;
            this._IsZipped = SbnBoolean.OutOfValue;
        }

        public GeneralDocument(SbnObject InitialObject) : base(InitialObject)
        {
            this._IsLocked = SbnBoolean.OutOfValue;
            this._IsHidden = SbnBoolean.OutOfValue;
            this._IsProtected = SbnBoolean.OutOfValue;
            this._IsZipped = SbnBoolean.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            GeneralDocument document = new GeneralDocument {
                ID = base.ID,
                CorrelateObjectID = this._CorrelateObjectID,
            };
            if (!object.ReferenceEquals(this.DocumentType, null))
            {
                document.DocumentType = (BasicInfoDetail) this.DocumentType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                document.CorrelateOffer = (Offer) this.CorrelateOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.FileVersions, null))
            {
                document.FileVersions = (WordDocuments) this.FileVersions.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Owner, null))
            {
                document.Owner = (WFPerson) this.Owner.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateFolder, null))
            {
                document.CorrelateFolder = (PersonalFolder) this.CorrelateFolder.Clone(sNodeName);
            }
            document.IsLocked = this.IsLocked;
            document.IsHidden = this.IsHidden;
            document.IsProtected = this.IsProtected;
            document.IsZipped = this.IsZipped;
            document.Extension = this.Extension;
            return document;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._CorrelateObjectID = 0L;
            this._DocumentType = new BasicInfoDetail();
            this._CorrelateOffer = new Offer();
            this._FileVersions = new WordDocuments();
            this._Owner = new WFPerson();
            this._CorrelateFolder = new PersonalFolder();
            this._IsLocked = SbnBoolean.OutOfValue;
            this._IsHidden = SbnBoolean.OutOfValue;
            this._IsProtected = SbnBoolean.OutOfValue;
            this._IsZipped = SbnBoolean.OutOfValue;
        }

        public override string ToString()
        {
            if (this.Title != null)
            {
                return this.Title;
            }
            return "";
        }

        public static string at_CorrelateFolder_ChildsFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateFolder.ChildsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateFolder_DocumentsFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateFolder.DocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateFolder_OwnerFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateFolder.OwnerFirstLevelAttributes";
            }
        }

        public static string at_CorrelateFolder_ParentFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateFolder.ParentFirstLevelAttributes";
            }
        }

        public static string at_CorrelateFolderFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateFolderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateFolderID
        {
            get
            {
                return "GeneralDocument.CorrelateFolderID";
            }
        }

        public static string at_CorrelateObjectID
        {
            get
            {
                return "GeneralDocument.CorrelateObjectID";
            }
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "GeneralDocument.CorrelateOfferID";
            }
        }

        public static string at_DocumentType_ParentFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.DocumentType.ParentFirstLevelAttributes";
            }
        }

        public static string at_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.DocumentTypeFirstLevelAttributes";
            }
        }

        public static string at_DocumentTypeID
        {
            get
            {
                return "GeneralDocument.DocumentTypeID";
            }
        }

        public static string at_FileVersionsFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.FileVersionsFirstLevelAttributes";
            }
        }

        public static string at_FileVersionsID
        {
            get
            {
                return "GeneralDocument.FileVersionsID";
            }
        }

        public static string at_IsHidden
        {
            get
            {
                return "GeneralDocument.IsHidden";
            }
        }

        public static string at_IsLocked
        {
            get
            {
                return "GeneralDocument.IsLocked";
            }
        }

        public static string at_IsProtected
        {
            get
            {
                return "GeneralDocument.IsProtected";
            }
        }

        public static string at_IsZipped
        {
            get
            {
                return "GeneralDocument.IsZipped";
            }
        }

        public static string at_Extension
        {
            get
            {
                return "GeneralDocument.Extension";
            }
        }

        public static string at_Owner_SexFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.Owner.SexFirstLevelAttributes";
            }
        }

        public static string at_Owner_WorkersFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.Owner.WorkersFirstLevelAttributes";
            }
        }

        public static string at_OwnerFirstLevelAttributes
        {
            get
            {
                return "GeneralDocument.OwnerFirstLevelAttributes";
            }
        }

        public static string at_OwnerID
        {
            get
            {
                return "GeneralDocument.OwnerID";
            }
        }

        [DocumentAttributeID("9358"), Description("پوشه"), IsRelational("False"), DisplayName("پوشه"), AttributeType("PersonalFolder"), IsMiddleTableExist("False"), RelationTable(""), Browsable(true), Category("")]
        public PersonalFolder CorrelateFolder
        {
            get
            {
                return this._CorrelateFolder;
            }
            set
            {
                this._CorrelateFolder = value;
            }
        }

        [DisplayName("کد سند مرتبط"), Browsable(true), Category(""), DocumentAttributeID("9240"), IsRelational("false"), Description("کد سند مرتبط"), AttributeType("Long")]
        public long CorrelateObjectID
        {
            get
            {
                return this._CorrelateObjectID;
            }
            set
            {
                this._CorrelateObjectID = value;
            }
        }

        [Category(""), DisplayName("پیشنهاد مرتبط"), IsMiddleTableExist("False"), DocumentAttributeID("9307"), Browsable(true), IsRelational("False"), Description("پیشنهاد مرتبط"), RelationTable(""), AttributeType("Offer")]
        public Offer CorrelateOffer
        {
            get
            {
                return this._CorrelateOffer;
            }
            set
            {
                this._CorrelateOffer = value;
            }
        }

        [RelationTable(""), Description("نوع سند مرتبط"), DisplayName("نوع سند مرتبط"), Category(""), DocumentAttributeID("9306"), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False")]
        public BasicInfoDetail DocumentType
        {
            get
            {
                return this._DocumentType;
            }
            set
            {
                this._DocumentType = value;
            }
        }

        [RelationTable(""), Category(""), DocumentAttributeID("9313"), Description("سابقه تغییرات"), DisplayName("سابقه تغییرات"), Browsable(true), IsRelational("True"), AttributeType("WordDocuments"), IsMiddleTableExist("True")]
        public WordDocuments FileVersions
        {
            get
            {
                return this._FileVersions;
            }
            set
            {
                this._FileVersions = value;
            }
        }

        [DocumentAttributeID("9399"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("غیر قابل مشاهده"), Category(""), Browsable(true), IsRelational("False"), AttributeType("SbnBoolean"), Description("غیر قابل مشاهده")]
        public SbnBoolean IsHidden
        {
            get
            {
                return this._IsHidden;
            }
            set
            {
                this._IsHidden = value;
            }
        }

        [AttributeType("SbnBoolean"), DisplayName("وضعیت ویرایش"), Category(""), DocumentAttributeID("9404"), IsMiddleTableExist("False"), RelationTable(""), Browsable(true), IsRelational("False"), Description("وضعیت ویرایش سند")]
        public SbnBoolean IsLocked
        {
            get
            {
                return this._IsLocked;
            }
            set
            {
                this._IsLocked = value;
            }
        }

        [AttributeType("SbnBoolean"), 
        DisplayName("وضعیت نهایی شدن"), 
        Category(""), 
        DocumentAttributeID(""), 
        IsMiddleTableExist("False"), 
        RelationTable(""), 
        Browsable(true), 
        IsRelational("False"),
        Description("وضعیت نهایی شدن سند")]
        public SbnBoolean IsProtected
        {
            get
            {
                return this._IsProtected;
            }
            set
            {
                this._IsProtected = value;
            }
        }

        [AttributeType("SbnBoolean"), 
        DisplayName("وضعیت فشرده سازی"), 
        Category(""), 
        DocumentAttributeID(""), 
        IsMiddleTableExist("False"),
        RelationTable(""),
        Browsable(true),
        IsRelational("False"),
        Description("وضعیت فشرده سازی سند")]
        public SbnBoolean IsZipped
        {
            get
            {
                return this._IsZipped;
            }
            set
            {
                this._IsZipped = value;
            }
        }

        [AttributeType("string"),
        DisplayName("پسوند فایل"), 
        Category(""),
        DocumentAttributeID(""),
        IsMiddleTableExist("False"),
        RelationTable(""),
        Browsable(true),
        IsRelational("False"),
        Description("پسوند فایل سند")]
        public string Extension
        {
            get
            {
                return this._Extension;
            }
            set
            {
                this._Extension = value;
            }
        }

        [IsRelational("False"), RelationTable(""), Browsable(true), IsMiddleTableExist("False"), AttributeType("WFPerson"), Description("مالک سند"), DisplayName("مالک سند"), Category(""), DocumentAttributeID("9340")]
        public WFPerson Owner
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


    }
}
