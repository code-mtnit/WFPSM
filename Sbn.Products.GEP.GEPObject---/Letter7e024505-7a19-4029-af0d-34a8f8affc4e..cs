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
using Sbn.Systems.OPS.OPSObject;
using Sbn.Systems.WMC.WMCObject;
namespace Sbn.Products.GEP.GEPObject
{
    [Description("نامه")]
    [DisplayName("نامه")]
    [ObjectCode("9052")]
    [SystemName("GEP")]
    [ItemsType("Sbn.Products.GEP.GEPObject.Letters")]
    [Serializable]
    public class Letter : SbnObject
    {
        public Letter()
            : base()
        {
        }
        public Letter(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private int _Year;
        /// <summary>
        /// سال نامه
        /// </summary>
        [Description("سال نامه")]
        [DisplayName("سال")]
        [Category("")]
        [DocumentAttributeID("9210")]
        [IsRelationalAttribute("false")]
        [AttributeType("Int")]
        [Browsable(true)]
        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        private string _SenderNumber;
        /// <summary>
        /// شماره فرستنده
        /// </summary>
        [Description("شماره فرستنده")]
        [DisplayName("شماره فرستنده")]
        [Category("")]
        [DocumentAttributeID("9214")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string SenderNumber
        {
            get { return _SenderNumber; }
            set { _SenderNumber = value; }
        }
        private string _Abstract;
        /// <summary>
        /// چکیده نامه
        /// </summary>
        [Description("چکیده نامه")]
        [DisplayName("چکیده")]
        [Category("")]
        [DocumentAttributeID("9015")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string Abstract
        {
            get { return _Abstract; }
            set { _Abstract = value; }
        }
        private string _OfficialCode;
        /// <summary>
        /// شماره نامه
        /// </summary>
        [Description("شماره نامه")]
        [DisplayName("شماره نامه")]
        [Category("")]
        [DocumentAttributeID("9016")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string OfficialCode
        {
            get { return _OfficialCode; }
            set { _OfficialCode = value; }
        }
        private string _LetterDate;
        /// <summary>
        /// تاریخ نامه
        /// </summary>
        [Description("تاریخ نامه")]
        [DisplayName("تاریخ نامه")]
        [Category("")]
        [DocumentAttributeID("9017")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string LetterDate
        {
            get { return _LetterDate; }
            set { _LetterDate = value; }
        }
        private string _Text;
        /// <summary>
        /// متن نامه
        /// </summary>
        [Description("متن نامه")]
        [DisplayName("متن")]
        [Category("")]
        [DocumentAttributeID("9012")]
        [IsRelationalAttribute("false")]
        [AttributeType("LongText")]
        [Browsable(true)]
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        private string _CentralOfficialCode;
        /// <summary>
        /// شماره نامه دبیرخانه مرکزی
        /// </summary>
        [Description("شماره نامه دبیرخانه مرکزی")]
        [DisplayName("شماره نامه")]
        [Category("")]
        [DocumentAttributeID("9031")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string CentralOfficialCode
        {
            get { return _CentralOfficialCode; }
            set { _CentralOfficialCode = value; }
        }
        private string _References;
        /// <summary>
        /// سوابق
        /// </summary>
        [Description("سوابق")]
        [DisplayName("سوابق")]
        [Category("")]
        [DocumentAttributeID("9264")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string References
        {
            get { return _References; }
            set { _References = value; }
        }
        private Personnel _Sender;
        /// <summary>
        /// فرستنده
        /// </summary>
        [Description("فرستنده")]
        [DisplayName("فرستنده")]
        [Category("")]
        [DocumentAttributeID("9032")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Personnel")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Personnel Sender
        {
            get { return _Sender; }
            set { _Sender = value; }
        }
        private BasicInfoDetail _LetterType;
        /// <summary>
        /// نوع وارده یا صادره نامه
        /// </summary>
        [Description("نوع وارده یا صادره نامه")]
        [DisplayName("صادره / وارده")]
        [Category("")]
        [DocumentAttributeID("9043")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail LetterType
        {
            get { return _LetterType; }
            set { _LetterType = value; }
        }
        private Letter _FlowLetter;
        /// <summary>
        /// شماره نامه پیرو
        /// </summary>
        [Description("شماره نامه پیرو")]
        [DisplayName("شماره نامه پیرو")]
        [Category("")]
        [DocumentAttributeID("9038")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Letter")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Letter FlowLetter
        {
            get { return _FlowLetter; }
            set { _FlowLetter = value; }
        }
        private BasicInfoDetail _ReceiptType;
        /// <summary>
        /// نوع دریافت
        /// </summary>
        [Description("نوع دریافت")]
        [DisplayName("نوع دریافت")]
        [Category("")]
        [DocumentAttributeID("9037")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail ReceiptType
        {
            get { return _ReceiptType; }
            set { _ReceiptType = value; }
        }
        private Letter _ReferenceLetter;
        /// <summary>
        /// سوابق نامه
        /// </summary>
        [Description("سوابق نامه")]
        [DisplayName("سوابق نامه")]
        [Category("")]
        [DocumentAttributeID("9039")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Letter")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Letter ReferenceLetter
        {
            get { return _ReferenceLetter; }
            set { _ReferenceLetter = value; }
        }
        private LetterRecipients _Recipients;
        /// <summary>
        /// گیرندگان
        /// </summary>
        [Description("گیرندگان")]
        [DisplayName("گیرندگان")]
        [Category("")]
        [DocumentAttributeID("9071")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("LetterRecipients")]
        [IsMiddleTableExist("True")]
        [RelationTable("LetRecvs")]
        public LetterRecipients Recipients
        {
            get { return _Recipients; }
            set { _Recipients = value; }
        }
        private BasicInfoDetail _Sensitivity;
        /// <summary>
        /// طبقه بندی نامه
        /// </summary>
        [Description("طبقه بندی نامه")]
        [DisplayName("طبقه بندی")]
        [Category("")]
        [DocumentAttributeID("9025")]
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
        private LetterPictures _LetterPictures;
        /// <summary>
        /// تصاویر نامه
        /// </summary>
        [Description("تصاویر نامه")]
        [DisplayName("تصاویر")]
        [Category("")]
        [DocumentAttributeID("9023")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("LetterPictures")]
        [IsMiddleTableExist("False")]
        [RelationTable("Letter_LetterPictures_M")]
        public LetterPictures LetterPictures
        {
            get { return _LetterPictures; }
            set { _LetterPictures = value; }
        }
        private GeneralDocument _WordDoc;
        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("مستند تایپی")]
        [DisplayName("مستند تایپی")]
        [Category("")]
        [DocumentAttributeID("9348")]
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
        private BasicInfoDetail _OfficialType;
        /// <summary>
        /// نوع نامه در دفتر هیات دولت
        /// </summary>
        [Description("نوع نامه در دفتر هیات دولت")]
        [DisplayName("نوع نامه")]
        [Category("")]
        [DocumentAttributeID("9262")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail OfficialType
        {
            get { return _OfficialType; }
            set { _OfficialType = value; }
        }
        private Offer _CorrelateOffer;
        /// <summary>
        /// پیشنهاد مرتبط با نامه
        /// </summary>
        [Description("پیشنهاد مرتبط با نامه")]
        [DisplayName("پیشنهاد مرتبط")]
        [Category("")]
        [DocumentAttributeID("9263")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Offer")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Offer CorrelateOffer
        {
            get { return _CorrelateOffer; }
            set { _CorrelateOffer = value; }
        }
        private BasicInfoDetail _ActionType;
        /// <summary>
        /// نوع اقدام روی نامه
        /// </summary>
        [Description("نوع اقدام روی نامه")]
        [DisplayName("نوع اقدام")]
        [Category("")]
        [DocumentAttributeID("9288")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail ActionType
        {
            get { return _ActionType; }
            set { _ActionType = value; }
        }
        private LetterAttachments _Attachments;
        /// <summary>
        /// ضمائم
        /// </summary>
        [Description("ضمائم")]
        [DisplayName("ضمائم")]
        [Category("ضمائم")]
        [DocumentAttributeID("27073")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("LetterAttachments")]
        [IsMiddleTableExist("False")]
        [RelationTable("LETTER_ATTACHMENTS_M")]
        public LetterAttachments Attachments
        {
            get { return _Attachments; }
            set { _Attachments = value; }
        }
        private Offers _CoOffers;
        /// <summary>
        /// پیشنهاد مرتبط
        /// </summary>
        [Description("پیشنهاد مرتبط")]
        [DisplayName("پیشنهاد مرتبط")]
        [Category("")]
        [DocumentAttributeID("27280")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Offers")]
        [IsMiddleTableExist("False")]
        [RelationTable("OFFER_OTHERLETTERS_M")]
        public Offers CoOffers
        {
            get { return _CoOffers; }
            set { _CoOffers = value; }
        }

        string _LetterNO;
        [Description("رشته شماره نامه")]
        [DisplayName("رشته شماره نامه")]
        [Category("")]
        [DocumentAttributeID("")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string LetterNO
        {
            get { return _LetterNO; }
            set { _LetterNO = value; }
        }

        public override string ToString()
        {
            if (object.ReferenceEquals(this.OfficialCode, null) || this.OfficialCode == "")
                return "فاقد شماره نامه";
            else
                return this.OfficialCode;

        }
        public override void Initialize()
        {
            base.Initialize();
            this._Year = 0;
            this._SenderNumber = "";
            this._Abstract = "";
            this._OfficialCode = "";
            this._LetterDate = "";
            this._Text = "";
            this._CentralOfficialCode = "";
            this._References = "";
            this._Sender = new Personnel();
            this._LetterType = new BasicInfoDetail();
            this._FlowLetter = new Letter();
            this._ReceiptType = new BasicInfoDetail();
            this._ReferenceLetter = new Letter();
            this._Recipients = new LetterRecipients();
            this._Sensitivity = new BasicInfoDetail();
            this._LetterPictures = new LetterPictures();
            this._WordDoc = new GeneralDocument();
            this._OfficialType = new BasicInfoDetail();
            this._CorrelateOffer = new Offer();
            this._ActionType = new BasicInfoDetail();
            this._Attachments = new LetterAttachments();
            this._CoOffers = new Offers();
            this.LetterNO = "";
        }
        public override SbnObject Clone(string sNodeName)
        {
            Letter retObject = new Letter(this);
            retObject.Year = this._Year;
            retObject.SenderNumber = this._SenderNumber;
            retObject.Abstract = this._Abstract;
            retObject.OfficialCode = this._OfficialCode;
            if (this._LetterDate != null)
                retObject.LetterDate = (string)this._LetterDate.Clone();
            if (this._Text != null)
                retObject.Text = (string)this._Text.Clone();
            retObject.CentralOfficialCode = this._CentralOfficialCode;
            retObject.References = this._References;
            if (!object.ReferenceEquals(this.Sender, null))
                retObject.Sender = (Personnel)this.Sender.Clone(sNodeName);
            if (!object.ReferenceEquals(this.LetterType, null))
                retObject.LetterType = (BasicInfoDetail)this.LetterType.Clone(sNodeName);
            if (!object.ReferenceEquals(this.FlowLetter, null))
                retObject.FlowLetter = (Letter)this.FlowLetter.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ReceiptType, null))
                retObject.ReceiptType = (BasicInfoDetail)this.ReceiptType.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ReferenceLetter, null))
                retObject.ReferenceLetter = (Letter)this.ReferenceLetter.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Recipients, null))
                retObject.Recipients = (LetterRecipients)this.Recipients.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Sensitivity, null))
                retObject.Sensitivity = (BasicInfoDetail)this.Sensitivity.Clone(sNodeName);
            if (!object.ReferenceEquals(this.LetterPictures, null))
                retObject.LetterPictures = (LetterPictures)this.LetterPictures.Clone(sNodeName);
            if (!object.ReferenceEquals(this.WordDoc, null))
                retObject.WordDoc = (GeneralDocument)this.WordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this.OfficialType, null))
                retObject.OfficialType = (BasicInfoDetail)this.OfficialType.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CorrelateOffer, null))
                retObject.CorrelateOffer = (Offer)this.CorrelateOffer.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ActionType, null))
                retObject.ActionType = (BasicInfoDetail)this.ActionType.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Attachments, null))
                retObject.Attachments = (LetterAttachments)this.Attachments.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoOffers, null))
                retObject.CoOffers = (Offers)this.CoOffers.Clone(sNodeName);
            retObject.LetterNO = _LetterNO;
            return retObject;
        }
        public static string at_Year
        {
            get
            {
                return "Letter.Year";
            }
        }
        public static string at_SenderNumber
        {
            get
            {
                return "Letter.SenderNumber";
            }
        }
        public static string at_Abstract
        {
            get
            {
                return "Letter.Abstract";
            }
        }
        public static string at_OfficialCode
        {
            get
            {
                return "Letter.OfficialCode";
            }
        }
        public static string at_LetterDate
        {
            get
            {
                return "Letter.LetterDate";
            }
        }
        public static string at_Text
        {
            get
            {
                return "Letter.Text";
            }
        }
        public static string at_CentralOfficialCode
        {
            get
            {
                return "Letter.CentralOfficialCode";
            }
        }
        public static string at_References
        {
            get
            {
                return "Letter.References";
            }
        }
        public static string at_SenderID
        {
            get
            {
                return "Letter.SenderID";
            }
        }
        public static string at_SenderTitle
        {
            get
            {
                return "Letter.Sender.Title";
            }
        }
        public static string at_SenderFirstLevelAttributes
        {
            get
            {
                return "Letter.SenderFirstLevelAttributes";
            }
        }
        public static string at_Sender_PersonnelCode
        {
            get
            {
                return "Letter.Sender.PersonnelCode";
            }
        }
        public static string at_Sender_PersonnelInterdictsFirstLevelAttributes
        {
            get
            {
                return "Letter.Sender.PersonnelInterdictsFirstLevelAttributes";
            }
        }
        public static string at_Sender_PersonFirstLevelAttributes
        {
            get
            {
                return "Letter.Sender.PersonFirstLevelAttributes";
            }
        }
        public static string at_LetterTypeID
        {
            get
            {
                return "Letter.LetterTypeID";
            }
        }
        public static string at_LetterTypeTitle
        {
            get
            {
                return "Letter.LetterType.Title";
            }
        }
        public static string at_LetterTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.LetterTypeFirstLevelAttributes";
            }
        }
        public static string at_LetterType_OrderInList
        {
            get
            {
                return "Letter.LetterType.OrderInList";
            }
        }
        public static string at_LetterType_ParentFirstLevelAttributes
        {
            get
            {
                return "Letter.LetterType.ParentFirstLevelAttributes";
            }
        }
        public static string at_FlowLetterID
        {
            get
            {
                return "Letter.FlowLetterID";
            }
        }
        public static string at_FlowLetterTitle
        {
            get
            {
                return "Letter.FlowLetter.Title";
            }
        }
        public static string at_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetterFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_Year
        {
            get
            {
                return "Letter.FlowLetter.Year";
            }
        }
        public static string at_FlowLetter_SenderNumber
        {
            get
            {
                return "Letter.FlowLetter.SenderNumber";
            }
        }
        public static string at_FlowLetter_Abstract
        {
            get
            {
                return "Letter.FlowLetter.Abstract";
            }
        }
        public static string at_FlowLetter_OfficialCode
        {
            get
            {
                return "Letter.FlowLetter.OfficialCode";
            }
        }
        public static string at_FlowLetter_LetterDate
        {
            get
            {
                return "Letter.FlowLetter.LetterDate";
            }
        }
        public static string at_FlowLetter_Text
        {
            get
            {
                return "Letter.FlowLetter.Text";
            }
        }
        public static string at_FlowLetter_CentralOfficialCode
        {
            get
            {
                return "Letter.FlowLetter.CentralOfficialCode";
            }
        }
        public static string at_FlowLetter_References
        {
            get
            {
                return "Letter.FlowLetter.References";
            }
        }
        public static string at_FlowLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.SenderFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_LetterTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.LetterTypeFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.FlowLetterFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.ReceiptTypeFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.ReferenceLetterFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.RecipientsFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_SensitivityFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.SensitivityFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.LetterPicturesFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.WordDocFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.OfficialTypeFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.CorrelateOfferFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.ActionTypeFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.AttachmentsFirstLevelAttributes";
            }
        }
        public static string at_FlowLetter_CoOffersFirstLevelAttributes
        {
            get
            {
                return "Letter.FlowLetter.CoOffersFirstLevelAttributes";
            }
        }
        public static string at_ReceiptTypeID
        {
            get
            {
                return "Letter.ReceiptTypeID";
            }
        }
        public static string at_ReceiptTypeTitle
        {
            get
            {
                return "Letter.ReceiptType.Title";
            }
        }
        public static string at_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.ReceiptTypeFirstLevelAttributes";
            }
        }
        public static string at_ReceiptType_OrderInList
        {
            get
            {
                return "Letter.ReceiptType.OrderInList";
            }
        }
        public static string at_ReceiptType_ParentFirstLevelAttributes
        {
            get
            {
                return "Letter.ReceiptType.ParentFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetterID
        {
            get
            {
                return "Letter.ReferenceLetterID";
            }
        }
        public static string at_ReferenceLetterTitle
        {
            get
            {
                return "Letter.ReferenceLetter.Title";
            }
        }
        public static string at_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetterFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_Year
        {
            get
            {
                return "Letter.ReferenceLetter.Year";
            }
        }
        public static string at_ReferenceLetter_SenderNumber
        {
            get
            {
                return "Letter.ReferenceLetter.SenderNumber";
            }
        }
        public static string at_ReferenceLetter_Abstract
        {
            get
            {
                return "Letter.ReferenceLetter.Abstract";
            }
        }
        public static string at_ReferenceLetter_OfficialCode
        {
            get
            {
                return "Letter.ReferenceLetter.OfficialCode";
            }
        }
        public static string at_ReferenceLetter_LetterDate
        {
            get
            {
                return "Letter.ReferenceLetter.LetterDate";
            }
        }
        public static string at_ReferenceLetter_Text
        {
            get
            {
                return "Letter.ReferenceLetter.Text";
            }
        }
        public static string at_ReferenceLetter_CentralOfficialCode
        {
            get
            {
                return "Letter.ReferenceLetter.CentralOfficialCode";
            }
        }
        public static string at_ReferenceLetter_References
        {
            get
            {
                return "Letter.ReferenceLetter.References";
            }
        }
        public static string at_ReferenceLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.SenderFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_LetterTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.LetterTypeFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.FlowLetterFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.ReceiptTypeFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.ReferenceLetterFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.RecipientsFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_SensitivityFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.SensitivityFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.LetterPicturesFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.WordDocFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.OfficialTypeFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.CorrelateOfferFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.ActionTypeFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.AttachmentsFirstLevelAttributes";
            }
        }
        public static string at_ReferenceLetter_CoOffersFirstLevelAttributes
        {
            get
            {
                return "Letter.ReferenceLetter.CoOffersFirstLevelAttributes";
            }
        }
        public static string at_RecipientsID
        {
            get
            {
                return "Letter.RecipientsID";
            }
        }
        public static string at_RecipientsTitle
        {
            get
            {
                return "Letter.Recipients.Title";
            }
        }
        public static string at_RecipientsFirstLevelAttributes
        {
            get
            {
                return "Letter.RecipientsFirstLevelAttributes";
            }
        }
        public static string at_SensitivityID
        {
            get
            {
                return "Letter.SensitivityID";
            }
        }
        public static string at_SensitivityTitle
        {
            get
            {
                return "Letter.Sensitivity.Title";
            }
        }
        public static string at_SensitivityFirstLevelAttributes
        {
            get
            {
                return "Letter.SensitivityFirstLevelAttributes";
            }
        }
        public static string at_Sensitivity_OrderInList
        {
            get
            {
                return "Letter.Sensitivity.OrderInList";
            }
        }
        public static string at_Sensitivity_ParentFirstLevelAttributes
        {
            get
            {
                return "Letter.Sensitivity.ParentFirstLevelAttributes";
            }
        }
        public static string at_LetterPicturesID
        {
            get
            {
                return "Letter.LetterPicturesID";
            }
        }
        public static string at_LetterPicturesTitle
        {
            get
            {
                return "Letter.LetterPictures.Title";
            }
        }
        public static string at_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "Letter.LetterPicturesFirstLevelAttributes";
            }
        }
        public static string at_WordDocID
        {
            get
            {
                return "Letter.WordDocID";
            }
        }
        public static string at_WordDocTitle
        {
            get
            {
                return "Letter.WordDoc.Title";
            }
        }
        public static string at_WordDocFirstLevelAttributes
        {
            get
            {
                return "Letter.WordDocFirstLevelAttributes";
            }
        }
        public static string at_WordDoc_CorrelateObjectID
        {
            get
            {
                return "Letter.WordDoc.CorrelateObjectID";
            }
        }
        public static string at_WordDoc_Title
        {
            get
            {
                return "Letter.WordDoc.Title";
            }
        }
        public static string at_WordDoc_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.WordDoc.DocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_WordDoc_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Letter.WordDoc.CorrelateOfferFirstLevelAttributes";
            }
        }
        public static string at_WordDoc_FileVersionsFirstLevelAttributes
        {
            get
            {
                return "Letter.WordDoc.FileVersionsFirstLevelAttributes";
            }
        }
        public static string at_WordDoc_OwnerFirstLevelAttributes
        {
            get
            {
                return "Letter.WordDoc.OwnerFirstLevelAttributes";
            }
        }
        public static string at_WordDoc_CorrelateFolderFirstLevelAttributes
        {
            get
            {
                return "Letter.WordDoc.CorrelateFolderFirstLevelAttributes";
            }
        }
        public static string at_OfficialTypeID
        {
            get
            {
                return "Letter.OfficialTypeID";
            }
        }
        public static string at_OfficialTypeTitle
        {
            get
            {
                return "Letter.OfficialType.Title";
            }
        }
        public static string at_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.OfficialTypeFirstLevelAttributes";
            }
        }
        public static string at_OfficialType_OrderInList
        {
            get
            {
                return "Letter.OfficialType.OrderInList";
            }
        }
        public static string at_OfficialType_ParentFirstLevelAttributes
        {
            get
            {
                return "Letter.OfficialType.ParentFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOfferID
        {
            get
            {
                return "Letter.CorrelateOfferID";
            }
        }
        public static string at_CorrelateOfferTitle
        {
            get
            {
                return "Letter.CorrelateOffer.Title";
            }
        }
        public static string at_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOfferFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_OrderInCatalogue
        {
            get
            {
                return "Letter.CorrelateOffer.OrderInCatalogue";
            }
        }
        public static string at_CorrelateOffer_OfficialCode
        {
            get
            {
                return "Letter.CorrelateOffer.OfficialCode";
            }
        }
        public static string at_CorrelateOffer_VicePresidentReceiptdate
        {
            get
            {
                return "Letter.CorrelateOffer.VicePresidentReceiptdate";
            }
        }
        public static string at_CorrelateOffer_VicePresidentLetterID
        {
            get
            {
                return "Letter.CorrelateOffer.VicePresidentLetterID";
            }
        }
        public static string at_CorrelateOffer_GovOfficeReceiptDate
        {
            get
            {
                return "Letter.CorrelateOffer.GovOfficeReceiptDate";
            }
        }
        public static string at_CorrelateOffer_RegisterDate
        {
            get
            {
                return "Letter.CorrelateOffer.RegisterDate";
            }
        }
        public static string at_CorrelateOffer_OfferRelations
        {
            get
            {
                return "Letter.CorrelateOffer.OfferRelations";
            }
        }
        public static string at_CorrelateOffer_OfferComment
        {
            get
            {
                return "Letter.CorrelateOffer.OfferComment";
            }
        }
        public static string at_CorrelateOffer_GovSessionTitle
        {
            get
            {
                return "Letter.CorrelateOffer.GovSessionTitle";
            }
        }
        public static string at_CorrelateOffer_OtherLettersFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.OtherLettersFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_ApprovalLettersFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.ApprovalLettersFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_GovernReportsFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.GovernReportsFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_InquiriesFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.InquiriesFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_StatusFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.StatusFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_GovMemberOpinionsFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.GovMemberOpinionsFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_CommissionsFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.CommissionsFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_EngineeringsFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.EngineeringsFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_LawDocumentsFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.LawDocumentsFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_CorrelateOrgansFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.CorrelateOrgansFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_OfferAbstractFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.OfferAbstractFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_OfferCommuniqueTextFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.OfferCommuniqueTextFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_UrgencyFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.UrgencyFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_OfferLetterFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.OfferLetterFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_SecurityFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.SecurityFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_ComplicationFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.ComplicationFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_ImportanceFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.ImportanceFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_OfferTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.OfferTypeFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_StatusInGovOrderOfficeFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.StatusInGovOrderOfficeFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_SubjectsFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.SubjectsFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_CommissionReportsFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.CommissionReportsFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_PreObservationFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.PreObservationFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.OwnerOrganFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_ActiveCommissionFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.ActiveCommissionFirstLevelAttributes";
            }
        }
        public static string at_CorrelateOffer_CommuniqueStatusFirstLevelAttributes
        {
            get
            {
                return "Letter.CorrelateOffer.CommuniqueStatusFirstLevelAttributes";
            }
        }
        public static string at_ActionTypeID
        {
            get
            {
                return "Letter.ActionTypeID";
            }
        }
        public static string at_ActionTypeTitle
        {
            get
            {
                return "Letter.ActionType.Title";
            }
        }
        public static string at_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "Letter.ActionTypeFirstLevelAttributes";
            }
        }
        public static string at_ActionType_OrderInList
        {
            get
            {
                return "Letter.ActionType.OrderInList";
            }
        }
        public static string at_ActionType_ParentFirstLevelAttributes
        {
            get
            {
                return "Letter.ActionType.ParentFirstLevelAttributes";
            }
        }
        public static string at_AttachmentsID
        {
            get
            {
                return "Letter.AttachmentsID";
            }
        }
        public static string at_AttachmentsTitle
        {
            get
            {
                return "Letter.Attachments.Title";
            }
        }
        public static string at_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "Letter.AttachmentsFirstLevelAttributes";
            }
        }
        public static string at_CoOffersID
        {
            get
            {
                return "Letter.CoOffersID";
            }
        }
        public static string at_CoOffersTitle
        {
            get
            {
                return "Letter.CoOffers.Title";
            }
        }
        public static string at_CoOffersFirstLevelAttributes
        {
            get
            {
                return "Letter.CoOffersFirstLevelAttributes";
            }
        }

        public static string at_LetterNO
        {
            get
            {
                return "Letter.LetterNO";
            }
        }
    }
}
