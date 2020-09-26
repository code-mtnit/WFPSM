namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName(""), SystemName("GEP"), ObjectCode("9081"), ItemsType("Sbn.Products.GEP.GEPObject.GovSessionMemberOpinions"), Description("")]
    public class GovSessionMemberOpinion : Opinion
    {
        private Sbn.Products.GEP.GEPObject.AnnotationPictures _AnnotationPictures;
        private Offer _CorrelateOffer;
        private GovSession _CorrelateSession;
        private GovSessionMember _CorrelateSessionMember;

        public GovSessionMemberOpinion()
        {
        }

        public GovSessionMemberOpinion(Opinion InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            GovSessionMemberOpinion opinion = new GovSessionMemberOpinion {
                ID = base.ID
            };
            if (!object.ReferenceEquals(this.CorrelateSession, null))
            {
                opinion.CorrelateSession = (GovSession) this.CorrelateSession.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                opinion.CorrelateOffer = (Offer) this.CorrelateOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateSessionMember, null))
            {
                opinion.CorrelateSessionMember = (GovSessionMember) this.CorrelateSessionMember.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.AnnotationPictures, null))
            {
                opinion.AnnotationPictures = (Sbn.Products.GEP.GEPObject.AnnotationPictures) this.AnnotationPictures.Clone(sNodeName);
            }
            return opinion;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._CorrelateSession = new GovSession();
            this._CorrelateOffer = new Offer();
            this._CorrelateSessionMember = new GovSessionMember();
            this._AnnotationPictures = new Sbn.Products.GEP.GEPObject.AnnotationPictures();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        [DocumentAttributeID("9344"), Description("تصاویر یادداشتها"), AttributeType("AnnotationPictures"), DisplayName("یادداشتها"), Category(""), IsRelational("False"), IsMiddleTableExist("False"), RelationTable("AnnPics"), Browsable(true)]
        public Sbn.Products.GEP.GEPObject.AnnotationPictures AnnotationPictures
        {
            get
            {
                return this._AnnotationPictures;
            }
            set
            {
                this._AnnotationPictures = value;
            }
        }

        public static string at_AnnotationPicturesFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.AnnotationPicturesFirstLevelAttributes";
            }
        }

        public static string at_AnnotationPicturesID
        {
            get
            {
                return "GovSessionMemberOpinion.AnnotationPicturesID";
            }
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateOfferID";
            }
        }

        public static string at_CorrelateSession_CataloguesFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSession.CataloguesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CoLettersFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSession.CoLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSession.CorrelateOffersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_MembersFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSession.MembersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_OrganAnnouncementFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSession.OrganAnnouncementFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_PreOrdersFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSession.PreOrdersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_PresentationsFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSession.PresentationsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSession.SessionOrderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSessionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionID
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSessionID";
            }
        }

        public static string at_CorrelateSessionMember_CorrelatePersonnelFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSessionMember.CorrelatePersonnelFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionMember_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSessionMember.CorrelateSessionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionMember_OpinionsFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSessionMember.OpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionMemberFirstLevelAttributes
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSessionMemberFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionMemberID
        {
            get
            {
                return "GovSessionMemberOpinion.CorrelateSessionMemberID";
            }
        }

        [Browsable(true), Category(""), DocumentAttributeID("9049"), Description("پیشنهاد"), IsRelational("False"), AttributeType("Offer"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("پیشنهاد")]
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

        [Description("جلسه"), DisplayName("جلسه"), DocumentAttributeID("9048"), Browsable(true), IsRelational("False"), AttributeType("GovSession"), IsMiddleTableExist("False"), RelationTable(""), Category("")]
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

        [RelationTable(""), Browsable(true), IsRelational("False"), Description("عضو جلسه"), DisplayName("عضو جلسه"), Category(""), DocumentAttributeID("9050"), AttributeType("GovSessionMember"), IsMiddleTableExist("False")]
        public GovSessionMember CorrelateSessionMember
        {
            get
            {
                return this._CorrelateSessionMember;
            }
            set
            {
                this._CorrelateSessionMember = value;
            }
        }
    }
}
