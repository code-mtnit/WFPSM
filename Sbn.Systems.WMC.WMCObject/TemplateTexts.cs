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
    [ItemsType("Sbn.Systems.WMC.WMCObject.TemplateText")]
    [SystemName("WMC")]

[Serializable]
public class TemplateTexts : SbnListObject<TemplateText> 
{
#region Constructors
public TemplateTexts()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
TemplateTexts Col = new  TemplateTexts ();
foreach (TemplateText objMember in this)
{
Col.Add((TemplateText)objMember.Clone(sNodeName));
}
return Col;
}
}
}
