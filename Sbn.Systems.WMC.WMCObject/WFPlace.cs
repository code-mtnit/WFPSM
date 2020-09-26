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
[Description("مرحله يا مقطع در فرايند كه مي تواند يك پست سازماني در سازمان باشد.")]
[DisplayName ("مرحله يا مقطع در فرايند كه مي تواند يك پست سازماني در سازمان باشد.")]
[ObjectCode ("2114")]
[SystemName ("WMC")]
[ItemsType ("Sbn.Systems.WMC.WMCObject.WFPlaces")]
[Serializable]
public class WFPlace : SbnObject 
{
public WFPlace() 
: base() 
{ 
} 
public WFPlace(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private int _XposInDiagram;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("27175")]
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
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("27176")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int YPosInDiagram
{
get { return _YPosInDiagram; }
set { _YPosInDiagram = value; }
}
private WorkContext _CoWC;
/// <summary>
/// از این طریق می توان به سند مورد پردازش جهت اعمال قوانین در گذر دست پیدا نمود
/// </summary>
[Description("از این طریق می توان به سند مورد پردازش جهت اعمال قوانین در گذر دست پیدا نمود")]
[DisplayName("زمینه کاری مرتبط")]
[Category("")]
[DocumentAttributeID("27293")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WorkContext")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public WorkContext CoWC
{
get { return _CoWC; }
set { _CoWC = value; }
}
private Workflow _CoWorkflow;
/// <summary>
/// فرایند مرتبط
/// </summary>
[Description("فرایند مرتبط")]
[DisplayName("فرایند مرتبط")]
[Category("")]
[DocumentAttributeID("27274")]
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
private WFPlaceType _PlaceType = WFPlaceType.OutOfValue;
/// <summary>
/// نوع مرحله
/// </summary>
[Description("نوع مرحله")]
[DisplayName("نوع مرحله")]
[Category("")]
[DocumentAttributeID("27275")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WFPlaceType")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public WFPlaceType PlaceType
{
get { return _PlaceType; }
set { _PlaceType = value; }
}
private WFRoles _CoRoleResources;
/// <summary>
/// نقشهای منابع مرتبط با این مرحله
/// </summary>
[Description("نقشهای منابع مرتبط با این مرحله")]
[DisplayName("نقشهای مرتبط")]
[Category("")]
[DocumentAttributeID("27285")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WFRoles")]
[IsMiddleTableExist("False")]
[RelationTable("WFPlace_Role_M")]
public WFRoles CoRoleResources
{
get { return _CoRoleResources; }
set { _CoRoleResources = value; }
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
this._CoWC = new WorkContext() ;
this._CoWorkflow = new Workflow() ;
this._PlaceType = WFPlaceType.OutOfValue;
this._CoRoleResources = new WFRoles() ;
}
public override SbnObject Clone(string sNodeName)
{
WFPlace retObject = new WFPlace(this);
retObject.XposInDiagram = this._XposInDiagram;
retObject.YPosInDiagram = this._YPosInDiagram;
if (! object.ReferenceEquals( this.CoWC , null))
retObject.CoWC = (WorkContext)this.CoWC.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoWorkflow , null))
retObject.CoWorkflow = (Workflow)this.CoWorkflow.Clone(sNodeName) ;
retObject.PlaceType = this.PlaceType;
if (! object.ReferenceEquals( this.CoRoleResources , null))
retObject.CoRoleResources = (WFRoles)this.CoRoleResources.Clone(sNodeName) ;
return retObject;
}
public static string at_XposInDiagram
{
get
{
return "WFPlace.XposInDiagram";
}
}
public static string at_YPosInDiagram
{
get
{
return "WFPlace.YPosInDiagram";
}
}
public static string at_CoWCID
{
get
{
return "WFPlace.CoWCID";
}
}
public static string at_CoWCTitle
{
get
{
return "WFPlace.CoWCTitle";
}
}
public static string at_CoWCFirstLevelAttributes
{
get
{
return "WFPlace.CoWCFirstLevelAttributes";
}
}
public static string at_CoWC_CoUIFirstLevelAttributes
{
get
{
return "WFPlace.CoWC.CoUIFirstLevelAttributes";
}
}
public static string at_CoWC_CoDocumentTypeFirstLevelAttributes
{
get
{
return "WFPlace.CoWC.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_CoWC_CoOrganFirstLevelAttributes
{
get
{
return "WFPlace.CoWC.CoOrganFirstLevelAttributes";
}
}
public static string at_CoWC_PictureFirstLevelAttributes
{
get
{
return "WFPlace.CoWC.PictureFirstLevelAttributes";
}
}
public static string at_CoWorkflowID
{
get
{
return "WFPlace.CoWorkflowID";
}
}
public static string at_CoWorkflowTitle
{
get
{
return "WFPlace.CoWorkflowTitle";
}
}
public static string at_CoWorkflowFirstLevelAttributes
{
get
{
return "WFPlace.CoWorkflowFirstLevelAttributes";
}
}
public static string at_CoWorkflow_RolesFirstLevelAttributes
{
get
{
return "WFPlace.CoWorkflow.RolesFirstLevelAttributes";
}
}
public static string at_CoWorkflow_PlacesFirstLevelAttributes
{
get
{
return "WFPlace.CoWorkflow.PlacesFirstLevelAttributes";
}
}
public static string at_CoWorkflow_CoOrganFirstLevelAttributes
{
get
{
return "WFPlace.CoWorkflow.CoOrganFirstLevelAttributes";
}
}
public static string at_PlaceType
{
get
{
return "WFPlace.PlaceType";
}
}
public static string at_CoRoleResourcesID
{
get
{
return "WFPlace.CoRoleResourcesID";
}
}
public static string at_CoRoleResourcesTitle
{
get
{
return "WFPlace.CoRoleResourcesTitle";
}
}
public static string at_CoRoleResourcesFirstLevelAttributes
{
get
{
return "WFPlace.CoRoleResourcesFirstLevelAttributes";
}
}
}
}
