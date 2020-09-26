using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Sbn.Libs.AssemblyTools;
using Sbn.Core;
using Sbn.Controls.Imaging.ImagingObject;

namespace Sbn.Systems.WMC.WMCObject
{
[Description("آيكون")]
[DisplayName ("آيكون")]
[ObjectCode ("2085")]
[ItemsType("Sbn.Systems.WMC.WMCObject.Icons")]
[SystemName("WMC")]
[Serializable]
public class Icon : ImageDocument 
{
public Icon() 
: base() 
{ 
} 
public Icon(ImageDocument InitialObject) 
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
Icon retObject = new Icon();
retObject.ID = this.ID;
return retObject;
}
}
}
