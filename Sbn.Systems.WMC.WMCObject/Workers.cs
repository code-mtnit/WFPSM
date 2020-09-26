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
    [ItemsType("Sbn.Systems.WMC.WMCObject.Worker")]
    [SystemName("WMC")]

[Serializable]
public class Workers : SbnListObject<Worker> 
{
#region Constructors
public Workers()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Workers Col = new  Workers ();
foreach (Worker objMember in this)
{
Col.Add((Worker)objMember.Clone(sNodeName));
}
return Col;
}
}
}
