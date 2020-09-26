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
    [ItemsType("Sbn.Systems.WMC.WMCObject.WorkerAccessright")]
    [SystemName("WMC")]

[Serializable]
public class WorkerAccessrights : SbnListObject<WorkerAccessright> 
{
#region Constructors
public WorkerAccessrights()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WorkerAccessrights Col = new  WorkerAccessrights ();
foreach (WorkerAccessright objMember in this)
{
Col.Add((WorkerAccessright)objMember.Clone(sNodeName));
}
return Col;
}
}
}
