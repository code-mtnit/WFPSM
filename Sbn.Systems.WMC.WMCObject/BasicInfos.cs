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
    [ItemsType("Sbn.Systems.WMC.WMCObject.BasicInfo")]
    [SystemName("WMC")]

[Serializable]
public class BasicInfos : SbnListObject<BasicInfo> 
{
#region Constructors
public BasicInfos()
: base()
{
}
#endregion Constructors
public override object  Clone(string sNodeName)
{
BasicInfos Col = new  BasicInfos ();
foreach (BasicInfo objMember in this)
{
Col.Add((BasicInfo)objMember.Clone(sNodeName));
}
return Col;
}
}
}
