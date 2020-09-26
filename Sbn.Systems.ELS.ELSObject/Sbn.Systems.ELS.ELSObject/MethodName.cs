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
[Description("نام رويداد سطح پايين")]
[DisplayName ("نام رويداد سطح پايين")]
[ObjectCode ("11019")]
    [ItemsType("Sbn.Systems.ELS.ELSObject.MethodNames")]
    [SystemName("ELS")]
[Serializable]
public class MethodName : SbnObject 
{
public MethodName() 
: base() 
{ 
} 
public MethodName(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _Title;
/// <summary>
/// عنوان تابع
/// </summary>
[Description("عنوان تابع")]
[DisplayName("عنوان")]
[Category("")]
[DocumentAttributeID("11034")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string Title
{
get { return _Title; }
set { _Title = value; }
}
private string _FName;
/// <summary>
/// نام فارسی
/// </summary>
[Description("نام فارسی")]
[DisplayName("نام فارسی")]
[Category("")]
[DocumentAttributeID("27164")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string FName
{
get { return _FName; }
set { _FName = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._Title =  "";
this._FName =  "";
}
public override SbnObject Clone(string sNodeName)
{
MethodName retObject = new MethodName();
retObject.ID = this.ID;
retObject.Title = this._Title;
retObject.FName = this._FName;
return retObject;
}
public static string at_Title
{
get
{
return "MethodName.Title";
}
}
public static string at_FName
{
get
{
return "MethodName.FName";
}
}
}
}
