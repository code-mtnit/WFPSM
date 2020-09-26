using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
namespace Sbn.Systems.WMC.WMCObject
{
    [Description("كارمند")]
    [DisplayName("كارمند")]
    [ObjectCode("2000")]
    [SystemName("WMC")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.Workers")]
    [Serializable]
    public class Worker : SbnObject
    {
        public Worker()
            : base()
        {
        }
        public Worker(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private string _StartWorkDate;
        /// <summary>
        /// زمان شروع بکار
        /// </summary>
        [Description("زمان شروع بکار")]
        [DisplayName("شروع بکار")]
        [Category("")]
        [DocumentAttributeID("2049")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string StartWorkDate
        {
            get { return _StartWorkDate; }
            set { _StartWorkDate = value; }
        }
        private string _EndWorkDate;
        /// <summary>
        /// زمان اتمام کار
        /// </summary>
        [Description("زمان اتمام کار")]
        [DisplayName("اتمام کار")]
        [Category("")]
        [DocumentAttributeID("2050")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string EndWorkDate
        {
            get { return _EndWorkDate; }
            set { _EndWorkDate = value; }
        }
        private byte[] _IconStream;
        /// <summary>
        /// ایکون
        /// </summary>
        [Description("ایکون")]
        [DisplayName("آیکون")]
        [Category("تصویر آیکون")]
        [DocumentAttributeID("27122")]
        [IsRelationalAttribute("false")]
        [AttributeType("Binary")]
        [Browsable(true)]
        public byte[] IconStream
        {
            get { return _IconStream; }
            set { _IconStream = value; }
        }
        private OrgPosition _CoPosition;
        /// <summary>
        /// سمت مرتبط
        /// </summary>
        [Description("سمت مرتبط")]
        [DisplayName("سمت")]
        [Category("")]
        [DocumentAttributeID("2029")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("OrgPosition")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public OrgPosition CoPosition
        {
            get { return _CoPosition; }
            set { _CoPosition = value; }
        }
        private WorkerRestrictions _Restrictions;
        /// <summary>
        /// محدودیتها
        /// </summary>
        [Description("محدودیتها")]
        [DisplayName("محدودیت ها")]
        [Category("")]
        [DocumentAttributeID("2037")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("WorkerRestrictions")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public WorkerRestrictions Restrictions
        {
            get { return _Restrictions; }
            set { _Restrictions = value; }
        }
        private WFPerson _CoPerson;
        /// <summary>
        /// شخص
        /// </summary>
        [Description("شخص")]
        [DisplayName("شخص")]
        [Category("")]
        [DocumentAttributeID("2038")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("WFPerson")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public WFPerson CoPerson
        {
            get { return _CoPerson; }
            set { _CoPerson = value; }
        }
        private WorkerAccessrights _Accessrights;
        /// <summary>
        /// دسترسیها
        /// </summary>
        [Description("دسترسیها")]
        [DisplayName("دسترسیها")]
        [Category("")]
        [DocumentAttributeID("2063")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("WorkerAccessrights")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public WorkerAccessrights Accessrights
        {
            get { return _Accessrights; }
            set { _Accessrights = value; }
        }
        private SbnBoolean _IsActive = SbnBoolean.OutOfValue;
        /// <summary>
        /// وضعیت فعالیت
        /// </summary>
        [Description("وضعیت فعالیت")]
        [DisplayName("وضعیت فعالیت")]
        [Category("")]
        [DocumentAttributeID("2073")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        private BasicInfoDetail _WorkerJob;
        /// <summary>
        /// عنوان رده یا شغل سازمانی
        /// </summary>
        [Description("عنوان رده یا شغل سازمانی")]
        [DisplayName("شغل")]
        [Category("")]
        [DocumentAttributeID("2077")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail WorkerJob
        {
            get { return _WorkerJob; }
            set { _WorkerJob = value; }
        }
        private WFRoles _CoRoles;
        /// <summary>
        /// نقشهای مرتبط
        /// </summary>
        [Description("نقشهای مرتبط")]
        [DisplayName("نقشهای مرتبط")]
        [Category("")]
        [DocumentAttributeID("27286")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("WFRoles")]
        [IsMiddleTableExist("False")]
        [RelationTable("Role_Worker_M")]
        public WFRoles CoRoles
        {
            get { return _CoRoles; }
            set { _CoRoles = value; }
        }
        public override string ToString()
        {
            try { if (this.CoPerson != null) { string sRet = this.CoPerson.ToString(); if (sRet != " ، ")                return sRet; else                return base.ToString(); } }
            catch { } return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._StartWorkDate = "";
            this._EndWorkDate = "";
            this._IconStream = new byte[1];
            this._CoPosition = new OrgPosition();
            this._Restrictions = new WorkerRestrictions();
            this._CoPerson = new WFPerson();
            this._Accessrights = new WorkerAccessrights();
            this._IsActive = SbnBoolean.OutOfValue;
            this._WorkerJob = new BasicInfoDetail();
            this._CoRoles = new WFRoles();
        }
        public override SbnObject Clone(string sNodeName)
        {
            Worker retObject = new Worker(this);
            if (this._StartWorkDate != null) retObject.StartWorkDate = (string)this._StartWorkDate.Clone();
            if (this._EndWorkDate != null) retObject.EndWorkDate = (string)this._EndWorkDate.Clone();
            if (this._IconStream != null) retObject.IconStream = (byte[])this._IconStream.Clone();
            if (!object.ReferenceEquals(this.CoPosition, null))
                retObject.CoPosition = (OrgPosition)this.CoPosition.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Restrictions, null))
                retObject.Restrictions = (WorkerRestrictions)this.Restrictions.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoPerson, null))
                retObject.CoPerson = (WFPerson)this.CoPerson.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Accessrights, null))
                retObject.Accessrights = (WorkerAccessrights)this.Accessrights.Clone(sNodeName);
            retObject.IsActive = this.IsActive;
            if (!object.ReferenceEquals(this.WorkerJob, null))
                retObject.WorkerJob = (BasicInfoDetail)this.WorkerJob.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoRoles, null))
                retObject.CoRoles = (WFRoles)this.CoRoles.Clone(sNodeName);
            return retObject;
        }
        public static string at_StartWorkDate
        {
            get
            {
                return "Worker.StartWorkDate";
            }
        }
        public static string at_EndWorkDate
        {
            get
            {
                return "Worker.EndWorkDate";
            }
        }
        public static string at_IconStream
        {
            get
            {
                return "Worker.IconStream";
            }
        }
        public static string at_CoPositionID
        {
            get
            {
                return "Worker.CoPositionID";
            }
        }
        public static string at_CoPositionTitle
        {
            get
            {
                return "Worker.CoPosition.Title";
            }
        }
        public static string at_CoPositionFirstLevelAttributes
        {
            get
            {
                return "Worker.CoPositionFirstLevelAttributes";
            }
        }
        public static string at_CoPosition_DefinitionDate
        {
            get
            {
                return "Worker.CoPosition.DefinitionDate";
            }
        }
        public static string at_CoPosition_ExpireDate
        {
            get
            {
                return "Worker.CoPosition.ExpireDate";
            }
        }
        public static string at_CoPosition_CoOrgUnitFirstLevelAttributes
        {
            get
            {
                return "Worker.CoPosition.CoOrgUnitFirstLevelAttributes";
            }
        }
        public static string at_CoPosition_WorkersFirstLevelAttributes
        {
            get
            {
                return "Worker.CoPosition.WorkersFirstLevelAttributes";
            }
        }
        public static string at_RestrictionsID
        {
            get
            {
                return "Worker.RestrictionsID";
            }
        }
        public static string at_RestrictionsTitle
        {
            get
            {
                return "Worker.Restrictions.Title";
            }
        }
        public static string at_RestrictionsFirstLevelAttributes
        {
            get
            {
                return "Worker.RestrictionsFirstLevelAttributes";
            }
        }
        public static string at_CoPersonID
        {
            get
            {
                return "Worker.CoPersonID";
            }
        }
        public static string at_CoPersonTitle
        {
            get
            {
                return "Worker.CoPerson.Title";
            }
        }
        public static string at_CoPersonFirstLevelAttributes
        {
            get
            {
                return "Worker.CoPersonFirstLevelAttributes";
            }
        }
        public static string at_CoPerson_FirstName
        {
            get
            {
                return "Worker.CoPerson.FirstName";
            }
        }
        public static string at_CoPerson_SurName
        {
            get
            {
                return "Worker.CoPerson.SurName";
            }
        }
        public static string at_CoPerson_Picture
        {
            get
            {
                return "Worker.CoPerson.Picture";
            }
        }
        public static string at_CoPerson_Signature
        {
            get
            {
                return "Worker.CoPerson.Signature";
            }
        }
        public static string at_CoPerson_WorkersFirstLevelAttributes
        {
            get
            {
                return "Worker.CoPerson.WorkersFirstLevelAttributes";
            }
        }
        public static string at_CoPerson_SexFirstLevelAttributes
        {
            get
            {
                return "Worker.CoPerson.SexFirstLevelAttributes";
            }
        }
        public static string at_AccessrightsID
        {
            get
            {
                return "Worker.AccessrightsID";
            }
        }
        public static string at_AccessrightsTitle
        {
            get
            {
                return "Worker.Accessrights.Title";
            }
        }
        public static string at_AccessrightsFirstLevelAttributes
        {
            get
            {
                return "Worker.AccessrightsFirstLevelAttributes";
            }
        }
        public static string at_IsActive
        {
            get
            {
                return "Worker.IsActive";
            }
        }
        public static string at_WorkerJobID
        {
            get
            {
                return "Worker.WorkerJobID";
            }
        }
        public static string at_WorkerJobTitle
        {
            get
            {
                return "Worker.WorkerJob.Title";
            }
        }
        public static string at_WorkerJobFirstLevelAttributes
        {
            get
            {
                return "Worker.WorkerJobFirstLevelAttributes";
            }
        }
        public static string at_WorkerJob_OrderInList
        {
            get
            {
                return "Worker.WorkerJob.OrderInList";
            }
        }
        public static string at_WorkerJob_ParentFirstLevelAttributes
        {
            get
            {
                return "Worker.WorkerJob.ParentFirstLevelAttributes";
            }
        }
        public static string at_CoRolesID
        {
            get
            {
                return "Worker.CoRolesID";
            }
        }
        public static string at_CoRolesTitle
        {
            get
            {
                return "Worker.CoRoles.Title";
            }
        }
        public static string at_CoRolesFirstLevelAttributes
        {
            get
            {
                return "Worker.CoRolesFirstLevelAttributes";
            }
        }
    }
}
