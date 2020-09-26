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
    [ItemsType("Sbn.Systems.ELS.ELSObject.SysUser")]
    [SystemName("ELS")]

[Serializable]
public class SysUsers : SbnListObject<SysUser> 
{
#region Constructors
public SysUsers()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
SysUsers Col = new  SysUsers ();
foreach (SysUser objMember in this)
{
Col.Add((SysUser)objMember.Clone(sNodeName));
}
return Col;
}
}
}
