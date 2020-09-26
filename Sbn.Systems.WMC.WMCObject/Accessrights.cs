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
    [ItemsType("Sbn.Systems.WMC.WMCObject.Accessright")]
    [SystemName("WMC")]

[Serializable]
public class Accessrights : SbnListObject<Accessright> 
{
#region Constructors
public Accessrights()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Accessrights Col = new  Accessrights ();
foreach (Accessright objMember in this)
{
Col.Add((Accessright)objMember.Clone(sNodeName));
}
return Col;
}
}
}
