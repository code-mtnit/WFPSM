namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, ObjectCode("9047"), SystemName("GEP"), Description("فهرست پيشنهادهاي آماده طرح در هيات دولت"), DisplayName("فهرست پيشنهادهاي آماده طرح در هيات دولت"), ItemsType("Sbn.Products.GEP.GEPObject.Catalogues")]
    public class Catalogue : SbnObject
    {
        private GEPOfferUrgencyType _CatalogueUrgencyType;
        private GovSession _CorrelateGovSession;
        private string _Description;
        private Sbn.Products.GEP.GEPObject.Offers _Offers;
        private string _OfficialCode;
        private int _OrderInSession;
        private string _RegistraterDate;
        private string _Title;
        private string _TitleBackColor;
        private string _TitleForeColor;
        private Single _TitleFontSize;
        public Single TitleFontSize
        {
            get
            {
                return _TitleFontSize;
            }

            set
            {
                _TitleFontSize = value;
            }
        }

        public string TitleBackColor
        {
            get
            {
                return _TitleBackColor;
            }

            set
            {
                _TitleBackColor = value;
            }
        }


        public string TitleForeColor
        {
            get
            {
                return _TitleForeColor;
            }

            set
            {
                _TitleForeColor = value;
            }
        }
        public Catalogue()
        {
            this._CatalogueUrgencyType = GEPOfferUrgencyType.OutOfValue;
        }

        public Catalogue(SbnObject InitialObject) : base(InitialObject)
        {
            this._CatalogueUrgencyType = GEPOfferUrgencyType.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            Catalogue catalogue = new Catalogue {
                ID = base.ID,
                OrderInSession = this._OrderInSession
            };
            if (this._RegistraterDate != null)
            {
                catalogue.RegistraterDate = (string) this._RegistraterDate.Clone();
            }
            catalogue.OfficialCode = this._OfficialCode;
            catalogue.Title = this._Title;
            catalogue.Description = this._Description;
            if (!object.ReferenceEquals(this.CorrelateGovSession, null))
            {
                catalogue.CorrelateGovSession = (GovSession) this.CorrelateGovSession.Clone(sNodeName);
            }
            catalogue.CatalogueUrgencyType = this.CatalogueUrgencyType;
            if (!object.ReferenceEquals(this.Offers, null))
            {
                catalogue.Offers = (Sbn.Products.GEP.GEPObject.Offers) this.Offers.Clone(sNodeName);
            }
            return catalogue;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._OrderInSession = 0;
            this._RegistraterDate = "";
            this._OfficialCode = "";
            this._Title = "";
            this._Description = "";
            this._CorrelateGovSession = new GovSession();
            this._CatalogueUrgencyType = GEPOfferUrgencyType.OutOfValue;
            this._Offers = new Sbn.Products.GEP.GEPObject.Offers();
        }

        public override string ToString()
        {
            string title = this.Title;
            if (this.CorrelateGovSession != null)
            {
                title = title + "-" + this.CorrelateGovSession.SessionDate;
            }
            return title;
        }

        public static string at_CatalogueUrgencyType
        {
            get
            {
                return "Catalogue.CatalogueUrgencyType";
            }
        }

        public static string at_CorrelateGovSession_CataloguesFirstLevelAttributes
        {
            get
            {
                return "Catalogue.CorrelateGovSession.CataloguesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateGovSession_CoLettersFirstLevelAttributes
        {
            get
            {
                return "Catalogue.CorrelateGovSession.CoLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateGovSession_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "Catalogue.CorrelateGovSession.CorrelateOffersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateGovSession_MembersFirstLevelAttributes
        {
            get
            {
                return "Catalogue.CorrelateGovSession.MembersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateGovSession_OrganAnnouncementFirstLevelAttributes
        {
            get
            {
                return "Catalogue.CorrelateGovSession.OrganAnnouncementFirstLevelAttributes";
            }
        }

        public static string at_CorrelateGovSession_PreOrdersFirstLevelAttributes
        {
            get
            {
                return "Catalogue.CorrelateGovSession.PreOrdersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateGovSession_PresentationsFirstLevelAttributes
        {
            get
            {
                return "Catalogue.CorrelateGovSession.PresentationsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateGovSession_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "Catalogue.CorrelateGovSession.SessionOrderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateGovSessionFirstLevelAttributes
        {
            get
            {
                return "Catalogue.CorrelateGovSessionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateGovSessionID
        {
            get
            {
                return "Catalogue.CorrelateGovSessionID";
            }
        }

        public static string at_Description
        {
            get
            {
                return "Catalogue.Description";
            }
        }

        public static string at_OffersFirstLevelAttributes
        {
            get
            {
                return "Catalogue.OffersFirstLevelAttributes";
            }
        }

        public static string at_OffersID
        {
            get
            {
                return "Catalogue.OffersID";
            }
        }

        public static string at_OfficialCode
        {
            get
            {
                return "Catalogue.OfficialCode";
            }
        }

        public static string at_OrderInSession
        {
            get
            {
                return "Catalogue.OrderInSession";
            }
        }

        public static string at_RegistraterDate
        {
            get
            {
                return "Catalogue.RegistraterDate";
            }
        }

        public static string at_Title
        {
            get
            {
                return "Catalogue.Title";
            }
        }

        [Description("فوریت"), RelationTable(""), DisplayName("فوریت"), Category(""), DocumentAttributeID("9031"), Browsable(true), IsRelational("False"), AttributeType("GEPOfferUrgencyType"), IsMiddleTableExist("False")]
        public GEPOfferUrgencyType CatalogueUrgencyType
        {
            get
            {
                return this._CatalogueUrgencyType;
            }
            set
            {
                this._CatalogueUrgencyType = value;
            }
        }

        [IsRelational("False"), Description("جلسه مرتبط"), DisplayName("جلسه مرتبط"), Category(""), DocumentAttributeID("9045"), Browsable(true), AttributeType("GovSession"), IsMiddleTableExist("False"), RelationTable("")]
        public GovSession CorrelateGovSession
        {
            get
            {
                return this._CorrelateGovSession;
            }
            set
            {
                this._CorrelateGovSession = value;
            }
        }

        [Description("توضیحات"), DocumentAttributeID("9242"), IsRelational("false"), Browsable(true), DisplayName("توضیحات"), Category(""), AttributeType("String")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        [IsRelational("False"), RelationTable("CATALOGUE_OFFERS_M"), Browsable(true), DisplayName("پیشنهادها"), Category(""), IsMiddleTableExist("False"), Description("پیشنهادها"), AttributeType("Offers"), DocumentAttributeID("9014")]
        public Sbn.Products.GEP.GEPObject.Offers Offers
        {
            get
            {
                return this._Offers;
            }
            set
            {
                this._Offers = value;
            }
        }

        [Description("کد"), DisplayName("کد"), Category(""), DocumentAttributeID("9007"), IsRelational("false"), AttributeType("String"), Browsable(true)]
        public string OfficialCode
        {
            get
            {
                return this._OfficialCode;
            }
            set
            {
                this._OfficialCode = value;
            }
        }

        [Browsable(true), DisplayName("الویت در جلسه"), Category(""), DocumentAttributeID("9026"), IsRelational("false"), AttributeType("Int"), Description("اولویت در جلسه")]
        public int OrderInSession
        {
            get
            {
                return this._OrderInSession;
            }
            set
            {
                this._OrderInSession = value;
            }
        }

        [DocumentAttributeID("9021"), DisplayName(""), Category(""), Description(""), IsRelational("false"), AttributeType("DateString"), Browsable(true)]
        public string RegistraterDate
        {
            get
            {
                return this._RegistraterDate;
            }
            set
            {
                this._RegistraterDate = value;
            }
        }

        [Category(""), Browsable(true), DisplayName("عنوان"), Description("عنوان"), DocumentAttributeID("9241"), IsRelational("false"), AttributeType("String")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
            }
        }
    }
}
