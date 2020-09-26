namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [Serializable, Description(""), DisplayName(""), ObjectCode("9294"), SystemName("GEP")]
    public class AO_ApprovalLetter : ApprovalLetter, ISbnObject
    {
        private string _ApprovalDate;
        private List<long> _ApprovalTypes;
        private string _LetterTitle;
        private string _OfferTitle;

        public AO_ApprovalLetter()
        {
            this._ApprovalTypes = new List<long>();
            this._OfferTitle = null;
            this._LetterTitle = null;
            this._ApprovalDate = null;
        }

        public AO_ApprovalLetter(ApprovalLetter InitialObject) : base(InitialObject)
        {
            this._ApprovalTypes = new List<long>();
            this._OfferTitle = null;
            this._LetterTitle = null;
            this._ApprovalDate = null;
        }

        public override SbnObject Clone(string sNodeName)
        {
            return new AO_ApprovalLetter { ID = base.ID };
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        [DisplayName("تاریخ ابلاغ"), Browsable(true), Description("تاریخ ابلاغ#Type:String")]
        public string ApprovalDate
        {
            get
            {
                return this._ApprovalDate;
            }
            set
            {
                this._ApprovalDate = value;
            }
        }

        public List<long> ApprovalTypesForReport
        {
            get
            {
                return this._ApprovalTypes;
            }
            set
            {
                this._ApprovalTypes = value;
            }
        }

        [Browsable(true), DisplayName("عنوان نامه"), Description("عنوان نامه#Type:String")]
        public string LetterTitle
        {
            get
            {
                return this._LetterTitle;
            }
            set
            {
                this._LetterTitle = value;
            }
        }

        [Description("عنوان پیشنهاد#Type:String"), Browsable(true), DisplayName("عنوان پیشنهاد")]
        public string OfferTitle
        {
            get
            {
                return this._OfferTitle;
            }
            set
            {
                this._OfferTitle = value;
            }
        }
    }
}
