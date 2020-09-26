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
[ItemsType ("Sbn.Systems.OPS.OPSObject.Telephone")]
[SystemName ("OPS")]
[Serializable]
public class Telephones : SbnListObject<Telephone> 
{
#region Constructors
public Telephones()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Telephones Col = new  Telephones ();
foreach (Telephone objMember in this)
{
Col.Add((Telephone)objMember.Clone(sNodeName));
}
return Col;
}
}
}
