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
[Description("وظيفه اي كه بر اساس يك فرايند در سازمان شروع ميشود")]
[DisplayName ("وظيفه اي كه بر اساس يك فرايند در سازمان شروع ميشود")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.Tasks")]
    [ObjectCode("2072")]
[SystemName ("WMC")]
[Serializable]
public class Task : SbnObject 
{
public Task() 
: base() 
{ 
} 
public Task(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private long _OuterOrganTaskID;
/// <summary>
/// کد وظیفه ای که از سازمان بیرونی ارسال شده است
/// </summary>
[Description("کد وظیفه ای که از سازمان بیرونی ارسال شده است")]
[DisplayName("کد وظیفه بیرونی")]
[Category("")]
[DocumentAttributeID("2057")]
[IsRelationalAttribute("false")]
[AttributeType("Long")]
[Browsable(true)]
public long OuterOrganTaskID
{
get { return _OuterOrganTaskID; }
set { _OuterOrganTaskID = value; }
}
private Workflow _CoWorkflow;
/// <summary>
/// فرایند مرتبط که بیشتر کاربرد آن برای وظایف ارسال شده از بیرون سازمان است
/// </summary>
[Description("فرایند مرتبط که بیشتر کاربرد آن برای وظایف ارسال شده از بیرون سازمان است")]
[DisplayName("فرایند مرتبط")]
[Category("")]
[DocumentAttributeID("2143")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Workflow")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public Workflow CoWorkflow
{
get { return _CoWorkflow; }
set { _CoWorkflow = value; }
}
private SbnBoolean _IsWFMandatory = SbnBoolean.OutOfValue;
/// <summary>
/// اجبار در تبعیت وظیفه از گردش کار
/// </summary>
[Description("اجبار در تبعیت وظیفه از گردش کار")]
[DisplayName("تبعیت از گردش کار")]
[Category("")]
[DocumentAttributeID("2144")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SbnBoolean")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SbnBoolean IsWFMandatory
{
get { return _IsWFMandatory; }
set { _IsWFMandatory = value; }
}
private OrgUnit _OuterSenderOrgan;
/// <summary>
/// سازمان بیرونی فرستنده وظیفه
/// </summary>
[Description("سازمان بیرونی فرستنده وظیفه")]
[DisplayName("سازمان فرستنده وظیفه")]
[Category("")]
[DocumentAttributeID("2140")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("OrgUnit")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public OrgUnit OuterSenderOrgan
{
get { return _OuterSenderOrgan; }
set { _OuterSenderOrgan = value; }
}
private Activities _Activities;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2114")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("Activities")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public Activities Activities
{
get { return _Activities; }
set { _Activities = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._OuterOrganTaskID = 0;
this._CoWorkflow = new Workflow() ;
this._IsWFMandatory = SbnBoolean.OutOfValue;
this._OuterSenderOrgan = new OrgUnit() ;
this._Activities = new Activities() ;
}
public override SbnObject Clone(string sNodeName)
{
Task retObject = new Task();
retObject.ID = this.ID;
retObject.OuterOrganTaskID = this._OuterOrganTaskID;
if (! object.ReferenceEquals( this.CoWorkflow , null))
retObject.CoWorkflow = (Workflow)this.CoWorkflow.Clone(sNodeName) ;
retObject.IsWFMandatory = this.IsWFMandatory;
if (! object.ReferenceEquals( this.OuterSenderOrgan , null))
retObject.OuterSenderOrgan = (OrgUnit)this.OuterSenderOrgan.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.Activities , null))
retObject.Activities = (Activities)this.Activities.Clone(sNodeName) ;
return retObject;
}
public static string at_OuterOrganTaskID
{
get
{
return "Task.OuterOrganTaskID";
}
}
public static string at_CoWorkflowID
{
get
{
return "Task.CoWorkflowID";
}
}
public static string at_CoWorkflowFirstLevelAttributes
{
get
{
return "Task.CoWorkflowFirstLevelAttributes";
}
}
public static string at_CoWorkflow_RolesFirstLevelAttributes
{
get
{
return "Task.CoWorkflow.RolesFirstLevelAttributes";
}
}
public static string at_CoWorkflow_ProcessesFirstLevelAttributes
{
get
{
return "Task.CoWorkflow.ProcessesFirstLevelAttributes";
}
}
public static string at_CoWorkflow_CoOrganFirstLevelAttributes
{
get
{
return "Task.CoWorkflow.CoOrganFirstLevelAttributes";
}
}
public static string at_IsWFMandatory
{
get
{
return "Task.IsWFMandatory";
}
}
public static string at_OuterSenderOrganID
{
get
{
return "Task.OuterSenderOrganID";
}
}
public static string at_OuterSenderOrganFirstLevelAttributes
{
get
{
return "Task.OuterSenderOrganFirstLevelAttributes";
}
}
public static string at_OuterSenderOrgan_BuildingLocationFirstLevelAttributes
{
get
{
return "Task.OuterSenderOrgan.BuildingLocationFirstLevelAttributes";
}
}
public static string at_OuterSenderOrgan_ChildUnitsFirstLevelAttributes
{
get
{
return "Task.OuterSenderOrgan.ChildUnitsFirstLevelAttributes";
}
}
public static string at_OuterSenderOrgan_ParentUnitFirstLevelAttributes
{
get
{
return "Task.OuterSenderOrgan.ParentUnitFirstLevelAttributes";
}
}
public static string at_OuterSenderOrgan_PositionsFirstLevelAttributes
{
get
{
return "Task.OuterSenderOrgan.PositionsFirstLevelAttributes";
}
}
public static string at_OuterSenderOrgan_MergedUnitFirstLevelAttributes
{
get
{
return "Task.OuterSenderOrgan.MergedUnitFirstLevelAttributes";
}
}
public static string at_ActivitiesID
{
get
{
return "Task.ActivitiesID";
}
}
public static string at_ActivitiesFirstLevelAttributes
{
get
{
return "Task.ActivitiesFirstLevelAttributes";
}
}
}
}
