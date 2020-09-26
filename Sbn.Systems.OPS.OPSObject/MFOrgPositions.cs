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
[ItemsType ("Sbn.Systems.OPS.OPSObject.MFOrgPosition")]
[SystemName ("OPS")]
[Serializable]
public class MFOrgPositions : SbnListObject<MFOrgPosition> 
{
#region Constructors
public MFOrgPositions()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
MFOrgPositions Col = new  MFOrgPositions ();
foreach (MFOrgPosition objMember in this)
{
Col.Add((MFOrgPosition)objMember.Clone(sNodeName));
}
return Col;
}
}
}
