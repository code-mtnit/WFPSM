using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Core;
namespace Sbn.Systems.WMC.WMCObject
{
    [Description("عضويت در گروه كاري")]
    [DisplayName("عضويت در گروه كاري")]
    [ObjectCode("2017")]
    [SystemName("WMC")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.WorkGroupMemberships")]
    [Serializable]
    public class WorkGroupMembership : SbnObject
    {
        public WorkGroupMembership()
            : base()
        {
        }
        public WorkGroupMembership(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private Worker _CoWorker;
        /// <summary>
        /// کارمند مرتبط
        /// </summary>
        [Description("کارمند مرتبط")]
        [DisplayName("کارمند مرتبط")]
        [Category("")]
        [DocumentAttributeID("2056")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Worker")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Worker CoWorker
        {
            get { return _CoWorker; }
            set { _CoWorker = value; }
        }
        private WorkContext _CoWC;
        /// <summary>
        /// در تعریف فرایند با یک مرحله مرتبط است
        /// </summary>
        [Description("در تعریف فرایند با یک مرحله مرتبط است")]
        [DisplayName("زمینه کاری مرتبط")]
        [Category("")]
        [DocumentAttributeID("2057")]
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
        private DocumentType _CoDocumentType;
        /// <summary>
        /// سند مرتبط در عضویت این کارمند در گروه کاری که می تواند به منظور ارجاعات روی موجودیت نامعلوم تعیین نشود
        /// </summary>
        [Description("سند مرتبط در عضویت این کارمند در گروه کاری که می تواند به منظور ارجاعات روی موجودیت نامعلوم تعیین نشود")]
        [DisplayName("سند مرتبط")]
        [Category("")]
        [DocumentAttributeID("27040")]
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
        private WorkGroup _CoWorkGroup;
        /// <summary>
        /// گروه کاری مرتبط
        /// </summary>
        [Description("گروه کاری مرتبط")]
        [DisplayName("گروه کاری مرتبط")]
        [Category("")]
        [DocumentAttributeID("27023")]
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
        private SbnBoolean _IsSender = SbnBoolean.OutOfValue;
        /// <summary>
        /// آیا کارمند در این گروه کاری حق ارسال دارد؟
        /// </summary>
        [Description("آیا کارمند در این گروه کاری حق ارسال دارد؟")]
        [DisplayName("ارسال کننده")]
        [Category("")]
        [DocumentAttributeID("27284")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsSender
        {
            get { return _IsSender; }
            set { _IsSender = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._CoWorker = new Worker();
            this._CoWC = new WorkContext();
            this._CoDocumentType = new DocumentType();
            this._CoWorkGroup = new WorkGroup();
            this._IsSender = SbnBoolean.OutOfValue;
        }
        public override SbnObject Clone(string sNodeName)
        {
            WorkGroupMembership retObject = new WorkGroupMembership(this);
            if (!object.ReferenceEquals(this.CoWorker, null))
                retObject.CoWorker = (Worker)this.CoWorker.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoWC, null))
                retObject.CoWC = (WorkContext)this.CoWC.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoDocumentType, null))
                retObject.CoDocumentType = (DocumentType)this.CoDocumentType.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoWorkGroup, null))
                retObject.CoWorkGroup = (WorkGroup)this.CoWorkGroup.Clone(sNodeName);
            retObject.IsSender = this.IsSender;
            return retObject;
        }
        public static string at_CoWorkerID
        {
            get
            {
                return "WorkGroupMembership.CoWorkerID";
            }
        }
        public static string at_CoWorkerTitle
        {
            get
            {
                return "WorkGroupMembership.CoWorker.Title";
            }
        }
        public static string at_CoWorkerFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWorkerFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_StartWorkDate
        {
            get
            {
                return "WorkGroupMembership.CoWorker.StartWorkDate";
            }
        }
        public static string at_CoWorker_EndWorkDate
        {
            get
            {
                return "WorkGroupMembership.CoWorker.EndWorkDate";
            }
        }
        public static string at_CoWorker_IconStream
        {
            get
            {
                return "WorkGroupMembership.CoWorker.IconStream";
            }
        }
        public static string at_CoWorker_CoPositionFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWorker.CoPositionFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_RestrictionsFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWorker.RestrictionsFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_CoPersonFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWorker.CoPersonFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_AccessrightsFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWorker.AccessrightsFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_WorkerJobFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWorker.WorkerJobFirstLevelAttributes";
            }
        }
        public static string at_CoWorker_CoRolesFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWorker.CoRolesFirstLevelAttributes";
            }
        }
        public static string at_CoWCID
        {
            get
            {
                return "WorkGroupMembership.CoWCID";
            }
        }
        public static string at_CoWCTitle
        {
            get
            {
                return "WorkGroupMembership.CoWC.Title";
            }
        }
        public static string at_CoWCFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWCFirstLevelAttributes";
            }
        }
        public static string at_CoWC_CoUIFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWC.CoUIFirstLevelAttributes";
            }
        }
        public static string at_CoWC_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWC.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoWC_CoOrganFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWC.CoOrganFirstLevelAttributes";
            }
        }
        public static string at_CoWC_PictureFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWC.PictureFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentTypeID
        {
            get
            {
                return "WorkGroupMembership.CoDocumentTypeID";
            }
        }
        public static string at_CoDocumentTypeTitle
        {
            get
            {
                return "WorkGroupMembership.CoDocumentType.Title";
            }
        }
        public static string at_CoDocumentTypeFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoDocumentTypeFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_ObjectNameSpace
        {
            get
            {
                return "WorkGroupMembership.CoDocumentType.ObjectNameSpace";
            }
        }
        public static string at_CoDocumentType_IconStream
        {
            get
            {
                return "WorkGroupMembership.CoDocumentType.IconStream";
            }
        }
        public static string at_CoDocumentType_ObjectName
        {
            get
            {
                return "WorkGroupMembership.CoDocumentType.ObjectName";
            }
        }
        public static string at_CoDocumentType_PictureFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoDocumentType.PictureFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_PropertiesFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoDocumentType.PropertiesFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_SubSystemFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoDocumentType.SubSystemFirstLevelAttributes";
            }
        }
        public static string at_CoDocumentType_CoDefaultUIFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoDocumentType.CoDefaultUIFirstLevelAttributes";
            }
        }
        public static string at_CoWorkGroupID
        {
            get
            {
                return "WorkGroupMembership.CoWorkGroupID";
            }
        }
        public static string at_CoWorkGroupTitle
        {
            get
            {
                return "WorkGroupMembership.CoWorkGroup.Title";
            }
        }
        public static string at_CoWorkGroupFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWorkGroupFirstLevelAttributes";
            }
        }
        public static string at_CoWorkGroup_MembershipsFirstLevelAttributes
        {
            get
            {
                return "WorkGroupMembership.CoWorkGroup.MembershipsFirstLevelAttributes";
            }
        }
        public static string at_IsSender
        {
            get
            {
                return "WorkGroupMembership.IsSender";
            }
        }
    }
}
