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
[Description("")]
[DisplayName ("")]
[ObjectCode ("21010")]
[SystemName ("OPS")]
[ItemsType ("Sbn.Systems.OPS.OPSObject.Telephones")]
[Serializable]
public class Telephone : SbnObject 
{
public Telephone() 
: base() 
{ 
} 
public Telephone(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private string _PostalCode;
/// <summary>
/// کد پستی
/// </summary>
[Description("کد پستی")]
[DisplayName("کد پستی")]
[Category("")]
[DocumentAttributeID("27236")]
[IsRelationalAttribute("false")]
[AttributeType("NotSet")]
[Browsable(true)]
public string PostalCode
{
get { return _PostalCode; }
set { _PostalCode = value; }
}
private long _PreCode;
/// <summary>
/// پیش کد
/// </summary>
[Description("پیش کد")]
[DisplayName("پیش کد")]
[Category("")]
[DocumentAttributeID("27240")]
[IsRelationalAttribute("false")]
[AttributeType("Long")]
[Browsable(true)]
public long PreCode
{
get { return _PreCode; }
set { _PreCode = value; }
}
private BasicInfoDetail _TelType;
/// <summary>
/// نوع تلفن
/// </summary>
[Description("نوع تلفن")]
[DisplayName("نوع تلفن")]
[Category("")]
[DocumentAttributeID("27425")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("BasicInfoDetail")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public BasicInfoDetail TelType
{
get { return _TelType; }
set { _TelType = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._PostalCode = null;
this._PreCode = 0;
this._TelType = new BasicInfoDetail() ;
}
public override SbnObject Clone(string sNodeName)
{
Telephone retObject = new Telephone(this);
retObject.PostalCode = this._PostalCode;
retObject.PreCode = this._PreCode;
if (! object.ReferenceEquals( this.TelType , null))
retObject.TelType = (BasicInfoDetail)this.TelType.Clone(sNodeName) ;
return retObject;
}
public static string at_PostalCode
{
get
{
return "Telephone.PostalCode";
}
}
public static string at_PreCode
{
get
{
return "Telephone.PreCode";
}
}
public static string at_TelTypeID
{
get
{
return "Telephone.TelTypeID";
}
}
public static string at_TelTypeFirstLevelAttributes
{
get
{
return "Telephone.TelTypeFirstLevelAttributes";
}
}
public static string at_TelType_ParentFirstLevelAttributes
{
get
{
return "Telephone.TelType.ParentFirstLevelAttributes";
}
}
}
}
