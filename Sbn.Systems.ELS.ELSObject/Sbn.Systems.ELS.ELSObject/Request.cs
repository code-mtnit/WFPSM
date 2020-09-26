using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Core;
using MSXML2;
namespace Sbn.Systems.ELS.ELSObject
{
    [Description("درخواست")]
    [DisplayName("درخواست")]
    [ObjectCode("11012")]
    [SystemName("ELS")]
    [ItemsType("Sbn.Systems.ELS.ELSObject.Requests")]
    [Serializable]
    public class Request : SbnObject
    {
        public Request()
            : base()
        {
        }
        public Request(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private long _RequestType;
        /// <summary>
        /// نوع درخواست
        /// </summary>
        [Description("نوع درخواست")]
        [DisplayName("نوع درخواست")]
        [Category("")]
        [DocumentAttributeID("27265")]
        [IsRelationalAttribute("false")]
        [AttributeType("Long")]
        [Browsable(true)]
        public long RequestType
        {
            get { return _RequestType; }
            set { _RequestType = value; }
        }
        private string _RequestContent;
        /// <summary>
        /// محتوای درخواست
        /// </summary>
        [Description("محتوای درخواست")]
        [DisplayName("محتوا")]
        [Category("")]
        [DocumentAttributeID("11012")]
        [IsRelationalAttribute("false")]
        [AttributeType("LongText")]
        [Browsable(true)]
        public string RequestContent
        {
            get { return _RequestContent; }
            set { _RequestContent = value; }
        }
        private long _RequestKey;
        /// <summary>
        /// سریال درخواست
        /// </summary>
        [Description("سریال درخواست")]
        [DisplayName("سریال درخواست")]
        [Category("")]
        [DocumentAttributeID("11015")]
        [IsRelationalAttribute("false")]
        [AttributeType("Long")]
        [Browsable(true)]
        public long RequestKey
        {
            get { return _RequestKey; }
            set { _RequestKey = value; }
        }
        private string _SubSystem;
        /// <summary>
        /// زیرسیستم
        /// </summary>
        [Description("زیرسیستم")]
        [DisplayName("زیرسیستم")]
        [Category("")]
        [DocumentAttributeID("11021")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string SubSystem
        {
            get { return _SubSystem; }
            set { _SubSystem = value; }
        }
        private ELSSession _CorrelateSession;
        /// <summary>
        /// سریال ورود
        /// </summary>
        [Description("سریال ورود")]
        [DisplayName("سریال ورود")]
        [Category("")]
        [DocumentAttributeID("11012")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("ELSSession")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public ELSSession CorrelateSession
        {
            get { return _CorrelateSession; }
            set { _CorrelateSession = value; }
        }
        private SubSystem _CoSubSystem;
        /// <summary>
        /// زیر سیستم مربط
        /// </summary>
        [Description("زیر سیستم مربط")]
        [DisplayName("زیر سیستم مرتبط")]
        [Category("")]
        [DocumentAttributeID("11018")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SubSystem")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SubSystem CoSubSystem
        {
            get { return _CoSubSystem; }
            set { _CoSubSystem = value; }
        }
        public override string ToString()
        {
            return "";
        }
        public override void Initialize()
        {
            base.Initialize();
            this._RequestType = 0;
            this._RequestContent = "";
            this._RequestKey = 0;
            this._SubSystem = "";
            this._CorrelateSession = new ELSSession();
            this._CoSubSystem = new SubSystem();
        }
        public override SbnObject Clone(string sNodeName)
        {
            Request retObject = new Request(this);
            retObject.RequestType = this._RequestType;
            if (this._RequestContent != null) retObject.RequestContent = (string)this._RequestContent.Clone();
            retObject.RequestKey = this._RequestKey;
            retObject.SubSystem = this._SubSystem;
            if (!object.ReferenceEquals(this.CorrelateSession, null))
                retObject.CorrelateSession = (ELSSession)this.CorrelateSession.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoSubSystem, null))
                retObject.CoSubSystem = (SubSystem)this.CoSubSystem.Clone(sNodeName);
            return retObject;
        }
        public static string at_RequestType
        {
            get
            {
                return "Request.RequestType";
            }
        }
        public static string at_RequestContent
        {
            get
            {
                return "Request.RequestContent";
            }
        }
        public static string at_RequestKey
        {
            get
            {
                return "Request.RequestKey";
            }
        }
        public static string at_SubSystem
        {
            get
            {
                return "Request.SubSystem";
            }
        }
        public static string at_CorrelateSessionID
        {
            get
            {
                return "Request.CorrelateSessionID";
            }
        }
        public static string at_CorrelateSessionTitle
        {
            get
            {
                return "Request.CorrelateSession.Title";
            }
        }
        public static string at_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "Request.CorrelateSessionFirstLevelAttributes";
            }
        }
        public static string at_CorrelateSession_IPAddress
        {
            get
            {
                return "Request.CorrelateSession.IPAddress";
            }
        }
        public static string at_CorrelateSession_EndDate
        {
            get
            {
                return "Request.CorrelateSession.EndDate";
            }
        }
        public static string at_CorrelateSession_MACAddress
        {
            get
            {
                return "Request.CorrelateSession.MACAddress";
            }
        }
        public static string at_CorrelateSession_UserFirstLevelAttributes
        {
            get
            {
                return "Request.CorrelateSession.UserFirstLevelAttributes";
            }
        }
        public static string at_CoSubSystemID
        {
            get
            {
                return "Request.CoSubSystemID";
            }
        }
        public static string at_CoSubSystemTitle
        {
            get
            {
                return "Request.CoSubSystem.Title";
            }
        }
        public static string at_CoSubSystemFirstLevelAttributes
        {
            get
            {
                return "Request.CoSubSystemFirstLevelAttributes";
            }
        }
        public static string at_CoSubSystem_Title
        {
            get
            {
                return "Request.CoSubSystem.Title";
            }
        }
    }
}
