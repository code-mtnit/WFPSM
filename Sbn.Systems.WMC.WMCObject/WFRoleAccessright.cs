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
[Description("دسترسي اعطا شده به نقش")]
[DisplayName ("دسترسي اعطا شده به نقش")]
[ObjectCode ("2058")]
[SystemName ("WMC")]
[ItemsType ("Sbn.Systems.WMC.WMCObject.WFRoleAccessrights")]
[Serializable]
public class WFRoleAccessright : SbnObject 
{
public WFRoleAccessright() 
: base() 
{ 
} 
public WFRoleAccessright(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private WFRole _CoRole;
/// <summary>
/// نقش مرتبط
/// </summary>
[Description("نقش مرتبط")]
[DisplayName("نقش مرتبط")]
[Category("")]
[DocumentAttributeID("27010")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WFRole")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public WFRole CoRole
{
get { return _CoRole; }
set { _CoRole = value; }
}
private Accessright _CoAccessright;
/// <summary>
/// دسترسی مرتبط
/// </summary>
[Description("دسترسی مرتبط")]
[DisplayName("دسترسی مرتبط")]
[Category("")]
[DocumentAttributeID("2081")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Accessright")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public Accessright CoAccessright
{
get { return _CoAccessright; }
set { _CoAccessright = value; }
}
private WorkContext _CoWC;
/// <summary>
/// زمینه کاری مرتبط
/// </summary>
[Description("زمینه کاری مرتبط")]
[DisplayName("زمینه کاری مرتبط")]
[Category("")]
[DocumentAttributeID("27032")]
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
private UserInterface _CoUI;
/// <summary>
/// محیط کاری مرتبط
/// </summary>
[Description("محیط کاری مرتبط")]
[DisplayName("محیط کاری مرتبط")]
[Category("")]
[DocumentAttributeID("27033")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("UserInterface")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public UserInterface CoUI
{
get { return _CoUI; }
set { _CoUI = value; }
}
private Folder _CoFolder;
/// <summary>
/// پوشه
/// </summary>
[Description("پوشه")]
[DisplayName("پوشه")]
[Category("")]
[DocumentAttributeID("27335")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Folder")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public Folder CoFolder
{
get { return _CoFolder; }
set { _CoFolder = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._CoRole = new WFRole() ;
this._CoAccessright = new Accessright() ;
this._CoWC = new WorkContext() ;
this._CoUI = new UserInterface() ;
this._CoFolder = new Folder() ;
}
public override SbnObject Clone(string sNodeName)
{
WFRoleAccessright retObject = new WFRoleAccessright(this);
if (! object.ReferenceEquals( this.CoRole , null))
retObject.CoRole = (WFRole)this.CoRole.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoAccessright , null))
retObject.CoAccessright = (Accessright)this.CoAccessright.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoWC , null))
retObject.CoWC = (WorkContext)this.CoWC.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoUI , null))
retObject.CoUI = (UserInterface)this.CoUI.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoFolder , null))
retObject.CoFolder = (Folder)this.CoFolder.Clone(sNodeName) ;
return retObject;
}
public static string at_CoRoleID
{
get
{
return "WFRoleAccessright.CoRoleID";
}
}
public static string at_CoRoleTitle
{
get
{
return "WFRoleAccessright.CoRoleTitle";
}
}
public static string at_CoRoleFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoRoleFirstLevelAttributes";
}
}
public static string at_CoRole_Title
{
get
{
return "WFRoleAccessright.CoRole.Title";
}
}
public static string at_CoRole_RestrictionsFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoRole.RestrictionsFirstLevelAttributes";
}
}
public static string at_CoRole_AccessrightsFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoRole.AccessrightsFirstLevelAttributes";
}
}
public static string at_CoRole_CoWorkflowFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoRole.CoWorkflowFirstLevelAttributes";
}
}
public static string at_CoRole_CoWorkersFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoRole.CoWorkersFirstLevelAttributes";
}
}
public static string at_CoRole_CoPlacesFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoRole.CoPlacesFirstLevelAttributes";
}
}
public static string at_CoAccessrightID
{
get
{
return "WFRoleAccessright.CoAccessrightID";
}
}
public static string at_CoAccessrightTitle
{
get
{
return "WFRoleAccessright.CoAccessrightTitle";
}
}
public static string at_CoAccessrightFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoAccessrightFirstLevelAttributes";
}
}
public static string at_CoAccessright_DefaultUIFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoAccessright.DefaultUIFirstLevelAttributes";
}
}
public static string at_CoWCID
{
get
{
return "WFRoleAccessright.CoWCID";
}
}
public static string at_CoWCTitle
{
get
{
return "WFRoleAccessright.CoWCTitle";
}
}
public static string at_CoWCFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoWCFirstLevelAttributes";
}
}
public static string at_CoWC_CoUIFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoWC.CoUIFirstLevelAttributes";
}
}
public static string at_CoWC_CoDocumentTypeFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoWC.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_CoWC_CoOrganFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoWC.CoOrganFirstLevelAttributes";
}
}
public static string at_CoWC_PictureFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoWC.PictureFirstLevelAttributes";
}
}
public static string at_CoUIID
{
get
{
return "WFRoleAccessright.CoUIID";
}
}
public static string at_CoUITitle
{
get
{
return "WFRoleAccessright.CoUITitle";
}
}
public static string at_CoUIFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoUIFirstLevelAttributes";
}
}
public static string at_CoUI_WebPageURL
{
get
{
return "WFRoleAccessright.CoUI.WebPageURL";
}
}
public static string at_CoUI_IconStream
{
get
{
return "WFRoleAccessright.CoUI.IconStream";
}
}
public static string at_CoUI_ObjectNameSpace
{
get
{
return "WFRoleAccessright.CoUI.ObjectNameSpace";
}
}
public static string at_CoUI_CoAccessRightsFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoUI.CoAccessRightsFirstLevelAttributes";
}
}
public static string at_CoUI_ChildInterfacesFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoUI.ChildInterfacesFirstLevelAttributes";
}
}
public static string at_CoUI_ParentFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoUI.ParentFirstLevelAttributes";
}
}
public static string at_CoUI_CoDocumentTypeFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoUI.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_CoUI_PictureFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoUI.PictureFirstLevelAttributes";
}
}
public static string at_CoUI_CoSubSystemFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoUI.CoSubSystemFirstLevelAttributes";
}
}
public static string at_CoUI_DefaultFolderFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoUI.DefaultFolderFirstLevelAttributes";
}
}
public static string at_CoUI_WorkerAccessrightsFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoUI.WorkerAccessrightsFirstLevelAttributes";
}
}
public static string at_CoFolderID
{
get
{
return "WFRoleAccessright.CoFolderID";
}
}
public static string at_CoFolderTitle
{
get
{
return "WFRoleAccessright.CoFolderTitle";
}
}
public static string at_CoFolderFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoFolderFirstLevelAttributes";
}
}
public static string at_CoFolder_ParentFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoFolder.ParentFirstLevelAttributes";
}
}
public static string at_CoFolder_ChildsFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoFolder.ChildsFirstLevelAttributes";
}
}
public static string at_CoFolder_ItemsFirstLevelAttributes
{
get
{
return "WFRoleAccessright.CoFolder.ItemsFirstLevelAttributes";
}
}
}
}
