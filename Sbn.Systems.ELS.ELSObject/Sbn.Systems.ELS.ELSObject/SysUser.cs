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
[Description("")]
[DisplayName ("")]
    [ObjectCode("11006")]
    [ItemsType("Sbn.Systems.ELS.ELSObject.SysUsers")]
    [SystemName("ELS")]

[Serializable]
public class SysUser : SbnObject 
{
public SysUser() 
: base() 
{ 
} 
public SysUser(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _Username;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("شناسه")]
[Category("")]
[DocumentAttributeID("11009")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string Username
{
get { return _Username; }
set { _Username = value; }
}
public override string ToString()
{
return this.Username;
}
public override void Initialize()
{
base.Initialize();
this._Username =  "";
}
public override SbnObject Clone(string sNodeName)
{
SysUser retObject = new SysUser();
retObject.ID = this.ID;
retObject.Username = this._Username;
return retObject;
}
public static string at_Username
{
get
{
return "SysUser.Username";
}
}
}
}
