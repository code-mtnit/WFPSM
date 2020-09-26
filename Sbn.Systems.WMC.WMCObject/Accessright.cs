using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
namespace Sbn.Systems.WMC.WMCObject
{
[Description("اين كلاس براي تعيين سطح دسترسي كارمندان استفاده مي شود مورد كاربرد آن كنترل سطح دسترسي كارمند در محيط كاربري است")]
[DisplayName ("اين كلاس براي تعيين سطح دسترسي كارمندان استفاده مي شود مورد كاربرد آن كنترل سطح دسترسي كارمند در محيط كاربري است")]
[ObjectCode ("2010")]
    [SystemName("WMC")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.Accessrights")]
[Serializable]
public class Accessright : SbnObject 
{
public Accessright() 
: base() 
{ 
} 
public Accessright(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private UserInterface _DefaultUI;
/// <summary>
/// محیط کاربری پیش فرض
/// </summary>
[Description("محیط کاربری پیش فرض")]
[DisplayName("محیط کاربری پیش فرض")]
[Category("")]
[DocumentAttributeID("27021")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("UserInterface")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public UserInterface DefaultUI
{
get { return _DefaultUI; }
set { _DefaultUI = value; }
}
public override string ToString()
{
    try { return this.Title ; }    catch { } return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._DefaultUI = new UserInterface() ;
}
public override SbnObject Clone(string sNodeName)
{
Accessright retObject = new Accessright();
retObject.ID = this.ID;
if (! object.ReferenceEquals( this.DefaultUI , null))
retObject.DefaultUI = (UserInterface)this.DefaultUI.Clone(sNodeName) ;
return retObject;
}
public static string at_DefaultUIID
{
get
{
return "Accessright.DefaultUIID";
}
}
public static string at_DefaultUIFirstLevelAttributes
{
get
{
return "Accessright.DefaultUIFirstLevelAttributes";
}
}
public static string at_DefaultUI_CoAccessRightsFirstLevelAttributes
{
get
{
return "Accessright.DefaultUI.CoAccessRightsFirstLevelAttributes";
}
}
public static string at_DefaultUI_ChildInterfacesFirstLevelAttributes
{
get
{
return "Accessright.DefaultUI.ChildInterfacesFirstLevelAttributes";
}
}
public static string at_DefaultUI_ParentFirstLevelAttributes
{
get
{
return "Accessright.DefaultUI.ParentFirstLevelAttributes";
}
}
public static string at_DefaultUI_CoDocumentTypeFirstLevelAttributes
{
get
{
return "Accessright.DefaultUI.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_DefaultUI_PictureFirstLevelAttributes
{
get
{
return "Accessright.DefaultUI.PictureFirstLevelAttributes";
}
}
public static string at_DefaultUI_CoSubSystemFirstLevelAttributes
{
get
{
return "Accessright.DefaultUI.CoSubSystemFirstLevelAttributes";
}
}
public static string at_DefaultUI_DefaultFolderFirstLevelAttributes
{
get
{
return "Accessright.DefaultUI.DefaultFolderFirstLevelAttributes";
}
}
}
}
