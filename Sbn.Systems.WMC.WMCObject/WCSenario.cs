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
[Description("")]
[DisplayName ("")]
[ObjectCode ("2110")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.WCSenarios")]
    [SystemName("WMC")]
[Serializable]
public class WCSenario : SbnObject 
{
public WCSenario() 
: base() 
{ 
} 
public WCSenario(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private int _OrderInSenario;
/// <summary>
/// ترتیب در سناریو
/// </summary>
[Description("ترتیب در سناریو")]
[DisplayName("ترتیب در سناریو")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27125")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int OrderInSenario
{
get { return _OrderInSenario; }
set { _OrderInSenario = value; }
}
private UserInterface _CoUI;
/// <summary>
/// محیط کاربری
/// </summary>
[Description("محیط کاربری")]
[DisplayName("محیط کاربری")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27153")]
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
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._OrderInSenario = 0;
this._CoUI = new UserInterface() ;
}
public override SbnObject Clone(string sNodeName)
{
WCSenario retObject = new WCSenario();
retObject.ID = this.ID;
retObject.OrderInSenario = this._OrderInSenario;
if (! object.ReferenceEquals( this.CoUI , null))
retObject.CoUI = (UserInterface)this.CoUI.Clone(sNodeName) ;
return retObject;
}
public static string at_OrderInSenario
{
get
{
return "WCSenario.OrderInSenario";
}
}
public static string at_CoUIID
{
get
{
return "WCSenario.CoUIID";
}
}
public static string at_CoUIFirstLevelAttributes
{
get
{
return "WCSenario.CoUIFirstLevelAttributes";
}
}
public static string at_CoUI_CoAccessRightsFirstLevelAttributes
{
get
{
return "WCSenario.CoUI.CoAccessRightsFirstLevelAttributes";
}
}
public static string at_CoUI_ChildInterfacesFirstLevelAttributes
{
get
{
return "WCSenario.CoUI.ChildInterfacesFirstLevelAttributes";
}
}
public static string at_CoUI_ParentFirstLevelAttributes
{
get
{
return "WCSenario.CoUI.ParentFirstLevelAttributes";
}
}
public static string at_CoUI_CoDocumentTypeFirstLevelAttributes
{
get
{
return "WCSenario.CoUI.CoDocumentTypeFirstLevelAttributes";
}
}
public static string at_CoUI_PictureFirstLevelAttributes
{
get
{
return "WCSenario.CoUI.PictureFirstLevelAttributes";
}
}
public static string at_CoUI_CoSubSystemFirstLevelAttributes
{
get
{
return "WCSenario.CoUI.CoSubSystemFirstLevelAttributes";
}
}
public static string at_CoUI_DefaultFolderFirstLevelAttributes
{
get
{
return "WCSenario.CoUI.DefaultFolderFirstLevelAttributes";
}
}
}
}
