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
[Description("جريان كار")]
[DisplayName ("جريان كار")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.Workflows")]
    [ObjectCode("2006")]
[SystemName ("WMC")]
[Serializable]
public class Workflow : SbnObject 
{
public Workflow() 
: base() 
{ 
} 
public Workflow(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private WFRoles _Roles;
/// <summary>
/// نقشها
/// </summary>
[Description("نقشها")]
[DisplayName("نقشها")]
[Category("")]
[DocumentAttributeID("2052")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("Roles")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public WFRoles Roles
{
get { return _Roles; }
set { _Roles = value; }
}
private WFProcesses _Processes;
/// <summary>
/// مراحل و ترتیب اقدامات مرتبط با این فرایند
/// </summary>
[Description("مراحل و ترتیب اقدامات مرتبط با این فرایند")]
[DisplayName("مراحل")]
[Category("")]
[DocumentAttributeID("2055")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("WFProcesses")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public WFProcesses Processes
{
get { return _Processes; }
set { _Processes = value; }
}
private OrgUnit _CoOrgan;
/// <summary>
/// سازمانی که فرایند در آن جریان دارد
/// </summary>
[Description("سازمانی که فرایند در آن جریان دارد")]
[DisplayName("سازمان مرتبط")]
[Category("")]
[DocumentAttributeID("2094")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("OrgUnit")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public OrgUnit CoOrgan
{
get { return _CoOrgan; }
set { _CoOrgan = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._Roles = new WFRoles() ;
this._Processes = new WFProcesses() ;
this._CoOrgan = new OrgUnit() ;
}
public override SbnObject Clone(string sNodeName)
{
Workflow retObject = new Workflow();
retObject.ID = this.ID;
if (! object.ReferenceEquals( this.Roles , null))
retObject.Roles = (WFRoles)this.Roles.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.Processes , null))
retObject.Processes = (WFProcesses)this.Processes.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoOrgan , null))
retObject.CoOrgan = (OrgUnit)this.CoOrgan.Clone(sNodeName) ;
return retObject;
}
public static string at_RolesID
{
get
{
return "Workflow.RolesID";
}
}
public static string at_RolesFirstLevelAttributes
{
get
{
return "Workflow.RolesFirstLevelAttributes";
}
}
public static string at_ProcessesID
{
get
{
return "Workflow.ProcessesID";
}
}
public static string at_ProcessesFirstLevelAttributes
{
get
{
return "Workflow.ProcessesFirstLevelAttributes";
}
}
public static string at_CoOrganID
{
get
{
return "Workflow.CoOrganID";
}
}
public static string at_CoOrganFirstLevelAttributes
{
get
{
return "Workflow.CoOrganFirstLevelAttributes";
}
}
public static string at_CoOrgan_BuildingLocationFirstLevelAttributes
{
get
{
return "Workflow.CoOrgan.BuildingLocationFirstLevelAttributes";
}
}
public static string at_CoOrgan_ChildUnitsFirstLevelAttributes
{
get
{
return "Workflow.CoOrgan.ChildUnitsFirstLevelAttributes";
}
}
public static string at_CoOrgan_ParentUnitFirstLevelAttributes
{
get
{
return "Workflow.CoOrgan.ParentUnitFirstLevelAttributes";
}
}
public static string at_CoOrgan_PositionsFirstLevelAttributes
{
get
{
return "Workflow.CoOrgan.PositionsFirstLevelAttributes";
}
}
public static string at_CoOrgan_MergedUnitFirstLevelAttributes
{
get
{
return "Workflow.CoOrgan.MergedUnitFirstLevelAttributes";
}
}
}
}
