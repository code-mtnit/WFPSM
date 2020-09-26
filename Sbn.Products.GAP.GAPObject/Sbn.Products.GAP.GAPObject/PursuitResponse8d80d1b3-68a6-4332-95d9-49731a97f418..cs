using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Systems.WMC.WMCObject;
namespace Sbn.Products.GAP.GAPObject
{
    [Description("پاسخ پیگیری")]
    [DisplayName("پاسخ پیگیری")]
    [ObjectCode("30001")]
    [SystemName("GAP")]
    [ItemsType("Sbn.Products.GAP.GAPObject.PursuitResponses")]
    [Serializable]
    public class PursuitResponse : SbnObject
    {
        public PursuitResponse()
            : base()
        {
        }
        public PursuitResponse(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private string _ImplementDate;
        /// <summary>
        /// تاریخ اجرا
        /// </summary>
        [Description("تاریخ اجرا")]
        [DisplayName("تاریخ اجرا")]
        [Category("")]
        [DocumentAttributeID("27169")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string ImplementDate
        {
            get { return _ImplementDate; }
            set { _ImplementDate = value; }
        }
        private string _ResponseDate;
        /// <summary>
        /// تاریخ پاسخ
        /// </summary>
        [Description("تاریخ پاسخ")]
        [DisplayName("تاریخ پاسخ")]
        [Category("")]
        [DocumentAttributeID("27170")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string ResponseDate
        {
            get { return _ResponseDate; }
            set { _ResponseDate = value; }
        }
        private PursuitAttachments _Attachments;
        /// <summary>
        /// ضمائم
        /// </summary>
        [Description("ضمائم")]
        [DisplayName("ضمائم")]
        [Category("")]
        [DocumentAttributeID("27265")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("PursuitAttachments")]
        [IsMiddleTableExist("False")]
        [RelationTable("Response_Attach_M")]
        public PursuitAttachments Attachments
        {
            get { return _Attachments; }
            set { _Attachments = value; }
        }
        private Pursuit _CoPursuit;
        /// <summary>
        /// پیگیری مرتبط
        /// </summary>
        [Category("")]
        [DocumentAttributeID("27266")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Pursuit")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        [Description("پیگیری مرتبط")]
        [DisplayName("پیگیری مرتبط")]
        public Pursuit CoPursuit
        {
            get { return _CoPursuit; }
            set { _CoPursuit = value; }
        }
        private BasicInfoDetail _ImplementStatus;
        /// <summary>
        /// وضعیت اجرا
        /// </summary>
        [Description("وضعیت اجرا")]
        [DisplayName("وضعیت اجرا")]
        [Category("")]
        [DocumentAttributeID("27267")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail ImplementStatus
        {
            get { return _ImplementStatus; }
            set { _ImplementStatus = value; }
        }
        private BasicInfoDetail _ResponseQualityType;
        /// <summary>
        /// کیفیت پاسخ
        /// </summary>
        [Description("کیفیت پاسخ")]
        [DisplayName("کیفیت پاسخ")]
        [Category("")]
        [DocumentAttributeID("27268")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail ResponseQualityType
        {
            get { return _ResponseQualityType; }
            set { _ResponseQualityType = value; }
        }
        private SbnBoolean _IsFinished = SbnBoolean.OutOfValue;
        /// <summary>
        /// آیا پاسخ نهایی شده و آماده ارسال است.
        /// </summary>
        [Description("آیا پاسخ نهایی شده و آماده ارسال است.")]
        [DisplayName("نهایی شده")]
        [Category("")]
        [DocumentAttributeID("27275")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsFinished
        {
            get { return _IsFinished; }
            set { _IsFinished = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._ImplementDate = "";
            this._ResponseDate = "";
            this._Attachments = new PursuitAttachments();
            this._CoPursuit = new Pursuit();
            this._ImplementStatus = new BasicInfoDetail();
            this._ResponseQualityType = new BasicInfoDetail();
            this._IsFinished = SbnBoolean.OutOfValue;
        }
        public override SbnObject Clone(string sNodeName)
        {
            PursuitResponse retObject = new PursuitResponse(this);
            if (this._ImplementDate != null) retObject.ImplementDate = (string)this._ImplementDate.Clone();
            if (this._ResponseDate != null) retObject.ResponseDate = (string)this._ResponseDate.Clone();
            if (!object.ReferenceEquals(this.Attachments, null))
                retObject.Attachments = (PursuitAttachments)this.Attachments.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoPursuit, null))
                retObject.CoPursuit = (Pursuit)this.CoPursuit.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ImplementStatus, null))
                retObject.ImplementStatus = (BasicInfoDetail)this.ImplementStatus.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ResponseQualityType, null))
                retObject.ResponseQualityType = (BasicInfoDetail)this.ResponseQualityType.Clone(sNodeName);
            retObject.IsFinished = this.IsFinished;
            return retObject;
        }
        public static string at_ImplementDate
        {
            get
            {
                return "PursuitResponse.ImplementDate";
            }
        }
        public static string at_ResponseDate
        {
            get
            {
                return "PursuitResponse.ResponseDate";
            }
        }
        public static string at_AttachmentsID
        {
            get
            {
                return "PursuitResponse.AttachmentsID";
            }
        }
        public static string at_AttachmentsTitle
        {
            get
            {
                return "PursuitResponse.Attachments.Title";
            }
        }
        public static string at_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "PursuitResponse.AttachmentsFirstLevelAttributes";
            }
        }
        public static string at_CoPursuitID
        {
            get
            {
                return "PursuitResponse.CoPursuitID";
            }
        }
        public static string at_CoPursuitTitle
        {
            get
            {
                return "PursuitResponse.CoPursuit.Title";
            }
        }
        public static string at_CoPursuitFirstLevelAttributes
        {
            get
            {
                return "PursuitResponse.CoPursuitFirstLevelAttributes";
            }
        }
        public static string at_CoPursuit_OpportunityDate
        {
            get
            {
                return "PursuitResponse.CoPursuit.OpportunityDate";
            }
        }
        public static string at_CoPursuit_PursuitReport
        {
            get
            {
                return "PursuitResponse.CoPursuit.PursuitReport";
            }
        }
        public static string at_CoPursuit_CoDocuemntFirstLevelAttributes
        {
            get
            {
                return "PursuitResponse.CoPursuit.CoDocuemntFirstLevelAttributes";
            }
        }
        public static string at_CoPursuit_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "PursuitResponse.CoPursuit.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoPursuit_CoOrganFirstLevelAttributes
        {
            get
            {
                return "PursuitResponse.CoPursuit.CoOrganFirstLevelAttributes";
            }
        }
        public static string at_CoPursuit_ResponsesFirstLevelAttributes
        {
            get
            {
                return "PursuitResponse.CoPursuit.ResponsesFirstLevelAttributes";
            }
        }
        public static string at_ImplementStatusID
        {
            get
            {
                return "PursuitResponse.ImplementStatusID";
            }
        }
        public static string at_ImplementStatusTitle
        {
            get
            {
                return "PursuitResponse.ImplementStatus.Title";
            }
        }
        public static string at_ImplementStatusFirstLevelAttributes
        {
            get
            {
                return "PursuitResponse.ImplementStatusFirstLevelAttributes";
            }
        }
        public static string at_ImplementStatus_OrderInList
        {
            get
            {
                return "PursuitResponse.ImplementStatus.OrderInList";
            }
        }
        public static string at_ImplementStatus_ParentFirstLevelAttributes
        {
            get
            {
                return "PursuitResponse.ImplementStatus.ParentFirstLevelAttributes";
            }
        }
        public static string at_ResponseQualityTypeID
        {
            get
            {
                return "PursuitResponse.ResponseQualityTypeID";
            }
        }
        public static string at_ResponseQualityTypeTitle
        {
            get
            {
                return "PursuitResponse.ResponseQualityType.Title";
            }
        }
        public static string at_ResponseQualityTypeFirstLevelAttributes
        {
            get
            {
                return "PursuitResponse.ResponseQualityTypeFirstLevelAttributes";
            }
        }
        public static string at_ResponseQualityType_OrderInList
        {
            get
            {
                return "PursuitResponse.ResponseQualityType.OrderInList";
            }
        }
        public static string at_ResponseQualityType_ParentFirstLevelAttributes
        {
            get
            {
                return "PursuitResponse.ResponseQualityType.ParentFirstLevelAttributes";
            }
        }
        public static string at_IsFinished
        {
            get
            {
                return "PursuitResponse.IsFinished";
            }
        }
    }
}
