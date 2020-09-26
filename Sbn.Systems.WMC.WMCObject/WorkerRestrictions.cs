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
    [ItemsType("Sbn.Systems.WMC.WMCObject.WorkerRestriction")]
    [SystemName("WMC")]

[Serializable]
public class WorkerRestrictions : SbnListObject<WorkerRestriction> 
{
#region Constructors
public WorkerRestrictions()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WorkerRestrictions Col = new  WorkerRestrictions ();
foreach (WorkerRestriction objMember in this)
{
Col.Add((WorkerRestriction)objMember.Clone(sNodeName));
}
return Col;
}
}
}
