namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("دستور جلسه کمیسیون"), DisplayName("دستور جلسه کمیسیون"), ObjectCode("9100"), ItemsType("Sbn.Products.GEP.GEPObject.CommissionSessionOrders")]
    public class CommissionSessionOrder : SbnObject
    {
        private Letter _CorrelateLetter;
        private string _Text;

        public CommissionSessionOrder()
        {
        }

        public CommissionSessionOrder(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            CommissionSessionOrder order = new CommissionSessionOrder {
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
                return "CommissionSessionOrder.CorrelateLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionOrder.CorrelateLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionOrder.CorrelateLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionOrder.CorrelateLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionOrder.CorrelateLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionOrder.CorrelateLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionOrder.CorrelateLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionOrder.CorrelateLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionOrder.CorrelateLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionOrder.CorrelateLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionOrder.CorrelateLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "CommissionSessionOrder.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterID
        {
            get
            {
                return "CommissionSessionOrder.CorrelateLetterID";
            }
        }

        public static string at_Text
        {
            get
            {
                return "CommissionSessionOrder.Text";
            }
        }

        [Browsable(true), Description("نامه دعوت به جلسه و دستور جلسه کمیسیون"), DisplayName("نامه مرتبط"), Category(""), DocumentAttributeID("9085"), IsRelational("False"), AttributeType("Letter"), IsMiddleTableExist("False"), RelationTable("")]
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

        [Browsable(true), Description("متن دستور جلسه"), DisplayName("متن دستور جلسه"), Category(""), DocumentAttributeID("9225"), IsRelational("false"), AttributeType("LongText")]
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
