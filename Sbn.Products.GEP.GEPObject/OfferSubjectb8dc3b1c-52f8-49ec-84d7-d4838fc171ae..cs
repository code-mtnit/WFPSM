namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Products.GEP.GEPObject.TMU;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("موضوع مرتبط با پيشنهاد با در نظر گرفتن نوع كميسيون"), DisplayName("موضوع مرتبط با پيشنهاد با در نظر گرفتن نوع كميسيون"), ObjectCode("9270"), ItemsType("Sbn.Products.GEP.GEPObject.OfferSubjects")]
    public class OfferSubject : SbnObject
    {
        private Offer _CoOffer;
        private Subject _CoSubject;

        public OfferSubject()
        {
        }

        public OfferSubject(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            OfferSubject subject = new OfferSubject(this);
            if (!object.ReferenceEquals(this.CoSubject, null))
            {
                subject.CoSubject = (Subject) this.CoSubject.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoOffer, null))
            {
                subject.CoOffer = (Offer) this.CoOffer.Clone(sNodeName);
            }
            return subject;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._CoSubject = new Subject();
            this._CoOffer = new Offer();
        }

        public override string ToString()
        {
            if (this.CoSubject != null)
            {
                return this.CoSubject.Title;
            }
            return "";
        }

        public static string at_CoOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CoOfferFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoOfferFirstLevelAttributes";
            }
        }

        public static string at_CoOfferID
        {
            get
            {
                return "OfferSubject.CoOfferID";
            }
        }

        public static string at_CoSubjectFirstLevelAttributes
        {
            get
            {
                return "OfferSubject.CoSubjectFirstLevelAttributes";
            }
        }

        public static string at_CoSubjectID
        {
            get
            {
                return "OfferSubject.CoSubjectID";
            }
        }

        [DisplayName("پیشنهاد مرتبط"), IsMiddleTableExist("False"), RelationTable(""), Description("پیشنهاد مرتبط"), Category(""), DocumentAttributeID("9376"), Browsable(true), IsRelational("False"), AttributeType("Offer")]
        public Offer CoOffer
        {
            get
            {
                return this._CoOffer;
            }
            set
            {
                this._CoOffer = value;
            }
        }

        [AttributeType("Subject"), IsMiddleTableExist("True"), RelationTable(""), DisplayName("موضوع"), Category(""), DocumentAttributeID("9375"), Browsable(true), IsRelational("True"), Description("موضوع")]
        public Subject CoSubject
        {
            get
            {
                return this._CoSubject;
            }
            set
            {
                this._CoSubject = value;
            }
        }
    }
}
