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
[ItemsType ("Sbn.Systems.WMC.WMCObject.BasicInfoCategory")]
[SystemName ("WMC")]
[Serializable]
public class BasicInfoCategories : SbnListObject<BasicInfoCategory> 
{
#region Constructors
public BasicInfoCategories()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
BasicInfoCategories Col = new  BasicInfoCategories ();
foreach (BasicInfoCategory objMember in this)
{
Col.Add((BasicInfoCategory)objMember.Clone(sNodeName));
}
return Col;
}
}
}
