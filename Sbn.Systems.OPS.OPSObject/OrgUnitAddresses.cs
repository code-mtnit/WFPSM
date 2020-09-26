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
[ItemsType ("Sbn.Systems.OPS.OPSObject.OrgUnitAddress")]
[SystemName ("OPS")]
[Serializable]
public class OrgUnitAddresses : SbnListObject<OrgUnitAddress> 
{
#region Constructors
public OrgUnitAddresses()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
OrgUnitAddresses Col = new  OrgUnitAddresses ();
foreach (OrgUnitAddress objMember in this)
{
Col.Add((OrgUnitAddress)objMember.Clone(sNodeName));
}
return Col;
}
}
}
