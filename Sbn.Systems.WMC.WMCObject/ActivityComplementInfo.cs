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
[Description("اطلاعات تكميلي اقدام")]
[DisplayName ("اطلاعات تكميلي اقدام")]
    [ItemsType("Sbn.Systems.WMC.WMCObject.ActivityComplementInfos")]
    [ObjectCode("2069")]
[SystemName ("WMC")]
[Serializable]
public class ActivityComplementInfo : SbnObject 
{
public ActivityComplementInfo() 
: base() 
{ 
} 
public ActivityComplementInfo(SbnObject InitialObject) 
: base(InitialObject) 
{ 
} 
public override string ToString()
{
return base.ToString();
}
public override void Initialize()
{
base.Initialize();
}
public override SbnObject Clone(string sNodeName)
{
ActivityComplementInfo retObject = new ActivityComplementInfo();
retObject.ID = this.ID;
return retObject;
}
}
}
