namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ObjectCode("9295")]
    public class AO_Offer : Offer, ISbnObject
    {
        private string _CommStartDate;
        private string _CommEndDate;
        private string _ApprovedDate;
        private string _FinalResult;
        private string _govSession;
        private string _LastCommissionSession;
        private string _OfferCommissionStatus;
        private List<long> _OfferTypeReport;
        private List<long> _StatusForCommunique;
        private List<long> _StatusForReport;
        private List<long> _StatusInGovOfficeForReport;

        public AO_Offer()
        {
            this._OfferTypeReport = new List<long>();
            this._StatusForCommunique = new List<long>();
            this._StatusForReport = new List<long>();
            this._StatusInGovOfficeForReport = new List<long>();
            this._LastCommissionSession = "";
            this._OfferCommissionStatus = "";
            this._ApprovedDate = "";
            this._FinalResult = "";
            this._govSession = "";
        }

        public AO_Offer(Offer off) : base(off)
        {
            this._OfferTypeReport = new List<long>();
            this._StatusForCommunique = new List<long>();
            this._StatusForReport = new List<long>();
            this._StatusInGovOfficeForReport = new List<long>();
            this._LastCommissionSession = "";
            this._OfferCommissionStatus = "";
            this._ApprovedDate = "";
            this._FinalResult = "";
            this._govSession = "";
            base.ActiveCommission = off.ActiveCommission;
            base.ApprovalLetters = off.ApprovalLetters;
            base.CommissionReports = off.CommissionReports;
            base.Commissions = off.Commissions;
            base.Complication = off.Complication;
            base.CorrelateOrgans = off.CorrelateOrgans;
            base.Engineerings = off.Engineerings;
            base.GovernReports = off.GovernReports;
            base.GovMemberOpinions = off.GovMemberOpinions;
            base.GovOfficeReceiptDate = off.GovOfficeReceiptDate;
            base.Importance = off.Importance;
            base.Inquiries = off.Inquiries;
            base.LawDocuments = off.LawDocuments;
            base.OfferAbstract = off.OfferAbstract;
            base.OfferComment = off.OfferComment;
            base.OfferCommuniqueText = off.OfferCommuniqueText;
            base.OfferLetter = off.OfferLetter;
            base.OfferRelations = off.OfferRelations;
            base.OfficialCode = off.OfficialCode;
            base.OrderInCatalogue = off.OrderInCatalogue;
            base.OtherLetters = off.OtherLetters;
            base.OwnerOrgan = off.OwnerOrgan;
            if ((off.RegisterDate != null) && (off.RegisterDate != ""))
            {
                base.RegisterDate = off.RegisterDate.Substring(0, 10);
            }
            base.Security = off.Security;
            base.Status = off.Status;
            base.Subjects = off.Subjects;
            base.Title = off.Title;
            base.Urgency = off.Urgency;
            base.VicePresidentLetterID = off.VicePresidentLetterID;
            base.VicePresidentReceiptdate = off.VicePresidentReceiptdate;
        }

        public override SbnObject Clone(string sNodeName)
        {
            return new AO_Offer { ID = base.ID };
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        [DisplayName("تاریخ ارجاع به کمیسیون"), Browsable(true), Description("تاریخ ارجاع به کمیسیون")]
        public string CommStartDate
        {
            get
            {
                return this._CommStartDate;
            }
            set
            {
                this._CommStartDate = value;
            }
        }

        [DisplayName("تاریخ پایان کار کمیسیون"), Browsable(true), Description("تاریخ پایان کار کمیسیون")]
        public string CommEndDate
        {
            get
            {
                return this._CommEndDate;
            }
            set
            {
                this._CommEndDate = value;
            }
        }

        [DisplayName("تاریخ ابلاغ"), Browsable(true), Description("تاریخ ابلاغ")]
        public string ApprovedDate
        {
            get
            {
                return this._ApprovedDate;
            }
            set
            {
                this._ApprovedDate = value;
            }
        }

        [Description("نتیجه نهایی"), Browsable(true), DisplayName("نتیجه نهایی")]
        public string FinalResult
        {
            get
            {
                return this._FinalResult;
            }
            set
            {
                this._FinalResult = value;
            }
        }

        [Description("تاریخ جلسه دولت"), Browsable(true), DisplayName("تاریخ جلسه دولت")]
        public string govSession
        {
            get
            {
                return this._govSession;
            }
            set
            {
                this._govSession = value;
            }
        }

        [DisplayName("تاریخ آخرین جلسه کمیسیون"), Description("تاریخ آخرین جلسه کمیسیون"), Browsable(true)]
        public string LastCommissionSession
        {
            get
            {
                return this._LastCommissionSession;
            }
            set
            {
                this._LastCommissionSession = value;
            }
        }

        [Description("وضعیت در کمیسیون"), Browsable(true), DisplayName("وضعیت در کمیسیون")]
        public string OfferCommissionStatus
        {
            get
            {
                return this._OfferCommissionStatus;
            }
            set
            {
                this._OfferCommissionStatus = value;
            }
        }

        public List<long> OfferTypeReport
        {
            get
            {
                return this._OfferTypeReport;
            }
            set
            {
                this._OfferTypeReport = value;
            }
        }

        public List<long> StatusForCommunique
        {
            get
            {
                return this._StatusForCommunique;
            }
            set
            {
                this._StatusForCommunique = value;
            }
        }

        public List<long> StatusForReport
        {
            get
            {
                return this._StatusForReport;
            }
            set
            {
                this._StatusForReport = value;
            }
        }

        public List<long> StatusInGovOfficeForReport
        {
            get
            {
                return this._StatusInGovOfficeForReport;
            }
            set
            {
                this._StatusInGovOfficeForReport = value;
            }
        }
    }
}
