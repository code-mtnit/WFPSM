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
    [ItemsType("Sbn.Systems.WMC.WMCObject.WFProcess")]
    [SystemName("WMC")]

[Serializable]
public class WFProcesses : SbnListObject<WFProcess> 
{
#region Constructors
public WFProcesses()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WFProcesses Col = new  WFProcesses ();
foreach (WFProcess objMember in this)
{
Col.Add((WFProcess)objMember.Clone(sNodeName));
}
return Col;
}
}
}
