using Sbn.Core;
using Sbn.Libs.AssemblyTools;
using Sbn.Systems.WMC.WMCObject;
using System;
using System.ComponentModel;

namespace Sbn.Products.GEP.GEPObject
{
    [Serializable, Description("درخواست پیشنهاد"), SystemName("GEP"), DisplayName("درخواست پیشنهاد"), ObjectCode("9062"), ItemsType("Sbn.Products.GEP.GEPObject.OfferTemps")]
    public class OfferTemp : SbnObject
    {
        private OfferCommission _ActiveCommission;
        //private Sbn.Products.GEP.GEPObject.ApprovalLetters _ApprovalLetters;
        //private OfferCommissionReports _CommissionReports;
        //private OfferCommissions _Commissions;
        //private BasicInfoDetail _CommuniqueStatus;
        //private BasicInfoDetail _Complication;
        //private OfferOrgUnits _CorrelateOrgans;
        //private Sbn.Products.GEP.GEPObject.Engineerings _Engineerings;
        //private GovernmentReports _GovernReports;
        //private GovSessionMemberOpinions _GovMemberOpinions;
        //private string _GovOfficeReceiptDate;
        //private string _GovSessionTitle;
        //private BasicInfoDetail _Importance;
        //private Sbn.Products.GEP.GEPObject.Inquiries _Inquiries;
        private ExpertLawDocuments _LawDocuments;
        private string _OfferAbstract;//private Sbn.Products.GEP.GEPObject.OfferAbstract _OfferAbstract;
        private string _Assessment;

        private string _OfferComment;
        private string _OfferCommuniqueText;//private Sbn.Products.GEP.GEPObject.OfferCommuniqueText _OfferCommuniqueText;

        private Letter _OfferLetter;
        private BasicInfoDetail _OfferType;
        //private string _OfficialCode;
        //private int _OrderInCatalogue;
        //private Letters _OtherLetters;
        //private OfferOrgUnit _OwnerOrgan;
        private OrgUnit _OwnerOrgan;
        //private Sbn.Products.GEP.GEPObject.PreObservation _PreObservation;
        private string _RegisterDate;
        private BasicInfoDetail _Security;
        private BasicInfoDetail _Status;
        //private BasicInfoDetail _StatusInGovOrderOffice;
        //private OfferSubjects _Subjects;
        private BasicInfoDetail _Urgency;
        private string _VicePresidentLetterID;
        private string _VicePresidentReceiptdate;

        private Offer _CoOffer;

        //private PublishableState _IsPublishable = PublishableState.None;
        //private string _PublishableDate;

        //private GeneralDocument _WordDoc;

        private GeneralDocument _DefinitionWordDoc;
        private GeneralDocument _UrgencyReasonsWordDoc;
        private GeneralDocument _RelatedLawsWordDoc;
        private GeneralDocument _GoalsWordDoc;
        private GeneralDocument _OptionsWordDoc;
        private GeneralDocument _OptionsEffectsWordDoc;
        private GeneralDocument _OptionsCompareWordDoc;
        private GeneralDocument _LegalAnalysisWordDoc;
        private GeneralDocument _ExcutivePlanWordDoc;
        private GeneralDocument _MonitoringPlanWordDoc;


        public OfferTemp()
        {
        }

        public OfferTemp(SbnObject InitialObject)
            : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            OfferTemp offerTemp = new OfferTemp
            {
                ID = base.ID,
                //OrderInCatalogue = this._OrderInCatalogue,
                //OfficialCode = this._OfficialCode
            };
            if (this._VicePresidentReceiptdate != null)
            {
                offerTemp.VicePresidentReceiptdate = (string)this._VicePresidentReceiptdate.Clone();
            }
            offerTemp.VicePresidentLetterID = this._VicePresidentLetterID;
            /*if (this._GovOfficeReceiptDate != null)
            {
                offerTemp.GovOfficeReceiptDate = (string)this._GovOfficeReceiptDate.Clone();
            }*/
            if (this._RegisterDate != null)
            {
                offerTemp.RegisterDate = (string)this._RegisterDate.Clone();
            }
            if (this._OfferComment != null)
            {
                offerTemp.OfferComment = (string)this._OfferComment.Clone();
            }
            /*offerTemp.GovSessionTitle = this._GovSessionTitle;
            if (!object.ReferenceEquals(this.OtherLetters, null))
            {
                offerTemp.OtherLetters = (Letters)this.OtherLetters.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.ApprovalLetters, null))
            {
                offerTemp.ApprovalLetters = (Sbn.Products.GEP.GEPObject.ApprovalLetters)this.ApprovalLetters.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.GovernReports, null))
            {
                offerTemp.GovernReports = (GovernmentReports)this.GovernReports.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Inquiries, null))
            {
                offerTemp.Inquiries = (Sbn.Products.GEP.GEPObject.Inquiries)this.Inquiries.Clone(sNodeName);
            }*/
            if (!object.ReferenceEquals(this.Status, null))
            {
                offerTemp.Status = (BasicInfoDetail)this.Status.Clone(sNodeName);
            }
            /*if (!object.ReferenceEquals(this.GovMemberOpinions, null))
            {
                offerTemp.GovMemberOpinions = (GovSessionMemberOpinions)this.GovMemberOpinions.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Commissions, null))
            {
                offerTemp.Commissions = (OfferCommissions)this.Commissions.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Engineerings, null))
            {
                offerTemp.Engineerings = (Sbn.Products.GEP.GEPObject.Engineerings)this.Engineerings.Clone(sNodeName);
            }*/
            if (!object.ReferenceEquals(this.LawDocuments, null))
            {
                offerTemp.LawDocuments = (ExpertLawDocuments)this.LawDocuments.Clone(sNodeName);
            }
            /*if (!object.ReferenceEquals(this.CorrelateOrgans, null))
            {
                offerTemp.CorrelateOrgans = (OfferOrgUnits)this.CorrelateOrgans.Clone(sNodeName);
            }*/
            //if (!object.ReferenceEquals(this.OfferAbstract, null))
            //{
            //    offerTemp.OfferAbstract = (Sbn.Products.GEP.GEPObject.OfferAbstract)this.OfferAbstract.Clone(sNodeName);

