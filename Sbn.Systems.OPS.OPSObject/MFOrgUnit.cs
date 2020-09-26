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
namespace Sbn.Systems.OPS.OPSObject
{
    [Description("ساختار واحد های سازمانی")]
    [DisplayName("ساختار واحد های سازمانی")]
    [ObjectCode("21018")]
    [SystemName("OPS")]
    [ItemsType("Sbn.Systems.OPS.OPSObject.MFOrgUnits")]
    [Serializable]
    public class MFOrgUnit : SbnObject
    {
        public MFOrgUnit()
            : base()
        {
        }
        public MFOrgUnit(SbnObject InitialObject)
            : base(InitialObject)
        {
        }
        private string _ExpireDate;
        /// <summary>
        /// تاریخ خاتمه
        /// </summary>
        [Description("تاریخ خاتمه")]
        [DisplayName("تاریخ خاتمه")]
        [Category("")]
        [DocumentAttributeID("27238")]
        [IsRelationalAttribute("false")]
        [AttributeType("DateString")]
        [Browsable(true)]
        public string ExpireDate
        {
            get { return _ExpireDate; }
            set { _ExpireDate = value; }
        }
        private MFOrgUnits _ChildUnits;
        /// <summary>
        /// واحد های زیرمجموعه
        /// </summary>
        [Description("واحد های زیرمجموعه")]
        [DisplayName("واحد های زیرمجموعه")]
        [Category("")]
        [DocumentAttributeID("27417")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("MFOrgUnits")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public MFOrgUnits ChildUnits
        {
            get { return _ChildUnits; }
            set { _ChildUnits = value; }
        }
        private MFOrgUnit _ParentUnit;
        /// <summary>
        /// ساختار بالا دستی
        /// </summary>
        [Description("ساختار بالا دستی")]
        [DisplayName("ساختار بالایی")]
        [Category("")]
        [DocumentAttributeID("27418")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("MFOrgUnit")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public MFOrgUnit ParentUnit
        {
            get { return _ParentUnit; }
            set { _ParentUnit = value; }
        }
        private MFOrgPositions _Positions;
        /// <summary>
        /// سمتهای مرتبط
        /// </summary>
        [Description("سمتهای مرتبط")]
        [DisplayName("سمتهای مرتبط")]
        [Category("")]
        [DocumentAttributeID("27419")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("MFOrgPositions")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public MFOrgPositions Positions
        {
            get { return _Positions; }
            set { _Positions = value; }
        }
        private OrgUnitAddresses _AddressInfos;
        /// <summary>
        /// اطلاعات آدرس و تماس
        /// </summary>
        [Description("اطلاعات آدرس و تماس")]
        [DisplayName("اطلاعات آدرس و تماس")]
        [Category("")]
        [DocumentAttributeID("27429")]
        [Browsable(true)]
        [IsRelationalAttribute("True")]
        [AttributeType("OrgUnitAddresses")]
        [IsMiddleTableExist("True")]
        [RelationTable("")]
        public OrgUnitAddresses AddressInfos
        {
            get { return _AddressInfos; }
            set { _AddressInfos = value; }
        }
        private PersonnelInterdicts _Interdicts;
        /// <summary>
        /// احکام مرتبط
        /// </summary>
        [Description("احکام مرتبط")]
        [DisplayName("احکام مرتبط")]
        [Category("")]
        [DocumentAttributeID("27430")]
        [Browsable(true)]
        [IsRelationalAttribute("False")]
        [AttributeType("PersonnelInterdicts")]
        [IsMiddleTableExist("False")]
        [RelationTable("")]
        public PersonnelInterdicts Interdicts
        {
            get { return _Interdicts; }
            set { _Interdicts = value; }
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override void Initialize()
        {
            base.Initialize();
            this._ExpireDate = "";
            this._ChildUnits = new MFOrgUnits();
            this._ParentUnit = new MFOrgUnit();
            this._Positions = new MFOrgPositions();
            this._AddressInfos = new OrgUnitAddresses();
            this._Interdicts = new PersonnelInterdicts();
        }
        public override SbnObject Clone(string sNodeName)
        {
            MFOrgUnit retObject = new MFOrgUnit(this);
            if (this._ExpireDate != null) retObject.ExpireDate = (string)this._ExpireDate.Clone();
            if (!object.ReferenceEquals(this.ChildUnits, null))
                retObject.ChildUnits = (MFOrgUnits)this.ChildUnits.Clone(sNodeName);
            if (!object.ReferenceEquals(this.ParentUnit, null))
                retObject.ParentUnit = (MFOrgUnit)this.ParentUnit.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Positions, null))
                retObject.Positions = (MFOrgPositions)this.Positions.Clone(sNodeName);
            if (!object.ReferenceEquals(this.AddressInfos, null))
                retObject.AddressInfos = (OrgUnitAddresses)this.AddressInfos.Clone(sNodeName);
            if (!object.ReferenceEquals(this.Interdicts, null))
                retObject.Interdicts = (PersonnelInterdicts)this.Interdicts.Clone(sNodeName);
            return retObject;
        }
        public static string at_ExpireDate
        {
            get
            {
                return "MFOrgUnit.ExpireDate";
            }
        }
        public static string at_ChildUnitsID
        {
            get
            {
                return "MFOrgUnit.ChildUnitsID";
            }
        }
        public static string at_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "MFOrgUnit.ChildUnitsFirstLevelAttributes";
            }
        }
        public static string at_ParentUnitID
        {
            get
            {
                return "MFOrgUnit.ParentUnitID";
            }
        }
        public static string at_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "MFOrgUnit.ParentUnitFirstLevelAttributes";
            }
        }
        public static string at_ParentUnit_ExpireDate
        {
            get
            {
                return "MFOrgUnit.ParentUnit.ExpireDate";
            }
        }
        public static string at_ParentUnit_ChildUnitsFirstLevelAttributes
        {
            get
            {
                return "MFOrgUnit.ParentUnit.ChildUnitsFirstLevelAttributes";
            }
        }
        public static string at_ParentUnit_ParentUnitFirstLevelAttributes
        {
            get
            {
                return "MFOrgUnit.ParentUnit.ParentUnitFirstLevelAttributes";
            }
        }
        public static string at_ParentUnit_PositionsFirstLevelAttributes
        {
            get
            {
                return "MFOrgUnit.ParentUnit.PositionsFirstLevelAttributes";
            }
        }
        public static string at_ParentUnit_AddressInfosFirstLevelAttributes
        {
            get
            {
                return "MFOrgUnit.ParentUnit.AddressInfosFirstLevelAttributes";
            }
        }
        public static string at_ParentUnit_InterdictsFirstLevelAttributes
        {
            get
            {
                return "MFOrgUnit.ParentUnit.InterdictsFirstLevelAttributes";
            }
        }
        public static string at_PositionsID
        {
            get
            {
                return "MFOrgUnit.PositionsID";
            }
        }
        public static string at_PositionsFirstLevelAttributes
        {
            get
            {
                return "MFOrgUnit.PositionsFirstLevelAttributes";
            }
        }
        public static string at_AddressInfosID
        {
            get
            {
                return "MFOrgUnit.AddressInfosID";
            }
        }
        public static string at_AddressInfosFirstLevelAttributes
        {
            get
            {
                return "MFOrgUnit.AddressInfosFirstLevelAttributes";
            }
        }
        public static string at_InterdictsID
        {
            get
            {
                return "MFOrgUnit.InterdictsID";
            }
        }
        public static string at_InterdictsFirstLevelAttributes
        {
            get
            {
                return "MFOrgUnit.InterdictsFirstLevelAttributes";
            }
        }
    }
}
