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
[ItemsType ("Sbn.Systems.OPS.OPSObject.CountryDivision")]
[SystemName ("OPS")]
[Serializable]
public class CountryDivisions : SbnListObject<CountryDivision> 
{
#region Constructors
public CountryDivisions()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
CountryDivisions Col = new  CountryDivisions ();
foreach (CountryDivision objMember in this)
{
Col.Add((CountryDivision)objMember.Clone(sNodeName));
}
return Col;
}
}
}
