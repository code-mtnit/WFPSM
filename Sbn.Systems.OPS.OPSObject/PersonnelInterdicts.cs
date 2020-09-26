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
[ItemsType ("Sbn.Systems.OPS.OPSObject.PersonnelInterdict")]
[SystemName ("OPS")]
[Serializable]
public class PersonnelInterdicts : SbnListObject<PersonnelInterdict> 
{
#region Constructors
public PersonnelInterdicts()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
PersonnelInterdicts Col = new  PersonnelInterdicts ();
foreach (PersonnelInterdict objMember in this)
{
Col.Add((PersonnelInterdict)objMember.Clone(sNodeName));
}
return Col;
}
}
}
