using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Core;
using MSXML2;
using Sbn.Systems.WMC;
namespace Sbn.Systems.OPS.OPSObject
{
[Description("")]
[DisplayName ("")]
[ItemsType ("Sbn.Systems.OPS.OPSObject.MFOrgUnit")]
[SystemName ("OPS")]
[Serializable]
public class MFOrgUnits : SbnListObject<MFOrgUnit> 
{
#region Constructors
public MFOrgUnits()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
MFOrgUnits Col = new  MFOrgUnits ();
foreach (MFOrgUnit objMember in this)
{
Col.Add((MFOrgUnit)objMember.Clone(sNodeName));
}
return Col;
}
}
}
