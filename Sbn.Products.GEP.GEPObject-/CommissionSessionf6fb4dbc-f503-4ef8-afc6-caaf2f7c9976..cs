namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, DisplayName("جلسه کمیسیون"), ObjectCode("9097"), ItemsType("Sbn.Products.GEP.GEPObject.CommissionSessions"), SystemName("GEP"), Description("جلسه کمیسیون")]
    public class CommissionSession : SbnObject
    {
        private Letters _CoLetters;
        private BasicInfoDetail _CommissionSessionType;
        private BasicInfoDetail _CorrelateCommission;
        private OfferCommissions _CorrelateOffers;
        private string _Duration;
        private string _FinishTime;
        private SbnBoolean _IsCanceled;
        private string _LocationAddress;
        private CommissionSessionMembers _Members;
        private string _SessionDate;
        private CommissionSessionOrder _SessionOrder;
        private CancelCommissionSessionOrder _CancelSessionOrder;
        private string _SessionTime;
        private string _StartTime;
        

        private GeneralDocument _WordDoc;
        private GeneralDocument _CancelWordDoc;

        private string _CommissionSessionVoice;
     //  private string _Extension;

        private BasicInfoDetail _Sensitivity;

        public CommissionSession()
        {
            this._IsCanceled = SbnBoolean.OutOfValue;
           // CancelIsActive = false;
        }

        public CommissionSession(SbnObject InitialObject)
            : base(InitialObject)
        {
            this._IsCanceled = SbnBoolean.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            CommissionSession session = new CommissionSession
            {
                ID = base.ID 
            
            };

            if (this._SessionDate != null)
            {
                session.SessionDate = (string)this._SessionDate.Clone();
            }
            session.Duration = this._Duration;
            session.StartTime = this._StartTime;
            session.FinishTime = this._FinishTime;
            session.SessionTime = this._SessionTime;
            session.LocationAddress = this._LocationAddress;
            if (!object.ReferenceEquals(this.CorrelateCommission, null))
            {
                session.CorrelateCommission = (BasicInfoDetail)this.CorrelateCommission.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffers, null))
            {
                session.CorrelateOffers = (OfferCommissions)this.CorrelateOffers.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Members, null))
            {
                session.Members = (CommissionSessionMembers)this.Members.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.SessionOrder, null))
            {
                session.SessionOrder = (CommissionSessionOrder)this.SessionOrder.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CancelSessionOrder, null))
            {
                session.CancelSessionOrder = (CancelCommissionSessionOrder)this.CancelSessionOrder.Clone(sNodeName);
            }

            if (!object.ReferenceEquals(this.CommissionSessionType, null))
            {
                session.CommissionSessionType = (BasicInfoDetail)this.CommissionSessionType.Clone(sNodeName);
            }
            session.IsCanceled = this.IsCanceled;
            if (!object.ReferenceEquals(this.CoLetters, null))
            {
                session.CoLetters = (Letters)this.CoLetters.Clone(sNodeName);
            }

            if (!object.ReferenceEquals(this.WordDoc, null))
                session.WordDoc = (GeneralDocument)WordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this._CancelWordDoc, null))
                session.CancelWordDoc = (GeneralDocument)CancelWordDoc.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CommissionSessionVoice, null))
                session.CommissionSessionVoice = this.CommissionSessionVoice;
         //   session.Extension = this._Extension;

            if (!object.ReferenceEquals(this.Sensitivity, null))
            {
                session.Sensitivity = (BasicInfoDetail)this.Sensitivity.Clone(sNodeName);
            }

            return session;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._SessionDate = "";
            this._Duration = "";
            this._StartTime = "";
            this._FinishTime = "";
            this._SessionTime = "";
            this._LocationAddress = "";
            this._CorrelateCommission = new BasicInfoDetail();
            this._CorrelateOffers = new OfferCommissions();
            this._Members = new CommissionSessionMembers();
            this._SessionOrder = new CommissionSessionOrder();
            this._CancelSessionOrder = new CancelCommissionSessionOrder();
            this._CommissionSessionType = new BasicInfoDetail();
            this._IsCanceled = SbnBoolean.OutOfValue;
            this._CoLetters = new Letters();

            this._WordDoc = new GeneralDocument();
            this._CancelWordDoc = new GeneralDocument();
            this._CommissionSessionVoice = null;
           // this._Extension = "";

            this.Sensitivity = new BasicInfoDetail();
        }

        public override string ToString()
        {
            return this.SessionDate;
        }

        public static string at_CoLettersFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.CoLettersFirstLevelAttributes";
            }
        }

        public static string at_CoLettersID
        {
            get
            {
                return "CommissionSession.CoLettersID";
            }
        }

        public static string at_CommissionSessionType_ParentFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.CommissionSessionType.ParentFirstLevelAttributes";
            }
        }

        public static string at_CommissionSessionTypeFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.CommissionSessionTypeFirstLevelAttributes";
            }
        }

        public static string at_CommissionSessionTypeID
        {
            get
            {
                return "CommissionSession.CommissionSessionTypeID";
            }
        }

        public static string at_CorrelateCommission_ParentFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.CorrelateCommission.ParentFirstLevelAttributes";
            }
        }

        public static string at_CorrelateCommissionFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.CorrelateCommissionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateCommissionID
        {
            get
            {
                return "CommissionSession.CorrelateCommissionID";
            }
        }

        public static string at_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.CorrelateOffersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffersID
        {
            get
            {
                return "CommissionSession.CorrelateOffersID";
            }
        }

        public static string at_Duration
        {
            get
            {
                return "CommissionSession.Duration";
            }
        }

        public static string at_FinishTime
        {
            get
            {
                return "CommissionSession.FinishTime";
            }
        }

        public static string at_IsCanceled
        {
            get
            {
                return "CommissionSession.IsCanceled";
            }
        }

        public static string at_LocationAddress
        {
            get
            {
                return "CommissionSession.LocationAddress";
            }
        }

        public static string at_MembersFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.MembersFirstLevelAttributes";
            }
        }

        public static string at_MembersID
        {
            get
            {
                return "CommissionSession.MembersID";
            }
        }

        public static string at_SessionDate
        {
            get
            {
                return "CommissionSession.SessionDate";
            }
        }

        public static string at_SessionOrder_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.SessionOrder.CorrelateLetterFirstLevelAttributes";
            }
        }
        public static string at_CancelSessionOrder_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.CancelSessionOrder.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.SessionOrderFirstLevelAttributes";
            }
        }
        public static string at_CancelSessionOrderFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.CancelSessionOrderFirstLevelAttributes";
            }
        }

        public static string at_SessionOrderID
        {
            get
            {
                return "CommissionSession.SessionOrderID";
            }
        }



        public static string at_CancelSessionOrderID
        {
            get
            {
                return "CommissionSession.CancelSessionOrderID";
            }
        }

        public static string at_SessionTime
        {
            get
            {
                return "CommissionSession.SessionTime";
            }
        }

        public static string at_StartTime
        {
            get
            {
                return "CommissionSession.StartTime";
            }
        }

        public static string at_CommissionSessionVoice
        {
            get
            {
                return "CommissionSession.CommissionSessionVoice";
            }
        }
        //public static string at_Extension
        //{
        //    get
        //    {
        //        return "CommissionSession.Extension";
        //    }
        //}

        public static string at_CancelWordDocID
        {
            get
            {
                return "CommissionSession.CancelWordDocID";
            }
        }
     
        public static string at_WordDocID
        {
            get
            {
                return "CommissionSession.WordDocID";
            }
        }
        public static string at_WordDocTitle
        {
            get
            {
                return "CommissionSession.WordDoc.Title";
            }
        }
        public static string at_CancelWordDocTitle
        {
            get
            {
                return "CommissionSesstion.CancelWordDoc.Title";
            }
        }
        public static string at_WordDocFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.WordDocFirstLevelAttributes";
            }
        }

        public static string at_CancelWordDocFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.CancelWordDocFirstLevelAttributes";
            }
        }

        public static string at_SensitivityID
        {
            get
            {
                return "CommissionSession.SensitivityID";
            }
        }
        public static string at_SensitivityFirstLevelAttributes
        {
            get
            {
                return "CommissionSession.SensitivityFirstLevelAttributes";
            }
        }

       // public bool CancelIsActive { get; set; }

        [DocumentAttributeID("27111"), AttributeType("Letters"), IsMiddleTableExist("False"), RelationTable("COMMISSIONSESSION_COLETTERS_M"), DisplayName("نامه های مرتبط"), Category("ضمائم"), Description("نامه های مرتبط"), Browsable(true), IsRelational("False")]
        public Letters CoLetters
        {
            get
            {
                return this._CoLetters;
            }
            set
            {
                this._CoLetters = value;
            }
        }

        [AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("نوع جلسه"), Category(""), DocumentAttributeID("9280"), Browsable(true), IsRelational("False"), Description("نوع جلسه کمیسیون")]
        public BasicInfoDetail CommissionSessionType
        {
            get
            {
                return this._CommissionSessionType;
            }
            set
            {
                this._CommissionSessionType = value;
            }
        }

        [AttributeType("BasicInfoDetail"), DocumentAttributeID("9080"), IsRelational("False"), Description("کمیسیون"), IsMiddleTableExist("False"), RelationTable(""), Browsable(true), DisplayName("کمیسیون"), Category("")]
        public BasicInfoDetail CorrelateCommission
        {
            get
            {
                return this._CorrelateCommission;
            }
            set
            {
                this._CorrelateCommission = value;
            }
        }

        [IsMiddleTableExist("False"), DocumentAttributeID("9081"), IsRelational("False"), AttributeType("OfferCommissions"), Description("پیشنهاد های مطروحه در جلسه"), RelationTable("COMMISSIONSESSION_OFFS_M"), Browsable(true), DisplayName("فهرست پیشنهادها"), Category("")]
        public OfferCommissions CorrelateOffers
        {
            get
            {
                return this._CorrelateOffers;
            }
            set
            {
                this._CorrelateOffers = value;
            }
        }

        [Description(""), AttributeType("String"), Browsable(true), DisplayName(""), Category(""), DocumentAttributeID("9232"), IsRelational("false")]
        public string Duration
        {
            get
            {
                return this._Duration;
            }
            set
            {
                this._Duration = value;
            }
        }

        [DisplayName("ساعت اتمام"), Description("ساعت اتمام جلسه"), AttributeType("String"), Browsable(true), DocumentAttributeID("9254"), IsRelational("false"), Category("")]
        public string FinishTime
        {
            get
            {
                return this._FinishTime;
            }
            set
            {
                this._FinishTime = value;
            }
        }

        [RelationTable(""), IsMiddleTableExist("False"), Description("لغو جلسه"), DisplayName("لغو جلسه"), Category(""), DocumentAttributeID("9291"), Browsable(true), IsRelational("False"), AttributeType("SbnBoolean")]
        public SbnBoolean IsCanceled
        {
            get
            {
                return this._IsCanceled;
            }
            set
            {
                this._IsCanceled = value;
            }
        }

        [DocumentAttributeID("27017"), IsRelational("false"), AttributeType("String"), Browsable(true), DisplayName("محل برگزاری"), Category(""), Description("محل برگزاری")]
        public string LocationAddress
        {
            get
            {
                return this._LocationAddress;
            }
            set
            {
                this._LocationAddress = value;
            }
        }

        [DocumentAttributeID("9084"), Browsable(true), IsRelational("True"), AttributeType("CommissionSessionMembers"), IsMiddleTableExist("True"), RelationTable(""), DisplayName("شرکت کنندگان"), Category(""), Description("اعضاء شرکت کننده")]
        public CommissionSessionMembers Members
        {
            get
            {
                return this._Members;
            }
            set
            {
                this._Members = value;
            }
        }

        [DocumentAttributeID("9218"), IsRelational("false"), AttributeType("DateString"), Browsable(true), Description("تاریخ  جلسه"), DisplayName("تاریخ  جلسه"), Category("")]
        public string SessionDate
        {
            get
            {
                return this._SessionDate;
            }
            set
            {
                this._SessionDate = value;
            }
        }

        [AttributeType("CommissionSessionOrder"), DisplayName("دستور جلسه کمیسیون"), Category(""), DocumentAttributeID("9086"), Browsable(true), IsRelational("False"), Description("دستور جلسه کمیسیون"), IsMiddleTableExist("False"), RelationTable("")]
        public CommissionSessionOrder SessionOrder
        {
            get
            {
                return this._SessionOrder;
            }
            set
            {
                this._SessionOrder = value;
            }
        }
        [AttributeType("CancelCommissionSessionOrder"), DisplayName("دستور لغو جلسه کمیسیون"), Category(""), DocumentAttributeID("9086"), Browsable(true), IsRelational("False"), Description("دستور لغو جلسه کمیسیون"), IsMiddleTableExist("False"), RelationTable("")]
        public CancelCommissionSessionOrder CancelSessionOrder
        {
            get
            {
                return this._CancelSessionOrder;
            }
            set
            {
                this._CancelSessionOrder = value;
            }
        }

        [Browsable(true), DocumentAttributeID("9258"), AttributeType("String"), Description("زمان جلسه"), IsRelational("false"), DisplayName("زمان جلسه"), Category("")]
        public string SessionTime
        {
            get
            {
                return this._SessionTime;
            }
            set
            {
                this._SessionTime = value;
            }
        }

        [Browsable(true), AttributeType("String"), Description("ساعت شروع جلسه"), DisplayName("ساعت شروع"), Category(""), DocumentAttributeID("9253"), IsRelational("false")]
        public string StartTime
        {
            get
            {
                return this._StartTime;
            }
            set
            {
                this._StartTime = value;
            }
        }

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
        
        public GeneralDocument WordDoc
        {
            get { return _WordDoc; }
            set { _WordDoc = value; }
        }
        /// <summary>
        /// دستور لغو جلسه
        /// </summary>
        [Description("دستور لغو جلسه")]
        [DisplayName("لغو جلسه")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("GeneralDocument")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public GeneralDocument CancelWordDoc
        {
            get { return _CancelWordDoc; }
            set { _CancelWordDoc = value; }
        }
       

        /// <summary>
        /// مستند تایپی
        /// </summary>
        [Description("شاخص فایل صوتی جلسه")]
        [DisplayName("صوت جلسه")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("string")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public string CommissionSessionVoice
        {
            get { return _CommissionSessionVoice; }
            set { _CommissionSessionVoice = value; }
        }
        //public string Extension
        //{
        //    get
        //    {
        //        return this._Extension;
        //    }
        //    set
        //    {
        //        this._Extension = value;
        //    }
        //}


        [AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable(""), IsRelational("False"), Description("طبقه بندی جلسه کمیسیون"), DisplayName("طبقه بندی"), Category(""), DocumentAttributeID(""), Browsable(true)]
        public BasicInfoDetail Sensitivity
        {
            get
            {
                return this._Sensitivity;
            }
            set
            {
                _Sensitivity = value;
            }
        }

   
    }
}
