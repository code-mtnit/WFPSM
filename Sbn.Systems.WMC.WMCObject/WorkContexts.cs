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
    [ItemsType("Sbn.Systems.WMC.WMCObject.WorkContext")]
    [SystemName("WMC")]

[Serializable]
public class WorkContexts : SbnListObject<WorkContext> 
{
#region Constructors
public WorkContexts()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WorkContexts Col = new  WorkContexts ();
foreach (WorkContext objMember in this)
{
Col.Add((WorkContext)objMember.Clone(sNodeName));
}
return Col;
}
}
}
