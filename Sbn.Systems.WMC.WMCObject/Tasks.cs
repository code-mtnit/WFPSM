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
    [ItemsType("Sbn.Systems.WMC.WMCObject.Task")]
    [SystemName("WMC")]

[Serializable]
public class Tasks : SbnListObject<Task> 
{
#region Constructors
public Tasks()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Tasks Col = new  Tasks ();
foreach (Task objMember in this)
{
Col.Add((Task)objMember.Clone(sNodeName));
}
return Col;
}
}
}
