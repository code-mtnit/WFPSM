using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Core;
using MSXML2;
namespace Sbn.Systems.ELS.ELSObject
{
[Description("زير سيستم")]
[DisplayName ("زير سيستم")]
    [ObjectCode("11017")]
    [ItemsType("Sbn.Systems.ELS.ELSObject.SubSystems")]
    [SystemName("ELS")]

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
private string _Title;
/// <summary>
/// عنوان زیر سیستم
/// </summary>
[Description("عنوان زیر سیستم")]
[DisplayName("عنوان")]
[Category("")]
[DocumentAttributeID("11033")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string Title
{
get { return _Title; }
set { _Title = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._Title =  "";
}
public override SbnObject Clone(string sNodeName)
{
SubSystem retObject = new SubSystem();
retObject.ID = this.ID;
retObject.Title = this._Title;
return retObject;
}
public static string at_Title
{
get
{
return "SubSystem.Title";
}
}
}
}
