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
    [ItemsType("Sbn.Systems.WMC.WMCObject.WorkerDomainRestriction")]
    [SystemName("WMC")]

[Serializable]
public class WorkerDomainRestrictions : SbnListObject<WorkerDomainRestriction> 
{
#region Constructors
public WorkerDomainRestrictions()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WorkerDomainRestrictions Col = new  WorkerDomainRestrictions ();
foreach (WorkerDomainRestriction objMember in this)
{
Col.Add((WorkerDomainRestriction)objMember.Clone(sNodeName));
}
return Col;
}
}
}
