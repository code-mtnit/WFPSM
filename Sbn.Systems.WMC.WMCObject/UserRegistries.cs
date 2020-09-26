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
    [ItemsType("Sbn.Systems.WMC.WMCObject.UserRegistry")]
    [SystemName("WMC")]

[Serializable]
public class UserRegistries : SbnListObject<UserRegistry> 
{
#region Constructors
public UserRegistries()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
UserRegistries Col = new  UserRegistries ();
foreach (UserRegistry objMember in this)
{
Col.Add((UserRegistry)objMember.Clone(sNodeName));
}
return Col;
}
}
}
