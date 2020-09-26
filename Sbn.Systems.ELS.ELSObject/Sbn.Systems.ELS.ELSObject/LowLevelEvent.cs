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
    [Description("رويداد سطح پايين")]
    [DisplayName("رويداد سطح پايين")]
    [ObjectCode("120")]
    [SystemName("ELS")]
    [ItemsType("Sbn.Systems.ELS.ELSObject.LowLevelEvents")]
    [Serializable]
    public class LowLevelEvent : SbnObject
    {
        public LowLevelEvent()
            : base()
        {
        }
        public LowLevelEvent(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private string _MethodName;
        /// <summary>
        /// نام تابع
        /// </summary>
        [Description("نام تابع")]
        [DisplayName("نام تابع")]
        [Category("")]
        [DocumentAttributeID("62")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string MethodName
        {
            get { return _MethodName; }
            set { _MethodName = value; }
        }
        private long _RequestKey;
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [DisplayName("سریال درخواست")]
        [Category("")]
        [DocumentAttributeID("11022")]
        [IsRelationalAttribute("false")]
        [AttributeType("Long")]
        [Browsable(true)]
        public long RequestKey
        {
            get { return _RequestKey; }
            set { _RequestKey = value; }
        }
        private DocumentType _ObjectType;
        /// <summary>
        /// نوع سند
        /// </summary>
        [Description("نوع سند")]
        [DisplayName("نوع سند")]
        [Category("")]
        [DocumentAttributeID("11009")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("DocumentType")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public DocumentType ObjectType
        {
            get { return _ObjectType; }
            set { _ObjectType = value; }
        }
        private EventCommandType _CommandType = EventCommandType.OutOfValue;
        /// <summary>
        /// نوع رویداد
        /// </summary>
        [Description("نوع رویداد")]
        [DisplayName("نوع رویداد")]
        [Category("")]
        [DocumentAttributeID("11011")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("EventCommandType")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public EventCommandType CommandType
        {
            get { return _CommandType; }
            set { _CommandType = value; }
        }
        private Document _CoDocument;
        /// <summary>
        /// سند مرتبط
        /// </summary>
        [Description("سند مرتبط")]
        [DisplayName("سند مرتبط")]
        [Category("")]
        [DocumentAttributeID("11013")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Document")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Document CoDocument
        {
            get { return _CoDocument; }
            set { _CoDocument = value; }
        }
        private ELSSession _CorrelateSession;
        /// <summary>
        /// سریال ورود مرتبط
        /// </summary>
        [Description("سریال ورود مرتبط")]
        [DisplayName("سریال ورود")]
        [Category("")]
        [DocumentAttributeID("11001")]
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
        private Document _CoParentDocument;
        /// <summary>
        /// سند پدر
        /// </summary>
        [Description("سند پدر")]
        [DisplayName("سند پدر")]
        [Category("")]
        [DocumentAttributeID("11016")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Document")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Document CoParentDocument
        {
            get { return _CoParentDocument; }
            set { _CoParentDocument = value; }
        }
        private Request _CoRequest;
        /// <summary>
        /// درخواست مرتبط
        /// </summary>
        [Description("درخواست مرتبط")]
        [DisplayName("درخواست مرتبط")]
        [Category("")]
        [DocumentAttributeID("27511")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Request")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Request CoRequest
        {
            get { return _CoRequest; }
            set { _CoRequest = value; }
        }
        private Document _CoChild;
        /// <summary>
        /// سند پایینی
        /// </summary>
        [Description("سند پایینی")]
        [DisplayName("سند پایینی")]
        [Category("")]
        [DocumentAttributeID("27514")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Document")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Document CoChild
        {
            get { return _CoChild; }
            set { _CoChild = value; }
        }
        public override string ToString()
        {
            if (this.CoDocument != null)
            {
                return this.CoDocument.DisplayID + "-" + this.MethodName;
            }
            return "";

        }
        public override void Initialize()
        {
            base.Initialize();
            this._MethodName = "";
            this._RequestKey = 0;
            this._ObjectType = new DocumentType();
            this._CommandType = EventCommandType.OutOfValue;
            this._CoDocument = new Document();
            this._CorrelateSession = new ELSSession();
            this._CoParentDocument = new Document();
            this._CoRequest = new Request();
            this._CoChild = new Document();
        }
        public override SbnObject Clone(string sNodeName)
        {
            LowLevelEvent retObject = new LowLevelEvent(this);
            retObject.MethodName = this._MethodName;
            retObject.RequestKey = this._RequestKey;
            if (!object.ReferenceEquals(this.ObjectType, null))
                retObject.ObjectType = (DocumentType)this.ObjectType.Clone(sNodeName);
            retObject.CommandType = this.CommandType;
            if (!object.ReferenceEquals(this.CoDocument, null))
                retObject.CoDocument = (Document)this.CoDocument.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CorrelateSession, null))
                retObject.CorrelateSession = (ELSSession)this.CorrelateSession.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoParentDocument, null))
                retObject.CoParentDocument = (Document)this.CoParentDocument.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoRequest, null))
                retObject.CoRequest = (Request)this.CoRequest.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoChild, null))
                retObject.CoChild = (Document)this.CoChild.Clone(sNodeName);
            return retObject;
        }
        public static string at_MethodName
        {
            get
            {
                return "LowLevelEvent.MethodName";
            }
        }
        public static string at_RequestKey
        {
            get
            {
                return "LowLevelEvent.RequestKey";
            }
        }
        public static string at_ObjectTypeID
        {
            get
            {
                return "LowLevelEvent.ObjectTypeID";
            }
        }
        public static string at_ObjectTypeTitle
        {
            get
            {
                return "LowLevelEvent.ObjectType.Title";
            }
        }
        public static string at_ObjectTypeFirstLevelAttributes
        {
            get
            {
                return "LowLevelEvent.ObjectTypeFirstLevelAttributes";
            }
        }
        public static string at_ObjectType_Title
        {
            get
            {
                return "LowLevelEvent.ObjectType.Title";
            }
        }
        public static string at_CommandType
        {
            get
            {
                return "LowLevelEvent.CommandType";
            }
        }
        public static string at_CoDocumentID
        {
            get
            {
                return "LowLevelEvent.CoDocumentID";
            }
        }
        public static string at_CoDocumentTitle
        {
            get
            {
                return "LowLevelEvent.CoDocument.Title";
            }
        }
        public static string at_CoDocumentFirstLevelAttributes
        {
            get
            {
                return "LowLevelEvent.CoDocumentFirstLevelAttributes";
            }
        }
        public static string at_CoDocument_BusinessDocumentCode
        {
            get
            {
                return "LowLevelEvent.CoDocument.BusinessDocumentCode";
            }
        }
        public static string at_CoDocument_DisplayID
        {
            get
            {
                return "LowLevelEvent.CoDocument.DisplayID";
            }
        }
        public static string at_CoDocument_Description
        {
            get
            {
                return "LowLevelEvent.CoDocument.Description";
            }
        }
        public static string at_CoDocument_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "LowLevelEvent.CoDocument.DocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CorrelateSessionID
        {
            get
            {
                return "LowLevelEvent.CorrelateSessionID";
            }
        }
        public static string at_CorrelateSessionTitle
        {
            get
            {
                return "LowLevelEvent.CorrelateSession.Title";
            }
        }
        public static string at_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "LowLevelEvent.CorrelateSessionFirstLevelAttributes";
            }
        }
        public static string at_CorrelateSession_IPAddress
        {
            get
            {
                return "LowLevelEvent.CorrelateSession.IPAddress";
            }
        }
        public static string at_CorrelateSession_EndDate
        {
            get
            {
                return "LowLevelEvent.CorrelateSession.EndDate";
            }
        }
        public static string at_CorrelateSession_MACAddress
        {
            get
            {
                return "LowLevelEvent.CorrelateSession.MACAddress";
            }
        }
        public static string at_CorrelateSession_UserFirstLevelAttributes
        {
            get
            {
                return "LowLevelEvent.CorrelateSession.UserFirstLevelAttributes";
            }
        }
        public static string at_CoParentDocumentID
        {
            get
            {
                return "LowLevelEvent.CoParentDocumentID";
            }
        }
        public static string at_CoParentDocumentTitle
        {
            get
            {
                return "LowLevelEvent.CoParentDocument.Title";
            }
        }
        public static string at_CoParentDocumentFirstLevelAttributes
        {
            get
            {
                return "LowLevelEvent.CoParentDocumentFirstLevelAttributes";
            }
        }
        public static string at_CoParentDocument_BusinessDocumentCode
        {
            get
            {
                return "LowLevelEvent.CoParentDocument.BusinessDocumentCode";
            }
        }
        public static string at_CoParentDocument_DisplayID
        {
            get
            {
                return "LowLevelEvent.CoParentDocument.DisplayID";
            }
        }
        public static string at_CoParentDocument_Description
        {
            get
            {
                return "LowLevelEvent.CoParentDocument.Description";
            }
        }
        public static string at_CoParentDocument_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "LowLevelEvent.CoParentDocument.DocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoRequestID
        {
            get
            {
                return "LowLevelEvent.CoRequestID";
            }
        }
        public static string at_CoRequestTitle
        {
            get
            {
                return "LowLevelEvent.CoRequest.Title";
            }
        }
        public static string at_CoRequestFirstLevelAttributes
        {
            get
            {
                return "LowLevelEvent.CoRequestFirstLevelAttributes";
            }
        }
        public static string at_CoRequest_RequestContent
        {
            get
            {
                return "LowLevelEvent.CoRequest.RequestContent";
            }
        }
        public static string at_CoRequest_RequestKey
        {
            get
            {
                return "LowLevelEvent.CoRequest.RequestKey";
            }
        }
        public static string at_CoRequest_SubSystem
        {
            get
            {
                return "LowLevelEvent.CoRequest.SubSystem";
            }
        }
        public static string at_CoRequest_CorrelateSessionFirstLevelAttributes
        {
            get
            {
                return "LowLevelEvent.CoRequest.CorrelateSessionFirstLevelAttributes";
            }
        }
        public static string at_CoRequest_CoSubSystemFirstLevelAttributes
        {
            get
            {
                return "LowLevelEvent.CoRequest.CoSubSystemFirstLevelAttributes";
            }
        }
        public static string at_CoChildID
        {
            get
            {
                return "LowLevelEvent.CoChildID";
            }
        }
        public static string at_CoChildTitle
        {
            get
            {
                return "LowLevelEvent.CoChild.Title";
            }
        }
        public static string at_CoChildFirstLevelAttributes
        {
            get
            {
                return "LowLevelEvent.CoChildFirstLevelAttributes";
            }
        }
        public static string at_CoChild_BusinessDocumentCode
        {
            get
            {
                return "LowLevelEvent.CoChild.BusinessDocumentCode";
            }
        }
        public static string at_CoChild_DisplayID
        {
            get
            {
                return "LowLevelEvent.CoChild.DisplayID";
            }
        }
        public static string at_CoChild_Description
        {
            get
            {
                return "LowLevelEvent.CoChild.Description";
            }
        }
        public static string at_CoChild_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "LowLevelEvent.CoChild.DocumentTypeFirstLevelAttributes";
            }
        }
    }
}
