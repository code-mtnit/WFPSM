namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName("کارشناسی در کمیسیون مربوط به یک پیشنهاد"), Description("کارشناسی در کمیسیون مربوط به یک پیشنهاد"), SystemName("GEP"), ObjectCode("9101"), ItemsType("Sbn.Products.GEP.GEPObject.Engineerings")]
    public class Engineering : SbnObject
    {
        private string _AssignDate;
        private CommissionExpert _CorrelateExpert;
        private GovernmentReports _CorrelateGovReports;
        private Offer _CorrelateOffer;
        private OfferCommission _CorrelateOfferCommission;
        private string _EndDate;

        public Engineering()
        {
        }

        public Engineering(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            Engineering engineering = new Engineering {
                ID = base.ID
            };
            if (this._AssignDate != null)
            {
                engineering.AssignDate = (string) this._AssignDate.Clone();
            }
            if (this._EndDate != null)
            {
                engineering.EndDate = (string) this._EndDate.Clone();
            }
            if (!object.ReferenceEquals(this.CorrelateExpert, null))
            {
                engineering.CorrelateExpert = (CommissionExpert) this.CorrelateExpert.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                engineering.CorrelateOffer = (Offer) this.CorrelateOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOfferCommission, null))
            {
                engineering.CorrelateOfferCommission = (OfferCommission) this.CorrelateOfferCommission.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateGovReports, null))
            {
                engineering.CorrelateGovReports = (GovernmentReports) this.CorrelateGovReports.Clone(sNodeName);
            }
            return engineering;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._AssignDate = "";
            this._EndDate = "";
            this._CorrelateExpert = new CommissionExpert();
            this._CorrelateOffer = new Offer();
            this._CorrelateOfferCommission = new OfferCommission();
            this._CorrelateGovReports = new GovernmentReports();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        [Browsable(true), Description("تاریخ ارجاع به کارشناس"), DisplayName("تاریخ ارجاع به کارشناس"), Category(""), DocumentAttributeID("9038"), IsRelational("false"), AttributeType("DateString")]
        public string AssignDate
        {
            get
            {
                return this._AssignDate;
            }
            set
            {
                this._AssignDate = value;
            }
        }

        public static string at_AssignDate
        {
            get
            {
                return "Engineering.AssignDate";
            }
        }

        public static string at_CorrelateExpert_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateExpert.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateExpert_CorrelatePersonFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateExpert.CorrelatePersonFirstLevelAttributes";
            }
        }

        public static string at_CorrelateExpertFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateExpertFirstLevelAttributes";
            }
        }

        public static string at_CorrelateExpertID
        {
            get
            {
                return "Engineering.CorrelateExpertID";
            }
        }

        public static string at_CorrelateGovReportsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateGovReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateGovReportsID
        {
            get
            {
                return "Engineering.CorrelateGovReportsID";
            }
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_AdminExpertFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOfferCommission.AdminExpertFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOfferCommission.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_CommissionResultsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOfferCommission.CommissionResultsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOfferCommission.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOfferCommission.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_GovReportsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOfferCommission.GovReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_OfferEngineeringsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOfferCommission.OfferEngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_SessionsFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOfferCommission.SessionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommission_StatusFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOfferCommission.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommissionFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOfferCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferCommissionID
        {
            get
            {
                return "Engineering.CorrelateOfferCommissionID";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Engineering.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "Engineering.CorrelateOfferID";
            }
        }

        public static string at_EndDate
        {
            get
            {
                return "Engineering.EndDate";
            }
        }

        [IsRelational("False"), IsMiddleTableExist("False"), RelationTable(""), AttributeType("CommissionExpert"), Description("کارشناس مرتبط با پیشنهاد"), DisplayName("کارشناس مرتبط"), Category(""), DocumentAttributeID("9087"), Browsable(true)]
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

        [Browsable(true), Description("گزارشهای دولت مرتبط"), DisplayName("گزارشهای دولت"), Category(""), DocumentAttributeID("9090"), IsRelational("True"), AttributeType("GovernmentReports"), IsMiddleTableExist("True"), RelationTable("")]
        public GovernmentReports CorrelateGovReports
        {
            get
            {
                return this._CorrelateGovReports;
            }
            set
            {
                this._CorrelateGovReports = value;
            }
        }

        [DocumentAttributeID("9088"), AttributeType("Offer"), IsMiddleTableExist("False"), RelationTable(""), Description("پیشنهاد مرتبط"), DisplayName("پیشنهاد مرتبط"), Category(""), Browsable(true), IsRelational("False")]
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

        [Category(""), IsRelational("False"), AttributeType("OfferCommission"), RelationTable(""), Description("پیشنهاد کمیسیون"), DisplayName("پیشنهاد کمیسیون"), DocumentAttributeID("9089"), Browsable(true), IsMiddleTableExist("False")]
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

        [IsRelational("false"), Browsable(true), Description("اتمام کار کارشناسی"), DisplayName("تاریخ اتمام کارشناسی"), Category(""), DocumentAttributeID("9039"), AttributeType("DateString")]
        public string EndDate
        {
            get
            {
                return this._EndDate;
            }
            set
            {
                this._EndDate = value;
            }
        }
    }
}
