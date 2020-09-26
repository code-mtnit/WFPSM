namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.OfferCommissions"), Description("پرونده پيشنهاد"), DisplayName("پرونده پيشنهاد"), ObjectCode("9089")]
    public class OfferCommission : SbnObject
    {
        private CommissionExpert _AdminExpert;
        private string _AssignDate;
        private OfferCommissionReports _CommissionReports;
        private OfferCommissionResults _CommissionResults;
        private BasicInfoDetail _CorrelateCommission;
        private Offer _CorrelateOffer;
        private string _EndWorkDate;
        private GovernmentReports _GovReports;
        private Engineerings _OfferEngineerings;
        private CommissionSessions _Sessions;
        private BasicInfoDetail _Status;

        private long _orderInCommissionSession;


        public OfferCommission()
        {
        }

        public OfferCommission(SbnObject InitialObject)
            : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            OfferCommission commission = new OfferCommission
            {
                ID = base.ID
            };
            if (this._EndWorkDate != null)
            {
                commission.EndWorkDate = (string)this._EndWorkDate.Clone();
            }
            if (this._AssignDate != null)
            {
                commission.AssignDate = (string)this._AssignDate.Clone();
            }
            if (!object.ReferenceEquals(this.Status, null))
            {
                commission.Status = (BasicInfoDetail)this.Status.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                commission.CorrelateOffer = (Offer)this.CorrelateOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateCommission, null))
            {
                commission.CorrelateCommission = (BasicInfoDetail)this.CorrelateCommission.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.AdminExpert, null))
            {
                commission.AdminExpert = (CommissionExpert)this.AdminExpert.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OfferEngineerings, null))
            {
                commission.OfferEngineerings = (Engineerings)this.OfferEngineerings.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.GovReports, null))
            {
                commission.GovReports = (GovernmentReports)this.GovReports.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CommissionReports, null))
            {
                commission.CommissionReports = (OfferCommissionReports)this.CommissionReports.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Sessions, null))
            {
                commission.Sessions = (CommissionSessions)this.Sessions.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CommissionResults, null))
            {
                commission.CommissionResults = (OfferCommissionResults)this.CommissionResults.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OrderInCommissionSession, null))
            {
                commission.OrderInCommissionSession = this.OrderInCommissionSession;
            }

            return commission;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._EndWorkDate = "";
            this._AssignDate = "";
            this._Status = new BasicInfoDetail();
            this._CorrelateOffer = new Offer();
            this._CorrelateCommission = new BasicInfoDetail();
            this._AdminExpert = new CommissionExpert();
            this._OfferEngineerings = new Engineerings();
            this._GovReports = new GovernmentReports();
            this._CommissionReports = new OfferCommissionReports();
            this._Sessions = new CommissionSessions();
            this._CommissionResults = new OfferCommissionResults();
            this._orderInCommissionSession = 0;
        }

        public override string ToString()
        {
            if (this.CorrelateCommission != null)
            {
                return this.CorrelateCommission.Title;
            }
            return "";
        }

        [Category(""), Description("کارشناس ارشد پرونده در کمیسیون"), DisplayName("کارشناس ارشد"), DocumentAttributeID("9068"), Browsable(true), IsRelational("False"), AttributeType("CommissionExpert"), IsMiddleTableExist("False"), RelationTable("")]
        public CommissionExpert AdminExpert
        {
            get
            {
                return this._AdminExpert;
            }
            set
            {
                this._AdminExpert = value;
            }
        }

        [DisplayName("تاریخ ارجاع"), IsRelational("false"), AttributeType("DateString"), Browsable(true), Description("تاریخ ارجاع پیشنهاد به کمیسیون"), Category(""), DocumentAttributeID("9030")]
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

        public static string at_AdminExpert_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.AdminExpert.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_AdminExpert_CorrelatePersonFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.AdminExpert.CorrelatePersonFirstLevelAttributes";
            }
        }

        public static string at_AdminExpertFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.AdminExpertFirstLevelAttributes";
            }
        }

        public static string at_AdminExpertID
        {
            get
            {
                return "OfferCommission.AdminExpertID";
            }
        }

        public static string at_AssignDate
        {
            get
            {
                return "OfferCommission.AssignDate";
            }
        }

        public static string at_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CommissionReportsID
        {
            get
            {
                return "OfferCommission.CommissionReportsID";
            }
        }

        public static string at_CommissionResultsFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CommissionResultsFirstLevelAttributes";
            }
        }

        public static string at_CommissionResultsID
        {
            get
            {
                return "OfferCommission.CommissionResultsID";
            }
        }

        public static string at_CorrelateCommission_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateCommission.ParentFirstLevelAttributes";
            }
        }

        public static string at_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateCommissionID
        {
            get
            {
                return "OfferCommission.CorrelateCommissionID";
            }
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "OfferCommission.CorrelateOfferID";
            }
        }

        public static string at_EndWorkDate
        {
            get
            {
                return "OfferCommission.EndWorkDate";
            }
        }

        public static string at_GovReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.GovReportsFirstLevelAttributes";
            }
        }

        public static string at_GovReportsID
        {
            get
            {
                return "OfferCommission.GovReportsID";
            }
        }

        public static string at_OfferEngineeringsFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.OfferEngineeringsFirstLevelAttributes";
            }
        }

        public static string at_OfferEngineeringsID
        {
            get
            {
                return "OfferCommission.OfferEngineeringsID";
            }
        }

        public static string at_SessionsFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.SessionsFirstLevelAttributes";
            }
        }

        public static string at_SessionsID
        {
            get
            {
                return "OfferCommission.SessionsID";
            }
        }

        public static string at_Status_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.Status.ParentFirstLevelAttributes";
            }
        }

        public static string at_StatusFirstLevelAttributes
        {
            get
            {
                return "OfferCommission.StatusFirstLevelAttributes";
            }
        }

        public static string at_StatusID
        {
            get
            {
                return "OfferCommission.StatusID";
            }
        }
        public static string at_OrderInCommissionSession
        {
            get
            {
                return "OfferCommission.OrderInCommissionSession";
            }
        }

        [IsMiddleTableExist("True"), Category(""), RelationTable(""), DisplayName("گزارشها"), DocumentAttributeID("9347"), Browsable(true), IsRelational("True"), AttributeType("OfferCommissionReports"), Description("گزارشها")]
        public OfferCommissionReports CommissionReports
        {
            get
            {
                return this._CommissionReports;
            }
            set
            {
                this._CommissionReports = value;
            }
        }

        [Browsable(true), IsMiddleTableExist("True"), Description("نتایج جلسات کمیسیون"), AttributeType("OfferCommissionResults"), RelationTable(""), DisplayName("نتایج جلسات کمیسیون"), Category(""), DocumentAttributeID("9391"), IsRelational("True")]
        public OfferCommissionResults CommissionResults
        {
            get
            {
                return this._CommissionResults;
            }
            set
            {
                this._CommissionResults = value;
            }
        }

        [DocumentAttributeID("9066"), DisplayName("کمیسیون مرتبط"), IsMiddleTableExist("False"), Category(""), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), RelationTable(""), Description("پیشنهاد کمیسیون مرتبط")]
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

        [IsRelational("False"), DisplayName("پیشنهاد مرتبط"), IsMiddleTableExist("False"), DocumentAttributeID("9065"), Browsable(true), RelationTable(""), AttributeType("Offer"), Category(""), Description("پرونده پیشنهاد مرتبط")]
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

        [IsRelational("false"), Browsable(true), Description("تاریخ خاتمه کار کارشناسی"), DisplayName("تاریخ خاتمه کارشناسی"), Category(""), DocumentAttributeID("9040"), AttributeType("DateString")]
        public string EndWorkDate
        {
            get
            {
                return this._EndWorkDate;
            }
            set
            {
                this._EndWorkDate = value;
            }
        }

        [IsMiddleTableExist("True"), DocumentAttributeID("9351"), Browsable(true), IsRelational("True"), AttributeType("GovernmentReports"), Description("گزارشهای دولت"), RelationTable(""), DisplayName("گزارشهای دولت"), Category("")]
        public GovernmentReports GovReports
        {
            get
            {
                return this._GovReports;
            }
            set
            {
                this._GovReports = value;
            }
        }

        [DisplayName("کارشناسی ها"), Category(""), DocumentAttributeID("9305"), Browsable(true), Description("کارشناسی انجام شده روی پیشنهاد"), IsRelational("True"), AttributeType("Engineerings"), IsMiddleTableExist("True"), RelationTable("")]
        public Engineerings OfferEngineerings
        {
            get
            {
                return this._OfferEngineerings;
            }
            set
            {
                this._OfferEngineerings = value;
            }
        }

        [DocumentAttributeID("9372"), IsRelational("False"), AttributeType("CommissionSessions"), IsMiddleTableExist("False"), RelationTable("OFFERCOMMISSION_SESSIONS_M"), Browsable(true), Category(""), Description("جلسات: که در حال حاضر  ارزش ذخیره سازی ندارد"), DisplayName("جلسات")]
        public CommissionSessions Sessions
        {
            get
            {
                return this._Sessions;
            }
            set
            {
                this._Sessions = value;
            }
        }

        [RelationTable(""), Description("وضعیت پرونده در کمیسیون"), DisplayName("وضعیت پرونده"), Category(""), DocumentAttributeID("9077"), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False")]
        public BasicInfoDetail Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }

        [RelationTable(""), Description("ترتیب در دستور جلسه کمیسیون"), DisplayName("ترتیب"), Category(""), DocumentAttributeID(""), Browsable(true), IsRelational("False"), AttributeType("long"), IsMiddleTableExist("False")]
        public long OrderInCommissionSession { get { return _orderInCommissionSession; } set { _orderInCommissionSession = value; } }
    }
}
