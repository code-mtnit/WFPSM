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
[ItemsType ("Sbn.Systems.WMC.WMCObject.WFRoleRestriction")]
[SystemName ("WMC")]
[Serializable]
public class WFRoleRestrictions : SbnListObject<WFRoleRestriction> 
{
#region Constructors
public WFRoleRestrictions()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WFRoleRestrictions Col = new  WFRoleRestrictions ();
foreach (WFRoleRestriction objMember in this)
{
Col.Add((WFRoleRestriction)objMember.Clone(sNodeName));
}
return Col;
}
}
}
