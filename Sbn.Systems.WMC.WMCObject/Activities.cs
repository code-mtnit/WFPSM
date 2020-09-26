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
    [ItemsType("Sbn.Systems.WMC.WMCObject.Activity")]
    [SystemName("WMC")]

[Serializable]
public class Activities : SbnListObject<Activity> 
{
#region Constructors
public Activities()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Activities Col = new  Activities ();
foreach (Activity objMember in this)
{
Col.Add((Activity)objMember.Clone(sNodeName));
}
return Col;
}
}
}
