using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
namespace Sbn.Systems.WMC.WMCObject
{
[Description("كمكي فعاليت")]
[DisplayName ("كمكي فعاليت")]
[ObjectCode ("2082")]
[Serializable]

public class AOActivity : Activity , ISbnObject
{
public AOActivity() 
: base() 
{ 
} 
public AOActivity(Activity InitialObject) 
: base(InitialObject) 
{ 
} 
private AOActivities _ChildActivities;
/// <summary>
/// 
/// </summary>
[Description("")]
[DisplayName("")]
[Category("")]
[DocumentAttributeID("2141")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Activities")]
public AOActivities ChildActivities
{
get { return _ChildActivities; }
set { _ChildActivities = value; }
}
private AOActivities _PreviousActivities;
/// <summary>
/// جهت استفاده در محیط کاربری تعریف شده است و جنبه ذخیره ندارد
/// </summary>
[Description("جهت استفاده در محیط کاربری تعریف شده است و جنبه ذخیره ندارد")]
[DisplayName("وظایف قبلی")]
[Category("")]
[DocumentAttributeID("2142")]
[Browsable(true)]
[IsRelationalAttribute("False")]
[AttributeType("Activities")]
public AOActivities PreviousActivities
{
get { return _PreviousActivities; }
set { _PreviousActivities = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._ChildActivities = new AOActivities();
this._PreviousActivities = new AOActivities();
}
public override SbnObject Clone(string sNodeName)
{
    AOActivity retObject = new AOActivity();

    retObject.ID = this.ID;
    if (!object.ReferenceEquals(this.ChildActivities, null))
        retObject.ChildActivities = (AOActivities)this.ChildActivities.Clone(sNodeName);

    if (!object.ReferenceEquals(this.PreviousActivities, null))
        retObject.PreviousActivities = (AOActivities)this.PreviousActivities.Clone(sNodeName);

    return (SbnObject )retObject;
}
public static string at_ChildActivitiesID
{
get
{
return "AOActivity.ChildActivitiesID";
}
}
public static string at_ChildActivitiesFirstLevelAttributes
{
get
{
return "AOActivity.ChildActivitiesFirstLevelAttributes";
}
}
public static string at_PreviousActivitiesID
{
get
{
return "AOActivity.PreviousActivitiesID";
}
}
public static string at_PreviousActivitiesFirstLevelAttributes
{
get
{
return "AOActivity.PreviousActivitiesFirstLevelAttributes";
}
}
}
}
