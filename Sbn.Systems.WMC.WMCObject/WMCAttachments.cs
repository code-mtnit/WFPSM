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
    [ItemsType("Sbn.Systems.WMC.WMCObject.WMCAttachment")]
    [SystemName("WMC")]

[Serializable]
public class WMCAttachments : SbnListObject<WMCAttachment> 
{
#region Constructors
public WMCAttachments()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WMCAttachments Col = new  WMCAttachments ();
foreach (WMCAttachment objMember in this)
{
Col.Add((WMCAttachment)objMember.Clone(sNodeName));
}
return Col;
}
}
}
