namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, Description(""), SystemName("GEP"), DisplayName(""), ObjectCode("9306")]
    public class ParliamentNotice : SbnObject
    {
        private ApprovalLetter _CoApprovalLetter;
        private Letter _CoLetter;
        private BasicInfoDetail _NoticeType;

        public ParliamentNotice()
        {
        }

        public ParliamentNotice(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            ParliamentNotice notice = new ParliamentNotice(this);
            if (!object.ReferenceEquals(this.CoApprovalLetter, null))
            {
                notice.CoApprovalLetter = (ApprovalLetter) this.CoApprovalLetter.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.NoticeType, null))
            {
                notice.NoticeType = (BasicInfoDetail) this.NoticeType.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoLetter, null))
            {
                notice.CoLetter = (Letter) this.CoLetter.Clone(sNodeName);
            }
            return notice;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._CoApprovalLetter = new ApprovalLetter();
            this._NoticeType = new BasicInfoDetail();
            this._CoLetter = new Letter();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CoApprovalLetter_AgainstCommResultTypeFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoApprovalLetter.AgainstCommResultTypeFirstLevelAttributes";
            }
        }

        public static string at_CoApprovalLetter_AnnotationPicturesFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoApprovalLetter.AnnotationPicturesFirstLevelAttributes";
            }
        }

        public static string at_CoApprovalLetter_ApprovalTypeFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoApprovalLetter.ApprovalTypeFirstLevelAttributes";
            }
        }

        public static string at_CoApprovalLetter_CorrelateCommSessionFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoApprovalLetter.CorrelateCommSessionFirstLevelAttributes";
            }
        }

        public static string at_CoApprovalLetter_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoApprovalLetter.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_CoApprovalLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoApprovalLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CoApprovalLetter_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoApprovalLetter.CorrelateSessionFirstLevelAttributes";
            }
        }

        public static string at_CoApprovalLetter_ParliamentNoticesFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoApprovalLetter.ParliamentNoticesFirstLevelAttributes";
            }
        }

        public static string at_CoApprovalLetter_PursuitsFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoApprovalLetter.PursuitsFirstLevelAttributes";
            }
        }

        public static string at_CoApprovalLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoApprovalLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CoApprovalLetterFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoApprovalLetterFirstLevelAttributes";
            }
        }

        public static string at_CoApprovalLetterID
        {
            get
            {
                return "ParliamentNotice.CoApprovalLetterID";
            }
        }

        public static string at_CoLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_LetterTypeFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.LetterTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_SensitivityFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.SensitivityFirstLevelAttributes";
            }
        }

        public static string at_CoLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CoLetterFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.CoLetterFirstLevelAttributes";
            }
        }

        public static string at_CoLetterID
        {
            get
            {
                return "ParliamentNotice.CoLetterID";
            }
        }

        public static string at_NoticeTypeFirstLevelAttributes
        {
            get
            {
                return "ParliamentNotice.NoticeTypeFirstLevelAttributes";
            }
        }

        public static string at_NoticeTypeID
        {
            get
            {
                return "ParliamentNotice.NoticeTypeID";
            }
        }

        [DocumentAttributeID("27345"), Browsable(true), RelationTable(""), DisplayName("مصوبه مرتبط"), Category(""), Description("مصوبه مرتبط"), IsRelational("False"), AttributeType("ApprovalLetter"), IsMiddleTableExist("False")]
        public ApprovalLetter CoApprovalLetter
        {
            get
            {
                return this._CoApprovalLetter;
            }
            set
            {
                this._CoApprovalLetter = value;
            }
        }

        [DocumentAttributeID("27348"), IsMiddleTableExist("False"), DisplayName("نامه مرتبط"), Category(""), Description("نامه مرتبط"), Browsable(true), IsRelational("False"), AttributeType("Letter"), RelationTable("")]
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

        [IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable(""), Browsable(true), Description("نوع ایراد"), DisplayName("نوع ایراد"), Category(""), DocumentAttributeID("27346")]
        public BasicInfoDetail NoticeType
        {
            get
            {
                return this._NoticeType;
            }
            set
            {
                this._NoticeType = value;
            }
        }
    }
}
