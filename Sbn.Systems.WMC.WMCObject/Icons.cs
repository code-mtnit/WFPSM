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
    [ItemsType("Sbn.Systems.WMC.WMCObject.Icon")]
    [SystemName("WMC")]

[Serializable]
public class Icons : SbnListObject<Icon> 
{
#region Constructors
public Icons()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Icons Col = new  Icons ();
foreach (Icon objMember in this)
{
Col.Add((Icon)objMember.Clone(sNodeName));
}
return Col;
}
}
}
