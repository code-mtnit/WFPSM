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
    [ItemsType("Sbn.Systems.WMC.WMCObject.ActivityComplementInfo")]
    [SystemName("WMC")]

[Serializable]
public class ActivityComplementInfos : SbnListObject<ActivityComplementInfo> 
{
#region Constructors
public ActivityComplementInfos()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
ActivityComplementInfos Col = new  ActivityComplementInfos ();
foreach (ActivityComplementInfo objMember in this)
{
Col.Add((ActivityComplementInfo)objMember.Clone(sNodeName));
}
return Col;
}
}
}
