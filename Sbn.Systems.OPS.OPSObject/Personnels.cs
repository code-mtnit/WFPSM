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
[ItemsType ("Sbn.Systems.OPS.OPSObject.Personnel")]
[SystemName ("OPS")]
[Serializable]
public class Personnels : SbnListObject<Personnel> 
{
#region Constructors
public Personnels()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Personnels Col = new  Personnels ();
foreach (Personnel objMember in this)
{
Col.Add((Personnel)objMember.Clone(sNodeName));
}
return Col;
}
}
}
