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
    [ItemsType("Sbn.Systems.ELS.ELSObject.MethodName")]
    [SystemName("ELS")]

[Serializable]
public class MethodNames : SbnListObject<MethodName> 
{
#region Constructors
public MethodNames()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
MethodNames Col = new  MethodNames ();
foreach (MethodName objMember in this)
{
Col.Add((MethodName)objMember.Clone(sNodeName));
}
return Col;
}
}
}
