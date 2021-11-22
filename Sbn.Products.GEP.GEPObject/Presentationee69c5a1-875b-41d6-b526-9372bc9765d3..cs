namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("ارائه گزارش حين جلسه دولت"), DisplayName("ارائه گزارش حين جلسه دولت"), ObjectCode("9252"), ItemsType("Sbn.Products.GEP.GEPObject.Presentations")]
    public class Presentation : SbnObject
    {
        private PresentationAttachs _Attachments;
        private Letter _CoLetter;
        private GovSession _CorrelateSession;
        private GovSessions _CoSessions;
        private string _Description;
        private LetterAttachments _DocAttachments;
        private int _OrderInSession;
        private OrgUnit _OwnerOrgan;
        private BasicInfoDetail _PresentType;
        private BasicInfoDetail _SensitivityType;
        private string _Title;

        private string _TitleBackColor;
        private string _TitleForeColor;
        private Single _TitleFontSize;
        public Single TitleFontSize
        {
            get
            {
                return _TitleFontSize;
            }

            set
            {
                _TitleFontSize = value;
            }
        }
        public string TitleBackColor
        {
            get
            {
                return _TitleBackColor;
            }

            set
            {
                _TitleBackColor = value;
            }
        }


        public string TitleForeColor
        {
            get
            {
                return _TitleForeColor;
            }

            set
            {
                _TitleForeColor = value;
            }
        }
        public Presentation()
        {
        }

        public Presentation(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            Presentation presentation = new Presentation(this) {
                Title = this._Title,
                Description = this._Description,
                OrderInSession = this._OrderInSession
            };
            if (!object.ReferenceEquals(this.CorrelateSession, null))
            {
                presentation.CorrelateSession = (GovSession) this.CorrelateSession.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Attachments, null))
            {
                presentation.Attachments = (PresentationAttachs) this.Attachments.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OwnerOrgan, null))
            {
                presentation.OwnerOrgan = (OrgUnit) this.OwnerOrgan.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoLetter, null))
            {
                presentation.CoLetter = (Letter) this.CoLetter.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.SensitivityType, null))
            {
                presentation.SensitivityType = (BasicInfoDetail) this.SensitivityType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.PresentType, null))
            {
                presentation.PresentType = (BasicInfoDetail) this.PresentType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.DocAttachments, null))
            {
                presentation.DocAttachments = (LetterAttachments) this.DocAttachments.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoSessions, null))
            {
                presentation.CoSessions = (GovSessions) this.CoSessions.Clone(sNodeName);
            }
            return presentation;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._Title = "";
            this._Description = "";
            this._OrderInSession = 0;
            this._CorrelateSession = new GovSession();
            this._Attachments = new PresentationAttachs();
            this._OwnerOrgan = new OrgUnit();
            this._CoLetter = new Letter();
            this._SensitivityType = new BasicInfoDetail();
            this._PresentType = new BasicInfoDetail();
            this._DocAttachments = new LetterAttachments();
            this._CoSessions = new GovSessions();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "Presentation.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_AttachmentsID
        {
            get
            {
                return "Presentation.AttachmentsID";
            }
        }

        public static string at_CoLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_LetterTypeFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.LetterTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_SensitivityFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.SensitivityFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CoLetterFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoLetterFirstLevelAttributes";
            }
        }

        public static string at_CoLetterID
        {
            get
            {
                return "Presentation.CoLetterID";
            }
        }

        public static string at_CorrelateSession_CataloguesFirstLevelAttributes
        {
            get
            {
                return "Presentation.CorrelateSession.CataloguesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CoLettersFirstLevelAttributes
        {
            get
            {
                return "Presentation.CorrelateSession.CoLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "Presentation.CorrelateSession.CorrelateOffersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_MembersFirstLevelAttributes
        {
            get
            {
                return "Presentation.CorrelateSession.MembersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_OrganAnnouncementFirstLevelAttributes
        {
            get
            {
                return "Presentation.CorrelateSession.OrganAnnouncementFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_PreOrdersFirstLevelAttributes
        {
            get
            {
                return "Presentation.CorrelateSession.PreOrdersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_PresentationsFirstLevelAttributes
        {
            get
            {
                return "Presentation.CorrelateSession.PresentationsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "Presentation.CorrelateSession.SessionOrderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "Presentation.CorrelateSessionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionID
        {
            get
            {
                return "Presentation.CorrelateSessionID";
            }
        }

        public static string at_CoSessionsFirstLevelAttributes
        {
            get
            {
                return "Presentation.CoSessionsFirstLevelAttributes";
            }
        }

        public static string at_CoSessionsID
        {
            get
            {
                return "Presentation.CoSessionsID";
            }
        }

        public static string at_Description
        {
            get
            {
                return "Presentation.Description";
            }
        }

        public static string at_DocAttachmentsFirstLevelAttributes
        {
            get
            {
                return "Presentation.DocAttachmentsFirstLevelAttributes";
            }
        }

        public static string at_DocAttachmentsID
        {
            get
            {
                return "Presentation.DocAttachmentsID";
            }
        }

        public static string at_OrderInSession
        {
            get
            {
                return "Presentation.OrderInSession";
            }
        }

        public static string at_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "Presentation.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_OwnerOrganID
        {
            get
            {
                return "Presentation.OwnerOrganID";
            }
        }

        public static string at_PresentTypeFirstLevelAttributes
        {
            get
            {
                return "Presentation.PresentTypeFirstLevelAttributes";
            }
        }

        public static string at_PresentTypeID
        {
            get
            {
                return "Presentation.PresentTypeID";
            }
        }

        public static string at_SensitivityTypeFirstLevelAttributes
        {
            get
            {
                return "Presentation.SensitivityTypeFirstLevelAttributes";
            }
        }

        public static string at_SensitivityTypeID
        {
            get
            {
                return "Presentation.SensitivityTypeID";
            }
        }

        public static string at_Title
        {
            get
            {
                return "Presentation.Title";
            }
        }

        [DocumentAttributeID("9365"), IsMiddleTableExist("False"), RelationTable("PRESENTATION_ATTACHMENTS_M"), AttributeType("PresentationAttachs"), Description("ضمائم"), DisplayName("ضمائم"), Category(""), Browsable(true), IsRelational("False")]
        public PresentationAttachs Attachments
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

        [RelationTable(""), IsRelational("False"), DocumentAttributeID("27333"), Browsable(true), IsMiddleTableExist("False"), AttributeType("Letter"), Description("نامه مرتبط"), DisplayName("نامه مرتبط"), Category("")]
        public Letter CoLetter
        {
            get
            {
                return this._CoLetter;
            }
            set
            {
                this._CoLetter = value;
            }
        }

        [IsRelational("False"), RelationTable(""), Description("جلسه مرتبط"), DisplayName("جلسه مرتبط"), Category(""), DocumentAttributeID("9317"), Browsable(true), AttributeType("GovSession"), IsMiddleTableExist("False")]
        public GovSession CorrelateSession
        {
            get
            {
                return this._CorrelateSession;
            }
            set
            {
                this._CorrelateSession = value;
            }
        }

        [IsRelational("False"), DisplayName("جلسات مرتبط"), DocumentAttributeID("27340"), Browsable(true), AttributeType("GovSessions"), IsMiddleTableExist("False"), RelationTable("GovSession_Presentation_M"), Category(""), Description("جلسات مرتبط")]
        public GovSessions CoSessions
        {
            get
            {
                return this._CoSessions;
            }
            set
            {
                this._CoSessions = value;
            }
        }

        [DocumentAttributeID("9244"), Browsable(true), Description("توضیحات"), DisplayName("توضیحات"), Category(""), IsRelational("false"), AttributeType("String")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        [IsMiddleTableExist("False"), Description("ضمائم"), IsRelational("False"), AttributeType("LetterAttachments"), DisplayName("ضمائم"), RelationTable("PRESENTDOC_ATTACHMENTS_M"), Browsable(true), Category(""), DocumentAttributeID("27339")]
        public LetterAttachments DocAttachments
        {
            get
            {
                return this._DocAttachments;
            }
            set
            {
                this._DocAttachments = value;
            }
        }

        [Browsable(true), Description("ردیف"), DisplayName("ردیف"), Category(""), DocumentAttributeID("9261"), IsRelational("false"), AttributeType("Int")]
        public int OrderInSession
        {
            get
            {
                return this._OrderInSession;
            }
            set
            {
                this._OrderInSession = value;
            }
        }

        [RelationTable(""), Description("دستگاه مرتبط"), DisplayName("دستگاه مرتبط"), Category(""), DocumentAttributeID("27066"), Browsable(true), IsRelational("False"), AttributeType("OrgUnit"), IsMiddleTableExist("False")]
        public OrgUnit OwnerOrgan
        {
            get
            {
                return this._OwnerOrgan;
            }
            set
            {
                this._OwnerOrgan = value;
            }
        }

        [RelationTable(""), Description("نوع"), DisplayName("نوع"), Category(""), DocumentAttributeID("27335"), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False")]
        public BasicInfoDetail PresentType
        {
            get
            {
                return this._PresentType;
            }
            set
            {
                this._PresentType = value;
            }
        }

        [RelationTable(""), IsMiddleTableExist("False"), DisplayName("حساسیت"), Category(""), DocumentAttributeID("27334"), Browsable(true), IsRelational("False"), Description("حساسیت"), AttributeType("BasicInfoDetail")]
        public BasicInfoDetail SensitivityType
        {
            get
            {
                return this._SensitivityType;
            }
            set
            {
                this._SensitivityType = value;
            }
        }

        [Browsable(true), Description("عنوان"), DisplayName("عنوان"), Category(""), DocumentAttributeID("9243"), IsRelational("false"), AttributeType("String")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }
    }
}
