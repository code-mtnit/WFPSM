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
    [ItemsType("Sbn.Systems.WMC.WMCObject.OrgUnitBuildingLocation")]
    [SystemName("WMC")]

[Serializable]
public class OrgUnitBuildingLocations : SbnListObject<OrgUnitBuildingLocation> 
{
#region Constructors
public OrgUnitBuildingLocations()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
OrgUnitBuildingLocations Col = new  OrgUnitBuildingLocations ();
foreach (OrgUnitBuildingLocation objMember in this)
{
Col.Add((OrgUnitBuildingLocation)objMember.Clone(sNodeName));
}
return Col;
}
}
}
