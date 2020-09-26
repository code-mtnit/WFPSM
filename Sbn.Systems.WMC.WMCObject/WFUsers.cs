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
    [ItemsType("Sbn.Systems.WMC.WMCObject.WFUser")]
    [SystemName("WMC")]

[Serializable]
public class WFUsers : SbnListObject<WFUser> 
{
#region Constructors
public WFUsers()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WFUsers Col = new  WFUsers ();
foreach (WFUser objMember in this)
{
Col.Add((WFUser)objMember.Clone(sNodeName));
}
return Col;
}
}
}
