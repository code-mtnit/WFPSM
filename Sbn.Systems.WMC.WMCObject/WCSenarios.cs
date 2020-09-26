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
    [ItemsType("Sbn.Systems.WMC.WMCObject.WCSenario")]
    [SystemName("WMC")]

[Serializable]
public class WCSenarios : SbnListObject<WCSenario> 
{
#region Constructors
public WCSenarios()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WCSenarios Col = new  WCSenarios ();
foreach (WCSenario objMember in this)
{
Col.Add((WCSenario)objMember.Clone(sNodeName));
}
return Col;
}
}
}
