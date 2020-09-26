namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using Sbn.Systems.WMC.WMCObject;
    using System;
    using System.ComponentModel;

    [Serializable, Description("جلسه هيات دولت"), SystemName("GEP"), DisplayName("جلسه هيات دولت"), ObjectCode("9046"), ItemsType("Sbn.Products.GEP.GEPObject.GovSessions")]
    public class GovSession : SbnObject
    {
        private Sbn.Products.GEP.GEPObject.Catalogues _Catalogues;
        private Letters _CoLetters;
        private Offers _CorrelateOffers;
        private string _FinishTime;
        private SbnBoolean _IsCanceled;
        private string _LocationAddress;
        private GovSessionMembers _Members;
        private Sbn.Products.GEP.GEPObject.Presentations _OrganAnnouncement;
        private PreSessionOrders _PreOrders;
        private Sbn.Products.GEP.GEPObject.Presentations _Presentations;
        private string _SessionDate;
        private GovernmentSessionOrder _SessionOrder;
        private string _SessionTime;
        private string _StartTime;
        private GeneralDocuments _CoGeneralDocuments;

        private GeneralDocument _WordDoc;

        private BasicInfoDetail _Sensitivity;

        public GovSession()
        {
            this._IsCanceled = SbnBoolean.OutOfValue;
        }

        public GovSession(SbnObject InitialObject)
            : base(InitialObject)
        {
            this._IsCanceled = SbnBoolean.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            GovSession session = new GovSession
            {
                ID = base.ID
            };
            if (this._SessionDate != null)
            {
                session.SessionDate = (string)this._SessionDate.Clone();
            }
            session.SessionTime = this._SessionTime;
            session.FinishTime = this._FinishTime;
            session.StartTime = this._StartTime;
            session.LocationAddress = this._LocationAddress;
            if (!object.ReferenceEquals(this.Members, null))
            {
                session.Members = (GovSessionMembers)this.Members.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Catalogues, null))
            {
                session.Catalogues = (Sbn.Products.GEP.GEPObject.Catalogues)this.Catalogues.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CorrelateOffers, null))
            {
                session.CorrelateOffers = (Offers)this.CorrelateOffers.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.SessionOrder, null))
            {
                session.SessionOrder = (GovernmentSessionOrder)this.SessionOrder.Clone(sNodeName);
            }
            session.IsCanceled = this.IsCanceled;
            if (!object.ReferenceEquals(this.PreOrders, null))
            {
                session.PreOrders = (PreSessionOrders)this.PreOrders.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.Presentations, null))
            {
                session.Presentations = (Sbn.Products.GEP.GEPObject.Presentations)this.Presentations.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoLetters, null))
            {
                session.CoLetters = (Letters)this.CoLetters.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.CoGeneralDocuments, null))
            {
                session.CoGeneralDocuments = (GeneralDocuments)this.CoGeneralDocuments.Clone(sNodeName);
            }
            if (!object.ReferenceEquals(this.WordDoc, null))
            {
                session.WordDoc = (GeneralDocument)this.WordDoc.Clone(sNodeName);
            }
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
            this._SessionTime = "";
            this._FinishTime = "";
            this._StartTime = "";
            this._LocationAddress = "";
            this._Members = new GovSessionMembers();
            this._Catalogues = new Sbn.Products.GEP.GEPObject.Catalogues();
            this._CorrelateOffers = new Offers();
            this._SessionOrder = new GovernmentSessionOrder();
            this._IsCanceled = SbnBoolean.OutOfValue;
            this._PreOrders = new PreSessionOrders();
            this._Presentations = new Sbn.Products.GEP.GEPObject.Presentations();
            this._OrganAnnouncement = new Sbn.Products.GEP.GEPObject.Presentations();
            this._CoLetters = new Letters();
            this._CoGeneralDocuments = new GeneralDocuments();

            this._WordDoc = new GeneralDocument();

            this.Sensitivity = new BasicInfoDetail();
        }

        public override string ToString()
        {
            try
            {
                return (this.SessionDate.Substring(0, 10) + " " + this.SessionTime);
            }
            catch
            {
            }
            return " ";
        }

        public static string at_CataloguesFirstLevelAttributes
        {
            get
            {
                return "GovSession.CataloguesFirstLevelAttributes";
            }
        }

        public static string at_CataloguesID
        {
            get
            {
                return "GovSession.CataloguesID";
            }
        }

        public static string at_CoLettersFirstLevelAttributes
        {
            get
            {
                return "GovSession.CoLettersFirstLevelAttributes";
            }
        }

        public static string at_CoLettersID
        {
            get
            {
                return "GovSession.CoLettersID";
            }
        }

        public static string at_CoGeneralDocumentsFirstLevelAttributes
        {
            get
            {
                return "GovSession.CoGeneralDocumentsFirstLevelAttributes";
            }
        }

        public static string at_CoGeneralDocumentsID
        {
            get
            {
                return "GovSession.CoGeneralDocumentsID";
            }
        }

        public static string at_WordDocID
        {
            get
            {
                return "GovSession.WordDocID";
            }
        }
        public static string at_WordDocTitle
        {
            get
            {
                return "GovSession.WordDoc.Title";
            }
        }
        public static string at_WordDocFirstLevelAttributes
        {
            get
            {
                return "GovSession.WordDocFirstLevelAttributes";
            }
        }

        public static string at_SensitivityID
        {
            get
            {
                return "GovSession.SensitivityID";
            }
        }
        public static string at_SensitivityFirstLevelAttributes
        {
            get
            {
                return "GovSession.SensitivityFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "GovSession.CorrelateOffersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateOffersID
        {
            get
            {
                return "GovSession.CorrelateOffersID";
            }
        }

        public static string at_FinishTime
        {
            get
            {
                return "GovSession.FinishTime";
            }
        }

        public static string at_IsCanceled
        {
            get
            {
                return "GovSession.IsCanceled";
            }
        }

        public static string at_LocationAddress
        {
            get
            {
                return "GovSession.LocationAddress";
            }
        }

        public static string at_MembersFirstLevelAttributes
        {
            get
            {
                return "GovSession.MembersFirstLevelAttributes";
            }
        }

        public static string at_MembersID
        {
            get
            {
                return "GovSession.MembersID";
            }
        }

        public static string at_OrganAnnouncementFirstLevelAttributes
        {
            get
            {
                return "GovSession.OrganAnnouncementFirstLevelAttributes";
            }
        }

        public static string at_OrganAnnouncementID
        {
            get
            {
                return "GovSession.OrganAnnouncementID";
            }
        }

        public static string at_PreOrdersFirstLevelAttributes
        {
            get
            {
                return "GovSession.PreOrdersFirstLevelAttributes";
            }
        }

        public static string at_PreOrdersID
        {
            get
            {
                return "GovSession.PreOrdersID";
            }
        }

        public static string at_PresentationsFirstLevelAttributes
        {
            get
            {
                return "GovSession.PresentationsFirstLevelAttributes";
            }
        }

        public static string at_PresentationsID
        {
            get
            {
                return "GovSession.PresentationsID";
            }
        }

        public static string at_SessionDate
        {
            get
            {
                return "GovSession.SessionDate";
            }
        }

        public static string at_SessionOrder_CorrelateLetterFirstLevelAttributes
        {
            get
            {
                return "GovSession.SessionOrder.CorrelateLetterFirstLevelAttributes";
            }
        }

        public static string at_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "GovSession.SessionOrderFirstLevelAttributes";
            }
        }

        public static string at_SessionOrderID
        {
            get
            {
                return "GovSession.SessionOrderID";
            }
        }

        public static string at_SessionTime
        {
            get
            {
                return "GovSession.SessionTime";
            }
        }

        public static string at_StartTime
        {
            get
            {
                return "GovSession.StartTime";
            }
        }

        [Browsable(true), Category(""), RelationTable("Cats"), Description("فهرستها"), DisplayName("فهرستها"), DocumentAttributeID("9015"), IsRelational("True"), AttributeType("Catalogues"), IsMiddleTableExist("True")]
        public Sbn.Products.GEP.GEPObject.Catalogues Catalogues
        {
            get
            {
                return this._Catalogues;
            }
            set
            {
                this._Catalogues = value;
            }
        }

        [Description("نامه های مرتبط"), DisplayName("نامه های مرتبط"), Category("ضمائم"), DocumentAttributeID("27110"), Browsable(true), IsRelational("False"), AttributeType("Letters"), IsMiddleTableExist("False"), RelationTable("GOVSESSION_COLETTERS_M")]
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

        [Browsable(true), Description("پیشنهادهای بدون فهرست"), DisplayName("پیشنهادهای بدون فهرست"), Category(""), DocumentAttributeID("9017"), IsRelational("True"), AttributeType("Offers"), IsMiddleTableExist("True"), RelationTable("Offs")]
        public Offers CorrelateOffers
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

        [IsRelational("false"), AttributeType("String"), DocumentAttributeID("9256"), Browsable(true), Description("ساعت اتمام جلسه"), DisplayName("ساعت اتمام"), Category("")]
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

        [Browsable(true), Description("لغو جلسه"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("لغو جلسه"), DocumentAttributeID("9290"), IsRelational("False"), AttributeType("SbnBoolean"), Category("")]
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

        [Browsable(true), DocumentAttributeID("27018"), Category(""), IsRelational("false"), AttributeType("String"), Description("محل برگزاری"), DisplayName("محل برگزاری")]
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

        [DocumentAttributeID("9051"), IsMiddleTableExist("True"), RelationTable("GovSesMems"), Description("اعضاء"), DisplayName("اعضاء"), Browsable(true), IsRelational("True"), Category(""), AttributeType("GovSessionMembers")]
        public GovSessionMembers Members
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

        [IsRelational("True"), AttributeType("PreSessionOrders"), IsMiddleTableExist("True"), RelationTable(""), DisplayName(""), Category(""), DocumentAttributeID("9363"), Browsable(true), Description("")]
        public PreSessionOrders PreOrders
        {
            get
            {
                return this._PreOrders;
            }
            set
            {
                this._PreOrders = value;
            }
        }

        [Description(""), AttributeType("Presentations"), IsMiddleTableExist("False"), RelationTable("GovSession_Presentation_M"), DisplayName(""), Category(""), DocumentAttributeID("9316"), Browsable(true), IsRelational("True")]
        public Sbn.Products.GEP.GEPObject.Presentations Presentations
        {
            get
            {
                return this._Presentations;
            }
            set
            {
                this._Presentations = value;
            }
        }

        [DocumentAttributeID("9217"), Category(""), Browsable(true), Description("تاریخ  جلسه"), DisplayName("تاریخ  جلسه"), IsRelational("false"), AttributeType("DateString")]
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

        [Description("دستور جلسه"), RelationTable(""), DisplayName("دستور جلسه"), Category(""), DocumentAttributeID("9018"), Browsable(true), IsRelational("False"), AttributeType("GovernmentSessionOrder"), IsMiddleTableExist("False")]
        public GovernmentSessionOrder SessionOrder
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

        [Description("ساعت جلسه"), DisplayName("ساعت جلسه"), Category(""), Browsable(true), AttributeType("String"), DocumentAttributeID("9245"), IsRelational("false")]
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

        [IsRelational("false"), Category(""), Description("زمان شروع جلسه"), AttributeType("String"), Browsable(true), DocumentAttributeID("9257"), DisplayName("زمان شروع جلسه")]
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
        [IsRelationalAttribute("false")]
        [AttributeType("GeneralDocuments")]
        [IsMiddleTableExist("false")]
        [RelationTable("GOVSESSION_GENERALDOCUMENT_M")]
        public GeneralDocuments CoGeneralDocuments
        {
            get { return _CoGeneralDocuments; }
            set { _CoGeneralDocuments = value; }
        }

        /// <summary>
        /// مستند تایپی متن دستور جلسه
        /// </summary>
        [Description("مستند تایپی متن دستور جلسه")]
        [DisplayName("متن دستور جلسه")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("false")]
        [AttributeType("GeneralDocument")]
        [IsMiddleTableExist("false")]
        [RelationTable("")]
        public GeneralDocument WordDoc
        {
            get { return _WordDoc; }
            set { _WordDoc = value; }
        }

        [AttributeType("BasicInfoDetail"), IsMiddleTableExist("False"), RelationTable(""), IsRelational("False"), Description("طبقه بندی جلسه دولت"), DisplayName("طبقه بندی"), Category(""), DocumentAttributeID(""), Browsable(true)]
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
