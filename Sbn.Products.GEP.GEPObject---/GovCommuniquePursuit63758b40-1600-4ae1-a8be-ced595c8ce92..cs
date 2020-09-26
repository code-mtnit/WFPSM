namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, ItemsType("Sbn.Products.GEP.GEPObject.GovCommuniquePursuits"), Description("پيگيري مصوبه"), DisplayName("پيگيري مصوبه"), SystemName("GEP"), ObjectCode("9262")]
    public class GovCommuniquePursuit : SbnObject
    {
        private Letter _CorrelateLetter;
        private BasicInfoDetail _ObservationQuality;
        private string _PersuitDate;
        private string _ResponseAbstract;
        private Letter _ResponseLetter;

        public GovCommuniquePursuit()
        {
        }

        public GovCommuniquePursuit(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            GovCommuniquePursuit pursuit = new GovCommuniquePursuit {
                ID = base.ID
            };
            if (this._PersuitDate != null)
            {
                pursuit.PersuitDate = (string) this._PersuitDate.Clone();
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
            this._PersuitDate = "";
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
                return "GovCommuniquePursuit.CorrelateLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.CorrelateLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.CorrelateLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.CorrelateLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.CorrelateLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.CorrelateLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.CorrelateLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.CorrelateLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.CorrelateLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.CorrelateLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.CorrelateLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterID
        {
            get
            {
                return "GovCommuniquePursuit.CorrelateLetterID";
            }
        }

        public static string at_ObservationQuality_ParentFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ObservationQuality.ParentFirstLevelAttributes";
            }
        }

        public static string at_ObservationQualityFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ObservationQualityFirstLevelAttributes";
            }
        }

        public static string at_ObservationQualityID
        {
            get
            {
                return "GovCommuniquePursuit.ObservationQualityID";
            }
        }

        public static string at_PersuitDate
        {
            get
            {
                return "GovCommuniquePursuit.PersuitDate";
            }
        }

        public static string at_ResponseAbstract
        {
            get
            {
                return "GovCommuniquePursuit.ResponseAbstract";
            }
        }

        public static string at_ResponseLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetterFirstLevelAttributes
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetterFirstLevelAttributes";
            }
        }

        public static string at_ResponseLetterID
        {
            get
            {
                return "GovCommuniquePursuit.ResponseLetterID";
            }
        }

        [DisplayName(""), Description(""), IsMiddleTableExist("False"), DocumentAttributeID("9334"), RelationTable(""), Category(""), Browsable(true), IsRelational("False"), AttributeType("Letter")]
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

        [DisplayName(""), Description(""), Category(""), DocumentAttributeID("9335"), Browsable(true), IsRelational("False"), AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable("")]
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

        [IsRelational("false"), Category(""), DocumentAttributeID("9249"), Browsable(true), DisplayName(""), AttributeType("DateString"), Description("")]
        public string PersuitDate
        {
            get
            {
                return this._PersuitDate;
            }
            set
            {
                this._PersuitDate = value;
            }
        }

        [Description(""), Category(""), DocumentAttributeID("9250"), DisplayName(""), IsRelational("false"), AttributeType("String"), Browsable(true)]
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

        [AttributeType("Letter"), IsRelational("False"), Description(""), IsMiddleTableExist("False"), RelationTable(""), Category(""), Browsable(true), DisplayName(""), DocumentAttributeID("9336")]
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
