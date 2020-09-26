namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ObjectCode("9051"), SystemName("GEP"), Description("دستور جلسه هيات دولت"), DisplayName("دستور جلسه هيات دولت"), ItemsType("Sbn.Products.GEP.GEPObject.GovernmentSessionOrders")]
    public class GovernmentSessionOrder : SbnObject
    {
        private Letter _CorrelateLetter;
        private string _Text;

        public GovernmentSessionOrder()
        {
        }

        public GovernmentSessionOrder(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            GovernmentSessionOrder order = new GovernmentSessionOrder {
                ID = base.ID
            };
            if (this._Text != null)
            {
                order.Text = (string) this._Text.Clone();
            }
            if (!object.ReferenceEquals(this.CorrelateLetter, null))
            {
                order.CorrelateLetter = (Letter) this.CorrelateLetter.Clone(sNodeName);
            }
            return order;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._Text = "";
            this._CorrelateLetter = new Letter();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CorrelateLetter_ActionTypeFirstLevelAttributes
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterID
        {
            get
            {
                return "GovernmentSessionOrder.CorrelateLetterID";
            }
        }

        public static string at_Text
        {
            get
            {
                return "GovernmentSessionOrder.Text";
            }
        }

        [IsRelational("False"), RelationTable(""), Browsable(true), Description("نامه مرتبط"), AttributeType("Letter"), DisplayName("نامه مرتبط"), Category(""), DocumentAttributeID("9289"), IsMiddleTableExist("False")]
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

        [AttributeType("LongText"), Browsable(true), DocumentAttributeID("9226"), IsRelational("false"), Category(""), Description("متن دستور جلسه"), DisplayName("متن دستور جلسه")]
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this._Text = value;
            }
        }
    }
}
