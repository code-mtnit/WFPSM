namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("پاسخ استعلام"), DisplayName("پاسخ استعلام"), ObjectCode("9237"), ItemsType("Sbn.Products.GEP.GEPObject.InquiryResponses")]
    public class InquiryResponse : SbnObject
    {
        private string _Abstract;
        private Inquiry _CorrelateInquiry;
        private Letter _CorrelateLetter;
        private Offer _CorrelateOffer;
        private OrgUnit _CorrelateOrgan;
        private BasicInfoDetail _OrganIdea;
        private BasicInfoDetail _ResponseQuality;
        private BasicInfoDetail _ResponseStatus;
        private SbnBoolean _IsInquiryCallRequired = SbnBoolean.OutOfValue;


        public InquiryResponse()
        {
        }

        public InquiryResponse(SbnObject InitialObject)
            : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            InquiryResponse response = new InquiryResponse
            {
                ID = base.ID
            };
            if (this._Abstract != null)
            {
                response.Abstract = (string)this._Abstract.Clone();
            }
            if (!object.ReferenceEquals(this.CorrelateLetter, null))
            {
                response.CorrelateLetter = (Letter)this.CorrelateLetter.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                response.CorrelateOffer = (Offer)this.CorrelateOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateInquiry, null))
            {
                response.CorrelateInquiry = (Inquiry)this.CorrelateInquiry.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOrgan, null))
            {
                response.CorrelateOrgan = (OrgUnit)this.CorrelateOrgan.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.ResponseQuality, null))
            {
                response.ResponseQuality = (BasicInfoDetail)this.ResponseQuality.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OrganIdea, null))
            {
                response.OrganIdea = (BasicInfoDetail)this.OrganIdea.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.ResponseStatus, null))
            {
                response.ResponseStatus = (BasicInfoDetail)this.ResponseStatus.Clone(sNodeName);
            }
            response.IsInquiryCallRequired = this.IsInquiryCallRequired;

            return response;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._Abstract = "";
            this._CorrelateLetter = new Letter();
            this._CorrelateOffer = new Offer();
            this._CorrelateInquiry = new Inquiry();
            this._CorrelateOrgan = new OrgUnit();
            this._ResponseQuality = new BasicInfoDetail();
            this._OrganIdea = new BasicInfoDetail();
            this._ResponseStatus = new BasicInfoDetail();
            this._IsInquiryCallRequired = SbnBoolean.OutOfValue;
        }

        public override string ToString()
        {
            try
            {
                if ((((this.CorrelateLetter != null) && (this.CorrelateLetter.ID > 0L)) && (this.CorrelateOrgan != null)) && (this.CorrelateOrgan.ID > 0L))
                {
                    return (this.CorrelateLetter.ToString() + " " + this.CorrelateOrgan.ToString());
                }
                if ((this.CorrelateLetter != null) && ((this.CorrelateOrgan == null) || (this.CorrelateOrgan.ID < 0L)))
                {
                    return this.CorrelateLetter.ToString();
                }
                if (((this.CorrelateLetter == null) || (this.CorrelateLetter.ID < 0L)) && ((this.CorrelateOrgan != null) && (this.CorrelateOrgan.ID > 0L)))
                {
                    return ("فاقد نامه " + this.CorrelateOrgan.ToString());
                }
                return "فاقد نامه";
            }
            catch
            {
                return "خطا در نامه مرتبط";
            }
        }

        [DocumentAttributeID("27140"), Category(""), Browsable(true), DisplayName("خلاصه پاسخ"), Description("خلاصه پاسخ"), IsRelational("false"), AttributeType("LongText")]
        public string Abstract
        {
            get
            {
                return this._Abstract;
            }
            set
            {
                this._Abstract = value;
            }
        }

        public static string at_Abstract
        {
            get
            {
                return "InquiryResponse.Abstract";
            }
        }

        public static string at_CorrelateInquiry_CorrelateExpertFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateInquiry.CorrelateExpertFirstLevelAttributes";
            }
        }

        public static string at_CorrelateInquiry_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateInquiry.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateInquiry_CorrelateOfferCommissionFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateInquiry.CorrelateOfferCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateInquiry_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateInquiry.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateInquiry_PursuitsFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateInquiry.PursuitsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateInquiry_ResponsesFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateInquiry.ResponsesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateInquiry_WordDocFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateInquiry.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CorrelateInquiryFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateInquiryFirstLevelAttributes";
            }
        }

        public static string at_CorrelateInquiryID
        {
            get
            {
                return "InquiryResponse.CorrelateInquiryID";
            }
        }

        public static string at_CorrelateLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterID
        {
            get
            {
                return "InquiryResponse.CorrelateLetterID";
            }
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "InquiryResponse.CorrelateOfferID";
            }
        }

        public static string at_CorrelateOrgan_BuildingLocationFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOrgan.BuildingLocationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgan_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOrgan.ChildUnitsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgan_MergedUnitFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOrgan.MergedUnitFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgan_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOrgan.ParentUnitFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgan_PositionsFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOrgan.PositionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrganFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.CorrelateOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrganID
        {
            get
            {
                return "InquiryResponse.CorrelateOrganID";
            }
        }

        public static string at_OrganIdea_ParentFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.OrganIdea.ParentFirstLevelAttributes";
            }
        }

        public static string at_OrganIdeaFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.OrganIdeaFirstLevelAttributes";
            }
        }

        public static string at_OrganIdeaID
        {
            get
            {
                return "InquiryResponse.OrganIdeaID";
            }
        }

        public static string at_ResponseQuality_ParentFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.ResponseQuality.ParentFirstLevelAttributes";
            }
        }

        public static string at_ResponseQualityFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.ResponseQualityFirstLevelAttributes";
            }
        }

        public static string at_ResponseQualityID
        {
            get
            {
                return "InquiryResponse.ResponseQualityID";
            }
        }

        public static string at_ResponseStatus_ParentFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.ResponseStatus.ParentFirstLevelAttributes";
            }
        }

        public static string at_ResponseStatusFirstLevelAttributes
        {
            get
            {
                return "InquiryResponse.ResponseStatusFirstLevelAttributes";
            }
        }

        public static string at_ResponseStatusID
        {
            get
            {
                return "InquiryResponse.ResponseStatusID";
            }
        }

        public static string at_IsInquiryCallRequired
        {
            get
            {
                return "InquiryResponse.IsInquiryCallRequired";
            }
        }

        [IsRelational("False"), DocumentAttributeID("9266"), RelationTable(""), DisplayName("استعلام مرتبط"), Category(""), Browsable(true), Description("استعلام مرتبط"), AttributeType("Inquiry"), IsMiddleTableExist("False")]
        public Inquiry CorrelateInquiry
        {
            get
            {
                return this._CorrelateInquiry;
            }
            set
            {
                this._CorrelateInquiry = value;
            }
        }

        [Browsable(true), DocumentAttributeID("9264"), AttributeType("Letter"), IsMiddleTableExist("False"), RelationTable(""), IsRelational("False"), Description("نامه مرتبط"), DisplayName("نامه مرتبط"), Category("")]
        public Letter CorrelateLetter
        {
            get
            {
                return this._CorrelateLetter;
            }
            set
            {
                this._CorrelateLetter = value;
            }
        }

        [IsRelational("False"), AttributeType("Offer"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("پیشنهاد مرتبط"), Category(""), DocumentAttributeID("9265"), Browsable(true), Description("پیشنهاد مرتبط با استعلام")]
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

        [Browsable(true), IsMiddleTableExist("False"), RelationTable(""), IsRelational("False"), AttributeType("OrgUnit"), DocumentAttributeID("9269"), Description("دستگاه پاسخ دهنده"), DisplayName("دستگاه مرتبط"), Category("")]
        public OrgUnit CorrelateOrgan
        {
            get
            {
                return this._CorrelateOrgan;
            }
            set
            {
                this._CorrelateOrgan = value;
            }
        }

        [IsRelational("False"), DocumentAttributeID("9272"), RelationTable(""), Category(""), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), Browsable(true), Description("نوع نظر دستگاه از نوع اطلاعات پایه ای"), DisplayName("نوع نظر")]
        public BasicInfoDetail OrganIdea
        {
            get
            {
                return this._OrganIdea;
            }
            set
            {
                this._OrganIdea = value;
            }
        }

        [Browsable(true), DocumentAttributeID("9271"), RelationTable(""), DisplayName("کیفیت پاسخ"), Category(""), Description("کیفیت پاسخ به استعلام از نوع اطلاعات پایه ای"), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False")]
        public BasicInfoDetail ResponseQuality
        {
            get
            {
                return this._ResponseQuality;
            }
            set
            {
                this._ResponseQuality = value;
            }
        }

        [AttributeType("BasicInfoDetail"), Description("وضعیت پاسخ به استعلام"), DisplayName("وضعیت پاسخ"), Browsable(true), Category(""), DocumentAttributeID("9273"), RelationTable(""), IsMiddleTableExist("False"), IsRelational("False")]
        public BasicInfoDetail ResponseStatus
        {
            get
            {
                return this._ResponseStatus;
            }
            set
            {
                this._ResponseStatus = value;
            }
        }

        /// <summary>
        /// الزام سازمان برای پاسخ به استعلام
        /// </summary>
        [Description("الزام سازمان برای پاسخ به استعلام")]
        [DisplayName("الزام پاسخ")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsInquiryCallRequired
        {
            get { return _IsInquiryCallRequired; }
            set { _IsInquiryCallRequired = value; }
        }
    }
}
