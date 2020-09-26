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
    [ItemsType("Sbn.Systems.ELS.ELSObject.HighLevelEvent")]
    [SystemName("ELS")]

[Serializable]
public class HighLevelEvents : SbnListObject<HighLevelEvent> 
{
#region Constructors
public HighLevelEvents()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
HighLevelEvents Col = new  HighLevelEvents ();
foreach (HighLevelEvent objMember in this)
{
Col.Add((HighLevelEvent)objMember.Clone(sNodeName));
}
return Col;
}
}
}
