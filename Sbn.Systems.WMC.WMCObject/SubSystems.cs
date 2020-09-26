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
    [ItemsType("Sbn.Systems.WMC.WMCObject.SubSystem")]
    [SystemName("WMC")]

[Serializable]
public class SubSystems : SbnListObject<SubSystem> 
{
#region Constructors
public SubSystems()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
SubSystems Col = new  SubSystems ();
foreach (SubSystem objMember in this)
{
Col.Add((SubSystem)objMember.Clone(sNodeName));
}
return Col;
}
}
}
