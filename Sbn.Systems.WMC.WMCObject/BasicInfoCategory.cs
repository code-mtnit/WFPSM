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
[Description("دستبه بندي اطلاعات پايه")]
[DisplayName ("دستبه بندي اطلاعات پايه")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.BasicInfoCategory")]
    [ObjectCode("2125")]
[SystemName ("WMC")]
[Serializable]
public class BasicInfoCategory : SbnObject 
{
public BasicInfoCategory() 
: base() 
{ 
} 
public BasicInfoCategory(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private BasicInfo _CoBasicInfo;
/// <summary>
/// اطلاعات پایه مرتبط که میخواهیم روی آن دسته بندی ایجاد کنیم
/// </summary>
[Description("اطلاعات پایه مرتبط که میخواهیم روی آن دسته بندی ایجاد کنیم")]
[DisplayName("اطلاعات پایه مرتبط")]
[Category("")]
[DocumentAttributeID("27336")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("BasicInfo")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public BasicInfo CoBasicInfo
{
get { return _CoBasicInfo; }
set { _CoBasicInfo = value; }
}
private BasicInfoDetails _CoDetails;
/// <summary>
/// مقادیر مرتبط
/// </summary>
[Description("مقادیر مرتبط")]
[DisplayName("مقادیر")]
[Category("")]
[DocumentAttributeID("27337")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("BasicInfoDetails")]
[IsMiddleTableExist("False")]
[RelationTable("BasicInfoCat_Detail")]
public BasicInfoDetails CoDetails
{
get { return _CoDetails; }
set { _CoDetails = value; }
}
private BasicInfoDetail _ParentBIDetail;
/// <summary>
/// ارتباط با یک اطلاعات پایه جزء از یک دسته اطلاعات پایه ای دیگر برای ایجاد ساختار درختی در موارد خاص
/// </summary>
[Description("ارتباط با یک اطلاعات پایه جزء از یک دسته اطلاعات پایه ای دیگر برای ایجاد ساختار درختی در موارد خاص")]
[DisplayName("اطلاعات پایه بالادستی")]
[Category("")]
[DocumentAttributeID("27339")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("BasicInfoDetail")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public BasicInfoDetail ParentBIDetail
{
get { return _ParentBIDetail; }
set { _ParentBIDetail = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._CoBasicInfo = new BasicInfo() ;
this._CoDetails = new BasicInfoDetails() ;
this._ParentBIDetail = new BasicInfoDetail() ;
}
public override SbnObject Clone(string sNodeName)
{
BasicInfoCategory retObject = new BasicInfoCategory();
retObject.ID = this.ID;
if (! object.ReferenceEquals( this.CoBasicInfo , null))
retObject.CoBasicInfo = (BasicInfo)this.CoBasicInfo.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.CoDetails , null))
retObject.CoDetails = (BasicInfoDetails)this.CoDetails.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.ParentBIDetail , null))
retObject.ParentBIDetail = (BasicInfoDetail)this.ParentBIDetail.Clone(sNodeName) ;
return retObject;
}
public static string at_CoBasicInfoID
{
get
{
return "BasicInfoCategory.CoBasicInfoID";
}
}
public static string at_CoBasicInfoFirstLevelAttributes
{
get
{
return "BasicInfoCategory.CoBasicInfoFirstLevelAttributes";
}
}
public static string at_CoBasicInfo_DetailsFirstLevelAttributes
{
get
{
return "BasicInfoCategory.CoBasicInfo.DetailsFirstLevelAttributes";
}
}
public static string at_CoBasicInfo_SubSystemFirstLevelAttributes
{
get
{
return "BasicInfoCategory.CoBasicInfo.SubSystemFirstLevelAttributes";
}
}
public static string at_CoDetailsID
{
get
{
return "BasicInfoCategory.CoDetailsID";
}
}
public static string at_CoDetailsFirstLevelAttributes
{
get
{
return "BasicInfoCategory.CoDetailsFirstLevelAttributes";
}
}
public static string at_ParentBIDetailID
{
get
{
return "BasicInfoCategory.ParentBIDetailID";
}
}
public static string at_ParentBIDetailFirstLevelAttributes
{
get
{
return "BasicInfoCategory.ParentBIDetailFirstLevelAttributes";
}
}
public static string at_ParentBIDetail_ParentFirstLevelAttributes
{
get
{
return "BasicInfoCategory.ParentBIDetail.ParentFirstLevelAttributes";
}
}
}
}
