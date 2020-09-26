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
    [ObjectCode("11004")]
    [SystemName("ELS")]

[Serializable]
public class WorkContext : SbnObject 
{
public WorkContext() 
: base() 
{ 
} 
public WorkContext(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _Title;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("نوع اقدام")]
[Category("")]
[DocumentAttributeID("11007")]
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
return this.Title;
}
public override void Initialize()
{
base.Initialize();
this._Title =  "";
}
public override SbnObject Clone(string sNodeName)
{
WorkContext retObject = new WorkContext();
retObject.ID = this.ID;
retObject.Title = this._Title;
return retObject;
}
public static string at_Title
{
get
{
return "WorkContext.Title";
}
}
}
}
