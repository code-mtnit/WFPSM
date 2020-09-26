using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Core;
using MSXML2;
using Sbn.Systems.WMC;
using Sbn.Systems.WMC.WMCObject;
namespace Sbn.Systems.OPS.OPSObject
{
[Description("شخص حقيقي")]
[DisplayName ("شخص حقيقي")]
[ObjectCode ("21000")]
[SystemName ("OPS")]
[ItemsType ("Sbn.Systems.OPS.OPSObject.MFPersons")]
[Serializable]
public class MFPerson : SbnObject 
{
public MFPerson() 
: base() 
{ 
} 
public MFPerson(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _BirthDate;
/// <summary>
/// تاریخ تولد
/// </summary>
[Description("تاریخ تولد")]
[DisplayName("تاریخ تولد")]
[Category("")]
[DocumentAttributeID("27042")]
[IsRelationalAttribute("false")]
[AttributeType("DateString")]
[Browsable(true)]
public string BirthDate
{
get { return _BirthDate; }
set { _BirthDate = value; }
}
private string _EMail;
/// <summary>
/// آدرس پست الکترونیک
/// </summary>
[Description("آدرس پست الکترونیک")]
[DisplayName("آدرس پست الکترونیک")]
[Category("")]
[DocumentAttributeID("27043")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string EMail
{
get { return _EMail; }
set { _EMail = value; }
}
private string _Fathername;
/// <summary>
/// نام پدر
/// </summary>
[Description("نام پدر")]
[DisplayName("نام پدر")]
[Category("")]
[DocumentAttributeID("27044")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string Fathername
{
get { return _Fathername; }
set { _Fathername = value; }
}
private string _FirstName;
/// <summary>
/// نام
/// </summary>
[Description("نام")]
[DisplayName("نام")]
[Category("")]
[DocumentAttributeID("27045")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string FirstName
{
get { return _FirstName; }
set { _FirstName = value; }
}
private string _LastName;
/// <summary>
/// نام خانوادگی
/// </summary>
[Description("نام خانوادگی")]
[DisplayName("")]
[Category("نام خانوادگی")]
[DocumentAttributeID("27046")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string LastName
{
get { return _LastName; }
set { _LastName = value; }
}
private string _NationalCode;
/// <summary>
/// کد ملی
/// </summary>
[Description("کد ملی")]
[DisplayName("کد ملی")]
[Category("")]
[DocumentAttributeID("27047")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string NationalCode
{
get { return _NationalCode; }
set { _NationalCode = value; }
}
private int _PersonalId;
/// <summary>
/// شماره شناسنامه
/// </summary>
[Description("شماره شناسنامه")]
[DisplayName("شماره شناسنامه")]
[Category("")]
[DocumentAttributeID("27048")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int PersonalId
{
get { return _PersonalId; }
set { _PersonalId = value; }
}
private int _SerialNumber;
/// <summary>
/// سریال شناسنامه
/// </summary>
[Description("سریال شناسنامه")]
[DisplayName("سریال شناسنامه")]
[Category("")]
[DocumentAttributeID("27049")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int SerialNumber
{
get { return _SerialNumber; }
set { _SerialNumber = value; }
}
private string _SeriesNumber;
/// <summary>
/// سری شناسنامه
/// </summary>
[Description("سری شناسنامه")]
[DisplayName("سری شناسنامه")]
[Category("")]
[DocumentAttributeID("27050")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string SeriesNumber
{
get { return _SeriesNumber; }
set { _SeriesNumber = value; }
}
private PersonnelInterdicts _Interdicts;
/// <summary>
/// احکام سازمانی
/// </summary>
[Description("احکام سازمانی")]
[DisplayName("احکام سازمانی")]
[Category("")]
[DocumentAttributeID("21003")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("PersonnelInterdicts")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public PersonnelInterdicts Interdicts
{
get { return _Interdicts; }
set { _Interdicts = value; }
}
private PersonPicture _Picrture;
/// <summary>
/// تصویر
/// </summary>
[Description("تصویر")]
[DisplayName("تصویر")]
[Category("")]
[DocumentAttributeID("27069")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("PersonPicture")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public PersonPicture Picrture
{
get { return _Picrture; }
set { _Picrture = value; }
}
private BasicInfoDetail _Sex;
/// <summary>
/// جنسیت
/// </summary>
[Description("جنسیت")]
[DisplayName("جنسیت")]
[Category("")]
[DocumentAttributeID("27070")]
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
if (this.FirstName != null && this.LastName != null) return  this.LastName + " ، " + this.FirstName;
return "";
}
public override void Initialize()
{
base.Initialize();
this._BirthDate = "";
this._EMail =  "";
this._Fathername =  "";
this._FirstName =  "";
this._LastName =  "";
this._NationalCode =  "";
this._PersonalId = 0;
this._SerialNumber = 0;
this._SeriesNumber =  "";
this._Interdicts = new PersonnelInterdicts() ;
this._Picrture = new PersonPicture() ;
this._Sex = new BasicInfoDetail() ;
}
public override SbnObject Clone(string sNodeName)
{
MFPerson retObject = new MFPerson(this);
if(this._BirthDate != null)  retObject.BirthDate = (string)this._BirthDate.Clone();
retObject.EMail = this._EMail;
retObject.Fathername = this._Fathername;
retObject.FirstName = this._FirstName;
retObject.LastName = this._LastName;
retObject.NationalCode = this._NationalCode;
retObject.PersonalId = this._PersonalId;
retObject.SerialNumber = this._SerialNumber;
retObject.SeriesNumber = this._SeriesNumber;
if (! object.ReferenceEquals( this.Interdicts , null))
retObject.Interdicts = (PersonnelInterdicts)this.Interdicts.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.Picrture , null))
retObject.Picrture = (PersonPicture)this.Picrture.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.Sex , null))
retObject.Sex = (BasicInfoDetail)this.Sex.Clone(sNodeName) ;
return retObject;
}
public static string at_BirthDate
{
get
{
return "MFPerson.BirthDate";
}
}
public static string at_EMail
{
get
{
return "MFPerson.EMail";
}
}
public static string at_Fathername
{
get
{
return "MFPerson.Fathername";
}
}
public static string at_FirstName
{
get
{
return "MFPerson.FirstName";
}
}
public static string at_LastName
{
get
{
return "MFPerson.LastName";
}
}
public static string at_NationalCode
{
get
{
return "MFPerson.NationalCode";
}
}
public static string at_PersonalId
{
get
{
return "MFPerson.PersonalId";
}
}
public static string at_SerialNumber
{
get
{
return "MFPerson.SerialNumber";
}
}
public static string at_SeriesNumber
{
get
{
return "MFPerson.SeriesNumber";
}
}
public static string at_InterdictsID
{
get
{
return "MFPerson.InterdictsID";
}
}
public static string at_InterdictsFirstLevelAttributes
{
get
{
return "MFPerson.InterdictsFirstLevelAttributes";
}
}
public static string at_PicrtureID
{
get
{
return "MFPerson.PicrtureID";
}
}
public static string at_PicrtureFirstLevelAttributes
{
get
{
return "MFPerson.PicrtureFirstLevelAttributes";
}
}
public static string at_SexID
{
get
{
return "MFPerson.SexID";
}
}
public static string at_SexFirstLevelAttributes
{
get
{
return "MFPerson.SexFirstLevelAttributes";
}
}
public static string at_Sex_ParentFirstLevelAttributes
{
get
{
return "MFPerson.Sex.ParentFirstLevelAttributes";
}
}
}
}
