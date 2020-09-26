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
[Description("شخص")]
[DisplayName ("شخص")]
[ObjectCode ("2025")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.WFPersons")]
    [SystemName("WMC")]
[Serializable]
public class WFPerson : SbnObject 
{
public WFPerson() 
: base() 
{ 
} 
public WFPerson(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _FirstName;
/// <summary>
/// نام
/// </summary>
[Description("نام")]
[DisplayName("نام")]
[Category("")]
[DocumentAttributeID("27010")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string FirstName
{
get { return _FirstName; }
set { _FirstName = value; }
}
private string _SurName;
/// <summary>
/// نام خانوادگی
/// </summary>
[Description("نام خانوادگی")]
[DisplayName("نام خانوادگی")]
[Category("")]
[DocumentAttributeID("27011")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string SurName
{
get { return _SurName; }
set { _SurName = value; }
}
private byte[] _Picture;
/// <summary>
/// تصویر
/// </summary>
[Description("تصویر")]
[DisplayName("تصویر")]
[Category("مشخصات اصلی")]
[DocumentAttributeID("27057")]
[IsRelationalAttribute("false")]
[AttributeType("Binary")]
[Browsable(true)]
public byte[] Picture
{
get { return _Picture; }
set { _Picture = value; }
}
private byte[] _Signature;
/// <summary>
/// تصویرامضاء
/// </summary>
[Description("تصویرامضاء")]
[DisplayName("تصویرامضاء")]
[Category("")]
[DocumentAttributeID("27019")]
[IsRelationalAttribute("false")]
[AttributeType("Binary")]
[Browsable(true)]
public byte[] Signature
{
get { return _Signature; }
set { _Signature = value; }
}
private Workers _Workers;
/// <summary>
/// کارمندان مرتبط
/// </summary>
[Description("کارمندان مرتبط")]
[DisplayName("کارمندان")]
[Category("")]
[DocumentAttributeID("2091")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("Workers")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public Workers Workers
{
get { return _Workers; }
set { _Workers = value; }
}
private BasicInfoDetail _Sex;
/// <summary>
/// جنسیت
/// </summary>
[Description("جنسیت")]
[DisplayName("جنسیت")]
[Category("")]
[DocumentAttributeID("27034")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("BasicInfoDetail")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public BasicInfoDetail Sex
{
get { return _Sex; }
set { _Sex = value; }
}
public override string ToString()
{
try { return this.SurName + " ، " + this.FirstName ; }    catch { } return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._FirstName =  "";
this._SurName =  "";
this._Picture=  new byte[1];
this._Signature=  new byte[1];
this._Workers = new Workers() ;
this._Sex = new BasicInfoDetail() ;
}
public override SbnObject Clone(string sNodeName)
{
WFPerson retObject = new WFPerson();
retObject.ID = this.ID;
retObject.FirstName = this._FirstName;
retObject.SurName = this._SurName;
if(this._Picture != null) retObject.Picture = (byte[]) this._Picture.Clone();
if(this._Signature != null) retObject.Signature = (byte[]) this._Signature.Clone();
if (! object.ReferenceEquals( this.Workers , null))
retObject.Workers = (Workers)this.Workers.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.Sex , null))
retObject.Sex = (BasicInfoDetail)this.Sex.Clone(sNodeName) ;
return retObject;
}
public static string at_FirstName
{
get
{
return "WFPerson.FirstName";
}
}
public static string at_SurName
{
get
{
return "WFPerson.SurName";
}
}
public static string at_Picture
{
get
{
return "WFPerson.Picture";
}
}
public static string at_Signature
{
get
{
return "WFPerson.Signature";
}
}
public static string at_WorkersID
{
get
{
return "WFPerson.WorkersID";
}
}
public static string at_WorkersFirstLevelAttributes
{
get
{
return "WFPerson.WorkersFirstLevelAttributes";
}
}
public static string at_SexID
{
get
{
return "WFPerson.SexID";
}
}
public static string at_SexFirstLevelAttributes
{
get
{
return "WFPerson.SexFirstLevelAttributes";
}
}
public static string at_Sex_ParentFirstLevelAttributes
{
get
{
return "WFPerson.Sex.ParentFirstLevelAttributes";
}
}
}
}
