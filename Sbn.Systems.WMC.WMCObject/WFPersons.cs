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
    [ItemsType("Sbn.Systems.WMC.WMCObject.WFPerson")]
    [SystemName("WMC")]

[Serializable]
public class WFPersons : SbnListObject<WFPerson> 
{
#region Constructors
public WFPersons()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WFPersons Col = new  WFPersons ();
foreach (WFPerson objMember in this)
{
Col.Add((WFPerson)objMember.Clone(sNodeName));
}
return Col;
}
}
}
