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
[ObjectCode ("2102")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.WMCAttachments")]
    [SystemName("WMC")]
[Serializable]
public class WMCAttachment : SbnBinary 
{
public WMCAttachment() 
: base() 
{ 
} 
public WMCAttachment(SbnBinary InitialObject) 
: base(InitialObject) 
{ 
} 
private string _FileType;
/// <summary>
/// نوع ضمیمه
/// </summary>
[Description("نوع ضمیمه")]
[DisplayName("نوع ضمیمه")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27073")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string FileType
{
get { return _FileType; }
set { _FileType = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._FileType =  "";
}
public override SbnObject Clone(string sNodeName)
{
WMCAttachment retObject = new WMCAttachment();
retObject.ID = this.ID;
retObject.FileType = this._FileType;
return retObject;
}
public static string at_FileType
{
get
{
return "WMCAttachment.FileType";
}
}
}
}
