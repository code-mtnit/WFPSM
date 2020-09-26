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
[Description("آيتم اطلاعات پايه")]
[DisplayName ("آيتم اطلاعات پايه")]
[ObjectCode ("2004")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.BasicInfoDetails")]
    [SystemName("WMC")]
[Serializable]
public class BasicInfoDetail : SbnObject 
{
public BasicInfoDetail() 
: base() 
{ 
} 
public BasicInfoDetail(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private int _OrderInList;
/// <summary>
/// ترتیب نمایش
/// </summary>
[Description("ترتیب نمایش")]
[DisplayName("ترتیب نمایش")]
[Category("")]
[DocumentAttributeID("2052")]
[IsRelationalAttribute("false")]
[AttributeType("Int")]
[Browsable(true)]
public int OrderInList
{
get { return _OrderInList; }
set { _OrderInList = value; }
}
private BasicInfo _Parent;
/// <summary>
/// عنوان اطلاعات پایه مرتبط یا عنوان پدر
/// </summary>
[Description("عنوان اطلاعات پایه مرتبط یا عنوان پدر")]
[DisplayName("دسته بندی اطلاعات پایه")]
[Category("")]
[DocumentAttributeID("2002")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("BasicInfo")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public BasicInfo Parent
{
get { return _Parent; }
set { _Parent = value; }
}
public override string ToString()
{
return this.Title ;
}
public override void Initialize()
{
base.Initialize();
this._OrderInList = 0;
this._Parent = new BasicInfo() ;
}
public override SbnObject Clone(string sNodeName)
{
BasicInfoDetail retObject = new BasicInfoDetail();
retObject.ID = this.ID;
retObject.OrderInList = this._OrderInList;
if (! object.ReferenceEquals( this.Parent , null))
retObject.Parent = (BasicInfo)this.Parent.Clone(sNodeName) ;
return retObject;
}
public static string at_OrderInList
{
get
{
return "BasicInfoDetail.OrderInList";
}
}
public static string at_ParentID
{
get
{
return "BasicInfoDetail.ParentID";
}
}
public static string at_ParentFirstLevelAttributes
{
get
{
return "BasicInfoDetail.ParentFirstLevelAttributes";
}
}
public static string at_Parent_DetailsFirstLevelAttributes
{
get
{
return "BasicInfoDetail.Parent.DetailsFirstLevelAttributes";
}
}
public static string at_Parent_SubSystemFirstLevelAttributes
{
get
{
return "BasicInfoDetail.Parent.SubSystemFirstLevelAttributes";
}
}
}
}
