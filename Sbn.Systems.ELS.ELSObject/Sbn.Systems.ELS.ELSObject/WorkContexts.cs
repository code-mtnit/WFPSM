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
    [ItemsType("Sbn.Systems.ELS.ELSObject.WorkContext")]
    [SystemName("ELS")]

[Serializable]
public class WorkContexts : SbnListObject<WorkContext> 
{
#region Constructors
public WorkContexts()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
WorkContexts Col = new  WorkContexts ();
foreach (WorkContext objMember in this)
{
Col.Add((WorkContext)objMember.Clone(sNodeName));
}
return Col;
}
}
}
