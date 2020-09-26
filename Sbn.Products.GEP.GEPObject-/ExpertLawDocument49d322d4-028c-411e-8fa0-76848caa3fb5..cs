namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("مستند قانوني يا بخشي از قوانين كه توسط كارشناس تهيه مي شود و براي پيشنهادهاي ديگر بعنوان مرجع قرار مي گيرد."), DisplayName("مستند قانوني يا بخشي از قوانين كه توسط كارشناس تهيه مي شود و براي پيشنهادهاي ديگر بعنوان مرجع قرار مي گيرد."), ObjectCode("9108"), ItemsType("Sbn.Products.GEP.GEPObject.ExpertLawDocuments")]
    public class ExpertLawDocument : SbnObject
    {
        private string _CompleteText;
        private BasicInfoDetail _CorrelateCommission;
        private Law _CorrelateLawDoc;
        private Offer _CorrelateOffer;
        private string _RegisterDate;
        private string _Title;

        public ExpertLawDocument()
        {
        }

        public ExpertLawDocument(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            ExpertLawDocument document = new ExpertLawDocument {
                ID = base.ID
            };
            if (this._RegisterDate != null)
            {
                document.RegisterDate = (string) this._RegisterDate.Clone();
            }
            document.Title = this._Title;
            if (this._CompleteText != null)
            {
                document.CompleteText = (string) this._CompleteText.Clone();
            }
            if (!object.ReferenceEquals(this.CorrelateLawDoc, null))
            {
                document.CorrelateLawDoc = (Law) this.CorrelateLawDoc.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateCommission, null))
            {
                document.CorrelateCommission = (BasicInfoDetail) this.CorrelateCommission.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                document.CorrelateOffer = (Offer) this.CorrelateOffer.Clone(sNodeName);
            }
            return document;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._RegisterDate = "";
            this._Title = "";
            this._CompleteText = "";
            this._CorrelateLawDoc = new Law();
            this._CorrelateCommission = new BasicInfoDetail();
            this._CorrelateOffer = new Offer();
        }

        public override string ToString()
        {
            return this.Title;
        }

        public static string at_CompleteText
        {
            get
            {
                return "ExpertLawDocument.CompleteText";
            }
        }

        public static string at_CorrelateCommission_ParentFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateCommission.ParentFirstLevelAttributes";
            }
        }

        public static string at_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateCommissionID
        {
            get
            {
                return "ExpertLawDocument.CorrelateCommissionID";
            }
        }

        public static string at_CorrelateLawDoc_LowSourceTypeFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateLawDoc.LowSourceTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLawDocFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateLawDocFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLawDocID
        {
            get
            {
                return "ExpertLawDocument.CorrelateLawDocID";
            }
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "ExpertLawDocument.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "ExpertLawDocument.CorrelateOfferID";
            }
        }

        public static string at_RegisterDate
        {
            get
            {
                return "ExpertLawDocument.RegisterDate";
            }
        }

        public static string at_Title
        {
            get
            {
                return "ExpertLawDocument.Title";
            }
        }

        [AttributeType("LongText"), Browsable(true), DisplayName("متن قانون"), Category(""), DocumentAttributeID("9237"), IsRelational("false"), Description("متن انتخابی توسط کارشناس")]
        public string CompleteText
        {
            get
            {
                return this._CompleteText;
            }
            set
            {
                this._CompleteText = value;
            }
        }

        [IsRelational("False"), DocumentAttributeID("9390"), Browsable(true), RelationTable(""), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), Description("کمیسیون مرتبط"), DisplayName("کمیسیون مرتبط"), Category("")]
        public BasicInfoDetail CorrelateCommission
        {
            get
            {
                return this._CorrelateCommission;
            }
            set
            {
                this._CorrelateCommission = value;
            }
        }

        [AttributeType("Law"), IsRelational("False"), IsMiddleTableExist("False"), RelationTable(""), Description("مرجع"), DisplayName("مرجع"), Category(""), DocumentAttributeID("9098"), Browsable(true)]
        public Law CorrelateLawDoc
        {
            get
            {
                return this._CorrelateLawDoc;
            }
            set
            {
                this._CorrelateLawDoc = value;
            }
        }

        [IsRelational("False"), AttributeType("Offer"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("پیشنهاد"), Category(""), DocumentAttributeID("9401"), Browsable(true), Description("پیشنهاد مرتبط")]
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

        [Category(""), DisplayName("تاریخ ثبت"), Description("تاریخ ثبت"), DocumentAttributeID("9045"), IsRelational("false"), AttributeType("DateString"), Browsable(true)]
        public string RegisterDate
        {
            get
            {
                return this._RegisterDate;
            }
            set
            {
                this._RegisterDate = value;
            }
        }

        [Description("خلاصه"), DisplayName("خلاصه"), Category(""), DocumentAttributeID("9046"), IsRelational("false"), AttributeType("String"), Browsable(true)]
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
