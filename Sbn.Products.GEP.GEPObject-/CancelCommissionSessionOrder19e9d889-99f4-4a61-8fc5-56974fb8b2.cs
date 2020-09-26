namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description("دستور لغو کمیسیون"), DisplayName("دستور لغو کمیسیون"), ObjectCode("9100"), ItemsType("Sbn.Products.GEP.GEPObject.CancelCommissionSessionOrders")]
    public class CancelCommissionSessionOrder : SbnObject
    {
        private Letter _CorrelateLetter;
        private string _Text;

        public CancelCommissionSessionOrder()
        {
        }

        public CancelCommissionSessionOrder(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            CancelCommissionSessionOrder order = new CancelCommissionSessionOrder
            {
                ID = base.ID
            };
            if (this._Text != null)
            {
                order.Text = (string)this._Text.Clone();
            }
            if (!object.ReferenceEquals(this.CorrelateLetter, null))
            {
                order.CorrelateLetter = (Letter)this.CorrelateLetter.Clone(sNodeName);
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
                return "CancelCommissionSessionOrder.CorrelateLetter.ActionTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "CancelCommissionSessionOrder.CorrelateLetter.AttachmentsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_CorrelateOfferFirstLevelAttributes
        {
            get
            {
                return "CancelCommissionSessionOrder.CorrelateLetter.CorrelateOfferFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_FlowLetterFirstLevelAttributes
        {
            get
            {
                return "CancelCommissionSessionOrder.CorrelateLetter.FlowLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_LetterPicturesFirstLevelAttributes
        {
            get
            {
                return "CancelCommissionSessionOrder.CorrelateLetter.LetterPicturesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_OfficialTypeFirstLevelAttributes
        {
            get
            {
                return "CancelCommissionSessionOrder.CorrelateLetter.OfficialTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReceiptTypeFirstLevelAttributes
        {
            get
            {
                return "CancelCommissionSessionOrder.CorrelateLetter.ReceiptTypeFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_RecipientsFirstLevelAttributes
        {
            get
            {
                return "CancelCommissionSessionOrder.CorrelateLetter.RecipientsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_ReferenceLetterFirstLevelAttributes
        {
            get
            {
                return "CancelCommissionSessionOrder.CorrelateLetter.ReferenceLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_SenderFirstLevelAttributes
        {
            get
            {
                return "CancelCommissionSessionOrder.CorrelateLetter.SenderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetter_WordDocFirstLevelAttributes
        {
            get
            {
                return "CancelCommissionSessionOrder.CorrelateLetter.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "CancelCommissionSessionOrder.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_CorrelateLetterID
        {
            get
            {
                return "CancelCommissionSessionOrder.CorrelateLetterID";
            }
        }

        public static string at_Text
        {
            get
            {
                return "CancelCommissionSessionOrder.Text";
            }
        }

        [Browsable(true), Description("نامه لغو جلسه کمیسیون"), DisplayName("نامه مرتبط"), Category(""), DocumentAttributeID("9085"), IsRelational("False"), AttributeType("Letter"), IsMiddleTableExist("False"), RelationTable("")]
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

        [Browsable(true), Description("متن لغو جلسه"), DisplayName("متن لغو جلسه"), Category(""), DocumentAttributeID(""), IsRelational("false"), AttributeType("LongText")]
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