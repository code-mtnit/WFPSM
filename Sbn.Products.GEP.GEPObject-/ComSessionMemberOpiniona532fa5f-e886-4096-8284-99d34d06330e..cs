namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, Description("نظر عضو کمیسیون"), SystemName("GEP"), DisplayName("نظر عضو کمیسیون"), ObjectCode("9102"), ItemsType("Sbn.Products.GEP.GEPObject.ComSessionMemberOpinions")]
    public class ComSessionMemberOpinion : SbnObject
    {
        private AnnotationPictures _AnnotationPics;
        private CommissionSessionMember _CorrelateMember;
        private Offer _CorrelateOffer;
        private CommissionSession _CorrelateSession;
        private string _OpinionDescription;
        private Sbn.Products.GEP.GEPObject.OfferCommission _OfferCommission;
        private BasicInfoDetail _OpinionType;

        public ComSessionMemberOpinion()
        {
        }

        public ComSessionMemberOpinion(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            ComSessionMemberOpinion opinion = new ComSessionMemberOpinion {
                ID = base.ID,
                OpinionDescription = this._OpinionDescription
            };
            if (!object.ReferenceEquals(this.CorrelateSession, null))
            {
                opinion.CorrelateSession = (CommissionSession) this.CorrelateSession.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateMember, null))
            {
                opinion.CorrelateMember = (CommissionSessionMember) this.CorrelateMember.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                opinion.CorrelateOffer = (Offer) this.CorrelateOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OpinionType, null))
            {
                opinion.OpinionType = (BasicInfoDetail) this.OpinionType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.AnnotationPics, null))
            {
                opinion.AnnotationPics = (AnnotationPictures) this.AnnotationPics.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OfferCommission, null))
            {
                opinion.OfferCommission = (Sbn.Products.GEP.GEPObject.OfferCommission) this.OfferCommission.Clone(sNodeName);
            }
            return opinion;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._OpinionDescription = "";
            this._CorrelateSession = new CommissionSession();
            this._CorrelateMember = new CommissionSessionMember();
            this._CorrelateOffer = new Offer();
            this._OpinionType = new BasicInfoDetail();
            this._AnnotationPics = new AnnotationPictures();
            this._OfferCommission = new Sbn.Products.GEP.GEPObject.OfferCommission();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        [AttributeType("AnnotationPictures"), Category(""), Browsable(true), IsRelational("False"), Description("یادداشتها"), IsMiddleTableExist("False"), RelationTable("AnnPics"), DocumentAttributeID("9343"), DisplayName("یادداشتها")]
        public AnnotationPictures AnnotationPics
        {
            get
            {
                return this._AnnotationPics;
            }
            set
            {
                this._AnnotationPics = value;
            }
        }

        public static string at_AnnotationPicsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.AnnotationPicsFirstLevelAttributes";
            }
        }

        public static string at_AnnotationPicsID
        {
            get
            {
                return "ComSessionMemberOpinion.AnnotationPicsID";
            }
        }

        public static string at_CorrelateMember_CorrelateOrgPositionFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateMember.CorrelateOrgPositionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateMember_CorrelatePersonFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateMember.CorrelatePersonFirstLevelAttributes";
            }
        }

        public static string at_CorrelateMember_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateMember.CorrelateSessionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateMemberFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateMemberFirstLevelAttributes";
            }
        }

        public static string at_CorrelateMemberID
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateMemberID";
            }
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateOfferID";
            }
        }

        public static string at_CorrelateSession_CoLettersFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateSession.CoLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CommissionSessionTypeFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateSession.CommissionSessionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateSession.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateSession.CorrelateOffersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_MembersFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateSession.MembersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateSession.SessionOrderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateSessionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionID
        {
            get
            {
                return "ComSessionMemberOpinion.CorrelateSessionID";
            }
        }

        public static string at_OpinionDescription
        {
            get
            {
                return "ComSessionMemberOpinion.OpinionDescription";
            }
        }

        public static string at_OfferCommission_AdminExpertFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.OfferCommission.AdminExpertFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.OfferCommission.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_CommissionResultsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.OfferCommission.CommissionResultsFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.OfferCommission.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.OfferCommission.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_GovReportsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.OfferCommission.GovReportsFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_OfferEngineeringsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.OfferCommission.OfferEngineeringsFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_SessionsFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.OfferCommission.SessionsFirstLevelAttributes";
            }
        }

        public static string at_OfferCommission_StatusFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.OfferCommission.StatusFirstLevelAttributes";
            }
        }

        public static string at_OfferCommissionFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.OfferCommissionFirstLevelAttributes";
            }
        }

        public static string at_OfferCommissionID
        {
            get
            {
                return "ComSessionMemberOpinion.OfferCommissionID";
            }
        }

        public static string at_OpinionType_ParentFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.OpinionType.ParentFirstLevelAttributes";
            }
        }

        public static string at_OpinionTypeFirstLevelAttributes
        {
            get
            {
                return "ComSessionMemberOpinion.OpinionTypeFirstLevelAttributes";
            }
        }

        public static string at_OpinionTypeID
        {
            get
            {
                return "ComSessionMemberOpinion.OpinionTypeID";
            }
        }

        [DocumentAttributeID("9093"), IsRelational("False"), RelationTable(""), Description("عضو کمیسیون"), DisplayName("عضو کمیسیون"), Category(""), Browsable(true), AttributeType("CommissionSessionMember"), IsMiddleTableExist("False")]
        public CommissionSessionMember CorrelateMember
        {
            get
            {
                return this._CorrelateMember;
            }
            set
            {
                this._CorrelateMember = value;
            }
        }

        [Browsable(true), AttributeType("Offer"), RelationTable(""), IsRelational("False"), Description("پیشنهاد"), DisplayName("پیشنهاد"), Category(""), DocumentAttributeID("9092"), IsMiddleTableExist("False")]
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

        [IsMiddleTableExist("False"), IsRelational("False"), AttributeType("CommissionSession"), DisplayName("جلسه"), RelationTable(""), Category(""), DocumentAttributeID("9094"), Description("جلسه"), Browsable(true)]
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

        [DocumentAttributeID("9219"), DisplayName("متن نظر عضو"), AttributeType("LongText"), Browsable(true), Category(""), Description("متن نظر عضو"), IsRelational("false")]
        public string OpinionDescription
        {
            get
            {
                return this._OpinionDescription;
            }
            set
            {
                this._OpinionDescription = value;
            }
        }

        [Category(""), DocumentAttributeID("9322"), Browsable(true), IsRelational("False"), AttributeType("OfferCommission"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("پیشنهاد کمیسیون"), Description("پیشنهاد ارجاع شده به کمیسیون")]
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

        [AttributeType("BasicInfoDetail"), Category(""), Browsable(true), IsRelational("False"), DisplayName("نوع اعلام نظر"), IsMiddleTableExist("False"), RelationTable(""), DocumentAttributeID("9286"), Description("نوع اعلام نظر")]
        public BasicInfoDetail OpinionType
        {
            get
            {
                return this._OpinionType;
            }
            set
            {
                this._OpinionType = value;
            }
        }
    }
}
