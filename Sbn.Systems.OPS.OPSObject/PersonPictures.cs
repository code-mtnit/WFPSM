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
[ItemsType ("Sbn.Systems.OPS.OPSObject.PersonPicture")]
[SystemName ("OPS")]
[Serializable]
public class PersonPictures : SbnListObject<PersonPicture> 
{
#region Constructors
public PersonPictures()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
PersonPictures Col = new  PersonPictures ();
foreach (PersonPicture objMember in this)
{
Col.Add((PersonPicture)objMember.Clone(sNodeName));
}
return Col;
}
}
}
