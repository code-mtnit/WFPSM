namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, Description("پيگيري استعلام"), ItemsType("Sbn.Products.GEP.GEPObject.InquiryPursuits"), ObjectCode("9260"), SystemName("GEP"), DisplayName("پيگيري استعلام")]
    public class InquiryPursuit : SbnObject
    {
        private Letter _CorrelateLetter;
        private BasicInfoDetail _ObservationQuality;
        private string _PursuitDate;
        private string _ResponseAbstract;
        private Letter _ResponseLetter;

        public InquiryPursuit()
        {
        }

        public InquiryPursuit(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            InquiryPursuit pursuit = new InquiryPursuit {
                ID = base.ID
            };
            if (this._PursuitDate != null)
            {
                pursuit.PursuitDate = (string) this._PursuitDate.Clone();
            }
            pursuit.ResponseAbstract = this._ResponseAbstract;
            if (!object.ReferenceEquals(this.CorrelateLetter, null))
            {
                pursuit.CorrelateLetter = (Letter) this.CorrelateLetter.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.ObservationQuality, null))
            {
                pursuit.ObservationQuality = (BasicInfoDetail) this.ObservationQuality.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.ResponseLetter, null))
            {
                pursuit.ResponseLetter = (Letter) this.ResponseLetter.Clone(sNodeName);
            }
            return pursuit;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._PursuitDate = "";
            this._ResponseAbstract = "";
            this._CorrelateLetter = new Letter();
            this._ObservationQuality = new BasicInfoDetail();
            this._ResponseLetter = new Letter();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CorrelateLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.CorrelateLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.CorrelateLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.CorrelateLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.CorrelateLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.CorrelateLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.CorrelateLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.CorrelateLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.CorrelateLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.CorrelateLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.CorrelateLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.CorrelateLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterID
        {
            get
            {
                return "InquiryPursuit.CorrelateLetterID";
            }
        }

        public static string at_ObservationQuality_ParentFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ObservationQuality.ParentFirstLevelAttributes";
            }
        }

        public static string at_ObservationQualityFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ObservationQualityFirstLevelAttributes";
            }
        }

        public static string at_ObservationQualityID
        {
            get
            {
                return "InquiryPursuit.ObservationQualityID";
            }
        }

        public static string at_PursuitDate
        {
            get
            {
                return "InquiryPursuit.PursuitDate";
            }
        }

        public static string at_ResponseAbstract
        {
            get
            {
                return "InquiryPursuit.ResponseAbstract";
            }
        }

        public static string at_ResponseLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ResponseLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ResponseLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ResponseLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ResponseLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ResponseLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ResponseLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ResponseLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ResponseLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ResponseLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ResponseLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ResponseLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetterFirstLevelAttributes
        {
            get
            {
                return "InquiryPursuit.ResponseLetterFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetterID
        {
            get
            {
                return "InquiryPursuit.ResponseLetterID";
            }
        }

        [DisplayName("نامه پیگیری"), RelationTable(""), Description("نامه پیگیری"), Category(""), DocumentAttributeID("9331"), Browsable(true), IsRelational("False"), AttributeType("Letter"), IsMiddleTableExist("False")]
        public Letter CorrelateLetter
        {
            get
            {
                return this._CorrelateLetter;
            }
            set
            {
                this._CorrelateLetter = value;
            }
        }

        [Category(""), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable(""), DocumentAttributeID("9332"), DisplayName("کیفیت اجرا"), Description("کیفیت اجرای مصوبه")]
        public BasicInfoDetail ObservationQuality
        {
            get
            {
                return this._ObservationQuality;
            }
            set
            {
                this._ObservationQuality = value;
            }
        }

        [Browsable(true), IsRelational("false"), AttributeType("DateString"), Description("تاریخ پیگیری"), DisplayName("تاریخ پیگیری"), Category(""), DocumentAttributeID("9247")]
        public string PursuitDate
        {
            get
            {
                return this._PursuitDate;
            }
            set
            {
                this._PursuitDate = value;
            }
        }

        [Browsable(true), DisplayName("نتیجه پیگیری"), Category(""), DocumentAttributeID("9248"), AttributeType("String"), Description("خلاصه نتیجه پیگیری"), IsRelational("false")]
        public string ResponseAbstract
        {
            get
            {
                return this._ResponseAbstract;
            }
            set
            {
                this._ResponseAbstract = value;
            }
        }

        [DocumentAttributeID("9333"), Category(""), DisplayName("نامه پاسخ"), Browsable(true), IsRelational("False"), AttributeType("Letter"), Description("نامه پاسخ پیگیری"), IsMiddleTableExist("False"), RelationTable("")]
        public Letter ResponseLetter
        {
            get
            {
                return this._ResponseLetter;
            }
            set
            {
                this._ResponseLetter = value;
            }
        }
    }
}
