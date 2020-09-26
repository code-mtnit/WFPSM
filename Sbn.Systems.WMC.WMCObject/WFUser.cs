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
[Description("كاربر")]
[DisplayName ("كاربر")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.WFUsers")]
    [ObjectCode("2014")]
[SystemName ("WMC")]
[Serializable]
public class WFUser : SbnObject 
{
public WFUser() 
: base() 
{ 
} 
public WFUser(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _Username;
/// <summary>
/// شناسه
/// </summary>
[Description("شناسه")]
[DisplayName("شناسه")]
[Category("")]
[DocumentAttributeID("2020")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string Username
{
get { return _Username; }
set { _Username = value; }
}
private string _Password;
/// <summary>
/// رمز
/// </summary>
[Description("رمز")]
[DisplayName("رمز")]
[Category("")]
[DocumentAttributeID("2021")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string Password
{
get { return _Password; }
set { _Password = value; }
}
private string _Description;
/// <summary>
/// شرح
/// </summary>
[Description("شرح")]
[DisplayName("شرح")]
[Category("")]
[DocumentAttributeID("27031")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string Description
{
get { return _Description; }
set { _Description = value; }
}
private WFPerson _CoPerson;
/// <summary>
/// شخص مرتبط
/// </summary>
[Description("شخص مرتبط")]
[DisplayName("شخص مرتبط")]
[Category("")]
[DocumentAttributeID("2042")]
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
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._Username =  "";
this._Password =  "";
this._Description =  "";
this._CoPerson = new WFPerson() ;
}
public override SbnObject Clone(string sNodeName)
{
WFUser retObject = new WFUser();
retObject.ID = this.ID;
retObject.Username = this._Username;
retObject.Password = this._Password;
retObject.Description = this._Description;
if (! object.ReferenceEquals( this.CoPerson , null))
retObject.CoPerson = (WFPerson)this.CoPerson.Clone(sNodeName) ;
return retObject;
}
public static string at_Username
{
get
{
return "WFUser.Username";
}
}
public static string at_Password
{
get
{
return "WFUser.Password";
}
}
public static string at_Description
{
get
{
return "WFUser.Description";
}
}
public static string at_CoPersonID
{
get
{
return "WFUser.CoPersonID";
}
}
public static string at_CoPersonFirstLevelAttributes
{
get
{
return "WFUser.CoPersonFirstLevelAttributes";
}
}
public static string at_CoPerson_WorkersFirstLevelAttributes
{
get
{
return "WFUser.CoPerson.WorkersFirstLevelAttributes";
}
}
public static string at_CoPerson_SexFirstLevelAttributes
{
get
{
return "WFUser.CoPerson.SexFirstLevelAttributes";
}
}
}
}
