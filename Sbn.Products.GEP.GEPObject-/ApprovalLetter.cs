using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using MSXML2;
using Sbn.Core;
using Sbn.Systems.OPS;
using Sbn.Controls.Imaging;
using Sbn.Systems.WMC;
using Sbn.Systems.WMC.WMCObject;
namespace Sbn.Products.GEP.GEPObject
{
    /// <summary>
    /// وضعیت پالایش نتایج نهایی
    /// مقدار عددی مقدار معادل
    /// AliasCode
    /// در بانک اطلاعاتی اطلاعات پایه ای می باشد
    /// </summary>
    public enum RefineStatusState
    {
        /// <summary>
        /// درحال تولید
        /// </summary>
        Creating = 6660,
        /// <summary>
        /// درحال ویرایش
        /// </summary>
        Editing = 6666,
        /// <summary>
        /// ویرایش شده
        /// </summary>
        Edited = 6667,
        /// <summary>
        /// تایید اولیه
        /// </summary>
        Confirmed = 6668,
        /// <summary>
        /// تایید نهایی
        /// </summary>
        FinalConfirmed = 6669
    }

    [Description("نامه نتيجه نهايي هيات دولت و كميسيونها روي پيشنهاد")]
    [DisplayName("نامه نتيجه نهايي هيات دولت و كميسيونها روي پيشنهاد")]
    [ObjectCode("9067")]
    [SystemName("GEP")]
    [ItemsType("Sbn.Products.GEP.GEPObject.ApprovalLetters")]
    [Serializable]
    public class ApprovalLetter : SbnObject
    {
        public ApprovalLetter()
            : base()
        {
        }
        public ApprovalLetter(SbnObject InitialObject)
            : base(InitialObject)
        {
        }

        private GeneralDocument _WordDocReportDescription;
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
        public GeneralDocument WordDocReportDescription
        {
            get { return _WordDocReportDescription; }
            set { _WordDocReportDescription = value; }
        }

