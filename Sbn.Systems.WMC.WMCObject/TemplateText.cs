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
[Description("متون پيش فرض كه هر كاربر بر اساس نوع مي تواند آنها را دسته بندي كند مانند پيام يا شرح ارجاع و ...")]
[DisplayName ("متون پيش فرض كه هر كاربر بر اساس نوع مي تواند آنها را دسته بندي كند مانند پيام يا شرح ارجاع و ...")]
[ObjectCode ("2076")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.TemplateTexts")]
    [SystemName("WMC")]
[Serializable]
public class TemplateText : SbnObject 
{
public TemplateText() 
: base() 
{ 
} 
public TemplateText(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private WFPerson _CoPerson;
/// <summary>
/// شخص
/// </summary>
[Description("شخص")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("27064")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("WFPerson")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public WFPerson CoPerson
{
get { return _CoPerson; }
set { _CoPerson = value; }
}
private BasicInfoDetail _TextType;
/// <summary>
/// نوع
/// </summary>
[Description("نوع")]
[DisplayName("نوع")]
[Category("")]
[DocumentAttributeID("2125")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("BasicInfoDetail")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public BasicInfoDetail TextType
{
get { return _TextType; }
set { _TextType = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._CoPerson = new WFPerson() ;
this._TextType = new BasicInfoDetail() ;
}
public override SbnObject Clone(string sNodeName)
{
TemplateText retObject = new TemplateText();
retObject.ID = this.ID;
if (! object.ReferenceEquals( this.CoPerson , null))
retObject.CoPerson = (WFPerson)this.CoPerson.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.TextType , null))
retObject.TextType = (BasicInfoDetail)this.TextType.Clone(sNodeName) ;
return retObject;
}
public static string at_CoPersonID
{
get
{
return "TemplateText.CoPersonID";
}
}
public static string at_CoPersonFirstLevelAttributes
{
get
{
return "TemplateText.CoPersonFirstLevelAttributes";
}
}
public static string at_CoPerson_WorkersFirstLevelAttributes
{
get
{
return "TemplateText.CoPerson.WorkersFirstLevelAttributes";
}
}
public static string at_CoPerson_SexFirstLevelAttributes
{
get
{
return "TemplateText.CoPerson.SexFirstLevelAttributes";
}
}
public static string at_TextTypeID
{
get
{
return "TemplateText.TextTypeID";
}
}
public static string at_TextTypeFirstLevelAttributes
{
get
{
return "TemplateText.TextTypeFirstLevelAttributes";
}
}
public static string at_TextType_ParentFirstLevelAttributes
{
get
{
return "TemplateText.TextType.ParentFirstLevelAttributes";
}
}
}
}
