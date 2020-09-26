namespace Sbn.Products.GEP.GEPObject
{
    using Sbn.Core;
    using Sbn.Libs.AssemblyTools;
    using System;
    using System.ComponentModel;

    [Serializable, SystemName("GEP"), Description(""), DisplayName(""), ObjectCode("9045"), ItemsType("Sbn.Products.GEP.GEPObject.GeneralSessions")]
    public class GeneralSession : SbnObject
    {
        private string _SessionDate;
        private GEPSessionType _SessionType;

        public GeneralSession()
        {
            this._SessionType = GEPSessionType.OutOfValue;
        }

        public GeneralSession(SbnObject InitialObject) : base(InitialObject)
        {
            this._SessionType = GEPSessionType.OutOfValue;
        }

        public override SbnObject Clone(string sNodeName)
        {
            GeneralSession session = new GeneralSession {
                ID = base.ID
            };
            if (this._SessionDate != null)
            {
                session.SessionDate = (string) this._SessionDate.Clone();
            }
            session.SessionType = this.SessionType;
            return session;
        }

        public override void Initialize()
        {
            base.Initialize();
            this._SessionDate = "";
            this._SessionType = GEPSessionType.OutOfValue;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static string at_SessionDate
        {
            get
            {
                return "GeneralSession.SessionDate";
            }
        }

        public static string at_SessionType
        {
            get
            {
                return "GeneralSession.SessionType";
            }
        }

        [Description("تاریخ و ساعت جلسه"), DisplayName("تاریخ و ساعت جلسه"), Category(""), DocumentAttributeID("9006"), IsRelational("false"), AttributeType("DateString"), Browsable(true)]
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

        [AttributeType("GEPSessionType"), IsRelational("False"), Description("نوع جلسه دولت یا کمیسیون"), IsMiddleTableExist("False"), RelationTable(""), DisplayName("نوع جلسه"), Category(""), DocumentAttributeID("9013"), Browsable(true)]
        public GEPSessionType SessionType
        {
            get
            {
                return this._SessionType;
            }
            set
            {
                this._SessionType = value;
            }
        }
    }
}
