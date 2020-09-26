namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, Description("بند پيش از دستور"), DisplayName("بند پيش از دستور"), ObjectCode("9268"), ItemsType("Sbn.Products.GEP.GEPObject.PreSessionOrders"), SystemName("GEP")]
    public class PreSessionOrder : SbnObject
    {
        private GovSession _CorrelateSession;
        private int _OrderInSession;
        private string _Title;
        private string _PreSessionOrderType;

        private string _TitleBackColor;
        private string _TitleForeColor;
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
        public PreSessionOrder()
        {
        }

        public PreSessionOrder(SbnObject InitialObject) : base(InitialObject)
        {
        }

        public override SbnObject Clone(string sNodeName)
        {
            PreSessionOrder order = new PreSessionOrder {
                ID = base.ID,
                Title = this._Title,
                OrderInSession = this._OrderInSession
            };
            if (!object.ReferenceEquals(this.CorrelateSession, null))
            {
                order.CorrelateSession = (GovSession) this.CorrelateSession.Clone(sNodeName);
            }
            return order;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._Title = "";
            this._OrderInSession = 0;
            this._CorrelateSession = new GovSession();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_CorrelateSession_CataloguesFirstLevelAttributes
        {
            get
            {
                return "PreSessionOrder.CorrelateSession.CataloguesFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CoLettersFirstLevelAttributes
        {
            get
            {
                return "PreSessionOrder.CorrelateSession.CoLettersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_CorrelateOffersFirstLevelAttributes
        {
            get
            {
                return "PreSessionOrder.CorrelateSession.CorrelateOffersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_MembersFirstLevelAttributes
        {
            get
            {
                return "PreSessionOrder.CorrelateSession.MembersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_OrganAnnouncementFirstLevelAttributes
        {
            get
            {
                return "PreSessionOrder.CorrelateSession.OrganAnnouncementFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_PreOrdersFirstLevelAttributes
        {
            get
            {
                return "PreSessionOrder.CorrelateSession.PreOrdersFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_PresentationsFirstLevelAttributes
        {
            get
            {
                return "PreSessionOrder.CorrelateSession.PresentationsFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSession_SessionOrderFirstLevelAttributes
        {
            get
            {
                return "PreSessionOrder.CorrelateSession.SessionOrderFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "PreSessionOrder.CorrelateSessionFirstLevelAttributes";
            }
        }

        public static string at_CorrelateSessionID
        {
            get
            {
                return "PreSessionOrder.CorrelateSessionID";
            }
        }

        public static string at_OrderInSession
        {
            get
            {
                return "PreSessionOrder.OrderInSession";
            }
        }

        public static string at_Title
        {
            get
            {
                return "PreSessionOrder.Title";
            }
        }

        [Description("جلسه مرتبط"), RelationTable(""), DisplayName("جلسه مرتبط"), Category(""), DocumentAttributeID("9364"), Browsable(true), IsRelational("False"), AttributeType("GovSession"), IsMiddleTableExist("False")]
        public GovSession CorrelateSession
        {
            get
            {
                return this._CorrelateSession;
            }
            set
            {
                this._CorrelateSession = value;
            }
        }

        [IsRelational("false"), Description("ردیف"), DisplayName("ردیف"), Category(""), DocumentAttributeID("9262"), AttributeType("Int"), Browsable(true)]
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

        [Category(""), Browsable(true), AttributeType("String"), Description("عنوان"), DisplayName("عنوان"), DocumentAttributeID("9260"), IsRelational("false")]
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

        public string PreSessionOrderType
        {
            get
            {
                return _PreSessionOrderType;
            }

            set
            {
                _PreSessionOrderType = value;
            }
        }
    }
}
