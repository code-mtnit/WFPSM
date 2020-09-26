using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
namespace Sbn.Systems.WMC.WMCObject
{
    [Description("فعاليت مرتبط با يك وظيفه")]
    [DisplayName("فعاليت مرتبط با يك وظيفه")]
    [ObjectCode("2005")]
    [SystemName("WMC")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.Activities")]
    [Serializable]
    public class Activity : SbnObject
    {
        public Activity()
            : base()
        {
        }
        public Activity(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private string _ReceivedDate;
        /// <summary>
        /// تاریخ دریافت وظیفه
        /// </summary>
        [Description("تاریخ دریافت وظیفه")]
        [DisplayName("تاریخ دریافت")]
        [Category("")]
        [DocumentAttributeID("2008")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string ReceivedDate
        {
            get { return _ReceivedDate; }
            set { _ReceivedDate = value; }
        }
        private string _SendDate;
        /// <summary>
        /// تاریخ ارسال
        /// </summary>
        [Description("تاریخ ارسال")]
        [DisplayName("تاریخ ارسال")]
        [Category("")]
        [DocumentAttributeID("2009")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string SendDate
        {
            get { return _SendDate; }
            set { _SendDate = value; }
        }
        private string _ActivityDescription;
        /// <summary>
        /// شرح اقدام انجام شده
        /// </summary>
        [Description("شرح اقدام انجام شده")]
        [DisplayName("شرح اقدام")]
        [Category("")]
        [DocumentAttributeID("2019")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string ActivityDescription
        {
            get { return _ActivityDescription; }
            set { _ActivityDescription = value; }
        }
        private string _ActivityOrderDesc;
        /// <summary>
        /// شرح اقدام خواسته شده
        /// </summary>
        [Description("شرح اقدام خواسته شده")]
        [DisplayName("شرح اقدام")]
        [Category("")]
        [DocumentAttributeID("2046")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string ActivityOrderDesc
        {
            get { return _ActivityOrderDesc; }
            set { _ActivityOrderDesc = value; }
        }
        private string _ReminderDate;
        /// <summary>
        /// زمان یادآوری
        /// </summary>
        [Description("زمان یادآوری")]
        [DisplayName("زمان یادآوری")]
        [Category("")]
        [DocumentAttributeID("2048")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string ReminderDate
        {
            get { return _ReminderDate; }
            set { _ReminderDate = value; }
        }
        private int _PercentOfDevelop;
        /// <summary>
        /// درصد پیشرفت
        /// </summary>
        [Description("درصد پیشرفت")]
        [DisplayName("درصد پیشرفت")]
        [Category("")]
        [DocumentAttributeID("2056")]
        [IsRelationalAttribute("false")]
        [AttributeType("Int")]
        [Browsable(true)]
        public int PercentOfDevelop
        {
            get { return _PercentOfDevelop; }
            set { _PercentOfDevelop = value; }
        }
        private Worker _CurrentWorker;
        /// <summary>
        /// کارمند فعلی
        /// </summary>
        [Description("کارمند فعلی")]
        [DisplayName("کارمند")]
        [Category("")]
        [DocumentAttributeID("2013")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Worker")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Worker CurrentWorker
        {
            get { return _CurrentWorker; }
            set { _CurrentWorker = value; }
        }
        private ActivityPriorityType _PriorityType = ActivityPriorityType.OutOfValue;
        /// <summary>
        /// اولویت
        /// </summary>
        [Description("اولویت")]
        [DisplayName("اولویت")]
        [Category("")]
        [DocumentAttributeID("2023")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("ActivityPriorityType")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public ActivityPriorityType PriorityType
        {
            get { return _PriorityType; }
            set { _PriorityType = value; }
        }
        private Activity _PreviousActivity;
        /// <summary>
        /// وظیفه قبلی
        /// </summary>
        [Description("وظیفه قبلی")]
        [DisplayName("وظیفه قبلی")]
        [Category("")]
        [DocumentAttributeID("2025")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Activity")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Activity PreviousActivity
        {
            get { return _PreviousActivity; }
            set { _PreviousActivity = value; }
        }
        private Activity _PrevRejectedActivity;
        /// <summary>
        /// وظیفه قبلی سند مرجوع شده
        /// </summary>
        [Description("وظیفه قبلی سند مرجوع شده")]
        [DisplayName("وظیفه ماقبل سند قبلی")]
        [Category("")]
        [DocumentAttributeID("2026")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Activity")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Activity PrevRejectedActivity
        {
            get { return _PrevRejectedActivity; }
            set { _PrevRejectedActivity = value; }
        }
        private WorkGroup _CoWorkGroup;
        /// <summary>
        /// گروه کاری که این وظیفه در آن جریان دارد
        /// </summary>
        [Description("گروه کاری که این وظیفه در آن جریان دارد")]
        [DisplayName("گروه کاری")]
        [Category("")]
        [DocumentAttributeID("2041")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("WorkGroup")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public WorkGroup CoWorkGroup
        {
            get { return _CoWorkGroup; }
            set { _CoWorkGroup = value; }
        }
        private ActivityActionType _ActionType = ActivityActionType.OutOfValue;
        /// <summary>
        /// نوع اقدام انجام شده
        /// </summary>
        [Description("نوع اقدام انجام شده")]
        [DisplayName("نوع اقدام")]
        [Category("")]
        [DocumentAttributeID("2129")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("ActivityActionType")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public ActivityActionType ActionType
        {
            get { return _ActionType; }
            set { _ActionType = value; }
        }
        private SbnBoolean _IsViewed = SbnBoolean.OutOfValue;
        /// <summary>
        /// مشاهده شده
        /// </summary>
        [Description("مشاهده شده")]
        [DisplayName("مشاهده شده")]
        [Category("")]
        [DocumentAttributeID("27058")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsViewed
        {
            get { return _IsViewed; }
            set { _IsViewed = value; }
        }
        private Folder _CoFolder;
        /// <summary>
        /// پوشه مرتبط -
        /// </summary>
        [Description("پوشه مرتبط -")]
        [DisplayName("پوشه مرتبط")]
        [Category("")]
        [DocumentAttributeID("27072")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Folder")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Folder CoFolder
        {
            get { return _CoFolder; }
            set { _CoFolder = value; }
        }
        private SbnBoolean _IsHidden = SbnBoolean.OutOfValue;
        /// <summary>
        /// 
        /// </summary>
        [Description("غیر قابل نمایش")]
        [DisplayName("غیر قابل نمایش")]
        [Category("")]
        [DocumentAttributeID("27446")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsHidden
        {
            get { return _IsHidden; }
            set { _IsHidden = value; }
        }
        private Document _CoDocument;
        /// <summary>
        /// سند مرتبط
        /// </summary>
        [Description("سند مرتبط")]
        [DisplayName("سند مرتبط")]
        [Category("")]
        [DocumentAttributeID("2109")]
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
        private ActivityComplementInfo _ComplementInfo;
        /// <summary>
        /// توضیحات
        /// </summary>
        [Description("توضیحات")]
        [DisplayName("توضیحات")]
        [Category("")]
        [DocumentAttributeID("2112")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("ActivityComplementInfo")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public ActivityComplementInfo ComplementInfo
        {
            get { return _ComplementInfo; }
            set { _ComplementInfo = value; }
        }
        private ActivityArchiveStatus _ArchiveStatus = ActivityArchiveStatus.OutOfValue;
        /// <summary>
        /// وضعیت آرشیو
        /// </summary>
        [Description("وضعیت آرشیو")]
        [DisplayName("وضعیت آرشیو")]
        [Category("")]
        [DocumentAttributeID("27065")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("ActivityArchiveStatus")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public ActivityArchiveStatus ArchiveStatus
        {
            get { return _ArchiveStatus; }
            set { _ArchiveStatus = value; }
        }
        private DocumentType _CoDocumentType;
        /// <summary>
        /// نوع سند
        /// </summary>
        [Description("نوع سند")]
        [DisplayName("نوع سند")]
        [Category("")]
        [DocumentAttributeID("27039")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("DocumentType")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public DocumentType CoDocumentType
        {
            get { return _CoDocumentType; }
            set { _CoDocumentType = value; }
        }
        private Task _CoTask;
        /// <summary>
        /// وظیفه مرتبط
        /// </summary>
        [Description("وظیفه مرتبط")]
        [DisplayName("وظیفه مرتبط")]
        [Category("")]
        [DocumentAttributeID("2115")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Task")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Task CoTask
        {
            get { return _CoTask; }
            set { _CoTask = value; }
        }
        private SbnBoolean _HasReminderFlag = SbnBoolean.OutOfValue;
        /// <summary>
        /// آیا پرچم خورده است؟
        /// </summary>
        [Description("آیا پرچم خورده است؟")]
        [DisplayName("پرچم یادآوری")]
        [Category("")]
        [DocumentAttributeID("2117")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean HasReminderFlag
        {
            get { return _HasReminderFlag; }
            set { _HasReminderFlag = value; }
        }
        private WMCAttachments _Attachments;
        /// <summary>
        /// ضمائم
        /// </summary>
        [Description("ضمائم")]
        [DisplayName("ضمائم")]
        [Category("")]
        [DocumentAttributeID("27090")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("WMCAttachments")]
        [IsMiddleTableExist("False")]
        [RelationTable("Activity_Attachment")]
        public WMCAttachments Attachments
        {
            get { return _Attachments; }
            set { _Attachments = value; }
        }
        private WFPlace _CoPlace;
        /// <summary>
        /// مرحله مرتبط در فرایند
        /// </summary>
        [Description("مرحله مرتبط در فرایند")]
        [DisplayName("مرحله مرتبط")]
        [Category("")]
        [DocumentAttributeID("27278")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("WFPlace")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public WFPlace CoPlace
        {
            get { return _CoPlace; }
            set { _CoPlace = value; }
        }
        private WorkContext _CoWC;
        /// <summary>
        /// زمینه کاری
        /// </summary>
        [Description("زمینه کاری")]
        [DisplayName("زمینه کاری")]
        [Category("")]
        [DocumentAttributeID("27434")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("WorkContext")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public WorkContext CoWC
        {
            get { return _CoWC; }
            set { _CoWC = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._ReceivedDate = "";
            this._SendDate = "";
            this._ActivityDescription = "";
            this._ActivityOrderDesc = "";
            this._ReminderDate = "";
            this._PercentOfDevelop = 0;
            this._CurrentWorker = new Worker();
            this._PriorityType = ActivityPriorityType.OutOfValue;
            this._PreviousActivity = new Activity();
            this._PrevRejectedActivity = new Activity();
            this._CoWorkGroup = new WorkGroup();
            this._ActionType = ActivityActionType.OutOfValue;
            this._IsViewed = SbnBoolean.OutOfValue;
            this._CoFolder = new Folder();
            this._IsHidden = SbnBoolean.OutOfValue;
            this._CoDocument = new Document();
            this._ComplementInfo = new ActivityComplementInfo();
            this._ArchiveStatus = ActivityArchiveStatus.OutOfValue;
            this._CoDocumentType = new DocumentType();
            this._CoTask = new Task();
            this._HasReminderFlag = SbnBoolean.OutOfValue;
            this._Attachments = new WMCAttachments();
            this._CoPlace = new WFPlace();
            this._CoWC = new WorkContext();
        }
        public override SbnObject Clone(string sNodeName)
        {
            Activity retObject = new Activity(this);
            if (this._ReceivedDate != null) retObject.ReceivedDate = (string)this._ReceivedDate.Clone();
            if (this._SendDate != null) retObject.SendDate = (string)this._SendDate.Clone();
            retObject.ActivityDescription = this._ActivityDescription;
            retObject.ActivityOrderDesc = this._ActivityOrderDesc;
            if (this._ReminderDate != null) retObject.ReminderDate = (string)this._ReminderDate.Clone();
            retObject.PercentOfDevelop = this._PercentOfDevelop;
            if (!object.ReferenceEquals(this.CurrentWorker, null))
                retObject.CurrentWorker = (Worker)this.CurrentWorker.Clone(sNodeName);
            retObject.PriorityType = this.PriorityType;
            if (!object.ReferenceEquals(this.PreviousActivity, null))
                retObject.PreviousActivity = (Activity)this.PreviousActivity.Clone(sNodeName);
            if (!object.ReferenceEquals(this.PrevRejectedActivity, null))
                retObject.PrevRejectedActivity = (Activity)this.PrevRejectedActivity.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoWorkGroup, null))
                retObject.CoWorkGroup = (WorkGroup)this.CoWorkGroup.Clone(sNodeName);
            retObject.ActionType = this.ActionType;
            retObject.IsViewed = this.IsViewed;
            if (!object.ReferenceEquals(this.CoFolder, null))
                retObject.CoFolder = (Folder)this.CoFolder.Clone(sNodeName);
            retObject.IsHidden = this.IsHidden;
            if (!object.ReferenceEquals(this.CoDocument, null))
                retObject.CoDocument = (Document)this.CoDocument.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ComplementInfo, null))
                retObject.ComplementInfo = (ActivityComplementInfo)this.ComplementInfo.Clone(sNodeName);
            retObject.ArchiveStatus = this.ArchiveStatus;
            if (!object.ReferenceEquals(this.CoDocumentType, null))
                retObject.CoDocumentType = (DocumentType)this.CoDocumentType.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoTask, null))
                retObject.CoTask = (Task)this.CoTask.Clone(sNodeName);
            retObject.HasReminderFlag = this.HasReminderFlag;
            if (!object.ReferenceEquals(this.Attachments, null))
                retObject.Attachments = (WMCAttachments)this.Attachments.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoPlace, null))
                retObject.CoPlace = (WFPlace)this.CoPlace.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoWC, null))
                retObject.CoWC = (WorkContext)this.CoWC.Clone(sNodeName);
            return retObject;
        }
        public static string at_ReceivedDate
        {
            get
            {
                return "Activity.ReceivedDate";
            }
        }
        public static string at_SendDate
        {
            get
            {
                return "Activity.SendDate";
            }
        }
        public static string at_ActivityDescription
        {
            get
            {
                return "Activity.ActivityDescription";
            }
        }
        public static string at_ActivityOrderDesc
        {
            get
            {
                return "Activity.ActivityOrderDesc";
            }
        }
        public static string at_ReminderDate
        {
            get
            {
                return "Activity.ReminderDate";
            }
        }
        public static string at_PercentOfDevelop
        {
            get
            {
                return "Activity.PercentOfDevelop";
            }
        }
        public static string at_CurrentWorkerID
        {
            get
            {
                return "Activity.CurrentWorkerID";
            }
        }
        public static string at_CurrentWorkerTitle
        {
            get
            {
                return "Activity.CurrentWorker.Title";
            }
        }
        public static string at_CurrentWorkerFirstLevelAttributes
        {
            get
            {
                return "Activity.CurrentWorkerFirstLevelAttributes";
            }
        }
        public static string at_CurrentWorker_StartWorkDate
        {
            get
            {
                return "Activity.CurrentWorker.StartWorkDate";
            }
        }
        public static string at_CurrentWorker_EndWorkDate
        {
            get
            {
                return "Activity.CurrentWorker.EndWorkDate";
            }
        }
        public static string at_CurrentWorker_IconStream
        {
            get
            {
                return "Activity.CurrentWorker.IconStream";
            }
        }
        public static string at_CurrentWorker_CoPositionFirstLevelAttributes
        {
            get
            {
                return "Activity.CurrentWorker.CoPositionFirstLevelAttributes";
            }
        }
        public static string at_CurrentWorker_RestrictionsFirstLevelAttributes
        {
            get
            {
                return "Activity.CurrentWorker.RestrictionsFirstLevelAttributes";
            }
        }
        public static string at_CurrentWorker_CoPersonFirstLevelAttributes
        {
            get
            {
                return "Activity.CurrentWorker.CoPersonFirstLevelAttributes";
            }
        }
        public static string at_CurrentWorker_AccessrightsFirstLevelAttributes
        {
            get
            {
                return "Activity.CurrentWorker.AccessrightsFirstLevelAttributes";
            }
        }
        public static string at_CurrentWorker_WorkerJobFirstLevelAttributes
        {
            get
            {
                return "Activity.CurrentWorker.WorkerJobFirstLevelAttributes";
            }
        }
        public static string at_CurrentWorker_CoRolesFirstLevelAttributes
        {
            get
            {
                return "Activity.CurrentWorker.CoRolesFirstLevelAttributes";
            }
        }
        public static string at_PriorityType
        {
            get
            {
                return "Activity.PriorityType";
            }
        }
        public static string at_PreviousActivityID
        {
            get
            {
                return "Activity.PreviousActivityID";
            }
        }
        public static string at_PreviousActivityTitle
        {
            get
            {
                return "Activity.PreviousActivity.Title";
            }
        }
        public static string at_PreviousActivityFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivityFirstLevelAttributes";
            }
        }
        public static string at_PreviousActivity_ReceivedDate
        {
            get
            {
                return "Activity.PreviousActivity.ReceivedDate";
            }
        }
        public static string at_PreviousActivity_SendDate
        {
            get
            {
                return "Activity.PreviousActivity.SendDate";
            }
        }
        public static string at_PreviousActivity_ActivityDescription
        {
            get
            {
                return "Activity.PreviousActivity.ActivityDescription";
            }
        }
        public static string at_PreviousActivity_ActivityOrderDesc
        {
            get
            {
                return "Activity.PreviousActivity.ActivityOrderDesc";
            }
        }
        public static string at_PreviousActivity_ReminderDate
        {
            get
            {
                return "Activity.PreviousActivity.ReminderDate";
            }
        }
        public static string at_PreviousActivity_PercentOfDevelop
        {
            get
            {
                return "Activity.PreviousActivity.PercentOfDevelop";
            }
        }
        public static string at_PreviousActivity_CurrentWorkerFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivity.CurrentWorkerFirstLevelAttributes";
            }
        }
        public static string at_PreviousActivity_PreviousActivityFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivity.PreviousActivityFirstLevelAttributes";
            }
        }
        public static string at_PreviousActivity_PrevRejectedActivityFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivity.PrevRejectedActivityFirstLevelAttributes";
            }
        }
        public static string at_PreviousActivity_CoWorkGroupFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivity.CoWorkGroupFirstLevelAttributes";
            }
        }
        public static string at_PreviousActivity_CoFolderFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivity.CoFolderFirstLevelAttributes";
            }
        }
        public static string at_PreviousActivity_CoDocumentFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivity.CoDocumentFirstLevelAttributes";
            }
        }
        public static string at_PreviousActivity_ComplementInfoFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivity.ComplementInfoFirstLevelAttributes";
            }
        }
        public static string at_PreviousActivity_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivity.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_PreviousActivity_CoTaskFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivity.CoTaskFirstLevelAttributes";
            }
        }
        public static string at_PreviousActivity_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivity.AttachmentsFirstLevelAttributes";
            }
        }
        public static string at_PreviousActivity_CoPlaceFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivity.CoPlaceFirstLevelAttributes";
            }
        }
        public static string at_PreviousActivity_CoWCFirstLevelAttributes
        {
            get
            {
                return "Activity.PreviousActivity.CoWCFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivityID
        {
            get
            {
                return "Activity.PrevRejectedActivityID";
            }
        }
        public static string at_PrevRejectedActivityTitle
        {
            get
            {
                return "Activity.PrevRejectedActivity.Title";
            }
        }
        public static string at_PrevRejectedActivityFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivityFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivity_ReceivedDate
        {
            get
            {
                return "Activity.PrevRejectedActivity.ReceivedDate";
            }
        }
        public static string at_PrevRejectedActivity_SendDate
        {
            get
            {
                return "Activity.PrevRejectedActivity.SendDate";
            }
        }
        public static string at_PrevRejectedActivity_ActivityDescription
        {
            get
            {
                return "Activity.PrevRejectedActivity.ActivityDescription";
            }
        }
        public static string at_PrevRejectedActivity_ActivityOrderDesc
        {
            get
            {
                return "Activity.PrevRejectedActivity.ActivityOrderDesc";
            }
        }
        public static string at_PrevRejectedActivity_ReminderDate
        {
            get
            {
                return "Activity.PrevRejectedActivity.ReminderDate";
            }
        }
        public static string at_PrevRejectedActivity_PercentOfDevelop
        {
            get
            {
                return "Activity.PrevRejectedActivity.PercentOfDevelop";
            }
        }
        public static string at_PrevRejectedActivity_CurrentWorkerFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivity.CurrentWorkerFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivity_PreviousActivityFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivity.PreviousActivityFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivity_PrevRejectedActivityFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivity.PrevRejectedActivityFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivity_CoWorkGroupFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivity.CoWorkGroupFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivity_CoFolderFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivity.CoFolderFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivity_CoDocumentFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivity.CoDocumentFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivity_ComplementInfoFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivity.ComplementInfoFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivity_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivity.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivity_CoTaskFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivity.CoTaskFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivity_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivity.AttachmentsFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivity_CoPlaceFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivity.CoPlaceFirstLevelAttributes";
            }
        }
        public static string at_PrevRejectedActivity_CoWCFirstLevelAttributes
        {
            get
            {
                return "Activity.PrevRejectedActivity.CoWCFirstLevelAttributes";
            }
        }
        public static string at_CoWorkGroupID
        {
            get
            {
                return "Activity.CoWorkGroupID";
            }
        }
        public static string at_CoWorkGroupTitle
        {
            get
            {
                return "Activity.CoWorkGroup.Title";
            }
        }
        public static string at_CoWorkGroupFirstLevelAttributes
        {
            get
            {
                return "Activity.CoWorkGroupFirstLevelAttributes";
            }
        }
        public static string at_CoWorkGroup_MembershipsFirstLevelAttributes
        {
            get
            {
                return "Activity.CoWorkGroup.MembershipsFirstLevelAttributes";
            }
        }
        public static string at_ActionType
        {
            get
            {
                return "Activity.ActionType";
            }
        }
        public static string at_IsViewed
        {
            get
            {
                return "Activity.IsViewed";
            }
        }
        public static string at_CoFolderID
        {
            get
            {
                return "Activity.CoFolderID";
            }
        }
        public static string at_CoFolderTitle
        {
            get
            {
                return "Activity.CoFolder.Title";
            }
        }
        public static string at_CoFolderFirstLevelAttributes
        {
            get
            {
                return "Activity.CoFolderFirstLevelAttributes";
            }
        }
        public static string at_CoFolder_ParentFirstLevelAttributes
        {
            get
            {
                return "Activity.CoFolder.ParentFirstLevelAttributes";
            }
        }
        public static string at_CoFolder_ChildsFirstLevelAttributes
        {
            get
            {
                return "Activity.CoFolder.ChildsFirstLevelAttributes";
            }
        }
        public static string at_CoFolder_ItemsFirstLevelAttributes
        {
            get
            {
                return "Activity.CoFolder.ItemsFirstLevelAttributes";
            }
        }
        public static string at_IsHidden
        {
            get
            {
                return "Activity.IsHidden";
            }
        }
        public static string at_CoDocumentID
        {
            get
            {
                return "Activity.CoDocumentID";
            }
        }
        public static string at_CoDocumentTitle
        {
            get
            {
                return "Activity.CoDocument.Title";
            }
        }
        public static string at_CoDocumentFirstLevelAttributes
        {
            get
            {
                return "Activity.CoDocumentFirstLevelAttributes";
            }
        }
        public static string at_CoDocument_BusinessDocumentCode
        {
            get
            {
                return "Activity.CoDocument.BusinessDocumentCode";
            }
        }
        public static string at_CoDocument_AttributeValuesFirstLevelAttributes
        {
            get
            {
                return "Activity.CoDocument.AttributeValuesFirstLevelAttributes";
            }
        }
        public static string at_CoDocument_DocumentTypeFirstLevelAttributes
        {
            get
            {
                return "Activity.CoDocument.DocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoDocument_ActivitiesFirstLevelAttributes
        {
            get
            {
                return "Activity.CoDocument.ActivitiesFirstLevelAttributes";
            }
        }
        public static string at_CoDocument_OwnerOrganFirstLevelAttributes
        {
            get
            {
                return "Activity.CoDocument.OwnerOrganFirstLevelAttributes";
            }
        }
        public static string at_CoDocument_CreatorPersonFirstLevelAttributes
        {
            get
            {
                return "Activity.CoDocument.CreatorPersonFirstLevelAttributes";
            }
        }
        public static string at_ComplementInfoID
        {
            get
            {
                return "Activity.ComplementInfoID";
            }
        }
        public static string at_ComplementInfoTitle
        {
            get
            {
                return "Activity.ComplementInfo.Title";
            }
        }
        public static string at_ComplementInfoFirstLevelAttributes
        {
            get
            {
                return "Activity.ComplementInfoFirstLevelAttributes";
            }
        }
        public static string at_ArchiveStatus
        {
            get
            {
                return "Activity.ArchiveStatus";
            }
        }
        public static string at_CoDocumentTypeID
        {
            get
            {
                return "Activity.CoDocumentTypeID";
            }
        }
        public static string at_CoDocumentTypeTitle
        {
            get
            {
                return "Activity.CoDocumentType.Title";
            }
        }
        public static string at_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "Activity.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_ObjectNameSpace
        {
            get
            {
                return "Activity.CoDocumentType.ObjectNameSpace";
            }
        }
        public static string at_CoDocumentType_IconStream
        {
            get
            {
                return "Activity.CoDocumentType.IconStream";
            }
        }
        public static string at_CoDocumentType_ObjectName
        {
            get
            {
                return "Activity.CoDocumentType.ObjectName";
            }
        }
        public static string at_CoDocumentType_PictureFirstLevelAttributes
        {
            get
            {
                return "Activity.CoDocumentType.PictureFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_PropertiesFirstLevelAttributes
        {
            get
            {
                return "Activity.CoDocumentType.PropertiesFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_SubSystemFirstLevelAttributes
        {
            get
            {
                return "Activity.CoDocumentType.SubSystemFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_CoDefaultUIFirstLevelAttributes
        {
            get
            {
                return "Activity.CoDocumentType.CoDefaultUIFirstLevelAttributes";
            }
        }
        public static string at_CoTaskID
        {
            get
            {
                return "Activity.CoTaskID";
            }
        }
        public static string at_CoTaskTitle
        {
            get
            {
                return "Activity.CoTask.Title";
            }
        }
        public static string at_CoTaskFirstLevelAttributes
        {
            get
            {
                return "Activity.CoTaskFirstLevelAttributes";
            }
        }
        public static string at_CoTask_OuterOrganTaskID
        {
            get
            {
                return "Activity.CoTask.OuterOrganTaskID";
            }
        }
        public static string at_CoTask_CoWorkflowFirstLevelAttributes
        {
            get
            {
                return "Activity.CoTask.CoWorkflowFirstLevelAttributes";
            }
        }
        public static string at_CoTask_OuterSenderOrganFirstLevelAttributes
        {
            get
            {
                return "Activity.CoTask.OuterSenderOrganFirstLevelAttributes";
            }
        }
        public static string at_CoTask_ActivitiesFirstLevelAttributes
        {
            get
            {
                return "Activity.CoTask.ActivitiesFirstLevelAttributes";
            }
        }
        public static string at_HasReminderFlag
        {
            get
            {
                return "Activity.HasReminderFlag";
            }
        }
        public static string at_AttachmentsID
        {
            get
            {
                return "Activity.AttachmentsID";
            }
        }
        public static string at_AttachmentsTitle
        {
            get
            {
                return "Activity.Attachments.Title";
            }
        }
        public static string at_AttachmentsFirstLevelAttributes
        {
            get
            {
                return "Activity.AttachmentsFirstLevelAttributes";
            }
        }
        public static string at_CoPlaceID
        {
            get
            {
                return "Activity.CoPlaceID";
            }
        }
        public static string at_CoPlaceTitle
        {
            get
            {
                return "Activity.CoPlace.Title";
            }
        }
        public static string at_CoPlaceFirstLevelAttributes
        {
            get
            {
                return "Activity.CoPlaceFirstLevelAttributes";
            }
        }
        public static string at_CoPlace_XposInDiagram
        {
            get
            {
                return "Activity.CoPlace.XposInDiagram";
            }
        }
        public static string at_CoPlace_YPosInDiagram
        {
            get
            {
                return "Activity.CoPlace.YPosInDiagram";
            }
        }
        public static string at_CoPlace_CoWCFirstLevelAttributes
        {
            get
            {
                return "Activity.CoPlace.CoWCFirstLevelAttributes";
            }
        }
        public static string at_CoPlace_CoWorkflowFirstLevelAttributes
        {
            get
            {
                return "Activity.CoPlace.CoWorkflowFirstLevelAttributes";
            }
        }
        public static string at_CoPlace_CoRoleResourcesFirstLevelAttributes
        {
            get
            {
                return "Activity.CoPlace.CoRoleResourcesFirstLevelAttributes";
            }
        }
        public static string at_CoWCID
        {
            get
            {
                return "Activity.CoWCID";
            }
        }
        public static string at_CoWCTitle
        {
            get
            {
                return "Activity.CoWC.Title";
            }
        }
        public static string at_CoWCFirstLevelAttributes
        {
            get
            {
                return "Activity.CoWCFirstLevelAttributes";
            }
        }
        public static string at_CoWC_CoUIFirstLevelAttributes
        {
            get
            {
                return "Activity.CoWC.CoUIFirstLevelAttributes";
            }
        }
        public static string at_CoWC_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "Activity.CoWC.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoWC_CoOrganFirstLevelAttributes
        {
            get
            {
                return "Activity.CoWC.CoOrganFirstLevelAttributes";
            }
        }
        public static string at_CoWC_PictureFirstLevelAttributes
        {
            get
            {
                return "Activity.CoWC.PictureFirstLevelAttributes";
            }
        }
    }
}
