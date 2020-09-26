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
namespace Sbn.Systems.OPS.OPSObject
{
[Description("")]
[DisplayName ("")]
[ObjectCode ("21012")]
[SystemName ("OPS")]
[ItemsType ("Sbn.Systems.OPS.OPSObject.Addresses")]
[Serializable]
public class Address : SbnObject 
{
public Address() 
: base() 
{ 
} 
public Address(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _BasicStreet;
/// <summary>
/// نام خیابان اصلی
/// </summary>
[Description("نام خیابان اصلی")]
[DisplayName("خیابان اصلی")]
[Category("")]
[DocumentAttributeID("27234")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string BasicStreet
{
get { return _BasicStreet; }
set { _BasicStreet = value; }
}
private string _PostalCode;
/// <summary>
/// کد پستی
/// </summary>
[Description("کد پستی")]
[DisplayName("کد پستی")]
[Category("")]
[DocumentAttributeID("27235")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string PostalCode
{
get { return _PostalCode; }
set { _PostalCode = value; }
}
private string _DetailAddress;
/// <summary>
/// جزئیات آدرس
/// </summary>
[Description("جزئیات آدرس")]
[DisplayName("جزئیات آدرس")]
[Category("")]
[DocumentAttributeID("27237")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string DetailAddress
{
get { return _DetailAddress; }
set { _DetailAddress = value; }
}
private CountryDivision _CoCity;
/// <summary>
/// شهر
/// </summary>
[Description("شهر")]
[DisplayName("شهر")]
[Category("")]
[DocumentAttributeID("27412")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("CountryDivision")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public CountryDivision CoCity
{
get { return _CoCity; }
set { _CoCity = value; }
}
private CountryDivision _CoProvince;
/// <summary>
/// استان
/// </summary>
[Description("استان")]
[DisplayName("استان")]
[Category("")]
[DocumentAttributeID("27411")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("CountryDivision")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public CountryDivision CoProvince
{
get { return _CoProvince; }
set { _CoProvince = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._BasicStreet =  "";
this._PostalCode =  "";
this._DetailAddress =  "";
this._CoCity = new CountryDivision() ;
this._CoProvince = new CountryDivision() ;
}
public override SbnObject Clone(string sNodeName)
{
Address retObject = new Address(this);
retObject.BasicStreet = this._BasicStreet;
retObject.PostalCode = this._PostalCode;
retObject.DetailAddress = this._DetailAddress;
if (! object.ReferenceEquals( this.CoCity , null))
retObject.CoCity = (CountryDivision)this.CoCity.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoProvince , null))
retObject.CoProvince = (CountryDivision)this.CoProvince.Clone(sNodeName) ;
return retObject;
}
public static string at_BasicStreet
{
get
{
return "Address.BasicStreet";
}
}
public static string at_PostalCode
{
get
{
return "Address.PostalCode";
}
}
public static string at_DetailAddress
{
get
{
return "Address.DetailAddress";
}
}
public static string at_CoCityID
{
get
{
return "Address.CoCityID";
}
}
public static string at_CoCityFirstLevelAttributes
{
get
{
return "Address.CoCityFirstLevelAttributes";
}
}
public static string at_CoCity_DivisionTypeFirstLevelAttributes
{
get
{
return "Address.CoCity.DivisionTypeFirstLevelAttributes";
}
}
public static string at_CoCity_ParentFirstLevelAttributes
{
get
{
return "Address.CoCity.ParentFirstLevelAttributes";
}
}
public static string at_CoProvinceID
{
get
{
return "Address.CoProvinceID";
}
}
public static string at_CoProvinceFirstLevelAttributes
{
get
{
return "Address.CoProvinceFirstLevelAttributes";
}
}
public static string at_CoProvince_DivisionTypeFirstLevelAttributes
{
get
{
return "Address.CoProvince.DivisionTypeFirstLevelAttributes";
}
}
public static string at_CoProvince_ParentFirstLevelAttributes
{
get
{
return "Address.CoProvince.ParentFirstLevelAttributes";
}
}
}
}