        private BasicInfoDetail _Sensitivity;
        /// <summary>
        /// طبقه بندی نامه
        /// </summary>
        [Description("طبقه بندی نتیجه نهایی")]
        [DisplayName("طبقه بندی")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail Sensitivity
        {
            get { return _Sensitivity; }
            set { _Sensitivity = value; }
        }

        private string _Duration;
        /// <summary>
        /// مدت زمان
        /// </summary>
        [Description("مدت زمان")]
        [DisplayName("مدت زمان")]
        [Category("مدت زمان بحث")]
        [DocumentAttributeID("27165")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }
        private string _ResultText;
        /// <summary>
        /// متن مصوبه
        /// </summary>
        [Description("متن مصوبه")]
        [DisplayName("متن مصوبه")]
        [Category("")]
        [DocumentAttributeID("27166")]
        [IsRelationalAttribute("false")]
        [AttributeType("LongText")]
        [Browsable(true)]
        public string ResultText
        {
            get { return _ResultText; }
            set { _ResultText = value; }
        }
        private string _PublishDate;
        /// <summary>
        /// تاریخ انتشار روزنامه رسمی
        /// </summary>
        [Description("تاریخ انتشار روزنامه رسمی")]
        [DisplayName("تاریخ انتشار روزنامه رسمی")]
        [Category("")]
        [DocumentAttributeID("27171")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string PublishDate
        {
            get { return _PublishDate; }
            set { _PublishDate = value; }
        }
        private long _NewsPaperNumber;
        /// <summary>
        /// 
        /// </summary>
        [Description("شماره روزنامه رسمی")]
        [DisplayName("شماره روزنامه رسمی")]
        [Category("")]
        [DocumentAttributeID("27172")]
        [IsRelationalAttribute("false")]
        [AttributeType("Long")]
        [Browsable(true)]
        public long NewsPaperNumber
        {
            get { return _NewsPaperNumber; }
            set { _NewsPaperNumber = value; }
        }
        private Letter _CorrelateLetter;
        /// <summary>
        /// نامه مرتبط
        /// </summary>
        [Description("نامه مرتبط")]
        [DisplayName("نامه مرتبط")]
        [Category("")]
        [DocumentAttributeID("9033")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Letter")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Letter CorrelateLetter
        {
            get { return _CorrelateLetter; }
            set { _CorrelateLetter = value; }
        }
        private BasicInfoDetail _ApprovalType;
        /// <summary>
        /// نتیجه نهایی دولت روی پیشنهاد
        /// </summary>
        [Description("نتیجه نهایی دولت روی پیشنهاد")]
        [DisplayName("نتیجه نهایی")]
        [Category("")]
        [DocumentAttributeID("9034")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail ApprovalType
        {
            get { return _ApprovalType; }
            set { _ApprovalType = value; }
        }

        private BasicInfoDetail _RefineStatus;
        /// <summary>
        /// وضعیت تایید
        /// </summary>
        [Description("وضعیت تایید")]
        [DisplayName("وضعیت تایید")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail RefineStatus
        {
            get { return _RefineStatus; }
            set { _RefineStatus = value; }
        }
        //private Offer _CorrelateOffer;
        ///// <summary>
        ///// پیشنهاد مرتبط
        ///// </summary>
        //[Description("پیشنهاد مرتبط")]
        //[DisplayName("پیشنهاد مرتبط")]
        //[Category("")]
        //[DocumentAttributeID("9044")]
        //[Browsable(true)]
        //[IsRelationalAttribute("False")]
        //[AttributeType("Offer")]
        //[IsMiddleTableExist("False")]
        //[RelationTable("")]
        //public Offer CorrelateOffer
        //{
        //    get { return _CorrelateOffer; }
        //    set { _CorrelateOffer = value; }
        //}

        private Offers _CoOffers;
        /// <summary>
        /// پیشنهادهای مرتبط
        /// </summary>
        [Description("پیشنهادهای مرتبط")]
        [DisplayName("پیشنهادهای مرتبط")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Offers")]
        [IsMiddleTableExist("False")]
        [RelationTable("Approval_Offer_M")]
        public Offers CoOffers
        {
            get { return _CoOffers; }
            set { _CoOffers = value; }
        }

        private OrgUnits _ReceiverOrgUnits;
        /// <summary>
        /// ارگانهای گیرنده مصوبه
        /// </summary>
        [Description("ارگانهای گیرنده مصوبه")]
        [DisplayName("ارگانهای گیرنده مصوبه")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("OrgUnits")]
        [IsMiddleTableExist("False")]
        [RelationTable("Approval_ReceiverOrgunit")]
        public OrgUnits ReceiverOrgUnits
        {
            get { return _ReceiverOrgUnits; }
            set { _ReceiverOrgUnits = value; }
        }

        

        private GovSession _CorrelateSession;
        /// <summary>
        /// جلسه منجر به نتیجه نهایی
        /// </summary>
        [Description("جلسه منجر به نتیجه نهایی")]
        [DisplayName("جلسه منجر به نتیجه نهایی")]
        [Category("")]
        [DocumentAttributeID("9057")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("GovSession")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public GovSession CorrelateSession
        {
            get { return _CorrelateSession; }
            set { _CorrelateSession = value; }
        }
        private AnnotationPictures _AnnotationPictures;
        /// <summary>
        /// تصاویر یادداشتها
        /// </summary>
        [Description("تصاویر یادداشتها")]
        [DisplayName("یادداشتها")]
        [Category("")]
        [DocumentAttributeID("9342")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("AnnotationPictures")]
        [IsMiddleTableExist("False")]
        [RelationTable("APPROVALLETTER_ANNPICS_M")]
        public AnnotationPictures AnnotationPictures
        {
            get { return _AnnotationPictures; }
            set { _AnnotationPictures = value; }
        }
        private BasicInfoDetail _AgainstCommResultType;
        /// <summary>
        /// وضعیت نسبت به نظر کمیسیون
        /// </summary>
        [Description("وضعیت نسبت به نظر کمیسیون")]
        [DisplayName("وضعیت نسبت به نظر کمیسیون")]
        [Category("")]
        [DocumentAttributeID("9295")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail AgainstCommResultType
        {
            get { return _AgainstCommResultType; }
            set { _AgainstCommResultType = value; }
        }
        private CommissionSession _CorrelateCommSession;
        /// <summary>
        /// جلسه کمیسیون منجر به نتیجه نهایی برای پیشنهادات عادی
        /// </summary>
        [Description("جلسه کمیسیون منجر به نتیجه نهایی برای پیشنهادات عادی")]
        [DisplayName("جلسه کمیسیون منجر به نتیجه نهایی")]
        [Category("")]
        [DocumentAttributeID("9303")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("CommissionSession")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public CommissionSession CorrelateCommSession
        {
            get { return _CorrelateCommSession; }
            set { _CorrelateCommSession = value; }
        }
        private GovCommuniquePursuits _Pursuits;
        /// <summary>
        /// پیگیریها
        /// </summary>
        [Description("پیگیریها")]
        [DisplayName("پیگیریها")]
        [Category("")]
        [DocumentAttributeID("9329")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("GovCommuniquePursuits")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public GovCommuniquePursuits Pursuits
        {
            get { return _Pursuits; }
            set { _Pursuits = value; }
        }
        private GeneralDocument _WordDoc;
        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("مستند تایپی")]
        [DisplayName("مستند تایپی")]
        [Category("")]
        [DocumentAttributeID("9355")]
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
        private Letters _OtherLetters;
        /// <summary>
        /// نامه ها
        /// </summary>
        [Description("نامه ها")]
        [DisplayName("نامه های مرتبط")]
        [Category("")]
        [DocumentAttributeID("27256")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Letters")]
        [IsMiddleTableExist("False")]
        [RelationTable("Approval_Letter_M")]
        public Letters OtherLetters
        {
            get { return _OtherLetters; }
            set { _OtherLetters = value; }
        }
        private Precepts _Precepts;
        /// <summary>
        /// احکام مرتبط
        /// </summary>
        [Description("احکام مرتبط")]
        [DisplayName("احکام")]
        [Category("")]
        [DocumentAttributeID("27257")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Precepts")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Precepts Precepts
        {
            get { return _Precepts; }
            set { _Precepts = value; }
        }
        private ApprovallChanges _Changes;
        /// <summary>
        /// تغییرات مصوبه
        /// </summary>
        [Description("تغییرات مصوبه")]
        [DisplayName("تغییرات مصوبه")]
        [Category("")]
        [DocumentAttributeID("27279")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("ApprovallChanges")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public ApprovallChanges Changes
        {
            get { return _Changes; }
            set { _Changes = value; }
        }

        private SbnBoolean _IsReplace = SbnBoolean.OutOfValue;
        /// <summary>
        /// جایگزین شده
        /// </summary>
        [Description("جایگزین شده")]
        [DisplayName("جایگزین شده")]
        [Category("")]
        [DocumentAttributeID("27269")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsReplace
        {
            get { return _IsReplace; }
            set { _IsReplace = value; }
        }
        private SbnBoolean _IsEdit = SbnBoolean.OutOfValue;
        /// <summary>
        /// اصلاح شده
        /// </summary>
        [Description("اصلاح شده")]
        [DisplayName("اصلاح شده")]
        [Category("")]
        [DocumentAttributeID("27270")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsEdit
        {
            get { return _IsEdit; }
            set { _IsEdit = value; }
        }
        private SbnBoolean _IsCancel = SbnBoolean.OutOfValue;
        /// <summary>
        /// لغو مصوبه
        /// </summary>
        [Description("لغو مصوبه")]
        [DisplayName("لغو مصوبه")]
        [Category("")]
        [DocumentAttributeID("27272")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsCancel
        {
            get { return _IsCancel; }
            set { _IsCancel = value; }
        }
        private Letter _CoLegalLetter;
        /// <summary>
        /// نامه عدم مغایرت
        /// </summary>
        [Description("نامه عدم مغایرت")]
        [DisplayName("نامه عدم مغایرت")]
        [Category("")]
        [DocumentAttributeID("27281")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Letter")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Letter CoLegalLetter
        {
            get { return _CoLegalLetter; }
            set { _CoLegalLetter = value; }
        }
        private SbnBoolean _NewsLetterPublish = SbnBoolean.OutOfValue;
        /// <summary>
        /// انتشار در روزنامه رسمی
        /// </summary>
        [Description("انتشار در روزنامه رسمی")]
        [DisplayName("روزنامه رسمی")]
        [Category("")]
        [DocumentAttributeID("27282")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean NewsLetterPublish
        {
            get { return _NewsLetterPublish; }
            set { _NewsLetterPublish = value; }
        }

        private SbnBoolean _IsTMUError = SbnBoolean.OutOfValue;
        /// <summary>
        /// انتشار در روزنامه رسمی
        /// </summary>
        [Description("خطا هنگام فراخوانی سرویس پردازش متون")]
        [DisplayName("خطای فراخوانی پردازش متون")]
        [Category("")]
        [DocumentAttributeID("27283")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsTMUError
        {
            get { return _IsTMUError; }
            set { _IsTMUError = value; }
        }

        //private Boolean _printState = false;
        ///// <summary>
        ///// وضعیت پرینت
        ///// </summary>
        //[Description("وضعیت پرینت")]
        //[DisplayName("وضعیت پرینت")]
        //[Category("")]
        //[DocumentAttributeID("")]
        //[Browsable(true)]
        //[IsRelationalAttribute("False")]
        //[AttributeType("Boolean")]
        //[IsMiddleTableExist("False")]
        //[RelationTable("")]
        //public Boolean PrintState
        //{
        //    get { return _printState; }
        //    set { _printState = value; }
        //}
        public override string ToString()
        {
            try
            {
                string strResult = "";


                if (this.ApprovalType != null && this.ApprovalType.ID > 0)
                    strResult += this.ApprovalType.ToString() + " ";

                if (this.CorrelateLetter != null && this.CorrelateLetter.ID != -1)
                {
                    strResult += this.CorrelateLetter.ToString();
                }
                else
                {
                    strResult += "فاقد نامه";
                }

                if (this.CorrelateCommSession != null && this.CorrelateCommSession.ID > 0)
                    strResult += " جلسه" + this.CorrelateCommSession.ToString();

                if (this.CorrelateSession != null && this.CorrelateSession.ID > 0)
                    strResult += " جلسه" + this.CorrelateSession.ToString();



                return strResult;
            }
            catch
            {
                return "خطا در نامه مرتبط";
            }
        }
        public override void Initialize()
        {
            base.Initialize();
            this._Duration = "";
            this._ResultText = "";
            this._PublishDate = "";
            this._NewsPaperNumber = 0;
            this._CorrelateLetter = new Letter();
            this._ApprovalType = new BasicInfoDetail();
            //this._CorrelateOffer = new Offer();
            this._CorrelateSession = new GovSession();
            this._AnnotationPictures = new AnnotationPictures();
            this._AgainstCommResultType = new BasicInfoDetail();
            this._CorrelateCommSession = new CommissionSession();
            this._Pursuits = new GovCommuniquePursuits();
            this._WordDoc = new GeneralDocument();
            this._OtherLetters = new Letters();
            this._Precepts = new Precepts();
            this._Changes = new ApprovallChanges();
            this._IsReplace = SbnBoolean.OutOfValue;
            this._RefineStatus = new BasicInfoDetail();
            this._IsEdit = SbnBoolean.OutOfValue;
            this._IsCancel = SbnBoolean.OutOfValue;
            this._CoLegalLetter = new Letter();
            this._NewsLetterPublish = SbnBoolean.OutOfValue;
            //this._printState = false;

            this._Sensitivity = new BasicInfoDetail();

            this._WordDocReportDescription = new GeneralDocument();
        }
        public override SbnObject Clone(string sNodeName)
        {
            ApprovalLetter retObject = new ApprovalLetter(this);
            retObject.Duration = this._Duration;
            if (this._ResultText != null) retObject.ResultText = (string)this._ResultText.Clone();
            if (this._PublishDate != null) retObject.PublishDate = (string)this._PublishDate.Clone();
            retObject.NewsPaperNumber = this._NewsPaperNumber;
            if (!object.ReferenceEquals(this.CorrelateLetter, null))
                retObject.CorrelateLetter = (Letter)this.CorrelateLetter.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ApprovalType, null))
                retObject.ApprovalType = (BasicInfoDetail)this.ApprovalType.Clone(sNodeName);
            //if (!object.ReferenceEquals(this.CorrelateOffer, null))
            //    retObject.CorrelateOffer = (Offer)this.CorrelateOffer.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CorrelateSession, null))
                retObject.CorrelateSession = (GovSession)this.CorrelateSession.Clone(sNodeName);
            if (!object.ReferenceEquals(this.AnnotationPictures, null))
                retObject.AnnotationPictures = (AnnotationPictures)this.AnnotationPictures.Clone(sNodeName);
            if (!object.ReferenceEquals(this.AgainstCommResultType, null))
                retObject.AgainstCommResultType = (BasicInfoDetail)this.AgainstCommResultType.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CorrelateCommSession, null))
                retObject.CorrelateCommSession = (CommissionSession)this.CorrelateCommSession.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Pursuits, null))
                retObject.Pursuits = (GovCommuniquePursuits)this.Pursuits.Clone(sNodeName);
            if (!object.ReferenceEquals(this.WordDoc, null))
                retObject.WordDoc = (GeneralDocument)this.WordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this.OtherLetters, null))
                retObject.OtherLetters = (Letters)this.OtherLetters.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoOffers, null))
                retObject.CoOffers = (Offers)this.CoOffers.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ReceiverOrgUnits, null))
                retObject.ReceiverOrgUnits = (OrgUnits)this.ReceiverOrgUnits.Clone(sNodeName);
           
            if (!object.ReferenceEquals(this.Precepts, null))
                retObject.Precepts = (Precepts)this.Precepts.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Changes, null))
                retObject.Changes = (ApprovallChanges)this.Changes.Clone(sNodeName);
            retObject.IsReplace = this.IsReplace;
            if (!object.ReferenceEquals(this.RefineStatus, null))
                retObject.RefineStatus = (BasicInfoDetail)this.RefineStatus.Clone(sNodeName);
            retObject.IsEdit = this.IsEdit;
            retObject.IsCancel = this.IsCancel;
            if (!object.ReferenceEquals(this.CoLegalLetter, null))
                retObject.CoLegalLetter = (Letter)this.CoLegalLetter.Clone(sNodeName);
            retObject.NewsLetterPublish = this.NewsLetterPublish;
            //retObject.PrintState = this.PrintState;

            if (!object.ReferenceEquals(this.Sensitivity, null))
                retObject.Sensitivity = (BasicInfoDetail)this.Sensitivity.Clone(sNodeName);

            if (!object.ReferenceEquals(this.WordDocReportDescription, null))
                retObject.WordDocReportDescription = (GeneralDocument)this.WordDocReportDescription.Clone(sNodeName);

            return retObject;
        }

        public static string at_WordDocReportDescriptionID
        {
            get
            {
                return "ApprovalLetter.WordDocReportDescriptionID";
            }
        }
        public static string at_WordDocReportDescriptionTitle
        {
            get
            {
                return "ApprovalLetter.WordDocReportDescription.Title";
            }
        }
        public static string at_WordDocReportDescriptionFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.WordDocReportDescriptionFirstLevelAttributes";
            }
        }

        public static string at_SensitivityID
        {
            get
            {
                return "ApprovalLetter.SensitivityID";
            }
        }
        public static string at_SensitivityTitle
        {
            get
            {
                return "ApprovalLetter.Sensitivity.Title";
            }
        }
        public static string at_SensitivityFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.SensitivityFirstLevelAttributes";
            }
        }
        public static string at_Sensitivity_OrderInList
        {
            get
            {
                return "ApprovalLetter.Sensitivity.OrderInList";
            }
        }
        public static string at_Sensitivity_ParentFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.Sensitivity.ParentFirstLevelAttributes";
            }
        }

        public static string at_Duration
        {
            get
            {
                return "ApprovalLetter.Duration";
            }
        }
        public static string at_ResultText
        {
            get
            {
                return "ApprovalLetter.ResultText";
            }
        }
        public static string at_PublishDate
        {
            get
            {
                return "ApprovalLetter.PublishDate";
            }
        }
        public static string at_NewsPaperNumber
        {
            get
            {
                return "ApprovalLetter.NewsPaperNumber";
            }
        }
        public static string at_CorrelateLetterID
        {
            get
            {
                return "ApprovalLetter.CorrelateLetterID";
            }
        }
        public static string at_CorrelateLetterTitle
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.Title";
            }
        }
        public static string at_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetterFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_Year
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.Year";
            }
        }
        public static string at_CorrelateLetter_SenderNumber
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.SenderNumber";
            }
        }
        public static string at_CorrelateLetter_Abstract
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.Abstract";
            }
        }
        public static string at_CorrelateLetter_OfficialCode
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.OfficialCode";
            }
        }
        public static string at_CorrelateLetter_LetterDate
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.LetterDate";
            }
        }
        public static string at_CorrelateLetter_Text
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.Text";
            }
        }
        public static string at_CorrelateLetter_CentralOfficialCode
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.CentralOfficialCode";
            }
        }
        public static string at_CorrelateLetter_References
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.References";
            }
        }
        public static string at_CorrelateLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.SenderFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_LetterTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.LetterTypeFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.FlowLetterFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.ReceiptTypeFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.ReferenceLetterFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.RecipientsFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_SensitivityFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.SensitivityFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.LetterPicturesFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.WordDocFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.OfficialTypeFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.CorrelateOfferFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.ActionTypeFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.AttachmentsFirstLevelAttributes";
            }
        }
        public static string at_CorrelateLetter_CoOffersFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateLetter.CoOffersFirstLevelAttributes";
            }
        }
        public static string at_ApprovalTypeID
        {
            get
            {
                return "ApprovalLetter.ApprovalTypeID";
            }
        }
        public static string at_ApprovalTypeTitle
        {
            get
            {
                return "ApprovalLetter.ApprovalType.Title";
            }
        }
        public static string at_ApprovalTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.ApprovalTypeFirstLevelAttributes";
            }
        }
        public static string at_ApprovalType_OrderInList
        {
            get
            {
                return "ApprovalLetter.ApprovalType.OrderInList";
            }
        }
        public static string at_ApprovalType_ParentFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.ApprovalType.ParentFirstLevelAttributes";
            }
        }

        public static string at_RefineStatusID
        {
            get
            {
                return "ApprovalLetter.RefineStatusID";
            }
        }
        public static string at_RefineStatusTitle
        {
            get
            {
                return "ApprovalLetter.RefineStatus.Title";
            }
        }
        public static string at_RefineStatusFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.RefineStatusFirstLevelAttributes";
            }
        }
        public static string at_RefineStatus_OrderInList
        {
            get
            {
                return "ApprovalLetter.RefineStatus.OrderInList";
            }
        }
        public static string at_RefineStatus_ParentFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.RefineStatus.ParentFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionID
        {
            get
            {
                return "ApprovalLetter.CorrelateSessionID";
            }
        }
        public static string at_CorrelateSessionTitle
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.Title";
            }
        }
        public static string at_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateSessionFirstLevelAttributes";
            }
        }
        public static string at_CorrelateSession_SessionDate
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.SessionDate";
            }
        }
        public static string at_CorrelateSession_SessionTime
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.SessionTime";
            }
        }
        public static string at_CorrelateSession_FinishTime
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.FinishTime";
            }
        }
        public static string at_CorrelateSession_StartTime
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.StartTime";
            }
        }
        public static string at_CorrelateSession_LocationAddress
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.LocationAddress";
            }
        }
        public static string at_CorrelateSession_MembersFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.MembersFirstLevelAttributes";
            }
        }
        public static string at_CorrelateSession_CataloguesFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.CataloguesFirstLevelAttributes";
            }
        }
        public static string at_CorrelateSession_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.CorrelateOffersFirstLevelAttributes";
            }
        }
        public static string at_CorrelateSession_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.SessionOrderFirstLevelAttributes";
            }
        }
        public static string at_CorrelateSession_PreOrdersFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.PreOrdersFirstLevelAttributes";
            }
        }
        public static string at_CorrelateSession_PresentationsFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.PresentationsFirstLevelAttributes";
            }
        }
        public static string at_CorrelateSession_OrganAnnouncementFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.OrganAnnouncementFirstLevelAttributes";
            }
        }
        public static string at_CorrelateSession_CoLettersFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateSession.CoLettersFirstLevelAttributes";
            }
        }
        public static string at_AnnotationPicturesID
        {
            get
            {
                return "ApprovalLetter.AnnotationPicturesID";
            }
        }
        public static string at_AnnotationPicturesTitle
        {
            get
            {
                return "ApprovalLetter.AnnotationPictures.Title";
            }
        }
        public static string at_AnnotationPicturesFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.AnnotationPicturesFirstLevelAttributes";
            }
        }
        public static string at_AgainstCommResultTypeID
        {
            get
            {
                return "ApprovalLetter.AgainstCommResultTypeID";
            }
        }
        public static string at_AgainstCommResultTypeTitle
        {
            get
            {
                return "ApprovalLetter.AgainstCommResultType.Title";
            }
        }
        public static string at_AgainstCommResultTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.AgainstCommResultTypeFirstLevelAttributes";
            }
        }
        public static string at_AgainstCommResultType_OrderInList
        {
            get
            {
                return "ApprovalLetter.AgainstCommResultType.OrderInList";
            }
        }
        public static string at_AgainstCommResultType_ParentFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.AgainstCommResultType.ParentFirstLevelAttributes";
            }
        }
        public static string at_CorrelateCommSessionID
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSessionID";
            }
        }
        public static string at_CorrelateCommSessionTitle
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.Title";
            }
        }
        public static string at_CorrelateCommSessionFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSessionFirstLevelAttributes";
            }
        }
        public static string at_CorrelateCommSession_SessionDate
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.SessionDate";
            }
        }
        public static string at_CorrelateCommSession_Duration
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.Duration";
            }
        }
        public static string at_CorrelateCommSession_StartTime
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.StartTime";
            }
        }
        public static string at_CorrelateCommSession_FinishTime
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.FinishTime";
            }
        }
        public static string at_CorrelateCommSession_SessionTime
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.SessionTime";
            }
        }
        public static string at_CorrelateCommSession_LocationAddress
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.LocationAddress";
            }
        }
        public static string at_CorrelateCommSession_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.CorrelateCommissionFirstLevelAttributes";
            }
        }
        public static string at_CorrelateCommSession_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.CorrelateOffersFirstLevelAttributes";
            }
        }
        public static string at_CorrelateCommSession_MembersFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.MembersFirstLevelAttributes";
            }
        }
        public static string at_CorrelateCommSession_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.SessionOrderFirstLevelAttributes";
            }
        }
        public static string at_CorrelateCommSession_CommissionSessionTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.CommissionSessionTypeFirstLevelAttributes";
            }
        }
        public static string at_CorrelateCommSession_CoLettersFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CorrelateCommSession.CoLettersFirstLevelAttributes";
            }
        }
        public static string at_PursuitsID
        {
            get
            {
                return "ApprovalLetter.PursuitsID";
            }
        }
        public static string at_PursuitsTitle
        {
            get
            {
                return "ApprovalLetter.Pursuits.Title";
            }
        }
        public static string at_PursuitsFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.PursuitsFirstLevelAttributes";
            }
        }
        public static string at_WordDocID
        {
            get
            {
                return "ApprovalLetter.WordDocID";
            }
        }
        public static string at_WordDocTitle
        {
            get
            {
                return "ApprovalLetter.WordDoc.Title";
            }
        }
        public static string at_WordDocFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.WordDocFirstLevelAttributes";
            }
        }
        public static string at_WordDoc_CorrelateObjectID
        {
            get
            {
                return "ApprovalLetter.WordDoc.CorrelateObjectID";
            }
        }
        public static string at_WordDoc_Title
        {
            get
            {
                return "ApprovalLetter.WordDoc.Title";
            }
        }
        public static string at_WordDoc_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.WordDoc.DocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_WordDoc_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.WordDoc.CorrelateOfferFirstLevelAttributes";
            }
        }
        public static string at_WordDoc_FileVersionsFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.WordDoc.FileVersionsFirstLevelAttributes";
            }
        }
        public static string at_WordDoc_OwnerFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.WordDoc.OwnerFirstLevelAttributes";
            }
        }
        public static string at_WordDoc_CorrelateFolderFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.WordDoc.CorrelateFolderFirstLevelAttributes";
            }
        }
        public static string at_OtherLettersID
        {
            get
            {
                return "ApprovalLetter.OtherLettersID";
            }
        }
        public static string at_OtherLettersTitle
        {
            get
            {
                return "ApprovalLetter.OtherLetters.Title";
            }
        }
        public static string at_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.OtherLettersFirstLevelAttributes";
            }
        }


        public static string at_CoOffersTitle
        {
            get
            {
                return "ApprovalLetter.CoOffers.Title";
            }
        }
        public static string at_CoOffersFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoOffersFirstLevelAttributes";
            }
        }

        public static string at_ReceiverOrgUnitsTitle
        {
            get
            {
                return "ApprovalLetter.ReceiverOrgUnits.Title";
            }
        }
        public static string at_ReceiverOrgUnitsFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.ReceiverOrgUnitsFirstLevelAttributes";
            }
        }

       

        public static string at_PreceptsID
        {
            get
            {
                return "ApprovalLetter.PreceptsID";
            }
        }
        public static string at_PreceptsTitle
        {
            get
            {
                return "ApprovalLetter.Precepts.Title";
            }
        }
        public static string at_PreceptsFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.PreceptsFirstLevelAttributes";
            }
        }
        public static string at_ChangesID
        {
            get
            {
                return "ApprovalLetter.ChangesID";
            }
        }
        public static string at_ChangesTitle
        {
            get
            {
                return "ApprovalLetter.Changes.Title";
            }
        }
        public static string at_ChangesFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.ChangesFirstLevelAttributes";
            }
        }
        public static string at_IsReplace
        {
            get
            {
                return "ApprovalLetter.IsReplace";
            }
        }
        public static string at_IsEdit
        {
            get
            {
                return "ApprovalLetter.IsEdit";
            }
        }
        public static string at_IsCancel
        {
            get
            {
                return "ApprovalLetter.IsCancel";
            }
        }
        public static string at_CoLegalLetterID
        {
            get
            {
                return "ApprovalLetter.CoLegalLetterID";
            }
        }
        public static string at_CoLegalLetterTitle
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.Title";
            }
        }
        public static string at_CoLegalLetterFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetterFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_Year
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.Year";
            }
        }
        public static string at_CoLegalLetter_SenderNumber
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.SenderNumber";
            }
        }
        public static string at_CoLegalLetter_Abstract
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.Abstract";
            }
        }
        public static string at_CoLegalLetter_OfficialCode
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.OfficialCode";
            }
        }
        public static string at_CoLegalLetter_LetterDate
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.LetterDate";
            }
        }
        public static string at_CoLegalLetter_Text
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.Text";
            }
        }
        public static string at_CoLegalLetter_CentralOfficialCode
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.CentralOfficialCode";
            }
        }
        public static string at_CoLegalLetter_References
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.References";
            }
        }
        public static string at_CoLegalLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.SenderFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_LetterTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.LetterTypeFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.FlowLetterFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.ReceiptTypeFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.ReferenceLetterFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.RecipientsFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_SensitivityFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.SensitivityFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.LetterPicturesFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.WordDocFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.OfficialTypeFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.CorrelateOfferFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.ActionTypeFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.AttachmentsFirstLevelAttributes";
            }
        }
        public static string at_CoLegalLetter_CoOffersFirstLevelAttributes
        {
            get
            {
                return "ApprovalLetter.CoLegalLetter.CoOffersFirstLevelAttributes";
            }
        }
        public static string at_NewsLetterPublish
        {
            get
            {
                return "ApprovalLetter.NewsLetterPublish";
            }
        }
        public static string at_IsTMUError
        {
            get
            {
                return "ApprovalLetter.IsTMUError";
            }
        }
        //public static string at_PrintState
        //{
        //    get
        //    {
        //        return "ApprovalLetter.PrintState";
        //    }
        //}
    }
}
