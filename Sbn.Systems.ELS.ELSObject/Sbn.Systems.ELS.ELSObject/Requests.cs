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
    [ItemsType("Sbn.Systems.ELS.ELSObject.Request")]
    [SystemName("ELS")]

[Serializable]
public class Requests : SbnListObject<Request> 
{
#region Constructors
public Requests()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
Requests Col = new  Requests ();
foreach (Request objMember in this)
{
Col.Add((Request)objMember.Clone(sNodeName));
}
return Col;
}
}
}
