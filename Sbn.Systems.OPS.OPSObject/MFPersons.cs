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
[ItemsType ("Sbn.Systems.OPS.OPSObject.MFPerson")]
[SystemName ("OPS")]
[Serializable]
public class MFPersons : SbnListObject<MFPerson> 
{
#region Constructors
public MFPersons()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
MFPersons Col = new  MFPersons ();
foreach (MFPerson objMember in this)
{
Col.Add((MFPerson)objMember.Clone(sNodeName));
}
return Col;
}
}
}
