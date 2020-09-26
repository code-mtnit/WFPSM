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
    [Description("واحد سازماني")]
    [DisplayName("واحد سازماني")]
    [ObjectCode("2002")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.OrgUnits")]
    [SystemName("WMC")]
    [Serializable]
    public class OrgUnit : SbnObject
    {
        public OrgUnit()
            : base()
        {
        }
        public OrgUnit(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private string _UnitPath;
        /// <summary>
        /// مسیر رشته ای واحد سازمانی که جهت تسریع در جستجوها استفاده می شود
        /// </summary>
        [Description("مسیر رشته ای واحد سازمانی که جهت تسریع در جستجوها استفاده می شود")]
        [DisplayName("مسیر رشته ای")]
        [Category("")]
        [DocumentAttributeID("2015")]
        [IsRelationalAttribute("false")]
        [AttributeType("String")]
        [Browsable(true)]
        public string UnitPath
        {
            get { return _UnitPath; }
            set { _UnitPath = value; }
        }
        private string _ExpireDate;
        /// <summary>
        /// تاریخ اعتبار
        /// </summary>
        [Description("تاریخ اعتبار")]
        [DisplayName("تاریخ اعتبار")]
        [Category("")]
        [DocumentAttributeID("27013")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string ExpireDate
        {
            get { return _ExpireDate; }
            set { _ExpireDate = value; }
        }
        private OrgUnitBuildingLocation _BuildingLocation;
        /// <summary>
        /// ساختار فیزیکی مرتبط
        /// </summary>
        [Description("ساختار فیزیکی مرتبط")]
        [DisplayName("ساختار فیزیکی مرتبط")]
        [Category("")]
        [DocumentAttributeID("2001")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("OrgUnitBuildingLocation")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public OrgUnitBuildingLocation BuildingLocation
        {
            get { return _BuildingLocation; }
            set { _BuildingLocation = value; }
        }
        private OrgUnits _ChildUnits;
        /// <summary>
        /// ساختار زیرمجموعه
        /// </summary>
        [Description("ساختار زیرمجموعه")]
        [DisplayName("ساختار زیرمجموعه")]
        [Category("")]
        [DocumentAttributeID("2030")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("OrgUnits")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public OrgUnits ChildUnits
        {
            get { return _ChildUnits; }
            set { _ChildUnits = value; }
        }
        private OrgUnit _ParentUnit;
        /// <summary>
        /// واحد سازمانی بالاتر
        /// </summary>
        [Description("واحد سازمانی بالاتر")]
        [DisplayName("واحد سازمانی بالاتر")]
        [Category("")]
        [DocumentAttributeID("2031")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("OrgUnit")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public OrgUnit ParentUnit
        {
            get { return _ParentUnit; }
            set { _ParentUnit = value; }
        }
        private OrgPositions _Positions;
        /// <summary>
        /// پستهای سازمانی
        /// </summary>
        [Description("پستهای سازمانی")]
        [DisplayName("پستهای سازمانی")]
        [Category("")]
        [DocumentAttributeID("27055")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("OrgPositions")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public OrgPositions Positions
        {
            get { return _Positions; }
            set { _Positions = value; }
        }
        private SbnBoolean _IsExpire = SbnBoolean.OutOfValue;
        /// <summary>
        /// منقضی شده
        /// </summary>
        [Description("منقضی شده")]
        [DisplayName("منقضی شده")]
        [Category("")]
        [DocumentAttributeID("27071")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsExpire
        {
            get { return _IsExpire; }
            set { _IsExpire = value; }
        }
        private SbnBoolean _IsDargah = SbnBoolean.OutOfValue;
        /// <summary>
        /// واحد سازمانی عضو درگاه
        /// </summary>
        [Description("واحد سازمانی عضو درگاه")]
        [DisplayName("واحد سازمانی")]
        [Category("")]
        [DocumentAttributeID("")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsDargah
        {
            get { return _IsDargah; }
            set { _IsDargah = value; }
        }

        private SbnBoolean _IsInternal = SbnBoolean.OutOfValue;        
        /// <summary>
        /// حوزه واحد سازمانی درونی یا بیرونی
        /// </summary>
        [Description("حوزه واحد سازمانی درونی یا بیرونی")]
        [DisplayName("حوزه")]
        [Category("")]
        [DocumentAttributeID("2096")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("SbnBoolean")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public SbnBoolean IsInternal
        {
            get { return _IsInternal; }
            set { _IsInternal = value; }
        }
       
        private OrgUnit _MergedUnit;
        /// <summary>
        /// واحد ادغام شده با این واحد سازمانی
        /// </summary>
        [Description("واحد ادغام شده با این واحد سازمانی")]
        [DisplayName("واحد ادغام شده")]
        [Category("")]
        [DocumentAttributeID("27056")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("OrgUnit")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public OrgUnit MergedUnit
        {
            get { return _MergedUnit; }
            set { _MergedUnit = value; }
        }
        public override string ToString()
        {
            try { return this.Title; }
            catch { } return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._UnitPath = "";
            this._ExpireDate = "";
            this._BuildingLocation = new OrgUnitBuildingLocation();
            this._ChildUnits = new OrgUnits();
            this._ParentUnit = new OrgUnit();
            this._Positions = new OrgPositions();
            this._IsExpire = SbnBoolean.OutOfValue;
            this._IsInternal = SbnBoolean.OutOfValue;
            this._IsDargah= SbnBoolean.OutOfValue;
           
            this._MergedUnit = new OrgUnit();
        }
        public override SbnObject Clone(string sNodeName)
        {
            OrgUnit retObject = new OrgUnit();
            retObject.ID = this.ID;
            retObject.UnitPath = this._UnitPath;
            if (this._ExpireDate != null) retObject.ExpireDate = (string)this._ExpireDate.Clone();
            if (!object.ReferenceEquals(this.BuildingLocation, null))
                retObject.BuildingLocation = (OrgUnitBuildingLocation)this.BuildingLocation.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ChildUnits, null))
                retObject.ChildUnits = (OrgUnits)this.ChildUnits.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ParentUnit, null))
                retObject.ParentUnit = (OrgUnit)this.ParentUnit.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Positions, null))
                retObject.Positions = (OrgPositions)this.Positions.Clone(sNodeName);
            retObject.IsExpire = this.IsExpire;
            retObject.IsInternal = this.IsInternal;
            retObject.IsDargah = this.IsDargah;
            
            if (!object.ReferenceEquals(this.MergedUnit, null))
                retObject.MergedUnit = (OrgUnit)this.MergedUnit.Clone(sNodeName);
            return retObject;
        }
        public static string at_UnitPath
        {
            get
            {
                return "OrgUnit.UnitPath";
            }
        }
        public static string at_ExpireDate
        {
            get
            {
                return "OrgUnit.ExpireDate";
            }
        }
        public static string at_BuildingLocationID
        {
            get
            {
                return "OrgUnit.BuildingLocationID";
            }
        }
        public static string at_BuildingLocationFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.BuildingLocationFirstLevelAttributes";
            }
        }
        public static string at_BuildingLocation_OrgUnitsFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.BuildingLocation.OrgUnitsFirstLevelAttributes";
            }
        }
        public static string at_BuildingLocation_ParentLocationFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.BuildingLocation.ParentLocationFirstLevelAttributes";
            }
        }
        public static string at_BuildingLocation_ChildLocationsFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.BuildingLocation.ChildLocationsFirstLevelAttributes";
            }
        }
        public static string at_ChildUnitsID
        {
            get
            {
                return "OrgUnit.ChildUnitsID";
            }
        }
        public static string at_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.ChildUnitsFirstLevelAttributes";
            }
        }
        public static string at_ParentUnitID
        {
            get
            {
                return "OrgUnit.ParentUnitID";
            }
        }
        public static string at_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.ParentUnitFirstLevelAttributes";
            }
        }
        public static string at_ParentUnit_BuildingLocationFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.ParentUnit.BuildingLocationFirstLevelAttributes";
            }
        }
        public static string at_ParentUnit_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.ParentUnit.ChildUnitsFirstLevelAttributes";
            }
        }
        public static string at_ParentUnit_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.ParentUnit.ParentUnitFirstLevelAttributes";
            }
        }
        public static string at_ParentUnit_PositionsFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.ParentUnit.PositionsFirstLevelAttributes";
            }
        }
        public static string at_ParentUnit_MergedUnitFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.ParentUnit.MergedUnitFirstLevelAttributes";
            }
        }
        public static string at_PositionsID
        {
            get
            {
                return "OrgUnit.PositionsID";
            }
        }
        public static string at_PositionsFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.PositionsFirstLevelAttributes";
            }
        }
        public static string at_IsExpire
        {
            get
            {
                return "OrgUnit.IsExpire";
            }
        }
        public static string at_IsInternal
        {
            get
            {
                return "OrgUnit.IsInternal";
            }
        }

        public static string at_IsDargah
        {
            get
            {
                return "OrgUnit.IsDargah";
            }
        }
       
        public static string at_MergedUnitID
        {
            get
            {
                return "OrgUnit.MergedUnitID";
            }
        }
        public static string at_MergedUnitFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.MergedUnitFirstLevelAttributes";
            }
        }
        public static string at_MergedUnit_BuildingLocationFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.MergedUnit.BuildingLocationFirstLevelAttributes";
            }
        }
        public static string at_MergedUnit_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.MergedUnit.ChildUnitsFirstLevelAttributes";
            }
        }
        public static string at_MergedUnit_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.MergedUnit.ParentUnitFirstLevelAttributes";
            }
        }
        public static string at_MergedUnit_PositionsFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.MergedUnit.PositionsFirstLevelAttributes";
            }
        }
        public static string at_MergedUnit_MergedUnitFirstLevelAttributes
        {
            get
            {
                return "OrgUnit.MergedUnit.MergedUnitFirstLevelAttributes";
            }
        }
    }
}
