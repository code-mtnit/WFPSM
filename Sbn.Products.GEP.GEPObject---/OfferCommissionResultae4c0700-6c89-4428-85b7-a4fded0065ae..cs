namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, ObjectCode("9111"), ItemsType("Sbn.Products.GEP.GEPObject.OfferCommissionResults"), SystemName("GEP"), DisplayName("نظر نهایی کمیسیون"), Description("نظر نهایی کمیسیون")]
    public class OfferCommissionResult : SbnObject
    {
        private BasicInfoDetail _AgainstResultType;
        private BasicInfoDetail _ApprovalType;
        private string _CommuniqueText;
        private Letter _CorrelateLetter;
        private Offer _CorrelateOffer;
        private CommissionSession _CorrelateSession;
        private string _Duration;
        private Sbn.Products.GEP.GEPObject.OfferCommission _OfferCommission;
        private string _PlanningProcess;
        private string _Reasons;
        private string _ResultText;

        public OfferCommissionResult()
        {
        }

        public OfferCommissionResult(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            OfferCommissionResult result = new OfferCommissionResult {
                ID = base.ID,
                ResultText = this._ResultText,
                Reasons = this._Reasons,
                PlanningProcess = this._PlanningProcess
            };
            if (this._CommuniqueText != null)
            {
                result.CommuniqueText = (string) this._CommuniqueText.Clone();
            }
            result.Duration = this._Duration;
            if (!object.ReferenceEquals(this.CorrelateLetter, null))
            {
                result.CorrelateLetter = (Letter) this.CorrelateLetter.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.ApprovalType, null))
            {
                result.ApprovalType = (BasicInfoDetail) this.ApprovalType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                result.CorrelateOffer = (Offer) this.CorrelateOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateSession, null))
            {
                result.CorrelateSession = (CommissionSession) this.CorrelateSession.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.AgainstResultType, null))
            {
                result.AgainstResultType = (BasicInfoDetail) this.AgainstResultType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OfferCommission, null))
            {
                result.OfferCommission = (Sbn.Products.GEP.GEPObject.OfferCommission) this.OfferCommission.Clone(sNodeName);
            }
            return result;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._ResultText = "";
            this._Reasons = "";
            this._PlanningProcess = "";
            this._CommuniqueText = "";
            this._Duration = "";
            this._CorrelateLetter = new Letter();
            this._ApprovalType = new BasicInfoDetail();
            this._CorrelateOffer = new Offer();
            this._CorrelateSession = new CommissionSession();
            this._AgainstResultType = new BasicInfoDetail();
            this._OfferCommission = new Sbn.Products.GEP.GEPObject.OfferCommission();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        [DisplayName("نظر کمیسیون در مقابل کمیسیون فرعی"), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable(""), Description("نظر کمیسیون در مقابل کمیسیون فرعی"), Category(""), DocumentAttributeID("9296"), Browsable(true)]
        public BasicInfoDetail AgainstResultType
        {
            get
            {
                return this._AgainstResultType;
            }
            set
            {
                this._AgainstResultType = value;
            }
        }

        [DisplayName("نوع نظر"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable(""), Description("نوع نظر نهایی"), Category(""), DocumentAttributeID("9103"), Browsable(true), IsRelational("False")]
        public BasicInfoDetail ApprovalType
        {
            get
            {
                return this._ApprovalType;
            }
            set
            {
                this._ApprovalType = value;
            }
        }

        public static string at_AgainstResultType_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.AgainstResultType.ParentFirstLevelAttributes";
            }
        }

        public static string at_AgainstResultTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.AgainstResultTypeFirstLevelAttributes";
            }
        }

        public static string at_AgainstResultTypeID
        {
            get
            {
                return "OfferCommissionResult.AgainstResultTypeID";
            }
        }

        public static string at_ApprovalType_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.ApprovalType.ParentFirstLevelAttributes";
            }
        }

        public static string at_ApprovalTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.ApprovalTypeFirstLevelAttributes";
            }
        }

        public static string at_ApprovalTypeID
        {
            get
            {
                return "OfferCommissionResult.ApprovalTypeID";
            }
        }

        public static string at_CommuniqueText
        {
            get
            {
                return "OfferCommissionResult.CommuniqueText";
            }
        }

        public static string at_CorrelateLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterID
        {
            get
            {
                return "OfferCommissionResult.CorrelateLetterID";
            }
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "OfferCommissionResult.CorrelateOfferID";
            }
        }

        public static string at_CorrelateSession_CoLettersFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateSession.CoLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CommissionSessionTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateSession.CommissionSessionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateSession.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateSession.CorrelateOffersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_MembersFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateSession.MembersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateSession.SessionOrderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.CorrelateSessionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionID
        {
            get
            {
                return "OfferCommissionResult.CorrelateSessionID";
            }
        }

        public static string at_Duration
        {
            get
            {
                return "OfferCommissionResult.Duration";
            }
        }

        public static string at_OfferCommission_AdminExpertFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.OfferCommission.AdminExpertFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.OfferCommission.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_CommissionResultsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.OfferCommission.CommissionResultsFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.OfferCommission.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.OfferCommission.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_GovReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.OfferCommission.GovReportsFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_OfferEngineeringsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.OfferCommission.OfferEngineeringsFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_SessionsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.OfferCommission.SessionsFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_StatusFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.OfferCommission.StatusFirstLevelAttributes";
            }
        }

        public static string at_OfferCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionResult.OfferCommissionFirstLevelAttributes";
            }
        }

        public static string at_OfferCommissionID
        {
            get
            {
                return "OfferCommissionResult.OfferCommissionID";
            }
        }

        public static string at_PlanningProcess
        {
            get
            {
                return "OfferCommissionResult.PlanningProcess";
            }
        }

        public static string at_Reasons
        {
            get
            {
                return "OfferCommissionResult.Reasons";
            }
        }

        public static string at_ResultText
        {
            get
            {
                return "OfferCommissionResult.ResultText";
            }
        }

        [DocumentAttributeID("9229"), Category(""), Description(""), IsRelational("false"), AttributeType("LongText"), Browsable(true), DisplayName("")]
        public string CommuniqueText
        {
            get
            {
                return this._CommuniqueText;
            }
            set
            {
                this._CommuniqueText = value;
            }
        }

        [AttributeType("Letter"), Description("نامه ابلاغیه"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("نامه ابلاغیه"), Category(""), DocumentAttributeID("9102"), Browsable(true), IsRelational("False")]
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

        [DisplayName("پیشنهاد مرتبط"), IsRelational("False"), IsMiddleTableExist("False"), RelationTable(""), AttributeType("Offer"), Description("پیشنهاد مرتبط"), Category(""), DocumentAttributeID("9104"), Browsable(true)]
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

        [IsRelational("False"), AttributeType("CommissionSession"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("جلسه مرتبط"), Category(""), DocumentAttributeID("9105"), Browsable(true), Description("جلسه مرتبط")]
        public CommissionSession CorrelateSession
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

        [Browsable(true), DocumentAttributeID("9233"), IsRelational("false"), AttributeType("String"), Description(""), DisplayName(""), Category("")]
        public string Duration
        {
            get
            {
                return this._Duration;
            }
            set
            {
                this._Duration = value;
            }
        }

        [Description("پیشنهاد ارجاع شده به کمیسیون"), IsRelational("False"), RelationTable(""), DisplayName("پیشنهاد کمیسیون"), Category(""), DocumentAttributeID("9321"), Browsable(true), AttributeType("OfferCommission"), IsMiddleTableExist("False")]
        public Sbn.Products.GEP.GEPObject.OfferCommission OfferCommission
        {
            get
            {
                return this._OfferCommission;
            }
            set
            {
                this._OfferCommission = value;
            }
        }

        [Description("روند تصمیم گیری"), Category(""), DocumentAttributeID("9228"), IsRelational("false"), AttributeType("String"), Browsable(true), DisplayName("روند تصمیم گیری")]
        public string PlanningProcess
        {
            get
            {
                return this._PlanningProcess;
            }
            set
            {
                this._PlanningProcess = value;
            }
        }

        [AttributeType("String"), Browsable(true), DisplayName("دلایل تایید یا رد پیشنهاد"), Category(""), DocumentAttributeID("9227"), IsRelational("false"), Description("دلایل تایید یا رد پیشنهاد")]
        public string Reasons
        {
            get
            {
                return this._Reasons;
            }
            set
            {
                this._Reasons = value;
            }
        }

        [Category(""), Browsable(true), DisplayName("نظر کلی کمیسیون"), Description("نظر کلی کمیسیون"), DocumentAttributeID("9049"), IsRelational("false"), AttributeType("String")]
        public string ResultText
        {
            get
            {
                return this._ResultText;
            }
            set
            {
                this._ResultText = value;
            }
        }
    }
}
