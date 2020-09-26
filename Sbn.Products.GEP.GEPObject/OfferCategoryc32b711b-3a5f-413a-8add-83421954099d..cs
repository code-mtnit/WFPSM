namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Products.GEP.GEPObject.TMU;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName("دسته بندي پيشنهاد"), Description("دسته بندي پيشنهاد"), SystemName("GEP"), ObjectCode("9300"), ItemsType("Sbn.Products.GEP.GEPObject.OfferCategories")]
    public class OfferCategory : SbnObject
    {
        private Idea _CorrelateIdea;
        private Offer _CorrelateOffer;
        private Subject _CorrelateSubject;

        public OfferCategory()
        {
        }

        public OfferCategory(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            OfferCategory category = new OfferCategory {
                ID = base.ID
            };
            if (!object.ReferenceEquals(this.CorrelateIdea, null))
            {
                category.CorrelateIdea = (Idea) this.CorrelateIdea.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                category.CorrelateOffer = (Offer) this.CorrelateOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateSubject, null))
            {
                category.CorrelateSubject = (Subject) this.CorrelateSubject.Clone(sNodeName);
            }
            return category;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._CorrelateIdea = new Idea();
            this._CorrelateOffer = new Offer();
            this._CorrelateSubject = new Subject();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CorrelateIdea_CategoriesFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateIdea.CategoriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateIdea_CoUnitFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateIdea.CoUnitFirstLevelAttributes";
            }
        }

        public static string at_CorrelateIdea_ReferencesFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateIdea.ReferencesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateIdea_StatusFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateIdea.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateIdeaFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateIdeaFirstLevelAttributes";
            }
        }

        public static string at_CorrelateIdeaID
        {
            get
            {
                return "OfferCategory.CorrelateIdeaID";
            }
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "OfferCategory.CorrelateOfferID";
            }
        }

        public static string at_CorrelateSubject_CommissionTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateSubject.CommissionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSubject_TitleTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateSubject.TitleTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSubjectFirstLevelAttributes
        {
            get
            {
                return "OfferCategory.CorrelateSubjectFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSubjectID
        {
            get
            {
                return "OfferCategory.CorrelateSubjectID";
            }
        }

        [Category("مشخصات اصلی"), AttributeType("Idea"), IsMiddleTableExist("False"), RelationTable(""), Description("نظریه مرتبط"), DisplayName("نظریه مرتبط"), DocumentAttributeID("27228"), Browsable(true), IsRelational("False")]
        public Idea CorrelateIdea
        {
            get
            {
                return this._CorrelateIdea;
            }
            set
            {
                this._CorrelateIdea = value;
            }
        }

        [Description("پیشنهاد مرتبط"), DocumentAttributeID("27229"), Browsable(true), RelationTable(""), DisplayName("پیشنهاد مرتبط"), Category("مشخصات اصلی"), IsRelational("False"), AttributeType("Offer"), IsMiddleTableExist("False")]
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

        [DisplayName("موضوع مرتبط"), Description("موضوع مرتبط"), DocumentAttributeID("27230"), IsMiddleTableExist("False"), RelationTable(""), Browsable(true), IsRelational("False"), AttributeType("Subject"), Category("مشخصات اصلی")]
        public Subject CorrelateSubject
        {
            get
            {
                return this._CorrelateSubject;
            }
            set
            {
                this._CorrelateSubject = value;
            }
        }
    }
}
