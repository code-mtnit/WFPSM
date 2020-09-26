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
    [ItemsType("Sbn.Systems.ELS.ELSObject.ExceptionEvent")]
    [SystemName("ELS")]

[Serializable]
public class ExceptionEvents : SbnListObject<ExceptionEvent> 
{
#region Constructors
public ExceptionEvents()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
ExceptionEvents Col = new  ExceptionEvents ();
foreach (ExceptionEvent objMember in this)
{
Col.Add((ExceptionEvent)objMember.Clone(sNodeName));
}
return Col;
}
}
}
