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
    [ItemsType("Sbn.Systems.WMC.WMCObject.Delegation")]
    [SystemName("WMC")]

[Serializable]
public class Delegations : SbnListObject<Delegation> 
{
#region Constructors
public Delegations()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Delegations Col = new  Delegations ();
foreach (Delegation objMember in this)
{
Col.Add((Delegation)objMember.Clone(sNodeName));
}
return Col;
}
}
}
