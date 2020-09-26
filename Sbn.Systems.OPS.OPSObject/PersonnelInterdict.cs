using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Core;
using MSXML2;
using Sbn.Systems.WMC;
using Sbn.Systems.WMC.WMCObject;
namespace Sbn.Systems.OPS.OPSObject
{
    [Description("حكم سازماني كه معادل كارمند در سيستم گردش كار است و مركب از يك شخص و يك سمت مي باشد.")]
    [DisplayName("حكم سازماني كه معادل كارمند در سيستم گردش كار است و مركب از يك شخص و يك سمت مي باشد.")]
    [ObjectCode("21006")]
    [SystemName("OPS")]
    [ItemsType("Sbn.Systems.OPS.OPSObject.PersonnelInterdicts")]
    [Serializable]
    public class PersonnelInterdict : SbnObject
    {
        public PersonnelInterdict()
            : base()
        {
        }
        public PersonnelInterdict(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private string _StartDate;
        /// <summary>
        /// تاریخ شروع حکم
        /// </summary>
        [Description("تاریخ شروع حکم")]
        [DisplayName("تاریخ شروع حکم")]
        [Category("")]
        [DocumentAttributeID("21002")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        private string _EndDate;
        /// <summary>
        /// تاریخ پایان حکم
        /// </summary>
        [Description("تاریخ پایان حکم")]
        [DisplayName("تاریخ پایان حکم")]
        [Category("")]
        [DocumentAttributeID("21003")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        private string _StartFormalTime;
        /// <summary>
        /// شروع ساعت کاری
        /// </summary>
        [Description("شروع ساعت کاری")]
        [DisplayName("زمان شروع شیفت")]
        [Category("")]
        [DocumentAttributeID("21004")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string StartFormalTime
        {
            get { return _StartFormalTime; }
            set { _StartFormalTime = value; }
        }
        private string _EndFormalTime;
        /// <summary>
        /// پایان شیفت کاری
        /// </summary>
        [Description("پایان شیفت کاری")]
        [DisplayName("زمان پایان شیفت")]
        [Category("")]
        [DocumentAttributeID("21005")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string EndFormalTime
        {
            get { return _EndFormalTime; }
            set { _EndFormalTime = value; }
        }
        private long _PersonnelCode;
        /// <summary>
        /// کد پرسنلی
        /// </summary>
        [Description("کد پرسنلی")]
        [DisplayName("کد پرسنلی")]
        [Category("")]
        [DocumentAttributeID("27239")]
        [IsRelationalAttribute("false")]
        [AttributeType("Long")]
        [Browsable(true)]
        public long PersonnelCode
        {
            get { return _PersonnelCode; }
            set { _PersonnelCode = value; }
        }
        private BasicInfoDetail _Job;
        /// <summary>
        /// شغل یا رده سازمانی
        /// </summary>
        [Description("شغل یا رده سازمانی")]
        [DisplayName("شغل / رده سازمانی")]
        [Category("")]
        [DocumentAttributeID("21000")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail Job
        {
            get { return _Job; }
            set { _Job = value; }
        }
        private BasicInfoDetail _PersonnelType;
        /// <summary>
        /// نوع پرسنل حقیقی یا حقوقی
        /// </summary>
        [Description("نوع پرسنل حقیقی یا حقوقی")]
        [DisplayName("")]
        [Category("")]
        [DocumentAttributeID("21007")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail PersonnelType
        {
            get { return _PersonnelType; }
            set { _PersonnelType = value; }
        }
        private OrgUnit _OrgUnit;
        /// <summary>
        /// واحد سازمانی
        /// </summary>
        [Description("واحد سازمانی")]
        [DisplayName("واحد سازمانی")]
        [Category("")]
        [DocumentAttributeID("21009")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("OrgUnit")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public OrgUnit OrgUnit
        {
            get { return _OrgUnit; }
            set { _OrgUnit = value; }
        }
        private MFOrgPosition _OrgPosition;
        /// <summary>
        /// سمت
        /// </summary>
        [Description("سمت")]
        [DisplayName("پست سازمانی")]
        [Category("")]
        [DocumentAttributeID("21010")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("MFOrgPosition")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public MFOrgPosition OrgPosition
        {
            get { return _OrgPosition; }
            set { _OrgPosition = value; }
        }
        private Personnel _Personnel;
        /// <summary>
        /// پرسنل مرتبط
        /// </summary>
        [Description("پرسنل مرتبط")]
        [DisplayName("پرسنل مرتبط")]
        [Category("")]
        [DocumentAttributeID("21011")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Personnel")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Personnel Personnel
        {
            get { return _Personnel; }
            set { _Personnel = value; }
        }
        private MFPerson _Person;
        /// <summary>
        /// شخص مرتبط
        /// </summary>
        [Description("شخص مرتبط")]
        [DisplayName("شخص مرتبط")]
        [Category("")]
        [DocumentAttributeID("21012")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("MFPerson")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public MFPerson Person
        {
            get { return _Person; }
            set { _Person = value; }
        }
        private Worker _Worker;
        /// <summary>
        /// کارمند مرتبط
        /// </summary>
        [Description("کارمند مرتبط")]
        [DisplayName("کارمند مرتبط")]
        [Category("")]
        [DocumentAttributeID("21013")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("Worker")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public Worker Worker
        {
            get { return _Worker; }
            set { _Worker = value; }
        }
        private MFOrgUnit _CoOrgUnit;
        /// <summary>
        /// واحد سازمانی مرتبط
        /// </summary>
        [Description("واحد سازمانی مرتبط")]
        [DisplayName("واحد سازمانی")]
        [Category("")]
        [DocumentAttributeID("27416")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("MFOrgUnit")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public MFOrgUnit CoOrgUnit
        {
            get { return _CoOrgUnit; }
            set { _CoOrgUnit = value; }
        }
        private BasicInfoDetail _OrganizationRanking;
        /// <summary>
        /// رتبه سازمانی
        /// </summary>
        [Description("رتبه سازمانی")]
        [DisplayName("رتبه سازمانی")]
        [Category("")]
        [DocumentAttributeID("27432")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("BasicInfoDetail")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public BasicInfoDetail OrganizationRanking
        {
            get { return _OrganizationRanking; }
            set { _OrganizationRanking = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._StartDate = "";
            this._EndDate = "";
            this._StartFormalTime = "";
            this._EndFormalTime = "";
            this._PersonnelCode = 0;
            this._Job = new BasicInfoDetail();
            this._PersonnelType = new BasicInfoDetail();
            this._OrgUnit = new OrgUnit();
            this._OrgPosition = new MFOrgPosition();
            this._Personnel = new Personnel();
            this._Person = new MFPerson();
            this._Worker = new Worker();
            this._CoOrgUnit = new MFOrgUnit();
            this._OrganizationRanking = new BasicInfoDetail();
        }
        public override SbnObject Clone(string sNodeName)
        {
            PersonnelInterdict retObject = new PersonnelInterdict(this);
            if (this._StartDate != null) retObject.StartDate = (string)this._StartDate.Clone();
            if (this._EndDate != null) retObject.EndDate = (string)this._EndDate.Clone();
            retObject.StartFormalTime = this._StartFormalTime;
            retObject.EndFormalTime = this._EndFormalTime;
            retObject.PersonnelCode = this._PersonnelCode;
            if (!object.ReferenceEquals(this.Job, null))
                retObject.Job = (BasicInfoDetail)this.Job.Clone(sNodeName);
            if (!object.ReferenceEquals(this.PersonnelType, null))
                retObject.PersonnelType = (BasicInfoDetail)this.PersonnelType.Clone(sNodeName);
            if (!object.ReferenceEquals(this.OrgUnit, null))
                retObject.OrgUnit = (OrgUnit)this.OrgUnit.Clone(sNodeName);
            if (!object.ReferenceEquals(this.OrgPosition, null))
                retObject.OrgPosition = (MFOrgPosition)this.OrgPosition.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Personnel, null))
                retObject.Personnel = (Personnel)this.Personnel.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Person, null))
                retObject.Person = (MFPerson)this.Person.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Worker, null))
                retObject.Worker = (Worker)this.Worker.Clone(sNodeName);
            if (!object.ReferenceEquals(this.CoOrgUnit, null))
                retObject.CoOrgUnit = (MFOrgUnit)this.CoOrgUnit.Clone(sNodeName);
            if (!object.ReferenceEquals(this.OrganizationRanking, null))
                retObject.OrganizationRanking = (BasicInfoDetail)this.OrganizationRanking.Clone(sNodeName);
            return retObject;
        }
        public static string at_StartDate
        {
            get
            {
                return "PersonnelInterdict.StartDate";
            }
        }
        public static string at_EndDate
        {
            get
            {
                return "PersonnelInterdict.EndDate";
            }
        }
        public static string at_StartFormalTime
        {
            get
            {
                return "PersonnelInterdict.StartFormalTime";
            }
        }
        public static string at_EndFormalTime
        {
            get
            {
                return "PersonnelInterdict.EndFormalTime";
            }
        }
        public static string at_PersonnelCode
        {
            get
            {
                return "PersonnelInterdict.PersonnelCode";
            }
        }
        public static string at_JobID
        {
            get
            {
                return "PersonnelInterdict.JobID";
            }
        }
        public static string at_JobFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.JobFirstLevelAttributes";
            }
        }
        public static string at_Job_OrderInList
        {
            get
            {
                return "PersonnelInterdict.Job.OrderInList";
            }
        }
        public static string at_Job_ParentFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.Job.ParentFirstLevelAttributes";
            }
        }
        public static string at_PersonnelTypeID
        {
            get
            {
                return "PersonnelInterdict.PersonnelTypeID";
            }
        }
        public static string at_PersonnelTypeFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.PersonnelTypeFirstLevelAttributes";
            }
        }
        public static string at_PersonnelType_OrderInList
        {
            get
            {
                return "PersonnelInterdict.PersonnelType.OrderInList";
            }
        }
        public static string at_PersonnelType_ParentFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.PersonnelType.ParentFirstLevelAttributes";
            }
        }
        public static string at_OrgUnitID
        {
            get
            {
                return "PersonnelInterdict.OrgUnitID";
            }
        }
        public static string at_OrgUnitFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrgUnitFirstLevelAttributes";
            }
        }
        public static string at_OrgUnit_UnitPath
        {
            get
            {
                return "PersonnelInterdict.OrgUnit.UnitPath";
            }
        }
        public static string at_OrgUnit_ExpireDate
        {
            get
            {
                return "PersonnelInterdict.OrgUnit.ExpireDate";
            }
        }
        public static string at_OrgUnit_BuildingLocationFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrgUnit.BuildingLocationFirstLevelAttributes";
            }
        }
        public static string at_OrgUnit_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrgUnit.ChildUnitsFirstLevelAttributes";
            }
        }
        public static string at_OrgUnit_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrgUnit.ParentUnitFirstLevelAttributes";
            }
        }
        public static string at_OrgUnit_PositionsFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrgUnit.PositionsFirstLevelAttributes";
            }
        }
        public static string at_OrgUnit_MergedUnitFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrgUnit.MergedUnitFirstLevelAttributes";
            }
        }
        public static string at_OrgPositionID
        {
            get
            {
                return "PersonnelInterdict.OrgPositionID";
            }
        }
        public static string at_OrgPositionFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrgPositionFirstLevelAttributes";
            }
        }
        public static string at_OrgPosition_OrgUnitFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrgPosition.OrgUnitFirstLevelAttributes";
            }
        }
        public static string at_OrgPosition_InterdictsFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrgPosition.InterdictsFirstLevelAttributes";
            }
        }
        public static string at_OrgPosition_CoOrgUnitFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrgPosition.CoOrgUnitFirstLevelAttributes";
            }
        }
        public static string at_OrgPosition_PositionTypeFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrgPosition.PositionTypeFirstLevelAttributes";
            }
        }
        public static string at_PersonnelID
        {
            get
            {
                return "PersonnelInterdict.PersonnelID";
            }
        }
        public static string at_PersonnelFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.PersonnelFirstLevelAttributes";
            }
        }
        public static string at_Personnel_PersonnelCode
        {
            get
            {
                return "PersonnelInterdict.Personnel.PersonnelCode";
            }
        }
        public static string at_Personnel_PersonFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.Personnel.PersonFirstLevelAttributes";
            }
        }
        public static string at_Personnel_PersonnelInterdictsFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.Personnel.PersonnelInterdictsFirstLevelAttributes";
            }
        }
        public static string at_PersonID
        {
            get
            {
                return "PersonnelInterdict.PersonID";
            }
        }
        public static string at_PersonFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.PersonFirstLevelAttributes";
            }
        }
        public static string at_Person_BirthDate
        {
            get
            {
                return "PersonnelInterdict.Person.BirthDate";
            }
        }
        public static string at_Person_EMail
        {
            get
            {
                return "PersonnelInterdict.Person.EMail";
            }
        }
        public static string at_Person_Fathername
        {
            get
            {
                return "PersonnelInterdict.Person.Fathername";
            }
        }
        public static string at_Person_FirstName
        {
            get
            {
                return "PersonnelInterdict.Person.FirstName";
            }
        }
        public static string at_Person_LastName
        {
            get
            {
                return "PersonnelInterdict.Person.LastName";
            }
        }
        public static string at_Person_NationalCode
        {
            get
            {
                return "PersonnelInterdict.Person.NationalCode";
            }
        }
        public static string at_Person_PersonalId
        {
            get
            {
                return "PersonnelInterdict.Person.PersonalId";
            }
        }
        public static string at_Person_SerialNumber
        {
            get
            {
                return "PersonnelInterdict.Person.SerialNumber";
            }
        }
        public static string at_Person_SeriesNumber
        {
            get
            {
                return "PersonnelInterdict.Person.SeriesNumber";
            }
        }
        public static string at_Person_InterdictsFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.Person.InterdictsFirstLevelAttributes";
            }
        }
        public static string at_Person_PicrtureFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.Person.PicrtureFirstLevelAttributes";
            }
        }
        public static string at_Person_SexFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.Person.SexFirstLevelAttributes";
            }
        }
        public static string at_WorkerID
        {
            get
            {
                return "PersonnelInterdict.WorkerID";
            }
        }
        public static string at_WorkerFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.WorkerFirstLevelAttributes";
            }
        }
        public static string at_Worker_StartWorkDate
        {
            get
            {
                return "PersonnelInterdict.Worker.StartWorkDate";
            }
        }
        public static string at_Worker_EndWorkDate
        {
            get
            {
                return "PersonnelInterdict.Worker.EndWorkDate";
            }
        }
        public static string at_Worker_IconStream
        {
            get
            {
                return "PersonnelInterdict.Worker.IconStream";
            }
        }
        public static string at_Worker_CoPositionFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.Worker.CoPositionFirstLevelAttributes";
            }
        }
        public static string at_Worker_RestrictionsFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.Worker.RestrictionsFirstLevelAttributes";
            }
        }
        public static string at_Worker_CoPersonFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.Worker.CoPersonFirstLevelAttributes";
            }
        }
        public static string at_Worker_AccessrightsFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.Worker.AccessrightsFirstLevelAttributes";
            }
        }
        public static string at_Worker_WorkerJobFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.Worker.WorkerJobFirstLevelAttributes";
            }
        }
        public static string at_Worker_CoRolesFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.Worker.CoRolesFirstLevelAttributes";
            }
        }
        public static string at_CoOrgUnitID
        {
            get
            {
                return "PersonnelInterdict.CoOrgUnitID";
            }
        }
        public static string at_CoOrgUnitFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.CoOrgUnitFirstLevelAttributes";
            }
        }
        public static string at_CoOrgUnit_ExpireDate
        {
            get
            {
                return "PersonnelInterdict.CoOrgUnit.ExpireDate";
            }
        }
        public static string at_CoOrgUnit_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.CoOrgUnit.ChildUnitsFirstLevelAttributes";
            }
        }
        public static string at_CoOrgUnit_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.CoOrgUnit.ParentUnitFirstLevelAttributes";
            }
        }
        public static string at_CoOrgUnit_PositionsFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.CoOrgUnit.PositionsFirstLevelAttributes";
            }
        }
        public static string at_CoOrgUnit_AddressInfosFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.CoOrgUnit.AddressInfosFirstLevelAttributes";
            }
        }
        public static string at_CoOrgUnit_InterdictsFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.CoOrgUnit.InterdictsFirstLevelAttributes";
            }
        }
        public static string at_OrganizationRankingID
        {
            get
            {
                return "PersonnelInterdict.OrganizationRankingID";
            }
        }
        public static string at_OrganizationRankingFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrganizationRankingFirstLevelAttributes";
            }
        }
        public static string at_OrganizationRanking_OrderInList
        {
            get
            {
                return "PersonnelInterdict.OrganizationRanking.OrderInList";
            }
        }
        public static string at_OrganizationRanking_ParentFirstLevelAttributes
        {
            get
            {
                return "PersonnelInterdict.OrganizationRanking.ParentFirstLevelAttributes";
            }
        }
    }
}
