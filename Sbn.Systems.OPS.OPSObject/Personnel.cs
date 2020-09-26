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
[Description("پرسنل سازمان كه با شخص تناظر يك به يك دارد")]
[DisplayName ("پرسنل سازمان كه با شخص تناظر يك به يك دارد")]
[ObjectCode ("21004")]
[SystemName ("OPS")]
[ItemsType ("Sbn.Systems.OPS.OPSObject.Personnels")]
[Serializable]
public class Personnel : SbnObject 
{
public Personnel() 
: base() 
{ 
} 
public Personnel(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _PersonnelCode;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("21000")]
[IsRelationalAttribute("false")]
[AttributeType("String")]
[Browsable(true)]
public string PersonnelCode
{
get { return _PersonnelCode; }
set { _PersonnelCode = value; }
}
private MFPerson _Person;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("21001")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("MFPerson")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public MFPerson Person
{
get { return _Person; }
set { _Person = value; }
}
private PersonnelInterdicts _PersonnelInterdicts;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("21002")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("PersonnelInterdicts")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public PersonnelInterdicts PersonnelInterdicts
{
get { return _PersonnelInterdicts; }
set { _PersonnelInterdicts = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._PersonnelCode =  "";
this._Person = new MFPerson() ;
this._PersonnelInterdicts = new PersonnelInterdicts() ;
}
public override SbnObject Clone(string sNodeName)
{
Personnel retObject = new Personnel(this);
retObject.PersonnelCode = this._PersonnelCode;
if (! object.ReferenceEquals( this.Person , null))
retObject.Person = (MFPerson)this.Person.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.PersonnelInterdicts , null))
retObject.PersonnelInterdicts = (PersonnelInterdicts)this.PersonnelInterdicts.Clone(sNodeName) ;
return retObject;
}
public static string at_PersonnelCode
{
get
{
return "Personnel.PersonnelCode";
}
}
public static string at_PersonID
{
get
{
return "Personnel.PersonID";
}
}
public static string at_PersonFirstLevelAttributes
{
get
{
return "Personnel.PersonFirstLevelAttributes";
}
}
public static string at_Person_InterdictsFirstLevelAttributes
{
get
{
return "Personnel.Person.InterdictsFirstLevelAttributes";
}
}
public static string at_Person_PicrtureFirstLevelAttributes
{
get
{
return "Personnel.Person.PicrtureFirstLevelAttributes";
}
}
public static string at_Person_SexFirstLevelAttributes
{
get
{
return "Personnel.Person.SexFirstLevelAttributes";
}
}
public static string at_PersonnelInterdictsID
{
get
{
return "Personnel.PersonnelInterdictsID";
}
}
public static string at_PersonnelInterdictsFirstLevelAttributes
{
get
{
return "Personnel.PersonnelInterdictsFirstLevelAttributes";
}
}
}
}
