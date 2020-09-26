namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, Description("استعلام"), SystemName("GEP"), DisplayName("استعلام"), ItemsType("Sbn.Products.GEP.GEPObject.Inquiries"), ObjectCode("9085")]
    public class Inquiry : SbnObject
    {
        private CommissionExpert _CorrelateExpert;
        private Letter _CorrelateLetter;
        private Offer _CorrelateOffer;
        private OfferCommission _CorrelateOfferCommission;
        private string _OpportunityDate;
        private InquiryPursuits _Pursuits;
        private string _ResponseAbstract;
        private InquiryResponses _Responses;
        private string _Text;
        private GeneralDocument _WordDoc;

        private BasicInfoDetail _Sensitivity;

        public Inquiry()
        {
        }

        public Inquiry(SbnObject InitialObject)
            : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            Inquiry inquiry = new Inquiry
            {
                ID = base.ID,
                Title = base.Title
            };
            if (this._OpportunityDate != null)
            {
                inquiry.OpportunityDate = (string)this._OpportunityDate.Clone();
            }
            if (this._Text != null)
            {
                inquiry.Text = (string)this._Text.Clone();
            }
            if (this._ResponseAbstract != null)
            {
                inquiry.ResponseAbstract = (string)this._ResponseAbstract.Clone();
            }
            if (!object.ReferenceEquals(this.Responses, null))
            {
                inquiry.Responses = (InquiryResponses)this.Responses.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                inquiry.CorrelateOffer = (Offer)this.CorrelateOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateLetter, null))
            {
                inquiry.CorrelateLetter = (Letter)this.CorrelateLetter.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateExpert, null))
            {
                inquiry.CorrelateExpert = (CommissionExpert)this.CorrelateExpert.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOfferCommission, null))
            {
                inquiry.CorrelateOfferCommission = (OfferCommission)this.CorrelateOfferCommission.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.WordDoc, null))
            {
                inquiry.WordDoc = (GeneralDocument)this.WordDoc.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Pursuits, null))
            {
                inquiry.Pursuits = (InquiryPursuits)this.Pursuits.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Sensitivity, null))
            {
                inquiry.Sensitivity = (BasicInfoDetail)this.Sensitivity.Clone(sNodeName);
            }
            return inquiry;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._OpportunityDate = "";
            this._Text = "";
            this._ResponseAbstract = "";
            this._Responses = new InquiryResponses();
            this._CorrelateOffer = new Offer();
            this._CorrelateLetter = new Letter();
            this._CorrelateExpert = new CommissionExpert();
            this._CorrelateOfferCommission = new OfferCommission();
            this._WordDoc = new GeneralDocument();
            this._Pursuits = new InquiryPursuits();
            this.Sensitivity = new BasicInfoDetail();
        }

        public override string ToString()
        {
            try
            {
                if ((this.CorrelateLetter != null) && (this.CorrelateLetter.ID > 0L))
                {
                    return this.CorrelateLetter.ToString();
                }
                return "فاقد نامه";
            }
            catch
            {
                return "خطا در نامه مرتبط";
            }
        }

        public static string at_CorrelateExpert_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateExpert.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateExpert_CorrelatePersonFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateExpert.CorrelatePersonFirstLevelAttributes";
            }
        }

        public static string at_CorrelateExpertFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateExpertFirstLevelAttributes";
            }
        }

        public static string at_CorrelateExpertID
        {
            get
            {
                return "Inquiry.CorrelateExpertID";
            }
        }

        public static string at_CorrelateLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterID
        {
            get
            {
                return "Inquiry.CorrelateLetterID";
            }
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_AdminExpertFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOfferCommission.AdminExpertFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOfferCommission.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_CommissionResultsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOfferCommission.CommissionResultsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOfferCommission.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOfferCommission.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_GovReportsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOfferCommission.GovReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_OfferEngineeringsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOfferCommission.OfferEngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_SessionsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOfferCommission.SessionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_StatusFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOfferCommission.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommissionFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOfferCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommissionID
        {
            get
            {
                return "Inquiry.CorrelateOfferCommissionID";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Inquiry.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "Inquiry.CorrelateOfferID";
            }
        }

        public static string at_OpportunityDate
        {
            get
            {
                return "Inquiry.OpportunityDate";
            }
        }

        public static string at_PursuitsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.PursuitsFirstLevelAttributes";
            }
        }

        public static string at_PursuitsID
        {
            get
            {
                return "Inquiry.PursuitsID";
            }
        }

        public static string at_ResponseAbstract
        {
            get
            {
                return "Inquiry.ResponseAbstract";
            }
        }

        public static string at_ResponsesFirstLevelAttributes
        {
            get
            {
                return "Inquiry.ResponsesFirstLevelAttributes";
            }
        }

        public static string at_ResponsesID
        {
            get
            {
                return "Inquiry.ResponsesID";
            }
        }

        public static string at_Text
        {
            get
            {
                return "Inquiry.Text";
            }
        }

        public static string at_SensitivityID
        {
            get
            {
                return "Inquiry.SensitivityID";
            }
        }
        public static string at_SensitivityFirstLevelAttributes
        {
            get
            {
                return "Inquiry.SensitivityFirstLevelAttributes";
            }
        }


        public static string at_WordDoc_CorrelateFolderFirstLevelAttributes
        {
            get
            {
                return "Inquiry.WordDoc.CorrelateFolderFirstLevelAttributes";
            }
        }

        public static string at_WordDoc_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Inquiry.WordDoc.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_WordDoc_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "Inquiry.WordDoc.DocumentTypeFirstLevelAttributes";
            }
        }

        public static string at_WordDoc_FileVersionsFirstLevelAttributes
        {
            get
            {
                return "Inquiry.WordDoc.FileVersionsFirstLevelAttributes";
            }
        }

        public static string at_WordDoc_OwnerFirstLevelAttributes
        {
            get
            {
                return "Inquiry.WordDoc.OwnerFirstLevelAttributes";
            }
        }

        public static string at_WordDocFirstLevelAttributes
        {
            get
            {
                return "Inquiry.WordDocFirstLevelAttributes";
            }
        }

        public static string at_WordDocID
        {
            get
            {
                return "Inquiry.WordDocID";
            }
        }

        [Description("کارشناس کمیسیون که پیشنهاد به وی جهت انجام امور کارشناسی ارجاع شده است"), RelationTable(""), DisplayName("کارشناس مرتبط"), Category(""), DocumentAttributeID("9062"), Browsable(true), IsRelational("False"), AttributeType("CommissionExpert"), IsMiddleTableExist("False")]
        public CommissionExpert CorrelateExpert
        {
            get
            {
                return this._CorrelateExpert;
            }
            set
            {
                this._CorrelateExpert = value;
            }
        }

        [RelationTable(""), Description("نامه استعلام مرتبط"), DisplayName("نامه استعلام"), Category(""), DocumentAttributeID("9059"), Browsable(true), IsRelational("False"), AttributeType("Letter"), IsMiddleTableExist("False")]
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

        [Description("پیشنهاد مرتبط"), RelationTable(""), DisplayName("پیشنهاد مرتبط"), Category(""), DocumentAttributeID("9060"), Browsable(true), IsRelational("False"), AttributeType("Offer"), IsMiddleTableExist("False")]
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

        [Description("کمیسیونی که پیشنهاد برای انجام امور کارشناسی به آنجا ارجاع شده است"), IsRelational("False"), RelationTable(""), DisplayName("کمیسیون مرتبط"), Category(""), DocumentAttributeID("9067"), Browsable(true), AttributeType("OfferCommission"), IsMiddleTableExist("False")]
        public OfferCommission CorrelateOfferCommission
        {
            get
            {
                return this._CorrelateOfferCommission;
            }
            set
            {
                this._CorrelateOfferCommission = value;
            }
        }

        [Browsable(true), Description("مهلت ارسال پاسخ استعلام"), DisplayName("مهلت ارسال پاسخ"), Category(""), DocumentAttributeID("9211"), IsRelational("false"), AttributeType("DateString")]
        public string OpportunityDate
        {
            get
            {
                return this._OpportunityDate;
            }
            set
            {
                this._OpportunityDate = value;
            }
        }

        [IsMiddleTableExist("True"), Browsable(true), IsRelational("True"), AttributeType("InquiryPursuits"), Description("پیگیریها"), RelationTable(""), DisplayName("پیگیریها"), Category(""), DocumentAttributeID("9330")]
        public InquiryPursuits Pursuits
        {
            get
            {
                return this._Pursuits;
            }
            set
            {
                this._Pursuits = value;
            }
        }

        [Description("خلاصه نظرات واصله"), IsRelational("false"), Browsable(true), DisplayName("خلاصه نظرات"), Category(""), DocumentAttributeID("9230"), AttributeType("LongText")]
        public string ResponseAbstract
        {
            get
            {
                return this._ResponseAbstract;
            }
            set
            {
                this._ResponseAbstract = value;
            }
        }

        [IsMiddleTableExist("True"), AttributeType("InquiryResponses"), IsRelational("True"), RelationTable(""), Description("فهرستی از پاسخهای استعلام از نوع پاسخ استعلام"), DisplayName("پاسخها"), Category(""), DocumentAttributeID("9267"), Browsable(true)]
        public InquiryResponses Responses
        {
            get
            {
                return this._Responses;
            }
            set
            {
                this._Responses = value;
            }
        }

        [Description("متن استعلام"), Browsable(true), DisplayName("متن استعلام"), Category(""), DocumentAttributeID("9224"), IsRelational("false"), AttributeType("LongText")]
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this._Text = value;
            }
        }

        [AttributeType("GeneralDocument"), IsMiddleTableExist("False"), RelationTable(""), IsRelational("False"), Description("مستند تایپی"), DisplayName("فایل word"), Category(""), DocumentAttributeID("9397"), Browsable(true)]
        public GeneralDocument WordDoc
        {
            get
            {
                return this._WordDoc;
            }
            set
            {
                this._WordDoc = value;
            }
        }

        [AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable(""), IsRelational("False"), Description("طبقه بندی استعلام"), DisplayName("طبقه بندی"), Category(""), DocumentAttributeID(""), Browsable(true)]
        public BasicInfoDetail Sensitivity
        {
            get
            {
                return this._Sensitivity;
            }
            set
            {
                _Sensitivity = value;
            }
        }
    }
}
