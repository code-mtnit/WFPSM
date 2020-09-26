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
[ObjectCode ("2100")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.UserRegistries")]
    [SystemName("WMC")]
[Serializable]
public class UserRegistry : SbnObject 
{
public UserRegistry() 
: base() 
{ 
} 
public UserRegistry(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
}
public override SbnObject Clone(string sNodeName)
{
UserRegistry retObject = new UserRegistry();
retObject.ID = this.ID;
return retObject;
}
}
}
