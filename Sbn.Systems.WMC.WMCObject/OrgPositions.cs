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
    [ItemsType("Sbn.Systems.WMC.WMCObject.OrgPosition")]
    [SystemName("WMC")]

[Serializable]
public class OrgPositions : SbnListObject<OrgPosition> 
{
#region Constructors
public OrgPositions()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
OrgPositions Col = new  OrgPositions ();
foreach (OrgPosition objMember in this)
{
Col.Add((OrgPosition)objMember.Clone(sNodeName));
}
return Col;
}
}
}
