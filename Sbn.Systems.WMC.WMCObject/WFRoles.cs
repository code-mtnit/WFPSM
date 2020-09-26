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
[ItemsType ("Sbn.Systems.WMC.WMCObject.WFRole")]
[SystemName ("WMC")]
[Serializable]
public class WFRoles : SbnListObject<WFRole> 
{
#region Constructors
public WFRoles()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WFRoles Col = new  WFRoles ();
foreach (WFRole objMember in this)
{
Col.Add((WFRole)objMember.Clone(sNodeName));
}
return Col;
}
}
}
