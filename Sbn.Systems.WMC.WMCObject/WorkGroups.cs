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
    [ItemsType("Sbn.Systems.WMC.WMCObject.WorkGroup")]
    [SystemName("WMC")]

[Serializable]
public class WorkGroups : SbnListObject<WorkGroup> 
{
#region Constructors
public WorkGroups()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WorkGroups Col = new  WorkGroups ();
foreach (WorkGroup objMember in this)
{
Col.Add((WorkGroup)objMember.Clone(sNodeName));
}
return Col;
}
}
}
