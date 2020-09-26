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
[ObjectCode ("21014")]
[SystemName ("OPS")]
[ItemsType ("Sbn.Systems.OPS.OPSObject.CountryDivisions")]
[Serializable]
public class CountryDivision : SbnObject 
{
public CountryDivision() 
: base() 
{ 
} 
public CountryDivision(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private BasicInfoDetail _DivisionType;
/// <summary>
/// نوع تقسیمات
/// </summary>
[Description("نوع تقسیمات")]
[DisplayName("نوع تقسیمات")]
[Category("")]
[DocumentAttributeID("27409")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("BasicInfoDetail")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public BasicInfoDetail DivisionType
{
get { return _DivisionType; }
set { _DivisionType = value; }
}
private CountryDivision _Parent;
/// <summary>
/// دسته بالایی
/// </summary>
[Description("دسته بالایی")]
[DisplayName("دسته بالایی")]
[Category("")]
[DocumentAttributeID("27410")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("CountryDivision")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public CountryDivision Parent
{
get { return _Parent; }
set { _Parent = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._DivisionType = new BasicInfoDetail() ;
this._Parent = new CountryDivision() ;
}
public override SbnObject Clone(string sNodeName)
{
CountryDivision retObject = new CountryDivision(this);
if (! object.ReferenceEquals( this.DivisionType , null))
retObject.DivisionType = (BasicInfoDetail)this.DivisionType.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.Parent , null))
retObject.Parent = (CountryDivision)this.Parent.Clone(sNodeName) ;
return retObject;
}
public static string at_DivisionTypeID
{
get
{
return "CountryDivision.DivisionTypeID";
}
}
public static string at_DivisionTypeFirstLevelAttributes
{
get
{
return "CountryDivision.DivisionTypeFirstLevelAttributes";
}
}
public static string at_DivisionType_ParentFirstLevelAttributes
{
get
{
return "CountryDivision.DivisionType.ParentFirstLevelAttributes";
}
}
public static string at_ParentID
{
get
{
return "CountryDivision.ParentID";
}
}
public static string at_ParentFirstLevelAttributes
{
get
{
return "CountryDivision.ParentFirstLevelAttributes";
}
}
public static string at_Parent_DivisionTypeFirstLevelAttributes
{
get
{
return "CountryDivision.Parent.DivisionTypeFirstLevelAttributes";
}
}
public static string at_Parent_ParentFirstLevelAttributes
{
get
{
return "CountryDivision.Parent.ParentFirstLevelAttributes";
}
}
}
}
