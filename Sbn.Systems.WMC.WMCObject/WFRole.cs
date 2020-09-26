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
[Description("نقش")]
[DisplayName ("نقش")]
[ObjectCode ("2007")]
[SystemName ("WMC")]
[ItemsType ("Sbn.Systems.WMC.WMCObject.WFRoles")]
[Serializable]
public class WFRole : SbnObject 
{
public WFRole() 
: base() 
{ 
} 
public WFRole(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _Title;
/// <summary>
/// عنوان
/// </summary>
[Description("عنوان")]
[DisplayName("عنوان")]
[Category("")]
[DocumentAttributeID("2018")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string Title
{
get { return _Title; }
set { _Title = value; }
}
private WFRoleRestrictions _Restrictions;
/// <summary>
/// محدودیتها
/// </summary>
[Description("محدودیتها")]
[DisplayName("محدودیتها")]
[Category("")]
[DocumentAttributeID("2121")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("WFRoleRestrictions")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public WFRoleRestrictions Restrictions
{
get { return _Restrictions; }
set { _Restrictions = value; }
}
private WFRoleAccessrights _Accessrights;
/// <summary>
/// دسترسیهای اعطا شده به نقش
/// </summary>
[Description("دسترسیهای اعطا شده به نقش")]
[DisplayName("دسترسیها")]
[Category("")]
[DocumentAttributeID("2122")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("WFRoleAccessrights")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public WFRoleAccessrights Accessrights
{
get { return _Accessrights; }
set { _Accessrights = value; }
}
private Workflow _CoWorkflow;
/// <summary>
/// فرایند مرتبط
/// </summary>
[Description("فرایند مرتبط")]
[DisplayName("فرایند مرتبط")]
[Category("")]
[DocumentAttributeID("27035")]
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
private Workers _CoWorkers;
/// <summary>
/// کاربران عضو نقش
/// </summary>
[Description("کاربران عضو نقش")]
[DisplayName("کاربران مرتبط")]
[Category("")]
[DocumentAttributeID("27273")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Workers")]
[IsMiddleTableExist("False")]
[RelationTable("Role_Worker_M")]
public Workers CoWorkers
{
get { return _CoWorkers; }
set { _CoWorkers = value; }
}
private WFPlaces _CoPlaces;
/// <summary>
/// مراحل مرتبط با این نقش
/// </summary>
[Description("مراحل مرتبط با این نقش")]
[DisplayName("مراحل مرتبط")]
[Category("")]
[DocumentAttributeID("27287")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WFPlaces")]
[IsMiddleTableExist("False")]
[RelationTable("WFPlace_Role_M")]
public WFPlaces CoPlaces
{
get { return _CoPlaces; }
set { _CoPlaces = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._Title =  "";
this._Restrictions = new WFRoleRestrictions() ;
this._Accessrights = new WFRoleAccessrights() ;
this._CoWorkflow = new Workflow() ;
this._CoWorkers = new Workers() ;
this._CoPlaces = new WFPlaces() ;
}
public override SbnObject Clone(string sNodeName)
{
WFRole retObject = new WFRole(this);
retObject.Title = this._Title;
if (! object.ReferenceEquals( this.Restrictions , null))
retObject.Restrictions = (WFRoleRestrictions)this.Restrictions.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.Accessrights , null))
retObject.Accessrights = (WFRoleAccessrights)this.Accessrights.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoWorkflow , null))
retObject.CoWorkflow = (Workflow)this.CoWorkflow.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoWorkers , null))
retObject.CoWorkers = (Workers)this.CoWorkers.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoPlaces , null))
retObject.CoPlaces = (WFPlaces)this.CoPlaces.Clone(sNodeName) ;
return retObject;
}
public static string at_Title
{
get
{
return "WFRole.Title";
}
}
public static string at_RestrictionsID
{
get
{
return "WFRole.RestrictionsID";
}
}
public static string at_RestrictionsTitle
{
get
{
return "WFRole.RestrictionsTitle";
}
}
public static string at_RestrictionsFirstLevelAttributes
{
get
{
return "WFRole.RestrictionsFirstLevelAttributes";
}
}
public static string at_AccessrightsID
{
get
{
return "WFRole.AccessrightsID";
}
}
public static string at_AccessrightsTitle
{
get
{
return "WFRole.AccessrightsTitle";
}
}
public static string at_AccessrightsFirstLevelAttributes
{
get
{
return "WFRole.AccessrightsFirstLevelAttributes";
}
}
public static string at_CoWorkflowID
{
get
{
return "WFRole.CoWorkflowID";
}
}
public static string at_CoWorkflowTitle
{
get
{
return "WFRole.CoWorkflowTitle";
}
}
public static string at_CoWorkflowFirstLevelAttributes
{
get
{
return "WFRole.CoWorkflowFirstLevelAttributes";
}
}
public static string at_CoWorkflow_RolesFirstLevelAttributes
{
get
{
return "WFRole.CoWorkflow.RolesFirstLevelAttributes";
}
}
public static string at_CoWorkflow_PlacesFirstLevelAttributes
{
get
{
return "WFRole.CoWorkflow.PlacesFirstLevelAttributes";
}
}
public static string at_CoWorkflow_CoOrganFirstLevelAttributes
{
get
{
return "WFRole.CoWorkflow.CoOrganFirstLevelAttributes";
}
}
public static string at_CoWorkersID
{
get
{
return "WFRole.CoWorkersID";
}
}
public static string at_CoWorkersTitle
{
get
{
return "WFRole.CoWorkersTitle";
}
}
public static string at_CoWorkersFirstLevelAttributes
{
get
{
return "WFRole.CoWorkersFirstLevelAttributes";
}
}
public static string at_CoPlacesID
{
get
{
return "WFRole.CoPlacesID";
}
}
public static string at_CoPlacesTitle
{
get
{
return "WFRole.CoPlacesTitle";
}
}
public static string at_CoPlacesFirstLevelAttributes
{
get
{
return "WFRole.CoPlacesFirstLevelAttributes";
}
}
}
}