            //}
            //if (!object.ReferenceEquals(this.OfferCommuniqueText, null))
            //{
            //    offerTemp.OfferCommuniqueText = (Sbn.Products.GEP.GEPObject.OfferCommuniqueText)this.OfferCommuniqueText.Clone(sNodeName);

            //}

            if (this.OfferAbstract != null)
            {
                offerTemp.OfferAbstract = (string)this.OfferAbstract.Clone();

            }
            if (this.Assessment != null)
            {
                offerTemp.Assessment = (string)this.Assessment.Clone();
            }
            if (this.OfferCommuniqueText != null)
            {
                offerTemp.OfferCommuniqueText = (string)this.OfferCommuniqueText.Clone();

            }
            if (!object.ReferenceEquals(this.Urgency, null))
            {
                offerTemp.Urgency = (BasicInfoDetail)this.Urgency.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OfferLetter, null))
            {
                offerTemp.OfferLetter = (Letter)this.OfferLetter.Clone(sNodeName);
            }

            if (!object.ReferenceEquals(this.CoOffer, null))
            {
                offerTemp.CoOffer = (GEPObject.Offer)this.CoOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Security, null))
            {
                offerTemp.Security = (BasicInfoDetail)this.Security.Clone(sNodeName);
            }
            /*if (!object.ReferenceEquals(this.Complication, null))
            {
                offerTemp.Complication = (BasicInfoDetail)this.Complication.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Importance, null))
            {
                offerTemp.Importance = (BasicInfoDetail)this.Importance.Clone(sNodeName);
            }*/
            if (!object.ReferenceEquals(this.OfferType, null))
            {
                offerTemp.OfferType = (BasicInfoDetail)this.OfferType.Clone(sNodeName);
            }
            /*if (!object.ReferenceEquals(this.StatusInGovOrderOffice, null))
            {
                offerTemp.StatusInGovOrderOffice = (BasicInfoDetail)this.StatusInGovOrderOffice.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Subjects, null))
            {
                offerTemp.Subjects = (OfferSubjects)this.Subjects.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CommissionReports, null))
            {
                offerTemp.CommissionReports = (OfferCommissionReports)this.CommissionReports.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.PreObservation, null))
            {
                offerTemp.PreObservation = (Sbn.Products.GEP.GEPObject.PreObservation)this.PreObservation.Clone(sNodeName);
            }*/
            //if (!object.ReferenceEquals(this.OwnerOrgan, null))
            //{
            //    offerTemp.OwnerOrgan = (OfferOrgUnit)this.OwnerOrgan.Clone(sNodeName);
            //}
            if (!object.ReferenceEquals(this.OwnerOrgan, null))
            {
                offerTemp.OwnerOrgan = (OrgUnit)this.OwnerOrgan.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.ActiveCommission, null))
            {
                offerTemp.ActiveCommission = (OfferCommission)this.ActiveCommission.Clone(sNodeName);
            }
            /*if (!object.ReferenceEquals(this.CommuniqueStatus, null))
            {
                offerTemp.CommuniqueStatus = (BasicInfoDetail)this.CommuniqueStatus.Clone(sNodeName);
            }
            /*if (!object.ReferenceEquals(this.OfferRelations, null))
                offerTemp.OfferRelations = (OfferRelations)this.OfferRelations.Clone(sNodeName);

            offerTemp._IsPublishable = this._IsPublishable;
            if (this._PublishableDate != null) offerTemp._PublishableDate = (string)this._PublishableDate.Clone();

            if (!object.ReferenceEquals(this.WordDoc, null))
                offerTemp.WordDoc = (GeneralDocument)this.WordDoc.Clone(sNodeName);
            */

            if (!object.ReferenceEquals(this.DefinitionWordDoc, null))
                offerTemp.DefinitionWordDoc = (GeneralDocument)this.DefinitionWordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this.UrgencyReasonsWordDoc, null))
                offerTemp.UrgencyReasonsWordDoc = (GeneralDocument)this.UrgencyReasonsWordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this.RelatedLawsWordDoc, null))
                offerTemp.RelatedLawsWordDoc = (GeneralDocument)this.RelatedLawsWordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this.GoalsWordDoc, null))
                offerTemp.GoalsWordDoc = (GeneralDocument)this.GoalsWordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this.OptionsWordDoc, null))
                offerTemp.OptionsWordDoc = (GeneralDocument)this.OptionsWordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this.OptionsEffectsWordDoc, null))
                offerTemp.OptionsEffectsWordDoc = (GeneralDocument)this.OptionsEffectsWordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this.OptionsCompareWordDoc, null))
                offerTemp.OptionsCompareWordDoc = (GeneralDocument)this.OptionsCompareWordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this.LegalAnalysisWordDoc, null))
                offerTemp.LegalAnalysisWordDoc = (GeneralDocument)this.LegalAnalysisWordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ExcutivePlanWordDoc, null))
                offerTemp.ExcutivePlanWordDoc = (GeneralDocument)this.ExcutivePlanWordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this.MonitoringPlanWordDoc, null))
                offerTemp.MonitoringPlanWordDoc = (GeneralDocument)this.MonitoringPlanWordDoc.Clone(sNodeName);

            return offerTemp;
        }

        public override void Initialize()
        {
            base.Initialize();
            //this._OrderInCatalogue = 0;
            //this._OfficialCode = "";
            this._VicePresidentReceiptdate = "";
            this._VicePresidentLetterID = "";
            //this._GovOfficeReceiptDate = "";
            this._RegisterDate = "";
            this._OfferComment = "";
            //this._GovSessionTitle = "";
            //this._OtherLetters = new Letters();
            //this._ApprovalLetters = new Sbn.Products.GEP.GEPObject.ApprovalLetters();
            //this._GovernReports = new GovernmentReports();
            //this._Inquiries = new Sbn.Products.GEP.GEPObject.Inquiries();
            this._Status = new BasicInfoDetail();
            //this._GovMemberOpinions = new GovSessionMemberOpinions();
            //this._Commissions = new OfferCommissions();
            //this._Engineerings = new Sbn.Products.GEP.GEPObject.Engineerings();
            this._LawDocuments = new ExpertLawDocuments();
            //this._CorrelateOrgans = new OfferOrgUnits();
            //this._OfferAbstract = new Sbn.Products.GEP.GEPObject.OfferAbstract();
            //this._OfferCommuniqueText = new Sbn.Products.GEP.GEPObject.OfferCommuniqueText();
            this._OfferAbstract = "";
            this.Assessment = "";
            this._OfferCommuniqueText = "";
            this._Urgency = new BasicInfoDetail();
            this._OfferLetter = new Letter();
            this._CoOffer = new Offer();
            this._Security = new BasicInfoDetail();
            //this._Complication = new BasicInfoDetail();
            //this._Importance = new BasicInfoDetail();
            this._OfferType = new BasicInfoDetail();
            //this._StatusInGovOrderOffice = new BasicInfoDetail();
            //this._Subjects = new OfferSubjects();
            //this._CommissionReports = new OfferCommissionReports();
            //this._PreObservation = new Sbn.Products.GEP.GEPObject.PreObservation();
            //this._OwnerOrgan = new OfferOrgUnit();
            this._OwnerOrgan = new OrgUnit();
            this._ActiveCommission = new OfferCommission();
            //this._CommuniqueStatus = new BasicInfoDetail();
            //this._OfferRelations = new OfferRelations();

            //this._IsPublishable = PublishableState.None;
            //this._PublishableDate = "";
            //this._WordDoc = new GeneralDocument();

            this._DefinitionWordDoc = new GeneralDocument();
            this._UrgencyReasonsWordDoc = new GeneralDocument();
            this._RelatedLawsWordDoc = new GeneralDocument();
            this._GoalsWordDoc = new GeneralDocument();
            this._OptionsWordDoc = new GeneralDocument();
            this._OptionsEffectsWordDoc = new GeneralDocument();
            this._OptionsCompareWordDoc = new GeneralDocument();
            this._LegalAnalysisWordDoc = new GeneralDocument();
            this._ExcutivePlanWordDoc = new GeneralDocument();
            this._MonitoringPlanWordDoc = new GeneralDocument();

        }

        //public override string ToString()
        //{
        //    return this.OfficialCode;
        //}

        [Description("کمیسیون فعال"), DocumentAttributeID("9381"), Browsable(true), RelationTable(""), DisplayName("کمیسیون فعال"), Category(""), IsRelational("False"), AttributeType("OfferCommission"), IsMiddleTableExist("False")]
        public OfferCommission ActiveCommission
        {
            get
            {
                return this._ActiveCommission;
            }
            set
            {
                this._ActiveCommission = value;
            }
        }

        /*[IsMiddleTableExist("True"),
        RelationTable("AppLetts"),
        Description("نتایج نهایی"),
        DisplayName("نتایج نهایی"),
        Category(""),
        DocumentAttributeID("9035"),
        Browsable(true),
        IsRelational("True"),
        AttributeType("ApprovalLetters")]
        public Sbn.Products.GEP.GEPObject.ApprovalLetters ApprovalLetters
        {
            get
            {
                return this._ApprovalLetters;
            }
            set
            {
                this._ApprovalLetters = value;
            }
        }*/

        public static string at_ActiveCommission_AdminExpertFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ActiveCommission.AdminExpertFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ActiveCommission.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_CommissionResultsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ActiveCommission.CommissionResultsFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ActiveCommission.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ActiveCommission.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_GovReportsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ActiveCommission.GovReportsFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_OfferEngineeringsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ActiveCommission.OfferEngineeringsFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_SessionsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ActiveCommission.SessionsFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_StatusFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ActiveCommission.StatusFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommissionID
        {
            get
            {
                return "OfferTemp.ActiveCommissionID";
            }
        }

        /*public static string at_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_ApprovalLettersID
        {
            get
            {
                return "OfferTemp.ApprovalLettersID";
            }
        }

        public static string at_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CommissionReportsID
        {
            get
            {
                return "OfferTemp.CommissionReportsID";
            }
        }

        public static string at_CommissionsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CommissionsID
        {
            get
            {
                return "OfferTemp.CommissionsID";
            }
        }

        public static string at_CommuniqueStatus_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.CommuniqueStatus.ParentFirstLevelAttributes";
            }
        }

        public static string at_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CommuniqueStatusID
        {
            get
            {
                return "OfferTemp.CommuniqueStatusID";
            }
        }

        public static string at_Complication_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.Complication.ParentFirstLevelAttributes";
            }
        }

        public static string at_ComplicationFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_ComplicationID
        {
            get
            {
                return "OfferTemp.ComplicationID";
            }
        }

        public static string at_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgansID
        {
            get
            {
                return "OfferTemp.CorrelateOrgansID";
            }
        }

        public static string at_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_EngineeringsID
        {
            get
            {
                return "OfferTemp.EngineeringsID";
            }
        }

        public static string at_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_GovernReportsID
        {
            get
            {
                return "OfferTemp.GovernReportsID";
            }
        }

        public static string at_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_GovMemberOpinionsID
        {
            get
            {
                return "OfferTemp.GovMemberOpinionsID";
            }
        }

        public static string at_GovOfficeReceiptDate
        {
            get
            {
                return "OfferTemp.GovOfficeReceiptDate";
            }
        }

        public static string at_GovSessionTitle
        {
            get
            {
                return "OfferTemp.GovSessionTitle";
            }
        }

        public static string at_Importance_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.Importance.ParentFirstLevelAttributes";
            }
        }

        public static string at_ImportanceFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_ImportanceID
        {
            get
            {
                return "OfferTemp.ImportanceID";
            }
        }

        public static string at_InquiriesFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_InquiriesID
        {
            get
            {
                return "OfferTemp.InquiriesID";
            }
        }*/

        public static string at_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_LawDocumentsID
        {
            get
            {
                return "OfferTemp.LawDocumentsID";
            }
        }

        //public static string at_OfferAbstract_CorrelateOfferFirstLevelAttributes
        //{
        //    get
        //    {
        //        return "OfferTemp.OfferAbstract.CorrelateOfferFirstLevelAttributes";
        //    }
        //}

        //public static string at_OfferAbstractFirstLevelAttributes
        //{
        //    get
        //    {
        //        return "OfferTemp.OfferAbstractFirstLevelAttributes";
        //    }
        //}

        //public static string at_OfferAbstractID
        //{
        //    get
        //    {
        //        return "OfferTemp.OfferAbstractID";
        //    }
        //}

        public static string at_OfferAbstract
        {
            get
            {
                return "OfferTemp.OfferAbstract";
            }
        }
        public static string at_Assessment
        {
            get
            {
                return "OfferTemp.Assessment";
            }
        }
        public static string at_OfferComment
        {
            get
            {
                return "OfferTemp.OfferComment";
            }
        }

        /*public static string at_WordDocID
        {
            get
            {
                return "OfferTemp.WordDocID";
            }
        }
        public static string at_WordDocTitle
        {
            get
            {
                return "OfferTemp.WordDoc.Title";
            }
        }
        public static string at_WordDocFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.WordDocFirstLevelAttributes";
            }
        }*/


        public static string at_DefinitionWordDocID
        {
            get
            {
                return "OfferTemp.DefinitionWordDocID";
            }
        }
        public static string at_DefinitionWordDocTitle
        {
            get
            {
                return "OfferTemp.DefinitionWordDoc.Title";
            }
        }
        public static string at_DefinitionWordDocFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.DefinitionWordDocFirstLevelAttributes";
            }
        }

        public static string at_UrgencyReasonsWordDocID
        {
            get
            {
                return "OfferTemp.UrgencyReasonsWordDocID";
            }
        }
        public static string at_UrgencyReasonsWordDocTitle
        {
            get
            {
                return "OfferTemp.UrgencyReasonsWordDoc.Title";
            }
        }
        public static string at_UrgencyReasonsWordDocFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.UrgencyReasonsWordDocFirstLevelAttributes";
            }
        }

        public static string at_RelatedLawsWordDocID
        {
            get
            {
                return "OfferTemp.RelatedLawsWordDocID";
            }
        }
        public static string at_RelatedLawsWordDocTitle
        {
            get
            {
                return "OfferTemp.RelatedLawsWordDoc.Title";
            }
        }
        public static string at_RelatedLawsWordDocFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.RelatedLawsWordDocFirstLevelAttributes";
            }
        }

        public static string at_GoalsWordDocID
        {
            get
            {
                return "OfferTemp.GoalsWordDocID";
            }
        }
        public static string at_GoalsWordDocTitle
        {
            get
            {
                return "OfferTemp.GoalsWordDoc.Title";
            }
        }
        public static string at_GoalsWordDocFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.GoalsWordDocFirstLevelAttributes";
            }
        }

        public static string at_OptionsWordDocID
        {
            get
            {
                return "OfferTemp.OptionsWordDocID";
            }
        }
        public static string at_OptionsWordDocTitle
        {
            get
            {
                return "OfferTemp.OptionsWordDoc.Title";
            }
        }
        public static string at_OptionsWordDocFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OptionsWordDocFirstLevelAttributes";
            }
        }

        public static string at_OptionsEffectsWordDocID
        {
            get
            {
                return "OfferTemp.OptionsEffectsWordDocID";
            }
        }
        public static string at_OptionsEffectsWordDocTitle
        {
            get
            {
                return "OfferTemp.OptionsEffectsWordDoc.Title";
            }
        }
        public static string at_OptionsEffectsWordDocFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OptionsEffectsWordDocFirstLevelAttributes";
            }
        }

        public static string at_OptionsCompareWordDocID
        {
            get
            {
                return "OfferTemp.OptionsCompareWordDocID";
            }
        }
        public static string at_OptionsCompareWordDocTitle
        {
            get
            {
                return "OfferTemp.OptionsCompareWordDoc.Title";
            }
        }
        public static string at_OptionsCompareWordDocFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OptionsCompareWordDocFirstLevelAttributes";
            }
        }

        public static string at_LegalAnalysisWordDocID
        {
            get
            {
                return "OfferTemp.LegalAnalysisWordDocID";
            }
        }
        public static string at_LegalAnalysisWordDocTitle
        {
            get
            {
                return "OfferTemp.LegalAnalysisWordDoc.Title";
            }
        }
        public static string at_LegalAnalysisWordDocFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.LegalAnalysisWordDocFirstLevelAttributes";
            }
        }

        public static string at_ExcutivePlanWordDocID
        {
            get
            {
                return "OfferTemp.ExcutivePlanWordDocID";
            }
        }
        public static string at_ExcutivePlanWordDocTitle
        {
            get
            {
                return "OfferTemp.ExcutivePlanWordDoc.Title";
            }
        }
        public static string at_ExcutivePlanWordDocFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ExcutivePlanWordDocFirstLevelAttributes";
            }
        }

        public static string at_MonitoringPlanWordDocID
        {
            get
            {
                return "OfferTemp.MonitoringPlanWordDocID";
            }
        }
        public static string at_MonitoringPlanWordDocTitle
        {
            get
            {
                return "OfferTemp.MonitoringPlanWordDoc.Title";
            }
        }
        public static string at_MonitoringPlanWordDocFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.MonitoringPlanWordDocFirstLevelAttributes";
            }
        }



        //public static string at_OfferCommuniqueText_CorrelateOfferFirstLevelAttributes
        //{
        //    get
        //    {
        //        return "OfferTemp.OfferCommuniqueText.CorrelateOfferFirstLevelAttributes";
        //    }
        //}

        //public static string at_OfferCommuniqueTextFirstLevelAttributes
        //{
        //    get
        //    {
        //        return "OfferTemp.OfferCommuniqueTextFirstLevelAttributes";
        //    }
        //}

        //public static string at_OfferCommuniqueTextID
        //{
        //    get
        //    {
        //        return "OfferTemp.OfferCommuniqueTextID";
        //    }
        //}
        public static string at_OfferCommuniqueText
        {
            get
            {
                return "OfferTemp.OfferCommuniqueText";
            }
        }

        public static string at_OfferLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_OfferLetterID
        {
            get
            {
                return "OfferTemp.OfferLetterID";
            }
        }

        public static string at_CoOfferFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferFirstLevelAttributes";
            }
        }

        public static string at_CoOfferID
        {
            get
            {
                return "OfferTemp.CoOfferID";
            }
        }

        /*public static string at_OfferRelations
        {
            get
            {
                return "OfferTemp.OfferRelations";
            }
        }*/

        public static string at_OfferType_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferType.ParentFirstLevelAttributes";
            }
        }

        public static string at_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_OfferTypeID
        {
            get
            {
                return "OfferTemp.OfferTypeID";
            }
        }

        //public static string at_OfficialCode
        //{
        //    get
        //    {
        //        return "OfferTemp.OfficialCode";
        //    }
        //}

        /*public static string at_OrderInCatalogue
        {
            get
            {
                return "OfferTemp.OrderInCatalogue";
            }
        }

        public static string at_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_OtherLettersID
        {
            get
            {
                return "OfferTemp.OtherLettersID";
            }
        }*/

        //public static string at_OwnerOrgan_CorrelateOfferFirstLevelAttributes
        //{
        //    get
        //    {
        //        return "OfferTemp.OwnerOrgan.CorrelateOfferFirstLevelAttributes";
        //    }
        //}

        //public static string at_OwnerOrgan_CorrelateOrgUnitFirstLevelAttributes
        //{
        //    get
        //    {
        //        return "OfferTemp.OwnerOrgan.CorrelateOrgUnitFirstLevelAttributes";
        //    }
        //}

        public static string at_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_OwnerOrganID
        {
            get
            {
                return "OfferTemp.OwnerOrganID";
            }
        }

        /*public static string at_PreObservation_CoCommissionExpertFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.PreObservation.CoCommissionExpertFirstLevelAttributes";
            }
        }

        public static string at_PreObservation_CoOfferFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.PreObservation.CoOfferFirstLevelAttributes";
            }
        }

        public static string at_PreObservation_CoWordDocumentFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.PreObservation.CoWordDocumentFirstLevelAttributes";
            }
        }

        public static string at_PreObservation_PicsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.PreObservation.PicsFirstLevelAttributes";
            }
        }

        public static string at_PreObservationFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_PreObservationID
        {
            get
            {
                return "OfferTemp.PreObservationID";
            }
        }*/

        public static string at_RegisterDate
        {
            get
            {
                return "OfferTemp.RegisterDate";
            }
        }

        public static string at_Security_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.Security.ParentFirstLevelAttributes";
            }
        }

        public static string at_SecurityFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.SecurityFirstLevelAttributes";
            }
        }

        public static string at_SecurityID
        {
            get
            {
                return "OfferTemp.SecurityID";
            }
        }

        public static string at_Status_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.Status.ParentFirstLevelAttributes";
            }
        }

        public static string at_StatusFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.StatusFirstLevelAttributes";
            }
        }

        public static string at_StatusID
        {
            get
            {
                return "OfferTemp.StatusID";
            }
        }

        /*public static string at_StatusInGovOrderOffice_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.StatusInGovOrderOffice.ParentFirstLevelAttributes";
            }
        }

        public static string at_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_StatusInGovOrderOfficeID
        {
            get
            {
                return "OfferTemp.StatusInGovOrderOfficeID";
            }
        }

        public static string at_SubjectsFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_SubjectsID
        {
            get
            {
                return "OfferTemp.SubjectsID";
            }
        }*/

        public static string at_Urgency_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.Urgency.ParentFirstLevelAttributes";
            }
        }

        public static string at_UrgencyFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_UrgencyID
        {
            get
            {
                return "OfferTemp.UrgencyID";
            }
        }

        public static string at_VicePresidentLetterID
        {
            get
            {
                return "OfferTemp.VicePresidentLetterID";
            }
        }

        public static string at_VicePresidentReceiptdate
        {
            get
            {
                return "OfferTemp.VicePresidentReceiptdate";
            }
        }

        /*public static string at_ChildOffersID
        {
            get
            {
                return "OfferTemp.ChildOffersID";
            }
        }

        public static string at_ChildOffersFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ChildOffersFirstLevelAttributes";
            }
        }

        public static string at_ParentOffer_ChildOffersFirstLevelAttributes
        {
            get
            {
                return "OfferTemp.ParentOffer.ChildOffersFirstLevelAttributes";
            }
        }

        public static string at_IsPublishable
        {
            get
            {
                return "OfferTemp.IsPublishable";
            }
        }

        public static string at_PublishableDate
        {
            get
            {
                return "OfferTemp.PublishableDate";
            }
        }


        [IsRelational("True"), RelationTable(""), Description(""), DisplayName(""), Category(""), DocumentAttributeID("9337"), Browsable(true), AttributeType("OfferCommissionReports"), IsMiddleTableExist("True")]
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

        [Description("کمیسیونهای مرتبط"), RelationTable(""), DisplayName("کمیسیونهای مرتبط"), Category(""), DocumentAttributeID("9074"), Browsable(true), IsRelational("True"), AttributeType("OfferCommissions"), IsMiddleTableExist("True")]
        public OfferCommissions Commissions
        {
            get
            {
                return this._Commissions;
            }
            set
            {
                this._Commissions = value;
            }
        }

        [RelationTable(""), IsMiddleTableExist("False"), AttributeType("BasicInfoDetail"), Description("آخرین وضعیت در واحد ابلاغ"), DisplayName("وضعیت ابلاغ"), Category(""), DocumentAttributeID("9394"), Browsable(true), IsRelational("False")]
        public BasicInfoDetail CommuniqueStatus
        {
            get
            {
                return this._CommuniqueStatus;
            }
            set
            {
                this._CommuniqueStatus = value;
            }
        }

        [Category(""), RelationTable(""), Description("پیچیدگی پیشنهاد"), DisplayName("پیجیدگی پیشنهاد"), DocumentAttributeID("9283"), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False")]
        public BasicInfoDetail Complication
        {
            get
            {
                return this._Complication;
            }
            set
            {
                this._Complication = value;
            }
        }

        [DocumentAttributeID("9022"), Description("دستگاههای مرتبط"), DisplayName("دستگاههای مرتبط"), Category(""), Browsable(true), IsRelational("True"), AttributeType("OfferOrgUnits"), IsMiddleTableExist("True"), RelationTable("")]
        public OfferOrgUnits CorrelateOrgans
        {
            get
            {
                return this._CorrelateOrgans;
            }
            set
            {
                this._CorrelateOrgans = value;
            }
        }

        [Browsable(true), Description("کارشناسی ها"), DisplayName("کارشناسی ها"), Category(""), DocumentAttributeID("9101"), IsRelational("True"), AttributeType("Engineerings"), IsMiddleTableExist("True"), RelationTable("")]
        public Sbn.Products.GEP.GEPObject.Engineerings Engineerings
        {
            get
            {
                return this._Engineerings;
            }
            set
            {
                this._Engineerings = value;
            }
        }

        [RelationTable(""), Description("گزارشهای دولت تهیه شده توسط کارشناسان"), DisplayName("گزارشهای دولت"), Category(""), DocumentAttributeID("9027"), Browsable(true), IsRelational("True"), AttributeType("GovernmentReports"), IsMiddleTableExist("True")]
        public GovernmentReports GovernReports
        {
            get
            {
                return this._GovernReports;
            }
            set
            {
                this._GovernReports = value;
            }
        }

        [Browsable(true), Description(""), DisplayName(""), Category(""), DocumentAttributeID("9053"), IsRelational("True"), AttributeType("GovSessionMemberOpinions"), IsMiddleTableExist("True"), RelationTable("")]
        public GovSessionMemberOpinions GovMemberOpinions
        {
            get
            {
                return this._GovMemberOpinions;
            }
            set
            {
                this._GovMemberOpinions = value;
            }
        }

        [Browsable(true), DisplayName("تاریخ دریافت دفتر دولت"), AttributeType("DateString"), Description("تاریخ دریافت دفتر دولت"), Category(""), DocumentAttributeID("9011"), IsRelational("false")]
        public string GovOfficeReceiptDate
        {
            get
            {
                return this._GovOfficeReceiptDate;
            }
            set
            {
                this._GovOfficeReceiptDate = value;
            }
        }

        [DisplayName("عنوان در جلسه دولت"), IsRelational("false"), Browsable(true), Description("عنوان ارائه شده در جلسه دولت"), Category(""), DocumentAttributeID("9267"), AttributeType("String")]
        public string GovSessionTitle
        {
            get
            {
                return this._GovSessionTitle;
            }
            set
            {
                this._GovSessionTitle = value;
            }
        }

        [RelationTable(""), Description("درجه اهمیت پیشنهاد"), DisplayName("درجه اهمیت"), Category(""), DocumentAttributeID("9284"), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False")]
        public BasicInfoDetail Importance
        {
            get
            {
                return this._Importance;
            }
            set
            {
                this._Importance = value;
            }
        }

        [Browsable(true), RelationTable(""), Description("استعلامها"), DisplayName("استعلامها"), Category(""), DocumentAttributeID("9064"), IsRelational("True"), AttributeType("Inquiries"), IsMiddleTableExist("True")]
        public Sbn.Products.GEP.GEPObject.Inquiries Inquiries
        {
            get
            {
                return this._Inquiries;
            }
            set
            {
                this._Inquiries = value;
            }
        }*/

        [RelationTable(""), Description("مستندا قانونی"), DisplayName("مستندات قانونی"), Category(""), DocumentAttributeID("9402"), Browsable(true), IsRelational("True"), AttributeType("ExpertLawDocuments"), IsMiddleTableExist("True")]
        public ExpertLawDocuments LawDocuments
        {
            get
            {
                return this._LawDocuments;
            }
            set
            {
                this._LawDocuments = value;
            }
        }

        //[Description("خلاصه پیشنهاد"), RelationTable(""), DisplayName("خلاصه پیشنهاد"), Category(""), DocumentAttributeID("9278"), Browsable(true), IsRelational("False"), AttributeType("OfferAbstract"), IsMiddleTableExist("False")]
        //public Sbn.Products.GEP.GEPObject.OfferAbstract OfferAbstract
        //{
        //    get
        //    {
        //        return this._OfferAbstract;
        //    }
        //    set
        //    {
        //        this._OfferAbstract = value;
        //    }
        //}

        [Description("خلاصه پیشنهاد"), RelationTable(""), DisplayName("خلاصه پیشنهاد"), Category(""), DocumentAttributeID(""), Browsable(true), IsRelational("False"), AttributeType("LongText"), IsMiddleTableExist("False")]
        public string OfferAbstract
        {
            get
            {
                return this._OfferAbstract;
            }
            set
            {
                this._OfferAbstract = value;
            }
        }
        [Description("ارزیابی درخواست پیشنهاد"), RelationTable(""), DisplayName("ارزیابی درخواست پیشنهاد"), Category(""), DocumentAttributeID(""), Browsable(true), IsRelational("False"), AttributeType("LongText"), IsMiddleTableExist("False")]
        public string Assessment
        {
            get
            {
                return this._Assessment;
            }
            set
            {
                this._Assessment = value;
            }
        }

        [Description("توضیحات"), Browsable(true), DisplayName("توضیحات"), Category(""), DocumentAttributeID("9263"), IsRelational("false"), AttributeType("LongText")]
        public string OfferComment
        {
            get
            {
                return this._OfferComment;
            }
            set
            {
                this._OfferComment = value;
            }
        }

        ///// <summary>
        ///// مستند تایپی
        ///// </summary>
        //[Description("مستند تایپی")]
        //[DisplayName("مستند تایپی")]
        //[Category("")]
        //[DocumentAttributeID("")]
        //[Browsable(true)]
        //[IsRelationalAttribute("False")]
        //[AttributeType("GeneralDocument")]
        //[IsMiddleTableExist("False")]
        //[RelationTable("")]
        //public GeneralDocument WordDoc
        //{
        //    get { return _WordDoc; }
        //    set { _WordDoc = value; }
        //}

        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("مستند تایپی")]
        [DisplayName("مستند تایپی")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("GeneralDocument")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public GeneralDocument MonitoringPlanWordDoc
        {
            get { return _MonitoringPlanWordDoc; }
            set { _MonitoringPlanWordDoc = value; }
        }
        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("مستند تایپی")]
        [DisplayName("مستند تایپی")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("GeneralDocument")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public GeneralDocument ExcutivePlanWordDoc
        {
            get { return _ExcutivePlanWordDoc; }
            set { _ExcutivePlanWordDoc = value; }
        }
        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("مستند تایپی")]
        [DisplayName("مستند تایپی")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("GeneralDocument")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public GeneralDocument LegalAnalysisWordDoc
        {
            get { return _LegalAnalysisWordDoc; }
            set { _LegalAnalysisWordDoc = value; }
        }
        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("مستند تایپی")]
        [DisplayName("مستند تایپی")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("GeneralDocument")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public GeneralDocument OptionsCompareWordDoc
        {
            get { return _OptionsCompareWordDoc; }
            set { _OptionsCompareWordDoc = value; }
        }
        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("مستند تایپی")]
        [DisplayName("مستند تایپی")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("GeneralDocument")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public GeneralDocument OptionsEffectsWordDoc
        {
            get { return _OptionsEffectsWordDoc; }
            set { _OptionsEffectsWordDoc = value; }
        }
        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("مستند تایپی")]
        [DisplayName("مستند تایپی")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("GeneralDocument")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public GeneralDocument OptionsWordDoc
        {
            get { return _OptionsWordDoc; }
            set { _OptionsWordDoc = value; }
        }
        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("مستند تایپی")]
        [DisplayName("مستند تایپی")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("GeneralDocument")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public GeneralDocument GoalsWordDoc
        {
            get { return _GoalsWordDoc; }
            set { _GoalsWordDoc = value; }
        }
        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("مستند تایپی")]
        [DisplayName("مستند تایپی")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("GeneralDocument")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public GeneralDocument RelatedLawsWordDoc
        {
            get { return _RelatedLawsWordDoc; }
            set { _RelatedLawsWordDoc = value; }
        }
        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("مستند تایپی")]
        [DisplayName("مستند تایپی")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("GeneralDocument")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public GeneralDocument UrgencyReasonsWordDoc
        {
            get { return _UrgencyReasonsWordDoc; }
            set { _UrgencyReasonsWordDoc = value; }
        }
        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("مستند تایپی")]
        [DisplayName("مستند تایپی")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("GeneralDocument")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public GeneralDocument DefinitionWordDoc
        {
            get { return _DefinitionWordDoc; }
            set { _DefinitionWordDoc = value; }
        }

        //[IsMiddleTableExist("False"), RelationTable(""), Description("متن ابلاغیه پیشنهادی دستگاه"), DisplayName("متن ابلاغیه پیشنهادی دستگاه"), Category(""), DocumentAttributeID("9279"), Browsable(true), IsRelational("False"), AttributeType("OfferCommuniqueText")]
        //public Sbn.Products.GEP.GEPObject.OfferCommuniqueText OfferCommuniqueText
        //{
        //    get
        //    {
        //        return this._OfferCommuniqueText;
        //    }
        //    set
        //    {
        //        this._OfferCommuniqueText = value;
        //    }
        //}

        [IsMiddleTableExist("False"), RelationTable(""), Description("متن ابلاغیه پیشنهادی دستگاه"), DisplayName("متن ابلاغیه پیشنهادی دستگاه"), Category(""), DocumentAttributeID(""), Browsable(true), IsRelational("False"), AttributeType("LongText")]
        public string OfferCommuniqueText
        {
            get
            {
                return this._OfferCommuniqueText;
            }
            set
            {
                this._OfferCommuniqueText = value;
            }
        }

        [DocumentAttributeID("9021"), Description("نامه پیشنهاد"), DisplayName("نامه پیشنهاد"), Category(""), Browsable(true), IsRelational("False"), AttributeType("Letter"), IsMiddleTableExist("False"), RelationTable("")]
        public Letter OfferLetter
        {
            get
            {
                return this._OfferLetter;
            }
            set
            {
                this._OfferLetter = value;
            }
        }

        [DocumentAttributeID(""), Description("پیشنهاد"), DisplayName("پیشنهاد"), Category(""), Browsable(true), IsRelational("False"), AttributeType("Offer"), IsMiddleTableExist("False"), RelationTable("")]
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

        [Category(""), RelationTable(""), Description("نوع پیشنهاد"), DisplayName("نوع پیشنهاد"), DocumentAttributeID("9395"), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False")]
        public BasicInfoDetail OfferType
        {
            get
            {
                return this._OfferType;
            }
            set
            {
                this._OfferType = value;
            }
        }

        //[Category(""), Description("کد پیشنهاد"), Browsable(true), AttributeType("String"), DocumentAttributeID("9008"), DisplayName("کد پیشنهاد"), IsRelational("false")]
        //public string OfficialCode
        //{
        //    get
        //    {
        //        return this._OfficialCode;
        //    }
        //    set
        //    {
        //        this._OfficialCode = value;
        //    }
        //}

        /*[Description("ردیف در فهرست"), Browsable(true), DisplayName("ردیف در فهرست"), Category(""), DocumentAttributeID("9019"), IsRelational("false"), AttributeType("Int")]
        public int OrderInCatalogue
        {
            get
            {
                return this._OrderInCatalogue;
            }
            set
            {
                this._OrderInCatalogue = value;
            }
        }

        [AttributeType("Letters"), IsRelational("False"), RelationTable("OFFER_OTHERLETTERS_M"), IsMiddleTableExist("False"), Description("نامه های مرتبط"), DisplayName("نامه های مرتبط"), Category(""), DocumentAttributeID("9261"), Browsable(true)]
        public Letters OtherLetters
        {
            get
            {
                return this._OtherLetters;
            }
            set
            {
                this._OtherLetters = value;
            }
        }*/

        //[Description("پیشنهاد دهنده"), Browsable(true), IsRelational("False"), RelationTable(""), DisplayName("پیشنهاد دهنده"), Category(""), DocumentAttributeID("9380"), AttributeType("OfferOrgUnit"), IsMiddleTableExist("False")]
        //public OfferOrgUnit OwnerOrgan
        //{
        //    get
        //    {
        //        return this._OwnerOrgan;
        //    }
        //    set
        //    {
        //        this._OwnerOrgan = value;
        //    }
        //}

        [Description("پیشنهاد دهنده"), Browsable(true), IsRelational("False"), RelationTable(""), DisplayName("پیشنهاد دهنده"), Category(""), DocumentAttributeID(""), AttributeType("OrgUnit"), IsMiddleTableExist("False")]
        public OrgUnit OwnerOrgan
        {
            get
            {
                return this._OwnerOrgan;
            }
            set
            {
                this._OwnerOrgan = value;
            }
        }

        /*[Browsable(true), RelationTable(""), Description("ارزیابی مقدماتی"), DisplayName("ارزیابی مقدماتی"), Category(""), DocumentAttributeID("9408"), IsRelational("False"), AttributeType("PreObservation"), IsMiddleTableExist("False")]
        public Sbn.Products.GEP.GEPObject.PreObservation PreObservation
        {
            get
            {
                return this._PreObservation;
            }
            set
            {
                this._PreObservation = value;
            }
        }*/

        [Browsable(true), Description("تاریخ ثبت"), Category(""), DisplayName("تاریخ ثبت"), AttributeType("DateString"), DocumentAttributeID("9212"), IsRelational("false")]
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

        [Description("امنیت"), RelationTable(""), DisplayName("امنیت"), Category(""), DocumentAttributeID("9270"), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False")]
        public BasicInfoDetail Security
        {
            get
            {
                return this._Security;
            }
            set
            {
                this._Security = value;
            }
        }

        [DocumentAttributeID("9030"), RelationTable(""), IsMiddleTableExist("False"), Description("آخرین وضعیت"), DisplayName("آخرین وضعیت"), Category(""), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail")]
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

        /*[Category(""), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable(""), Description("وضعیت پیشنهاد در امور دولت"), DisplayName("وضعیت پیشنهاد در امور دولت"), DocumentAttributeID("9396"), Browsable(true), IsRelational("False")]
        public BasicInfoDetail StatusInGovOrderOffice
        {
            get
            {
                return this._StatusInGovOrderOffice;
            }
            set
            {
                this._StatusInGovOrderOffice = value;
            }
        }

        [RelationTable(""), Description("موضوعات"), DisplayName("موضوعات"), Category(""), DocumentAttributeID("9377"), Browsable(true), IsRelational("True"), AttributeType("OfferSubjects"), IsMiddleTableExist("True")]
        public OfferSubjects Subjects
        {
            get
            {
                return this._Subjects;
            }
            set
            {
                this._Subjects = value;
            }
        }*/

        [RelationTable(""), Description("فوریت پیشنهاد"), DisplayName("فوریت"), Category(""), DocumentAttributeID("9287"), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False")]
        public BasicInfoDetail Urgency
        {
            get
            {
                return this._Urgency;
            }
            set
            {
                this._Urgency = value;
            }
        }

        [DisplayName("شماره نامه دفتر معاون اول"), DocumentAttributeID("9010"), AttributeType("String"), Category(""), IsRelational("false"), Browsable(true), Description("شماره نامه معاون اول")]
        public string VicePresidentLetterID
        {
            get
            {
                return this._VicePresidentLetterID;
            }
            set
            {
                this._VicePresidentLetterID = value;
            }
        }

        [IsRelational("false"), AttributeType("DateString"), Browsable(true), DisplayName("تاریخ دریافت معاون اول"), Category(""), DocumentAttributeID("9009"), Description("تاریخ دریافت معاون اول")]
        public string VicePresidentReceiptdate
        {
            get
            {
                return this._VicePresidentReceiptdate;
            }
            set
            {
                this._VicePresidentReceiptdate = value;
            }
        }

        /*private OfferRelations _OfferRelations;
        /// <summary>
        /// ارتباطات
        /// </summary>
        [Description("ارتباطات")]
        [DisplayName("ارتباطات")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("OfferRelations")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public OfferRelations OfferRelations
        {
            get { return _OfferRelations; }
            set { _OfferRelations = value; }
        }

        [RelationTable(""), Description("وضعیت امکان انتشار پرونده"), DisplayName("وضعیت انتشار"), Category(""), DocumentAttributeID(""), Browsable(true), IsRelational("False"), AttributeType("PublishableState"), IsMiddleTableExist("False")]
        public PublishableState IsPublishable
        {
            get
            {
                return this._IsPublishable;
            }
            set
            {
                this._IsPublishable = value;
            }
        }


        /// <summary>
        /// تاریخ اعلام انتشار پرونده
        /// </summary>
        [Description("تاریخ اعلام انتشار پرونده")]
        [DisplayName("تاریخ اعلام انتشار پرونده")]
        [Category("")]
        [DocumentAttributeID("")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string PublishableDate
        {
            get { return _PublishableDate; }
            set { _PublishableDate = value; }
        }*/

    }
}
