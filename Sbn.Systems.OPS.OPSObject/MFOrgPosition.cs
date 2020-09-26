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
[Description("سمت")]
[DisplayName ("سمت")]
[ObjectCode ("21002")]
[SystemName ("OPS")]
[ItemsType ("Sbn.Systems.OPS.OPSObject.MFOrgPositions")]
[Serializable]
public class MFOrgPosition : SbnObject 
{
public MFOrgPosition() 
: base() 
{ 
} 
public MFOrgPosition(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private OrgUnit _OrgUnit;
/// <summary>
/// واحد سازمانی
/// </summary>
[Description("واحد سازمانی")]
[DisplayName("واحد سازمانی")]
[Category("")]
[DocumentAttributeID("21004")]
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
private PersonnelInterdicts _Interdicts;
/// <summary>
/// احکام سازمانی
/// </summary>
[Description("احکام سازمانی")]
[DisplayName("احکام سازمانی")]
[Category("")]
[DocumentAttributeID("21005")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("PersonnelInterdicts")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public PersonnelInterdicts Interdicts
{
get { return _Interdicts; }
set { _Interdicts = value; }
}
private MFOrgUnit _CoOrgUnit;
/// <summary>
/// واحد سازمانی مرتبط
/// </summary>
[Description("واحد سازمانی مرتبط")]
[DisplayName("واحد سازمانی")]
[Category("")]
[DocumentAttributeID("27415")]
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
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._OrgUnit = new OrgUnit() ;
this._Interdicts = new PersonnelInterdicts() ;
this._CoOrgUnit = new MFOrgUnit() ;
}
public override SbnObject Clone(string sNodeName)
{
MFOrgPosition retObject = new MFOrgPosition(this);
if (! object.ReferenceEquals( this.OrgUnit , null))
retObject.OrgUnit = (OrgUnit)this.OrgUnit.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.Interdicts , null))
retObject.Interdicts = (PersonnelInterdicts)this.Interdicts.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoOrgUnit , null))
retObject.CoOrgUnit = (MFOrgUnit)this.CoOrgUnit.Clone(sNodeName) ;
return retObject;
}
public static string at_OrgUnitID
{
get
{
return "MFOrgPosition.OrgUnitID";
}
}
public static string at_OrgUnitFirstLevelAttributes
{
get
{
return "MFOrgPosition.OrgUnitFirstLevelAttributes";
}
}
public static string at_OrgUnit_BuildingLocationFirstLevelAttributes
{
get
{
return "MFOrgPosition.OrgUnit.BuildingLocationFirstLevelAttributes";
}
}
public static string at_OrgUnit_ChildUnitsFirstLevelAttributes
{
get
{
return "MFOrgPosition.OrgUnit.ChildUnitsFirstLevelAttributes";
}
}
public static string at_OrgUnit_ParentUnitFirstLevelAttributes
{
get
{
return "MFOrgPosition.OrgUnit.ParentUnitFirstLevelAttributes";
}
}
public static string at_OrgUnit_PositionsFirstLevelAttributes
{
get
{
return "MFOrgPosition.OrgUnit.PositionsFirstLevelAttributes";
}
}
public static string at_OrgUnit_MergedUnitFirstLevelAttributes
{
get
{
return "MFOrgPosition.OrgUnit.MergedUnitFirstLevelAttributes";
}
}
public static string at_InterdictsID
{
get
{
return "MFOrgPosition.InterdictsID";
}
}
public static string at_InterdictsFirstLevelAttributes
{
get
{
return "MFOrgPosition.InterdictsFirstLevelAttributes";
}
}
public static string at_CoOrgUnitID
{
get
{
return "MFOrgPosition.CoOrgUnitID";
}
}
public static string at_CoOrgUnitFirstLevelAttributes
{
get
{
return "MFOrgPosition.CoOrgUnitFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_ChildUnitsFirstLevelAttributes
{
get
{
return "MFOrgPosition.CoOrgUnit.ChildUnitsFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_ParentUnitFirstLevelAttributes
{
get
{
return "MFOrgPosition.CoOrgUnit.ParentUnitFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_PositionsFirstLevelAttributes
{
get
{
return "MFOrgPosition.CoOrgUnit.PositionsFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_AddressInfosFirstLevelAttributes
{
get
{
return "MFOrgPosition.CoOrgUnit.AddressInfosFirstLevelAttributes";
}
}
}
}
