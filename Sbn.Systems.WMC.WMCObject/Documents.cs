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
    [ItemsType("Sbn.Systems.WMC.WMCObject.Document")]
    [SystemName("WMC")]

[Serializable]
public class Documents : SbnListObject<Document> 
{
#region Constructors
public Documents()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Documents Col = new  Documents ();
foreach (Document objMember in this)
{
Col.Add((Document)objMember.Clone(sNodeName));
}
return Col;
}
}
}
