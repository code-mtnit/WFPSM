namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("گزارش جهت طرح در كميسيون"), DisplayName("گزارش جهت طرح در كميسيون"), ItemsType("Sbn.Products.GEP.GEPObject.OfferCommissionReports"), ObjectCode("9255")]
    public class OfferCommissionReport : SbnObject
    {
        private BasicInfoDetail _ComSessionType;
        private OfferCommission _CoOfferCommission;
        private Engineering _CorrelateEngineering;
        private Offer _CorrelateOffer;
        private OfferCommissionReportPics _Pictures;
        private string _TextContent;
        private GeneralDocument _WordDoc;

        public OfferCommissionReport()
        {
        }

        public OfferCommissionReport(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            OfferCommissionReport report = new OfferCommissionReport {
                ID = base.ID
            };
            if (this._TextContent != null)
            {
                report.TextContent = (string) this._TextContent.Clone();
            }
            if (!object.ReferenceEquals(this.CorrelateEngineering, null))
            {
                report.CorrelateEngineering = (Engineering) this.CorrelateEngineering.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
            {
                report.CorrelateOffer = (Offer) this.CorrelateOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Pictures, null))
            {
                report.Pictures = (OfferCommissionReportPics) this.Pictures.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.WordDoc, null))
            {
                report.WordDoc = (GeneralDocument) this.WordDoc.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoOfferCommission, null))
            {
                report.CoOfferCommission = (OfferCommission) this.CoOfferCommission.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.ComSessionType, null))
            {
                report.ComSessionType = (BasicInfoDetail) this.ComSessionType.Clone(sNodeName);
            }
            return report;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._TextContent = "";
            this._CorrelateEngineering = new Engineering();
            this._CorrelateOffer = new Offer();
            this._Pictures = new OfferCommissionReportPics();
            this._WordDoc = new GeneralDocument();
            this._CoOfferCommission = new OfferCommission();
            this._ComSessionType = new BasicInfoDetail();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_ComSessionType_ParentFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.ComSessionType.ParentFirstLevelAttributes";
            }
        }

        public static string at_ComSessionTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.ComSessionTypeFirstLevelAttributes";
            }
        }

        public static string at_ComSessionTypeID
        {
            get
            {
                return "OfferCommissionReport.ComSessionTypeID";
            }
        }

        public static string at_CoOfferCommission_AdminExpertFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CoOfferCommission.AdminExpertFirstLevelAttributes";
            }
        }

        public static string at_CoOfferCommission_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CoOfferCommission.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CoOfferCommission_CommissionResultsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CoOfferCommission.CommissionResultsFirstLevelAttributes";
            }
        }

        public static string at_CoOfferCommission_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CoOfferCommission.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CoOfferCommission_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CoOfferCommission.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CoOfferCommission_GovReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CoOfferCommission.GovReportsFirstLevelAttributes";
            }
        }

        public static string at_CoOfferCommission_OfferEngineeringsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CoOfferCommission.OfferEngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CoOfferCommission_SessionsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CoOfferCommission.SessionsFirstLevelAttributes";
            }
        }

        public static string at_CoOfferCommission_StatusFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CoOfferCommission.StatusFirstLevelAttributes";
            }
        }

        public static string at_CoOfferCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CoOfferCommissionFirstLevelAttributes";
            }
        }

        public static string at_CoOfferCommissionID
        {
            get
            {
                return "OfferCommissionReport.CoOfferCommissionID";
            }
        }

        public static string at_CorrelateEngineering_CorrelateExpertFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateEngineering.CorrelateExpertFirstLevelAttributes";
            }
        }

        public static string at_CorrelateEngineering_CorrelateGovReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateEngineering.CorrelateGovReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateEngineering_CorrelateOfferCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateEngineering.CorrelateOfferCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateEngineering_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateEngineering.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateEngineeringFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateEngineeringFirstLevelAttributes";
            }
        }

        public static string at_CorrelateEngineeringID
        {
            get
            {
                return "OfferCommissionReport.CorrelateEngineeringID";
            }
        }

        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOfferID
        {
            get
            {
                return "OfferCommissionReport.CorrelateOfferID";
            }
        }

        public static string at_PicturesFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.PicturesFirstLevelAttributes";
            }
        }

        public static string at_PicturesID
        {
            get
            {
                return "OfferCommissionReport.PicturesID";
            }
        }

        public static string at_TextContent
        {
            get
            {
                return "OfferCommissionReport.TextContent";
            }
        }

        public static string at_WordDoc_CorrelateFolderFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.WordDoc.CorrelateFolderFirstLevelAttributes";
            }
        }

        public static string at_WordDoc_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.WordDoc.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_WordDoc_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.WordDoc.DocumentTypeFirstLevelAttributes";
            }
        }

        public static string at_WordDoc_FileVersionsFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.WordDoc.FileVersionsFirstLevelAttributes";
            }
        }

        public static string at_WordDoc_OwnerFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.WordDoc.OwnerFirstLevelAttributes";
            }
        }

        public static string at_WordDocFirstLevelAttributes
        {
            get
            {
                return "OfferCommissionReport.WordDocFirstLevelAttributes";
            }
        }

        public static string at_WordDocID
        {
            get
            {
                return "OfferCommissionReport.WordDocID";
            }
        }

        [Browsable(true), RelationTable(""), Description("نوع جلسه کمیسیون"), DisplayName("نوع جلسه"), Category(""), DocumentAttributeID("9339"), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False")]
        public BasicInfoDetail ComSessionType
        {
            get
            {
                return this._ComSessionType;
            }
            set
            {
                this._ComSessionType = value;
            }
        }

        [Category(""), Browsable(true), AttributeType("OfferCommission"), IsMiddleTableExist("False"), RelationTable(""), IsRelational("False"), DocumentAttributeID("9338"), Description("پیشنهاد کمیسیون"), DisplayName("پیشنهاد کمیسیون")]
        public OfferCommission CoOfferCommission
        {
            get
            {
                return this._CoOfferCommission;
            }
            set
            {
                this._CoOfferCommission = value;
            }
        }

        [DocumentAttributeID("9324"), RelationTable(""), Description("کارشناسی مرتبط"), DisplayName("کارشناسی مرتبط"), Category(""), Browsable(true), IsRelational("False"), AttributeType("Engineering"), IsMiddleTableExist("False")]
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

        [IsRelational("False"), AttributeType("Offer"), Category(""), DocumentAttributeID("9325"), Browsable(true), RelationTable(""), Description("پیشنهاد مرتبط"), DisplayName("پیشنهاد مرتبط"), IsMiddleTableExist("False")]
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

        [Browsable(true), Description(""), AttributeType("OfferCommissionReportPics"), IsMiddleTableExist("False"), RelationTable("OFFERCOMMREP_PICS_M"), DisplayName(""), IsRelational("False"), Category(""), DocumentAttributeID("9327")]
        public OfferCommissionReportPics Pictures
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

        [Browsable(true), Description("متن کامل"), DisplayName("متن کامل"), Category(""), DocumentAttributeID("9251"), IsRelational("false"), AttributeType("LongText")]
        public string TextContent
        {
            get
            {
                return this._TextContent;
            }
            set
            {
                this._TextContent = value;
            }
        }

        [AttributeType("GeneralDocument"), Category(""), DocumentAttributeID("9346"), IsMiddleTableExist("False"), DisplayName(""), Browsable(true), RelationTable(""), IsRelational("False"), Description("")]
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
