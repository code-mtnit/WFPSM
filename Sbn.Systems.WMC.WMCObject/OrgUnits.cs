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
    [ItemsType("Sbn.Systems.WMC.WMCObject.OrgUnit")]
    [SystemName("WMC")]

[Serializable]
public class OrgUnits : SbnListObject<OrgUnit> 
{
#region Constructors
public OrgUnits()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
OrgUnits Col = new  OrgUnits ();
foreach (OrgUnit objMember in this)
{
Col.Add((OrgUnit)objMember.Clone(sNodeName));
}
return Col;
}
}
}
