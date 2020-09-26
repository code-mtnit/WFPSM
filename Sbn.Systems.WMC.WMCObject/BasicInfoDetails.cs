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
    [ItemsType("Sbn.Systems.WMC.WMCObject.BasicInfoDetail")]
    [SystemName("WMC")]

[Serializable]
public class BasicInfoDetails : SbnListObject<BasicInfoDetail> 
{
#region Constructors
public BasicInfoDetails()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
BasicInfoDetails Col = new  BasicInfoDetails ();
foreach (BasicInfoDetail objMember in this)
{
Col.Add((BasicInfoDetail)objMember.Clone(sNodeName));
}
return Col;
}
}
}
