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
[Description("نوع سند")]
[DisplayName ("نوع سند")]
    [ObjectCode("11010")]
    [ItemsType("Sbn.Systems.ELS.ELSObject.DocumentTypes")]
    [SystemName("ELS")]

[Serializable]
public class DocumentType : SbnObject 
{
public DocumentType() 
: base() 
{ 
} 
public DocumentType(SbnObject InitialObject) 
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
[DocumentAttributeID("11014")]
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
DocumentType retObject = new DocumentType();
retObject.ID = this.ID;
retObject.Title = this._Title;
return retObject;
}
public static string at_Title
{
get
{
return "DocumentType.Title";
}
}
}
}
