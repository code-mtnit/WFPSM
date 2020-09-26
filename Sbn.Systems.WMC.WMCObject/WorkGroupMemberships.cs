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
[Description("")]
[DisplayName ("")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.WorkGroupMembership")]
    [SystemName("WMC")]

[Serializable]
public class WorkGroupMemberships : SbnListObject<WorkGroupMembership> 
{
#region Constructors
public WorkGroupMemberships()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WorkGroupMemberships Col = new  WorkGroupMemberships ();
foreach (WorkGroupMembership objMember in this)
{
Col.Add((WorkGroupMembership)objMember.Clone(sNodeName));
}
return Col;
}
}
}
