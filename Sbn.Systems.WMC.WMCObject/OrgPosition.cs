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
[Description("سمت")]
[DisplayName ("سمت")]
[ObjectCode ("2001")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.OrgPositions")]
    [SystemName("WMC")]
[Serializable]
public class OrgPosition : SbnObject 
{
public OrgPosition() 
: base() 
{ 
} 
public OrgPosition(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _DefinitionDate;
/// <summary>
/// تاریخ تعریف پست
/// </summary>
[Description("تاریخ تعریف پست")]
[DisplayName("تاریخ تعریف پست")]
[Category("")]
[DocumentAttributeID("27023")]
[IsRelationalAttribute("false")]
[AttributeType("DateString")]
[Browsable(true)]
public string DefinitionDate
{
get { return _DefinitionDate; }
set { _DefinitionDate = value; }
}
private string _ExpireDate;
/// <summary>
/// تاریخ اعتبار
/// </summary>
[Description("تاریخ اعتبار")]
[DisplayName("تاریخ اعتبار")]
[Category("")]
[DocumentAttributeID("27024")]
[IsRelationalAttribute("false")]
[AttributeType("DateString")]
[Browsable(true)]
public string ExpireDate
{
get { return _ExpireDate; }
set { _ExpireDate = value; }
}
private OrgUnit _CoOrgUnit;
/// <summary>
/// واحد سازمانی مرتبط
/// </summary>
[Description("واحد سازمانی مرتبط")]
[DisplayName("واحد سازمانی مرتبط")]
[Category("")]
[DocumentAttributeID("2015")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("OrgUnit")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public OrgUnit CoOrgUnit
{
get { return _CoOrgUnit; }
set { _CoOrgUnit = value; }
}
private Workers _Workers;
/// <summary>
/// کارمندان
/// </summary>
[Description("کارمندان")]
[DisplayName("کارمندان")]
[Category("")]
[DocumentAttributeID("2028")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("Workers")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public Workers Workers
{
get { return _Workers; }
set { _Workers = value; }
}
private SbnBoolean _IsExpired = SbnBoolean.OutOfValue;
/// <summary>
/// آیا اعتبار پست منقضی شده است؟
/// </summary>
[Description("آیا اعتبار پست منقضی شده است؟")]
[DisplayName("انقضای پست")]
[Category("")]
[DocumentAttributeID("2118")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SbnBoolean")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SbnBoolean IsExpired
{
get { return _IsExpired; }
set { _IsExpired = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._DefinitionDate = "";
this._ExpireDate = "";
this._CoOrgUnit = new OrgUnit() ;
this._Workers = new Workers() ;
this._IsExpired = SbnBoolean.OutOfValue;
}
public override SbnObject Clone(string sNodeName)
{
OrgPosition retObject = new OrgPosition();
retObject.ID = this.ID;
if(this._DefinitionDate != null)  retObject.DefinitionDate = (string)this._DefinitionDate.Clone();
if(this._ExpireDate != null)  retObject.ExpireDate = (string)this._ExpireDate.Clone();
if (! object.ReferenceEquals( this.CoOrgUnit , null))
retObject.CoOrgUnit = (OrgUnit)this.CoOrgUnit.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.Workers , null))
retObject.Workers = (Workers)this.Workers.Clone(sNodeName) ;
retObject.IsExpired = this.IsExpired;
return retObject;
}
public static string at_DefinitionDate
{
get
{
return "OrgPosition.DefinitionDate";
}
}
public static string at_ExpireDate
{
get
{
return "OrgPosition.ExpireDate";
}
}
public static string at_CoOrgUnitID
{
get
{
return "OrgPosition.CoOrgUnitID";
}
}
public static string at_CoOrgUnitFirstLevelAttributes
{
get
{
return "OrgPosition.CoOrgUnitFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_BuildingLocationFirstLevelAttributes
{
get
{
return "OrgPosition.CoOrgUnit.BuildingLocationFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_ChildUnitsFirstLevelAttributes
{
get
{
return "OrgPosition.CoOrgUnit.ChildUnitsFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_ParentUnitFirstLevelAttributes
{
get
{
return "OrgPosition.CoOrgUnit.ParentUnitFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_PositionsFirstLevelAttributes
{
get
{
return "OrgPosition.CoOrgUnit.PositionsFirstLevelAttributes";
}
}
public static string at_CoOrgUnit_MergedUnitFirstLevelAttributes
{
get
{
return "OrgPosition.CoOrgUnit.MergedUnitFirstLevelAttributes";
}
}
public static string at_WorkersID
{
get
{
return "OrgPosition.WorkersID";
}
}
public static string at_WorkersFirstLevelAttributes
{
get
{
return "OrgPosition.WorkersFirstLevelAttributes";
}
}
public static string at_IsExpired
{
get
{
return "OrgPosition.IsExpired";
}
}
}
}
