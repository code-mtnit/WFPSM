namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), ItemsType("Sbn.Products.GEP.GEPObject.GovernmentReports"), Description("گزارش كميسيون جهت طرح در دولت"), DisplayName("گزارش كميسيون جهت طرح در دولت"), ObjectCode("9061")]
    public class GovernmentReport : SbnObject
    {
        private Engineering _CorrelateEngineering;
        private OfferCommission _CorrelateOffCom;
        private Offer _CorrelateOffer;
        private SbnBoolean _IsActive;
        private GovernmentReportPictures _Pictures;
        private GeneralDocument _WordDoc;

        public GovernmentReport()
        {
            this._IsActive = SbnBoolean.OutOfValue;
        }

        public GovernmentReport(SbnObject InitialObject) : base(InitialObject)
        {
            this._IsActive = SbnBoolean.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            GovernmentReport report = new GovernmentReport {
                ID = base.ID
            };
            if (!object.ReferenceEquals(this.CorrelateEngineering, null))
            {
                report.CorrelateEngineering = (Engineering) this.CorrelateEngineering.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Pictures, null))
            {
                report.Pictures = (GovernmentReportPictures) this.Pictures.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                report.CorrelateOffer = (Offer) this.CorrelateOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.WordDoc, null))
            {
                report.WordDoc = (GeneralDocument) this.WordDoc.Clone(sNodeName);
            }
            report.IsActive = this.IsActive;
            if (!object.ReferenceEquals(this.CorrelateOffCom, null))
            {
                report.CorrelateOffCom = (OfferCommission) this.CorrelateOffCom.Clone(sNodeName);
            }
            return report;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._CorrelateEngineering = new Engineering();
            this._Pictures = new GovernmentReportPictures();
            this._CorrelateOffer = new Offer();
            this._WordDoc = new GeneralDocument();
            this._IsActive = SbnBoolean.OutOfValue;
            this._CorrelateOffCom = new OfferCommission();
        }

        public override string ToString()
        {
            return base.ID.ToString();
        }

        public static string at_CorrelateEngineering_CorrelateExpertFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateEngineering.CorrelateExpertFirstLevelAttributes";
            }
        }

        public static string at_CorrelateEngineering_CorrelateGovReportsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateEngineering.CorrelateGovReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateEngineering_CorrelateOfferCommissionFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateEngineering.CorrelateOfferCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateEngineering_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateEngineering.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateEngineeringFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateEngineeringFirstLevelAttributes";
            }
        }

        public static string at_CorrelateEngineeringID
        {
            get
            {
                return "GovernmentReport.CorrelateEngineeringID";
            }
        }

        public static string at_CorrelateOffCom_AdminExpertFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffCom.AdminExpertFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffCom_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffCom.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffCom_CommissionResultsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffCom.CommissionResultsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffCom_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffCom.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffCom_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffCom.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffCom_GovReportsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffCom.GovReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffCom_OfferEngineeringsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffCom.OfferEngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffCom_SessionsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffCom.SessionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffCom_StatusFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffCom.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffComFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffComFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffComID
        {
            get
            {
                return "GovernmentReport.CorrelateOffComID";
            }
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "GovernmentReport.CorrelateOfferID";
            }
        }

        public static string at_IsActive
        {
            get
            {
                return "GovernmentReport.IsActive";
            }
        }

        public static string at_PicturesFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.PicturesFirstLevelAttributes";
            }
        }

        public static string at_PicturesID
        {
            get
            {
                return "GovernmentReport.PicturesID";
            }
        }

        public static string at_WordDoc_CorrelateFolderFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.WordDoc.CorrelateFolderFirstLevelAttributes";
            }
        }

        public static string at_WordDoc_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.WordDoc.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_WordDoc_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.WordDoc.DocumentTypeFirstLevelAttributes";
            }
        }

        public static string at_WordDoc_FileVersionsFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.WordDoc.FileVersionsFirstLevelAttributes";
            }
        }

        public static string at_WordDoc_OwnerFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.WordDoc.OwnerFirstLevelAttributes";
            }
        }

        public static string at_WordDocFirstLevelAttributes
        {
            get
            {
                return "GovernmentReport.WordDocFirstLevelAttributes";
            }
        }

        public static string at_WordDocID
        {
            get
            {
                return "GovernmentReport.WordDocID";
            }
        }

        [DocumentAttributeID("9091"), RelationTable(""), Description("کارشناسی مرتبط با پیشنهاد کمیسیون"), DisplayName("کارشناسی کمیسیون"), Category(""), Browsable(true), IsRelational("False"), AttributeType("Engineering"), IsMiddleTableExist("False")]
        public Engineering CorrelateEngineering
        {
            get
            {
                return this._CorrelateEngineering;
            }
            set
            {
                this._CorrelateEngineering = value;
            }
        }

        [AttributeType("OfferCommission"), IsRelational("False"), Description("پیشنهاد کمیسیون"), RelationTable(""), DisplayName("پیشنهاد کمیسیون"), Category(""), DocumentAttributeID("9352"), IsMiddleTableExist("False"), Browsable(true)]
        public OfferCommission CorrelateOffCom
        {
            get
            {
                return this._CorrelateOffCom;
            }
            set
            {
                this._CorrelateOffCom = value;
            }
        }

        [RelationTable(""), Description("پیشنهاد مرتبط"), DisplayName("پیشنهاد مرتبط"), Category(""), DocumentAttributeID("9047"), Browsable(true), IsRelational("False"), AttributeType("Offer"), IsMiddleTableExist("False")]
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

        [RelationTable(""), Description(""), DisplayName(""), Category(""), DocumentAttributeID("9275"), Browsable(true), IsRelational("False"), AttributeType("SbnBoolean"), IsMiddleTableExist("False")]
        public SbnBoolean IsActive
        {
            get
            {
                return this._IsActive;
            }
            set
            {
                this._IsActive = value;
            }
        }

        [DisplayName("تصاویر"), IsRelational("False"), AttributeType("GovernmentReportPictures"), RelationTable("GOVERNMENTREPORT_PICTURES_M"), Description("تصاویر"), Category(""), DocumentAttributeID("9026"), Browsable(true), IsMiddleTableExist("False")]
        public GovernmentReportPictures Pictures
        {
            get
            {
                return this._Pictures;
            }
            set
            {
                this._Pictures = value;
            }
        }

        [Description("مستند تایپی"), RelationTable(""), DisplayName("مستند تایپی"), Category(""), DocumentAttributeID("9345"), Browsable(true), IsRelational("False"), AttributeType("GeneralDocument"), IsMiddleTableExist("False")]
        public GeneralDocument WordDoc
        {
            get
            {
                return this._WordDoc;
            }
            set
            {
                this._WordDoc = value;
            }
        }
    }
}
