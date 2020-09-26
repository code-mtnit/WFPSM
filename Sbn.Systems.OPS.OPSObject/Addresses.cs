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
[ItemsType ("Sbn.Systems.OPS.OPSObject.Address")]
[SystemName ("OPS")]
[Serializable]
public class Addresses : SbnListObject<Address> 
{
#region Constructors
public Addresses()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Addresses Col = new  Addresses ();
foreach (Address objMember in this)
{
Col.Add((Address)objMember.Clone(sNodeName));
}
return Col;
}
}
}
