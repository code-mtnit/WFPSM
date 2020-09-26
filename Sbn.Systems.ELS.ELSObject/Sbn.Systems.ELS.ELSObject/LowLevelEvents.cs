using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Core;
using MSXML2;
namespace Sbn.Systems.ELS.ELSObject
{
[Description("")]
[DisplayName ("")]
    [ItemsType("Sbn.Systems.ELS.ELSObject.LowLevelEvent")]
    [SystemName("ELS")]

[Serializable]
public class LowLevelEvents : SbnListObject<LowLevelEvent> 
{
#region Constructors
public LowLevelEvents()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
LowLevelEvents Col = new  LowLevelEvents ();
foreach (LowLevelEvent objMember in this)
{
Col.Add((LowLevelEvent)objMember.Clone(sNodeName));
}
return Col;
}
}
}
