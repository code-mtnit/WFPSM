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
    [ItemsType("Sbn.Systems.WMC.WMCObject.DocumentType")]
    [SystemName("WMC")]

[Serializable]
public class DocumentTypes : SbnListObject<DocumentType> 
{
#region Constructors
public DocumentTypes()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
DocumentTypes Col = new  DocumentTypes ();
foreach (DocumentType objMember in this)
{
Col.Add((DocumentType)objMember.Clone(sNodeName));
}
return Col;
}
}
}
