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
    [ItemsType("Sbn.Systems.WMC.WMCObject.TrustedDocument")]
    [SystemName("WMC")]

[Serializable]
public class TrustedDocuments : SbnListObject<TrustedDocument> 
{
#region Constructors
public TrustedDocuments()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
TrustedDocuments Col = new  TrustedDocuments ();
foreach (TrustedDocument objMember in this)
{
Col.Add((TrustedDocument)objMember.Clone(sNodeName));
}
return Col;
}
}
}
