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
[Description("زير سيستم مديريت گردش كار")]
[DisplayName ("زير سيستم مديريت گردش كار")]
[ObjectCode ("2063")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.SubSystems")]
    [SystemName("WMC")]
[Serializable]
public class SubSystem : SbnObject 
{
public SubSystem() 
: base() 
{ 
} 
public SubSystem(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private long _DocumentIDRange;
/// <summary>
/// محدوده کد اسناد
/// </summary>
[Description("محدوده کد اسناد")]
[DisplayName("محدوه کد اسناد")]
[Category("")]
[DocumentAttributeID("2031")]
[IsRelationalAttribute("false")]
[AttributeType("Long")]
[Browsable(true)]
public long DocumentIDRange
{
get { return _DocumentIDRange; }
set { _DocumentIDRange = value; }
}
private string _ClientObjectNamespace;
/// <summary>
/// نام کتابخانه مشتری
/// </summary>
[Description("نام کتابخانه مشتری")]
[DisplayName("نام کتابخانه")]
[Category("")]
[DocumentAttributeID("27040")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string ClientObjectNamespace
{
get { return _ClientObjectNamespace; }
set { _ClientObjectNamespace = value; }
}
private string _UIOjbectNamespace;
/// <summary>
/// نام کتابخانه ای محیط کاربری
/// </summary>
[Description("نام کتابخانه ای محیط کاربری")]
[DisplayName("کتابخانه محیط کاربری")]
[Category("")]
[DocumentAttributeID("27041")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string UIOjbectNamespace
{
get { return _UIOjbectNamespace; }
set { _UIOjbectNamespace = value; }
}
public override string ToString()
{
return this.Title ;
}
public override void Initialize()
{
base.Initialize();
this._DocumentIDRange = 0;
this._ClientObjectNamespace =  "";
this._UIOjbectNamespace =  "";
}
public override SbnObject Clone(string sNodeName)
{
SubSystem retObject = new SubSystem();
retObject.ID = this.ID;
retObject.DocumentIDRange = this._DocumentIDRange;
retObject.ClientObjectNamespace = this._ClientObjectNamespace;
retObject.UIOjbectNamespace = this._UIOjbectNamespace;
return retObject;
}
public static string at_DocumentIDRange
{
get
{
return "SubSystem.DocumentIDRange";
}
}
public static string at_ClientObjectNamespace
{
get
{
return "SubSystem.ClientObjectNamespace";
}
}
public static string at_UIOjbectNamespace
{
get
{
return "SubSystem.UIOjbectNamespace";
}
}
}
}
