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
    [ItemsType("Sbn.Systems.WMC.WMCObject.DocumentPropValue")]
    [SystemName("WMC")]

[Serializable]
public class DocumentPropValues : SbnListObject<DocumentPropValue> 
{
#region Constructors
public DocumentPropValues()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
DocumentPropValues Col = new  DocumentPropValues ();
foreach (DocumentPropValue objMember in this)
{
Col.Add((DocumentPropValue)objMember.Clone(sNodeName));
}
return Col;
}
}
}
