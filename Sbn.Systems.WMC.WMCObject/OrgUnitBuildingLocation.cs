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
[Description("ساختار فيزيكي سازمان")]
[DisplayName ("ساختار فيزيكي سازمان")]
[ObjectCode ("2021")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.OrgUnitBuildingLocations")]
    [SystemName("WMC")]
[Serializable]
public class OrgUnitBuildingLocation : SbnObject 
{
public OrgUnitBuildingLocation() 
: base() 
{ 
} 
public OrgUnitBuildingLocation(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _BuildingPath;
/// <summary>
/// مسیر رشته ای این ساختار که در ابدای واحد های زیرین قرار  می گیرد
/// </summary>
[Description("مسیر رشته ای این ساختار که در ابدای واحد های زیرین قرار  می گیرد")]
[DisplayName("مسیر ساختار")]
[Category("")]
[DocumentAttributeID("2028")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string BuildingPath
{
get { return _BuildingPath; }
set { _BuildingPath = value; }
}
private OrgUnits _OrgUnits;
/// <summary>
/// واحدهای سازمانی که در این ساختار فیزیکی وجود دارد
/// </summary>
[Description("واحدهای سازمانی که در این ساختار فیزیکی وجود دارد")]
[DisplayName("ساختارهای سازمانی")]
[Category("")]
[DocumentAttributeID("2000")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("OrgUnits")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public OrgUnits OrgUnits
{
get { return _OrgUnits; }
set { _OrgUnits = value; }
}
private OrgUnitBuildingLocation _ParentLocation;
/// <summary>
/// ساختار بالاتر
/// </summary>
[Description("ساختار بالاتر")]
[DisplayName("ساختار بالاتر")]
[Category("")]
[DocumentAttributeID("2032")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("OrgUnitBuildingLocation")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public OrgUnitBuildingLocation ParentLocation
{
get { return _ParentLocation; }
set { _ParentLocation = value; }
}
private OrgUnitBuildingLocations _ChildLocations;
/// <summary>
/// ساختار های فیزیکی پایین تر
/// </summary>
[Description("ساختار های فیزیکی پایین تر")]
[DisplayName("ساختارهای پایینتر")]
[Category("")]
[DocumentAttributeID("2033")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("OrgUnitBuildingLocations")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public OrgUnitBuildingLocations ChildLocations
{
get { return _ChildLocations; }
set { _ChildLocations = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._BuildingPath =  "";
this._OrgUnits = new OrgUnits() ;
this._ParentLocation = new OrgUnitBuildingLocation() ;
this._ChildLocations = new OrgUnitBuildingLocations() ;
}
public override SbnObject Clone(string sNodeName)
{
OrgUnitBuildingLocation retObject = new OrgUnitBuildingLocation();
retObject.ID = this.ID;
retObject.BuildingPath = this._BuildingPath;
if (! object.ReferenceEquals( this.OrgUnits , null))
retObject.OrgUnits = (OrgUnits)this.OrgUnits.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.ParentLocation , null))
retObject.ParentLocation = (OrgUnitBuildingLocation)this.ParentLocation.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.ChildLocations , null))
retObject.ChildLocations = (OrgUnitBuildingLocations)this.ChildLocations.Clone(sNodeName) ;
return retObject;
}
public static string at_BuildingPath
{
get
{
return "OrgUnitBuildingLocation.BuildingPath";
}
}
public static string at_OrgUnitsID
{
get
{
return "OrgUnitBuildingLocation.OrgUnitsID";
}
}
public static string at_OrgUnitsFirstLevelAttributes
{
get
{
return "OrgUnitBuildingLocation.OrgUnitsFirstLevelAttributes";
}
}
public static string at_ParentLocationID
{
get
{
return "OrgUnitBuildingLocation.ParentLocationID";
}
}
public static string at_ParentLocationFirstLevelAttributes
{
get
{
return "OrgUnitBuildingLocation.ParentLocationFirstLevelAttributes";
}
}
public static string at_ParentLocation_OrgUnitsFirstLevelAttributes
{
get
{
return "OrgUnitBuildingLocation.ParentLocation.OrgUnitsFirstLevelAttributes";
}
}
public static string at_ParentLocation_ParentLocationFirstLevelAttributes
{
get
{
return "OrgUnitBuildingLocation.ParentLocation.ParentLocationFirstLevelAttributes";
}
}
public static string at_ParentLocation_ChildLocationsFirstLevelAttributes
{
get
{
return "OrgUnitBuildingLocation.ParentLocation.ChildLocationsFirstLevelAttributes";
}
}
public static string at_ChildLocationsID
{
get
{
return "OrgUnitBuildingLocation.ChildLocationsID";
}
}
public static string at_ChildLocationsFirstLevelAttributes
{
get
{
return "OrgUnitBuildingLocation.ChildLocationsFirstLevelAttributes";
}
}
}
}
