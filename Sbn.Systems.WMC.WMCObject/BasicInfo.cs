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
[Description("اطلاعات پايه . مرتبط با اسناد است . كد نمايشي اطلاعات پايه عمومي از يك تا 1000 است و كد عناوين مرتبط با زير سيستمها از محدوده اسناد آن زير سيستم پيروي مي كنند.")]
[DisplayName ("اطلاعات پايه . مرتبط با اسناد است . كد نمايشي اطلاعات پايه عمومي از يك تا 1000 است و كد عناوين مرتبط با زير سيستمها از محدوده اسناد آن زير سيستم پيروي مي كنند.")]
[ObjectCode ("2003")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.BasicInfos")]
    [SystemName("WMC")]
[Serializable]
public class BasicInfo : SbnObject 
{
public BasicInfo() 
: base() 
{ 
} 
public BasicInfo(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private BasicInfoDetails _Details;
/// <summary>
/// فهرست اجزاء
/// </summary>
[Description("فهرست اجزاء")]
[DisplayName("فهرست اجزاء")]
[Category("")]
[DocumentAttributeID("2003")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("BasicInfoDetails")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public BasicInfoDetails Details
{
get { return _Details; }
set { _Details = value; }
}
private SubSystem _SubSystem;
/// <summary>
/// زیر سیستم مرتبط با این اطلاعات پایه که برای اطلاعات پایه عمومی مقدار دهی نمی شود
/// </summary>
[Description("زیر سیستم مرتبط با این اطلاعات پایه که برای اطلاعات پایه عمومی مقدار دهی نمی شود")]
[DisplayName("زیر سیستم مرتبط")]
[Category("")]
[DocumentAttributeID("2098")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("SubSystem")]
[IsMiddleTableExist("False")]
[RelationTable("")]
public SubSystem SubSystem
{
get { return _SubSystem; }
set { _SubSystem = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._Details = new BasicInfoDetails() ;
this._SubSystem = new SubSystem() ;
}
public override SbnObject Clone(string sNodeName)
{
BasicInfo retObject = new BasicInfo();
retObject.ID = this.ID;
if (! object.ReferenceEquals( this.Details , null))
retObject.Details = (BasicInfoDetails)this.Details.Clone(sNodeName) ;
if (! object.ReferenceEquals( this.SubSystem , null))
retObject.SubSystem = (SubSystem)this.SubSystem.Clone(sNodeName) ;
return retObject;
}
public static string at_DetailsID
{
get
{
return "BasicInfo.DetailsID";
}
}
public static string at_DetailsFirstLevelAttributes
{
get
{
return "BasicInfo.DetailsFirstLevelAttributes";
}
}
public static string at_SubSystemID
{
get
{
return "BasicInfo.SubSystemID";
}
}
public static string at_SubSystemFirstLevelAttributes
{
get
{
return "BasicInfo.SubSystemFirstLevelAttributes";
}
}
}
}
