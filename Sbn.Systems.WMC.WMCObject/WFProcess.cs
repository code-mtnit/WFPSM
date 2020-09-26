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
[Description("يك مرحله از يك فرايند كه شامل يك زمينه كاري و ويژگيهاي آن است")]
[DisplayName ("يك مرحله از يك فرايند كه شامل يك زمينه كاري و ويژگيهاي آن است")]
[ObjectCode ("2009")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.WFProcesses")]
    [SystemName("WMC")]
[Serializable]
public class WFProcess : SbnObject 
{
public WFProcess() 
: base() 
{ 
} 
public WFProcess(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private int _XposInDiagram;
/// <summary>
/// مختصات افقی در نمودار فرایند
/// </summary>
[Description("مختصات افقی در نمودار فرایند")]
[DisplayName("مختصات افقی")]
[Category("")]
[DocumentAttributeID("2029")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int XposInDiagram
{
get { return _XposInDiagram; }
set { _XposInDiagram = value; }
}
private int _YPosInDiagram;
/// <summary>
/// مختصات عمودی در نمودار فرایند
/// </summary>
[Description("مختصات عمودی در نمودار فرایند")]
[DisplayName("مختصات عمودی")]
[Category("")]
[DocumentAttributeID("2030")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int YPosInDiagram
{
get { return _YPosInDiagram; }
set { _YPosInDiagram = value; }
}
private Workflow _CoWorkflow;
/// <summary>
/// فرایند مرتبط
/// </summary>
[Description("فرایند مرتبط")]
[DisplayName("فرایند مرتبط")]
[Category("")]
[DocumentAttributeID("2054")]
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
private WorkContext _CurrentWC;
/// <summary>
/// زمینه کاری مرتبط
/// </summary>
[Description("زمینه کاری مرتبط")]
[DisplayName("زمینه کاری")]
[Category("")]
[DocumentAttributeID("2065")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WorkContext")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public WorkContext CurrentWC
{
get { return _CurrentWC; }
set { _CurrentWC = value; }
}
private WorkContext _NextWC;
/// <summary>
/// زمینه کاری بعدی
/// </summary>
[Description("زمینه کاری بعدی")]
[DisplayName("زمینه کاری بعدی")]
[Category("")]
[DocumentAttributeID("2066")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WorkContext")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public WorkContext NextWC
{
get { return _NextWC; }
set { _NextWC = value; }
}
private SbnBoolean _IsJoinner = SbnBoolean.OutOfValue;
/// <summary>
/// آیا این مرحه از به هم پیوستن جند مرحله ایجاد می شود
/// </summary>
[Description("آیا این مرحه از به هم پیوستن جند مرحله ایجاد می شود")]
[DisplayName("ادغام کننده")]
[Category("")]
[DocumentAttributeID("2100")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SbnBoolean")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SbnBoolean IsJoinner
{
get { return _IsJoinner; }
set { _IsJoinner = value; }
}
private SbnBoolean _IsFork = SbnBoolean.OutOfValue;
/// <summary>
/// آیا این مرحله از فرایند به مراحلی دیگر منشعب می شود
/// </summary>
[Description("آیا این مرحله از فرایند به مراحلی دیگر منشعب می شود")]
[DisplayName("تفکیک کننده")]
[Category("")]
[DocumentAttributeID("2101")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SbnBoolean")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SbnBoolean IsFork
{
get { return _IsFork; }
set { _IsFork = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._XposInDiagram = 0;
this._YPosInDiagram = 0;
this._CoWorkflow = new Workflow() ;
this._CurrentWC = new WorkContext() ;
this._NextWC = new WorkContext() ;
this._IsJoinner = SbnBoolean.OutOfValue;
this._IsFork = SbnBoolean.OutOfValue;
}
public override SbnObject Clone(string sNodeName)
{
WFProcess retObject = new WFProcess();
retObject.ID = this.ID;
retObject.XposInDiagram = this._XposInDiagram;
retObject.YPosInDiagram = this._YPosInDiagram;
if (! object.ReferenceEquals( this.CoWorkflow , null))
retObject.CoWorkflow = (Workflow)this.CoWorkflow.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CurrentWC , null))
retObject.CurrentWC = (WorkContext)this.CurrentWC.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.NextWC , null))
retObject.NextWC = (WorkContext)this.NextWC.Clone(sNodeName) ;
retObject.IsJoinner = this.IsJoinner;
retObject.IsFork = this.IsFork;
return retObject;
}
public static string at_XposInDiagram
{
get
{
return "WFProcess.XposInDiagram";
}
}
public static string at_YPosInDiagram
{
get
{
return "WFProcess.YPosInDiagram";
}
}
public static string at_CoWorkflowID
{
get
{
return "WFProcess.CoWorkflowID";
}
}
public static string at_CoWorkflowFirstLevelAttributes
{
get
{
return "WFProcess.CoWorkflowFirstLevelAttributes";
}
}
public static string at_CoWorkflow_RolesFirstLevelAttributes
{
get
{
return "WFProcess.CoWorkflow.RolesFirstLevelAttributes";
}
}
public static string at_CoWorkflow_ProcessesFirstLevelAttributes
{
get
{
return "WFProcess.CoWorkflow.ProcessesFirstLevelAttributes";
}
}
public static string at_CoWorkflow_CoOrganFirstLevelAttributes
{
get
{
return "WFProcess.CoWorkflow.CoOrganFirstLevelAttributes";
}
}
public static string at_CurrentWCID
{
get
{
return "WFProcess.CurrentWCID";
}
}
public static string at_CurrentWCFirstLevelAttributes
{
get
{
return "WFProcess.CurrentWCFirstLevelAttributes";
}
}
public static string at_CurrentWC_CoUIFirstLevelAttributes
{
get
{
return "WFProcess.CurrentWC.CoUIFirstLevelAttributes";
}
}
public static string at_CurrentWC_CoDocumentTypeFirstLevelAttributes
{
get
{
return "WFProcess.CurrentWC.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_CurrentWC_CoOrganFirstLevelAttributes
{
get
{
return "WFProcess.CurrentWC.CoOrganFirstLevelAttributes";
}
}
public static string at_CurrentWC_PictureFirstLevelAttributes
{
get
{
return "WFProcess.CurrentWC.PictureFirstLevelAttributes";
}
}
public static string at_NextWCID
{
get
{
return "WFProcess.NextWCID";
}
}
public static string at_NextWCFirstLevelAttributes
{
get
{
return "WFProcess.NextWCFirstLevelAttributes";
}
}
public static string at_NextWC_CoUIFirstLevelAttributes
{
get
{
return "WFProcess.NextWC.CoUIFirstLevelAttributes";
}
}
public static string at_NextWC_CoDocumentTypeFirstLevelAttributes
{
get
{
return "WFProcess.NextWC.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_NextWC_CoOrganFirstLevelAttributes
{
get
{
return "WFProcess.NextWC.CoOrganFirstLevelAttributes";
}
}
public static string at_NextWC_PictureFirstLevelAttributes
{
get
{
return "WFProcess.NextWC.PictureFirstLevelAttributes";
}
}
public static string at_IsJoinner
{
get
{
return "WFProcess.IsJoinner";
}
}
public static string at_IsFork
{
get
{
return "WFProcess.IsFork";
}
}
}
}
