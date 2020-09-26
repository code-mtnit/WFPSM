namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("در اين بخش پرونده ارجاع شده به كميسيون جهت ارزيابي مقدماتي نمايش داده مي شود."), DisplayName("در اين بخش پرونده ارجاع شده به كميسيون جهت ارزيابي مقدماتي نمايش داده مي شود."), ObjectCode("9280"), ItemsType("Sbn.Products.GEP.GEPObject.PreObservations")]
    public class PreObservation : SbnObject
    {
        private string _ApprovalArchive;
        private CommissionExpert _CoCommissionExpert;
        private Letter _CoLetter;
        private string _ConsiderationText;
        private Offer _CoOffer;
        private GeneralDocument _CoWordDocument;
        private string _JustificationReasons;
        private string _Opinion1;
        private string _Opinion2;
        private string _Opinion3;
        private string _ParticularDescription;
        private PreObservationPics _Pics;
        private string _Title;

        public PreObservation()
        {
        }

        public PreObservation(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            PreObservation observation = new PreObservation {
                ID = base.ID,
                Title = this._Title
            };
            if (this._ParticularDescription != null)
            {
                observation.ParticularDescription = (string) this._ParticularDescription.Clone();
            }
            if (this._JustificationReasons != null)
            {
                observation.JustificationReasons = (string) this._JustificationReasons.Clone();
            }
            if (this._ConsiderationText != null)
            {
                observation.ConsiderationText = (string) this._ConsiderationText.Clone();
            }
            if (this._ApprovalArchive != null)
            {
                observation.ApprovalArchive = (string) this._ApprovalArchive.Clone();
            }
            observation.Opinion1 = this._Opinion1;
            observation.Opinion2 = this._Opinion2;
            observation.Opinion3 = this._Opinion3;
            if (!object.ReferenceEquals(this.CoWordDocument, null))
            {
                observation.CoWordDocument = (GeneralDocument) this.CoWordDocument.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoOffer, null))
            {
                observation.CoOffer = (Offer) this.CoOffer.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoCommissionExpert, null))
            {
                observation.CoCommissionExpert = (CommissionExpert) this.CoCommissionExpert.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Pics, null))
            {
                observation.Pics = (PreObservationPics) this.Pics.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoLetter, null))
            {
                observation.CoLetter = (Letter) this.CoLetter.Clone(sNodeName);
            }
            return observation;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._Title = "";
            this._ParticularDescription = "";
            this._JustificationReasons = "";
            this._ConsiderationText = "";
            this._ApprovalArchive = "";
            this._Opinion1 = "";
            this._Opinion2 = "";
            this._Opinion3 = "";
            this._CoWordDocument = new GeneralDocument();
            this._CoOffer = new Offer();
            this._CoCommissionExpert = new CommissionExpert();
            this._Pics = new PreObservationPics();
            this._CoLetter = new Letter();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        [IsRelational("false"), Browsable(true), DisplayName("سوابق تصمیمات دولت"), Category(""), DocumentAttributeID("9272"), Description("سوابق احتمالی دولت درخصوص موضوع"), AttributeType("LongText")]
        public string ApprovalArchive
        {
            get
            {
                return this._ApprovalArchive;
            }
            set
            {
                this._ApprovalArchive = value;
            }
        }

        public static string at_ApprovalArchive
        {
            get
            {
                return "PreObservation.ApprovalArchive";
            }
        }

        public static string at_CoCommissionExpert_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoCommissionExpert.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CoCommissionExpert_CorrelatePersonFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoCommissionExpert.CorrelatePersonFirstLevelAttributes";
            }
        }

        public static string at_CoCommissionExpertFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoCommissionExpertFirstLevelAttributes";
            }
        }

        public static string at_CoCommissionExpertID
        {
            get
            {
                return "PreObservation.CoCommissionExpertID";
            }
        }

        public static string at_CoLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CoLetterFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoLetterFirstLevelAttributes";
            }
        }

        public static string at_CoLetterID
        {
            get
            {
                return "PreObservation.CoLetterID";
            }
        }

        public static string at_ConsiderationText
        {
            get
            {
                return "PreObservation.ConsiderationText";
            }
        }

        public static string at_CoOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.ActiveCommissionFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.ApprovalLettersFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.CommissionReportsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.CommissionsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.ComplicationFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.EngineeringsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.GovernReportsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.ImportanceFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.InquiriesFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.LawDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.OfferAbstractFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.OfferLetterFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.OfferTypeFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.OtherLettersFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.OwnerOrganFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.PreObservationFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.SecurityFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.StatusFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.SubjectsFirstLevelAttributes";
            }
        }

        public static string at_CoOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOffer.UrgencyFirstLevelAttributes";
            }
        }

        public static string at_CoOfferFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoOfferFirstLevelAttributes";
            }
        }

        public static string at_CoOfferID
        {
            get
            {
                return "PreObservation.CoOfferID";
            }
        }

        public static string at_CoWordDocument_CorrelateFolderFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoWordDocument.CorrelateFolderFirstLevelAttributes";
            }
        }

        public static string at_CoWordDocument_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoWordDocument.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CoWordDocument_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoWordDocument.DocumentTypeFirstLevelAttributes";
            }
        }

        public static string at_CoWordDocument_FileVersionsFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoWordDocument.FileVersionsFirstLevelAttributes";
            }
        }

        public static string at_CoWordDocument_OwnerFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoWordDocument.OwnerFirstLevelAttributes";
            }
        }

        public static string at_CoWordDocumentFirstLevelAttributes
        {
            get
            {
                return "PreObservation.CoWordDocumentFirstLevelAttributes";
            }
        }

        public static string at_CoWordDocumentID
        {
            get
            {
                return "PreObservation.CoWordDocumentID";
            }
        }

        public static string at_JustificationReasons
        {
            get
            {
                return "PreObservation.JustificationReasons";
            }
        }

        public static string at_Opinion1
        {
            get
            {
                return "PreObservation.Opinion1";
            }
        }

        public static string at_Opinion2
        {
            get
            {
                return "PreObservation.Opinion2";
            }
        }

        public static string at_Opinion3
        {
            get
            {
                return "PreObservation.Opinion3";
            }
        }

        public static string at_ParticularDescription
        {
            get
            {
                return "PreObservation.ParticularDescription";
            }
        }

        public static string at_PicsFirstLevelAttributes
        {
            get
            {
                return "PreObservation.PicsFirstLevelAttributes";
            }
        }

        public static string at_PicsID
        {
            get
            {
                return "PreObservation.PicsID";
            }
        }

        public static string at_Title
        {
            get
            {
                return "PreObservation.Title";
            }
        }

        [AttributeType("CommissionExpert"), Browsable(true), IsRelational("False"), IsMiddleTableExist("False"), RelationTable(""), Description("کارشناس مرتبط"), DisplayName("کارشناس مرتبط"), Category(""), DocumentAttributeID("9406")]
        public CommissionExpert CoCommissionExpert
        {
            get
            {
                return this._CoCommissionExpert;
            }
            set
            {
                this._CoCommissionExpert = value;
            }
        }

        [DocumentAttributeID("27237"), IsRelational("False"), AttributeType("Letter"), Description("نامه مرتبط"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("نامه مرتبط"), Category("مشخصات اصلی"), Browsable(true)]
        public Letter CoLetter
        {
            get
            {
                return this._CoLetter;
            }
            set
            {
                this._CoLetter = value;
            }
        }

        [DisplayName("ارزیابی و پیشنهاد"), Category(""), DocumentAttributeID("9271"), Browsable(true), IsRelational("false"), Description("متن ارزیابی و پیشنهاد"), AttributeType("LongText")]
        public string ConsiderationText
        {
            get
            {
                return this._ConsiderationText;
            }
            set
            {
                this._ConsiderationText = value;
            }
        }

        [Description("پیشنهاد مرتبط"), RelationTable(""), DisplayName("پیشنهاد مرتبط"), Category(""), DocumentAttributeID("9405"), Browsable(true), IsRelational("False"), AttributeType("Offer"), IsMiddleTableExist("False")]
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

        [Browsable(true), Description("مستند تایپی مرتبط"), DisplayName("مستند تایپی"), Category(""), DocumentAttributeID("9409"), IsRelational("False"), AttributeType("GeneralDocument"), IsMiddleTableExist("False"), RelationTable("")]
        public GeneralDocument CoWordDocument
        {
            get
            {
                return this._CoWordDocument;
            }
            set
            {
                this._CoWordDocument = value;
            }
        }

        [IsRelational("false"), DisplayName("دلایل توجیهی"), DocumentAttributeID("9270"), Category(""), Browsable(true), AttributeType("LongText"), Description("ضرورت پیشنهاد یا دلایل توجیهی پیشنهاد دهنده")]
        public string JustificationReasons
        {
            get
            {
                return this._JustificationReasons;
            }
            set
            {
                this._JustificationReasons = value;
            }
        }

        [Category(""), Description("نظر رییس دبیرخانه کمیسیون"), DisplayName("نظر رییس دبیرخانه"), Browsable(true), DocumentAttributeID("9273"), IsRelational("false"), AttributeType("String")]
        public string Opinion1
        {
            get
            {
                return this._Opinion1;
            }
            set
            {
                this._Opinion1 = value;
            }
        }

        [Browsable(true), Description("نظر دبیر کمیسیون"), DisplayName("نظر دبیر کمیسیون"), Category(""), DocumentAttributeID("9274"), IsRelational("false"), AttributeType("String")]
        public string Opinion2
        {
            get
            {
                return this._Opinion2;
            }
            set
            {
                this._Opinion2 = value;
            }
        }

        [DisplayName("نظر دبیر هیات دولت"), Description("نظر دبیر هیات دولت"), Category(""), DocumentAttributeID("9275"), IsRelational("false"), AttributeType("String"), Browsable(true)]
        public string Opinion3
        {
            get
            {
                return this._Opinion3;
            }
            set
            {
                this._Opinion3 = value;
            }
        }

        [Category(""), IsRelational("false"), AttributeType("LongText"), Browsable(true), Description("شرح دقیق"), DisplayName("شرح دقیق"), DocumentAttributeID("9269")]
        public string ParticularDescription
        {
            get
            {
                return this._ParticularDescription;
            }
            set
            {
                this._ParticularDescription = value;
            }
        }

        [IsMiddleTableExist("True"), DocumentAttributeID("9410"), IsRelational("True"), AttributeType("PreObservationPics"), RelationTable("PreObservation_Pics_M"), Browsable(true), Description("تصاویر"), DisplayName("تصاویر"), Category("")]
        public PreObservationPics Pics
        {
            get
            {
                return this._Pics;
            }
            set
            {
                this._Pics = value;
            }
        }

        [DocumentAttributeID("9268"), IsRelational("false"), Description("عنوان"), DisplayName("عنوان"), Category(""), AttributeType("String"), Browsable(true)]
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
