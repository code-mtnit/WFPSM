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
    [ItemsType("Sbn.Systems.WMC.WMCObject.UserInterface")]
    [SystemName("WMC")]

[Serializable]
public class UserInterfaces : SbnListObject<UserInterface> 
{
#region Constructors
public UserInterfaces()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
UserInterfaces Col = new  UserInterfaces ();
foreach (UserInterface objMember in this)
{
Col.Add((UserInterface)objMember.Clone(sNodeName));
}
return Col;
}
}
}
