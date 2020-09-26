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
    [ItemsType("Sbn.Systems.WMC.WMCObject.Workflow")]
    [SystemName("WMC")]

[Serializable]
public class Workflows : SbnListObject<Workflow> 
{
#region Constructors
public Workflows()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Workflows Col = new  Workflows ();
foreach (Workflow objMember in this)
{
Col.Add((Workflow)objMember.Clone(sNodeName));
}
return Col;
}
}
}
