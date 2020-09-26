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
[ItemsType ("Sbn.Systems.WMC.WMCObject.WFRoleAccessright")]
[SystemName ("WMC")]
[Serializable]
public class WFRoleAccessrights : SbnListObject<WFRoleAccessright> 
{
#region Constructors
public WFRoleAccessrights()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WFRoleAccessrights Col = new  WFRoleAccessrights ();
foreach (WFRoleAccessright objMember in this)
{
Col.Add((WFRoleAccessright)objMember.Clone(sNodeName));
}
return Col;
}
}
}
