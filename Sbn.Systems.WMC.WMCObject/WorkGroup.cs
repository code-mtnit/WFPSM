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
[Description("گروه كاري كه اعضاء آن كارمندان مستقل از ساختار سازماني يا طبقه بندي خاصي هستند")]
[DisplayName ("گروه كاري كه اعضاء آن كارمندان مستقل از ساختار سازماني يا طبقه بندي خاصي هستند")]
[ObjectCode ("2016")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.WorkGroups")]
    [SystemName("WMC")]
[Serializable]
public class WorkGroup : SbnObject 
{
public WorkGroup() 
: base() 
{ 
} 
public WorkGroup(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
private WorkGroupMemberships _Memberships;
/// <summary>
/// اعضاء گروه کاری
/// </summary>
[Description("اعضاء گروه کاری")]
[DisplayName("اعضاء")]
[Category("")]
[DocumentAttributeID("2075")]
[Browsable(true)]
[IsRelationalAttribute("True")]
[AttributeType("WorkGroupMemberships")]
[IsMiddleTableExist("True")]
[RelationTable("")]
public WorkGroupMemberships Memberships
{
get { return _Memberships; }
set { _Memberships = value; }
}
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
this._Memberships = new WorkGroupMemberships() ;
}
public override SbnObject Clone(string sNodeName)
{
WorkGroup retObject = new WorkGroup();
retObject.ID = this.ID;
if (! object.ReferenceEquals( this.Memberships , null))
retObject.Memberships = (WorkGroupMemberships)this.Memberships.Clone(sNodeName) ;
return retObject;
}
public static string at_MembershipsID
{
get
{
return "WorkGroup.MembershipsID";
}
}
public static string at_MembershipsFirstLevelAttributes
{
get
{
return "WorkGroup.MembershipsFirstLevelAttributes";
}
}
}
}
