namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    public enum PublishableState
    {
        None = 999,
        Unknown = 0,
        Confirmed = 1,
        NotConfirmed = 2
    }

    [Serializable, Description("پیشنهاد"), SystemName("GEP"), DisplayName("پیشنهاد"), ObjectCode("9048"), ItemsType("Sbn.Products.GEP.GEPObject.Offers")]
    public class Offer : SbnObject
    {
        private OfferCommission _ActiveCommission;
        private Sbn.Products.GEP.GEPObject.ApprovalLetters _ApprovalLetters;
        private OfferCommissionReports _CommissionReports;
        private OfferCommissions _Commissions;
        private BasicInfoDetail _CommuniqueStatus;
        private BasicInfoDetail _Complication;
        private OfferOrgUnits _CorrelateOrgans;
        private Sbn.Products.GEP.GEPObject.Engineerings _Engineerings;
        private GovernmentReports _GovernReports;
        private GovSessionMemberOpinions _GovMemberOpinions;
        private string _GovOfficeReceiptDate;
        private string _GovSessionTitle;
        private BasicInfoDetail _Importance;
        private Sbn.Products.GEP.GEPObject.Inquiries _Inquiries;
        private ExpertLawDocuments _LawDocuments;
        private Sbn.Products.GEP.GEPObject.OfferAbstract _OfferAbstract;
        private string _OfferComment;
        private Sbn.Products.GEP.GEPObject.OfferCommuniqueText _OfferCommuniqueText;
        private Letter _OfferLetter;
        private BasicInfoDetail _OfferType;
        private string _OfficialCode;
        private int _OrderInCatalogue;
        private Letters _OtherLetters;
        private OfferOrgUnit _OwnerOrgan;
        private Sbn.Products.GEP.GEPObject.PreObservation _PreObservation;
        private string _RegisterDate;
        private BasicInfoDetail _Security;
        private BasicInfoDetail _Status;
        private BasicInfoDetail _StatusInGovOrderOffice;
        private OfferSubjects _Subjects;
        private BasicInfoDetail _Urgency;
        private string _VicePresidentLetterID;
        private string _VicePresidentReceiptdate;

        private PublishableState _IsPublishable = PublishableState.None;
        private string _PublishableDate;

        private GeneralDocument _WordDoc;

        private string _TitleBackColor;
        private string _TitleForeColor;
        public string TitleBackColor
        {
            get
            {
                return _TitleBackColor;
            }

            set
            {
                _TitleBackColor = value;
            }
        }


        public string TitleForeColor
        {
            get
            {
                return _TitleForeColor;
            }

            set
            {
                _TitleForeColor = value;
            }
        }
        public Offer()
        {
        }

        public Offer(SbnObject InitialObject)
            : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            Offer offer = new Offer
            {
                ID = base.ID,
                OrderInCatalogue = this._OrderInCatalogue,
                OfficialCode = this._OfficialCode
            };
            if (this._VicePresidentReceiptdate != null)
            {
                offer.VicePresidentReceiptdate = (string)this._VicePresidentReceiptdate.Clone();
            }
            offer.VicePresidentLetterID = this._VicePresidentLetterID;
            if (this._GovOfficeReceiptDate != null)
            {
                offer.GovOfficeReceiptDate = (string)this._GovOfficeReceiptDate.Clone();
            }
            if (this._RegisterDate != null)
            {
                offer.RegisterDate = (string)this._RegisterDate.Clone();
            }
            if (this._OfferComment != null)
            {
                offer.OfferComment = (string)this._OfferComment.Clone();
            }
            offer.GovSessionTitle = this._GovSessionTitle;
            if (!object.ReferenceEquals(this.OtherLetters, null))
            {
                offer.OtherLetters = (Letters)this.OtherLetters.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.ApprovalLetters, null))
            {
                offer.ApprovalLetters = (Sbn.Products.GEP.GEPObject.ApprovalLetters)this.ApprovalLetters.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.GovernReports, null))
            {
                offer.GovernReports = (GovernmentReports)this.GovernReports.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Inquiries, null))
            {
                offer.Inquiries = (Sbn.Products.GEP.GEPObject.Inquiries)this.Inquiries.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Status, null))
            {
                offer.Status = (BasicInfoDetail)this.Status.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.GovMemberOpinions, null))
            {
                offer.GovMemberOpinions = (GovSessionMemberOpinions)this.GovMemberOpinions.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Commissions, null))
            {
                offer.Commissions = (OfferCommissions)this.Commissions.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Engineerings, null))
            {
                offer.Engineerings = (Sbn.Products.GEP.GEPObject.Engineerings)this.Engineerings.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.LawDocuments, null))
            {
                offer.LawDocuments = (ExpertLawDocuments)this.LawDocuments.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOrgans, null))
            {
                offer.CorrelateOrgans = (OfferOrgUnits)this.CorrelateOrgans.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OfferAbstract, null))
            {
                offer.OfferAbstract = (Sbn.Products.GEP.GEPObject.OfferAbstract)this.OfferAbstract.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OfferCommuniqueText, null))
            {
                offer.OfferCommuniqueText = (Sbn.Products.GEP.GEPObject.OfferCommuniqueText)this.OfferCommuniqueText.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Urgency, null))
            {
                offer.Urgency = (BasicInfoDetail)this.Urgency.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OfferLetter, null))
            {
                offer.OfferLetter = (Letter)this.OfferLetter.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Security, null))
            {
                offer.Security = (BasicInfoDetail)this.Security.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Complication, null))
            {
                offer.Complication = (BasicInfoDetail)this.Complication.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Importance, null))
            {
                offer.Importance = (BasicInfoDetail)this.Importance.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OfferType, null))
            {
                offer.OfferType = (BasicInfoDetail)this.OfferType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.StatusInGovOrderOffice, null))
            {
                offer.StatusInGovOrderOffice = (BasicInfoDetail)this.StatusInGovOrderOffice.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Subjects, null))
            {
                offer.Subjects = (OfferSubjects)this.Subjects.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CommissionReports, null))
            {
                offer.CommissionReports = (OfferCommissionReports)this.CommissionReports.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.PreObservation, null))
            {
                offer.PreObservation = (Sbn.Products.GEP.GEPObject.PreObservation)this.PreObservation.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OwnerOrgan, null))
            {
                offer.OwnerOrgan = (OfferOrgUnit)this.OwnerOrgan.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.ActiveCommission, null))
            {
                offer.ActiveCommission = (OfferCommission)this.ActiveCommission.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CommuniqueStatus, null))
            {
                offer.CommuniqueStatus = (BasicInfoDetail)this.CommuniqueStatus.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.OfferRelations, null))
                offer.OfferRelations = (OfferRelations)this.OfferRelations.Clone(sNodeName);

            offer._IsPublishable = this._IsPublishable;
            if (this._PublishableDate != null) offer._PublishableDate = (string)this._PublishableDate.Clone();

            if (!object.ReferenceEquals(this.WordDoc, null))
                offer.WordDoc = (GeneralDocument)this.WordDoc.Clone(sNodeName);

            return offer;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._OrderInCatalogue = 0;
            this._OfficialCode = "";
            this._VicePresidentReceiptdate = "";
            this._VicePresidentLetterID = "";
            this._GovOfficeReceiptDate = "";
            this._RegisterDate = "";
            this._OfferComment = "";
            this._GovSessionTitle = "";
            this._OtherLetters = new Letters();
            this._ApprovalLetters = new Sbn.Products.GEP.GEPObject.ApprovalLetters();
            this._GovernReports = new GovernmentReports();
            this._Inquiries = new Sbn.Products.GEP.GEPObject.Inquiries();
            this._Status = new BasicInfoDetail();
            this._GovMemberOpinions = new GovSessionMemberOpinions();
            this._Commissions = new OfferCommissions();
            this._Engineerings = new Sbn.Products.GEP.GEPObject.Engineerings();
            this._LawDocuments = new ExpertLawDocuments();
            this._CorrelateOrgans = new OfferOrgUnits();
            this._OfferAbstract = new Sbn.Products.GEP.GEPObject.OfferAbstract();
            this._OfferCommuniqueText = new Sbn.Products.GEP.GEPObject.OfferCommuniqueText();
            this._Urgency = new BasicInfoDetail();
            this._OfferLetter = new Letter();
            this._Security = new BasicInfoDetail();
            this._Complication = new BasicInfoDetail();
            this._Importance = new BasicInfoDetail();
            this._OfferType = new BasicInfoDetail();
            this._StatusInGovOrderOffice = new BasicInfoDetail();
            this._Subjects = new OfferSubjects();
            this._CommissionReports = new OfferCommissionReports();
            this._PreObservation = new Sbn.Products.GEP.GEPObject.PreObservation();
            this._OwnerOrgan = new OfferOrgUnit();
            this._ActiveCommission = new OfferCommission();
            this._CommuniqueStatus = new BasicInfoDetail();
            this._OfferRelations = new OfferRelations();

            this._IsPublishable = PublishableState.None;
            this._PublishableDate = "";
            this._WordDoc = new GeneralDocument();
        }

        public override string ToString()
        {
            return this.OfficialCode;
        }

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

        [IsMiddleTableExist("True"),
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
        }

        //   [
        //Description("نتایج نهایی"),
        //DisplayName("نتایج نهایی"),
        //Category(""),
        //DocumentAttributeID(""),
        //Browsable(true),
        //IsRelational("False"),
        //AttributeType("ApprovalLetters"),
        //        IsMiddleTableExist("False"),
        //  RelationTable("Approval_Offer_M")]
        //   public Sbn.Products.GEP.GEPObject.ApprovalLetters AppLetters
        //   {
        //       get
        //       {
        //           return this._ApprovalLetters;
        //       }
        //       set
        //       {
        //           this._ApprovalLetters = value;
        //       }
        //   }

        public static string at_ActiveCommission_AdminExpertFirstLevelAttributes
        {
            get
            {
                return "Offer.ActiveCommission.AdminExpertFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "Offer.ActiveCommission.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_CommissionResultsFirstLevelAttributes
        {
            get
            {
                return "Offer.ActiveCommission.CommissionResultsFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "Offer.ActiveCommission.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Offer.ActiveCommission.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_GovReportsFirstLevelAttributes
        {
            get
            {
                return "Offer.ActiveCommission.GovReportsFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_OfferEngineeringsFirstLevelAttributes
        {
            get
            {
                return "Offer.ActiveCommission.OfferEngineeringsFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_SessionsFirstLevelAttributes
        {
            get
            {
                return "Offer.ActiveCommission.SessionsFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommission_StatusFirstLevelAttributes
        {
            get
            {
                return "Offer.ActiveCommission.StatusFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "Offer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_ActiveCommissionID
        {
            get
            {
                return "Offer.ActiveCommissionID";
            }
        }

        public static string at_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "Offer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_ApprovalLettersID
        {
            get
            {
                return "Offer.ApprovalLettersID";
            }
        }

        public static string at_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "Offer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CommissionReportsID
        {
            get
            {
                return "Offer.CommissionReportsID";
            }
        }

        public static string at_CommissionsFirstLevelAttributes
        {
            get
            {
                return "Offer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CommissionsID
        {
            get
            {
                return "Offer.CommissionsID";
            }
        }

        public static string at_CommuniqueStatus_ParentFirstLevelAttributes
        {
            get
            {
                return "Offer.CommuniqueStatus.ParentFirstLevelAttributes";
            }
        }

        public static string at_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "Offer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CommuniqueStatusID
        {
            get
            {
                return "Offer.CommuniqueStatusID";
            }
        }

        public static string at_Complication_ParentFirstLevelAttributes
        {
            get
            {
                return "Offer.Complication.ParentFirstLevelAttributes";
            }
        }

        public static string at_ComplicationFirstLevelAttributes
        {
            get
            {
                return "Offer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_ComplicationID
        {
            get
            {
                return "Offer.ComplicationID";
            }
        }

        public static string at_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "Offer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOrgansID
        {
            get
            {
                return "Offer.CorrelateOrgansID";
            }
        }

        public static string at_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "Offer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_EngineeringsID
        {
            get
            {
                return "Offer.EngineeringsID";
            }
        }

        public static string at_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "Offer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_GovernReportsID
        {
            get
            {
                return "Offer.GovernReportsID";
            }
        }

        public static string at_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "Offer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_GovMemberOpinionsID
        {
            get
            {
                return "Offer.GovMemberOpinionsID";
            }
        }

        public static string at_GovOfficeReceiptDate
        {
            get
            {
                return "Offer.GovOfficeReceiptDate";
            }
        }

        public static string at_GovSessionTitle
        {
            get
            {
                return "Offer.GovSessionTitle";
            }
        }

        public static string at_Importance_ParentFirstLevelAttributes
        {
            get
            {
                return "Offer.Importance.ParentFirstLevelAttributes";
            }
        }

        public static string at_ImportanceFirstLevelAttributes
        {
            get
            {
                return "Offer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_ImportanceID
        {
            get
            {
                return "Offer.ImportanceID";
            }
        }

        public static string at_InquiriesFirstLevelAttributes
        {
            get
            {
                return "Offer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_InquiriesID
        {
            get
            {
                return "Offer.InquiriesID";
            }
        }

        public static string at_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "Offer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_LawDocumentsID
        {
            get
            {
                return "Offer.LawDocumentsID";
            }
        }

        public static string at_OfferAbstract_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferAbstract.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_OfferAbstractID
        {
            get
            {
                return "Offer.OfferAbstractID";
            }
        }

        public static string at_OfferComment
        {
            get
            {
                return "Offer.OfferComment";
            }
        }

        public static string at_WordDocID
        {
            get
            {
                return "Offer.WordDocID";
            }
        }
        public static string at_WordDocTitle
        {
            get
            {
                return "Offer.WordDoc.Title";
            }
        }
        public static string at_WordDocFirstLevelAttributes
        {
            get
            {
                return "Offer.WordDocFirstLevelAttributes";
            }
        }

        public static string at_OfferCommuniqueText_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferCommuniqueText.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_OfferCommuniqueTextID
        {
            get
            {
                return "Offer.OfferCommuniqueTextID";
            }
        }

        public static string at_OfferLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_OfferLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_OfferLetterID
        {
            get
            {
                return "Offer.OfferLetterID";
            }
        }

        public static string at_OfferRelations
        {
            get
            {
                return "Offer.OfferRelations";
            }
        }

        public static string at_OfferType_ParentFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferType.ParentFirstLevelAttributes";
            }
        }

        public static string at_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "Offer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_OfferTypeID
        {
            get
            {
                return "Offer.OfferTypeID";
            }
        }

        public static string at_OfficialCode
        {
            get
            {
                return "Offer.OfficialCode";
            }
        }



        public static string at_OrderInCatalogue
        {
            get
            {
                return "Offer.OrderInCatalogue";
            }
        }

        public static string at_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "Offer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_OtherLettersID
        {
            get
            {
                return "Offer.OtherLettersID";
            }
        }

        public static string at_OwnerOrgan_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Offer.OwnerOrgan.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_OwnerOrgan_CorrelateOrgUnitFirstLevelAttributes
        {
            get
            {
                return "Offer.OwnerOrgan.CorrelateOrgUnitFirstLevelAttributes";
            }
        }

        public static string at_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "Offer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_OwnerOrganID
        {
            get
            {
                return "Offer.OwnerOrganID";
            }
        }

        public static string at_PreObservation_CoCommissionExpertFirstLevelAttributes
        {
            get
            {
                return "Offer.PreObservation.CoCommissionExpertFirstLevelAttributes";
            }
        }

        public static string at_PreObservation_CoOfferFirstLevelAttributes
        {
            get
            {
                return "Offer.PreObservation.CoOfferFirstLevelAttributes";
            }
        }

        public static string at_PreObservation_CoWordDocumentFirstLevelAttributes
        {
            get
            {
                return "Offer.PreObservation.CoWordDocumentFirstLevelAttributes";
            }
        }

        public static string at_PreObservation_PicsFirstLevelAttributes
        {
            get
            {
                return "Offer.PreObservation.PicsFirstLevelAttributes";
            }
        }

        public static string at_PreObservationFirstLevelAttributes
        {
            get
            {
                return "Offer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_PreObservationID
        {
            get
            {
                return "Offer.PreObservationID";
            }
        }

        public static string at_RegisterDate
        {
            get
            {
                return "Offer.RegisterDate";
            }
        }

        public static string at_Security_ParentFirstLevelAttributes
        {
            get
            {
                return "Offer.Security.ParentFirstLevelAttributes";
            }
        }

        public static string at_SecurityFirstLevelAttributes
        {
            get
            {
                return "Offer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_SecurityID
        {
            get
            {
                return "Offer.SecurityID";
            }
        }

        public static string at_Status_ParentFirstLevelAttributes
        {
            get
            {
                return "Offer.Status.ParentFirstLevelAttributes";
            }
        }

        public static string at_StatusFirstLevelAttributes
        {
            get
            {
                return "Offer.StatusFirstLevelAttributes";
            }
        }

        public static string at_StatusID
        {
            get
            {
                return "Offer.StatusID";
            }
        }

        public static string at_StatusInGovOrderOffice_ParentFirstLevelAttributes
        {
            get
            {
                return "Offer.StatusInGovOrderOffice.ParentFirstLevelAttributes";
            }
        }

        public static string at_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "Offer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_StatusInGovOrderOfficeID
        {
            get
            {
                return "Offer.StatusInGovOrderOfficeID";
            }
        }

        public static string at_SubjectsFirstLevelAttributes
        {
            get
            {
                return "Offer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_SubjectsID
        {
            get
            {
                return "Offer.SubjectsID";
            }
        }

        public static string at_Urgency_ParentFirstLevelAttributes
        {
            get
            {
                return "Offer.Urgency.ParentFirstLevelAttributes";
            }
        }

        public static string at_UrgencyFirstLevelAttributes
        {
            get
            {
                return "Offer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_UrgencyID
        {
            get
            {
                return "Offer.UrgencyID";
            }
        }

        public static string at_VicePresidentLetterID
        {
            get
            {
                return "Offer.VicePresidentLetterID";
            }
        }

        public static string at_VicePresidentReceiptdate
        {
            get
            {
                return "Offer.VicePresidentReceiptdate";
            }
        }

        public static string at_ChildOffersID
        {
            get
            {
                return "Offer.ChildOffersID";
            }
        }

        public static string at_ChildOffersFirstLevelAttributes
        {
            get
            {
                return "Offer.ChildOffersFirstLevelAttributes";
            }
        }

        public static string at_ParentOffer_ChildOffersFirstLevelAttributes
        {
            get
            {
                return "Offer.ParentOffer.ChildOffersFirstLevelAttributes";
            }
        }

        public static string at_IsPublishable
        {
            get
            {
                return "Offer.IsPublishable";
            }
        }

        public static string at_PublishableDate
        {
            get
            {
                return "Offer.PublishableDate";
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
        }

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

        [Description("خلاصه پیشنهاد"), RelationTable(""), DisplayName("خلاصه پیشنهاد"), Category(""), DocumentAttributeID("9278"), Browsable(true), IsRelational("False"), AttributeType("OfferAbstract"), IsMiddleTableExist("False")]
        public Sbn.Products.GEP.GEPObject.OfferAbstract OfferAbstract
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
        public GeneralDocument WordDoc
        {
            get { return _WordDoc; }
            set { _WordDoc = value; }
        }

        [IsMiddleTableExist("False"), RelationTable(""), Description("متن ابلاغیه پیشنهادی دستگاه"), DisplayName("متن ابلاغیه پیشنهادی دستگاه"), Category(""), DocumentAttributeID("9279"), Browsable(true), IsRelational("False"), AttributeType("OfferCommuniqueText")]
        public Sbn.Products.GEP.GEPObject.OfferCommuniqueText OfferCommuniqueText
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

        [Category(""), Description("کد پیشنهاد"), Browsable(true), AttributeType("String"), DocumentAttributeID("9008"), DisplayName("کد پیشنهاد"), IsRelational("false")]
        public string OfficialCode
        {
            get
            {
                return this._OfficialCode;
            }
            set
            {
                this._OfficialCode = value;
            }
        }

        [Description("ردیف در فهرست"), Browsable(true), DisplayName("ردیف در فهرست"), Category(""), DocumentAttributeID("9019"), IsRelational("false"), AttributeType("Int")]
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
        }

        [Description("پیشنهاد دهنده"), Browsable(true), IsRelational("False"), RelationTable(""), DisplayName("پیشنهاد دهنده"), Category(""), DocumentAttributeID("9380"), AttributeType("OfferOrgUnit"), IsMiddleTableExist("False")]
        public OfferOrgUnit OwnerOrgan
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

        [Browsable(true), RelationTable(""), Description("ارزیابی مقدماتی"), DisplayName("ارزیابی مقدماتی"), Category(""), DocumentAttributeID("9408"), IsRelational("False"), AttributeType("PreObservation"), IsMiddleTableExist("False")]
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
        }

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

        [Category(""), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable(""), Description("وضعیت پیشنهاد در امور دولت"), DisplayName("وضعیت پیشنهاد در امور دولت"), DocumentAttributeID("9396"), Browsable(true), IsRelational("False")]
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
        }

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

        private OfferRelations _OfferRelations;
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
        }
    }
}
