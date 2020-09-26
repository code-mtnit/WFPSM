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
[ItemsType ("Sbn.Systems.WMC.WMCObject.WFPlace")]
[SystemName ("WMC")]
[Serializable]
public class WFPlaces : SbnListObject<WFPlace> 
{
#region Constructors
public WFPlaces()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WFPlaces Col = new  WFPlaces ();
foreach (WFPlace objMember in this)
{
Col.Add((WFPlace)objMember.Clone(sNodeName));
}
return Col;
}
}
}
